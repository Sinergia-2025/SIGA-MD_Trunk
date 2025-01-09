  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('MovimientosDeCompras', 'Movimientos de Compras', 'Movimientos de Compras', 
    'True', 'True', 'True', 'True', 'Compras', 5, 'Eniac.Win', 'MovimientosDeCompras', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'MovimientosDeCompras' AS Pantalla FROM dbo.Roles
GO
