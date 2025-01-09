

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ConsultarFact-MostrarImp', 'Consultar Facturables - Mostrar Importes', 'ConsultarFacturables - Mostrar Importes', 
    'False', 'False', 'True', 'True', 'ConsultarFacturables', 10, 'Eniac.Win', 'ConsultarFact-MostrarImp', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarFact-MostrarImp' AS Pantalla FROM dbo.Roles
--    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
