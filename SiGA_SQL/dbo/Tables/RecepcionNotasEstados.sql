CREATE TABLE [dbo].[RecepcionNotasEstados] (
    [IdSucursal]  INT           NOT NULL,
    [NroNota]     INT           NOT NULL,
    [FechaEstado] DATETIME      NOT NULL,
    [IdEstado]    INT           NOT NULL,
    [Observacion] VARCHAR (150) NULL,
    [Usuario]     VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_RecepcionNotasEstado] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NroNota] ASC, [FechaEstado] ASC),
    CONSTRAINT [FK_RecepcionNotasEstados_RecepcionEstados] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[RecepcionEstados] ([IdEstado]),
    CONSTRAINT [FK_RecepcionNotasEstados_RecepcionNotas] FOREIGN KEY ([IdSucursal], [NroNota]) REFERENCES [dbo].[RecepcionNotas] ([IdSucursal], [NroNota])
);

