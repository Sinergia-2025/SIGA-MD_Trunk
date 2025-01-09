PRINT ''
PRINT '1. Normalización de Horas NULL'
UPDATE C SET C.HoraInicio = '0000' FROM Clientes C WHERE C.HoraInicio IS NULL 
UPDATE C SET C.HoraInicio2 = '0000' FROM Clientes C WHERE C.HoraInicio2 IS NULL 
UPDATE C SET C.HoraFin = '0000' FROM Clientes C WHERE C.HoraFin IS NULL 
UPDATE C SET C.HoraFin2 = '0000' FROM Clientes C WHERE C.HoraFin2 IS NULL 
UPDATE C SET C.HoraSabInicio = '0000' FROM Clientes C WHERE C.HoraSabInicio IS NULL 
UPDATE C SET C.HoraSabInicio2 = '0000' FROM Clientes C WHERE C.HoraSabInicio2 IS NULL 
UPDATE C SET C.HoraSabFin = '0000' FROM Clientes C WHERE C.HoraSabFin IS NULL 
UPDATE C SET C.HoraSabFin2 = '0000' FROM Clientes C WHERE C.HoraSabFin2 IS NULL 


PRINT ''
PRINT '2. Normalización de Horas en Clientes - Formato(hhmm)'
UPDATE C SET C.HoraInicio = RIGHT('0000'+HoraInicio,4) FROM Clientes C WHERE C.HoraInicio NOT LIKE '%:%'
UPDATE C SET C.HoraInicio2 = RIGHT('0000'+HoraInicio2,4) FROM Clientes C WHERE C.HoraInicio2 NOT LIKE '%:%'
UPDATE C SET C.HoraFin = RIGHT('0000'+HoraFin,4) FROM Clientes C WHERE C.HoraFin NOT LIKE '%:%'
UPDATE C SET C.HoraFin2 = RIGHT('0000'+HoraFin2,4) FROM Clientes C WHERE C.HoraFin2 NOT LIKE '%:%'
UPDATE C SET C.HoraSabInicio = RIGHT('0000'+HoraSabInicio,4) FROM Clientes C WHERE C.HoraSabInicio NOT LIKE '%:%'
UPDATE C SET C.HoraSabInicio2 = RIGHT('0000'+HoraSabInicio2,4) FROM Clientes C WHERE C.HoraSabInicio2 NOT LIKE '%:%'
UPDATE C SET C.HoraSabFin = RIGHT('0000'+HoraSabFin,4) FROM Clientes C WHERE C.HoraSabFin NOT LIKE '%:%'
UPDATE C SET C.HoraSabFin2 = RIGHT('0000'+HoraSabFin2,4) FROM Clientes C WHERE C.HoraSabFin2 NOT LIKE '%:%'

PRINT ''
PRINT '3. Cambio de Formato(hhmm) a Formato(hh:mm)'
UPDATE C SET C.HoraInicio = SUBSTRING(HoraInicio,1,2) + ':' + SUBSTRING(HoraInicio,3,4)
FROM Clientes C WHERE C.HoraInicio NOT LIKE '%:%'
UPDATE C SET C.HoraInicio2 = SUBSTRING(HoraInicio2,1,2) + ':' + SUBSTRING(HoraInicio2,3,4)
FROM Clientes C WHERE C.HoraInicio2 NOT LIKE '%:%'
UPDATE C SET C.HoraFin = SUBSTRING(HoraFin,1,2) + ':' + SUBSTRING(HoraFin,3,4)
FROM Clientes C WHERE C.HoraFin NOT LIKE '%:%'
UPDATE C SET C.HoraFin2 = SUBSTRING(HoraFin2,1,2) + ':' + SUBSTRING(HoraFin2,3,4)
FROM Clientes C WHERE C.HoraFin2 NOT LIKE '%:%'
UPDATE C SET C.HoraSabInicio = SUBSTRING(HoraSabInicio,1,2) + ':' + SUBSTRING(HoraSabInicio,3,4)
FROM Clientes C WHERE C.HoraSabInicio NOT LIKE '%:%'
UPDATE C SET C.HoraSabInicio2 = SUBSTRING(HoraSabInicio2,1,2) + ':' + SUBSTRING(HoraSabInicio2,3,4)
FROM Clientes C WHERE C.HoraSabInicio2 NOT LIKE '%:%'
UPDATE C SET C.HoraSabFin = SUBSTRING(HoraSabFin,1,2) + ':' + SUBSTRING(HoraSabFin,3,4)
FROM Clientes C WHERE C.HoraSabFin NOT LIKE '%:%'
UPDATE C SET C.HoraSabFin2 = SUBSTRING(HoraSabFin2,1,2) + ':' + SUBSTRING(HoraSabFin2,3,4)
FROM Clientes C WHERE C.HoraSabFin2 NOT LIKE '%:%'
GO

