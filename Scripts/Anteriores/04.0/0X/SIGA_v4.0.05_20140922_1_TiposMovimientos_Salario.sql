
UPDATE TiposMovimientos SET
	ComprobantesAsociados = ComprobantesAsociados + ',SALARIO'
 WHERE IdTipoMovimiento = 'SUELDO'
GO
