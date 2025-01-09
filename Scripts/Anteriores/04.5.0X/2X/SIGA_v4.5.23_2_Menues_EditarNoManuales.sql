INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('CntbAsientosABM-EditaNoManual', 'Asientos - Edita No Manual', 'Asientos - Edita No Manual', 
    'False', 'False', 'True', 'False', 'ContabilidadAsientosABM', 10, 'Eniac.Win', 'CntbAsientosABM-EditaNoManual', NULL)
GO

-- Aquellos Roles que pueden Actualizar los Ejercicios Contables.
INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT IdRol, 'CntbAsientosABM-EditaNoManual' AS Pantalla  FROM RolesFunciones 
 WHERE IdFuncion = 'ContabilidadEjeciciosABM'
GO
