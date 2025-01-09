
DECLARE @RETIENEIIBB bit;
SET @RETIENEIIBB = (SELECT CASE WHEN ValorParametro = 'True' THEN 1 ELSE 0 END FROM Parametros WHERE IdParametro = 'RETIENEIIBB');

DECLARE @idActividad int;
SET @idActividad = 99999;  --Usamos la actividad 99999 para EXCENTO para no tener problemas con las ya cargadas.

IF @RETIENEIIBB = 1
BEGIN

PRINT '1. Agrego la Actividad EXENTO'

    INSERT INTO Actividades
               (IdProvincia,IdActividad,NombreActividad,Porcentaje,BaseImponible)
         SELECT TOP 1 IdProvincia,@idActividad,'EXENTO',0,0
           FROM Actividades WHERE IdProvincia = 'SF';

PRINT '2. Copio todas las Actividades a EmpresasActividades definiendolas como NO Principales'
    INSERT INTO EmpresaActividades
           (IdProvincia,IdActividad,Principal)
    SELECT IdProvincia,IdActividad, 0 FROM Actividades;

    --DELETE ClientesActividades
    --  FROM ClientesActividades AS CA
    -- WHERE CA.IdActividad NOT IN (SELECT TOP 1 IdActividad
    --                                FROM ClientesActividades CA2
    --                               WHERE CA2.IdCliente = CA.IdCliente);

PRINT '3. A la primera EmpresaActividades de cada provincia le pongo que es Principal (excepto EXENTO en StaFe)'
    UPDATE EmpresaActividades
       SET Principal = 1
      FROM EmpresaActividades EA
     INNER JOIN (SELECT IdProvincia, MIN(IdActividad) IdActividad
                   FROM EmpresaActividades
                  WHERE IdActividad <> @idActividad OR IdProvincia <> 'SF'
                  GROUP BY IdProvincia) AS EAG ON EAG.IdActividad = EA.IdActividad
                                              AND EAG.IdProvincia = EA.IdProvincia;
PRINT '4. A todos los clientes que tienen InscriptoIBStaFe = 0, su categoría EsPasiblePercIIBB y no tienen Actividades asociadas, le agrego la actividad EXCENTO de StaFe (si aplica)'
    INSERT INTO ClientesActividades
               (IdProvincia,IdActividad,IdCliente)
        SELECT A.IdProvincia, A.IdActividad, C.IdCliente
          FROM Clientes C
         INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
         INNER JOIN Actividades A ON A.IdProvincia = 'SF' AND A.IdActividad = @idActividad
          LEFT JOIN ClientesActividades CA ON CA.IdCliente = C.IdCliente
         WHERE CF.EsPasiblePercIIBB = 1
           AND C.InscriptoIBStaFe = 0
           AND CA.IdActividad IS NULL;

PRINT '5. A todos los clientes tienen InscriptoIBStaFe = 0 y su categoría EsPasiblePercIIBB los tildo como InscriptoIBStaFe = 1'
    UPDATE Clientes
       SET InscriptoIBStaFe = 1
       FROM Clientes C
     INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal
     INNER JOIN Actividades A ON A.IdProvincia = 'SF' AND A.IdActividad = @idActividad
      LEFT JOIN ClientesActividades CA ON CA.IdCliente = C.IdCliente
     WHERE CF.EsPasiblePercIIBB = 1
       AND C.InscriptoIBStaFe = 0;

END
