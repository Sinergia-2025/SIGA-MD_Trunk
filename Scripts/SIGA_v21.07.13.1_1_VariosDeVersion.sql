
PRINT ''
PRINT '1. Tabla Productos: Nuevos campos Certificado Entregado'
ALTER TABLE Productos ADD CalidadNroCertEntregado int	null
GO

ALTER TABLE Productos ADD CalidadFecCertEntregado	datetime null
GO

ALTER TABLE Productos ADD CalidadUsrCertEntregado	varchar(100) null
GO



ALTER TABLE AuditoriaProductos ADD CalidadNroCertEntregado int	null
GO

ALTER TABLE AuditoriaProductos ADD CalidadFecCertEntregado	datetime null
GO

ALTER TABLE AuditoriaProductos ADD CalidadUsrCertEntregado	varchar(100) null
GO


PRINT ''
PRINT '2. Tabla Productos: Nuevos campos Liberado PDI'

ALTER TABLE Productos ADD CalidadStatusLiberadoPDI	bit	null
GO

UPDATE Productos SET CalidadStatusLiberadoPDI = 'False'
GO

ALTER TABLE Productos ALTER COLUMN CalidadStatusLiberadoPDI	bit not null
GO

ALTER TABLE Productos ADD CalidadFechaLiberadoPDI	datetime null
GO

ALTER TABLE Productos ADD CalidadUserLiberadoPDI	varchar(10)	null
GO


ALTER TABLE AuditoriaProductos ADD CalidadStatusLiberadoPDI	bit	null
GO

ALTER TABLE AuditoriaProductos ADD CalidadFechaLiberadoPDI	datetime null
GO

ALTER TABLE AuditoriaProductos ADD CalidadUserLiberadoPDI	varchar(10)	null
GO

UPDATE Productos SET CalidadStatusLiberadoPDI = CalidadStatusLiberado 
					,CalidadFechaLiberadoPDI = CalidadFechaLiberado
					,CalidadUserLiberadoPDI = CalidadUserLiberado

					
PRINT ''
PRINT '2. Tabla CalidadListasControl: Nuevo campo HabilitaFechaLiberadoPDI '
ALTER TABLE CalidadListasControl ADD HabilitaFechaLiberadoPDI	bit	null
GO

UPDATE CalidadListasControl SET HabilitaFechaLiberadoPDI = 'False'
GO

ALTER TABLE CalidadListasControl ALTER COLUMN HabilitaFechaLiberadoPDI	bit	not null
GO


