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
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Created] [datetime2](7) NOT NULL DEFAULT (getdate()),
        [CreatedBy] [nvarchar](max) NULL,
        [LastModified] [datetime2](7) NULL,
        [LastModifiedBy] [nvarchar](max) NULL,
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

    END
GO
