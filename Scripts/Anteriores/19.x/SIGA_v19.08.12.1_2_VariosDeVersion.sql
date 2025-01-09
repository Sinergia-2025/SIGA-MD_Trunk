--Quito espacio adelante para que no este entre las primeras. Que el cliente lo decida.
UPDATE TiposComprobantes
  SET Descripcion = LTRIM(Descripcion)
WHERE IdTipoComprobante IN ('ePRE-FCE','ePRE-NDCE','ePRE-NDCECHEQR','ePRE-NCCE','eFCE','eNDCE','eNDCECHEQRECH','eNCCE')
GO
