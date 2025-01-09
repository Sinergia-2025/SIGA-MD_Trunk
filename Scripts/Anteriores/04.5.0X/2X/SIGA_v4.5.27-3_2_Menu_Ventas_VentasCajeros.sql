
--- Inserto las pantallas nuevas ---

IF EXISTS (SELECT 1 FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' AND P.ValorParametro = '20182151204')
BEGIN
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible
   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('Cajero', 'Cajero', 'Cajero', 
    'True', 'False', 'True', 'True', 
    'Ventas', 35,'Eniac.Win', 'Cajero', null);

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Cajero' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');

END
