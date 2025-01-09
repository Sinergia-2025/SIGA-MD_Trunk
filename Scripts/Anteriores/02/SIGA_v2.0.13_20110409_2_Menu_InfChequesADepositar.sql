
--Pantallas nuevas de Sueldos

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('InfChequesADepositar', 'Inf. Cheques a Depositar', 'Inf. Cheques a Depositar', 
    'False', 'False', 'True', 'False', 'Caja', 75, 'Eniac.Win', 'InfChequesADepositar', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfChequesADepositar' AS Pantalla FROM dbo.Roles
        WHERE Id IN ('Adm', 'Supervisor')
GO



