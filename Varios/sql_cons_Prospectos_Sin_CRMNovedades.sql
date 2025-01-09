SELECT CodigoProspecto, NombreProspecto, NombreDeFantasia
  FROM Prospectos 
WHERE NOT EXISTS 
     (SELECT * FROM CRMNovedades CRMNov
	    WHERE CRMNov.IdTipoNovedad = 'PROSP'
          AND CRMNov.IdProspecto = Prospectos.IdProspecto)

