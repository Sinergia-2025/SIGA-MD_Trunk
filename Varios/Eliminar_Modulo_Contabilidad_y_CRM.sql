----- ELIMINO MODULO CONTABILIDAD

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE IdPadre='Contabilidad'
)
GO

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE IdPadre='ContabilidadAsientosABM'
)
GO

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'Contabilidad'
)
GO

DELETE [dbo].Bitacora WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE IdPadre='Contabilidad'
)
GO

DELETE [dbo].[Funciones]
 WHERE IdPadre='ContabilidadAsientosABM'
GO

DELETE [dbo].[Funciones]
 WHERE IdPadre='Contabilidad'
GO

DELETE [dbo].[Funciones]
 WHERE id='Contabilidad'
GO

----- ELIMINO MODULO CRM


DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE IdPadre LIKE 'CRM%' AND IdPadre <> 'CRM'
)
GO

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE IdPadre='CRM'
)
GO

DELETE [dbo].RolesFunciones WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE id = 'CRM'
)
GO

DELETE [dbo].Bitacora WHERE IdFuncion IN
 (
SELECT id FROM [dbo].[Funciones]
 WHERE IdPadre='CRM'
)
GO

DELETE [dbo].[Funciones]
 WHERE IdPadre LIKE 'CRM%' AND IdPadre <> 'CRM'
GO

DELETE [dbo].[Funciones]
 WHERE IdPadre='CRM'
GO

DELETE [dbo].[Funciones]
 WHERE id='CRM'
GO


