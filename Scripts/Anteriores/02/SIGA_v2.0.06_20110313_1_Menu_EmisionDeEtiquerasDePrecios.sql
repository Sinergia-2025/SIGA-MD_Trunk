
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
      IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
     ('EmisionDeEtiquetasDePrecios', 'Emisión de Etiquetas de Precios', 'Emisión de Etiquetas de Precios', 'True', 'False', 'True', 'True', 
      'Precios', 90, 'Eniac.Win', 'EmisionDeEtiquetasDePrecios', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EmisionDeEtiquetasDePrecios' AS Pantalla FROM Roles
GO
