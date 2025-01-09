  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfKilosCompMarcasPorCliente', 'Inf. de Kilos Comparativo de Marcas por Cliente', 'Inf. de Kilos de Marcas Mensual por Cliente', 
    'True', 'False', 'True', 'True', 'Kilos', 60, 'Eniac.Win', 'InfKilosCompMarcasPorCliente', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfKilosCompMarcasPorCliente' AS Pantalla FROM dbo.Roles
GO
