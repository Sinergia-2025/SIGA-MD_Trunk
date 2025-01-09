

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))
BEGIN
UPDATE Parametros set ValorParametro = 'True' where IdParametro like 'FTPSUBEINFOALSERVIDOR2'
UPDATE Parametros set ValorParametro = 'RimpoD255454F' where IdParametro like 'FTPPASSWORD2'
UPDATE Parametros set ValorParametro = 'w1021701.ferozo.com' where IdParametro like 'FTPSERVIDOR2'
UPDATE Parametros set ValorParametro = 'turcoftp@w1021701.ferozo.com' where IdParametro like 'FTPUSUARIO2'
UPDATE Parametros set ValorParametro = '/actualizador/Aplicaciones/' where IdParametro like 'FTPCARPETAREMOTA2'
END
