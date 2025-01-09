PRINT '';
PRINT '1. Tabla Campos: Inserto el Campo DescuentoRecargoPorc1, DescuentoRecargoPorc2, DescuentoRecargoPorc3 y DescuentoRecargoPorc4';
INSERT INTO Campos (IdCampo,NombreCampo,Orden)
     VALUES (14, 'DescuentoRecargoPorc1', 14),
            (15, 'DescuentoRecargoPorc2', 15),
            (16, 'DescuentoRecargoPorc3', 16),
            (17, 'DescuentoRecargoPorc3', 17)

PRINT '';
PRINT '2. Tabla PlantillasCampos: Genero un registro en cada planilla (sin orden)';
INSERT INTO PlantillasCampos (IdPlantilla ,IdCampo, OrdenColumna)
SELECT DISTINCT PC.IdPlantilla, C.IdCampo, NULL
  FROM PlantillasCampos PC
 CROSS JOIN (SELECT * FROM Campos WHERE IdCampo IN (14, 15, 16, 17)) C

PRINT '';
PRINT '3. Nueva función de menu: Informe Ordenes de Producción Detallado';
-- SI Tiene la pantalla ConsultarOrdenesProduccion Significa que tiene el modulo avanzado.
IF dbo.ExisteFuncion('Produccion') = 1 AND dbo.ExisteFuncion('ConsultarOrdenesProduccion') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfProduccionDetallado', 'Inf. Ordenes de Producción Detallado', 'Inf. Ordenes de Producción Detallado', 'True', 'False', 'True', 'True'
        ,'Produccion', 25, 'Eniac.Win', 'InfProduccionDetallado', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'InfProduccionDetallado' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT '';
PRINT '4. Nuevo campo PermiteCobroParcial en tabla MovilRutas';
ALTER TABLE dbo.MovilRutas ADD PermiteCobroParcial bit NULL
GO
UPDATE MovilRutas SET PermiteCobroParcial = 1;
ALTER TABLE dbo.MovilRutas ALTER COLUMN PermiteCobroParcial bit NOT NULL
GO

IF dbo.BaseConCuit('20250887265') = 1
BEGIN
    PRINT '';
    PRINT '5. Ajuste de PrecioCosto a productos no sincronizados';
    UPDATE PS2
       SET PrecioCosto = PS1.PrecioCosto
          ,PrecioFabrica = PS1.PrecioFabrica
          ,FechaActualizacion = PS1.FechaActualizacion
      FROM ProductosSucursales PS1
     INNER JOIN ProductosSucursales PS2 ON PS2.IdProducto = PS1.IdProducto AND PS2.IdSucursal = 2
     WHERE PS1.IdSucursal = 1
END
