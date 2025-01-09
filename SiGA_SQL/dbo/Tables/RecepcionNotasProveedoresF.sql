CREATE TABLE [dbo].[RecepcionNotasProveedoresF] (
    [IdSucursal]   INT           NOT NULL,
    [NroNota]      INT           NOT NULL,
    [FechaEntrega] DATETIME      NOT NULL,
    [Observacion]  VARCHAR (150) NULL,
    [Usuario]      VARCHAR (50)  NOT NULL,
    [IdProveedor]  BIGINT        NOT NULL,
    CONSTRAINT [PK_RecepcionNotasProveedoresF] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NroNota] ASC, [IdProveedor] ASC),
    CONSTRAINT [FK_RecepcionNotasProveedoresF_Proveedores] FOREIGN KEY ([IdProveedor]) REFERENCES [dbo].[Proveedores] ([IdProveedor]),
    CONSTRAINT [FK_RecepcionNotasProveedoresF_RecepcionNotasF] FOREIGN KEY ([IdSucursal], [NroNota]) REFERENCES [dbo].[RecepcionNotasF] ([IdSucursal], [NroNota])
);

