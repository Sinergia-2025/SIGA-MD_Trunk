
/****** Object:  Table [dbo].[Aduanas]    Script Date: 04/18/2017 17:59:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Aduanas](
	[IdAduana] [int] NOT NULL,
	[NombreAduana] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Aduanas] PRIMARY KEY CLUSTERED 
(
	[IdAduana] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/* --------------------------- */

INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (3,'BAHIA BLANCA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (4,'BARILOCHE')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (10,'BARRANQUERAS')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (82,'BERNARDO DE YRIGOYEN')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (1,'BUENOS AIRES (CAPITAL)')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (87,'CALETA OLIVIA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (8,'CAMPANA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (12,'CLORINDA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (13,'COLON')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (14,'COMODORO RIVADAVIA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (15,'CONCEPCION DEL URUGUAY')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (16,'CONCORDIA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (17,'CORDOBA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (18,'CORRIENTES')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (20,'DIAMANTE')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (23,'ESQUEL')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (73,'EZEIZA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (24,'FORMOSA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (25,'GOYA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (26,'GUALEGUAYCHU')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (29,'IGUAZU')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (31,'JUJUY')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (33,'LA PLATA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (34,'LA QUIACA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (79,'LA RIOJA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (37,'MAR DEL PLATA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (38,'MENDOZA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (40,'NECOCHEA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (75,'NEUQUEN')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (86,'OBERA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (76,'ORAN')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (41,'PARANA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (42,'PASO DE LOS LIBRES')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (45,'POCITOS')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (46,'POSADAS')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (19,'PUERTO DESEADO')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (47,'PUERTO MADRYN')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (48,'RIO GALLEGOS')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (49,'RIO GRANDE')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (52,'ROSARIO')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (58,'S.MARTIN DE LOS ANDES')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (53,'SALTA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (80,'SAN ANTONIO OESTE')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (54,'SAN JAVIER')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (55,'SAN JUAN')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (57,'SAN LORENZO')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (83,'SAN LUIS')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (59,'SAN NICOLAS')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (60,'SAN PEDRO')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (78,'SAN RAFAEL')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (61,'SANTA CRUZ')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (62,'SANTA FE')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (84,'SANTO TOME')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (66,'TINOGASTA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (74,'TUCUMAN')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (67,'USHUAIA')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (69,'VILLA CONSTITUCION')
INSERT INTO Aduanas (IdAduana,NombreAduana) VALUES (85,'VILLA REGINA')
GO

