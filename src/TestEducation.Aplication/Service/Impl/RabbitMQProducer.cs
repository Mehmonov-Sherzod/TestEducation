using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using TestEducation.Aplication.Models;
using TestEducation.Aplication.Models.Users;

namespace TestEducation.Aplication.Service.Impl
{

    /// <summary>
    /// RabbitMQ Producer - RabbitMQ queue ga xabar yuboruvchi service.
    /// Bu class Singleton sifatida ro'yxatdan o'tgan va dastur davomida bitta instance ishlaydi.
    /// IDisposable interface'ini implement qiladi - ulanishlarni to'g'ri yopish uchun.
    /// </summary>
    /// 

    public class RabbitMQProducer : IRabbitMQproducer , IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RabbitMQProducer> _logger;
        private IConnection _connection;
        private IModel _channel;
        private readonly string _queueName;
        private readonly object _lock = new object();

        public RabbitMQProducer(IConfiguration configuration, ILogger<RabbitMQProducer> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _queueName = _configuration["RabbitMQ:QueueName"] ?? "orders_queue";
            _logger.LogInformation("RabbitMQ Producer yaratildi");
        }

        private void EnsureConnection()
        {
            lock (_lock)
            {
                if (_connection == null || !_connection.IsOpen)
                {
                    _channel?.Dispose();
                    _connection?.Dispose();

                    try
                    {
                        var factory = new ConnectionFactory()
                        {
                            HostName = _configuration["RabbitMQ:HostName"] ?? "localhost",
                            UserName = _configuration["RabbitMQ:UserName"] ?? "guest",
                            Password = _configuration["RabbitMQ:Password"] ?? "guest",
                            Port = int.Parse(_configuration["RabbitMQ:Port"] ?? "5672"),
                            RequestedHeartbeat = TimeSpan.FromSeconds(10),
                            NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                            AutomaticRecoveryEnabled = true
                        };

                        _connection = factory.CreateConnection();
                        _channel = _connection.CreateModel();

                        _channel.QueueDeclare(
                            queue: _queueName,
                            durable: true,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        _logger.LogInformation("RabbitMQ Producer muvaffaqiyatli ulandi,  Ishlatilayotgan Queue nomi: {QueueName}", _queueName);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "RabbitMQ Producer ulanishda xatolik: {Message}", ex.Message);
                        throw;
                    }
                }
            }
        }

        // <<<< O'zgarish shu yerda! T emas, OrderCreatedDto qabul qilamiz
       

        // Agar sizga hali ham generik SendMessage kerak bo'lsa, uni saqlab qolishingiz mumkin,
        // lekin u boshqa DTOlar uchun ishlaydi, Order uchun emas.
        // public void SendMessage<T>(T message) {...}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            try
            {
                _channel?.Close();
                _connection?.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RabbitMQ Producer dispose qilishda xatolik");
            }
            finally
            {
                _channel?.Dispose();
                _connection?.Dispose();
            }
        }

        public void SedMessage(LoginDTO loginDTO)
        {
            EnsureConnection();

            try
            {
                if (_channel == null || _channel.IsClosed)
                {
                    _logger.LogError("RabbitMQ channel yopiq yoki mavjud emas, xabar yuborilmadi.");
                    throw new InvalidOperationException("RabbitMQ channel is not open or available.");
                }

                string json = JsonSerializer.Serialize(loginDTO);
                var body = Encoding.UTF8.GetBytes(json);

                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;

                _channel.BasicPublish(
                    exchange: "",
                    routingKey: _queueName,
                    basicProperties: properties,
                    body: body);

                _logger.LogInformation("Xabar RabbitMQ ga yuborildi: {Message}", json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RabbitMQ ga xabar yuborishda xatolik: {Message}", ex.Message);
                throw;
            }
        }
    }
}


/* ============================================
 * XULOSA - RabbitMQProducer qanday ishlaydi:
 * ============================================
 *
 * 1. BOSHLASH (Constructor):
 *    - Configuration va Logger injected qilinadi
 *    - Queue nomi appsettings.json dan o'qiladi
 *    - Hali RabbitMQ ga ulanish o'rnatilmaydi (lazy initialization)
 *
 * 2. XABAR YUBORISH (SendMessage):
 *    a) EnsureConnection() chaqiriladi - ulanish mavjud bo'lishini ta'minlaydi
 *    b) OrderCreatedDto -> JSON string -> byte array
 *    c) BasicPublish() orqali xabar queue ga yuboriladi
 *    d) Log yoziladi
 *
 * 3. ULANISHNI TA'MINLASH (EnsureConnection):
 *    - Lock bilan thread-safety ta'minlanadi
 *    - Agar ulanish yo'q yoki yopilgan bo'lsa:
 *      * ConnectionFactory yaratiladi
 *      * Connection va Channel ochiladi
 *      * Queue declare qilinadi
 *    - AutomaticRecoveryEnabled = true - avtomatik qayta ulanish
 *
 * 4. TOZALASH (Dispose):
 *    - Channel va Connection to'g'ri yopiladi
 *    - Barcha resurslar tozalanadi
 *
 * ============================================
 * MUHIM TUSHUNCHALAR:
 * ============================================
 *
 * - Connection: RabbitMQ server bilan TCP/IP ulanish
 * - Channel: Connection ichidagi virtual ulanish (xabarlar shu orqali yuboriladi)
 * - Queue: Xabarlar saqlanadigan navbat
 * - Exchange: Xabarlarni qaysi queue ga yuborishni belgilaydi (bo'sh = default)
 * - RoutingKey: Xabarni qaysi queue ga yuborish kerakligini ko'rsatadi
 * - Persistent: Xabar disk ga yoziladi (RabbitMQ qayta ishga tushganda ham saqlanadi)
 * - Durable: Queue disk ga yoziladi (RabbitMQ qayta ishga tushganda ham saqlanadi)
 *
 * ============================================
 * HAYOTIY MISOL (Uber Taxi):
 * ============================================
 *
 * 1. Foydalanuvchi taksi buyurtma qildi
 * 2. Controller: RabbitMQProducer.SendMessage(orderDto) chaqiradi
 * 3. Producer: Xabarni "taxi_orders" queue ga yuboradi
 * 4. Producer: Darhol javob qaytaradi (blocking yo'q!)
 * 5. Foydalanuvchi: "Buyurtmangiz qabul qilindi" xabarini oladi
 * 6. RabbitMQConsumer (background): Xabarni queue dan olib, haydovchilarga yuboradi
 *
 * Natija: Foydalanuvchi tez javob oladi, og'ir ishlar background da bajariladi!
 */

