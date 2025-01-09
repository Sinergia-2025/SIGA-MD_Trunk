IF dbo.SoyHAR() = 1
BEGIN
    DELETE RolesFunciones
     WHERE IdFuncion = 'ClientesEstrellas'
       AND IdRol <> 'Adm'
END
ELSE
BEGIN
    DELETE RolesFunciones WHERE IdFuncion = 'ClientesEstrellas'
    DELETE Bitacora WHERE IdFuncion = 'ClientesEstrellas'
    DELETE Funciones WHERE Id = 'ClientesEstrellas'
END
