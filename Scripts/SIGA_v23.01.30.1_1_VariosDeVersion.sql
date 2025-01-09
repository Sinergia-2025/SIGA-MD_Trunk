DECLARE @idParametro VARCHAR(MAX) = 'FACTURACIONCONTROLATOPECF'
DECLARE @descripcionParametro VARCHAR(MAX) = 'Tope Consumidor Final'
DECLARE @valorParametro_NuevoTope DECIMAL(12) = '30767'

UPDATE Parametros
   SET ValorParametro = CASE WHEN ValorParametro < @valorParametro_NuevoTope THEN @valorParametro_NuevoTope ELSE ValorParametro END
 WHERE IdParametro = @idParametro


 DECLARE @PalabraMala VARCHAR(MAX) = 'ci?n'
DECLARE @PalabraCorregida VARCHAR(MAX) = 'cion'

PRINT '1. Quito ? de ci?n (ej:Producci?n).'
UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;

-----------------------------------------
PRINT ''
PRINT '2. Quito ? de C?digo.'

SET @PalabraMala = 'C?digo'
SET @PalabraCorregida = 'Codigo'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;

-----------------------------------------
PRINT ''
PRINT '3. Quito ? de Categor?a.'

SET @PalabraMala = 'Categor?a'
SET @PalabraCorregida = 'Categoria'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;


-----------------------------------------
PRINT ''
PRINT '4. Quito ? de Antig?edad.'

SET @PalabraMala = 'Antig?edad'
SET @PalabraCorregida = 'Antigüedad'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;

-----------------------------------------
PRINT ''
PRINT '5. Quito ? de F?rmula.'

SET @PalabraMala = 'F?rmula'
SET @PalabraCorregida = 'Formula'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;


 -----------------------------------------
PRINT ''
PRINT '6. Quito ? de C?lculo.'

SET @PalabraMala = 'C?lculo'
SET @PalabraCorregida = 'Calculo'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;


-----------------------------------------
PRINT ''
PRINT '7. Quito ? de ti?n (ej: Gesti?n).'

SET @PalabraMala = 'ti?n'
SET @PalabraCorregida = 'tion'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;


-----------------------------------------
PRINT ''
PRINT '8. Quito ? de p?si (ej: Dep?sitos).'

SET @PalabraMala = 'p?si'
SET @PalabraCorregida = 'posi'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;


-----------------------------------------
PRINT ''
PRINT '9. Quito ? de tor?a (ej: Auditor?a).'

SET @PalabraMala = 'tor?a'
SET @PalabraCorregida = 'toria'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;


-----------------------------------------
PRINT ''
PRINT '10. Quito ? de Par?metro.'

SET @PalabraMala = 'Par?metro'
SET @PalabraCorregida = 'Parametro'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;


-----------------------------------------
PRINT ''
PRINT '11. Quito ? de Geogr?fica.'

SET @PalabraMala = 'Geogr?fica'
SET @PalabraCorregida = 'Geografica'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;


-----------------------------------------
PRINT ''
PRINT '12. Quito ? de si?n (ej: Impresi?n).'

SET @PalabraMala = 'si?n'
SET @PalabraCorregida = 'sion'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;

-----------------------------------------
PRINT ''
PRINT '13. Quito ? de a?o.'

SET @PalabraMala = 'a?o'
SET @PalabraCorregida = 'año'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;

-----------------------------------------
PRINT ''
PRINT '14. Quito ? de R?pida.'

SET @PalabraMala = 'R?pida'
SET @PalabraCorregida = 'Rapida'

UPDATE Funciones
   SET Nombre = REPLACE(Nombre, @PalabraMala, @PalabraCorregida)
 WHERE Nombre LIKE '%' + @PalabraMala + '%'
;

UPDATE Funciones
   SET Descripcion = REPLACE(Descripcion, @PalabraMala, @PalabraCorregida)
 WHERE Descripcion LIKE '%' + @PalabraMala + '%'
;

IF NOT EXISTS(SELECT * FROM [AuditoriaMonedas])
BEGIN
    INSERT INTO [dbo].[AuditoriaMonedas] (
          [FechaAuditoria], [OperacionAuditoria], [UsuarioAuditoria]
        , [IdMoneda], [NombreMoneda], [IdTipoMoneda], [OperadorConversion]
        , [FactorConversion], [IdBanco], [Simbolo])
    SELECT GETDATE(), 'A', 'admin'
         , [IdMoneda], [NombreMoneda], [IdTipoMoneda], [OperadorConversion]
         , [FactorConversion], [IdBanco], [Simbolo]
      FROM Monedas
END

PRINT ''
PRINT '1. Nueva Función: Informe de Comisiones por Cobranzas Realizadas.'
IF dbo.ExisteFuncion('Caja') = 'True' AND dbo.ExisteFuncion('InfComisionesCobranzasRealiz') = 'False'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('InfComisionesCobranzasRealiz', 'Informe de Comisiones por Cobranzas Realizadas', 'Informe de Comisiones por Cobranzas Realizadas', 'True', 'False', 'True', 'True'
        ,'Caja', 131, 'Eniac.Win', 'InfComisionesCobranzasRealizadas', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'InfComisionesCobranzasRealiz' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

PRINT ''
PRINT '2. Nuevo parámetro: Cantidad de dias de Control de Licencias.'
BEGIN
	MERGE INTO Parametros AS DEST
	USING (
			SELECT IdEmpresa, 
				'ARBOREAPRECIOPRODUCTO' AS IdParametro, 
				'DELPRODUCTO' ValorParametro, 
				'Arborea' CategoriaParametro, 
				'Precio del Producto en Moneda' DescripcionParametro FROM Empresas) AS ORIG 
			ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
	WHEN MATCHED THEN
		UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
	WHEN NOT MATCHED THEN 
		INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
		VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);
END
GO