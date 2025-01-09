--TRUNCATE TABLE SiSeN.dbo.PadronARBA_temp

--BULK INSERT SiSeN.dbo.PadronARBA_Temp  FROM 'D:\Users\Sinergia\Desktop\PadronRGSPer052016_mini.txt' WITH (FIELDTERMINATOR =';',ROWTERMINATOR =';\n')

--DELETE FROM SiSeN.dbo.PadronARBA WHERE 1 = 1 AND PeriodoInformado = 201605

--EXECUTE SiSeN.dbo.ProcesarInfoARBA 201605

--DELETE FROM SiSeN.dbo.PadronARBA WHERE 1 = 1 AND PeriodoInformado <= 201602

select * from SiSeN.dbo.PadronARBA_Temp
select * from SiSeN.dbo.PadronARBA

select Count(Distinct PeriodoInformado) as cantidad, MIN(PeriodoInformado) as MasAntiguo from SiSeN.dbo.PadronARBA

select Distinct PeriodoInformado from SiSeN.dbo.PadronARBA