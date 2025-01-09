GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
PRINT N'Dropping FK_Cajas_Sucursales...';


GO
ALTER TABLE [dbo].[Cajas] DROP CONSTRAINT [FK_Cajas_Sucursales];


GO
PRINT N'Dropping FK_CajasDetalle_Cajas...';


GO
ALTER TABLE [dbo].[CajasDetalle] DROP CONSTRAINT [FK_CajasDetalle_Cajas];


GO
PRINT N'Dropping FK_Ventas_CajasDetalle...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_CajasDetalle];


GO
PRINT N'Dropping FK_CajasDetalle_CuentasDeCajas...';


GO
ALTER TABLE [dbo].[CajasDetalle] DROP CONSTRAINT [FK_CajasDetalle_CuentasDeCajas];


GO
PRINT N'Dropping FK_Retenciones_CajasDetalle...';


GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_CajasDetalle];


GO
PRINT N'Dropping FK_Cheques_CajasDetalle_Ingreso...';


GO
ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_Cheques_CajasDetalle_Ingreso];


GO
PRINT N'Dropping FK_Cheques_CajasDetalle_Egreso...';


GO
ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_Cheques_CajasDetalle_Egreso];


GO
PRINT N'Dropping FK_LibrosBancos_Cheques...';


GO
ALTER TABLE [dbo].[LibrosBancos] DROP CONSTRAINT [FK_LibrosBancos_Cheques];


GO
PRINT N'Dropping FK_Cheques_CuentasBancarias...';


GO
ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_Cheques_CuentasBancarias];


GO
PRINT N'Dropping FK_Cheques_Bancos...';


GO
ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_Cheques_Bancos];


GO
PRINT N'Dropping FK_Cheques_Localidades...';


GO
ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_Cheques_Localidades];


GO
PRINT N'Dropping FK_Cheques_Sucursales...';


GO
ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_Cheques_Sucursales];


GO
PRINT N'Dropping FK_Cheques_EstadosCheques...';


GO
ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_Cheques_EstadosCheques];


GO
PRINT N'Dropping FK_Cheques_EstadosChequesAnt...';


GO
ALTER TABLE [dbo].[Cheques] DROP CONSTRAINT [FK_Cheques_EstadosChequesAnt];


GO
PRINT N'Dropping FK_VentasCheques_Cheques...';


GO
ALTER TABLE [dbo].[VentasCheques] DROP CONSTRAINT [FK_VentasCheques_Cheques];


GO
PRINT N'Dropping FK_VentasChequesRechazados_Cheques...';


GO
ALTER TABLE [dbo].[VentasChequesRechazados] DROP CONSTRAINT [FK_VentasChequesRechazados_Cheques];


GO
PRINT N'Dropping FK_DepositosCheques_Cheques...';


GO
ALTER TABLE [dbo].[DepositosCheques] DROP CONSTRAINT [FK_DepositosCheques_Cheques];


GO
PRINT N'Dropping FK_CuentasCorrientesProvCheques_Cheques...';


GO
ALTER TABLE [dbo].[CuentasCorrientesProvCheques] DROP CONSTRAINT [FK_CuentasCorrientesProvCheques_Cheques];


GO
PRINT N'Dropping FK_CuentasCorrientesCheques_Cheques...';


GO
ALTER TABLE [dbo].[CuentasCorrientesCheques] DROP CONSTRAINT [FK_CuentasCorrientesCheques_Cheques];


GO
PRINT N'Dropping FK_CuentasCorrientesRetenciones_Retenciones...';


GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] DROP CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones];


GO
PRINT N'Dropping FK_Retenciones_Clientes...';


GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_Clientes];


GO
PRINT N'Dropping FK_Retenciones_Sucursales...';


GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_Sucursales];


GO
PRINT N'Dropping FK_Retenciones_TiposImpuestos...';


GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_TiposImpuestos];


GO
PRINT N'Dropping FK_Retenciones_Ventas...';


GO
ALTER TABLE [dbo].[Retenciones] DROP CONSTRAINT [FK_Retenciones_Ventas];


GO
PRINT N'Dropping FK_Ventas_Transportistas...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_Transportistas];


GO
PRINT N'Dropping FK_Ventas_Ventas...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_Ventas];


GO
PRINT N'Dropping FK_Ventas_Sucursales...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_Sucursales];


GO
PRINT N'Dropping FK_Ventas_TiposComprobantes...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_TiposComprobantes];


GO
PRINT N'Dropping FK_Ventas_Empleados...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_Empleados];


GO
PRINT N'Dropping FK_Ventas_VentasFormasPago...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_VentasFormasPago];


GO
PRINT N'Dropping FK_Ventas_CategoriasFiscales...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_CategoriasFiscales];


GO
PRINT N'Dropping FK_Ventas_Clientes...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_Clientes];


GO
PRINT N'Dropping FK_Ventas_TiposComprobantes1...';


GO
ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_Ventas_TiposComprobantes1];


GO
PRINT N'Dropping FK_VentasObservaciones_Ventas...';


