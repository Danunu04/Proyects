USE master;
GO

-- Cerrar conexiones y poner ambas bases en modo SINGLE_USER
ALTER DATABASE AseguraYA SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
--ALTER DATABASE AdventureWorksDW2022 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

-- Restaurar backup sobrescribiendo la base AseguraYA
RESTORE DATABASE AseguraYA
FROM DISK = 'C:\SQLBackups\AseguraYA.bak'
WITH 
    MOVE 'AseguraYA' TO 'C:\SQLBackups\AseguraYA.mdf',
    MOVE 'AseguraYA_log' TO 'C:\SQLBackups\AseguraYA_log.ldf',
    REPLACE,
    STATS = 5;
GO

-- Volver a modo MULTI_USER en ambas bases
ALTER DATABASE AseguraYA SET MULTI_USER;
--ALTER DATABASE AdventureWorksDW2022 SET MULTI_USER;
GO
