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
EXECUTE sp_rename N'dbo.Intereses', N'InteresesTemp', 'OBJECT' 
GO
CREATE TABLE [dbo].[Intereses](
	[IdInteres] [int] NOT NULL,
	[NombreInteres] [nvarchar](30) NOT NULL,
	[AdicionalProporcinalDias] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_Intereses] PRIMARY KEY CLUSTERED 
(
	[IdInteres] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[InteresesDias](
	[IdInteres] [int] NOT NULL,
	[DiasDesde] [int] NOT NULL,
	[DiasHasta] [int] NOT NULL,
	[Interes] [decimal](5, 2) NULL,
 CONSTRAINT [PK_InteresesDias] PRIMARY KEY CLUSTERED 
(
	[IdInteres] ASC,
	[DiasDesde] ASC,
	[DiasHasta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[InteresesDias]  WITH CHECK ADD  CONSTRAINT [FK_InteresesDias_Intereses] FOREIGN KEY([IdInteres])
REFERENCES [dbo].[Intereses] ([IdInteres])
GO

ALTER TABLE [dbo].[InteresesDias] CHECK CONSTRAINT [FK_InteresesDias_Intereses]
GO

DECLARE @cantidad int;
SELECT @cantidad = COUNT(1) FROM InteresesTemp
IF @cantidad > 0
BEGIN
    INSERT INTO Intereses
        (IdInteres,NombreInteres,AdicionalProporcinalDias)
    VALUES
        (1
        ,'Unico'
        ,ISNULL((SELECT CONVERT(decimal(7,2), MAX(ValorParametro)) FROM Parametros WHERE IdParametro = 'INTERESESADICIONALPROPORCIONALDIARIO') ,0))
    INSERT INTO InteresesDias
        (IdInteres,DiasDesde,DiasHasta,Interes)
        (SELECT 1,InteresesTemp.DiasDesde,InteresesTemp.DiasHasta,InteresesTemp.Interes FROM InteresesTemp)
END
GO
ALTER TABLE dbo.Intereses SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.InteresesDias SET (LOCK_ESCALATION = TABLE)
GO
DROP TABLE InteresesTemp
GO
COMMIT
