PRINT ''
PRINT '1. Elimnar la FK de Versiones a VersionesScripts'
ALTER TABLE dbo.VersionesScripts DROP CONSTRAINT FK_VersionesScripts_Versiones

