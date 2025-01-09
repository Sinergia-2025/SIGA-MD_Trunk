UPDATE TiposMovimientos SET
    MuestraCombo = 'False'
 WHERE ComprobantesAsociados IS NOT NULL
GO
