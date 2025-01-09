CREATE TABLE [dbo].[SueldosConceptos] (
    [IdTipoConcepto]   INT            NOT NULL,
    [IdConcepto]       INT            NOT NULL,
    [NombreConcepto]   VARCHAR (30)   NOT NULL,
    [Valor]            DECIMAL (8, 2) NOT NULL,
    [Tipo]             CHAR (1)       NOT NULL,
    [Aguinaldo]        CHAR (1)       NOT NULL,
    [IdQuepide]        INT            NULL,
    [Calculo1]         VARCHAR (114)  NULL,
    [Formula]          VARCHAR (200)  NULL,
    [LiquidacionAnual] BIT            NULL,
    [LiquidacionMeses] VARCHAR (12)   NULL,
    CONSTRAINT [PK_SueldosConceptos] PRIMARY KEY CLUSTERED ([IdTipoConcepto] ASC, [IdConcepto] ASC)
);

