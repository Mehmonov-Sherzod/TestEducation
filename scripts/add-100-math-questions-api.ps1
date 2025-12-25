# 100 ta Matematik savol qo'shish - API orqali
# Ishlatish: .\add-100-math-questions-api.ps1 -TopicId "your-topic-guid-here"

param(
    [Parameter(Mandatory=$true)]
    [string]$TopicId,

    [string]$ApiBase = "https://localhost:7164"
)

# Matematik savollar
$mathQuestions = @{
    easy = @(
        @{ q = "2 + 3 = ?"; a = @("5", "4", "6", "7"); c = 0 }
        @{ q = "5 - 2 = ?"; a = @("3", "2", "4", "1"); c = 0 }
        @{ q = "3 * 2 = ?"; a = @("6", "5", "4", "8"); c = 0 }
        @{ q = "8 / 2 = ?"; a = @("4", "3", "5", "6"); c = 0 }
        @{ q = "10 + 5 = ?"; a = @("15", "14", "16", "12"); c = 0 }
        @{ q = "7 - 4 = ?"; a = @("3", "2", "4", "5"); c = 0 }
        @{ q = "4 * 3 = ?"; a = @("12", "10", "14", "11"); c = 0 }
        @{ q = "9 / 3 = ?"; a = @("3", "2", "4", "6"); c = 0 }
        @{ q = "6 + 7 = ?"; a = @("13", "12", "14", "11"); c = 0 }
        @{ q = "15 - 8 = ?"; a = @("7", "6", "8", "9"); c = 0 }
        @{ q = "5 * 5 = ?"; a = @("25", "20", "30", "15"); c = 0 }
        @{ q = "20 / 4 = ?"; a = @("5", "4", "6", "8"); c = 0 }
        @{ q = "11 + 9 = ?"; a = @("20", "19", "21", "18"); c = 0 }
        @{ q = "18 - 9 = ?"; a = @("9", "8", "10", "7"); c = 0 }
        @{ q = "6 * 4 = ?"; a = @("24", "22", "26", "20"); c = 0 }
        @{ q = "16 / 4 = ?"; a = @("4", "3", "5", "6"); c = 0 }
        @{ q = "8 + 8 = ?"; a = @("16", "15", "17", "14"); c = 0 }
        @{ q = "20 - 12 = ?"; a = @("8", "7", "9", "10"); c = 0 }
        @{ q = "7 * 3 = ?"; a = @("21", "20", "22", "18"); c = 0 }
        @{ q = "30 / 5 = ?"; a = @("6", "5", "7", "8"); c = 0 }
        @{ q = "14 + 6 = ?"; a = @("20", "19", "21", "18"); c = 0 }
        @{ q = "25 - 10 = ?"; a = @("15", "14", "16", "13"); c = 0 }
        @{ q = "8 * 2 = ?"; a = @("16", "14", "18", "12"); c = 0 }
        @{ q = "24 / 6 = ?"; a = @("4", "3", "5", "6"); c = 0 }
        @{ q = "9 + 11 = ?"; a = @("20", "19", "21", "18"); c = 0 }
        @{ q = "30 - 15 = ?"; a = @("15", "14", "16", "13"); c = 0 }
        @{ q = "9 * 2 = ?"; a = @("18", "16", "20", "14"); c = 0 }
        @{ q = "36 / 6 = ?"; a = @("6", "5", "7", "8"); c = 0 }
        @{ q = "12 + 13 = ?"; a = @("25", "24", "26", "23"); c = 0 }
        @{ q = "50 - 25 = ?"; a = @("25", "24", "26", "20"); c = 0 }
    )
    medium = @(
        @{ q = "15 * 12 = ?"; a = @("180", "170", "190", "160"); c = 0 }
        @{ q = "144 / 12 = ?"; a = @("12", "11", "13", "14"); c = 0 }
        @{ q = "sqrt(64) = ?"; a = @("8", "6", "7", "9"); c = 0 }
        @{ q = "3^2 + 4^2 = ?"; a = @("25", "24", "26", "23"); c = 0 }
        @{ q = "2^3 = ?"; a = @("8", "6", "9", "4"); c = 0 }
        @{ q = "45 + 67 = ?"; a = @("112", "110", "114", "108"); c = 0 }
        @{ q = "123 - 78 = ?"; a = @("45", "43", "47", "44"); c = 0 }
        @{ q = "18 * 6 = ?"; a = @("108", "106", "110", "104"); c = 0 }
        @{ q = "156 / 12 = ?"; a = @("13", "12", "14", "11"); c = 0 }
        @{ q = "sqrt(100) = ?"; a = @("10", "9", "11", "12"); c = 0 }
        @{ q = "5^2 - 3^2 = ?"; a = @("16", "14", "18", "12"); c = 0 }
        @{ q = "4^3 = ?"; a = @("64", "48", "72", "56"); c = 0 }
        @{ q = "89 + 56 = ?"; a = @("145", "143", "147", "141"); c = 0 }
        @{ q = "200 - 87 = ?"; a = @("113", "111", "115", "110"); c = 0 }
        @{ q = "25 * 8 = ?"; a = @("200", "190", "210", "180"); c = 0 }
        @{ q = "225 / 15 = ?"; a = @("15", "14", "16", "13"); c = 0 }
        @{ q = "sqrt(144) = ?"; a = @("12", "11", "13", "14"); c = 0 }
        @{ q = "6^2 + 8^2 = ?"; a = @("100", "98", "102", "96"); c = 0 }
        @{ q = "3^4 = ?"; a = @("81", "64", "72", "90"); c = 0 }
        @{ q = "156 + 289 = ?"; a = @("445", "443", "447", "441"); c = 0 }
        @{ q = "500 - 237 = ?"; a = @("263", "261", "265", "260"); c = 0 }
        @{ q = "32 * 15 = ?"; a = @("480", "470", "490", "460"); c = 0 }
        @{ q = "288 / 16 = ?"; a = @("18", "17", "19", "16"); c = 0 }
        @{ q = "sqrt(196) = ?"; a = @("14", "13", "15", "16"); c = 0 }
        @{ q = "7^2 - 5^2 = ?"; a = @("24", "22", "26", "20"); c = 0 }
        @{ q = "2^5 = ?"; a = @("32", "24", "36", "28"); c = 0 }
        @{ q = "234 + 567 = ?"; a = @("801", "799", "803", "797"); c = 0 }
        @{ q = "1000 - 456 = ?"; a = @("544", "542", "546", "540"); c = 0 }
        @{ q = "45 * 22 = ?"; a = @("990", "980", "1000", "970"); c = 0 }
        @{ q = "sqrt(256) = ?"; a = @("16", "15", "17", "18"); c = 0 }
        @{ q = "9^2 = ?"; a = @("81", "72", "90", "63"); c = 0 }
        @{ q = "125 / 5 = ?"; a = @("25", "24", "26", "23"); c = 0 }
        @{ q = "78 + 94 = ?"; a = @("172", "170", "174", "168"); c = 0 }
        @{ q = "350 - 178 = ?"; a = @("172", "170", "174", "168"); c = 0 }
        @{ q = "16 * 16 = ?"; a = @("256", "246", "266", "236"); c = 0 }
        @{ q = "324 / 18 = ?"; a = @("18", "17", "19", "16"); c = 0 }
        @{ q = "11^2 = ?"; a = @("121", "111", "131", "110"); c = 0 }
        @{ q = "sqrt(225) = ?"; a = @("15", "14", "16", "13"); c = 0 }
        @{ q = "67 + 89 = ?"; a = @("156", "154", "158", "152"); c = 0 }
        @{ q = "400 - 167 = ?"; a = @("233", "231", "235", "230"); c = 0 }
    )
    hard = @(
        @{ q = "log10(1000) = ?"; a = @("3", "2", "4", "10"); c = 0 }
        @{ q = "sin(90) = ?"; a = @("1", "0", "-1", "0.5"); c = 0 }
        @{ q = "cos(0) = ?"; a = @("1", "0", "-1", "0.5"); c = 0 }
        @{ q = "5! = ?"; a = @("120", "60", "24", "720"); c = 0 }
        @{ q = "(2^3)^2 = ?"; a = @("64", "32", "128", "16"); c = 0 }
        @{ q = "cbrt(27) = ?"; a = @("3", "9", "6", "4"); c = 0 }
        @{ q = "2^8 = ?"; a = @("256", "128", "512", "64"); c = 0 }
        @{ q = "17^2 = ?"; a = @("289", "279", "299", "269"); c = 0 }
        @{ q = "cbrt(125) = ?"; a = @("5", "25", "6", "4"); c = 0 }
        @{ q = "6! = ?"; a = @("720", "120", "360", "480"); c = 0 }
        @{ q = "log2(64) = ?"; a = @("6", "4", "8", "5"); c = 0 }
        @{ q = "tan(45) = ?"; a = @("1", "0", "1.41", "2"); c = 0 }
        @{ q = "sin(30) = ?"; a = @("0.5", "1", "0", "0.87"); c = 0 }
        @{ q = "13^2 = ?"; a = @("169", "159", "179", "149"); c = 0 }
        @{ q = "cbrt(1000) = ?"; a = @("10", "100", "31", "32"); c = 0 }
        @{ q = "7! / 5! = ?"; a = @("42", "21", "56", "35"); c = 0 }
        @{ q = "log10(10000) = ?"; a = @("4", "3", "5", "2"); c = 0 }
        @{ q = "cos(60) = ?"; a = @("0.5", "1", "0", "0.87"); c = 0 }
        @{ q = "sin(45) = ?"; a = @("0.71", "1", "0.5", "0.87"); c = 0 }
        @{ q = "19^2 = ?"; a = @("361", "351", "371", "341"); c = 0 }
        @{ q = "2^9 = ?"; a = @("512", "256", "1024", "128"); c = 0 }
        @{ q = "cbrt(216) = ?"; a = @("6", "36", "7", "8"); c = 0 }
        @{ q = "8! / 6! = ?"; a = @("56", "28", "42", "72"); c = 0 }
        @{ q = "log2(256) = ?"; a = @("8", "6", "7", "9"); c = 0 }
        @{ q = "tan(60) = ?"; a = @("1.73", "1", "2", "1.41"); c = 0 }
        @{ q = "21^2 = ?"; a = @("441", "431", "451", "421"); c = 0 }
        @{ q = "3^5 = ?"; a = @("243", "81", "729", "162"); c = 0 }
        @{ q = "cbrt(512) = ?"; a = @("8", "64", "9", "7"); c = 0 }
        @{ q = "log10(100000) = ?"; a = @("5", "4", "6", "3"); c = 0 }
        @{ q = "23^2 = ?"; a = @("529", "519", "539", "509"); c = 0 }
    )
}

