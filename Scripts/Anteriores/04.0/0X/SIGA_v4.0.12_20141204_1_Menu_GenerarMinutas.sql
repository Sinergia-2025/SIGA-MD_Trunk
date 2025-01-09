
--Inserto las pantallas nuevas

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('GenerarMinutas', 'Generar Minutas Masivas', 'Generar Minutas Masivas', 
    'True', 'False', 'True', 'True', 'CuentasCorrientes', 15, 'Eniac.Win', 'GenerarMinutas', null)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'GenerarMinutas' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