GO
ALTER TABLE [dbo].[VentasObservaciones] DROP CONSTRAINT [FK_VentasObservaciones_Ventas];


GO
PRINT N'Dropping FK_RecepcionNotas_Ventas...';


GO
ALTER TABLE [dbo].[RecepcionNotas] DROP CONSTRAINT [FK_RecepcionNotas_Ventas];


GO
PRINT N'Dropping FK_VentasProductos_Ventas...';


GO
ALTER TABLE [dbo].[VentasProductos] DROP CONSTRAINT [FK_VentasProductos_Ventas];


GO
PRINT N'Dropping FK_VentasCheques_Ventas...';


GO
ALTER TABLE [dbo].[VentasCheques] DROP CONSTRAINT [FK_VentasCheques_Ventas];


GO
PRINT N'Dropping FK_VentasChequesRechazados_Ventas...';


GO
ALTER TABLE [dbo].[VentasChequesRechazados] DROP CONSTRAINT [FK_VentasChequesRechazados_Ventas];


GO
PRINT N'Dropping FK_Clientes_Sucursales...';


GO
ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_Clientes_Sucursales];


GO
PRINT N'Starting rebuilding table [dbo].[Cajas]...';


GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_Cajas] (
    [IdSucursal]           INT             NOT NULL,
    [IdCaja]               INT             CONSTRAINT [DF_Cajas_IdCaja] DEFAULT ((1)) NOT NULL,
    [NumeroPlanilla]       INT             NOT NULL,
    [FechaPlanilla]        DATETIME        NOT NULL,
    [PesosSaldoInicial]    DECIMAL (10, 2) NOT NULL,
    [PesosSaldoFinal]      DECIMAL (10, 2) NOT NULL,
    [DolaresSaldoInicial]  DECIMAL (10, 2) NOT NULL,
    [DolaresSaldoFinal]    DECIMAL (10, 2) NOT NULL,
    [EurosSaldoInicial]    DECIMAL (10, 2) NOT NULL,
    [EurosSaldoFinal]      DECIMAL (10, 2) NOT NULL,
    [ChequesSaldoInicial]  DECIMAL (10, 2) NOT NULL,
    [ChequesSaldoFinal]    DECIMAL (10, 2) NOT NULL,
    [TarjetasSaldoInicial] DECIMAL (10, 2) NOT NULL,
    [TarjetasSaldoFinal]   DECIMAL (10, 2) NOT NULL,
    [TicketsSaldoInicial]  DECIMAL (10, 2) NOT NULL,
    [TicketsSaldoFinal]    DECIMAL (10, 2) NOT NULL
);

ALTER TABLE [dbo].[tmp_ms_xx_Cajas]
    ADD CONSTRAINT [tmp_ms_xx_clusteredindex_PK_Cajas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCaja] ASC, [NumeroPlanilla] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[Cajas])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Cajas] ([IdSucursal], [NumeroPlanilla], [FechaPlanilla], [PesosSaldoInicial], [PesosSaldoFinal], [DolaresSaldoInicial], [DolaresSaldoFinal], [EurosSaldoInicial], [EurosSaldoFinal], [ChequesSaldoInicial], [ChequesSaldoFinal], [TarjetasSaldoInicial], [TarjetasSaldoFinal], [TicketsSaldoInicial], [TicketsSaldoFinal])
        SELECT   [IdSucursal],
                 [NumeroPlanilla],
                 [FechaPlanilla],
                 [PesosSaldoInicial],
                 [PesosSaldoFinal],
                 [DolaresSaldoInicial],
                 [DolaresSaldoFinal],
                 [EurosSaldoInicial],
                 [EurosSaldoFinal],
                 [ChequesSaldoInicial],
                 [ChequesSaldoFinal],
                 [TarjetasSaldoInicial],
                 [TarjetasSaldoFinal],
                 [TicketsSaldoInicial],
                 [TicketsSaldoFinal]
        FROM     [dbo].[Cajas]
        ORDER BY [IdSucursal] ASC, [NumeroPlanilla] ASC;
    END

DROP TABLE [dbo].[Cajas];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Cajas]', N'Cajas';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_clusteredindex_PK_Cajas]', N'PK_Cajas', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[CajasDetalle]...';


GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_CajasDetalle] (
    [IdSucursal]       INT             NOT NULL,
    [IdCaja]           INT             CONSTRAINT [DF_CajasDetalle_IdCaja] DEFAULT ((1)) NOT NULL,
    [NumeroPlanilla]   INT             NOT NULL,
    [NumeroMovimiento] INT             NOT NULL,
    [FechaMovimiento]  DATETIME        NOT NULL,
    [IdCuentaCaja]     INT             NOT NULL,
    [IdTipoMovimiento] CHAR (1)        NOT NULL,
    [ImportePesos]     DECIMAL (10, 2) NOT NULL,
    [ImporteDolares]   DECIMAL (10, 2) NOT NULL,
    [ImporteEuros]     DECIMAL (10, 2) NOT NULL,
    [ImporteCheques]   DECIMAL (10, 2) NOT NULL,
    [ImporteTarjetas]  DECIMAL (10, 2) NOT NULL,
    [Observacion]      VARCHAR (100)   NULL,
    [EsModificable]    BIT             NOT NULL,
    [ImporteTickets]   DECIMAL (10, 2) NOT NULL
);

