CREATE TABLE [dbo].[ContabilidadCuentas] (
    [IdCuenta]      BIGINT          NOT NULL,
    [NombreCuenta]  VARCHAR (50) NOT NULL,
    [Nivel]         INT          NOT NULL,
    [IdCentroCosto] INT          NOT NULL,
    [EsImputable]   BIT          NOT NULL,
    [Activa]        BIT          NOT NULL,
    [IdCuentaPadre] BIGINT NULL, 
    CONSTRAINT [PK_ContabilidadCuentas] PRIMARY KEY CLUSTERED ([IdCuenta] ASC),
    CONSTRAINT [FK_ContabilidadCuentas_ContabilidadCentrosCostos] FOREIGN KEY ([IdCentroCosto]) REFERENCES [dbo].[ContabilidadCentrosCostos] ([IdCentroCosto]), 
    CONSTRAINT [FK_ContabilidadCuentas_ContabilidadCuentas] FOREIGN KEY (IdCuenta) REFERENCES ContabilidadCuentas(IdCuenta) 
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'La cuenta padre en la jerarquia de cuentas',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ContabilidadCuentas',
    @level2type = N'COLUMN',
    @level2name = N'IdCuentaPadre'