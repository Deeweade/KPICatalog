KPICatalog - каталог типовых целей и их связей с бонусными схемами сотрудников.

При разработке на dev-окружении можно использовать docker для развертывания СУБД MS SQL Server в контейнере. Ниже приведена инструкция по настройке docker.

Настройка dev-окружения:

    -устанавливаем docker и docker composer на dev-машину

    -запускаем в терминале/командной строке скрипт, который создает контейнер с мультиархитектурным образом SQL Server: docker pull mcr.microsoft.com/azure-sql-edge

    -запускаем контейнер с MS SQL Server: docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Пароль_с_цифрами_8_и_знакаМИ' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/azure-sql-edge

    -для работы с БД можно использовать SSMS или Azure Data Studio (на Mac OS)
    
    -после запуска контейнера запустить SQL скрипт из файла init-db.sql (таблицы в БД KPICatalog добавятся автоматически с помощью миграций при запуске проекта).