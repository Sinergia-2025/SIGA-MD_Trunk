
--Pantalla Nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('SemaforoVentasUtilidadesABM', 'ABM de Semaforo Ventas Utilidades', 'ABM de Semaforo Ventas Utilidades', 
    'True', 'False', 'True', 'True', 'Configuraciones', 40, 'Eniac.Win', 'SemaforoVentasUtilidadesABM', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'SemaforoVentasUtilidadesABM' AS Pantalla FROM dbo.Roles
GO
