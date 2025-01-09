
DELETE RolesFunciones WHERE IdFuncion = 'FormasPago'
GO

DELETE Funciones WHERE Id = 'FormasPago'
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
            IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('FormasPago', 'Formas de Pago', 'Formas de Pago', 'True', 'False', 'True', 'True', 
             'Archivos', 50, 'Eniac.Win', 'FormasDePagoABM', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'FormasPago' AS Pantalla FROM Roles
GO
