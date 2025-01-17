﻿CREATE TABLE [dbo].[Proveedores] (
    [TipoDocProveedorAnterior] VARCHAR (5)    NULL,
    [NroDocProveedorAnterior]  BIGINT         NULL,
    [NombreProveedor]          VARCHAR (100)  NOT NULL,
    [DireccionProveedor]       VARCHAR (100)  NOT NULL,
    [IdLocalidadProveedor]     INT            NOT NULL,
    [CuitProveedor]            VARCHAR (13)   NULL,
    [TelefonoProveedor]        VARCHAR (100)  NULL,
    [FaxProveedor]             VARCHAR (50)   NULL,
    [IdCategoriaFiscal]        SMALLINT       NOT NULL,
    [Observacion]              VARCHAR (200)  NULL,
    [IngresosBrutos]           VARCHAR (20)   NULL,
    [CorreoElectronico]        VARCHAR (50)   NULL,
    [Activo]                   BIT            NOT NULL,
    [IdCategoria]              INT            NOT NULL,
    [IdRubroCompra]            INT            NOT NULL,
    [IdCuentaCaja]             INT            NOT NULL,
    [EsPasibleRetencion]       BIT            NULL,
    [IdRegimen]                INT            NULL,
    [IdTipoComprobante]        VARCHAR (15)   NULL,
    [DescuentoRecargoPorc]     DECIMAL (6, 2) NOT NULL,
    [IdFormasPago]             INT            NULL,
    [Foto]                     IMAGE          NULL,
    [PorCtaOrden]              BIT            NOT NULL,
    [IdProveedor]              BIGINT         NOT NULL,
    [CodigoProveedor]          BIGINT         NOT NULL,
    [TipoDocProveedor]         VARCHAR (5)    NULL,
    [NroDocProveedor]          BIGINT         NULL,
    [FechaHigSeg]              DATETIME       NULL,
    [FechaRes559]              DATETIME       NULL,
    [FechaIndiceInc]           DATETIME       NULL,
    [EsPasibleRetencionIVA]    BIT            CONSTRAINT [DF_Proveedores_EsPasibleRetencionIVA] DEFAULT ((0)) NOT NULL,
    [IdRegimenIVA]             INT            NULL,
    CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED ([IdProveedor] ASC),
    CONSTRAINT [FK_Proveedores_CategoriasFiscales] FOREIGN KEY ([IdCategoriaFiscal]) REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal]),
    CONSTRAINT [FK_Proveedores_CategoriasProveedores] FOREIGN KEY ([IdCategoria]) REFERENCES [dbo].[CategoriasProveedores] ([IdCategoria]),
    CONSTRAINT [FK_Proveedores_CuentasDeCajas] FOREIGN KEY ([IdCuentaCaja]) REFERENCES [dbo].[CuentasDeCajas] ([IdCuentaCaja]),
    CONSTRAINT [FK_Proveedores_Localidades] FOREIGN KEY ([IdLocalidadProveedor]) REFERENCES [dbo].[Localidades] ([IdLocalidad]),
    CONSTRAINT [FK_Proveedores_Regimenes] FOREIGN KEY ([IdRegimen]) REFERENCES [dbo].[Regimenes] ([IdRegimen]),
    CONSTRAINT [FK_Proveedores_Regimenes_IVA] FOREIGN KEY ([IdRegimenIVA]) REFERENCES [dbo].[Regimenes] ([IdRegimen]),
    CONSTRAINT [FK_Proveedores_RubrosCompras] FOREIGN KEY ([IdRubroCompra]) REFERENCES [dbo].[RubrosCompras] ([IdRubro]),
    CONSTRAINT [FK_Proveedores_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante]),
    CONSTRAINT [FK_Proveedores_VentasFormasPago] FOREIGN KEY ([IdFormasPago]) REFERENCES [dbo].[VentasFormasPago] ([IdFormasPago]),
    CONSTRAINT [IX_Proveedores] UNIQUE NONCLUSTERED ([CodigoProveedor] ASC)
);

