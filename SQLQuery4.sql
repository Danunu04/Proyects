ALTER TABLE [dbo].[686DP_Cobertura] NOCHECK CONSTRAINT ALL;
ALTER TABLE [dbo].[686DP_Plan] NOCHECK CONSTRAINT ALL;
-- Ejecutás los DELETE
DELETE FROM [dbo].[686DP_Cobertura]; -- Hija de Plan
DELETE FROM [dbo].[686DP_Plan];      -- Hija de Producto
DELETE FROM [dbo].[686DP_Productos]; -- Padre

-- Luego las volvés a activar:
ALTER TABLE [dbo].[686DP_Cobertura] CHECK CONSTRAINT ALL;
ALTER TABLE [dbo].[686DP_Plan] CHECK CONSTRAINT ALL;
DELETE FROM [dbo].[686DP_PlanesCoberturas][dbo].[686DP_Seguro]

