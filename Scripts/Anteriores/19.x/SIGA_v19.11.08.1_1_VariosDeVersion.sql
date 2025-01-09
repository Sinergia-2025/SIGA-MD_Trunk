PRINT ''
PRINT '1. Tabla ContabilidadAsientosCuentas: Agregar nuevo campo IdEjercicio'
ALTER TABLE ContabilidadAsientosCuentas ADD IdEjercicio INT NULL
GO
PRINT ''
PRINT '1.1. Tabla ContabilidadAsientosCuentas: Valores por defecto para campo IdEjercicio (tomado de ContabilidadAsientos)'
UPDATE CAC
   SET IdEjercicio = CA.IdEjercicio
  FROM ContabilidadAsientosCuentas CAC
 INNER JOIN ContabilidadAsientos CA ON CA.IdPlanCuenta = CAC.IdPlanCuenta AND CA.IdAsiento = CAC.IdAsiento
PRINT ''
PRINT '1.2. Tabla ContabilidadAsientosCuentas: NOT NULL para campo IdEjercicio'
ALTER TABLE ContabilidadAsientosCuentas ALTER COLUMN IdEjercicio INT NOT NULL
GO

PRINT ''
PRINT '2. Tabla ContabilidadAsientosCuentas: DROP PRIMARY KEY'
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] DROP CONSTRAINT [PK_ContabilidadAsientosCuentas]
PRINT ''
PRINT '3. Tabla ContabilidadAsientosCuentas: DROP FK a ContabilidadAsientos'
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] DROP CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos]
PRINT ''
PRINT '4. Tabla ContabilidadAsientos: DROP PRIMARY KEY'
ALTER TABLE [dbo].[ContabilidadAsientos] DROP CONSTRAINT [PK_ContabilidadAsientos]
GO

PRINT ''
PRINT '5. Tabla ContabilidadAsientos: RE-CREATE PRIMARY KEY'
ALTER TABLE [dbo].[ContabilidadAsientos] ADD  CONSTRAINT [PK_ContabilidadAsientos] PRIMARY KEY CLUSTERED 
(
	[IdEjercicio] ASC, [IdPlanCuenta] ASC, [IdAsiento] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
PRINT ''
PRINT '6. Tabla ContabilidadAsientosCuentas: RE-CREATE PRIMARY KEY'
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] ADD  CONSTRAINT [PK_ContabilidadAsientosCuentas] PRIMARY KEY CLUSTERED 
(
    [IdEjercicio] ASC, [IdPlanCuenta] ASC, [IdAsiento] ASC, [IdCuenta] ASC, [IdRenglon] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

PRINT ''
PRINT '7. Tabla ContabilidadAsientosCuentas: RE-CREATE FK a ContabilidadAsientos'
ALTER TABLE [dbo].[ContabilidadAsientosCuentas]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos] FOREIGN KEY([IdEjercicio], [IdPlanCuenta], [IdAsiento])
REFERENCES [dbo].[ContabilidadAsientos] ([IdEjercicio], [IdPlanCuenta], [IdAsiento])
GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] CHECK CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos]
GO

PRINT ''
PRINT '8. Tabla ContabilidadAsientosCuentasTmp: Agregar nuevo campo IdEjercicio'
ALTER TABLE ContabilidadAsientosCuentasTmp ADD IdEjercicio INT NULL
GO
PRINT ''
PRINT '8.1. Tabla ContabilidadAsientosCuentasTmp: Valores por defecto para campo IdEjercicio (tomado de ContabilidadAsientosTmp)'
UPDATE CAC
   SET IdEjercicio = CA.IdEjercicio
  FROM ContabilidadAsientosCuentasTmp CAC
 INNER JOIN ContabilidadAsientosTmp CA ON CA.IdPlanCuenta = CAC.IdPlanCuenta AND CA.IdAsiento = CAC.IdAsiento
PRINT ''
PRINT '8.2. Tabla ContabilidadAsientosCuentasTmp: NOT NULL para campo IdEjercicio'
ALTER TABLE ContabilidadAsientosCuentasTmp ALTER COLUMN IdEjercicio INT NOT NULL
GO

