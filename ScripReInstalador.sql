IF EXISTS (SELECT name FROM sys.databases WHERE name = 'DBAseguraYADemo')
BEGIN
    PRINT 'La base existe. Insertando datos...';

    INSERT INTO [DBAseguraYADemo].[dbo].[686DP_PermisoSimple] 
        (DP686_Nombre)
    VALUES
        ('RecomendacionAumento');

    INSERT INTO [DBAseguraYADemo].[dbo].[686DP_PerfilPermiso]
        (DP686_PerfilID, DP686_PermisoID)
    VALUES
        (7, 21);
END
ELSE
BEGIN
    PRINT 'La base NO existe. No se puede insertar.';
END
