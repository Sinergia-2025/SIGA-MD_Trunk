

ALTER TABLE dbo.Productos ADD ModalidadCodigoDeBarras varchar(20) NULL
GO
UPDATE dbo.Productos SET ModalidadCodigoDeBarras = 'PRECIO' WHERE CodigoDeBarrasConPrecio = 1
GO

ALTER TABLE dbo.AuditoriaProductos ADD ModalidadCodigoDeBarras varchar(20) NULL
GO
