  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfKilosCompMensualXCliente2R', 'Inf. de Kilos Comparativo Mensual por Cliente 2 R', 'Inf. de Kilos Comparativo Mensual por Cliente Doble Rango', 
    'True', 'False', 'True', 'True', 'Kilos', 55, 'Eniac.Win', 'InfKilosCompMensualPorClienteDobleRango', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfKilosCompMensualXCliente2R' AS Pantalla FROM dbo.Roles
GO
