DELETE RolesFunciones
   WHERE IdFuncion = 'AlicuotasIVA'
GO

DELETE Funciones
   WHERE Id = 'AlicuotasIVA'
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
            IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('ImpuestosABM', 'Impuestos', 'Impuestos', 'True', 'False', 'True', 'True', 
             'Archivos', 890, 'Eniac.Win', 'ImpuestosABM', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImpuestosABM' AS Pantalla FROM Roles
GO