ALTER TABLE [dbo].[tmp_ms_xx_CajasDetalle]
    ADD CONSTRAINT [tmp_ms_xx_clusteredindex_PK_CajasDetalle] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCaja] ASC, [NumeroPlanilla] ASC, [NumeroMovimiento] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[CajasDetalle])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_CajasDetalle] ([IdSucursal], [NumeroPlanilla], [NumeroMovimiento], [FechaMovimiento], [IdCuentaCaja], [IdTipoMovimiento], [ImportePesos], [ImporteDolares], [ImporteEuros], [ImporteCheques], [ImporteTarjetas], [Observacion], [EsModificable], [ImporteTickets])
        SELECT   [IdSucursal],
                 [NumeroPlanilla],
                 [NumeroMovimiento],
                 [FechaMovimiento],
                 [IdCuentaCaja],
                 [IdTipoMovimiento],
                 [ImportePesos],
                 [ImporteDolares],
                 [ImporteEuros],
                 [ImporteCheques],
                 [ImporteTarjetas],
                 [Observacion],
                 [EsModificable],
                 [ImporteTickets]
        FROM     [dbo].[CajasDetalle]
        ORDER BY [IdSucursal] ASC, [NumeroPlanilla] ASC, [NumeroMovimiento] ASC;
    END

DROP TABLE [dbo].[CajasDetalle];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_CajasDetalle]', N'CajasDetalle';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_clusteredindex_PK_CajasDetalle]', N'PK_CajasDetalle', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Cheques]...';


GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_Cheques] (
    [IdSucursal]           INT             NOT NULL,
    [NumeroCheque]         INT             NOT NULL,
    [IdBanco]              INT             NOT NULL,
    [IdBancoSucursal]      INT             NOT NULL,
    [IdLocalidad]          INT             NOT NULL,
    [FechaEmision]         DATETIME        NOT NULL,
    [FechaCobro]           DATETIME        NOT NULL,
    [Titular]              VARCHAR (40)    NULL,
    [Importe]              DECIMAL (10, 2) NOT NULL,
    [IdCajaIngreso]        INT             NULL,
    [NroPlanillaIngreso]   INT             NULL,
    [NroMovimientoIngreso] INT             NULL,
    [IdCajaEgreso]         INT             NULL,
    [NroPlanillaEgreso]    INT             NULL,
    [NroMovimientoEgreso]  INT             NULL,
    [EsPropio]             BIT             NOT NULL,
    [IdCuentaBancaria]     INT             NULL,
    [IdEstadoCheque]       VARCHAR (10)    NOT NULL,
    [IdEstadoChequeAnt]    VARCHAR (10)    NULL,
    [TipoDocCliente]       VARCHAR (5)     NULL,
    [NroDocCliente]        VARCHAR (12)    NULL,
    [TipoDocProveedor]     VARCHAR (5)     NULL,
    [NroDocProveedor]      BIGINT          NULL
);

ALTER TABLE [dbo].[tmp_ms_xx_Cheques]
    ADD CONSTRAINT [tmp_ms_xx_clusteredindex_PK_Cheques] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [NumeroCheque] ASC, [IdBanco] ASC, [IdBancoSucursal] ASC, [IdLocalidad] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[Cheques])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad], [FechaEmision], [FechaCobro], [Titular], [Importe], [NroPlanillaIngreso], [NroMovimientoIngreso], [NroPlanillaEgreso], [NroMovimientoEgreso], [EsPropio], [IdCuentaBancaria], [IdEstadoCheque], [IdEstadoChequeAnt], [TipoDocCliente], [NroDocCliente], [TipoDocProveedor], [NroDocProveedor])
        SELECT   [IdSucursal],
                 [NumeroCheque],
                 [IdBanco],
                 [IdBancoSucursal],
                 [IdLocalidad],
                 [FechaEmision],
                 [FechaCobro],
                 [Titular],
                 [Importe],
                 [NroPlanillaIngreso],
                 [NroMovimientoIngreso],
                 [NroPlanillaEgreso],
                 [NroMovimientoEgreso],
                 [EsPropio],
                 [IdCuentaBancaria],
                 [IdEstadoCheque],
                 [IdEstadoChequeAnt],
                 [TipoDocCliente],
                 [NroDocCliente],
                 [TipoDocProveedor],
                 [NroDocProveedor]
        FROM     [dbo].[Cheques]
        ORDER BY [IdSucursal] ASC, [NumeroCheque] ASC, [IdBanco] ASC, [IdBancoSucursal] ASC, [IdLocalidad] ASC;
    END

