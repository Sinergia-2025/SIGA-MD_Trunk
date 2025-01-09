--SELECT MRPP.CantidadSolicitada, OPP.Cantidad, MRPP.CantidadUnitaria, MRPP.*
UPDATE MRPP
   SET CantidadUnitaria = MRPP.CantidadSolicitada / OPP.Cantidad
  FROM OrdenesProduccionMRPProductos MRPP
 INNER JOIN OrdenesProduccionProductos OPP
    ON OPP.IdSucursal = MRPP.IdSucursal
   AND OPP.IdTipoComprobante = MRPP.IdTipoComprobante
   AND OPP.Letra = MRPP.LetraComprobante
   AND OPP.CentroEmisor = MRPP.CentroEmisor
   AND OPP.NumeroOrdenProduccion = MRPP.NumeroOrdenProduccion
   AND OPP.IdProducto = MRPP.IdProducto
   AND OPP.Orden = MRPP.Orden
 WHERE MRPP.CantidadUnitaria = 0
   AND MRPP.CantidadSolicitada <> 0
--   AND OPP.Cantidad = 1

PRINT ''
PRINT 'F1. Nuevo Menu Procesos Productivos: MRP - Impresion Masiva Hoja de Ruta'
IF dbo.ExisteFuncion('MRP') = 1 AND dbo.ExisteFuncion('MRPImpresionMasivaHojaRuta') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('MRPImpresionMasivaHojaRuta', 'Impresion Masiva de Hojas de Ruta', 'Impresión Masiva de Hojas de Ruta', 'True', 'False', 'True', 'True'
        , 'MRP', 1000, 'Eniac.Win', 'MRPImpresionMasivaHojasRuta', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'MRPImpresionMasivaHojaRuta' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO
