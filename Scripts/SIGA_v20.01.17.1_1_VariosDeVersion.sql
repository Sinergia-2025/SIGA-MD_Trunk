ALTER TABLE dbo.TiposComprobantes ADD DescripcionImpresion varchar(70) NULL
GO
UPDATE TiposComprobantes SET DescripcionImpresion = LTRIM(Descripcion);
UPDATE TiposComprobantes SET DescripcionImpresion = SUBSTRING(LTRIM(Descripcion), 2, 70) WHERE EsElectronico = 'True';
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN DescripcionImpresion varchar(70) NOT NULL
GO