DROP TABLE [dbo].[Cheques];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Cheques]', N'Cheques';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_clusteredindex_PK_Cheques]', N'PK_Cheques', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


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
    [FechaEmision]         DATETIME        NOT NULL,
    [IdTipoComprobante]    VARCHAR (15)    NULL,
    [LetraComprobante]     VARCHAR (1)     NULL,
    [EmisorComprobante]    INT             NULL,
    [NumeroComprobante]    BIGINT          NULL,
    [FechaComprobante]     DATETIME        NULL,
    [ImporteComprobante]   DECIMAL (10, 2) NULL,
    [BaseImponible]        DECIMAL (10, 2) NOT NULL,
    [Alicuota]             DECIMAL (6, 2)  NOT NULL,
    [ImporteTotal]         DECIMAL (10, 2) NOT NULL,
    [IdCajaIngreso]        INT             NULL,
    [NroPlanillaIngreso]   INT             NOT NULL,
    [NroMovimientoIngreso] INT             NOT NULL,
    [TipoDocCliente]       VARCHAR (5)     NOT NULL,
    [NroDocCliente]        VARCHAR (12)    NOT NULL,
    [IdEstado]             VARCHAR (10)    NOT NULL
);

ALTER TABLE [dbo].[tmp_ms_xx_Retenciones]
    ADD CONSTRAINT [tmp_ms_xx_clusteredindex_PK_Retenciones] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[Retenciones])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion], [FechaEmision], [IdTipoComprobante], [LetraComprobante], [EmisorComprobante], [NumeroComprobante], [FechaComprobante], [ImporteComprobante], [BaseImponible], [Alicuota], [ImporteTotal], [NroPlanillaIngreso], [NroMovimientoIngreso], [TipoDocCliente], [NroDocCliente], [IdEstado])
        SELECT   [IdSucursal],
                 [IdTipoImpuesto],
                 [EmisorRetencion],
                 [NumeroRetencion],
                 [FechaEmision],
                 [IdTipoComprobante],
                 [LetraComprobante],
                 [EmisorComprobante],
                 [NumeroComprobante],
                 [FechaComprobante],
                 [ImporteComprobante],
                 [BaseImponible],
                 [Alicuota],
                 [ImporteTotal],
                 [NroPlanillaIngreso],
                 [NroMovimientoIngreso],
                 [TipoDocCliente],
                 [NroDocCliente],
                 [IdEstado]
        FROM     [dbo].[Retenciones]
        ORDER BY [IdSucursal] ASC, [IdTipoImpuesto] ASC, [EmisorRetencion] ASC, [NumeroRetencion] ASC;
    END

DROP TABLE [dbo].[Retenciones];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Retenciones]', N'Retenciones';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_clusteredindex_PK_Retenciones]', N'PK_Retenciones', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Ventas]...';


GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_Ventas] (
    [IdSucursal]            INT             NOT NULL,
    [IdTipoComprobante]     VARCHAR (15)    NOT NULL,
    [Letra]                 VARCHAR (1)     NOT NULL,
    [CentroEmisor]          INT             NOT NULL,
    [NumeroComprobante]     BIGINT          NOT NULL,
    [Fecha]                 DATETIME        NOT NULL,
    [TipoDocVendedor]       VARCHAR (5)     NOT NULL,
    [NroDocVendedor]        VARCHAR (12)    NOT NULL,
    [SubTotal]              DECIMAL (12, 2) NOT NULL,
    [DescuentoRecargo]      DECIMAL (12, 2) NOT NULL,
    [ImporteTotal]          DECIMAL (12, 2) NOT NULL,
    [TipoDocCliente]        VARCHAR (5)     NOT NULL,
    [NroDocCliente]         VARCHAR (12)    NOT NULL,
    [IdCategoriaFiscal]     SMALLINT        NOT NULL,
    [IdFormasPago]          INT             NOT NULL,
    [Observacion]           VARCHAR (100)   NULL,
    [ImporteBruto]          DECIMAL (12, 2) NOT NULL,
    [DescuentoRecargoPorc]  DECIMAL (6, 2)  NOT NULL,
    [IdEstadoComprobante]   VARCHAR (10)    NULL,
    [IdTipoComprobanteFact] VARCHAR (15)    NULL,
    [LetraFact]             VARCHAR (1)     NULL,
    [CentroEmisorFact]      INT             NULL,
    [NumeroComprobanteFact] BIGINT          NULL,
    [IdCaja]                INT             NULL,
    [NumeroPlanilla]        INT             NULL,
    [NumeroMovimiento]      INT             NULL,
    [ImportePesos]          DECIMAL (12, 2) NOT NULL,
    [ImporteTickets]        DECIMAL (12, 2) NOT NULL,
    [ImporteTarjetas]       DECIMAL (12, 2) NOT NULL,
    [ImporteCheques]        DECIMAL (12, 2) NOT NULL,
    [Kilos]                 DECIMAL (10, 3) NOT NULL,
    [Bultos]                INT             NOT NULL,
    [ValorDeclarado]        DECIMAL (12, 2) NOT NULL,
    [IdTransportista]       INT             NULL,
    [NumeroLote]            BIGINT          NOT NULL,
    [TotalImpuestos]        DECIMAL (12, 2) NOT NULL,
    [CantidadInvocados]     INT             NOT NULL,
    [CantidadLotes]         INT             NOT NULL,
    [Usuario]               VARCHAR (10)    NOT NULL,
    [FechaAlta]             DATETIME        NOT NULL,
    [CAE]                   VARCHAR (30)    NULL,
    [CAEVencimiento]        DATETIME        NULL,
    [Utilidad]              DECIMAL (12, 2) NOT NULL,
    [FechaTransmisionAFIP]  DATETIME        NULL,
    [CotizacionDolar]       DECIMAL (7, 3)  NOT NULL,
    [ComisionVendedor]      DECIMAL (10, 4) NOT NULL,
    [FechaImpresion]        DATETIME        NULL
);

