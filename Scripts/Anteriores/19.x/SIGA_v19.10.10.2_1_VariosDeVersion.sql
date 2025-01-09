PRINT '1. Distribuidora ByM: Renombrar Repórte Presupuesto_STR_MitadHoja.rdlc a 324_Presupuesto_MitadHoja.rdlc'
IF dbo.BaseConCuit('20245741643') = 1
BEGIN
	EXECUTE [dbo].[RenombrarReporte] 'Presupuesto_STR_MitadHoja.rdlc', '324_Presupuesto_MitadHoja.rdlc', '0'
END
