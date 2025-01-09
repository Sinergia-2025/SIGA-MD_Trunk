CREATE TABLE [dbo].[Transportistas] (
    [IdTransportista]                INT           NOT NULL,
    [NombreTransportista]            VARCHAR (100) NOT NULL,
    [DireccionTransportista]         VARCHAR (100) NOT NULL,
    [IdLocalidadTransportista]       INT           NOT NULL,
    [TelefonoTransportista]          VARCHAR (100) NOT NULL,
    [IdCategoriaFiscalTransportista] SMALLINT      NOT NULL,
    [CuitTransportista]              VARCHAR (13)  NULL,
    [Observacion]                    VARCHAR (200) NULL,
    CONSTRAINT [PK_Transportistas] PRIMARY KEY CLUSTERED ([IdTransportista] ASC),
    CONSTRAINT [FK_Transportistas_CategoriasFiscales] FOREIGN KEY ([IdCategoriaFiscalTransportista]) REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal]),
    CONSTRAINT [FK_Transportistas_Localidades] FOREIGN KEY ([IdLocalidadTransportista]) REFERENCES [dbo].[Localidades] ([IdLocalidad])
);

