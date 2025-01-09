
DELETE RolesFunciones 
  WHERE IdFuncion IN ('ConsultarCtaCteClientes', 'ConsultarCtaCteDetalleClientes')
;

UPDATE Funciones 
    SET EsMenu = 'False'
      , [Enabled] = 'False'
      , Visible = 'False'
  WHERE Id IN ('ConsultarCtaCteClientes', 'ConsultarCtaCteDetalleClientes')
;
