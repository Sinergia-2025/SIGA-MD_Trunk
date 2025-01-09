
--27055884175: Servilimp - Sinopoli Maria del Carmen.
--30708748737: Kweb

IF EXISTS (SELECT 1 FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' AND P.ValorParametro IN ('27055884175','30708748737'))
BEGIN

--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('CargosClientes', 'Asignación de Cargos a Clientes', 'Asignación de Cargos a Clientes', 'True', 'False', 'True', 'True',
      'Cargos', 50, 'Eniac.Win', 'CargosClientes', NULL);

INSERT INTO RolesFunciones 
      (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'CargosClientes' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END
