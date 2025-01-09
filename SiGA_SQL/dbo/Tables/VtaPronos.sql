CREATE TABLE [dbo].[VtaPronos] (
    [Codigo]  INT             NOT NULL,
    [Cliente] NVARCHAR (30)   NULL,
    [Monto]   NUMERIC (15, 3) NULL,
    [Mes]     FLOAT (53)      NOT NULL,
    [Año]     FLOAT (53)      NOT NULL,
    [Detalla] BIT             NULL,
    CONSTRAINT [PK_VtaPronos] PRIMARY KEY CLUSTERED ([Codigo] ASC, [Mes] ASC, [Año] ASC)
);

