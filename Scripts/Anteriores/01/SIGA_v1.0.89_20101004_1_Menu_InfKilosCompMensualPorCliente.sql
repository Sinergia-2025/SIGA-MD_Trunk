  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfKilosCompMensualPorCliente', 'Inf. de Kilos Comparativo Mensual por Cliente', 'Inf. de Kilos Comparativo Mensual por Cliente', 
    'True', 'False', 'True', 'True', 'Kilos', 50, 'Eniac.Win', 'InfKilosCompMensualPorCliente', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfKilosCompMensualPorCliente' AS Pantalla FROM dbo.Roles
GO
