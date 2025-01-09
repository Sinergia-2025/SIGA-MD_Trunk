
ALTER TABLE SueldosConceptos ADD CodigoConcepto int null
GO 

--- el codigo 1 se manteiene en 1, pero del tipo 2 , pasa de 20 a 1020. 
--- No arranca por 1000 porque llegaria a 10mil y ocupa un digito mas.

UPDATE SueldosConceptos 
 SET CodigoConcepto = IdTipoConcepto*1000+IdConcepto-1000
GO

ALTER TABLE SueldosConceptos ALTER COLUMN CodigoConcepto int not null
GO 
