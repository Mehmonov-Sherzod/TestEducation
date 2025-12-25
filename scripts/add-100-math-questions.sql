-- 100 ta Matematik savol qo'shish SQL scripti
-- 30 ta Easy, 40 ta Medium, 30 ta Hard

-- Avval Matematika SubjectId va TopicId ni aniqlang
-- Bu qiymatlarni o'zgartiring:
DECLARE @SubjectId UNIQUEIDENTIFIER;
DECLARE @TopicId UNIQUEIDENTIFIER;

-- Matematika fanini toping (nomiga qarab)
SELECT TOP 1 @SubjectId = Id FROM Subjects WHERE Name LIKE '%Matematik%' OR Name LIKE '%Math%';

-- Shu fan uchun birinchi topicni oling
SELECT TOP 1 @TopicId = Id FROM Topics WHERE SubjectId = @SubjectId;

-- Agar topilmasa, xatolik
IF @SubjectId IS NULL
BEGIN
    PRINT 'Matematika fani topilmadi! Subjects jadvalini tekshiring.';
    RETURN;
END

IF @TopicId IS NULL
BEGIN
    PRINT 'Topic topilmadi! Topics jadvalini tekshiring.';
    RETURN;
END

PRINT 'SubjectId: ' + CAST(@SubjectId AS VARCHAR(50));
PRINT 'TopicId: ' + CAST(@TopicId AS VARCHAR(50));

-- Savollar va javoblar uchun vaqtinchalik jadval
DECLARE @Questions TABLE (
    QuestionText NVARCHAR(500),
    Level NVARCHAR(20), -- Easy, Medium, Hard (string sifatida)
    Answer1 NVARCHAR(100),
    Answer2 NVARCHAR(100),
    Answer3 NVARCHAR(100),
    Answer4 NVARCHAR(100),
    CorrectIndex INT -- 1-4
);

-- EASY SAVOLLAR (30 ta) - Level = 'Easy'
INSERT INTO @Questions VALUES (N'2 + 3 = ?', N'Easy', N'5', N'4', N'6', N'7', 1);
INSERT INTO @Questions VALUES (N'5 - 2 = ?', N'Easy', N'3', N'2', N'4', N'1', 1);
INSERT INTO @Questions VALUES (N'3 × 2 = ?', N'Easy', N'6', N'5', N'4', N'8', 1);
INSERT INTO @Questions VALUES (N'8 ÷ 2 = ?', N'Easy', N'4', N'3', N'5', N'6', 1);
INSERT INTO @Questions VALUES (N'10 + 5 = ?', N'Easy', N'15', N'14', N'16', N'12', 1);
INSERT INTO @Questions VALUES (N'7 - 4 = ?', N'Easy', N'3', N'2', N'4', N'5', 1);
INSERT INTO @Questions VALUES (N'4 × 3 = ?', N'Easy', N'12', N'10', N'14', N'11', 1);
INSERT INTO @Questions VALUES (N'9 ÷ 3 = ?', N'Easy', N'3', N'2', N'4', N'6', 1);
INSERT INTO @Questions VALUES (N'6 + 7 = ?', N'Easy', N'13', N'12', N'14', N'11', 1);
INSERT INTO @Questions VALUES (N'15 - 8 = ?', N'Easy', N'7', N'6', N'8', N'9', 1);
INSERT INTO @Questions VALUES (N'5 × 5 = ?', N'Easy', N'25', N'20', N'30', N'15', 1);
INSERT INTO @Questions VALUES (N'20 ÷ 4 = ?', N'Easy', N'5', N'4', N'6', N'8', 1);
INSERT INTO @Questions VALUES (N'11 + 9 = ?', N'Easy', N'20', N'19', N'21', N'18', 1);
INSERT INTO @Questions VALUES (N'18 - 9 = ?', N'Easy', N'9', N'8', N'10', N'7', 1);
INSERT INTO @Questions VALUES (N'6 × 4 = ?', N'Easy', N'24', N'22', N'26', N'20', 1);
INSERT INTO @Questions VALUES (N'16 ÷ 4 = ?', N'Easy', N'4', N'3', N'5', N'6', 1);
INSERT INTO @Questions VALUES (N'8 + 8 = ?', N'Easy', N'16', N'15', N'17', N'14', 1);
INSERT INTO @Questions VALUES (N'20 - 12 = ?', N'Easy', N'8', N'7', N'9', N'10', 1);
INSERT INTO @Questions VALUES (N'7 × 3 = ?', N'Easy', N'21', N'20', N'22', N'18', 1);
INSERT INTO @Questions VALUES (N'30 ÷ 5 = ?', N'Easy', N'6', N'5', N'7', N'8', 1);
INSERT INTO @Questions VALUES (N'14 + 6 = ?', N'Easy', N'20', N'19', N'21', N'18', 1);
INSERT INTO @Questions VALUES (N'25 - 10 = ?', N'Easy', N'15', N'14', N'16', N'13', 1);
INSERT INTO @Questions VALUES (N'8 × 2 = ?', N'Easy', N'16', N'14', N'18', N'12', 1);
INSERT INTO @Questions VALUES (N'24 ÷ 6 = ?', N'Easy', N'4', N'3', N'5', N'6', 1);
INSERT INTO @Questions VALUES (N'9 + 11 = ?', N'Easy', N'20', N'19', N'21', N'18', 1);
INSERT INTO @Questions VALUES (N'30 - 15 = ?', N'Easy', N'15', N'14', N'16', N'13', 1);
INSERT INTO @Questions VALUES (N'9 × 2 = ?', N'Easy', N'18', N'16', N'20', N'14', 1);
INSERT INTO @Questions VALUES (N'36 ÷ 6 = ?', N'Easy', N'6', N'5', N'7', N'8', 1);
INSERT INTO @Questions VALUES (N'12 + 13 = ?', N'Easy', N'25', N'24', N'26', N'23', 1);
INSERT INTO @Questions VALUES (N'50 - 25 = ?', N'Easy', N'25', N'24', N'26', N'20', 1);

