
--SOLO SIAP
IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                AND P.ValorParametro IN ('30710784236'))

BEGIN

PRINT ''
PRINT '1. Tabla CRMNovedadesSeguimiento: Borro FKs y PK.'

ALTER TABLE [dbo].[CRMNovedades] DROP CONSTRAINT  FK_CRMNovedades_CRMNovedades_Padre

ALTER TABLE [dbo].[CRMNovedadesSeguimiento] DROP CONSTRAINT [FK_CRMNovedadesSeguimiento_CRMNovedades]

ALTER TABLE dbo.CRMNovedades DROP CONSTRAINT PK_CRMNovedades



PRINT ''
PRINT '2. Tabla CRMNovedadesSeguimiento: Borro PK.'

ALTER TABLE dbo.CRMNovedadesSeguimiento DROP CONSTRAINT PK_CRMNovedadesSeguimiento



PRINT '3. Actualizo numeracion de Alertas'
--CRMNovedadesSeguimiento
DECLARE @Valor VARCHAR(MAX)
DECLARE nove CURSOR FOR  
SELECT * FROM CRMNovedadesSeguimiento WHERE IdTipoNovedad = 'ALERTAS' AND Letra = ''
SELECT @Valor = MAX(IdNovedad) FROM CRMNovedades WHERE IdTipoNovedad = 'ALERTAS' AND Letra = 'X'
OPEN nove 
FETCH NEXT FROM nove
WHILE @@FETCH_STATUS = 0  
BEGIN  

Select @valor = @valor +1

UPDATE CRMNovedadesSeguimiento SET Letra = 'X', IdNovedad = @valor  

WHERE CURRENT OF nove
      FETCH NEXT FROM nove
  END 
CLOSE nove
DEALLOCATE nove 

--CRMNovedades
DECLARE @Valor1 VARCHAR(MAX)
DECLARE nove CURSOR FOR  
SELECT * FROM CRMNovedades WHERE IdTipoNovedad = 'ALERTAS' AND Letra = ''
SELECT @Valor1 = MAX(IdNovedad) FROM CRMNovedades WHERE IdTipoNovedad = 'ALERTAS' AND Letra = 'X'
OPEN nove 
FETCH NEXT FROM nove
WHILE @@FETCH_STATUS = 0  
BEGIN  

Select @valor1 = @valor1 +1

UPDATE CRMNovedades SET Letra = 'X', IdNovedad = @valor1  

WHERE CURRENT OF nove
      FETCH NEXT FROM nove
  END 
CLOSE nove
DEALLOCATE nove 



PRINT '4. Actualizo numeracion de Gestiones'
--CRMNovedadesSeguimiento
DECLARE @Valor3 VARCHAR(MAX)
DECLARE nove CURSOR FOR  
SELECT * FROM CRMNovedadesSeguimiento WHERE IdTipoNovedad = 'GESTIONES' AND Letra = ''
SELECT @Valor3 = MAX(IdNovedad) FROM CRMNovedades WHERE IdTipoNovedad = 'GESTIONES' AND Letra = 'X'
OPEN nove 
FETCH NEXT FROM nove
WHILE @@FETCH_STATUS = 0  
BEGIN  

Select @valor3 = @valor3 +1

UPDATE CRMNovedadesSeguimiento SET Letra = 'X', IdNovedad = @valor3  

WHERE CURRENT OF nove
      FETCH NEXT FROM nove
  END 
CLOSE nove
DEALLOCATE nove 

--CRMNovedades
DECLARE @Valor4 VARCHAR(MAX)
DECLARE nove CURSOR FOR  
SELECT * FROM CRMNovedades WHERE IdTipoNovedad = 'GESTIONES' AND Letra = ''
SELECT @Valor4 = MAX(IdNovedad) FROM CRMNovedades WHERE IdTipoNovedad = 'GESTIONES' AND Letra = 'X'
OPEN nove 
FETCH NEXT FROM nove
WHILE @@FETCH_STATUS = 0  
BEGIN  

Select @valor4 = @valor4 +1

UPDATE CRMNovedades SET Letra = 'X', IdNovedad = @valor4  

WHERE CURRENT OF nove
      FETCH NEXT FROM nove
  END 
CLOSE nove
DEALLOCATE nove 




PRINT ''
PRINT '5. Tabla CRMNovedades: Creo PK.'

ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT PK_CRMNovedades
    PRIMARY KEY CLUSTERED (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

PRINT ''
PRINT '6. Tabla CRMNovedadesSeguimiento: Creo PK.'

ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CONSTRAINT PK_CRMNovedadesSeguimiento
    PRIMARY KEY CLUSTERED (IdTipoNovedad,Letra,CentroEmisor,IdNovedad,IdSeguimiento)
    WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

PRINT ''
PRINT '7. Tabla CRMNovedades: Creo FK_CRMNovedades_CRMNovedades_Padre.'

ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_CRMNovedades_Padre
    FOREIGN KEY (IdTipoNovedadPadre,LetraPadre,CentroEmisorPadre,IdNovedadPadre)
    REFERENCES dbo.CRMNovedades (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 

PRINT ''
PRINT '8. Tabla CRMNovedadesSeguimiento: Creo FK_CRMNovedadesSeguimiento_CRMNovedades.'

ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CONSTRAINT FK_CRMNovedadesSeguimiento_CRMNovedades
    FOREIGN KEY (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    REFERENCES dbo.CRMNovedades (IdTipoNovedad,Letra,CentroEmisor,IdNovedad)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION

END
