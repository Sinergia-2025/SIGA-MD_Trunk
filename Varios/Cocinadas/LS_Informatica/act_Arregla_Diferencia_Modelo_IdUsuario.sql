PRINT '1. Muestro las Tablas con IdUsuario Distinto a 10.'
GO
SELECT Table_name, Column_Name, Data_Type, CHARACTER_MAXIMUM_LENGTH
  FROM INFORMATION_SCHEMA.COLUMNS 
 WHERE (COLUMN_NAME LIKE '%Usuario%' AND COLUMN_NAME NOT IN ('SiMovilIdUsuario', 'nombre_usuario', 'MailUsuario', 'UsuarioWindows','NombreTipoUsuario'))
   AND DATA_TYPE NOT IN ('int', 'datetime', 'bit')
   AND CHARACTER_MAXIMUM_LENGTH <> 10
 ORDER BY TABLE_NAME
GO

PRINT '2. Borro las FKs de las tablas que hoy lo tienen (DROP_CREATE_FKs.sql). Podria Borrarlo Automatico pero prefiero revisar.'
GO

---TABLE_NAME ='xx' 
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_CalendariosUsuarios_Usuarios') 
	ALTER TABLE dbo.CalendariosUsuarios DROP CONSTRAINT FK_CalendariosUsuarios_Usuarios;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_CRMNovedades_Usuarios_Responsable') 
	ALTER TABLE dbo.CRMNovedades DROP CONSTRAINT FK_CRMNovedades_Usuarios_Responsable;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_PedidosEstadosProveedores_Usuarios')
    ALTER TABLE dbo.PedidosEstadosProveedores DROP CONSTRAINT FK_PedidosEstadosProveedores_Usuarios;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_PedidosProveedores_Usuarios') 
	ALTER TABLE dbo.PedidosProveedores DROP CONSTRAINT FK_PedidosProveedores_Usuarios;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_Repartos_Usuarios') 
   ALTER TABLE dbo.Repartos DROP CONSTRAINT FK_Repartos_Usuarios;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_Tareas_Usuarios') 
   ALTER TABLE dbo.Tareas DROP CONSTRAINT FK_Tareas_Usuarios;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_UsuariosRoles_Usuarios') 
	ALTER TABLE dbo.UsuariosRoles DROP CONSTRAINT FK_UsuariosRoles_Usuarios;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_Cheques_Usuarios') 
	ALTER TABLE dbo.Cheques DROP CONSTRAINT FK_Cheques_Usuarios;
GO


PRINT '3. Borro las PKs de las tablas que tienen el Campo IdUSuario como Clave.'
GO

---TABLE_NAME ='xx' 

IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'PK_Usuario') 
   ALTER TABLE dbo.Usuarios DROP CONSTRAINT PK_Usuario;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'PK_CalendariosUsuarios') 
   ALTER TABLE dbo.CalendariosUsuarios DROP CONSTRAINT PK_CalendariosUsuarios;
GO
IF EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'PK_UsuariosRoles') 
   ALTER TABLE dbo.UsuariosRoles DROP CONSTRAINT PK_UsuariosRoles;
GO
 
  
PRINT '4. Altero las Tablas que tienen ancho incorrecto. CON FK Previa.'
GO

ALTER TABLE dbo.Usuarios ALTER COLUMN Id VARCHAR(10) NOT NULL;
ALTER TABLE dbo.CalendariosUsuarios ALTER COLUMN IdUsuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.CRMNovedades ALTER COLUMN IdUsuarioResponsable VARCHAR(10) NOT NULL;
ALTER TABLE dbo.PedidosEstadosProveedores ALTER COLUMN IdUsuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.PedidosProveedores ALTER COLUMN IdUsuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.Repartos ALTER COLUMN IdUsuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.Tareas ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.UsuariosRoles ALTER COLUMN IdUsuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.Cheques ALTER COLUMN IdUsuarioActualizacion VARCHAR(10);

PRINT '5. Altero las Tablas que tienen ancho incorrecto. SIN (ATENCION!!!) FK Previa.'
GO

ALTER TABLE dbo.MovimientosCompras ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.MovimientosVentas ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.ProductosSucursales ALTER COLUMN Usuario VARCHAR(10) NOT NULL;
ALTER TABLE dbo.ProductosSucursalesPrecios ALTER COLUMN Usuario VARCHAR(10) NOT NULL;



