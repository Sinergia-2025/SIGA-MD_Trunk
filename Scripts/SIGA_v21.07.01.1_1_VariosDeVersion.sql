PRINT ''
PRINT '1. Tabla CRMNovedades: Nuevo campo ClienteValorizacionEstrellas'
ALTER TABLE dbo.CRMNovedades ADD ClienteValorizacionEstrellas decimal(5, 2) NULL
GO

PRINT ''
PRINT '1.1. Tabla CRMNovedades: Asignar ClienteValorizacionEstrellas a las novedades ya finalizadas'
UPDATE N
   SET ClienteValorizacionEstrellas = C.ValorizacionEstrellas
  FROM CRMNovedades N
 INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = N.IdEstadoNovedad
 INNER JOIN Clientes C ON C.IdCliente = N.IdCliente
 WHERE EN.Finalizado = 'True'

PRINT ''
PRINT '1.2. Tabla AuditoriaCRMNovedades: Nuevo campo ClienteValorizacionEstrellas'
ALTER TABLE dbo.AuditoriaCRMNovedades ADD ClienteValorizacionEstrellas decimal(5, 2) NULL
GO


PRINT ''
PRINT '2. Tabla Clientes: Nuevo campo ValorizacionProyectoObservacion'
ALTER TABLE dbo.Clientes ADD ValorizacionProyectoObservacion varchar(1000) NULL
GO
PRINT ''
PRINT '2.1. Tabla Clientes.ValorizacionProyectoObservacion: Le pongo valores por defecto a los registros pre-existentes'
UPDATE Clientes SET ValorizacionProyectoObservacion = '';

PRINT ''
PRINT '2.2. Tabla Clientes: NOT NULL para ValorizacionProyectoObservacion'
ALTER TABLE dbo.Clientes ALTER COLUMN ValorizacionProyectoObservacion varchar(1000) NOT NULL
GO
PRINT ''
PRINT '2.3. Tabla AuditoriaClientes: Nuevo campo ValorizacionProyectoObservacion'
ALTER TABLE dbo.AuditoriaClientes ADD ValorizacionProyectoObservacion varchar(1000) NULL
GO

PRINT ''
PRINT '3. Tabla Prospectos: Nuevo campo ValorizacionProyectoObservacion'
ALTER TABLE dbo.Prospectos ADD ValorizacionProyectoObservacion varchar(1000) NULL
GO
PRINT ''
PRINT '3.1. Tabla Prospectos.ValorizacionProyectoObservacion: Le pongo valores por defecto a los registros pre-existentes'
UPDATE Prospectos SET ValorizacionProyectoObservacion = '';
PRINT ''
PRINT '3.2. Tabla Prospectos: NOT NULL para ValorizacionProyectoObservacion'
ALTER TABLE dbo.Prospectos ALTER COLUMN ValorizacionProyectoObservacion varchar(1000) NOT NULL
GO
PRINT ''
PRINT '3.3. Tabla AuditoriaProspectos: Nuevo campo ValorizacionProyectoObservacion'
ALTER TABLE dbo.AuditoriaProspectos ADD ValorizacionProyectoObservacion varchar(1000) NULL
GO

PRINT ''
PRINT '4. Tabla Categorias: Nuevos campos BackColor y ForeColor'
ALTER TABLE dbo.Categorias ADD BackColor int NULL
ALTER TABLE dbo.Categorias ADD ForeColor int NULL
GO

