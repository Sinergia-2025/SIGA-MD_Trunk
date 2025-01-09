
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('EmisionDeEtiquetasCodBarra', 'Emisi�n de Etiquetas de C�digo de Barras', 'Emisi�n de Etiquetas de C�digo de Barras', 
    'True', 'False', 'True', 'True', 'Precios', 95, 'Eniac.Win', 'EmisionDeEtiquetasCodBarra', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EmisionDeEtiquetasCodBarra' AS Pantalla FROM dbo.Roles
GO
