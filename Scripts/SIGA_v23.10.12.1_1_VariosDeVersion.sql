IF dbo.ExisteCampo('Impresoras', 'UtilizaBonosFiscalesElectronicos') = 0
BEGIN
    ALTER TABLE dbo.Impresoras ADD UtilizaBonosFiscalesElectronicos bit NULL
END
GO

UPDATE I
   SET UtilizaBonosFiscalesElectronicos = CASE WHEN P.ValorParametro = 'True' THEN 1 ELSE 0 END
  FROM Impresoras I
 INNER JOIN Sucursales S ON S.IdSucursal = I.IdSucursal
 INNER JOIN Parametros P ON P.IdEmpresa = S.IdEmpresa AND P.IdParametro = 'UTILIZABONOSFISCALESELECTRONICOS'
 WHERE I.UtilizaBonosFiscalesElectronicos IS NULL
GO

ALTER TABLE dbo.Impresoras ALTER COLUMN UtilizaBonosFiscalesElectronicos bit NOT NULL
GO

