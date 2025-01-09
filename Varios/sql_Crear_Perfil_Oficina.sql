--SELECT * FROM Roles
--GO

INSERT INTO Roles (Id, Nombre, Descripcion)
 VALUES ('Oficina', 'Oficina', 'Oficina')
GO

--SELECT * FROM UsuariosRoles
--GO

UPDATE UsuariosRoles 
   SET IdRol = 'Oficina'
 WHERE IdUsuario IN ('Gisela', 'Malena')
GO
   
DELETE RolesFunciones WHERE IdRol = 'Oficina'
GO

INSERT INTO RolesFunciones(IdRol, IdFuncion)
SELECT 'Oficina' AS Rol, IdFuncion FROM RolesFunciones
  WHERE IdRol = 'Supervisor'
  AND IdFuncion NOT IN ('EliminarComprobantes', 'EliminarVentas', 'BlanquearStock', 'RecibosNuevos', 'AnularRecibos', 'EliminarRecibosDeClientes', 
                        'InfUtilidadesPorCliente', 'InfUtilidadesPorComprobantDet', 'InfUtilidadesPorComprobantes', 'InfUtilidadesPorMarca', 'InfUtilidadesPorProducto', 
                        'LibroBancos', 'MoviCaja', 'PagosAProveedores', 'AnularPagosAProveedores', 'DepositosBancarios',  
                        'SemaforoVentasUtilidadesABM', 'Seguridad', 'SegFunRol', 'SegRoles', 'SegUsuarios', 'SegUsuRol', 'ConsultaRolesDeUsuarios', 'Backups', 'Restores')
GO
