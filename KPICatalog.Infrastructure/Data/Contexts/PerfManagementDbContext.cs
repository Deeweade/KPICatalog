using KPICatalog.Domain.Models.Entities.Goals;
using Microsoft.EntityFrameworkCore;

namespace KPICatalog.Infrastructure.Data.Contexts;

public class PerfManagementDbContext : DbContext
{
    public PerfManagementDbContext(DbContextOptions<PerfManagementDbContext> options)
    : base(options)
    {
        Database.EnsureCreated();
        Initialize();
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Period> Periods { get; set; }
    public DbSet<RatingScaleValue> RatingScaleValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    private void Initialize()
    {
        if (!Employees.Any())
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 9725,
                    TabNumber = "00118463",
                    Fio = "Петров Олег Владимирович",
                    PositionNum = "20000229",
                    Position = "Старший разработчик",
                    UnitNum = "40005506",
                    UnitParentNum = "40005505",
                    Unit = "Отдел развития внутренних сервисов",
                    Gender = true,
                    City = "Краснодар",
                    IsManager = false,
                    IsStaffMember = true,
                    IsActive = true,
                    Birthday = new DateTime(1985, 5, 20),
                    HireDate = new DateTime(2022, 8, 26),
                    AmountSubordinate = 0,
                    Login = "opetrov2",
                    SpId = 18,
                    Parent = 2728,
                    Parents = "2,11995,7547,7854,2728",
                    Levels = 5,
                    BlockNum = 11995,
                    BonusType = "Ежегодный"
                },
                new Employee
                {
                    Id = 10250,
                    TabNumber = "00119272",
                    Fio = "Сивоплясов Александр Владимирович",
                    PositionNum = "20000245",
                    Position = "Старший разработчик",
                    UnitNum = "40005335",
                    UnitParentNum = "40005474",
                    Unit = "Отдел развития внутренних сервисов",
                    Gender = true,
                    City = "Москва",
                    IsManager = false,
                    IsStaffMember = true,
                    IsActive = true,
                    Birthday = new DateTime(1987, 10, 14),
                    HireDate = new DateTime(2022, 10, 25),
                    AmountSubordinate = 1,
                    Login = "asivoplyasov",
                    SpId = 25497,
                    Parent = 12927,
                    Parents = "2,11995,7547,7854,12927",
                    Levels = 5,
                    BlockNum = 11995,
                    BonusType = "Ежегодный"
                },
                new Employee
                {
                    Id = 11208,
                    TabNumber = "00121345",
                    Fio = "Гвоздинская Анна Сергеевна",
                    PositionNum = "20000602",
                    Position = "Руководитель проекта",
                    UnitNum = "40005335",
                    UnitParentNum = "40005474",
                    Unit = "Управление компенсаций и льгот",
                    Gender = false,
                    City = "Москва",
                    IsManager = false,
                    IsStaffMember = true,
                    IsActive = true,
                    Birthday = new DateTime(1990, 12, 12),
                    HireDate = new DateTime(2023, 4, 24),
                    AmountSubordinate = 0,
                    Login = "agvozdinskaya",
                    SpId = 25513,
                    Parent = 12927,
                    Parents = "2,6141,12927",
                    Levels = 3,
                    BlockNum = 6141,
                    PhotoUrl = "http://srvap869:80/my/User Photos/Profile Pictures/agvozdinskaya.jpg",
                    BonusType = "Ежегодный"
                },
                new Employee
                {
                    Id = 11303,
                    TabNumber = "00121042",
                    Fio = "Бычкова Александра Мирославна",
                    PositionNum = "20000602",
                    Position = "Разработчик",
                    UnitNum = "40005916",
                    UnitParentNum = "40005917",
                    Unit = "Отдел развития внутренних сервисов",
                    Gender = false,
                    City = "Москва",
                    IsManager = true,
                    IsStaffMember = true,
                    IsActive = true,
                    Birthday = new DateTime(1992, 3, 15),
                    HireDate = new DateTime(2023, 3, 30),
                    AmountSubordinate = 0,
                    Login = "abychkova2",
                    SpId = 26703,
                    Parent = 9725,
                    Parents = "2,11995,7547,7854,2728",
                    Levels = 5,
                    BlockNum = 11995,
                    BonusType = "Ежегодный"
                },
                new Employee
                {
                    Id = 11581,
                    TabNumber = "00122004",
                    Fio = "Рыковский Андрей Игоревич",
                    PositionNum = "20000602",
                    Position = "Владелец продукта",
                    UnitNum = "40005857",
                    UnitParentNum = "40005474",
                    Unit = "Управление развития технологий HR",
                    Gender = true,
                    City = "Москва",
                    IsManager = true,
                    IsStaffMember = true,
                    HeadOffice = null,
                    IsActive = true,
                    Birthday = new DateTime(1982, 6, 30),
                    HireDate = new DateTime(2024, 8, 31),
                    AmountSubordinate = 1,
                    Login = "arykovskiy",
                    SpId = 25519,
                    Parent = 12927,
                    Parents = "2,6141,12927",
                    Levels = 3,
                    BlockNum = 6141,
                    BonusType = "Ежегодный"
                }
            };

            Employees.AddRange(employees);
        }

        if (!Periods.Any())
        {
            var periods = new List<Period>
            {
                new Period { Id = 13, Title = "2024, 1 квартал", DateStart = new DateTime(2024, 1, 1), DateEnd = new DateTime(2024, 3, 31), NumberY = 2024, NumberQ = 1 },
                new Period { Id = 14, Title = "2024, 2 квартал", DateStart = new DateTime(2024, 4, 1), DateEnd = new DateTime(2024, 6, 30), NumberY = 2024, NumberQ = 2 },
                new Period { Id = 15, Title = "2024, 3 квартал", DateStart = new DateTime(2024, 7, 1), DateEnd = new DateTime(2024, 9, 30), NumberY = 2024, NumberQ = 3 },
                new Period { Id = 16, Title = "2024, 4 квартал", DateStart = new DateTime(2024, 10, 1), DateEnd = new DateTime(2024, 12, 31), NumberY = 2024, NumberQ = 4 },
                new Period { Id = 17, Title = "2024 год", DateStart = new DateTime(2024, 1, 1), DateEnd = new DateTime(2024, 12, 31), NumberY = 2024, NumberQ = 100, IsYear = 1 }
            };

            Periods.AddRange(periods);
        }

        if (!RatingScaleValues.Any())
        {
            var values = new List<RatingScaleValue>
            {
                new RatingScaleValue { Id = 1, RatingScaleId = 1, MinimumValue = 0, MaximumValue = 99, RatingPercentage = 0 },
                new RatingScaleValue { Id = 2, RatingScaleId = 1, MinimumValue = 99, MaximumValue = (decimal)99.8, RatingPercentage = 50 },
                new RatingScaleValue { Id = 3, RatingScaleId = 1, MinimumValue = (decimal)99.8, MaximumValue = (decimal)99.9, RatingPercentage = 100 },
                new RatingScaleValue { Id = 4, RatingScaleId = 1, MinimumValue = (decimal)99.9, MaximumValue = (decimal)99.95, RatingPercentage = 105 },
                new RatingScaleValue { Id = 5, RatingScaleId = 1, MinimumValue = (decimal)99.95, MaximumValue = 100, RatingPercentage = 110 }
            };

            RatingScaleValues.AddRange(values);
        }

        SaveChanges();
    }
}
