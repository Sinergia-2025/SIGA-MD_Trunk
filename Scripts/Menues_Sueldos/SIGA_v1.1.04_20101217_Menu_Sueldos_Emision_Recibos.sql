  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SueldosEmisionRecibos', 'Emisión de Recibos de Sueldos', 'Emisión de Recibos de Sueldos', 
    'True', 'False', 'True', 'True', 'Sueldos', 30, 'Eniac.Win', 'SueldosEmisionRecibos', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SueldosEmisionRecibos' AS Pantalla FROM dbo.Roles
GO
