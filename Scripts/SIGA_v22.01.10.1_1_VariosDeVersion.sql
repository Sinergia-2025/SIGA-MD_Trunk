PRINT ''
PRINT '1.1. Tabla Empleados: Nuevo Campo EsTransportista'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Empleados' AND COLUMN_NAME = 'EsChofer')
    BEGIN
        ALTER TABLE Empleados ADD Eschofer bit NULL;
        ALTER TABLE Empleados ADD IdTransportista int NULL;
    END
GO


PRINT ''
PRINT '1.2. Tabla Empleados: Nuevo Campo EsTransportista'
BEGIN
    UPDATE Empleados SET EsChofer = 0;
    ALTER TABLE Empleados ALTER COLUMN EsChofer bit NOT NULL;
END
GO

PRINT ''
PRINT '1.3. Tabla Empleados: Crea Clave Foranea TRansportista'
BEGIN
    ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Transportista] FOREIGN KEY([IdTransportista]) REFERENCES [dbo].[Transportistas] ([IdTransportista])
END
GO

PRINT ''
PRINT '2.1. Tabla Ventas: Nuevo Campos Transporte'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Ventas' AND COLUMN_NAME = 'IdTransportistaTransporte')
    BEGIN
        ALTER TABLE Ventas ADD IdTransportistaTransporte Int NULL;
        ALTER TABLE Ventas ADD IdChoferTransporte Int NULL;
        ALTER TABLE Ventas ADD PatenteVehiculoTransporte VarChar(8) NULL;

        ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_TransportistaTransporte] FOREIGN KEY([IdTransportistaTransporte]) REFERENCES [dbo].[Transportistas] ([IdTransportista])
        ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_ChoferTransporte] FOREIGN KEY([IdChoferTransporte]) REFERENCES [dbo].[Empleados] ([IdEmpleado])
        ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_VehiculosTransporte] FOREIGN KEY([PatenteVehiculoTransporte]) REFERENCES [dbo].[Vehiculos] ([PatenteVehiculo])
    END
GO

PRINT ''
PRINT '3.1. Tabla Calendarios: Nuevo Campos PermiteImpresion'
ALTER TABLE dbo.Calendarios ADD PermiteImpresion bit NULL
GO
UPDATE Calendarios SET PermiteImpresion = 0;
ALTER TABLE dbo.Calendarios ALTER COLUMN PermiteImpresion bit NOT NULL
GO

PRINT ''
PRINT '4. Nuevo Parámetro: Vizualizar Nombre de Fantasia.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'CONSCCBLUEOCULTANOMFANTASIA' AS IdParametro, 
                'False' ValorParametro, 
                '' CategoriaParametro, 
                'CONSCCBLUEOCULTANOMFANTASIA' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END


PRINT '5. Tabla FormatosEtiquetas, se da de alta formato 2 x Ancho (5 x 3 cm).'

INSERT INTO FormatosEtiquetas
     (IdFormatoEtiqueta, NombreFormatoEtiqueta, Tipo, ArchivoAImprimir, ArchivoAImprimirEmbebido, NombreImpresora, ImprimeLote
     ,MaximoColumnas, UtilizaCabecera, SolicitaListaPrecios2, Activo)
  VALUES
     (70, '2 x Ancho (5 x 3 cm)', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF14.rdlc', 'True', '', 'False',
      2, 'False', 'False', 'True');

GO

