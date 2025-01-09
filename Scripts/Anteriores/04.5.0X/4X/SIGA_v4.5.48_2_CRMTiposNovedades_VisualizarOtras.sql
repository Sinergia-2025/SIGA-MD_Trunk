
ALTER TABLE CRMTiposNovedades ADD VisualizaOtrasNovedades bit NULL;
GO

UPDATE CRMTiposNovedades 
   SET VisualizaOtrasNovedades = (CASE WHEN IdTipoNovedad IN ('CRM','RECCLTE') THEN 'True' ELSE 'False' END);
GO

ALTER TABLE CRMTiposNovedades ALTER COLUMN VisualizaOtrasNovedades bit NOT NULL;
GO

--SELECT IdTipoNovedad, NombreTipoNovedad, VisualizaOtrasNovedades FROM CRMTiposNovedades
--GO
