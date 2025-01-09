
IF dbo.BaseConCuit('30716887401') = 0
BEGIN
IF dbo.ExisteFuncion('SincronizarPanelDeControl') = 0 
    -- Elimina Parametros de Arborea.- --
    PRINT ''
    PRINT '1.1. Elimina los parametros Arborea.-'
    DELETE FROM Parametros WHERE IdParametro like '%ARBOREA%'
END
