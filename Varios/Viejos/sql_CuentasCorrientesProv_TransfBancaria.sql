/*
   Miércoles, 03 de Junio de 200920:17:15
   Usuario: sa
   Servidor: TERRA-PC\SQLEXPRESS
   Base de datos: Bernabe
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar esta secuencia de comandos detalladamente antes de ejecutarla fuera del contexto del diseñador de base de datos.*/
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
EXECUTE sp_rename N'dbo.CuentasCorrientesProv.ImporteTarjetas', N'Tmp_ImporteTransfBancaria', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.CuentasCorrientesProv.Tmp_ImporteTransfBancaria', N'ImporteTransfBancaria', 'COLUMN' 
GO
COMMIT
