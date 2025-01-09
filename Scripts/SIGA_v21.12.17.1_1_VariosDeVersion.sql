PRINT ''
PRINT '1. Tabla DashBoardsPaneles: Nuevo Campo VisualizaLeyenda'
PRINT ''
PRINT 'B1. Insertar Nuevo Campo: VisualizaLeyenda'
ALTER TABLE DashBoardsPaneles ADD VisualizaLeyenda bit NULL
GO
UPDATE DashBoardsPaneles SET VisualizaLeyenda = 0;
ALTER TABLE DashBoardsPaneles ALTER COLUMN VisualizaLeyenda bit NOT NULL
GO

INSERT [dbo].[TiposMovimientos] 
        ([IdTipoMovimiento], [Descripcion], [CoeficienteStock], [ComprobantesAsociados], [AsociaSucursal], 
         [MuestraCombo], [HabilitaDestinatario], [HabilitaRubro], [Imprime], [CargaPrecio], 
         [IdContraTipoMovimiento], [HabilitaEmpleado], [ReservaMercaderia]) 
 VALUES ('SRV_CONSUMO', N'Consumo Service', -1, NULL, 'False',
         'False', 'False', 'False', 'False', 'NO', 
         NULL, 'False', 'False'),
        ('SRV_DEVOL', N'Devolucion Service', 1, NULL, 'False',
         'False', 'False', 'False', 'False', 'NO', 
         NULL, 'False', 'False')

DECLARE @idParametro VARCHAR(MAX) = 'CRMMOVIMIENTOCONSUMO'
DECLARE @descripcionParametro VARCHAR(MAX) = 'RMA: Movimiento para Consumo'
DECLARE @valorParametro VARCHAR(MAX) = 'SRV_CONSUMO'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;

SET @idParametro = 'CRMMOVIMIENTOREVERSADO'
SET @descripcionParametro = 'RMA: Movimiento para Reversado'
SET @valorParametro = 'SRV_DEVOL'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


PRINT ''
PRINT '1. Tabla Calendarios: Nuevo Campo SolicitaVehiculos'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Calendarios' AND COLUMN_NAME = 'SolicitaVehiculo')
    BEGIN
        ALTER TABLE Calendarios ADD SolicitaVehiculo bit NULL;
    END
GO

PRINT ''
PRINT '2. Tabla Calendarios: Nuevo Campo SolicitaVehiculos'
BEGIN
    UPDATE Calendarios  SET SolicitaVehiculo = 0;

    ALTER TABLE Calendarios ALTER COLUMN SolicitaVehiculo bit NOT NULL;
END
GO

PRINT ''
PRINT '3. Buscador Nuevo: Vehiculos'
BEGIN
    PRINT ''
    PRINT '3-1. Buscador Nuevo: Vehiculos'
    BEGIN
        INSERT INTO [dbo].[Buscadores]
                   ([IdBuscador]
                   ,[Titulo]
                   ,[AnchoAyuda]
                   ,[IniciaConFocoEn]
                   ,[ColumaBusquedaInicial])
             VALUES
                   (200
                   ,'Vehiculos'
                   ,780
                   ,'Grilla'
                   ,'')
    END

    PRINT ''
    PRINT '3-2. Buscador Nuevo Campos: Vehiculos'
    BEGIN
        INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo,Orden,Titulo,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
             VALUES (200,'PatenteVehiculo',1,'Patente Vehiculo',16,80,'',NULL,NULL,NULL)

        INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo,Orden,Titulo,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
             VALUES (200,'NombreCliente',2,'Nombre Cliente',16,100,'',NULL,NULL,NULL)

        INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo,Orden,Titulo,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
             VALUES (200,'NombreMarcaVehiculo',3,'Marca Vehiculo',16,100,'',NULL,NULL,NULL)

        INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo,Orden,Titulo,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
             VALUES (200,'NombreModeloVehiculo',4,'Modelo Vehiculo',16,100,'',NULL,NULL,NULL)

        INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo,Orden,Titulo,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
             VALUES (200,'Color',5,'Color Vehiculo',16,100,'',NULL,NULL,NULL)

        INSERT INTO BuscadoresCampos(IdBuscador,IdBuscadorNombreCampo,Orden,Titulo,Alineacion,Ancho,Formato,Condicion,Valor,ColorFila)
             VALUES (200,'IdCliente',6,'',64,80,'',NULL,NULL,NULL)

    END

END
GO


PRINT ''
PRINT '4. Tabla Turnos: Nuevo Campo IdPatenteVehiculo'
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TurnosCalendarios' AND COLUMN_NAME = 'IdPatenteVehiculo')
    BEGIN
        ALTER TABLE TurnosCalendarios ADD IdPatenteVehiculo VarChar(8) NULL;
    END
GO



