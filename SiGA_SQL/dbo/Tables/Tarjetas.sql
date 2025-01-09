CREATE TABLE [dbo].[Tarjetas] (
    [IdTarjeta]        INT          NOT NULL,
    [NombreTarjeta]    VARCHAR (50) NOT NULL,
    [TipoTarjeta]      VARCHAR (1)  CONSTRAINT [DF_Tarjetas_TipoTarjeta] DEFAULT ('C') NOT NULL,
    [Habilitada]       BIT          CONSTRAINT [DF_Tarjetas_Habilitada] DEFAULT ((1)) NOT NULL,
    [Acreditacion]     BIT          NOT NULL,
    [IdCuentaBancaria] INT          NULL,
    [CantDiasAcredit]  INT          NULL,
    [PagoPosVenta]     BIT          NOT NULL,
    [PagoPosCorte]     BIT          NOT NULL,
    [DiaCorte]         INT          NULL,
    [PagoDiaMes]       BIT          NOT NULL,
    [DiaMes]           INT          NULL,
    CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED ([IdTarjeta] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Por ejemplo Visa, Mastercard, American Express', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tarjetas', @level2type = N'COLUMN', @level2name = N'NombreTarjeta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Es del Tipo Credito o Debito', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tarjetas', @level2type = N'COLUMN', @level2name = N'TipoTarjeta';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Si esta habilitada para pagar o no', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Tarjetas', @level2type = N'COLUMN', @level2name = N'Habilitada';

