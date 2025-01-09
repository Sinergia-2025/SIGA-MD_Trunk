CREATE TABLE [dbo].[EstadosPedidos] (
    [idEstado]          VARCHAR (10) NOT NULL,
    [IdTipoComprobante] VARCHAR (15) NULL,
    [Orden]             INT          NOT NULL,
    [IdTipoEstado]      VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_EstadosPedidos] PRIMARY KEY CLUSTERED ([idEstado] ASC),
    CONSTRAINT [FK_EstadosPedidos_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante])
);



