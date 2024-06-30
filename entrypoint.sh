#!/bin/bash

# Wait for SQL Server to start up
/wait-for-it.sh sqlserver:1433 --timeout=5

# Run the setup script to create the DB and schema in the DB
echo "Running the init script..."
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P QWErty_12345678 -d master -i /init-db.sql

if [ $? -eq 0 ]; then
  echo "Script init-db finished. Database initialized successfully!"
else
  echo "Failed to initialize database."
  exit 1
fi

# Run the application
echo "Starting the application..."

dotnet KPICatalog.API.dll