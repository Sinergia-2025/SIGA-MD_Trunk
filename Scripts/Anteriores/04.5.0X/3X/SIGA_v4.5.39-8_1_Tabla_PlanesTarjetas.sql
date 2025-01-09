
PRINT '1. Creo tabla PlanesTarjetas y los FK a Bancos y Tarjetas';

/****** Object:  Table dbo.PlanesTarjetas    Script Date: 05/17/2017 15:49:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE dbo.PlanesTarjetas(
    IdPlanTarjeta int NOT NULL,
    NombrePlanTarjeta varchar(30) NOT NULL,
    CuotasDesde int NOT NULL,
    CuotasHasta int NOT NULL,
    PorcDescRec decimal(8, 2) NOT NULL,
    IdTarjeta int NULL,
    IdBanco int NULL,
    Activo bit NOT NULL,
 CONSTRAINT PK_PlanesTarjetas PRIMARY KEY CLUSTERED 
(
	IdPlanTarjeta ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

PRINT '2. Creo FK a Bancos';

ALTER TABLE dbo.PlanesTarjetas  WITH CHECK ADD  CONSTRAINT FK_PlanesTarjetas_Bancos FOREIGN KEY(IdBanco)
REFERENCES dbo.Bancos (IdBanco)
GO

ALTER TABLE dbo.PlanesTarjetas CHECK CONSTRAINT FK_PlanesTarjetas_Bancos
GO

PRINT '3. Creo FK a Tarjetas';

ALTER TABLE dbo.PlanesTarjetas  WITH CHECK ADD  CONSTRAINT FK_PlanesTarjetas_PlanesTarjetas FOREIGN KEY(IdTarjeta)
REFERENCES dbo.Tarjetas (IdTarjeta)
GO

ALTER TABLE dbo.PlanesTarjetas CHECK CONSTRAINT FK_PlanesTarjetas_PlanesTarjetas
GO

/* -------------- */

PRINT '4. Inserto los Registros de Planes Ahora 3, 6, 12 y 18.';

INSERT INTO PlanesTarjetas
           (IdPlanTarjeta,NombrePlanTarjeta
           ,CuotasDesde,CuotasHasta,PorcDescRec
           ,IdTarjeta,IdBanco,Activo)
     VALUES
           (1, 'Ahora  3', 3, 3, 0, NULL, NULL, 'True'),
           (2, 'Ahora  6', 6, 6, 0, NULL, NULL, 'True'),
           (3, 'Ahora 12', 12, 12, 0, NULL, NULL, 'True'),
           (4, 'Ahora 18', 18, 18, 0, NULL, NULL, 'True')
GO

IF EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' AND P.ValorParametro IN ('20182151204'))	
BEGIN

	PRINT '5. Emporio de Ferreteria: Inserto los Registros de PlanesTarjetas segun Tarjetas.';
	--Hoy tiene mi CUIT

	INSERT INTO PlanesTarjetas
			   (IdPlanTarjeta,NombrePlanTarjeta
			   ,CuotasDesde,CuotasHasta,PorcDescRec
			   ,IdTarjeta,IdBanco,Activo)
	SELECT 4 + ROW_NUMBER() OVER (ORDER BY IdTarjeta) IdPlanTarjeta
		  ,REPLACE(NombreTarjeta, 'TARJETA ', '') NombrePlanTarjeta
		  ,CantidadCuotas CuotasDesde,CantidadCuotas CuotasHasta,PorcIntereses PorcDescRec
		  ,NULL IdTarjeta, NULL IdBanco, 1 Activo
	  FROM Tarjetas
	 WHERE NombreTarjeta LIKE 'TARJETA%'
	 ORDER BY IdTarjeta
	;

	PRINT '6. Emporio de Ferreteria: Elimino los Registros de Tarjetas.';

	DELETE FROM Tarjetas
	 WHERE NombreTarjeta LIKE 'TARJETA%'
	;

END
