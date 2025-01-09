DECLARE @um char(2) = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas WHERE IdUnidadDeMedida = 'UN')

IF @um IS NULL
    SET @um = (SELECT TOP 1 IdUnidadDeMedida FROM UnidadesDeMedidas)

PRINT @um

PRINT ''
PRINT '1. Tabla Productos: Actualización de registros pre-existentes'
UPDATE P SET P.IdUnidadDeMedida = @um, P.Tamano = 1 FROM Productos P WHERE P.IdUnidadDeMedida IS NULL
UPDATE P SET P.Conversion = 1 FROM Productos P WHERE P.Conversion = 0
GO

PRINT ''
PRINT '2. Tabla Ventas: Actualización de registros inconsistentes entre SubTotal y ValorDeclarado'
UPDATE V SET V.SubTotal = V.ValorDeclarado FROM Ventas V WHERE IdTipoComprobante = 'REMITOTRANSP' AND V.SubTotal = 0
GO


PRINT ''
PRINT '3. Tabla CRMTiposNovedades: Nuevo Campo CantidadCopias'
ALTER TABLE CRMTiposNovedades ADD CantidadCopias INT NULL
GO
PRINT ''
PRINT '3.1. Tabla CRMTiposNovedades: Actualización de registros pre-existentes'
UPDATE CTN SET CTN.CantidadCopias = 1 FROM CRMTiposNovedades CTN
PRINT ''
PRINT '3.2. Tabla CRMTiposNovedades: Cambio el campo a NOT NULL'
ALTER TABLE CRMTiposNovedades ALTER COLUMN CantidadCopias INT NOT NULL
GO

PRINT ''
PRINT '4. Tabla CRMEstadosNovedades: Nuevo Campo CantidadCopias '
ALTER TABLE CRMEstadosNovedades ADD CantidadCopias INT NULL
GO
PRINT ''
PRINT '4.1. Tabla CRMEstadosNovedades: Actualización de registros pre-existentes'
UPDATE CEN SET CEN.CantidadCopias = 1 FROM CRMEstadosNovedades CEN
PRINT ''
PRINT '4.2. Tabla CRMEstadosNovedades: Cambio el campo a NOT NULL'
ALTER TABLE CRMEstadosNovedades ALTER COLUMN CantidadCopias INT NOT NULL
GO


PRINT ''
PRINT '5. Nuevo Comando para la subida automática de Ventas'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('CmdSubidaVentasPDF', 'Subida Automática de Ventas PDF', 'Subida Automática de Ventas PDF', 'False', 'False', 'True', 'True'
    ,NULL, 1100, 'Eniac.Win', 'CmdSubidaVentasPDF', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CmdSubidaVentasPDF' AS Pantalla FROM dbo.Roles
 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO

PRINT ''
PRINT '6. Nuevo Comando para la subida automática de Recibos'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('CmdSubidaRecibosPDF', 'Subida Automática de Recibos PDF', 'Subida Automática de Recibos PDF', 'False', 'False', 'True', 'True'
    ,NULL, 1100, 'Eniac.Win', 'CmdSubidaRecibosPDF', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CmdSubidaRecibosPDF' AS Pantalla FROM dbo.Roles
 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO


PRINT ''
PRINT '7. Tabla VentasProductosLotes: Actualización de registros inconsistentes'
UPDATE VPL SET VPL.Cantidad = VPL.Cantidad * -1
FROM VentasProductosLotes VPL 
INNER JOIN VentasProductos VP ON VPL.IdSucursal = VP.IdSucursal
							   AND VPL.IdTipoComprobante = VP.IdTipoComprobante
							   AND VPL.Letra = VP.Letra
							   AND VPL.CentroEmisor = VP.CentroEmisor
							   AND VPL.NumeroComprobante = VP.NumeroComprobante
							   AND VPL.IdProducto = VP.IdProducto
							   AND VPL.Orden = VP.Orden
WHERE SIGN(VPL.Cantidad) <> SIGN(VP.Cantidad)
GO
