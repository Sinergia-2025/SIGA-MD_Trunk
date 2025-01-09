/****** Object:  Table dbo.ProduccionModelosFormas    Script Date: 2/1/2023 18:18:06 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('ProduccionModelosFormas') = 0
BEGIN
    CREATE TABLE ProduccionModelosFormas(
	    IdProduccionModeloForma int NOT NULL,
	    NombreProduccionModeloForma varchar(20) NOT NULL,
	    Coeficiente decimal(10, 6) NOT NULL,
     CONSTRAINT PK_ProduccionModelosFormas PRIMARY KEY CLUSTERED (IdProduccionModeloForma ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

DELETE FROM ProduccionModelosFormas
INSERT INTO ProduccionModelosFormas 
        (IdProduccionModeloForma, NombreProduccionModeloForma , Coeficiente)
    VALUES
        (1, 'CURVA', 1),
        (2, 'RECTA', 1.1)
GO

IF dbo.ExisteCampo('PedidosProductos', 'IdProduccionModeloForma') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductos ADD IdProduccionModeloForma int NULL
    ALTER TABLE dbo.PedidosProductos ADD Architran decimal(10, 3) NULL
END
GO

IF dbo.ExisteFK('FK_PedidosProductos_ProduccionModelosFormas') = 0
BEGIN
    ALTER TABLE dbo.PedidosProductos ADD CONSTRAINT FK_PedidosProductos_ProduccionModelosFormas
        FOREIGN KEY (IdProduccionModeloForma) 
        REFERENCES dbo.ProduccionModelosFormas (IdProduccionModeloForma)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
