PRINT ''
PRINT '1. Tabla Paises: Se actualiza el campo IdAfipPais según el estándar'
UPDATE Paises SET IdAfipPais = CASE IdPais
                               WHEN 'ARS' THEN 200
                               WHEN 'BOL' THEN 202 
                               WHEN 'BRA' THEN 203 
                               WHEN 'CHL' THEN 208 
                               WHEN 'CHN' THEN 310 
                               WHEN 'PER' THEN 222 
                               WHEN 'PRY' THEN 221 
                               WHEN 'URY' THEN 225 
                               WHEN 'USA' THEN 212
                               WHEN 'VEN' THEN 226
                               ELSE 0 END


--https://www.afip.gob.ar/genericos/guiavirtual/consultas_detalle.aspx?id=14038593
PRINT ''
PRINT '2. Tabla AFIPIncoterms: Se agregan Categorias Incoterms'
INSERT INTO [dbo].[AFIPIncoterms]
           ([IdIncoterm],[NombreIncoterm])
     VALUES
            --Incoterms multimodales "any mode of transport" (para cualquier transporte, incluido el marítimo y fluvial):
           ('EXW', 'En fábrica'),
           ('FCA', 'Franco al transportista'),
           ('CPT', 'Flete o porte pagado hasta'),
           ('CIP', 'Flete o porte y seguro pagado hasta'),
           ('DAP', 'Entregado en lugar designado'),
           ('DAT', 'Entrega en terminal'),
           ('DDP', 'Entregado derechos pagados'),
           --Incoterms sólo marítimos "sea and inland waterway transport only" (sólo utilizables en el transporte por mar y vías navegables interiores (fluvial).
           ('FAS', 'Franco al costado del buque'),
           ('CFR', 'Costo y flete'),
           ('CIF', 'Costo seguro y flete')
----------------------------------------------------

-- INSERTA COMPROBANTES FACTURA EXPORTACION.- --
PRINT ''
PRINT '3. Insertar Comprobantes Factura de Exportacion'
BEGIN
    PRINT ''
    PRINT '3.1. Tabla AFIPTiposComprobantesTiposCbtes: Carga Codigo 19 Factura de Exportacion.-'
    IF not exists ( SELECT *
                    FROM AFIPTiposComprobantesTiposCbtes 
                    WHERE IdAFIPTipoComprobante = 19 AND IdTipoComprobante IN ('eFACT', 'ePRE-FACT') AND Letra = 'E')
        BEGIN
            INSERT AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra) VALUES (19, 'eFACT', 'E')
            INSERT AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra) VALUES (19, 'ePRE-FACT', 'E')
        END

    PRINT ''
    PRINT '3.2. Tabla AFIPTiposComprobantesTiposCbtes: Carga Codigo 20 Factura de Exportacion.-'
    IF not exists ( SELECT *
                    FROM AFIPTiposComprobantesTiposCbtes 
                    WHERE IdAFIPTipoComprobante = 20 AND IdTipoComprobante IN ('eNDEB', 'ePRE-NDEB') AND Letra = 'E')
        BEGIN
            INSERT AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra) VALUES (20, 'eNDEB', 'E')
            INSERT AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra) VALUES (20, 'ePRE-NDEB', 'E')
        END

    PRINT ''
    PRINT '3.3. Tabla AFIPTiposComprobantesTiposCbtes: Carga Codigo 21 Factura de Exportacion.-'
    IF not exists ( SELECT *
                    FROM AFIPTiposComprobantesTiposCbtes 
                    WHERE IdAFIPTipoComprobante = 21 AND IdTipoComprobante IN ('eNCRED', 'ePRE-NCRED') AND Letra = 'E')
        BEGIN
            INSERT AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra) VALUES (21, 'eNCRED', 'E')
            INSERT AFIPTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra) VALUES (21, 'ePRE-NCRED', 'E')
        END
END
GO

PRINT ''
PRINT '4. Tabla TiposComprobantes: Agregar Letra Habilitada E a Comprobantes Electrónicos'
UPDATE TiposComprobantes
   SET LetrasHabilitadas = LetrasHabilitadas + ',E'
 WHERE EsElectronico = 'True'
   AND NOT (LetrasHabilitadas LIKE 'E,%' OR
            LetrasHabilitadas LIKE '%,E,%' OR
            LetrasHabilitadas LIKE '%,E')

