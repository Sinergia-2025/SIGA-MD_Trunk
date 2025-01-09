CREATE TABLE [dbo].[ContabilidadCuentasMediosDePago] (
    [IdCuentaMedioDePago] INT NOT NULL,
    [IdCuentaPesos]       BIGINT NULL,
    [IdCuentaDolares]     BIGINT NULL,
    [IdCuentaCheques]     BIGINT NULL,
    [IdCuentaTickets]     BIGINT NULL,
    [IdCuentaTarjetas]    BIGINT NULL,
    CONSTRAINT [PK_ContabilidadCuentasMediosDePago] PRIMARY KEY CLUSTERED ([IdCuentaMedioDePago] ASC)
);