-- MEDIUM SAVOLLAR (40 ta) - Level = 'Medium'
INSERT INTO @Questions VALUES (N'15 × 12 = ?', N'Medium', N'180', N'170', N'190', N'160', 1);
INSERT INTO @Questions VALUES (N'144 ÷ 12 = ?', N'Medium', N'12', N'11', N'13', N'14', 1);
INSERT INTO @Questions VALUES (N'√64 = ?', N'Medium', N'8', N'6', N'7', N'9', 1);
INSERT INTO @Questions VALUES (N'3² + 4² = ?', N'Medium', N'25', N'24', N'26', N'23', 1);
INSERT INTO @Questions VALUES (N'2³ = ?', N'Medium', N'8', N'6', N'9', N'4', 1);
INSERT INTO @Questions VALUES (N'45 + 67 = ?', N'Medium', N'112', N'110', N'114', N'108', 1);
INSERT INTO @Questions VALUES (N'123 - 78 = ?', N'Medium', N'45', N'43', N'47', N'44', 1);
INSERT INTO @Questions VALUES (N'18 × 6 = ?', N'Medium', N'108', N'106', N'110', N'104', 1);
INSERT INTO @Questions VALUES (N'156 ÷ 12 = ?', N'Medium', N'13', N'12', N'14', N'11', 1);
INSERT INTO @Questions VALUES (N'√100 = ?', N'Medium', N'10', N'9', N'11', N'12', 1);
INSERT INTO @Questions VALUES (N'5² - 3² = ?', N'Medium', N'16', N'14', N'18', N'12', 1);
INSERT INTO @Questions VALUES (N'4³ = ?', N'Medium', N'64', N'48', N'72', N'56', 1);
INSERT INTO @Questions VALUES (N'89 + 56 = ?', N'Medium', N'145', N'143', N'147', N'141', 1);
INSERT INTO @Questions VALUES (N'200 - 87 = ?', N'Medium', N'113', N'111', N'115', N'110', 1);
INSERT INTO @Questions VALUES (N'25 × 8 = ?', N'Medium', N'200', N'190', N'210', N'180', 1);
INSERT INTO @Questions VALUES (N'225 ÷ 15 = ?', N'Medium', N'15', N'14', N'16', N'13', 1);
INSERT INTO @Questions VALUES (N'√144 = ?', N'Medium', N'12', N'11', N'13', N'14', 1);
INSERT INTO @Questions VALUES (N'6² + 8² = ?', N'Medium', N'100', N'98', N'102', N'96', 1);
INSERT INTO @Questions VALUES (N'3⁴ = ?', N'Medium', N'81', N'64', N'72', N'90', 1);
INSERT INTO @Questions VALUES (N'156 + 289 = ?', N'Medium', N'445', N'443', N'447', N'441', 1);
INSERT INTO @Questions VALUES (N'500 - 237 = ?', N'Medium', N'263', N'261', N'265', N'260', 1);
INSERT INTO @Questions VALUES (N'32 × 15 = ?', N'Medium', N'480', N'470', N'490', N'460', 1);
INSERT INTO @Questions VALUES (N'288 ÷ 16 = ?', N'Medium', N'18', N'17', N'19', N'16', 1);
INSERT INTO @Questions VALUES (N'√196 = ?', N'Medium', N'14', N'13', N'15', N'16', 1);
INSERT INTO @Questions VALUES (N'7² - 5² = ?', N'Medium', N'24', N'22', N'26', N'20', 1);
INSERT INTO @Questions VALUES (N'2⁵ = ?', N'Medium', N'32', N'24', N'36', N'28', 1);
INSERT INTO @Questions VALUES (N'234 + 567 = ?', N'Medium', N'801', N'799', N'803', N'797', 1);
INSERT INTO @Questions VALUES (N'1000 - 456 = ?', N'Medium', N'544', N'542', N'546', N'540', 1);
INSERT INTO @Questions VALUES (N'45 × 22 = ?', N'Medium', N'990', N'980', N'1000', N'970', 1);
INSERT INTO @Questions VALUES (N'√256 = ?', N'Medium', N'16', N'15', N'17', N'18', 1);
INSERT INTO @Questions VALUES (N'9² = ?', N'Medium', N'81', N'72', N'90', N'63', 1);
INSERT INTO @Questions VALUES (N'125 ÷ 5 = ?', N'Medium', N'25', N'24', N'26', N'23', 1);
INSERT INTO @Questions VALUES (N'78 + 94 = ?', N'Medium', N'172', N'170', N'174', N'168', 1);
INSERT INTO @Questions VALUES (N'350 - 178 = ?', N'Medium', N'172', N'170', N'174', N'168', 1);
INSERT INTO @Questions VALUES (N'16 × 16 = ?', N'Medium', N'256', N'246', N'266', N'236', 1);
INSERT INTO @Questions VALUES (N'324 ÷ 18 = ?', N'Medium', N'18', N'17', N'19', N'16', 1);
INSERT INTO @Questions VALUES (N'11² = ?', N'Medium', N'121', N'111', N'131', N'110', 1);
INSERT INTO @Questions VALUES (N'√225 = ?', N'Medium', N'15', N'14', N'16', N'13', 1);
INSERT INTO @Questions VALUES (N'67 + 89 = ?', N'Medium', N'156', N'154', N'158', N'152', 1);
INSERT INTO @Questions VALUES (N'400 - 167 = ?', N'Medium', N'233', N'231', N'235', N'230', 1);

