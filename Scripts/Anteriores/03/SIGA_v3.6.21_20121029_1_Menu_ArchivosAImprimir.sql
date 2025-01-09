
--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ArchivosAImprimirABM', 'Archivos a Imprimir', 'Archivos a Imprimir', 
    'True', 'False', 'True', 'True', 'Configuraciones', 35, 'Eniac.Win', 'ArchivosAImprimirABM', NULL)
GO
INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ArchivosAImprimirABM' AS Pantalla FROM dbo.Roles
GO



