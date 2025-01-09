CREATE TABLE [dbo].[ContabilidadAsientosModelo] (
    [IdAsiento]     INT           NOT NULL,
    [NombreAsiento] NVARCHAR (50) NOT NULL,
    [IdPlanCuenta]  INT           NOT NULL,
    [IdCuenta]      BIGINT           NOT NULL,
    CONSTRAINT [PK_ContabilidadAsientosModelo] PRIMARY KEY CLUSTERED ([IdAsiento] ASC, [NombreAsiento] ASC, [IdPlanCuenta] ASC, [IdCuenta] ASC)
);