# Level mapping
$levelMap = @{
    "easy" = 0
    "medium" = 1
    "hard" = 2
}

function Add-Question {
    param(
        [hashtable]$Question,
        [string]$Level
    )

    $answers = @()
    for ($i = 0; $i -lt $Question.a.Count; $i++) {
        $answers += @{
            Text = $Question.a[$i]
            IsCorrect = ($i -eq $Question.c)
            Translate = @(
                @{
                    LanguageId = 0
                    ColumnName = "Text"
                    TranslateText = $Question.a[$i]
                }
            )
        }
    }

    $body = @{
        QuestionText = $Question.q
        TopicId = $TopicId
        Level = $levelMap[$Level]
        Translate = @(
            @{
                LanguageId = 0
                ColumnName = "QuestionText"
                TranslateText = $Question.q
            }
        )
        Answers = $answers
    }

    $json = $body | ConvertTo-Json -Depth 10

    try {
        # SSL sertifikat tekshiruvini o'chirish (localhost uchun)
        [System.Net.ServicePointManager]::ServerCertificateValidationCallback = { $true }

        $response = Invoke-RestMethod -Uri "$ApiBase/api/QuestionAnswer" `
            -Method Post `
            -ContentType "application/json; charset=utf-8" `
            -Body ([System.Text.Encoding]::UTF8.GetBytes($json)) `
            -SkipCertificateCheck

        return $response.Succeeded
    }
    catch {
        Write-Host "Xato: $_" -ForegroundColor Red
        return $false
    }
}

