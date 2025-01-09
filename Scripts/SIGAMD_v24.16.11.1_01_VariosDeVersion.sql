IF dbo.ExisteFuncion('RequerimientosCompras') = 1 AND dbo.ExisteFuncion('AnularRequerimientosCompras') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('AnularRequerimientosCompras', 'Anular Requerimiento de Compra', 'Anular Requerimiento de Compra', 'True', 'False', 'True', 'True'
        ,'RequerimientosCompras', 210, 'Eniac.Win', 'AnularRequerimientosCompras', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'AnularRequerimientosCompras' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor')
END

PRINT ''
PRINT '1. Crea Clave Foranea MRP Proceso Productivo.'
IF dbo.ExisteFK('FK_ProcesoProductivoOperaciones') = 0
BEGIN
    ALTER TABLE MRPProcesosProductivosOperaciones
		ADD CONSTRAINT FK_ProcesoProductivoOperaciones
        FOREIGN KEY (IdProcesoProductivo)
        REFERENCES MRPProcesosProductivos(IdProcesoProductivo)
END
GO

PRINT ''
PRINT '2. Crea Clave Foranea Novedades Produccion.'
IF dbo.ExisteFK('FK_NovedadesProduccionProductos') = 0
BEGIN
    ALTER TABLE NovedadesProduccionMRPProductos
		ADD CONSTRAINT FK_NovedadesProduccionProductos
        FOREIGN KEY (NumeroNovedadesProducccion, CodigoOperacion)
        REFERENCES NovedadesProduccionMRP(NumeroNovedadesProducccion, CodigoOperacion)
END
GO

PRINT ''
PRINT '3. Crea Campo EsNecesario Novedades Produccion Productos Lotes.'
IF dbo.ExisteCampo('NovedadesProduccionMRPProductosLotes','EsProductoNecesario') = 0
BEGIN
	ALTER TABLE NovedadesProduccionMRPProductosLotes ADD EsProductoNecesario bit NULL
END
GO

PRINT ''
PRINT '4. Carga Campo EsNecesario Novedades Produccion Productos Lotes.'
BEGIN
	UPDATE PPL
		SET PPL.EsProductoNecesario = PP.EsProductoNecesario
	FROM NovedadesProduccionMRPProductosLotes as PPL
		INNER JOIN NovedadesProduccionMRPProductos AS PP
			ON 
				PPL.NumeroNovedadesProducccion = PP.NumeroNovedadesProducccion
			AND PPL.CodigoOperacion = PP.CodigoOperacion
			AND PPL.IdProducto = PP.IdProducto
	WHERE PPL.EsProductoNecesario IS NULL
END
GO

PRINT ''
PRINT '5. Carga Campo EsNecesario Novedades Produccion Productos Lotes.'
BEGIN
	ALTER TABLE NovedadesProduccionMRPProductosLotes ALTER COLUMN  EsProductoNecesario bit NOT NULL
END
GO

PRINT ''
PRINT '6. Elimina Clave Primaria Novedades Produccion Productos Lotes.'
IF dbo.ExistePK('PK_NovedadesProduccionMRPProductosLotes') = 1
BEGIN
	ALTER TABLE NovedadesProduccionMRPProductosLotes DROP CONSTRAINT PK_NovedadesProduccionMRPProductosLotes
END
GO

PRINT ''
PRINT '7. Modifica Clave Primaria Novedades Produccion Productos Lotes.'
BEGIN
	ALTER TABLE NovedadesProduccionMRPProductosLotes
		ADD CONSTRAINT PK_NovedadesProduccionMRPProductosLotes PRIMARY KEY CLUSTERED (NumeroNovedadesProducccion, CodigoOperacion, IdProducto, IdLote, EsProductoNecesario)
END
GO

PRINT ''
PRINT '8. Crea Clave Foranea Novedades Produccion.'
IF dbo.ExisteFK('FK_NovedadesProduccionProductosLotes') = 0
BEGIN
    ALTER TABLE NovedadesProduccionMRPProductosLotes
		ADD CONSTRAINT FK_NovedadesProduccionProductosLotes
        FOREIGN KEY (NumeroNovedadesProducccion, CodigoOperacion, IdProducto, EsProductoNecesario)
        REFERENCES NovedadesProduccionMRPProductos(NumeroNovedadesProducccion, CodigoOperacion, IdProducto, EsProductoNecesario)
END
GO