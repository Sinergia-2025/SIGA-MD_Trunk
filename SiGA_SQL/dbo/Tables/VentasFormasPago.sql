CREATE TABLE [dbo].[VentasFormasPago] (
    [IdFormasPago]          INT          NOT NULL,
    [DescripcionFormasPago] VARCHAR (50) NOT NULL,
    [Dias]                  INT          NOT NULL,
    [EsTarjeta]             BIT          NOT NULL,
    [OrdenVentas]           INT          NOT NULL,
    [OrdenCompras]          INT          NOT NULL,
    [OrdenFichas]           INT          NOT NULL,
    CONSTRAINT [PK_VentasFormaPago] PRIMARY KEY CLUSTERED ([IdFormasPago] ASC)
);

