
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

ALTER TABLE dbo.Provincias ADD Jurisdiccion int NULL
GO
UPDATE Provincias SET Jurisdiccion = 901 WHERE IdProvincia = 'CF'
UPDATE Provincias SET Jurisdiccion = 902 WHERE IdProvincia = 'BS'
UPDATE Provincias SET Jurisdiccion = 903 WHERE IdProvincia = 'CA'
UPDATE Provincias SET Jurisdiccion = 904 WHERE IdProvincia = 'CB'
UPDATE Provincias SET Jurisdiccion = 905 WHERE IdProvincia = 'CR'
UPDATE Provincias SET Jurisdiccion = 906 WHERE IdProvincia = 'CH'
UPDATE Provincias SET Jurisdiccion = 907 WHERE IdProvincia = 'CU'
UPDATE Provincias SET Jurisdiccion = 908 WHERE IdProvincia = 'ER'
UPDATE Provincias SET Jurisdiccion = 909 WHERE IdProvincia = 'FO'
UPDATE Provincias SET Jurisdiccion = 910 WHERE IdProvincia = 'JU'
UPDATE Provincias SET Jurisdiccion = 911 WHERE IdProvincia = 'LP'
UPDATE Provincias SET Jurisdiccion = 912 WHERE IdProvincia = 'LR'
UPDATE Provincias SET Jurisdiccion = 913 WHERE IdProvincia = 'MZ'
UPDATE Provincias SET Jurisdiccion = 914 WHERE IdProvincia = 'MI'
UPDATE Provincias SET Jurisdiccion = 915 WHERE IdProvincia = 'NE'
UPDATE Provincias SET Jurisdiccion = 916 WHERE IdProvincia = 'RN'
UPDATE Provincias SET Jurisdiccion = 917 WHERE IdProvincia = 'SA'
UPDATE Provincias SET Jurisdiccion = 918 WHERE IdProvincia = 'SJ'
UPDATE Provincias SET Jurisdiccion = 919 WHERE IdProvincia = 'SL'
UPDATE Provincias SET Jurisdiccion = 920 WHERE IdProvincia = 'SC'
UPDATE Provincias SET Jurisdiccion = 921 WHERE IdProvincia = 'SF'
UPDATE Provincias SET Jurisdiccion = 922 WHERE IdProvincia = 'SE'
UPDATE Provincias SET Jurisdiccion = 923 WHERE IdProvincia = 'TF'
UPDATE Provincias SET Jurisdiccion = 924 WHERE IdProvincia = 'TC'

UPDATE Provincias SET Jurisdiccion = 0 WHERE Jurisdiccion IS NULL

ALTER TABLE dbo.Provincias ALTER COLUMN Jurisdiccion int NOT NULL
GO

ALTER TABLE dbo.Provincias SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
