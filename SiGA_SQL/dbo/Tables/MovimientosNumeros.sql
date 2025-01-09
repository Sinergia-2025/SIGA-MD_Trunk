CREATE TABLE [dbo].[MovimientosNumeros] (
    [IdSucursal]       INT          NOT NULL,
    [IdTipoMovimiento] VARCHAR (15) NOT NULL,
    [Numero]           INT          NOT NULL,
    CONSTRAINT [PK_MovimientosNumeros] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoMovimiento] ASC),
    CONSTRAINT [FK_MovimientosNumeros_TiposMovimientos] FOREIGN KEY ([IdTipoMovimiento]) REFERENCES [dbo].[TiposMovimientos] ([IdTipoMovimiento])
);

