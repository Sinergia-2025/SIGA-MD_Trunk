
PRINT ''
PRINT '0. Tabla Clientes: Nuevos Campos: FechaCambioCategoria, Observaciones IdCategoriaCambio'
ALTER TABLE CategoriasFiscales ADD [LeyendaCategoriaFiscal] [varchar] (500) NULL
GO

PRINT ''
PRINT '1. SE AGREGA LA NUEVA CATEGORIA FISCAL: Monotributista A'
INSERT INTO [dbo].[CategoriasFiscales]
           ([IdCategoriaFiscal],[NombreCategoriaFiscal],[CondicionIvaImpresoraFiscalEpson],[NombreCategoriaFiscalAbrev],[Activo],[UtilizaImpuestos],
            [CondicionIvaImpresoraFiscalHasar],[SolicitaCUIT],[EsPasiblePercIIBB],[UtilizaAlicuota2Producto],[CodigoExportacion],
            [LeyendaCategoriaFiscal])
     VALUES
           (9, 'Monotributista A', 'M', 'Monotr. A', 'True', 'True', 
		   'M', 'True', 'False', 'False', NULL, 
           'El crédito fiscal discriminado en el presente comprobante, sólo podrá ser computado a efectos del Régimen de Sostenimiento e Inclusión Fiscal para Peque±os Contribuyentes de la Ley N° 27.618.')
GO

PRINT ''
PRINT '2. SE AGREGAN LAS CONFIGURACIONES DE LA NUEVA CATEGORIA FISCAL'
PRINT ''
PRINT '2.1 Si IdCategoriaFiscalEmpresa =  Responsable Inscripto, Excento, Monotributista'
INSERT INTO [dbo].[CategoriasFiscalesConfiguraciones]
           ([IdCategoriaFiscalEmpresa], [IdCategoriaFiscalCliente], [LetraFiscal], [LetraFiscalCompra], [IvaDiscriminado])
     VALUES
           (2, 9, 'A', 'C', 'True'),        -- Responsable Inscripto  //  Monotributista A
           (4, 9, 'C', 'C', 'False'),       -- Exento                 //  Monotributista A
           (6, 9, 'C', 'C', 'False')        -- Monotributista         //  Monotributista A
GO


PRINT ''
PRINT '2.2 Si  IdCategoriaFiscalEmpresa = Monotributista A'
INSERT INTO [dbo].[CategoriasFiscalesConfiguraciones]
           ([IdCategoriaFiscalEmpresa], [IdCategoriaFiscalCliente], [LetraFiscal], [LetraFiscalCompra], [IvaDiscriminado])
     SELECT 9 IdCategoriaFiscalEmpresa, [IdCategoriaFiscalCliente], [LetraFiscal], 
            CASE WHEN IdCategoriaFiscalCliente = 2 THEN 'A'  ELSE [LetraFiscalCompra] END LetraFiscalCompra, 
            CASE WHEN IdCategoriaFiscalCliente = 2 THEN 'True' ELSE [IvaDiscriminado] END IvaDiscriminado
       FROM CategoriasFiscalesConfiguraciones
      WHERE IdCategoriaFiscalEmpresa = 6

PRINT ''
PRINT '3. Tabla PedidoProducto: Nuevo campo ModificoDescuentos'
ALTER TABLE PedidosProductos ADD ModificoDescuentos BIT NULL
GO

PRINT ''
PRINT '3.1. Tabla PedidoProducto: Actualización de registros pre-existentes'
UPDATE PP SET PP.ModificoDescuentos = 0 FROM PedidosProductos PP
PRINT ''
PRINT '3.2. Tabla PedidoProducto: Cambio el campo ModificoDescuentos a NOT NULL'
ALTER TABLE PedidosProductos ALTER COLUMN ModificoDescuentos BIT NOT NULL
GO

PRINT ''
PRINT '4. CAMBIOS DE NOMBRE AL REPORTE eComprobante_PAS del Cliente 147 EMT Maquinarias SRL'
    EXECUTE [dbo].[RenombrarReporte] 'eComprobante_PAS.rdlc', '147_eComprobante.rdlc', 'N'

PRINT ''
PRINT '5. Actualización de registros inconsistentes en CuentasCorrientesTransferencias'
UPDATE CCT SET 
	CCT.IdCuentaBancaria = CC.IdCuentaBancaria 
FROM CuentasCorrientesTransferencias CCT
  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCT.IdSucursal 
							     AND CC.IdTipoComprobante = CCT.IdTipoComprobante
							     AND CC.Letra = CCT.Letra 
							     AND CC.CentroEmisor = CCT.CentroEmisor
							     AND CC.NumeroComprobante = CCT.NumeroComprobante
WHERE CCT.IdCuentaBancaria <> CC.IdCuentaBancaria
GO
