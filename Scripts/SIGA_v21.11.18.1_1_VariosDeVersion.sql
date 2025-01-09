PRINT ''
PRINT '1. Nuevo menú: CMD Sincronización Paneles Sincronizar'
IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '1.1. Nueva función menú CMD Sincronización Paneles Sincronizar'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('CmdSincroPanelesSincronizar', 'CMD Sincronización Paneles Sincronizar', 'CMD Sincronización Paneles Sincronizar', 'False', 'False', 'True', 'True'
        ,NULL, 1000, 'Eniac.Win', 'CmdSincroPanelesSincronizar', NULL, 'ReEnviar=False;EnviarWebPC=True;ExportarPC=True;EnviarWebFS=True;ExportarFS=True;'
        ,'True', 'S', 'N', 'N', 'N', 'True')

    PRINT ''
    PRINT '1.2. Roles menú CMD Sincronización Paneles Sincronizar'
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'CmdSincroPanelesSincronizar' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm')
END;

PRINT ''
PRINT '2. Buscadores: Ajustar etiqueta de teléfono del proveedor'
UPDATE BC
   SET Titulo = 'Teléfono'
  FROM BuscadoresCampos BC
 INNER JOIN Buscadores B ON B.IdBuscador = BC.IdBuscador
 WHERE B.Titulo = 'Proveedores'
   AND BC.IdBuscadorNombreCampo = 'TelefonoProveedor'


PRINT ''
PRINT '3. Cantidad de Dias DH Recibos.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'CTACTECANTDIASDHRECIBOS' AS IdParametro, 
                '180' ValorParametro, 
                'CantidadDiasDH' CategoriaParametro, 
                'CTACTECANTDIASDHRECIBOS' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
