
PRINT ''
PRINT '1. Tabla CargosClientes: Agrego Campos PrecioLista, DescuentoRecargoPorc1, y DescuentoRecargoPorc1.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.CargosClientes ADD
	PrecioLista decimal(12, 2) NULL,
	DescuentoRecargoPorc1 decimal(10, 5) NULL,
	DescuentoRecargoPorc2 decimal(10, 5) NULL
GO
ALTER TABLE dbo.CargosClientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '2. Tabla CargosClientes: Asigno valores a los Campos PrecioLista, DescuentoRecargoPorc1, y DescuentoRecargoPorc1.'
GO

UPDATE CargosClientes 
  SET PrecioLista = Monto
	, DescuentoRecargoPorc1 = 0
	, DescuentoRecargoPorc2 = 0
GO


PRINT ''
PRINT '3. Tabla CargosClientes: Ajusto NOT NULL a los Campos PrecioLista, DescuentoRecargoPorc1, y DescuentoRecargoPorc1.'
GO

ALTER TABLE dbo.CargosClientes ALTER COLUMN	PrecioLista decimal(12, 2) NOT NULL
GO

ALTER TABLE dbo.CargosClientes ALTER COLUMN	DescuentoRecargoPorc1 decimal(10, 5) NOT NULL
GO
	
ALTER TABLE dbo.CargosClientes ALTER COLUMN	DescuentoRecargoPorc2 decimal(10, 5) NOT NULL
GO


PRINT ''
PRINT '4. Tabla Parametros: Seteos Direcciones Web especificas Plumas Aloe.'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('23238857449'))
BEGIN

	UPDATE Parametros
	   SET ValorParametro = 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigapedido/CuitEmpresa/23238857449'
	 WHERE IdParametro = 'PEDIDOSURLWEBGET';
	UPDATE Parametros
	   SET ValorParametro = 'http://www.plumasaloe.com.ar/rest-siga/index.php/api/sigapedido/id/{0}/estado/{1}'
	 WHERE IdParametro = 'PEDIDOSURLWEBPUT';
	UPDATE Parametros
	   SET ValorParametro = 'SiGA'
	 WHERE IdParametro = 'PEDIDOSWEBFORMATO';

	--SELECT *
	--  FROM Parametros
	-- WHERE IdParametro IN ('PEDIDOSURLWEBGET', 'PEDIDOSURLWEBPUT', 'PEDIDOSWEBFORMATO')
	-- ;
 
 END;
