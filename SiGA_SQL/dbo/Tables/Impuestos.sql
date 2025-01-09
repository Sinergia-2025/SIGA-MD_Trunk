CREATE TABLE [dbo].[Impuestos] (
    [IdTipoImpuesto] VARCHAR (5)    NOT NULL,
    [Alicuota]       DECIMAL (6, 2) NOT NULL,
    [Activo]         BIT            NOT NULL,
    CONSTRAINT [PK_Impuestos] PRIMARY KEY CLUSTERED ([IdTipoImpuesto] ASC, [Alicuota] ASC),
    CONSTRAINT [FK_Impuestos_TiposImpuestos] FOREIGN KEY ([IdTipoImpuesto]) REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'•Valor porcentual que se debe aplicar sobre la base imponible de acuerdo al impuesto que corresponde, para determinar el monto del tributo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Impuestos', @level2type = N'COLUMN', @level2name = N'Alicuota';