PRINT ''
PRINT '9. Tabla ContabilidadAsientosCuentasTmp: DROP PRIMARY KEY'
ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] DROP CONSTRAINT [PK_ContabilidadAsientosCuentasTmp]
PRINT ''
PRINT '10. Tabla ContabilidadAsientosCuentasTmp: DROP FK a ContabilidadAsientosTmp'
ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] DROP CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientosTmp]
PRINT ''
PRINT '11. Tabla ContabilidadAsientosTmp: DROP PRIMARY KEY'
ALTER TABLE [dbo].[ContabilidadAsientosTmp] DROP CONSTRAINT [PK_ContabilidadAsientosTmp]
GO

PRINT ''
PRINT '12. Tabla ContabilidadAsientosTmp: RE-CREATE PRIMARY KEY'
ALTER TABLE [dbo].[ContabilidadAsientosTmp] ADD  CONSTRAINT [PK_ContabilidadAsientosTmp] PRIMARY KEY CLUSTERED 
(
	[IdEjercicio] ASC, [IdPlanCuenta] ASC, [IdAsiento] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
PRINT ''
PRINT '13. Tabla ContabilidadAsientosCuentasTmp: RE-CREATE PRIMARY KEY'
ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] ADD  CONSTRAINT [PK_ContabilidadAsientosCuentasTmp] PRIMARY KEY CLUSTERED 
(
    [IdEjercicio] ASC, [IdPlanCuenta] ASC, [IdAsiento] ASC, [IdCuenta] ASC, [IdRenglon] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

PRINT ''
PRINT '14. Tabla ContabilidadAsientosCuentasTmp: RE-CREATE FK a ContabilidadAsientosTmp'
ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp]  WITH CHECK ADD  CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientosTmp] FOREIGN KEY([IdEjercicio], [IdPlanCuenta], [IdAsiento])
REFERENCES [dbo].[ContabilidadAsientosTmp] ([IdEjercicio], [IdPlanCuenta], [IdAsiento])
GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] CHECK CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientosTmp]
GO

PRINT ''
PRINT '15. Tabla ContabilidadAsientosCuentasTmp: Agregar nuevo campo IdEjercicio'
ALTER TABLE ContabilidadAsientosTmp ADD IdEjercicioDefinitivo INT NULL
GO
PRINT ''
PRINT '14.1. Tabla ContabilidadAsientosCuentasTmp: Valores por defecto para campo IdEjercicio (tomado de ContabilidadAsientosTmp)'
UPDATE CAT
   SET IdEjercicioDefinitivo = CA.IdEjercicio
  FROM ContabilidadAsientosTmp CAT
 INNER JOIN ContabilidadAsientos CA ON CA.IdPlanCuenta = CAT.IdPlanCuentaDefinitivo AND CA.IdAsiento = CAT.IdAsientoDefinitivo
GO

PRINT ''
PRINT '14.2. Tabla ContabilidadAsientosTmp: NULL si los definitivos son 0'
UPDATE ContabilidadAsientosTmp
   SET IdAsientoDefinitivo = NULL
     , IdPlanCuentaDefinitivo = NULL
 WHERE IdAsientoDefinitivo = 0 AND IdPlanCuentaDefinitivo = 0

PRINT ''
PRINT '14.3. Tabla ContabilidadAsientosTmp: FK a ContabilidadAsientos'
ALTER TABLE dbo.ContabilidadAsientosTmp ADD CONSTRAINT FK_ContabilidadAsientosTmp_ContabilidadAsientos
    FOREIGN KEY (IdEjercicioDefinitivo,IdPlanCuentaDefinitivo,IdAsientoDefinitivo)
    REFERENCES dbo.ContabilidadAsientos (IdEjercicio,IdPlanCuenta,IdAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '15.1. Drop de Vista vw_ContabilidadAsientosIDMaximo'
DROP VIEW [dbo].[vw_ContabilidadAsientosIDMaximo]
GO
PRINT ''
PRINT '15.2. Recrear de Vista vw_ContabilidadAsientosIDMaximo'
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ContabilidadAsientosIDMaximo] AS 
SELECT IdEjercicio
     , IdPlanCuenta
     , MAX(maximo) AS Maximo
  FROM (SELECT IdEjercicio, IdPlanCuenta, ISNULL(MAX(IdAsiento),0) AS maximo
          FROM ContabilidadAsientos
         GROUP BY IdEjercicio, IdPlanCuenta
         UNION
         SELECT IdEjercicio, IdPlanCuenta, ISNULL(MAX(IdAsiento),0) AS maximo
           FROM ContabilidadAsientostmp
          GROUP BY IdEjercicio, IdPlanCuenta
       ) tp
 GROUP BY IdEjercicio, IdPlanCuenta

