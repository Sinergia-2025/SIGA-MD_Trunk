CREATE TABLE [dbo].[RecepcionNotasEstadosF] (
    [IdSucursal]  INT           NOT NULL,
    [NroNota]     INT           NOT NULL,
    [FechaEstado] DATETIME      NOT NULL,
    [IdEstado]    INT           NULL,
    [Observacion] VARCHAR (150) NULL,
    [Usuario]     VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_RecepcionNotasFEstado] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NroNota] ASC, [FechaEstado] ASC),
    CONSTRAINT [FK_RecepcionNotasEstadosF_RecepcionEstadosF] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[RecepcionEstadosF] ([IdEstado]),
    CONSTRAINT [FK_RecepcionNotasEstadosF_RecepcionNotasF] FOREIGN KEY ([IdSucursal], [NroNota]) REFERENCES [dbo].[RecepcionNotasF] ([IdSucursal], [NroNota])
);

