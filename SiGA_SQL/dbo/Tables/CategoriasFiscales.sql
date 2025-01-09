CREATE TABLE [dbo].[CategoriasFiscales] (
    [IdCategoriaFiscal]                SMALLINT     NOT NULL,
    [NombreCategoriaFiscal]            VARCHAR (40) NOT NULL,
    [LetraFiscal]                      CHAR (1)     NOT NULL,
    [IvaDiscriminado]                  BIT          NOT NULL,
    [CondicionIvaImpresoraFiscalEpson] CHAR (1)     NOT NULL,
    [NombreCategoriaFiscalAbrev]       VARCHAR (10) NOT NULL,
    [LetraFiscalCompra]                CHAR (1)     NOT NULL,
    [Activo]                           BIT          NOT NULL,
    [UtilizaImpuestos]                 BIT          NOT NULL,
    [CondicionIvaImpresoraFiscalHasar] CHAR (1)     NOT NULL,
    [SolicitaCUIT]                     BIT          NOT NULL,
    CONSTRAINT [PK_CategoriasFiscales] PRIMARY KEY CLUSTERED ([IdCategoriaFiscal] ASC)
);

