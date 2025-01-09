PRINT ''
PRINT '1. Tabla Calles: Si hay dos calles General con id 1 dejo solo una.'
--Esto se da en bases que se ejecutaron dos veces un script fallido.
IF (SELECT COUNT(1) FROM Calles WHERE IdCalle = 1 AND NombreCalle = 'General' AND IdLocalidad = 2000) > 1
BEGIN
    DELETE Calles
     WHERE IdCalle = 1 AND NombreCalle = 'General' AND IdLocalidad = 2000

    INSERT INTO [dbo].[Calles] ([IdCalle], [NombreCalle], [IdLocalidad])
        VALUES (1, 'General', 2000)
END

PRINT ''
PRINT '1.1. Tabla Calles: Si no existe la PK de Calles, la creo.'
--Esto se da en bases que se ejecutaron dos veces un script fallido.
IF (OBJECT_ID('dbo.PK_Calles', 'PK') IS NULL)
BEGIN
    ALTER TABLE dbo.Calles ADD CONSTRAINT PK_Calles
    PRIMARY KEY CLUSTERED (IdCalle) 
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
END

PRINT ''
PRINT '1.2. Tabla Calles: Drop de las FK de Clientes con Calle.'
--La vuelvo a crear más adelante.
IF (OBJECT_ID('dbo.FK_Clientes_Calles', 'F')  IS NOT NULL) ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_Clientes_Calles]
IF (OBJECT_ID('dbo.FK_Clientes_Calles1', 'F') IS NOT NULL) ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_Clientes_Calles1]
GO

PRINT ''
PRINT '1.3. Tabla Calles: Si el Cliente tiene IdCalle o IdCalle2 igual a cero, le pongo 1.'
--Esto se da en bases que se ejecutaron dos veces un script fallido.
UPDATE Clientes
   SET IdCalle  = ISNULL(NULLIF(IdCalle,  0), 1)
     , IdCalle2 = ISNULL(NULLIF(IdCalle2, 0), 1)

PRINT ''
PRINT '1.4. Tabla Calles: Recrear FK de Clientes con Calle.'
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Calles] FOREIGN KEY([IdCalle])
REFERENCES [dbo].[Calles] ([IdCalle])
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Calles1] FOREIGN KEY([IdCalle2])
REFERENCES [dbo].[Calles] ([IdCalle])
GO

ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Calles]
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Calles1]
GO

PRINT ''
PRINT '2. Tabla Tarjetas: Nuevo campo IdProveedor'
BEGIN
    ALTER TABLE Tarjetas ADD IdProveedor bigint
    ALTER TABLE Tarjetas ADD CONSTRAINT FK_Proveedores 
        FOREIGN KEY (IdProveedor)
        REFERENCES Proveedores (IdProveedor)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION
END

PRINT ''
PRINT '3. Cambiar reporte 432_eComprobanteDolares.rdlc por Eniac.Win.eComprobanteDolares.rdlc'
BEGIN 
    UPDATE TiposComprobantesLetras  
        SET  ArchivoAImprimir = 'Eniac.Win.eComprobanteDolares.rdlc'
            ,ArchivoAImprimirEmbebido = 1      
    WHERE ArchivoAImprimir = '432_eComprobanteDolares.rdlc'
END
GO

PRINT ''
PRINT '4. Tabla TiposComprobantes: Ajuste de mínimos y topes'
UPDATE TiposComprobantes
   SET ImporteMinimo = ISNULL(NULLIF(ImporteMinimo, 0), 0.01)
     , ImporteTope   = ISNULL(NULLIF(ImporteTope, 0), 9999999.99)
  FROM TiposComprobantes
 WHERE Tipo = 'VENTAS'
   AND ((ImporteMinimo  = 0 AND ImporteTope <> 0) OR
        (ImporteMinimo <> 0 AND ImporteTope  = 0))

PRINT ''
PRINT '5. Nueva Función: TarjetasCuponesABM'
IF dbo.ExisteFuncion('Caja') = 1
BEGIN

    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('TarjetasCuponesABM', 'ABM de Cupones de Tarjeta', 'ABM de Cupones de Tarjeta', 'True', 'False', 'True', 'True'
        ,'Caja', 65, 'Eniac.Win', 'TarjetasCuponesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
    
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'TarjetasCuponesABM' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '6. Tabla TarjetasCupones: Nuevo campo IdSituacionCupones'
BEGIN
    ALTER TABLE TarjetasCupones ADD IdSituacionCupon Int NULL
END
GO

PRINT ''
PRINT '7.1. Tabla TarjetasCupones: Nuevo campo IdSituacionCupones'
BEGIN
    UPDATE TarjetasCupones SET IdSituacionCupon = (SELECT IdSituacionCupon FROM SituacionCupones WHERE PorDefecto = 1)

    ALTER TABLE TarjetasCupones ALTER COLUMN IdSituacionCupon Int NOT NULL

    ALTER TABLE TarjetasCupones ADD CONSTRAINT FK_SituacionesCupones 
        FOREIGN KEY (IdSituacionCupon)
        REFERENCES SituacionCupones (IdsituacionCupon)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

