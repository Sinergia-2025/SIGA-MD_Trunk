DECLARE @Menu varchar(255) = 'TurnosAnt'

DELETE Bitacora WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

DELETE RolesFunciones WHERE IdFuncion IN (SELECT ID FROM Funciones WHERE Id = @Menu OR IdPadre = @Menu);

DELETE Funciones WHERE Id = @Menu or IdPadre = @Menu ;


