PRINT ''
PRINT '1. Tabla CRMNovedadesSeguimiento: Nuevo campo UsuarioAsignado'
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD UsuarioAsignado varchar(10) NULL
GO
ALTER TABLE dbo.CRMNovedadesSeguimiento ADD CONSTRAINT FK_CRMNovedadesSeguimiento_UsuariosAsignado
    FOREIGN KEY (UsuarioSeguimiento)
    REFERENCES dbo.Usuarios (Id)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO


PRINT ''
PRINT '2. FKs Reservas'
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_ClientesContactos] FOREIGN KEY([IdEstablecimiento], [IdResponsable])
REFERENCES [dbo].[ClientesContactos] ([IdCliente], [IdContacto])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_ClientesContactos]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Usuarios_Alta] FOREIGN KEY([IdUsuarioAlta])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Usuarios_Alta]
GO

ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Usuarios_Estado] FOREIGN KEY([IdUsuarioEstadoTurismo])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Usuarios_Estado]
GO

PRINT ''
PRINT '3. FKs ReservasProductos'
ALTER TABLE [dbo].[ReservasProductos]  WITH CHECK ADD  CONSTRAINT [FK_ReservasProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[ReservasProductos] CHECK CONSTRAINT [FK_ReservasProductos_Productos]
GO

ALTER TABLE [dbo].[ReservasProductos]  WITH CHECK ADD  CONSTRAINT [FK_ReservasProductos_Productos_Componente] FOREIGN KEY([IdProductoComponente])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[ReservasProductos] CHECK CONSTRAINT [FK_ReservasProductos_Productos_Componente]
GO


PRINT ''
PRINT '4. Drop de FK FK_ReservasPasajeros_Clientes'
ALTER TABLE ReservasPasajeros DROP CONSTRAINT FK_ReservasPasajeros_Clientes
GO

PRINT ''
PRINT '5. FKs ReservasProductos'
ALTER TABLE [dbo].[ReservasPasajeros]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPasajeros_Clientes_Pasajero] FOREIGN KEY([IdClientePasajero])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ReservasPasajeros] CHECK CONSTRAINT [FK_ReservasPasajeros_Clientes_Pasajero]
GO

ALTER TABLE [dbo].[ReservasPasajeros]  WITH CHECK ADD  CONSTRAINT [FK_ReservasPasajeros_Clientes_Responsable] FOREIGN KEY([IdResponsablePasajero])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[ReservasPasajeros] CHECK CONSTRAINT [FK_ReservasPasajeros_Clientes_Responsable]
GO


PRINT ''
PRINT '6. Tabla ReservasPasajeros: Recrear PKs'
IF EXISTS (SELECT *
            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
           WHERE CONSTRAINT_NAME = 'PK_ReservasPasajeros1'
             AND TABLE_NAME = 'ReservasPasajeros'
             AND TABLE_SCHEMA ='dbo')
BEGIN
    ALTER TABLE [dbo].[ReservasPasajeros] DROP CONSTRAINT [PK_ReservasPasajeros1]

    /****** Object:  Index [PK_ReservasPasajeros1]    Script Date: 04/03/2020 13:58:57 ******/
    ALTER TABLE [dbo].[ReservasPasajeros] ADD  CONSTRAINT [PK_ReservasPasajeros] PRIMARY KEY CLUSTERED 
    (
	    [IdSucursal] ASC,
	    [IdTipoReserva] ASC,
	    [Letra] ASC,
	    [CentroEmisor] ASC,
	    [NumeroReserva] ASC,
	    [IdPasajero] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
END
GO



PRINT ''
PRINT '7.1. Agregar opción de Menu: Informe de No Cobranza.'
INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
 SELECT 'InfNoCobranza', 'Informe de No Cobranza', 'Informe de No Cobranza', 
	EsMenu, EsBoton, [Enabled], Visible, 'CuentasCorrientes',59, 'Eniac.Win', 'InfNoCobranza', null, null,'N','S','N','N'
   FROM Funciones
  WHERE Id = 'InfNoCompradores'

PRINT ''
PRINT '7.2. Permisos opción de Menu: Informe de No Cobranza.'
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfNoCobranza' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
