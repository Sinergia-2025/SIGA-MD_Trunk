CREATE TABLE [dbo].[EmpresaActividades] (
    [IdProvincia] CHAR (2) NOT NULL,
    [IdActividad] INT      NOT NULL,
    [Principal]   BIT      NOT NULL,
    CONSTRAINT [PK_EmpresaActividades] PRIMARY KEY CLUSTERED ([IdProvincia] ASC, [IdActividad] ASC),
    CONSTRAINT [FK_EmpresaActividades_Actividades] FOREIGN KEY ([IdProvincia], [IdActividad]) REFERENCES [dbo].[Actividades] ([IdProvincia], [IdActividad])
);

