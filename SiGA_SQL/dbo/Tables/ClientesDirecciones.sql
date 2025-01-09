CREATE TABLE [dbo].[ClientesDirecciones] (
    [IdCliente]   BIGINT        NOT NULL,
    [IdDireccion] INT           NOT NULL,
    [Direccion]   VARCHAR (100) NOT NULL,
    [IdLocalidad] INT           NOT NULL,
    CONSTRAINT [PK_ClientesDirecciones] PRIMARY KEY CLUSTERED ([IdCliente] ASC, [IdDireccion] ASC)
);

