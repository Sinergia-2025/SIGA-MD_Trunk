PRINT ''
PRINT '1. Nuevo Parámetro: IDCATEGORIAPACIENTE'
DECLARE @idParametro VARCHAR(MAX) = 'IDCATEGORIAPACIENTE'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Ventas: ID Categoría por defecto para identificar a los clientes que son "Pacientes"'
DECLARE @valorParametro VARCHAR(MAX) = NULL
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '2. Nuevo Parámetro: IDCATEGORIADOCTOR'
DECLARE @idParametro VARCHAR(MAX) = 'IDCATEGORIADOCTOR'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Ventas: ID Categoría por defecto para identificar a los clientes que son "Doctores"'
DECLARE @valorParametro VARCHAR(MAX) = NULL
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '3. Nuevo Parámetro: FACTURACIONMUESTRAHISTORIACLINICA'
DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONMUESTRAHISTORIACLINICA'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Ventas: Muestra o no los campos correspondientes en la solapa Adicionales de Facturación'
DECLARE @valorParametro VARCHAR(MAX) = 'False'
IF dbo.BaseConCuit('30698319263') = 1 -- En TRUE para STAR MEDICAL
    SET @valorParametro = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

PRINT ''
PRINT '4. Nuevo Ancho de la pantalla de AyudaProyectos'
UPDATE Buscadores       SET AnchoAyuda = 1000   WHERE Titulo = 'Proyectos'
PRINT ''
PRINT '4.1. Ajuste en el ancho de los campos Cliente y Nombre de Fantasía en la ayuda de Proyectos'
UPDATE BuscadoresCampos SET Ancho = 200         WHERE IdBuscadorNombreCampo = 'NombreCliente' AND IdBuscador = 12
UPDATE BuscadoresCampos SET Ancho = 200         WHERE IdBuscadorNombreCampo = 'NombreDeFantasia' AND IdBuscador = 12
UPDATE BuscadoresCampos SET Ancho = 80          WHERE IdBuscadorNombreCampo = 'NombreEstado' AND IdBuscador = 12
UPDATE BuscadoresCampos SET Ancho = 80          WHERE IdBuscadorNombreCampo = 'NombreClasificacion' AND IdBuscador = 12
GO

PRINT ''
PRINT '5. Nuevo Comando para la exportación automática de Ventas'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('CmdExportacionVentas', 'Exportación Automática de Ventas', 'Exportación Automática de Ventas', 'False', 'False', 'True', 'True'
    ,NULL, 1000, 'Eniac.Win', 'CmdExportacionVentas', NULL, 'CantidadMesesAExportar=6;Exportado=False;UbicacionDestino=C:\Eniac\Archivos\Ventas;'
    ,'True', 'S', 'N', 'N', 'N')

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CmdExportacionVentas' AS Pantalla FROM dbo.Roles
 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

PRINT ''
PRINT '6. Nuevo Comando para la exportación automática de Recibos'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('CmdExportacionRecibos', 'Exportación Automática de Recibos', 'Exportación Automática de Recibos', 'False', 'False', 'True', 'True'
    ,NULL, 1000, 'Eniac.Win', 'CmdExportacionRecibos', NULL, 'CantidadMesesAExportar=6;Exportado=False;UbicacionDestino=C:\Eniac\Archivos\Recibos;'
    ,'True', 'S', 'N', 'N', 'N')

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CmdExportacionRecibos' AS Pantalla FROM dbo.Roles
 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
