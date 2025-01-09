CREATE TABLE [dbo].[TiposMovimientos] (
    [IdTipoMovimiento]       VARCHAR (15)  NOT NULL,
    [Descripcion]            VARCHAR (25)  NOT NULL,
    [CoeficienteStock]       INT           NOT NULL,
    [ComprobantesAsociados]  VARCHAR (100) NULL,
    [AsociaSucursal]         BIT           NOT NULL,
    [MuestraCombo]           BIT           NOT NULL,
    [HabilitaDestinatario]   BIT           NOT NULL,
    [HabilitaRubro]          BIT           NOT NULL,
    [Imprime]                BIT           NOT NULL,
    [CargaPrecio]            VARCHAR (15)  NOT NULL,
    [IdContraTipoMovimiento] VARCHAR (15)  NULL,
    [IdPlanCuenta]           INT           NULL,
    CONSTRAINT [PK_TiposMovimientos] PRIMARY KEY CLUSTERED ([IdTipoMovimiento] ASC),
    CONSTRAINT [FK_TiposMovimientos_TiposMovimientos] FOREIGN KEY ([IdContraTipoMovimiento]) REFERENCES [dbo].[TiposMovimientos] ([IdTipoMovimiento])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Si es true habilita el proveedor o cliente, si es false lo deshabilita', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TiposMovimientos', @level2type = N'COLUMN', @level2name = N'HabilitaDestinatario';

