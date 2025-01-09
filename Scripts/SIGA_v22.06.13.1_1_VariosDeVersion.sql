PRINT ''
PRINT '1. Nuevos Tabla turismoTiposViajes.'
CREATE TABLE [dbo].[TurismoTiposViajes](
	[IdTipoViaje] [int] NOT NULL,
	[DescripcionTipoViaje] [varchar](30) NOT NULL,
	[CantidadDiasUltimaCuota] [int] NOT NULL,
	[IdInteres] [int] NOT NULL,
	CONSTRAINT [PK_TurismoTiposViajes] PRIMARY KEY CLUSTERED ([IdTipoViaje] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
GO

PRINT ''
PRINT '2. Menu TurismoTiposViajes ABM.'
ALTER TABLE [dbo].[TurismoTiposViajes]  WITH CHECK ADD  CONSTRAINT [FK_TurismoTiposViajes_Intereses] FOREIGN KEY([IdInteres])
REFERENCES [dbo].[Intereses] ([IdInteres])
ALTER TABLE [dbo].[TurismoTiposViajes] CHECK CONSTRAINT [FK_TurismoTiposViajes_Intereses]
GO

IF dbo.ExisteFuncion('Turismo') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('TurismoTiposViajesABM', 'ABM de Tipos de Viajes', 'ABM de Tipos de Viajes', 'True', 'False', 'True', 'True'
        ,'Turismo', 225, 'Eniac.Win', 'TurismoTiposViajesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'TurismoTiposViajesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END

PRINT ''
PRINT '3. Clave Foranea TurismoTiposViajes.'
ALTER TABLE dbo.ReservasTurismo ADD IdTipoViaje int NULL
GO
ALTER TABLE dbo.ReservasTurismo ADD CONSTRAINT FK_ReservasTurismo_TurismoTiposViajes
    FOREIGN KEY (IdTipoViaje)
    REFERENCES dbo.TurismoTiposViajes (IdTipoViaje)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

PRINT ''
PRINT '4. Campo nuevo CoeficienteAjustePorInflacion.'
ALTER TABLE dbo.ContabilidadPeriodosEjercicios ADD CoeficienteAjustePorInflacion decimal(12, 4) NULL
GO

PRINT ''
PRINT '5. Update TurismoTiposViajes.'
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'ContabilidadPeriodosEjerciciosCoeficientes'))
BEGIN
   UPDATE PE
      SET CoeficienteAjustePorInflacion = NULLIF(PEC.Coeficiente, 0)
     FROM ContabilidadPeriodosEjerciciosCoeficientes PEC
    INNER JOIN ContabilidadPeriodosEjercicios PE ON PE.IdEjercicio = PEC.IdEjercicio AND PE.IdPeriodo = PEC.IdPeriodo
END

PRINT ''
PRINT '6. Buscadores - Comprobantes de Venta Pendientes.'
INSERT INTO [dbo].[Buscadores]
           ([IdBuscador], [Titulo], [AnchoAyuda], [IniciaConFocoEn], [ColumaBusquedaInicial])
     VALUES
           (150, 'Comprobantes de Venta Pendientes', 900, 'Grilla', '')
GO


INSERT INTO [dbo].[BuscadoresCampos]
           ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila])
     VALUES
           (150, 'FechaVencimiento',       1, 'Vencimiento',   32,  70, 'dd/MM/yyyy', NULL, NULL, NULL),
           (150, 'Tipo',                   2, 'Tipo',          16, 100, '',           NULL, NULL, NULL),
           (150, 'Letra',                  3, 'Letra',         16,  40, '',           NULL, NULL, NULL),
           (150, 'Emisor',                 4, 'Emisor',        64,  40, '',           NULL, NULL, NULL),
           (150, 'Numero',                 5, 'Número',        64,  60, '',           NULL, NULL, NULL),
           (150, 'Cuota',                  6, 'Cuota',         64,  40, '',           NULL, NULL, NULL),
           (150, 'Fecha',                  7, 'Emisión',       32,  70, 'dd/MM/yyyy', NULL, NULL, NULL),
           (150, 'Importe',                8, 'Importe',       64,  70, 'N2',         NULL, NULL, NULL),
           (150, 'Saldo',                  9, 'Saldo',         64,  70, 'N2',         NULL, NULL, NULL),
           (150, 'DescripcionFormasPago', 10, 'Forma de Pago', 16, 120, '',           NULL, NULL, NULL),
           (150, 'Observacion',           11, 'Observación',   16, 220, '',           NULL, NULL, NULL),
           (150, 'NombreCliente',         12, 'Cliente',       16, 150, '',           NULL, NULL, NULL),
           (150, 'Direccion',             13, 'Direccion',     16, 220, '',           NULL, NULL, NULL),
           (150, 'NombreMoneda',          14, 'Moneda',        16,  80, '',           NULL, NULL, NULL),
           (150, 'Interes',               15, 'Interés',       64,  70, 'N2',         NULL, NULL, NULL)
GO

IF dbo.BaseConCUIT('30714757128') = 1
BEGIN
    INSERT INTO [dbo].[BuscadoresCampos]
               ([IdBuscador], [IdBuscadorNombreCampo], [Orden], [Titulo], [Alineacion], [Ancho], [Formato], [Condicion], [Valor], [ColorFila])
         VALUES
               (150, 'NumeroOrdenCompra',     16, 'Nro. O.C.',     64,  70, ''          , NULL, NULL, NULL)
END

PRINT ''
PRINT '7. RepartosCobranzasComprobantes.'
ALTER TABLE RepartosCobranzasComprobantes ADD TotalTransferencia DECIMAL(14,2)
ALTER TABLE RepartosCobranzasComprobantes ADD IdCuentaBancaria   INT
ALTER TABLE RepartosCobranzasComprobantes ADD FechaTransferencia DATETIME
GO

UPDATE RepartosCobranzasComprobantes SET TotalTransferencia = 0;

ALTER TABLE RepartosCobranzasComprobantes ALTER COLUMN TotalTransferencia DECIMAL(14,2) NOT NULL


ALTER TABLE dbo.RepartosCobranzasComprobantes ADD CONSTRAINT FK_RepartosCobranzasComprobantes_CuentasBancarias 
    FOREIGN KEY (IdCuentaBancaria)
    REFERENCES dbo.CuentasBancarias (IdCuentaBancaria)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE Repartos ADD TotalResumenTransferencia DECIMAL(14,2)
GO
UPDATE Repartos SET TotalResumenTransferencia = 0;
ALTER TABLE Repartos ALTER COLUMN TotalResumenTransferencia DECIMAL(14,2) NOT NULL

PRINT ''
PRINT '7. RepartosCobranzasComprobantes.'
INSERT INTO [dbo].[Buscadores] ([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
     VALUES (105, 'Ordenes de Compra', 550, 'Grilla', '')
GO
INSERT INTO [dbo].[BuscadoresCampos]
           ([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato])
     VALUES
           (105, 'NumeroOrdenCompra',           1, 'Nro. O. C.', 64, 70,  ''),
           (105, 'NombreProveedor',             2, 'proveedor',  16, 200, ''),
           (105, 'DescripcionFormasPago',       3, 'Forma Pago', 16, 100, ''),
           (105, 'FechaPedidos',                4, 'Fecha',      32, 80,  'dd/MM/yyyy')
GO
