
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('EmisionDeEtiquetasCodBarra', 'Emisión de Etiquetas de Código de Barras', 'Emisión de Etiquetas de Código de Barras', 
    'True', 'False', 'True', 'True', 'Precios', 95, 'Eniac.Win', 'EmisionDeEtiquetasCodBarra', NULL)
GO

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EmisionDeEtiquetasCodBarra' AS Pantalla FROM dbo.Roles
GO
