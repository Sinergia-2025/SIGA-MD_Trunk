
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfHistoricoConsProd', 'Informe Historico Consulta Productos', 'Informe Historico Consulta Productos', 
    'True', 'False', 'True', 'True', 'Precios', 60, 'Eniac.Win', 'InfHistoricoConsultaProductos', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfHistoricoConsProd' AS Pantalla FROM dbo.Roles
GO
