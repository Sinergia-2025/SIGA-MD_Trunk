CREATE TABLE [dbo].[VtaPronosArt] (
    [Codigo]   INT             NOT NULL,
    [Cliente]  NVARCHAR (30)   NULL,
    [CodArt]   CHAR (20)       NOT NULL,
    [Cantidad] NUMERIC (15, 3) NULL,
    [Precio]   NUMERIC (15, 4) NULL,
    [Monto]    NUMERIC (15, 3) NULL,
    [Mes]      FLOAT (53)      NOT NULL,
    [Año]      FLOAT (53)      NOT NULL,
    CONSTRAINT [PK_VtaPronosArt] PRIMARY KEY CLUSTERED ([Codigo] ASC, [CodArt] ASC, [Mes] ASC, [Año] ASC)
);

