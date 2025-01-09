	
IF EXISTS (SELECT PS.IdProducto, PS.IdSucursal, PS.PrecioVenta, PSP.PrecioVenta AS PrecioVenta2, PS.FechaActualizacion, PSP.FechaActualizacion AS FechaActualizacion2
                 FROM ProductosSucursales PS, ProductosSucursalesPrecios PSP 
                WHERE PS.Idproducto = PSP.IdProducto 
                  AND PS.IdSucursal = PSP.IdSucursal 
                  AND PSP.IdListaPrecios = 0
                  AND (PS.PrecioVenta <> PSP.PrecioVenta OR CONVERT(date, PS.FechaActualizacion, 120) <> CONVERT(date, PSP.FechaActualizacion, 120))
                )
    BEGIN
    
    DELETE ProductosSucursalesPrecios WHERE IdListaPrecios = 0

	INSERT INTO ProductosSucursalesPrecios 
			 (IdProducto, IdSucursal, IdListaPrecios, PrecioVenta, FechaActualizacion, Usuario)
	SELECT PS.IdProducto 
		  ,PS.IdSucursal
		  ,0 AS xIdListaPrecios
		  ,PS.PrecioVenta
		  ,PS.FechaActualizacion
		  ,PS.Usuario 
	  FROM ProductosSucursales PS

    END
GO

