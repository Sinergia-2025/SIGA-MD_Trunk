PRINT ''
PRINT 'A0 Tabla Ventas Formas de Pago: Nuevo Campo IdTipoComprobante'
BEGIN
    ALTER TABLE VentasFormasPago ADD IdTipoComprobantes VarChar(15) NULL
    ALTER TABLE VentasFormasPago ADD CONSTRAINT FK_VentasFormasPago_TipoComprobantes_1 FOREIGN KEY (IdTipoComprobantes) REFERENCES TiposComprobantes(IdTipoComprobante)
END



--INSERT INTO Funciones
--     (Id, Nombre, Descripcion, 
--      EsMenu, EsBoton, [Enabled], Visible, 
--      IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,Plus, Express, Basica, PV, EsMDIChild)
--  VALUES
--     ('InformeDeNovEstadosCRM', 'Informe de CRM Cambios de Estado', 'Informe de CRM Cambios de Estado', 
--      'True', 'False', 'True', 'True', 
--      'CRM', 207, 'Eniac.Win', 'InformeDeNovedadesEstado', NULL, 'CRM','S','N','N','N', 1)
--GO

--INSERT INTO RolesFunciones (IdRol, IdFuncion)
--SELECT DISTINCT Id AS Rol, 'InformeDeNovEstadosCRM' AS Pantalla FROM Roles
--    WHERE Id IN ('Adm', 'Supervidor', 'Oficina')
--GO

PRINT ''
PRINT 'A0 Tabla Bitacora: Actualiza el ID de Funcion.-'
BEGIN
    UPDATE Bitacora
        SET IdFuncion = 'InfMovimientosBancarios'
    WHERE idFuncion = 'Movimientos'
END

PRINT ''
PRINT 'B0 Tabla CRMNovedades: Actualiza el ID de Funcion.-'
BEGIN
    UPDATE CRMNovedades 
        SET IdFuncion = 'InfMovimientosBancarios'
    WHERE idFuncion = 'Movimientos'
END

PRINT ''
PRINT 'C0 Tabla Funciones: Borra el ID de Funcion.-'
BEGIN
    DELETE RolesFunciones 
    WHERE idFuncion = 'Movimientos' 
END

PRINT ''
PRINT 'D0 Tabla Funciones: Borra el ID de Funcion.-'
BEGIN
    DELETE Funciones 
    WHERE id = 'Movimientos' 
    AND idPadre = 'Bancos'
    AND Pantalla = 'Movimientos'
END


PRINT ''
PRINT 'A0. Alta Lista de Precio Arborea 01.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREALISTAPRECIOS01' AS IdParametro, 
                '0' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREALISTAPRECIOS01' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
----------------------------------------------------
PRINT ''
PRINT 'B0. Alta Lista de Precio Arborea 02.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREALISTAPRECIOS02' AS IdParametro, 
                '0' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREALISTAPRECIOS02' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
----------------------------------------------------
PRINT ''
PRINT 'C0. Alta Lista de Precio Arborea 03.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREALISTAPRECIOS03' AS IdParametro, 
                '0' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREALISTAPRECIOS03' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
----------------------------------------------------
PRINT ''
PRINT 'D0. Alta Lista de Precio Arborea 04.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREALISTAPRECIOS04' AS IdParametro, 
                '0' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREALISTAPRECIOS04' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
----------------------------------------------------
PRINT ''
PRINT 'E0. Alta de URL de Lista de Precio Arborea.-'
BEGIN
    MERGE INTO Parametros AS DEST
    USING (
            SELECT IdEmpresa, 
                'ARBOREAURLLISTAPRECIOS' AS IdParametro, 
                'http://www.petworld.com.ar/rest-siga-shop/index.php/api/sigashoppreciomayorista' ValorParametro, 
                'Arborea' CategoriaParametro, 
                'ARBOREAURLLISTAPRECIOS' DescripcionParametro FROM Empresas) AS ORIG 
            ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
        VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END



PRINT ''
PRINT 'A0 Tabla Ventas Formas de Pago: Nuevo Campo IdTipoComprobante'
BEGIN
    ALTER TABLE VentasFormasPago ADD IdTipoComprobantesFR VarChar(15) NULL
    ALTER TABLE VentasFormasPago ADD CONSTRAINT FK_VentasFormasPago_TipoComprobantes_FR FOREIGN KEY (IdTipoComprobantesFR) REFERENCES TiposComprobantes(IdTipoComprobante)
END