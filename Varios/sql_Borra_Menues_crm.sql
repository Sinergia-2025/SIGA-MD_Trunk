
DELETE RolesFunciones 
where IdFuncion in
 (
SELECT id FROM Funciones
 WHERE id='CRM' or IdPadre IN ('CRM','CRMNovedadesABMCRM', 'CRMNovedadesABMPROSP', 'CRMNovedadesABMRECCLTE', 'CRMNovedadesABMRECPROV','CRMNovedadesABMSERVICE')
 
)
GO

DELETE Funciones
 WHERE id='CRM' or IdPadre IN ('CRM','CRMNovedadesABMCRM', 'CRMNovedadesABMPROSP', 'CRMNovedadesABMRECCLTE', 'CRMNovedadesABMRECPROV','CRMNovedadesABMSERVICE')
GO
