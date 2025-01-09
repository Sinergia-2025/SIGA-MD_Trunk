CREATE TABLE [dbo].[TiposImpuestos] (
    [IdTipoImpuesto]     VARCHAR (5)  NOT NULL,
    [NombreTipoImpuesto] VARCHAR (50) NOT NULL,
    [Tipo]               VARCHAR (15) NOT NULL,
    [idCuentaDebe]       INT          NULL,
    [idCuentaHaber]      INT          NULL,
    [IdCuentaCaja]       INT          NULL,
    CONSTRAINT [PK_TiposImpuestos] PRIMARY KEY CLUSTERED ([IdTipoImpuesto] ASC)
);

