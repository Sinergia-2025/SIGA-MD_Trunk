ALTER TABLE dbo.VentasFormasPago ADD IdCuentaBancariaEfectivo int NULL
GO
ALTER TABLE dbo.VentasFormasPago ADD CONSTRAINT FK_VentasFormasPago_CuentasBancarias
    FOREIGN KEY (IdCuentaBancariaEfectivo)
    REFERENCES dbo.CuentasBancarias (IdCuentaBancaria)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '0. Tabla Categorias Fiscales: Nuevos Campos: IvaCeroCategoriaFiscal'
ALTER TABLE CategoriasFiscales ADD IvaCeroCategoriaFiscal VarChar(10) NULL
GO
UPDATE CategoriasFiscales SET IvaCeroCategoriaFiscal = 'NOGRAVADO'     
ALTER TABLE CategoriasFiscales ALTER COLUMN IvaCeroCategoriaFiscal VarChar(10) NOT NULL
GO

PRINT ''
PRINT '0. Tabla Categorias Fiscales: Nuevos Campos: IvaCeroCategoriaFiscal'
ALTER TABLE PlanesTarjetas ADD PorcDescRecDom bit NULL
ALTER TABLE PlanesTarjetas ADD PorcDescRecLun bit NULL
ALTER TABLE PlanesTarjetas ADD PorcDescRecMar bit NULL
ALTER TABLE PlanesTarjetas ADD PorcDescRecMie bit NULL
ALTER TABLE PlanesTarjetas ADD PorcDescRecJue bit NULL
ALTER TABLE PlanesTarjetas ADD PorcDescRecVie bit NULL
ALTER TABLE PlanesTarjetas ADD PorcDescRecSab bit NULL
GO
UPDATE PlanesTarjetas SET PorcDescRecDom = 1,
                          PorcDescRecLun = 1,
                          PorcDescRecMar = 1,
                          PorcDescRecMie = 1,
                          PorcDescRecJue = 1,
                          PorcDescRecVie = 1,
                          PorcDescRecSab = 1
                            
ALTER TABLE PlanesTarjetas ALTER COLUMN PorcDescRecDom bit NOT NULL
ALTER TABLE PlanesTarjetas ALTER COLUMN PorcDescRecLun bit NOT NULL
ALTER TABLE PlanesTarjetas ALTER COLUMN PorcDescRecMar bit NOT NULL
ALTER TABLE PlanesTarjetas ALTER COLUMN PorcDescRecMie bit NOT NULL
ALTER TABLE PlanesTarjetas ALTER COLUMN PorcDescRecJue bit NOT NULL
ALTER TABLE PlanesTarjetas ALTER COLUMN PorcDescRecVie bit NOT NULL
ALTER TABLE PlanesTarjetas ALTER COLUMN PorcDescRecSab bit NOT NULL
GO

PRINT ''
PRINT '0. Tabla Cuentas Corrientes: Nuevos Campos: FechaCalculoInteres'
ALTER TABLE CuentasCorrientes ADD FechaCalculoInteresModif bit NULL
ALTER TABLE CuentasCorrientes ADD FechaCalculoInteres DateTime NULL
GO
UPDATE CuentasCorrientes SET FechaCalculoInteresModif = 0
ALTER TABLE CuentasCorrientes ALTER COLUMN FechaCalculoInteresModif bit NOT NULL
GO


IF dbo.ExisteFuncion('FacturacionRapida') = 1 AND dbo.ExisteFuncion('Fact-Rapid-ModCotizacionDolar') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('Fact-Rapid-ModCotizacionDolar', 'Fact.Rápida - Permite Modificar Cot. Dolar', 'Fact.Rápida - Permite Modificar Cot. Dolar', 'False', 'False', 'True', 'True'
        ,'FacturacionRapida', 999, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Fact-Rapid-ModCotizacionDolar' FROM RolesFunciones WHERE IdFuncion = 'FacturacionRapida'
END

IF dbo.ExisteFuncion('FacturacionRapida') = 1 AND dbo.ExisteFuncion('Facturacion-ModCotizacionDolar') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('Facturacion-ModCotizacionDolar', 'Facturacion - Permite Modificar Cot. Dolar', 'Facturacion - Permite Modificar Cot. Dolar', 'False', 'False', 'True', 'True'
        ,'FacturacionV2', 999, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Facturacion-ModCotizacionDolar' FROM RolesFunciones WHERE IdFuncion = 'FacturacionV2'
END
