CREATE TABLE [dbo].[ImpresorasPCs] (
    [IdSucursal]  INT          NOT NULL,
    [IdImpresora] VARCHAR (15) NOT NULL,
    [NombrePC]    VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_ImpresorasPCs_1] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdImpresora] ASC, [NombrePC] ASC),
    CONSTRAINT [FK_ImpresorasPCs_Impresoras] FOREIGN KEY ([IdSucursal], [IdImpresora]) REFERENCES [dbo].[Impresoras] ([IdSucursal], [IdImpresora])
);

