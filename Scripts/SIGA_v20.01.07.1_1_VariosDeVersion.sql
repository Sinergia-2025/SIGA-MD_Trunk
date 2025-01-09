PRINT ''
PRINT '1. Impresoras: Quitar el nombre del puerto "COM" si usa DLLv2'
UPDATE Impresoras
   SET Puerto = REPLACE(Puerto, 'COM', '')
 WHERE Metodo = 'DLLsV2'


PRINT ''
PRINT '2. Parametro: Pedidos/Presupuestos: Mostrar el combo de Criticidad'
DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSMOSTRARCRITICIDAD'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Pedidos/Presupuestos: Mostrar el combo de Criticidad'
DECLARE @valorParametro VARCHAR(MAX) = 'True'
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
PRINT '3. Parametro: Pedidos: Permitir modificar el Descuento Recargo General del producto'
DECLARE @idParametro VARCHAR(MAX) = 'PEDIDOSPERMITEMODIFICARDESCREC'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Pedidos: Permitir modificar el Descuento Recargo General del producto'
DECLARE @valorParametro VARCHAR(MAX) = (SELECT MAX(ValorParametro) FROM Parametros WHERE IdParametro = 'FacturacionModificaDescRecProducto')
--IF dbo.BaseConCuit('20170521014') = 1
--    SET @valor = 'True'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;


PRINT ''
PRINT '4. Nueva Función: Pedidos Permite Modificar Descuento/Recargo del Producto.'
IF dbo.ExisteFuncion('PedidosClientesV2') = 'True' 
BEGIN
    PRINT ''
    PRINT '4.1. Inserta Funcion: Pedidos Permite Modificar Descuento/Recargo del Producto'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('Pedidos-ModifDescRecProd', 'Pedidos: Modifica el Desc/Recargo del Producto', 'Pedidos: Modifica el Desc/Recargo del Producto', 'False', 'False', 'True', 'True'
        ,'PedidosClientesV2', 999, 'Eniac.Win', 'Pedidos-ModifDescRecProd', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N');
   
    PRINT ''
    PRINT '4.2. Permisos Funcion: Pedidos Permite Modificar Descuento/Recargo del Producto'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'Pedidos-ModifDescRecProd' FROM RolesFunciones WHERE IdFuncion = 'Facturacion-ModifDescRecProd'
END



