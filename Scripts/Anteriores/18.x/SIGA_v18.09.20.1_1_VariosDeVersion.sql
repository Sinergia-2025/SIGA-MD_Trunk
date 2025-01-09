
PRINT ''
PRINT '1. Tabla CRMCategoriasNovedades: Agrego Campo Reporta.'
GO

ALTER TABLE CRMCategoriasNovedades ADD Reporta varchar(10) NULL
GO

PRINT ''
PRINT '2. Tabla CRMCategoriasNovedades: Actualizo NA / NO / SI segun corresponde.'
GO

UPDATE CRMCategoriasNovedades 
   SET Reporta = 'NO'
GO

UPDATE CRMCategoriasNovedades 
   SET Reporta = 'SI'
 WHERE IdTipoNovedad ='PENDIENTE'
   AND NombreCategoriaNovedad IN ('MEJORA', 'PROYECTO', 'MANUAL') 
GO

UPDATE CRMCategoriasNovedades 
   SET Reporta = 'CLIENTE'
 WHERE IdTipoNovedad ='PENDIENTE'
   AND NombreCategoriaNovedad = 'UNICO'
GO

PRINT ''
PRINT '3. Tabla CRMCategoriasNovedades: Convierto Campo Reporta a NOT NULL.'
GO

ALTER TABLE CRMCategoriasNovedades ALTER COLUMN Reporta varchar(10) NOT NULL
GO


PRINT ''
PRINT '4. Nuevo Parametro: Muestra "Reporta" en Categorías Novedades (NO).'
GO

MERGE INTO Parametros AS P
        USING (SELECT 'CRMMUESTRAREPORTACATEGORIASNOVEDADES' AS IdParametro, 'False' ValorParametro, 'Muestra "Reporta" en Categorías Novedades'  AS DescripcionParametro) AS PT ON P.IdParametro = PT.IdParametro
    WHEN MATCHED THEN
        UPDATE SET P.ValorParametro = PT.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (PT.IdParametro, PT.ValorParametro, NULL, PT.DescripcionParametro)
;


PRINT ''
PRINT '5. Parametros: Muestra "Reporta" en Categorías Novedades: Solo HAR - True.'
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('33711345499'))
BEGIN

	UPDATE Parametros 
	   SET ValorParametro = 'True' 
	 WHERE IdParametro = 'CRMMUESTRAREPORTACATEGORIASNOVEDADES'

END
;


PRINT ''
PRINT '6. Tabla Funciones: Agrego campos Plus, Express, Basica y PV // Actualizo Valores.'
GO

ALTER TABLE Funciones ADD Plus varchar(5) null
GO

ALTER TABLE Funciones ADD Express varchar(5) null
GO

ALTER TABLE Funciones ADD Basica varchar(5) null
GO

ALTER TABLE Funciones ADD PV varchar(5) null
GO

UPDATE Funciones 
   SET Plus = 'S'
     , Express = 'N'
     , Basica = 'N'
     , PV = 'N'
GO

ALTER TABLE Funciones ALTER COLUMN Plus varchar(5) not null
GO

ALTER TABLE Funciones ALTER COLUMN Express varchar(5) not null
GO

ALTER TABLE Funciones ALTER COLUMN Basica varchar(5) not null
GO

ALTER TABLE Funciones ALTER COLUMN PV varchar(5) not null
GO