GO


PRINT ''
PRINT '16. Tabla Ventas: Nuevo campo IdEjercicio'
ALTER TABLE dbo.Ventas ADD IdEjercicio int NULL
GO
PRINT ''
PRINT '16.1. Tabla Ventas: Valor por defecto para IdEjercicio'
UPDATE V 
   SET IdEjercicio = CAT.IdEjercicio 
  FROM Ventas V
 INNER JOIN ContabilidadAsientosTmp CAT ON CAT.IdPlanCuenta = V.IdPlanCuenta AND CAT.IdAsiento = V.IdAsiento
PRINT ''
PRINT '16.2. Tabla Ventas: FK a ContabilidadAsientosTmp'
ALTER TABLE dbo.Ventas ADD CONSTRAINT FK_Ventas_ContabilidadAsientosTmp
    FOREIGN KEY (IdEjercicio,IdPlanCuenta,IdAsiento)
    REFERENCES dbo.ContabilidadAsientosTmp (IdEjercicio,IdPlanCuenta,IdAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '17. Tabla CuentasCorrientes: Nuevo campo IdEjercicio'
ALTER TABLE dbo.CuentasCorrientes ADD IdEjercicio int NULL
GO
PRINT ''
PRINT '17.1. Tabla CuentasCorrientes: Valor por defecto para IdEjercicio'
UPDATE V
   SET IdEjercicio = CAT.IdEjercicio
  FROM CuentasCorrientes V
 INNER JOIN ContabilidadAsientosTmp CAT ON CAT.IdPlanCuenta = V.IdPlanCuenta AND CAT.IdAsiento = V.IdAsiento
PRINT ''
PRINT '17.2. Tabla CuentasCorrientes: FK a ContabilidadAsientosTmp'
ALTER TABLE dbo.CuentasCorrientes ADD CONSTRAINT FK_CuentasCorrientes_ContabilidadAsientosTmp
    FOREIGN KEY (IdEjercicio,IdPlanCuenta,IdAsiento)
    REFERENCES dbo.ContabilidadAsientosTmp (IdEjercicio,IdPlanCuenta,IdAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '18. Tabla Compras: Nuevo campo IdEjercicio'
ALTER TABLE dbo.Compras ADD IdEjercicio int NULL
GO
PRINT ''
PRINT '18.1. Tabla Compras: Valor por defecto para IdEjercicio'
UPDATE V
   SET IdEjercicio = CAT.IdEjercicio
  FROM Compras V
 INNER JOIN ContabilidadAsientosTmp CAT ON CAT.IdPlanCuenta = V.IdPlanCuenta AND CAT.IdAsiento = V.IdAsiento
PRINT ''
PRINT '18.2. Tabla Compras: FK a ContabilidadAsientosTmp'
ALTER TABLE dbo.Compras ADD CONSTRAINT FK_Compras_ContabilidadAsientosTmp
    FOREIGN KEY (IdEjercicio,IdPlanCuenta,IdAsiento)
    REFERENCES dbo.ContabilidadAsientosTmp (IdEjercicio,IdPlanCuenta,IdAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '19. Tabla CuentasCorrientesProv: Nuevo campo IdEjercicio'
ALTER TABLE dbo.CuentasCorrientesProv ADD IdEjercicio int NULL
GO
PRINT ''
PRINT '19.1. Tabla CuentasCorrientesProv: Valor por defecto para IdEjercicio'
UPDATE V
   SET IdEjercicio = CAT.IdEjercicio
  FROM CuentasCorrientesProv V
 INNER JOIN ContabilidadAsientosTmp CAT ON CAT.IdPlanCuenta = V.IdPlanCuenta AND CAT.IdAsiento = V.IdAsiento
PRINT ''
PRINT '19.2. Tabla CuentasCorrientesProv: FK a ContabilidadAsientosTmp'
ALTER TABLE dbo.CuentasCorrientesProv ADD CONSTRAINT FK_CuentasCorrientesProv_ContabilidadAsientosTmp
    FOREIGN KEY (IdEjercicio,IdPlanCuenta,IdAsiento)
    REFERENCES dbo.ContabilidadAsientosTmp (IdEjercicio,IdPlanCuenta,IdAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '20. Tabla CajasDetalle: Nuevo campo IdEjercicio'
ALTER TABLE dbo.CajasDetalle ADD IdEjercicio int NULL
GO
PRINT ''
PRINT '20.1. Tabla CajasDetalle: Valor por defecto para IdEjercicio'
UPDATE V
   SET IdEjercicio = CAT.IdEjercicio
  FROM CajasDetalle V
 INNER JOIN ContabilidadAsientosTmp CAT ON CAT.IdPlanCuenta = V.IdPlanCuenta AND CAT.IdAsiento = V.IdAsiento
PRINT ''
PRINT '20.2. Tabla CajasDetalle: FK a ContabilidadAsientosTmp'
ALTER TABLE dbo.CajasDetalle ADD CONSTRAINT FK_CajasDetalle_ContabilidadAsientosTmp
    FOREIGN KEY (IdEjercicio,IdPlanCuenta,IdAsiento)
    REFERENCES dbo.ContabilidadAsientosTmp (IdEjercicio,IdPlanCuenta,IdAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '21. Tabla LibrosBancos: Nuevo campo IdEjercicio'
ALTER TABLE dbo.LibrosBancos ADD IdEjercicio int NULL
GO
PRINT ''
PRINT '21.1. Tabla LibrosBancos: Valor por defecto para IdEjercicio'
UPDATE V
   SET IdEjercicio = CAT.IdEjercicio
  FROM LibrosBancos V
 INNER JOIN ContabilidadAsientosTmp CAT ON CAT.IdPlanCuenta = V.IdPlanCuenta AND CAT.IdAsiento = V.IdAsiento
PRINT ''
PRINT '21.2. Tabla LibrosBancos: FK a ContabilidadAsientosTmp'
ALTER TABLE dbo.LibrosBancos ADD CONSTRAINT FK_LibrosBancos_ContabilidadAsientosTmp
    FOREIGN KEY (IdEjercicio,IdPlanCuenta,IdAsiento)
    REFERENCES dbo.ContabilidadAsientosTmp (IdEjercicio,IdPlanCuenta,IdAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '22. Tabla Depositos: Nuevo campo IdEjercicio'
ALTER TABLE dbo.Depositos ADD IdEjercicio int NULL
GO
PRINT ''
PRINT '22.1. Tabla Depositos: Valor por defecto para IdEjercicio'
UPDATE V
   SET IdEjercicio = CAT.IdEjercicio
  FROM Depositos V
 INNER JOIN ContabilidadAsientosTmp CAT ON CAT.IdPlanCuenta = V.IdPlanCuenta AND CAT.IdAsiento = V.IdAsiento
PRINT ''
PRINT '22.2. Tabla Depositos: FK a ContabilidadAsientosTmp'
ALTER TABLE dbo.Depositos ADD CONSTRAINT FK_Depositos_ContabilidadAsientosTmp
    FOREIGN KEY (IdEjercicio,IdPlanCuenta,IdAsiento)
    REFERENCES dbo.ContabilidadAsientosTmp (IdEjercicio,IdPlanCuenta,IdAsiento)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '23. Tabla LiquidacionesCargos: Nuevo Indice IX_LiquidacionesCargos_Comprobante'
CREATE NONCLUSTERED INDEX IX_LiquidacionesCargos_Comprobante ON dbo.LiquidacionesCargos
	(PeriodoLiquidacion, IdSucursal,IdTipoComprobante,Letra,CentroEmisor,NumeroComprobante)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]



PRINT ''
PRINT '24. Menu: Deshabilita InfComisionesProductos si utiliza Impuestos Internos'
DECLARE @ConImpuestoInterno bit
SET @ConImpuestoInterno = (SELECT CONVERT(bit, SUM(ImporteImpuestoInterno) + SUM(PorcImpuestoInterno)) ConImpuestoInterno FROM Productos)

IF @ConImpuestoInterno = 'True'
BEGIN
    UPDATE Funciones
       SET [Enabled] = 'False'
         , [Visible] = 'False'
     WHERE Pantalla = 'InfComisionesProductos'
END
