PRINT ''
PRINT '1. Nuevo Formato de Etiqueta'
DECLARE @IdFormatoEtiqueta INT
SET @IdFormatoEtiqueta = (SELECT MAX(IdFormatoEtiqueta) FROM FormatosEtiquetas) + 1
INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta], [NombreFormatoEtiqueta], [Tipo], [ArchivoAImprimir], [ArchivoAImprimirEmbebido]
           ,[NombreImpresora], [ImprimeLote], [MaximoColumnas], [UtilizaCabecera], [SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@IdFormatoEtiqueta, '2 x Descuento por Volumen', 'PRECIOS', 'Eniac.Win.EmisionDeEtiquetasDePreciosF7.rdlc', 'True',
		   '', 'False', 2, 'False', 'False',
		   'True')
GO

PRINT ''
PRINT '2 Tabla MovimientosCompras: Nuevos Campo MercEnviada'
ALTER TABLE Compras ADD [MercEnviada] [bit] NULL
GO
PRINT ''
PRINT '2.1. Tabla MovimientosCompras: Actualizar registros pre-existentes para los campos'
UPDATE Compras SET [MercEnviada] = 'False'
PRINT ''
PRINT '2.2. Tabla MovimientosCompras: NOT NULL para los campos agregados'
ALTER TABLE Compras ALTER COLUMN [MercEnviada] [bit] NOT NULL

PRINT ''
PRINT '3. Parametro Nuevo: MUESTRAFECHAACTUALIZA'
MERGE INTO Parametros AS DEST
USING (
        SELECT IdEmpresa,
            'MUESTRAFECHAACTUALIZA' AS IdParametro,
            'TRUE' ValorParametro,
            '' CategoriaParametro,
            'En Consultar Precios por Producto Muestra fecha de Actualización' DescripcionParametro FROM Empresas) AS ORIG
        ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
WHEN MATCHED THEN
    UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
WHEN NOT MATCHED THEN
    INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro)
    VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);



PRINT ''
PRINT '4. Nuevo Menu: Informa Ventas Pirelli'
IF dbo.SoyHAR() = 1 AND dbo.BaseConCuit('20085063899') = 1
BEGIN
    ------------------------------------------------------------------------------------------------------------------------
    PRINT ''
    PRINT '4.1. Nueva Opcion de Menú: '

	IF dbo.ExisteFuncion('InformaVentasPirelli') = 0
	BEGIN    
            INSERT INTO Funciones
                (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
                ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
            VALUES
                ('InformaVentasPirelli', 'Informe Ventas a Pirelli', 'Informe Ventas a Pirelli', 'False', 'False', 'True', 'True'
                ,'Ventas', 76, 'Eniac.Win', 'InformaVentasPirelli', NULL, NULL
                ,'True', 'S', 'N', 'N', 'N', 'True')

            INSERT INTO RolesFunciones (IdRol,IdFuncion)
            SELECT DISTINCT Id AS Rol, 'InformaVentasPirelli' AS Pantalla FROM dbo.Roles
             WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
    ------------------------------------------------------------------------------------------------------------------------
END
------------------------------------------------------------------------------------------------------------------------
PRINT ''
PRINT '5. Inserta parametro tabla de Parametros'
DECLARE @Valor as Varchar(10)
IF dbo.ExisteFuncion('InformaVentasPirelli') = 1
BEGIN
    PRINT ''
    PRINT 'B1. Carga URL Base de Pirelli.-'
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'VENTASPIRELLIURLBASE' AS IdParametro, 
                'Http://152.67.35.38/controller/api/upload' ValorParametro, 
                'Ventas Pirelli' CategoriaParametro, 
                'VENTASPIRELLIURLBASE' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);

    PRINT ''
    PRINT 'B1. Carga IDMARCA Ventas Pirelli.-'
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'VENTASPIRELLIIDMARCA' AS IdParametro, 
                '2' ValorParametro, 
                'Ventas Pirelli' CategoriaParametro, 
                'VENTASPIRELLIIDMARCA' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);

END