PRINT ''
PRINT '4. Nuevo Campo: CBUCuit en Proveedores'
ALTER TABLE Proveedores
	ADD CBUCuit VARCHAR(13) NULL
GO

PRINT ''
PRINT '5. Actualización de datos pre-existentes'
UPDATE P SET P.CBUCuit = P.CuitProveedor FROM Proveedores P WHERE P.CuitProveedor IS NOT NULL
GO

PRINT ''
PRINT '6. Nuevo Campo: IdTipoSemaforoVentaUtilidad en SemaforoVentasUtilidades'
ALTER TABLE SemaforoVentasUtilidades
	ADD IdTipoSemaforoVentaUtilidad VARCHAR(30) NULL
GO

PRINT ''
PRINT '7. Actualización de registros pre-existentes'
UPDATE SVU SET SVU.IdTipoSemaforoVentaUtilidad = 'RENTABILIDAD' FROM SemaforoVentasUtilidades SVU
GO

PRINT ''
PRINT '8. Actualizo el campo a NOT NULL'
ALTER TABLE SemaforoVentasUtilidades 
	ALTER COLUMN IdTipoSemaforoVentaUtilidad VARCHAR(30) NOT NULL
GO

PRINT ''
PRINT '9. Agrando el tamaño del campo PorcentajeHasta de la tabla SemaforoVentasUtilidad'
ALTER TABLE SemaforoVentasUtilidades 
	ALTER COLUMN PorcentajeHasta DECIMAL(14,2) NOT NULL
GO

PRINT ''
PRINT '10. Nuevo Campo: ColorLetra en SemaforoVentasUtilidades'
ALTER TABLE SemaforoVentasUtilidades
	ADD ColorLetra INT NULL
GO

PRINT ''
PRINT '11. Actualización de datos pre-existentes. En caso de que el color de semáforo sea NEGRO > Letra BLANCA. Caso contrario Letra NEGRA.'
UPDATE S SET S.ColorLetra = (CASE WHEN (S.ColorSemaforo = -16777216) THEN -1 ELSE -16777216 END) FROM SemaforoVentasUtilidades S
GO

PRINT ''
PRINT '12. Cambio el campo a NOT NULL'
ALTER TABLE SemaforoVentasUtilidades
	ALTER COLUMN ColorLetra INT NOT NULL
GO

PRINT ''
PRINT '13. Nuevo Campo: Negrita en SemaforoVentasUtilidades'
ALTER TABLE SemaforoVentasUtilidades
	ADD Negrita BIT NULL
GO

PRINT ''
PRINT '14. Actualizo datos pre-existentes'
UPDATE S SET S.Negrita = (CASE WHEN S.IdTipoSemaforoVentaUtilidad = 'RENTABILIDAD' THEN 1 ELSE 0 END) FROM SemaforoVentasUtilidades S
GO

PRINT ''
PRINT '15. Cambio la propiedad a NOT NULL'
ALTER TABLE SemaforoVentasUtilidades
	ALTER COLUMN Negrita BIT NOT NULL
GO