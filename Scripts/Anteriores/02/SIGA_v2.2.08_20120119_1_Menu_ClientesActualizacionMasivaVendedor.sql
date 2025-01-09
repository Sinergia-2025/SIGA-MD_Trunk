
DELETE RolesFunciones WHERE IdFuncion IN ('ActualizMasivaClientesVend', 'ClientesActualizMasivaVend')
GO

DELETE Funciones WHERE Id IN ('ActualizMasivaClientesVend', 'ClientesActualizMasivaVend')
GO


--Inserto la pantalla nueva

INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono)
 VALUES
   ('ClientesActualizMasivaVend', 'Clientes - Actualizacion Masiva de Vendedores', 'Clientes - Actualizacion Masiva de Vendedores', 
    'True', 'False', 'True', 'True', 'Archivos', 25, 'Eniac.Win', 'ClientesActualizacionMasivaVendedor', NULL)
GO

INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ClientesActualizMasivaVend' AS Pantalla FROM dbo.Roles
GO
