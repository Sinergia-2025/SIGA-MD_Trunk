
--Agrego un campo nuevo para identificar si es obligatorio el CUIT para ese tipo de Categoria Fiscal

-- 1	Consumidor Final
-- 2	Responsable Inscripto
-- 3	Responsable NO Inscripto
-- 4	Exento
-- 5	Exento SIN IVA
-- 6	Monotributista
-- 7	Exportacion

ALTER TABLE CategoriasFiscales ADD SolicitaCUIT bit null
GO

UPDATE CategoriasFiscales 
   SET SolicitaCUIT = (CASE WHEN IdCategoriaFiscal<>1 AND IdCategoriaFiscal<>7 THEN 'True' ELSE 'False' END)
GO

ALTER TABLE CategoriasFiscales ALTER COLUMN SolicitaCUIT bit not null
GO
