
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id,Nombre,Descripcion,EsMenu,EsBoton,Enabled,Visible,IdPadre,Posicion,Archivo,Pantalla,Icono)
 VALUES
    ('Transportistas','Transportistas','Transportistas','True','False','True','True','Archivos', 150,'Eniac.Win','TransportistasABM',NULL)
GO
    

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'Transportistas' AS Pantalla FROM dbo.Roles
GO

