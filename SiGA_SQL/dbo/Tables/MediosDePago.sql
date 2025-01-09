CREATE TABLE [dbo].[MediosDePago] (
    [IdMedioDePago]     INT          NOT NULL,
    [NombreMedioDePago] VARCHAR (30) NOT NULL,
    [IdCuenta]          BIGINT          NULL,
    CONSTRAINT [PK_MediosDePago] PRIMARY KEY CLUSTERED ([IdMedioDePago] ASC),
    CONSTRAINT [FK_MediosDePago_ContabilidadCuentas] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta])
);

