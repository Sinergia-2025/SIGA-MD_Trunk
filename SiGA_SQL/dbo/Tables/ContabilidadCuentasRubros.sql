CREATE TABLE [dbo].[ContabilidadCuentasRubros] (
    [idRubro]      INT          NOT NULL,
    [IdCuenta]     BIGINT          NOT NULL,
    [IdPlanCuenta] INT          NOT NULL,
    [Tipo]         VARCHAR (50) NOT NULL,
    [Debe]         BIT          NULL,
    [Haber]        BIT          NULL,
    [GrupoAsiento] INT          NULL,
    [Campo]        VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_ContabilidadCuentasRubros] PRIMARY KEY CLUSTERED ([idRubro] ASC, [IdCuenta] ASC, [IdPlanCuenta] ASC)
);



