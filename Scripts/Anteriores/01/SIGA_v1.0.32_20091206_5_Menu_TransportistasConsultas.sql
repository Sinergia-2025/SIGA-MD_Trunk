
--Inserto la pantalla nueva

INSERT INTO Funciones
    (Id,Nombre,Descripcion,EsMenu,EsBoton,Enabled,Visible,IdPadre,Posicion,Archivo,Pantalla,Icono)
 VALUES
    ('TransportistasConsultas','Consulta de Transportistas','Consulta de Transportistas','True','False','True','True','Archivos', 160,'Eniac.Win','TransportistasConsultas',NULL)
GO
    

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'TransportistasConsultas' AS Pantalla FROM dbo.Roles
GO