ALTER TABLE [dbo].[tmp_ms_xx_Ventas]
    ADD CONSTRAINT [tmp_ms_xx_clusteredindex_PK_Ventas] PRIMARY KEY CLUSTERED ([IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdSucursal] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[Ventas])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal], [Fecha], [TipoDocVendedor], [NroDocVendedor], [SubTotal], [DescuentoRecargo], [ImporteTotal], [TipoDocCliente], [NroDocCliente], [IdCategoriaFiscal], [IdFormasPago], [Observacion], [ImporteBruto], [DescuentoRecargoPorc], [IdEstadoComprobante], [IdTipoComprobanteFact], [LetraFact], [CentroEmisorFact], [NumeroComprobanteFact], [NumeroPlanilla], [NumeroMovimiento], [ImportePesos], [ImporteTickets], [ImporteTarjetas], [ImporteCheques], [Kilos], [Bultos], [ValorDeclarado], [IdTransportista], [NumeroLote], [TotalImpuestos], [CantidadInvocados], [CantidadLotes], [Usuario], [FechaAlta], [CAE], [CAEVencimiento], [Utilidad], [FechaTransmisionAFIP], [CotizacionDolar], [ComisionVendedor], [FechaImpresion])
        SELECT   [IdTipoComprobante],
                 [Letra],
                 [CentroEmisor],
                 [NumeroComprobante],
                 [IdSucursal],
                 [Fecha],
                 [TipoDocVendedor],
                 [NroDocVendedor],
                 [SubTotal],
                 [DescuentoRecargo],
                 [ImporteTotal],
                 [TipoDocCliente],
                 [NroDocCliente],
                 [IdCategoriaFiscal],
                 [IdFormasPago],
                 [Observacion],
                 [ImporteBruto],
                 [DescuentoRecargoPorc],
                 [IdEstadoComprobante],
                 [IdTipoComprobanteFact],
                 [LetraFact],
                 [CentroEmisorFact],
                 [NumeroComprobanteFact],
                 [NumeroPlanilla],
                 [NumeroMovimiento],
                 [ImportePesos],
                 [ImporteTickets],
                 [ImporteTarjetas],
                 [ImporteCheques],
                 [Kilos],
                 [Bultos],
                 [ValorDeclarado],
                 [IdTransportista],
                 [NumeroLote],
                 [TotalImpuestos],
                 [CantidadInvocados],
                 [CantidadLotes],
                 [Usuario],
                 [FechaAlta],
                 [CAE],
                 [CAEVencimiento],
                 [Utilidad],
                 [FechaTransmisionAFIP],
                 [CotizacionDolar],
                 [ComisionVendedor],
                 [FechaImpresion]
        FROM     [dbo].[Ventas]
        ORDER BY [IdTipoComprobante] ASC, [Letra] ASC, [CentroEmisor] ASC, [NumeroComprobante] ASC, [IdSucursal] ASC;
    END

DROP TABLE [dbo].[Ventas];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Ventas]', N'Ventas';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_clusteredindex_PK_Ventas]', N'PK_Ventas', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[CajasNombres]...';


GO
CREATE TABLE [dbo].[CajasNombres] (
    [IdSucursal] INT          NOT NULL,
    [IdCaja]     INT          NOT NULL,
    [NombreCaja] VARCHAR (50) NULL
);

GO
INSERT INTO CajasNombres (IdSucursal,IdCaja,NombreCaja)
     SELECT IdSucursal, 1,'Principal' FROM Sucursales
;

GO
PRINT N'Creating PK_SubCajas...';


GO
ALTER TABLE [dbo].[CajasNombres]
    ADD CONSTRAINT [PK_SubCajas] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCaja] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[CajasUsuarios]...';


GO
CREATE TABLE [dbo].[CajasUsuarios] (
    [IdSucursal] INT          NOT NULL,
    [IdCaja]     INT          NOT NULL,
    [IdUsuario]  VARCHAR (10) NOT NULL
);

GO
INSERT INTO CajasUsuarios (IdSucursal, IdCaja, IdUsuario)
SELECT IdSucursal, 1, IdUsuario FROM UsuariosRoles ORDER BY IdSucursal, IdUsuario;

