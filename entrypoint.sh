#!/bin/bash

# Wait for SQL Server to start up
/wait-for-it.sh sqlserver:1433 --timeout=5

# Run the application
echo "Starting the application..."

dotnet KPICatalog.API.dll