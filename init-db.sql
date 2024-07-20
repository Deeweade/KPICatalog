IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'KPICatalog')
BEGIN
    CREATE DATABASE KPICatalog;
END
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PerfManagement1')
BEGIN
    CREATE DATABASE PerfManagement1;
END
GO

USE PerfManagement1;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Employee')
    BEGIN

    CREATE TABLE Employee(
        [Id] [int] NOT NULL,
        [TabNumber] [nvarchar](10) NULL,
        [Fio] [nvarchar](max) NULL,
        [PositionNum] [nvarchar](10) NULL,
        [Position] [nvarchar](max) NULL,
        [UnitNum] [nvarchar](10) NULL,
        [UnitParentNum] [nvarchar](10) NULL,
        [Unit] [nvarchar](max) NULL,
        [Gender] [bit] NOT NULL DEFAULT ((0)),
        [City] [nvarchar](150) NULL,
        [FuncManager] [nvarchar](10) NULL,
        [AdmManager] [nvarchar](10) NULL,
        [UnitManager] [nvarchar](10) NULL,
        [IsManager] [bit] NOT NULL DEFAULT ((0)),
        [State] [int] NULL,
        [IsStaffMember] [bit] NOT NULL DEFAULT ((1)),
        [HeadOffice] [int] NULL,
        [IsActive] [bit] NOT NULL DEFAULT ((1)),
        [Birthday] [datetime2](7) NULL,
        [HireDate] [datetime2](7) NULL,
        [AmountSubordinate] [int] NULL,
        [Login] [nvarchar](100) NULL,
        [SpId] [int] NULL,
        [Parent] [int] NULL,
        [Parents] [nvarchar](max) NULL,
        [Levels] [int] NOT NULL DEFAULT ((0)),
        [BlockNum] [int] NULL,
        [PhotoUrl] [nvarchar](500) NULL,
        [BonusType] [nvarchar](250) NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    CREATE TABLE [dbo].[Quarter](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Title] [nvarchar](max) NULL,
        [DateStart] [datetime2](7) NULL,
        [DateEnd] [datetime2](7) NULL,
        [NumberY]  AS (case when datepart(year,[DateStart])=datepart(year,[dateend]) then datepart(year,[datestart]) else (1950) end),
        [NumberQ]  AS (case when datepart(quarter,[datestart])=datepart(quarter,[dateend]) then datepart(quarter,[datestart]) else (100) end),
        [IsYear]  AS (case when datepart(day,[datestart])=(1) AND datepart(month,[datestart])=(1) AND datepart(day,[dateend])=(31) AND datepart(month,[dateend])=(12) AND datepart(year,[datestart])=datepart(year,[dateend]) then (1) else (0) end),
    CONSTRAINT [PK_Quarter] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    CREATE TABLE [dbo].[RatingScaleValue](
	[Id] [int] NOT NULL,
	[RatingScaleId] [int] NULL,
	[MinimumValue] [decimal](18, 3) NULL,
	[MaximumValue] [decimal](18, 3) NULL,
	[RatingPercentage] [int] NULL,
    CONSTRAINT [PK_RatingScaleValue] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

    INSERT INTO Employee (Id, TabNumber, Fio, PositionNum, Position, UnitNum, UnitParentNum, Unit, Gender, City, FuncManager, AdmManager, UnitManager, IsManager, State, IsStaffMember, HeadOffice, IsActive, Birthday, HireDate, AmountSubordinate, Login, SpId, Parent, Parents, Levels, BlockNum, PhotoUrl, BonusType)
    VALUES 
    (9725,'00118463', N'Петров Олег Владимирович', '20000229', N'Старший разработчик', '40005506', '40005505', N'Отдел развития внутренних сервисов', 1, N'Краснодар', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, '1985-05-20', '2022-08-26 00:00:00.0000000', 0, 'opetrov2', 18, 2728, N'2,11995,7547,7854,2728', 5, 11995, NULL, N'Ежегодный'),
    (10250,'00119272', N'Сивоплясов Александр Владимирович', '20000245', N'Старший разработчик', '40005335', '40005474', N'Отдел развития внутренних сервисов', 1, N'Москва', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, '1987-10-14', '2022-10-25 00:00:00.0000000', 1, 'asivoplyasov', 25497, 12927, N'2,11995,7547,7854,12927', 5, 11995, NULL, N'Ежегодный'),
    (11208,'00121345', N'Гвоздинская Анна Сергеевна', '20000602', N'Руководитель проекта', '40005335', '40005474', N'Управление компенсаций и льгот', 0, N'Москва', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, '1990-12-12', '2023-04-24 00:00:00.0000000', 0, 'agvozdinskaya', 25513, 12927, N'2,6141,12927', 3, 6141, 'http://srvap869:80/my/User Photos/Profile Pictures/agvozdinskaya.jpg', NULL),
    (11303,'00121042', N'Бычкова Александра Мирославна', '20000602', N'Разработчик', '40005916', '40005917', N'Отдел развития внутренних сервисов', 0, N'Москва', NULL, NULL, NULL, 0, NULL, 1, NULL, 1, '1992-03-15', '2023-03-30 00:00:00.0000000', 0, 'abychkova2', 26703, 9725, N'2,11995,7547,7854,2728', 5, 11995, NULL, NULL),
    (11581,'00122004', N'Рыковский Андрей Игоревич', '20000602', N'Владелец продукта', '40005857', '40005474', N'Управление развития технологий HR', 1, N'Москва', NULL, NULL, NULL, 1, NULL, 1, NULL, 1, '1982-06-30', '2024-08-31 00:00:00.0000000', 1, 'arykovskiy', 25519, 12927, N'2,6141,12927', 3, 6141, NULL, NULL);

    INSERT INTO Quarter (Title, DateStart, DateEnd)
    VALUES 
    ('2022', '2022-01-01 00:00:00.0000000', '2022-12-31 00:00:00.0000000'),
    (N'2022, 1 квартал', '2022-01-01 00:00:00.0000000', '2022-03-31 00:00:00.0000000'),
    (N'2022, 2 квартал', '2022-04-01 00:00:00.0000000', '2022-06-30 00:00:00.0000000'),
    (N'2022, 3 квартал', '2022-07-01 00:00:00.0000000', '2022-09-30 00:00:00.0000000'),
    (N'2022, 4 квартал', '2022-10-01 00:00:00.0000000', '2022-12-31 00:00:00.0000000'),
    (N'2021', '2021-01-01 00:00:00.0000000', '2021-12-31 00:00:00.0000000'),
    (N'2021, 1 квартал', '2021-01-01 00:00:00.0000000', '2021-03-31 00:00:00.0000000'),
    (N'2021, 4 квартал', '2021-10-01 00:00:00.0000000', '2021-12-31 00:00:00.0000000'),
    (N'2023, 1 квартал', '2023-01-01 00:00:00.0000000', '2023-03-31 00:00:00.0000000'),
    (N'2023, 2 квартал', '2023-04-01 00:00:00.0000000', '2023-06-30 00:00:00.0000000'),
    (N'2023, 3 квартал', '2023-07-01 00:00:00.0000000', '2023-09-30 00:00:00.0000000'),
    (N'2023, 4 квартал', '2023-10-01 00:00:00.0000000', '2023-12-31 00:00:00.0000000'),
    (N'2023', '2023-01-01 00:00:00.0000000', '2023-12-31 00:00:00.0000000'),
    (N'2024, 1 квартал', '2024-01-01 00:00:00.0000000', '2024-03-31 00:00:00.0000000'),
    (N'2024, 2 квартал', '2024-04-01 00:00:00.0000000', '2024-06-30 00:00:00.0000000'),
    (N'2024, 3 квартал', '2024-07-01 00:00:00.0000000', '2024-09-30 00:00:00.0000000'),
    (N'2024, 4 квартал', '2024-10-01 00:00:00.0000000', '2024-12-31 00:00:00.0000000'),
    (N'2024 год', '2024-01-01 00:00:00.0000000', '2024-12-31 00:00:00.0000000');

    INSERT INTO RatingScaleValue (Id, RatingScaleId, MinimumValue, MaximumValue, RatingPercentage)
    VALUES 
    (1, 1, 0, 99, 0),
    (2, 1, 99, 99.8, 50),
    (3, 1, 99.8, 99.9, 100),
    (4, 1, 99.9, 99.95, 105),
    (5, 1, 99.95, 100, 110);

    END

GO