GO
PRINT N'Creating PK_SubCajasUsuarios...';


GO
ALTER TABLE [dbo].[CajasUsuarios]
    ADD CONSTRAINT [PK_SubCajasUsuarios] PRIMARY KEY CLUSTERED ([IdSucursal] ASC, [IdCaja] ASC, [IdUsuario] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating FK_Cajas_Sucursales...';


GO
ALTER TABLE [dbo].[Cajas] WITH NOCHECK
    ADD CONSTRAINT [FK_Cajas_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_CajasDetalle_Cajas...';


GO
ALTER TABLE [dbo].[CajasDetalle] WITH NOCHECK
    ADD CONSTRAINT [FK_CajasDetalle_Cajas] FOREIGN KEY ([IdSucursal], [IdCaja], [NumeroPlanilla]) REFERENCES [dbo].[Cajas] ([IdSucursal], [IdCaja], [NumeroPlanilla]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cajas_CajasNombres...';


GO
ALTER TABLE [dbo].[Cajas] WITH NOCHECK
    ADD CONSTRAINT [FK_Cajas_CajasNombres] FOREIGN KEY ([IdSucursal], [IdCaja]) REFERENCES [dbo].[CajasNombres] ([IdSucursal], [IdCaja]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_CajasDetalle...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_CajasDetalle] FOREIGN KEY ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_CajasDetalle_CuentasDeCajas...';


GO
ALTER TABLE [dbo].[CajasDetalle] WITH NOCHECK
    ADD CONSTRAINT [FK_CajasDetalle_CuentasDeCajas] FOREIGN KEY ([IdCuentaCaja]) REFERENCES [dbo].[CuentasDeCajas] ([IdCuentaCaja]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Retenciones_CajasDetalle...';


GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_CajasDetalle] FOREIGN KEY ([IdSucursal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_LibrosBancos_Cheques...';


GO
ALTER TABLE [dbo].[LibrosBancos] WITH NOCHECK
    ADD CONSTRAINT [FK_LibrosBancos_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBancoCheque], [IdBancoSucursalCheque], [IdLocalidadCheque]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cheques_CuentasBancarias...';


GO
ALTER TABLE [dbo].[Cheques] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheques_CuentasBancarias] FOREIGN KEY ([IdCuentaBancaria]) REFERENCES [dbo].[CuentasBancarias] ([IdCuentaBancaria]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cheques_Bancos...';


GO
ALTER TABLE [dbo].[Cheques] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheques_Bancos] FOREIGN KEY ([IdBanco]) REFERENCES [dbo].[Bancos] ([IdBanco]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cheques_Localidades...';


GO
ALTER TABLE [dbo].[Cheques] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheques_Localidades] FOREIGN KEY ([IdLocalidad]) REFERENCES [dbo].[Localidades] ([IdLocalidad]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cheques_Sucursales...';


GO
ALTER TABLE [dbo].[Cheques] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheques_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cheques_EstadosCheques...';


GO
ALTER TABLE [dbo].[Cheques] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheques_EstadosCheques] FOREIGN KEY ([IdEstadoCheque]) REFERENCES [dbo].[EstadosCheques] ([IdEstadoCheque]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cheques_EstadosChequesAnt...';


GO
ALTER TABLE [dbo].[Cheques] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheques_EstadosChequesAnt] FOREIGN KEY ([IdEstadoChequeAnt]) REFERENCES [dbo].[EstadosCheques] ([IdEstadoCheque]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VentasCheques_Cheques...';


GO
ALTER TABLE [dbo].[VentasCheques] WITH NOCHECK
    ADD CONSTRAINT [FK_VentasCheques_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VentasChequesRechazados_Cheques...';


GO
ALTER TABLE [dbo].[VentasChequesRechazados] WITH NOCHECK
    ADD CONSTRAINT [FK_VentasChequesRechazados_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_DepositosCheques_Cheques...';


GO
ALTER TABLE [dbo].[DepositosCheques] WITH NOCHECK
    ADD CONSTRAINT [FK_DepositosCheques_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_CuentasCorrientesProvCheques_Cheques...';


GO
ALTER TABLE [dbo].[CuentasCorrientesProvCheques] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesProvCheques_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_CuentasCorrientesCheques_Cheques...';


GO
ALTER TABLE [dbo].[CuentasCorrientesCheques] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesCheques_Cheques] FOREIGN KEY ([IdSucursal], [NumeroCheque], [IdBancoCheque], [IdBancoSucursalCheque], [IdLocalidadCheque]) REFERENCES [dbo].[Cheques] ([IdSucursal], [NumeroCheque], [IdBanco], [IdBancoSucursal], [IdLocalidad]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cheques_CajasDetalle...';


GO
ALTER TABLE [dbo].[Cheques] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheques_CajasDetalle] FOREIGN KEY ([IdSucursal], [IdCajaIngreso], [NroPlanillaIngreso], [NroMovimientoIngreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Cheques_CajasDetalleEgreso...';


GO
ALTER TABLE [dbo].[Cheques] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheques_CajasDetalleEgreso] FOREIGN KEY ([IdSucursal], [IdCajaEgreso], [NroPlanillaEgreso], [NroMovimientoEgreso]) REFERENCES [dbo].[CajasDetalle] ([IdSucursal], [IdCaja], [NumeroPlanilla], [NumeroMovimiento]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_CuentasCorrientesRetenciones_Retenciones...';


GO
ALTER TABLE [dbo].[CuentasCorrientesRetenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones] FOREIGN KEY ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion]) REFERENCES [dbo].[Retenciones] ([IdSucursal], [IdTipoImpuesto], [EmisorRetencion], [NumeroRetencion]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Retenciones_Clientes...';


GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_Clientes] FOREIGN KEY ([TipoDocCliente], [NroDocCliente]) REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento]) ON DELETE NO ACTION ON UPDATE NO ACTION;


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
PRINT N'Creating FK_Retenciones_Ventas...';


GO
ALTER TABLE [dbo].[Retenciones] WITH NOCHECK
    ADD CONSTRAINT [FK_Retenciones_Ventas] FOREIGN KEY ([IdTipoComprobante], [LetraComprobante], [EmisorComprobante], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_Transportistas...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_Transportistas] FOREIGN KEY ([IdTransportista]) REFERENCES [dbo].[Transportistas] ([IdTransportista]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_Ventas...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_Ventas] FOREIGN KEY ([IdTipoComprobanteFact], [LetraFact], [CentroEmisorFact], [NumeroComprobanteFact], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_Sucursales...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_Sucursales] FOREIGN KEY ([IdSucursal]) REFERENCES [dbo].[Sucursales] ([IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_TiposComprobantes...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_TiposComprobantes] FOREIGN KEY ([IdTipoComprobante]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_Empleados...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_Empleados] FOREIGN KEY ([TipoDocVendedor], [NroDocVendedor]) REFERENCES [dbo].[Empleados] ([TipoDocEmpleado], [NroDocEmpleado]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_VentasFormasPago...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_VentasFormasPago] FOREIGN KEY ([IdFormasPago]) REFERENCES [dbo].[VentasFormasPago] ([IdFormasPago]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_CategoriasFiscales...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_CategoriasFiscales] FOREIGN KEY ([IdCategoriaFiscal]) REFERENCES [dbo].[CategoriasFiscales] ([IdCategoriaFiscal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_Clientes...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_Clientes] FOREIGN KEY ([TipoDocCliente], [NroDocCliente]) REFERENCES [dbo].[Clientes] ([TipoDocumento], [NroDocumento]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_Ventas_TiposComprobantes1...';


GO
ALTER TABLE [dbo].[Ventas] WITH NOCHECK
    ADD CONSTRAINT [FK_Ventas_TiposComprobantes1] FOREIGN KEY ([IdTipoComprobanteFact]) REFERENCES [dbo].[TiposComprobantes] ([IdTipoComprobante]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VentasObservaciones_Ventas...';


GO
ALTER TABLE [dbo].[VentasObservaciones] WITH NOCHECK
    ADD CONSTRAINT [FK_VentasObservaciones_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_RecepcionNotas_Ventas...';


GO
ALTER TABLE [dbo].[RecepcionNotas] WITH NOCHECK
    ADD CONSTRAINT [FK_RecepcionNotas_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VentasProductos_Ventas...';


GO
ALTER TABLE [dbo].[VentasProductos] WITH NOCHECK
    ADD CONSTRAINT [FK_VentasProductos_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VentasCheques_Ventas...';


GO
ALTER TABLE [dbo].[VentasCheques] WITH NOCHECK
    ADD CONSTRAINT [FK_VentasCheques_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VentasChequesRechazados_Ventas...';


GO
ALTER TABLE [dbo].[VentasChequesRechazados] WITH NOCHECK
    ADD CONSTRAINT [FK_VentasChequesRechazados_Ventas] FOREIGN KEY ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) REFERENCES [dbo].[Ventas] ([IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [IdSucursal]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_CajasUsuarios_Usuarios...';


GO
ALTER TABLE [dbo].[CajasUsuarios] WITH NOCHECK
    ADD CONSTRAINT [FK_CajasUsuarios_Usuarios] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_SubCajasUsuarios_SubCajas...';


GO
ALTER TABLE [dbo].[CajasUsuarios] WITH NOCHECK
    ADD CONSTRAINT [FK_SubCajasUsuarios_SubCajas] FOREIGN KEY ([IdSucursal], [IdCaja]) REFERENCES [dbo].[CajasNombres] ([IdSucursal], [IdCaja]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_VentasProductosLotes_VentasProductos...';


GO
ALTER TABLE [dbo].[VentasProductosLotes] WITH NOCHECK
    ADD CONSTRAINT [FK_VentasProductosLotes_VentasProductos] FOREIGN KEY ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto]) REFERENCES [dbo].[VentasProductos] ([IdSucursal], [IdTipoComprobante], [Letra], [CentroEmisor], [NumeroComprobante], [Orden], [IdProducto]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Checking existing data against newly created constraints';


GO
ALTER TABLE [dbo].[Cajas] WITH CHECK CHECK CONSTRAINT [FK_Cajas_Sucursales];

ALTER TABLE [dbo].[CajasDetalle] WITH CHECK CHECK CONSTRAINT [FK_CajasDetalle_Cajas];

ALTER TABLE [dbo].[Cajas] WITH CHECK CHECK CONSTRAINT [FK_Cajas_CajasNombres];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_CajasDetalle];

ALTER TABLE [dbo].[CajasDetalle] WITH CHECK CHECK CONSTRAINT [FK_CajasDetalle_CuentasDeCajas];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_CajasDetalle];

ALTER TABLE [dbo].[LibrosBancos] WITH CHECK CHECK CONSTRAINT [FK_LibrosBancos_Cheques];

ALTER TABLE [dbo].[Cheques] WITH CHECK CHECK CONSTRAINT [FK_Cheques_CuentasBancarias];

ALTER TABLE [dbo].[Cheques] WITH CHECK CHECK CONSTRAINT [FK_Cheques_Bancos];

ALTER TABLE [dbo].[Cheques] WITH CHECK CHECK CONSTRAINT [FK_Cheques_Localidades];

ALTER TABLE [dbo].[Cheques] WITH CHECK CHECK CONSTRAINT [FK_Cheques_Sucursales];

ALTER TABLE [dbo].[Cheques] WITH CHECK CHECK CONSTRAINT [FK_Cheques_EstadosCheques];

ALTER TABLE [dbo].[Cheques] WITH CHECK CHECK CONSTRAINT [FK_Cheques_EstadosChequesAnt];

ALTER TABLE [dbo].[VentasCheques] WITH CHECK CHECK CONSTRAINT [FK_VentasCheques_Cheques];

ALTER TABLE [dbo].[VentasChequesRechazados] WITH CHECK CHECK CONSTRAINT [FK_VentasChequesRechazados_Cheques];

ALTER TABLE [dbo].[DepositosCheques] WITH CHECK CHECK CONSTRAINT [FK_DepositosCheques_Cheques];

ALTER TABLE [dbo].[CuentasCorrientesProvCheques] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesProvCheques_Cheques];

ALTER TABLE [dbo].[CuentasCorrientesCheques] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesCheques_Cheques];

ALTER TABLE [dbo].[Cheques] WITH CHECK CHECK CONSTRAINT [FK_Cheques_CajasDetalle];

ALTER TABLE [dbo].[Cheques] WITH CHECK CHECK CONSTRAINT [FK_Cheques_CajasDetalleEgreso];

ALTER TABLE [dbo].[CuentasCorrientesRetenciones] WITH CHECK CHECK CONSTRAINT [FK_CuentasCorrientesRetenciones_Retenciones];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Clientes];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Sucursales];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_TiposImpuestos];

ALTER TABLE [dbo].[Retenciones] WITH CHECK CHECK CONSTRAINT [FK_Retenciones_Ventas];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_Transportistas];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_Ventas];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_Sucursales];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_TiposComprobantes];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_Empleados];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_VentasFormasPago];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_CategoriasFiscales];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_Clientes];

