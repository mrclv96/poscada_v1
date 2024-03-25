# POSCADA

a. Set Database (Docker SQL Server Container)
    1. Make a SQL Server Docker Container as a database. Run the command below on bash. Replace SA password, Port, container name, hast name for those needed or available. Once ran the command, Docker Container's port will be forwarding automatically to localhost port:
        docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Portamento8' -e 'MSSQL_PID=Developer' -e 'TCPENABLED=Yes' -p 1461:1433 --name assemblylineserver --hostname assemblylineserver -d mcr.microsoft.com/mssql/server:2022-latest
    2. Fill database. 
        IF YOU CAN GET A BACKUP: Get a backup from Assemblyline_data db on Assemblyline server. Copy the .bak file to the Codespace, and then run first command to copy the .bak file within the container. Once .bak file is copied, run SQL query to backup .bak file into the SQL Server instance on container. It might be used SSMS, Azure Data Studio or any other database manager.
            docker cp Assemblyline_data.bak assemblylineserver:/home
            BACKUP DATABASE Assemblyline_data
            TO DISK = 'home\Assemblyline_data.bak'
            WITH FORMAT NAME = 'Assemblyline_data';

        IF YOU HAVE .csv FILES EXPORTED FROM DATABASE: Get columns data types is needed to correctly import data from .csv files. Running SQL query below, data types will be shown. Then, import .csv files with any database manager with the same datatypes as they were on assemblyline db. Procedure may vary depending on the db manager used.
            SELECT COLUMN_NAME, DATA_TYPE
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = 'NombreDeTuTabla';

b. Run ASP.NET WebAPI
    1. Edit connection string from /workspaces/POSCADA/SCADA_A/SCADA_A.Web/appsettings.json. It should include SQL Server database container info.
    2. Open /workspaces/POSCADA/SCADA_A/SCADA_A.Web/ path on bash and execute "dotnet run". Codespace port will be forwarding automatically to a localhost port. Start WebAPI will open a web browser tab, but that view won´t work.
    
c. Run Vue.Js project
    1. Open /workspaces/POSCADA/ScadaVue/scada/ path on bash. Then, run "npm i @vue/cli-service" to install a missing dependency.
    2. Edit axios.defaults.baseURL at /workspaces/POSCADA/ScadaVue/scada/src/main.js. URL should be the same port as forwarded for the WebAPI
    3. AT /workspaces/POSCADA/ScadaVue/scada/, Run "npm run serve" to start app.