USE master;
GO

-- Parámetros
DECLARE @RutaBackup AS NVARCHAR(260) = 'C:\SQLBackups\AdventureWorksDW2022.bak';

-- Verificar contenido del backup
RESTORE FILELISTONLY 
FROM DISK = @RutaBackup;
GO
-- Restaurar la base creando los archivos en la carpeta deseada
RESTORE DATABASE AdventureWorksDW2022
FROM DISK = 'C:\SQLBackups\AdventureWorksDW2022.bak'
WITH 
    MOVE 'AdventureWorksDW2022' TO 'C:\SQLBackups\AdventureWorksDW2022.mdf',
    MOVE 'AdventureWorksDW2022_log' TO 'C:\SQLBackups\AdventureWorksDW2022_log.ldf',
    REPLACE,
    STATS = 5;