ALTER TABLE [dbo].[Ventas] WITH CHECK CHECK CONSTRAINT [FK_Ventas_TiposComprobantes1];

ALTER TABLE [dbo].[VentasObservaciones] WITH CHECK CHECK CONSTRAINT [FK_VentasObservaciones_Ventas];

ALTER TABLE [dbo].[RecepcionNotas] WITH CHECK CHECK CONSTRAINT [FK_RecepcionNotas_Ventas];

ALTER TABLE [dbo].[VentasProductos] WITH CHECK CHECK CONSTRAINT [FK_VentasProductos_Ventas];

ALTER TABLE [dbo].[VentasCheques] WITH CHECK CHECK CONSTRAINT [FK_VentasCheques_Ventas];

ALTER TABLE [dbo].[VentasChequesRechazados] WITH CHECK CHECK CONSTRAINT [FK_VentasChequesRechazados_Ventas];

ALTER TABLE [dbo].[CajasUsuarios] WITH CHECK CHECK CONSTRAINT [FK_CajasUsuarios_Usuarios];

ALTER TABLE [dbo].[CajasUsuarios] WITH CHECK CHECK CONSTRAINT [FK_SubCajasUsuarios_SubCajas];

ALTER TABLE [dbo].[VentasProductosLotes] WITH CHECK CHECK CONSTRAINT [FK_VentasProductosLotes_VentasProductos];


GO




update Cajas set IdCaja = 1;
update CajasDetalle set IdCaja = 1;
update Retenciones set IdCajaIngreso = 1 where NroPlanillaIngreso is not null;
update Ventas set IdCaja = 1 where NumeroPlanilla is not null;
update Cheques set IdCajaIngreso = 1 where NroPlanillaIngreso is not null;
update Cheques set IdCajaEgreso = 1 where NroPlanillaEgreso is not null;

GO