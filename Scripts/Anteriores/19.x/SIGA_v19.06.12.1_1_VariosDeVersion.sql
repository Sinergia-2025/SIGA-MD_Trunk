PRINT ''
PRINT '1. Corregir nombre de módulo Servicio Técnico'
UPDATE Funciones SET Nombre = 'Servicio Técnico' WHERE Id = 'CRMNovedadesABMSERVICE'
UPDATE CRMTiposNovedades SET NombreTipoNovedad = 'Servicio Técnico' WHERE IdTipoNovedad = 'SERVICE'

PRINT ''
PRINT '2. Table Numeradores - Creación'
CREATE TABLE [dbo].[Numeradores](
	[IdNumerador] [varchar](30) NOT NULL,
	[Numero] [bigint] NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Numeradores] PRIMARY KEY CLUSTERED 
([IdNumerador] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

PRINT ''
PRINT '3. Table CRMEstadosNovedades - Nuevos campos Imprime y Reporte'
ALTER TABLE CRMEstadosNovedades ADD Imprime bit null, Reporte	varchar(150) null
GO
PRINT ''
PRINT '3.1. Table CRMEstadosNovedades - Valor por defecto para Imprime'
UPDATE CRMEstadosNovedades SET Imprime = 'False'
PRINT ''
PRINT '3.2. Table CRMEstadosNovedades - NOT NULL para Imprime'
ALTER TABLE CRMEstadosNovedades ALTER COLUMN Imprime bit not null
GO


PRINT ''
PRINT '4. Nueva Función NumeradoresABM'
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('NumeradoresABM', 'ABM de Numeradores', 'ABM de Numeradores', 'True', 'False', 'True', 'True'
        ,'Configuraciones', 100, 'Eniac.Win', 'NumeradoresABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
PRINT ''
PRINT '4.1. Asignar Roles a la Función NumeradoresABM'
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'NumeradoresABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')

PRINT ''
PRINT '5. Tabla CuentasCorrientes: Nuevo Campo FechaTransferencia'
ALTER TABLE dbo.CuentasCorrientes ADD FechaTransferencia DateTime null;
PRINT ''
PRINT '6. Tabla Ventas: Nuevo Campo FechaTransferencia'
ALTER TABLE dbo.Ventas ADD FechaTransferencia DateTime null;
GO

PRINT ''
PRINT '7. Corregir DadoAltaPor para aplicaciones no LIVE'
DECLARE @idAplicacion VARCHAR(MAX) = (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'IDAPLICACION')
IF @idAplicacion <> 'SILIVE'
BEGIN
    PRINT '7.1. Soy ' + @idAplicacion + ': corrijo'
    UPDATE Clientes
       SET TipoDocDadoAltaPor = TipoDocVendedor
          ,NroDocDadoAltaPor = NroDocVendedor
END

PRINT ''
PRINT '8. Tabla Clientes: FK_Clientes_Empleados_DadoAltaPor'
ALTER TABLE dbo.Clientes ADD CONSTRAINT FK_Clientes_Empleados_DadoAltaPor
    FOREIGN KEY (TipoDocDadoAltaPor,NroDocDadoAltaPor)
    REFERENCES dbo.Empleados (TipoDocEmpleado,NroDocEmpleado)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 

PRINT ''
PRINT '9. Corregir PercepcionVentas de NC con BaseImponible positiva'
UPDATE PercepcionVentas
   SET BaseImponible = BaseImponible * -1
 WHERE ImporteTotal < 0 AND BaseImponible > 0


IF dbo.BaseConCuit('') = 'True'
BEGIN
    DECLARE @fechaDesde DATETIME = '19000601 00:00:00'
    DECLARE @fechaHasta DATETIME = '20190630 23:59:59'
    PRINT ''
    PRINT '10. NUTRISUR'
    PRINT ''
    PRINT '10.1. Correjo ComisionVendedorPorc que estan en 0 y deberian tener valor'
    UPDATE VP
       SET ComisionVendedorPorc = CASE WHEN ISNULL(ECP.Comision, 0) <> 0 THEN ECP.Comision ELSE
                                      CASE WHEN ISNULL(ECR.Comision, 0) <> 0 THEN ECR.Comision ELSE
                                           CASE WHEN R.ComisionPorVenta <> 0 THEN R.ComisionPorVenta ELSE
                                                CASE WHEN ISNULL(ECM.Comision, 0) <> 0 THEN ECM.Comision ELSE
                                                     CASE WHEN M.ComisionPorVenta <> 0 THEN M.ComisionPorVenta
                                                     ELSE E.ComisionPorVenta
                                                  END
                                               END
                                            END
                                         END
                                      END
      FROM Ventas V
     INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
     INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal 
                                  AND V.IdTipoComprobante=VP.IdTipoComprobante
                                  AND V.Letra=VP.Letra
                                  AND V.CentroEmisor=VP.CentroEmisor
                                  AND V.NumeroComprobante=VP.NumeroComprobante
       INNER JOIN Empleados E ON V.TipoDocVendedor = E.TipoDocEmpleado AND V.NroDocVendedor = E.NroDocEmpleado 
       INNER JOIN Productos P ON VP.IdProducto = P.IdProducto 
       INNER JOIN Marcas M ON P.IdMarca = M.IdMarca 
       INNER JOIN Rubros R ON P.IdRubro = R.IdRubro
       LEFT JOIN EmpleadosComisionesMarcas ECM ON ECM.IdMarca = M.IdMarca AND ECM.TipoDocEmpleado = E.TipoDocEmpleado AND ECM.NroDocEmpleado = E.NroDocEmpleado
       LEFT JOIN EmpleadosComisionesRubros ECR ON ECR.IdRubro = R.IdRubro AND ECR.TipoDocEmpleado = E.TipoDocEmpleado AND ECR.NroDocEmpleado = E.NroDocEmpleado
       LEFT JOIN EmpleadosComisionesProductos ECP ON ECP.IdProducto = P.IdProducto AND ECP.TipoDocEmpleado = E.TipoDocEmpleado AND ECP.NroDocEmpleado = E.NroDocEmpleado
     WHERE V.Fecha >= @fechaDesde   AND V.Fecha <= @fechaHasta
       AND TC.AfectaCaja = 'True'
       AND TC.EsComercial = 'True'
       AND VP.ComisionVendedorPorc = 0

    PRINT ''
    PRINT '10.2. Calculo las ComisionVendedor con los nuevos ComisionVendedorPorc'
    UPDATE VP
       SET ComisionVendedor = ROUND(VP.ImporteTotalNeto * ComisionVendedorPorc / 100, 2)
      FROM Ventas V
     INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
     INNER JOIN VentasProductos VP ON V.IdSucursal=VP.IdSucursal 
                                  AND V.IdTipoComprobante=VP.IdTipoComprobante
                                  AND V.Letra=VP.Letra
                                  AND V.CentroEmisor=VP.CentroEmisor
                                  AND V.NumeroComprobante=VP.NumeroComprobante
     WHERE V.Fecha >= @fechaDesde   AND V.Fecha <= @fechaHasta
       AND TC.AfectaCaja = 'True'
       AND TC.EsComercial = 'True'
       AND VP.ComisionVendedorPorc <> 0 AND VP.ComisionVendedor = 0

    PRINT ''
    PRINT '10.3. Recalculo ComisionVendedor de Ventas'
    UPDATE V
       SET ComisionVendedor = VP.ComisionVendedor
      FROM Ventas V
     INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante 
     INNER JOIN (SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, SUM(ComisionVendedor) ComisionVendedor FROM VentasProductos GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante) VP ON V.IdSucursal=VP.IdSucursal 
                                  AND V.IdTipoComprobante=VP.IdTipoComprobante
                                  AND V.Letra=VP.Letra
                                  AND V.CentroEmisor=VP.CentroEmisor
                                  AND V.NumeroComprobante=VP.NumeroComprobante
     WHERE V.Fecha >= @fechaDesde   AND V.Fecha <= @fechaHasta
       AND TC.AfectaCaja = 'True'
       AND TC.EsComercial = 'True'
       AND V.ComisionVendedor = 0 AND VP.ComisionVendedor <> 0
END