-- HARD SAVOLLAR (30 ta) - Level = 'Hard'
INSERT INTO @Questions VALUES (N'log₁₀(1000) = ?', N'Hard', N'3', N'2', N'4', N'10', 1);
INSERT INTO @Questions VALUES (N'sin(90°) = ?', N'Hard', N'1', N'0', N'-1', N'0.5', 1);
INSERT INTO @Questions VALUES (N'cos(0°) = ?', N'Hard', N'1', N'0', N'-1', N'0.5', 1);
INSERT INTO @Questions VALUES (N'5! (faktorial) = ?', N'Hard', N'120', N'60', N'24', N'720', 1);
INSERT INTO @Questions VALUES (N'(2³)² = ?', N'Hard', N'64', N'32', N'128', N'16', 1);
INSERT INTO @Questions VALUES (N'∛27 = ?', N'Hard', N'3', N'9', N'6', N'4', 1);
INSERT INTO @Questions VALUES (N'2⁸ = ?', N'Hard', N'256', N'128', N'512', N'64', 1);
INSERT INTO @Questions VALUES (N'17² = ?', N'Hard', N'289', N'279', N'299', N'269', 1);
INSERT INTO @Questions VALUES (N'∛125 = ?', N'Hard', N'5', N'25', N'6', N'4', 1);
INSERT INTO @Questions VALUES (N'6! = ?', N'Hard', N'720', N'120', N'360', N'480', 1);
INSERT INTO @Questions VALUES (N'log₂(64) = ?', N'Hard', N'6', N'4', N'8', N'5', 1);
INSERT INTO @Questions VALUES (N'tan(45°) = ?', N'Hard', N'1', N'0', N'√2', N'2', 1);
INSERT INTO @Questions VALUES (N'sin(30°) = ?', N'Hard', N'0.5', N'1', N'0', N'√3/2', 1);
INSERT INTO @Questions VALUES (N'13² = ?', N'Hard', N'169', N'159', N'179', N'149', 1);
INSERT INTO @Questions VALUES (N'∛1000 = ?', N'Hard', N'10', N'100', N'31', N'32', 1);
INSERT INTO @Questions VALUES (N'7! ÷ 5! = ?', N'Hard', N'42', N'21', N'56', N'35', 1);
INSERT INTO @Questions VALUES (N'log₁₀(10000) = ?', N'Hard', N'4', N'3', N'5', N'2', 1);
INSERT INTO @Questions VALUES (N'cos(60°) = ?', N'Hard', N'0.5', N'1', N'0', N'√3/2', 1);
INSERT INTO @Questions VALUES (N'sin(45°) = ?', N'Hard', N'√2/2', N'1', N'0.5', N'√3/2', 1);
INSERT INTO @Questions VALUES (N'19² = ?', N'Hard', N'361', N'351', N'371', N'341', 1);
INSERT INTO @Questions VALUES (N'2⁹ = ?', N'Hard', N'512', N'256', N'1024', N'128', 1);
INSERT INTO @Questions VALUES (N'∛216 = ?', N'Hard', N'6', N'36', N'7', N'8', 1);
INSERT INTO @Questions VALUES (N'8! ÷ 6! = ?', N'Hard', N'56', N'28', N'42', N'72', 1);
INSERT INTO @Questions VALUES (N'log₂(256) = ?', N'Hard', N'8', N'6', N'7', N'9', 1);
INSERT INTO @Questions VALUES (N'tan(60°) = ?', N'Hard', N'√3', N'1', N'2', N'√2', 1);
INSERT INTO @Questions VALUES (N'21² = ?', N'Hard', N'441', N'431', N'451', N'421', 1);
INSERT INTO @Questions VALUES (N'3⁵ = ?', N'Hard', N'243', N'81', N'729', N'162', 1);
INSERT INTO @Questions VALUES (N'∛512 = ?', N'Hard', N'8', N'64', N'9', N'7', 1);
INSERT INTO @Questions VALUES (N'log₁₀(100000) = ?', N'Hard', N'5', N'4', N'6', N'3', 1);
INSERT INTO @Questions VALUES (N'23² = ?', N'Hard', N'529', N'519', N'539', N'509', 1);