PRINT ''
PRINT '5. Nuevo parámetro: Carga URLWSFEX Para Factura de Exportacion.-'
MERGE INTO Parametros AS DEST
USING (
        SELECT IdEmpresa, 
            'URLWSFEX' AS IdParametro, 
            'https://servicios1.afip.gov.ar/wsfexv1/service.asmx' ValorParametro, 
            'URL WebService FEE' CategoriaParametro, 
            'URLWSFEX' DescripcionParametro FROM Empresas) AS ORIG 
        ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
WHEN MATCHED THEN
    UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
WHEN NOT MATCHED THEN 
    INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) 
    VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, ORIG.CategoriaParametro, ORIG.DescripcionParametro);

PRINT ''
PRINT '6. Cambio en el parámetro: FACTURACIONORDENDECOLOR'
UPDATE Parametros
   SET ValorParametro = CASE ValorParametro WHEN 'VENDEDORCAJA' THEN 'VENDEDOR,CAJA,TIPOCOMPROBANTE'
                                            WHEN 'CAJAVENDEDOR' THEN 'CAJA,VENDEDOR,TIPOCOMPROBANTE'
                                            ELSE 'VENDEDOR,CAJA,TIPOCOMPROBANTE' END
 WHERE IdParametro = 'FACTURACIONORDENDECOLOR'


PRINT ''
PRINT '6. Nueva Función de Menú: ABM de Incoterms'
IF dbo.ExisteFuncion('AFIP') = 1 AND dbo.ExisteFuncion('AFIPIncotermsABM') = 0
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
    VALUES
        ('AFIPIncotermsABM', 'ABM de Incoterms', 'ABM de Incoterms', 'True', 'False', 'True', 'True'
        ,'AFIP', 135, 'Eniac.Win', 'AFIPIncotermsABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'AFIPIncotermsABM' AS Pantalla FROM dbo.Roles
     WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END


PRINT ''
PRINT '7. Tabla TarjetasCupones: Guardar los datos de Ingreso a Caja de los siguientes registros pre-existentes segun los valores de la tabla CuentasCorrientes. PE-32195'
UPDATE TC SET
        TC.IdCajaIngreso = ISNULL(TC.IdCajaIngreso, CC.IdCaja),
        TC.NroPlanillaIngreso = ISNULL(TC.NroPlanillaIngreso, CC.NumeroPlanilla),
        TC.NroMovimientoIngreso = ISNULL(TC.NroMovimientoIngreso, CC.NumeroMovimiento)	
  FROM TarjetasCupones AS TC
 INNER JOIN CuentasCorrientesTarjetas CT ON TC.IdTarjetaCupon = CT.IdTarjetaCupon
 INNER JOIN CuentasCorrientes CC ON CT.IdSucursal = CC.IdSucursal AND CT.IdTipoComprobante = CC.IdTipoComprobante 
                                AND CT.Letra = CC.Letra AND CT.CentroEmisor = CT.CentroEmisor AND CT.NumeroComprobante = CC.NumeroComprobante

PRINT ''
PRINT '8. Tabla TarjetasCupones: Guardar los datos de Ingreso a Caja de los siguientes registros pre-existentes segun los valores de la tabla Ventas. PE-32196'
UPDATE TC SET
       TC.IdCajaIngreso = ISNULL(TC.IdCajaIngreso, V.IdCaja),
       TC.NroPlanillaIngreso = ISNULL(TC.NroPlanillaIngreso, V.NumeroPlanilla),
       TC.NroMovimientoIngreso = ISNULL(TC.NroMovimientoIngreso, V.NumeroMovimiento)	
  FROM TarjetasCupones AS TC
 INNER JOIN VentasTarjetas VT ON TC.IdTarjetaCupon = VT.IdTarjetaCupon
 INNER JOIN Ventas V ON VT.IdSucursal = V.IdSucursal AND VT.IdTipoComprobante = V.IdTipoComprobante 
                    AND VT.Letra = V.Letra AND VT.CentroEmisor = VT.CentroEmisor AND VT.NumeroComprobante = V.NumeroComprobante
