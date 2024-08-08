### KPICatalog - каталог типовых целей и их связей с бонусными схемами сотрудников.

При разработке на dev-окружении можно использовать docker для развертывания как всего приложения, так и отдельно контейнера с СУБД MS SQL Server. Ниже приведена инструкция по настройке docker для каждого из вариантов.

При разработке на Mac M1 в докере в настройках надо включить галочку в пункте `Use Rosetta for x86_64/amd64 emulation on Apple Silicon`

1. Настройка dev-окружения для использования только MS SQL Server контейнера:

    -устанавливаем docker и docker composer на dev-машину

    -запускаем в терминале/командной строке скрипт, который создает контейнер с мультиархитектурным образом SQL Server: `docker pull mcr.microsoft.com/azure-sql-edge`

    -запускаем контейнер с MS SQL Server: `docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=QWErty_12345678' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/azure-sql-edge`

    -для работы с БД можно использовать SSMS или Azure Data Studio (на Mac OS)

2. Для запуска и хостинга контейнеров локально в Docker достаточно в терминале перейти в папку проекта, где лежит файл docker-compose.yml, и запустить команду `docker-compose up --build`
