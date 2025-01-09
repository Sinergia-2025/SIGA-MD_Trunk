
Print ''
Print '1. Se coloco Genericanmente "Numero" en las Fuentes.'

DELETE Traducciones WHERE Control = 'chbIdPedido'
;


Print ''
Print '2. Ajusto la descripion del Item Presupuesto de Ventas.'
Print '   Vuelvo al Original si no usa el Modulo de Presupuestos'
 
-- Solo lo cambio si NO utiliza el Modulo de Presupuestos a Clientes
IF NOT EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Presupuestos')

BEGIN

	UPDATE TiposComprobantes
	   SET Descripcion = 'Presupuesto'
		 , DescripcionAbrev = 'Presup.'
	 WHERE IdTipoComprobante = 'PRESUP'
	;

END;



Print ''
Print '3. Activo Seteo de mostrar la URL solo para Metalurgica Almafuerte / CEAR.'


DECLARE @valorParametro varchar(MAX)
SET @valorParametro = 'False'


IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                                                     AND P.ValorParametro IN ('20231852698','30715213091'))	
BEGIN
    SET @valorParametro = 'True'
END

MERGE INTO Parametros AS P
     USING (SELECT 'PEDIDOSMOSTRARURLPLANODETALLE' AS IdParametro, @valorParametro ValorParametro ,'Mostrar URL Plano Detalle' AS DescripcionParametro) AS PT
        ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN
    UPDATE SET P.ValorParametro = PT.ValorParametro
 WHEN NOT MATCHED THEN
    INSERT (   IdParametro,    ValorParametro, CategoriaParametro,    DescripcionParametro)
    VALUES (PT.IdParametro, PT.ValorParametro, NULL              , PT.DescripcionParametro);

--SELECT *
--  FROM Parametros
-- WHERE IdParametro IN ('PEDIDOSMOSTRARURLPLANODETALLE')
--;
