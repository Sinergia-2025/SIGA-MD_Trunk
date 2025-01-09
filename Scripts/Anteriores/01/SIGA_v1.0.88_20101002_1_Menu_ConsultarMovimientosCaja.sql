  
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ConsultarMovimientosCaja', 'Consultar Movimientos de Caja', 'Consultar Movimientos de Caja', 
    'True', 'False', 'True', 'True', 'Caja', 15, 'Eniac.Win', 'ConsultarMovimientosCaja', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ConsultarMovimientosCaja' AS Pantalla FROM dbo.Roles
GO
