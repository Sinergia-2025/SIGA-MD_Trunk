
--Inserto la pantalla nueva

INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
            IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
           ('AlicuotasIVA', 'Alicuotas de IVA', 'Alicuotas de IVA', 'True', 'False', 'True', 'True', 
             'Archivos', 890, 'Eniac.Win', 'AlicuotasIVAABM', NULL)
GO


INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'AlicuotasIVA' AS Pantalla FROM dbo.Roles
GO
