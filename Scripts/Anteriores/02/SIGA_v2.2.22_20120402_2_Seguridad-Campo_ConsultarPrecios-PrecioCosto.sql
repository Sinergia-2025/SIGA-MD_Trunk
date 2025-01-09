
--Inserto el Campo de Pantalla

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ConsultarPrecios-PrecioCosto', 'Consultar Precios - Mostrar Precio de Costo', 'Consultar Precios - Mostrar Precio de Costo', 
    'False', 'False', 'True', 'True', 'ConsultarPrecios', 10, 'Eniac.Win', 'ConsultarPrecios-PrecioCosto', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarPrecios-PrecioCosto' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
