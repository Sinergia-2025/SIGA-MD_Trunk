﻿CREATE TABLE [dbo].[AuditoriaClientes] (
    [FechaAuditoria]        DATETIME        NOT NULL,
    [OperacionAuditoria]    CHAR (1)        NOT NULL,
    [UsuarioAuditoria]      VARCHAR (10)    NOT NULL,
    [TipoDocumentoAnterior] VARCHAR (5)     NULL,
    [NroDocumentoAnterior]  VARCHAR (12)    NULL,
    [NombreCliente]         VARCHAR (100)   NOT NULL,
    [Direccion]             VARCHAR (100)   NOT NULL,
    [IdLocalidad]           INT             NOT NULL,
    [Telefono]              VARCHAR (100)   NULL,
    [FechaNacimiento]       DATETIME        NULL,
    [NroOperacion]          INT             NULL,
    [CorreoElectronico]     VARCHAR (500)   NULL,
    [Celular]               VARCHAR (100)   NULL,
    [NombreTrabajo]         VARCHAR (100)   NULL,
    [DireccionTrabajo]      VARCHAR (100)   NULL,
    [IdLocalidadTrabajo]    INT             NULL,
    [TelefonoTrabajo]       VARCHAR (100)   NULL,
    [CorreoTrabajo]         VARCHAR (100)   NULL,
    [FechaIngresoTrabajo]   DATETIME        NULL,
    [FechaAlta]             DATETIME        NULL,
    [SaldoPendiente]        DECIMAL (10, 2) NULL,
    [IdCategoria]           INT             NULL,
    [IdCategoriaFiscal]     SMALLINT        NULL,
    [Cuit]                  VARCHAR (13)    NULL,
    [TipoDocVendedor]       VARCHAR (5)     NOT NULL,
    [NroDocVendedor]        VARCHAR (12)    NOT NULL,
    [Observacion]           VARCHAR (1000)  NULL,
    [IdListaPrecios]        INT             NOT NULL,
    [IdZonaGeografica]      VARCHAR (20)    NOT NULL,
    [Activo]                BIT             NOT NULL,
    [LimiteDeCredito]       DECIMAL (10, 2) NULL,
    [IdSucursalAsociada]    INT             NULL,
    [NombreDeFantasia]      VARCHAR (100)   NULL,
    [DescuentoRecargoPorc]  DECIMAL (6, 2)  NULL,
    [IdTipoComprobante]     VARCHAR (15)    NULL,
    [IdFormasPago]          INT             NULL,
    [Foto]                  IMAGE           NULL,
    [IdTransportista]       INT             NULL,
    [IngresosBrutos]        VARCHAR (20)    NULL,
    [InscriptoIBStaFe]      BIT             NOT NULL,
    [LocalIB]               BIT             NOT NULL,
    [ConvMultilateralIB]    BIT             NOT NULL,
    [NumeroLote]            BIGINT          NULL,
    [IdCaja]                INT             NULL,
    [GeoLocalizacionLat]    FLOAT (53)      NULL,
    [GeoLocalizacionLng]    FLOAT (53)      NULL,
    [IdTipoDeExension]      SMALLINT        NULL,
    [AnioExension]          INT             NULL,
    [NroCertExension]       VARCHAR (6)     NULL,
    [NroCertPropio]         VARCHAR (12)    NULL,
    [IdCliente]             BIGINT          NOT NULL,
    [CodigoCliente]         BIGINT          NOT NULL,
    [IdClienteGarante]      BIGINT          NULL,
    [TipoDocCliente]        VARCHAR (5)     NULL,
    [NroDocCliente]         BIGINT          NULL,
    [DescuentoRecargoPorc2] DECIMAL (6, 2)  NULL,
    [IdClienteCtaCte]       BIGINT          NULL,
    [PaginaWeb]             VARCHAR (100)   NULL,
    [LimiteDiasVtoFactura]  INT             NULL,
    CONSTRAINT [PK_AuditoriaClientes] PRIMARY KEY CLUSTERED ([FechaAuditoria] ASC, [IdCliente] ASC),
    CONSTRAINT [FK_AuditoriaClientes_Usuarios] FOREIGN KEY ([UsuarioAuditoria]) REFERENCES [dbo].[Usuarios] ([Id])
);


