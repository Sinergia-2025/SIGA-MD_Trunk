
-- Setear los Impuestos para los Ingresos Brutos de las Actividades que tiene asociada la Empresa
-- Solo en caso de ser Agente de Retencion/Percepcion

INSERT INTO Impuestos 
  (IdTipoImpuesto, Alicuota, Activo)
SELECT 'PIIBB', P.Porcentaje, 1 FROM 
 (SELECT Ac.Porcentaje FROM actividades Ac 
   WHERE Ac.Porcentaje <> 0
    AND (SELECT COUNT(*) FROM Impuestos WHERE IdTipoImpuesto = 'PIIBB' AND Ac.Porcentaje = Alicuota) = 0) as P
GO
