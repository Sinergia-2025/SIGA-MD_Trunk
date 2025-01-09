GO
PRINT N'Dropping FK_Retenciones_Sucursales...';
GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_Sucursales];
GO
PRINT N'Dropping FK_Retenciones_TiposImpuestos...';
GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_TiposImpuestos];
GO
PRINT N'Dropping FK_Retenciones_Proveedores...';
GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_Proveedores];
GO
PRINT N'Dropping FK_Retenciones_Regimenes...';
GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_Regimenes];
GO
PRINT N'Dropping FK_CuentasCorrientesProvRetenciones_Retenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] DROP CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones];
GO
PRINT N'Dropping FK_CuentasCorrientesRetenciones_Retenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] DROP CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones];
GO
PRINT N'Dropping FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] DROP CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv];
GO
PRINT N'Dropping FK_CuentasCorrientesRetenciones_CuentasCorrientes...';
GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] DROP CONSTRAINT [FK_CuentasCorrientesRetenciones_CuentasCorrientes];
GO
PRINT N'Dropping PK_CuentasCorrientesProvRetenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] DROP CONSTRAINT [PK_CuentasCorrientesProvRetenciones];
GO
PRINT N'Dropping PK_CuentasCorrientesRetenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] DROP CONSTRAINT [PK_CuentasCorrientesRetenciones];
GO
PRINT N'Altering [dbo].[CuentasCorrientesProvRetenciones]...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] ADD [TipoRetencion] VARCHAR (6) NULL;
GO
UPDATE [dbo].[CuentasCorrientesProvRetenciones] 
   SET [TipoRetencion]='COMPRA';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] ALTER COLUMN [TipoRetencion] VARCHAR (6) NOT NULL;
GO
PRINT N'Creating PK_CuentasCorrientesProvRetenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones]
    ADD CONSTRAINT [PK_CuentasCorrientesProvRetenciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [TipoDocProveedor] ASC, [NroDocProveedor] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC, [TipoRetencion] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
GO
PRINT N'Altering [dbo].[CuentasCorrientesRetenciones]...';
GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] ADD [TipoRetencion] VARCHAR (6) NULL;
GO
UPDATE [dbo].[CuentasCorrientesRetenciones] 
   SET [TipoRetencion]='VENTA';
GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] ALTER COLUMN [TipoRetencion] VARCHAR (6) NOT NULL;
GO

PRINT N'Creating PK_CuentasCorrientesRetenciones_1...';
GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones]
    ADD CONSTRAINT [PK_CuentasCorrientesRetenciones_1] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC, [TipoRetencion] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
GO
PRINT N'Starting rebuilding table [dbo].[Retenciones]...';
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_Retenciones] (
    [IdSucursal]           INT             NOT NULL,
    [IdTipoImpuesto]       VARCHAR (5)     NOT NULL,
    [EmisorRetencion]      INT             NOT NULL,
    [NumeroRetencion]      BIGINT          NOT NULL,
    [TipoRetencion]        VARCHAR (6)     NOT NULL,
    [FechaEmision]         DATETIME        NOT NULL,
    [BaseImponible]        DECIMAL (14, 4) NOT NULL,
    [Alicuota]             DECIMAL (6, 2)  NOT NULL,
    [ImporteTotal]         DECIMAL (14, 4) NULL,
    [IdCajaIngreso]        INT             NULL,
    [NroPlanillaIngreso]   INT             NULL,
    [NroMovimientoIngreso] INT             NULL,
    [TipoDocCliente]       VARCHAR (5)     NULL,
    [NroDocCliente]        VARCHAR (12)    NULL,
    [IdEstado]             VARCHAR (10)    NOT NULL,
    [TipoDocProveedor]     VARCHAR (5)     NULL,
    [NroDocProveedor]      BIGINT          NULL,
    [IdRegimen]            INT             NULL
);

ALTER TABLE [dbo].[tmp_ms_xx_Retenciones]
    ADD CONSTRAINT [tmp_ms_xx_clusteredindex_PK_Retenciones_1] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC, [TipoRetencion] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[Retenciones])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [TipoRetencion], [FechaEmision], [BaseImponible], [Alicuota], [ImporteTotal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso], [TipoDocCliente], [NroDocCliente], [IdEstado], [TipoDocProveedor], [NroDocProveedor], [IdRegimen])
        SELECT   [IdSucursal],
                 [IdTipoImpuesto],
                 [EmisorRetencion],
                 [NumeroRetencion],
                 [TipoRetencion],
                 [FechaEmision],
                 [BaseImponible],
                 [Alicuota],
                 [ImporteTotal],
                 [IdCajaIngreso],
                 [NroPlanillaIngreso],
                 [NroMovimientoIngreso],
                 [TipoDocCliente],
                 [NroDocCliente],
                 [IdEstado],
                 [TipoDocProveedor],
                 [NroDocProveedor],
                 [IdRegimen]
        FROM     [dbo].[Retenciones]
        ORDER BY [IdSucursal] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC, [TipoRetencion] ASC;
    END

DROP TABLE [dbo].[Retenciones];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Retenciones]', N'Retenciones';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_clusteredindex_PK_Retenciones_1]', N'PK_Retenciones_1', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

GO
PRINT N'Creating FK_Retenciones_Sucursales...';
GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_Retenciones_TiposImpuestos...';
GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_TiposImpuestos] FOREIGN KEY ([IdTipoImpuesto]) REFERENCES [dbo].[TiposImpuestos] ([IdTipoImpuesto]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_Retenciones_Proveedores...';
GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_Proveedores] FOREIGN KEY ([TipoDocProveedor], [NroDocProveedor]) REFERENCES [dbo].[Proveedores] ([TipoDocProveedor], [NroDocProveedor]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_Retenciones_Regimenes...';
GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_Regimenes] FOREIGN KEY ([IdRegimen]) REFERENCES [dbo].[Regimenes] ([IdRegimen]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_CuentasCorrientesProvRetenciones_Retenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones] FOREIGN KEY ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [TipoRetencion]) REFERENCES [dbo].[Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [TipoRetencion]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_CuentasCorrientesRetenciones_Retenciones...';
GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones] FOREIGN KEY ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [TipoRetencion]) REFERENCES [dbo].[Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [TipoRetencion]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_Retenciones_CajasDetalle...';
GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_CajasDetalle] FOREIGN KEY ([IdSucursal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_Retenciones_Clientes...';
GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_Clientes] FOREIGN KEY ([TipoDocCliente], [NroDocCliente]) REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv...';
GO
ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv] FOREIGN KEY ([IdSucursal], [TipoDocProveedor], [NroDocProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) REFERENCES [dbo].[CuentasCorrientesProv] ([IdSucursal], [TipoDocProveedor], [NroDocProveedor], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
PRINT N'Creating FK_CuentasCorrientesRetenciones_CuentasCorrientes...';
GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesRetenciones_CuentasCorrientes] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) REFERENCES [dbo].[CuentasCorrientes] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Sucursales];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_TiposImpuestos];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Proveedores];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Regimenes];

ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesProvRetenciones_Retenciones];

ALTER TABLE [dbo].[CuentasCorrientesRetenciones] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_CajasDetalle];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Clientes];

ALTER TABLE [dbo].[CuentasCorrientesProvRetenciones] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesProvRetenciones_CuentasCorrientesProv];

ALTER TABLE [dbo].[CuentasCorrientesRetenciones] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesRetenciones_CuentasCorrientes];


GO
