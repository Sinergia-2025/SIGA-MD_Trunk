

DECLARE @blnEmitioComprobFiscal bit;
----------------------------

PRINT '1. Miro el Historial de Ventas en Busqueda de Comprobantes Fiscales'

SET @blnEmitioComprobFiscal = (SELECT CASE WHEN COUNT(*)>0 THEN 'True' ELSE 'False' END FROM Ventas
 WHERE EXISTS 
     ( SELECT * FROM TiposComprobantes TC
        WHERE TC.IdTipoComprobante = Ventas.IdTipoComprobante
          AND TC.EsFiscal = 'True'
     )
);


-- En Caso de No haber Emitido Fiscales lo quito.
IF @blnEmitioComprobFiscal = 'False'
BEGIN
	PRINT '2. Ajusto Pantallas Fiscales'

	UPDATE Funciones
	   SET EsMenu = 'False'
	     , [Enabled] = 'False'
	     , Visible = 'False'
	 WHERE Id IN ('FacturacionRapida','CierreX', 'CierreZ', 'CierreZReimprimir');


	PRINT '3. Quito Pantallas Fiscales'

	DELETE RolesFunciones
	 WHERE IdFuncion IN ('FacturacionRapida','CierreX', 'CierreZ', 'CierreZReimprimir');

END


SELECT Id, EsMenu, [Enabled], Visible FROM Funciones
 WHERE Id IN ('FacturacionRapida', 'CierreX', 'CierreZ', 'CierreZReimprimir');