# Asosiy script
Write-Host "========================================" -ForegroundColor Cyan
Write-Host " 100 ta Matematik savol qo'shish" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "TopicId: $TopicId" -ForegroundColor Yellow
Write-Host "API: $ApiBase" -ForegroundColor Yellow
Write-Host ""

$successCount = 0
$errorCount = 0

# Easy savollar (30 ta)
Write-Host "Easy savollar (30 ta)..." -ForegroundColor Green
for ($i = 0; $i -lt 30; $i++) {
    $result = Add-Question -Question $mathQuestions.easy[$i] -Level "easy"
    if ($result) {
        $successCount++
        Write-Host "`rEasy: $($i + 1)/30" -NoNewline
    } else {
        $errorCount++
    }
}
Write-Host ""
Write-Host "Easy: $successCount/30 muvaffaqiyatli" -ForegroundColor Green

# Medium savollar (40 ta)
Write-Host "Medium savollar (40 ta)..." -ForegroundColor Yellow
$mediumStart = $successCount
for ($i = 0; $i -lt 40; $i++) {
    $result = Add-Question -Question $mathQuestions.medium[$i] -Level "medium"
    if ($result) {
        $successCount++
        Write-Host "`rMedium: $($i + 1)/40" -NoNewline
    } else {
        $errorCount++
    }
}
Write-Host ""
Write-Host "Medium: $($successCount - $mediumStart)/40 muvaffaqiyatli" -ForegroundColor Yellow

# Hard savollar (30 ta)
Write-Host "Hard savollar (30 ta)..." -ForegroundColor Red
$hardStart = $successCount
for ($i = 0; $i -lt 30; $i++) {
    $result = Add-Question -Question $mathQuestions.hard[$i] -Level "hard"
    if ($result) {
        $successCount++
        Write-Host "`rHard: $($i + 1)/30" -NoNewline
    } else {
        $errorCount++
    }
}
Write-Host ""
Write-Host "Hard: $($successCount - $hardStart)/30 muvaffaqiyatli" -ForegroundColor Red

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host " NATIJA" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Muvaffaqiyatli: $successCount/100" -ForegroundColor Green
Write-Host "Xatolar: $errorCount" -ForegroundColor Red
Write-Host "========================================" -ForegroundColor Cyan
