PRINT ''
PRINT '1. Pantalla nueva Libro de IVA Dinamico Ventas'

DECLARE @posicion int = (SELECT Posicion FROM Funciones WHERE Id = 'LibrodeIvaVentas')
IF @posicion IS NOT NULL
--Inserto la Pantalla Nueva
BEGIN
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 VALUES
	   ('LibrodeIvaVentasV2', 'Libro de IVA Ventas Dinámico', 'Libro de IVA Ventas Dinámico', 
		'True', 'False', 'True', 'True', 'VentasFiscal',@posicion + 5, 'Eniac.Win', 'LibrodeIvaVentasV2', null, null,'N','S','N','N')

	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT IdRol, 'LibrodeIvaVentasV2' FROM RolesFunciones
	 WHERE IdFuncion = 'LibrodeIvaVentas'
END;

PRINT ''
PRINT '2. Parametro Nuevo Controlar Limite de Credito'

MERGE INTO Parametros AS P
        USING (SELECT 'CONTROLAEVENTOSDELIMITEDECREDITODECLIENTES' AS IdParametro, 
			          CASE WHEN ValorParametro = 'False' THEN 'Avisar y Permitir' ELSE 'No Permitir' END ValorParametro, 'Permite Controlar Los Eventos de Limite de Credito' AS DescripcionParametro
			     FROM Parametros WHERE IdParametro = 'CONTROLAlIMITEDECREDITODECLIENTES') AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;

PRINT ''
PRINT '3. Parametro Nuevo CAJEROABRIRVARIASVENTANASDEFACTURACION'

DECLARE @ValorParametro varchar(max) = 'False'
--SOLO PARA EMPORIO DE LA FERRETERIA
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
													 AND P.ValorParametro IN ('20182151204'))
BEGIN
    SET @ValorParametro = 'True'
END

MERGE INTO Parametros AS P
		USING (SELECT 'CAJEROABRIRVARIASVENTANASDEFACTURACION' AS IdParametro, @ValorParametro ValorParametro, 'Cajero Permitir Abrir Varias Ventanas de Facturacion'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
	WHEN MATCHED THEN
		UPDATE SET P.ValorParametro = PT.ValorParametro
	WHEN NOT MATCHED THEN 
		INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;


PRINT ''
PRINT '4. Parametro Nuevo PROCESOSCORREOPRUEBAPARA'

MERGE INTO Parametros AS P
        USING (SELECT 'PROCESOSCORREOPRUEBAPARA' IdParametro, ValorParametro, 'Correo Electrónico para correos de prueba' AS DescripcionParametro, CategoriaParametro FROM Parametros WHERE IdParametro = 'FACTURACIONENVIOMAILCOPIAOCULTA') AS PT 
           ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;