PRINT '6. Vuelvo a Crear las PKs de las tablas que tienen el Campo IdUSuario como Clave (Del Punto 3).'
GO

---TABLE_NAME ='xx' 
IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'PK_Usuario') 
	ALTER TABLE Usuarios ADD CONSTRAINT PK_Usuario PRIMARY KEY CLUSTERED 
		(Id ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90);
GO

IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'PK_CalendariosUsuarios') 
	ALTER TABLE dbo.CalendariosUsuarios ADD CONSTRAINT
		PK_CalendariosUsuarios PRIMARY KEY CLUSTERED 
		(IdSucursal ASC, IdCalendario ASC, IdUsuario ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90);
GO

IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'PK_UsuariosRoles') 
	ALTER TABLE dbo.UsuariosRoles ADD CONSTRAINT
		PK_UsuariosRoles PRIMARY KEY CLUSTERED 
		(IdUsuario ASC, IdRol ASC, IdSucursal ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90);
GO


PRINT '7. Vuelvo a Creas las FKs de las tablas que hoy lo tienen (DROP_CREATE_FKs.sql). Podria Hacerlo Automatico pero prefiero revisar.'
GO

---TABLE_NAME ='xx' 
IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_CalendariosUsuarios_Usuarios') 
	ALTER TABLE dbo.CalendariosUsuarios ADD CONSTRAINT FK_CalendariosUsuarios_Usuarios 
		FOREIGN KEY	(IdUsuario) 
		REFERENCES dbo.Usuarios (Id) 
	ON UPDATE NO ACTION 
	ON DELETE NO ACTION;	
GO
IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_CRMNovedades_Usuarios_Responsable') 
	ALTER TABLE dbo.CRMNovedades ADD CONSTRAINT FK_CRMNovedades_Usuarios_Responsable
		FOREIGN KEY (IdUsuarioResponsable)
		REFERENCES dbo.Usuarios (Id)
	ON UPDATE NO ACTION 
	ON DELETE NO ACTION;	
GO

IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_PedidosEstadosProveedores_Usuarios') 
	ALTER TABLE dbo.PedidosEstadosProveedores ADD CONSTRAINT FK_PedidosEstadosProveedores_Usuarios
		FOREIGN KEY (IdUsuario)
		REFERENCES dbo.Usuarios (Id)
	ON UPDATE NO ACTION 
	ON DELETE NO ACTION;	
GO

IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_PedidosProveedores_Usuarios') 
	ALTER TABLE dbo.PedidosProveedores ADD CONSTRAINT FK_PedidosProveedores_Usuarios
		FOREIGN KEY (IdUsuario)
		REFERENCES dbo.Usuarios (Id)
	ON UPDATE NO ACTION 
	ON DELETE NO ACTION;	
GO

IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_Repartos_Usuarios') 
	ALTER TABLE dbo.Repartos ADD CONSTRAINT FK_Repartos_Usuarios
		FOREIGN KEY (IdUsuario)
		REFERENCES dbo.Usuarios (Id)
	ON UPDATE NO ACTION 
	ON DELETE NO ACTION;	
GO

IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_Tareas_Usuarios') 
	ALTER TABLE dbo.Tareas ADD CONSTRAINT FK_Tareas_Usuarios
		FOREIGN KEY (Usuario)
		REFERENCES dbo.Usuarios (Id)
	ON UPDATE NO ACTION 
	ON DELETE NO ACTION;	
GO

IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_UsuariosRoles_Usuarios') 
	ALTER TABLE dbo.UsuariosRoles ADD CONSTRAINT FK_UsuariosRoles_Usuarios
		FOREIGN KEY (IdUsuario)
		REFERENCES dbo.Usuarios (Id)
	ON UPDATE NO ACTION 
	ON DELETE NO ACTION;	
GO

IF NOT EXISTS(SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME  = 'FK_Cheques_Usuarios') 
	ALTER TABLE dbo.Cheques ADD CONSTRAINT FK_Cheques_Usuarios
		FOREIGN KEY (IdUsuarioActualizacion)
		REFERENCES dbo.Usuarios (Id)
	ON UPDATE NO ACTION 
	ON DELETE NO ACTION;	
GO

 