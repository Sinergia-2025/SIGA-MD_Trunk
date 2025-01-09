PRINT N'Dropping FK_Retenciones_Clientes...';
GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_Clientes];
GO
PRINT N'Dropping FK_Retenciones_CajasDetalle...';
GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_CajasDetalle];
GO
PRINT N'Dropping FK_Retenciones_Ventas...';
GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_Ventas];
GO
PRINT N'Altering [dbo].[CuentasBancarias]...';
GO
ALTER TABLE [dbo].[CuentasBancarias] ALTER COLUMN [Saldo] DECIMAL (14, 4) NULL;
ALTER TABLE [dbo].[CuentasBancarias] ALTER COLUMN [SaldoConfirmado] DECIMAL (14, 4) NULL;
GO
PRINT N'Altering [dbo].[Proveedores]...';
GO
ALTER TABLE [dbo].[Proveedores] ALTER COLUMN [EsPasibleRetencion] BIT NULL;
GO
PRINT N'Altering [dbo].[Retenciones]...';
GO
ALTER TABLE [dbo].[Retenciones] DROP COLUMN [EmisorComprobante], COLUMN [FechaComprobante], COLUMN [IdTipoComprobante], COLUMN [ImporteComprobante], COLUMN [LetraComprobante], COLUMN [NumeroComprobante];
GO
ALTER TABLE [dbo].[Retenciones] ALTER COLUMN [BaseImponible] DECIMAL (14, 4) NOT NULL;

ALTER TABLE [dbo].[Retenciones] ALTER COLUMN [ImporteTotal] DECIMAL (14, 4) NULL;

ALTER TABLE [dbo].[Retenciones] ALTER COLUMN [NroDocCliente] VARCHAR (12) NULL;

ALTER TABLE [dbo].[Retenciones] ALTER COLUMN [NroMovimientoIngreso] INT NULL;

ALTER TABLE [dbo].[Retenciones] ALTER COLUMN [NroPlanillaIngreso] INT NULL;

ALTER TABLE [dbo].[Retenciones] ALTER COLUMN [TipoDocCliente] VARCHAR (5) NULL;
GO
ALTER TABLE [dbo].[Retenciones]
    ADD [TipoRetencion]    VARCHAR (6) NULL,
        [TipoDocProveedor] VARCHAR (5) NULL,
        [NroDocProveedor]  BIGINT      NULL;
GO
PRINT N'Creating [dbo].[CuentasCorrientesProvRetenciones]...';
GO
CREATE TABLE [dbo].[CuentasCorrientesProvRetenciones] (
    [IdSucursal]        INT          NOT NULL,
    [TipoDocProveedor]  VARCHAR (5)  NOT NULL,
    [NroDocProveedor]   BIGINT       NOT NULL,
    [IdTipoComprobante] VARCHAR (15) NOT NULL,
    [Letra]             VARCHAR (1)  NOT NULL,
    [CentroEmisor]      INT          NOT NULL,
    [NumeroComprobante] BIGINT       NOT NULL,
    [IdTipoImpuesto]    VARCHAR (5)  NOT NULL,
    [EmisorRetencion]   INT          NOT NULL,
    [NumeroRetencion]   BIGINT       NOT NULL
);
GO
PRINT N'Creating PK_CuentasCorrientesProvRetenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones]
    ADD CONSTRAINT [PK_CuentasCorrientesProvRetenciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [TipoDocProveedor] ASC, [NroDocProveedor] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
GO
PRINT N'Creating FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv] FOREIGN KEY ([IdSucursal], [TipoDocProveedor], [NroDocProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) REFERENCES [dbo].[CuentasCorrientesProv] ([IdSucursal], [TipoDocProveedor], [NroDocProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_CuentasCorrientesProvRetenciones_Retenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones] FOREIGN KEY ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion]) REFERENCES [dbo].[Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_Retenciones_Proveedores...';
GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_Proveedores] FOREIGN KEY ([TipoDocProveedor], [NroDocProveedor]) REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Checking existing data against newly created constraints';
GO
ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Clientes];
ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_CajasDetalle];
ALTER TABLE [dbo].[Cuentas] WITH CHECK CHECK CONSTRAINT [FK_Cuentas_CentrosCosto];
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv];
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones];
ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Proveedores];
GO
