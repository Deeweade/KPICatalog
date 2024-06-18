# Используем базовый образ для ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Используем образ SDK для сборки проекта
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файлы решения и проектов
COPY ["KPICatalog.sln", "./"]
COPY ["KPICatalog.API/KPICatalog.API.csproj", "KPICatalog.API/"]
COPY ["KPICatalog.Application/KPICatalog.Application.csproj", "KPICatalog.Application/"]
COPY ["KPICatalog.Domain/KPICatalog.Domain.csproj", "KPICatalog.Domain/"]
COPY ["KPICatalog.Infrastructure/KPICatalog.Infrastructure.csproj", "KPICatalog.Infrastructure/"]

# Восстанавливаем зависимости проекта
RUN dotnet restore "KPICatalog.API/KPICatalog.API.csproj"

# Копируем все исходные коды
COPY . .

# Собираем проект
WORKDIR "/src/KPICatalog.API"
RUN dotnet build "KPICatalog.API.csproj" -c Debug -o /app/build

# Публикуем проект
FROM build AS publish
RUN dotnet publish "KPICatalog.API.csproj" -c Debug -o /app/publish

# Используем базовый образ для выполнения проекта
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KPICatalog.API.dll"]