-- Savollarni qo'shish
DECLARE @QuestionId UNIQUEIDENTIFIER;
DECLARE @QuestionText NVARCHAR(500);
DECLARE @Level NVARCHAR(20);
DECLARE @Answer1 NVARCHAR(100);
DECLARE @Answer2 NVARCHAR(100);
DECLARE @Answer3 NVARCHAR(100);
DECLARE @Answer4 NVARCHAR(100);
DECLARE @CorrectIndex INT;

DECLARE question_cursor CURSOR FOR
SELECT QuestionText, Level, Answer1, Answer2, Answer3, Answer4, CorrectIndex FROM @Questions;

OPEN question_cursor;
FETCH NEXT FROM question_cursor INTO @QuestionText, @Level, @Answer1, @Answer2, @Answer3, @Answer4, @CorrectIndex;

DECLARE @Counter INT = 0;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @QuestionId = NEWID();

    -- Savolni qo'shish
    INSERT INTO Question (Id, QuestionText, ImageUrl, Level, TopicId, SubjectId)
    VALUES (@QuestionId, @QuestionText, NULL, @Level, @TopicId, @SubjectId);

    -- 4 ta javobni qo'shish
    INSERT INTO Answers (Id, AnswerText, IsCorrect, QuestionId)
    VALUES
        (NEWID(), @Answer1, CASE WHEN @CorrectIndex = 1 THEN 1 ELSE 0 END, @QuestionId),
        (NEWID(), @Answer2, CASE WHEN @CorrectIndex = 2 THEN 1 ELSE 0 END, @QuestionId),
        (NEWID(), @Answer3, CASE WHEN @CorrectIndex = 3 THEN 1 ELSE 0 END, @QuestionId),
        (NEWID(), @Answer4, CASE WHEN @CorrectIndex = 4 THEN 1 ELSE 0 END, @QuestionId);

    SET @Counter = @Counter + 1;

    FETCH NEXT FROM question_cursor INTO @QuestionText, @Level, @Answer1, @Answer2, @Answer3, @Answer4, @CorrectIndex;
END

CLOSE question_cursor;
DEALLOCATE question_cursor;

PRINT '';
PRINT '═══════════════════════════════════════════════════';
PRINT '✅ Jami ' + CAST(@Counter AS VARCHAR(10)) + ' ta savol muvaffaqiyatli qo''shildi!';
PRINT '   - 30 ta Easy';
PRINT '   - 40 ta Medium';
PRINT '   - 30 ta Hard';
PRINT '═══════════════════════════════════════════════════';

-- Tekshirish
SELECT
    'Easy' AS Level, COUNT(*) AS Count FROM Question WHERE SubjectId = @SubjectId AND Level = 'Easy'
UNION ALL
SELECT
    'Medium', COUNT(*) FROM Question WHERE SubjectId = @SubjectId AND Level = 'Medium'
UNION ALL
SELECT
    'Hard', COUNT(*) FROM Question WHERE SubjectId = @SubjectId AND Level = 'Hard';
