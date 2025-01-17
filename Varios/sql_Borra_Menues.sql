DELETE Bitacora
GO

--Solo Factura Electronica
DELETE Textos
GO

DELETE Traducciones
where IdFuncion in
 (
SELECT id FROM [Funciones]
 where id='Sueldos' or IdPadre='Sueldos' or IdPadre='SueldosLiquidacion'
    or id='Presupuestos' or IdPadre IN ('Presupuestos', 'PresupuestosAdmin', 'InfPresupuestosSumaPorProducto', 'ConsultarPresupuestos')
    or id='Service' or IdPadre='Service'
    or id='ServiceF' or IdPadre='ServiceF'
    or id in ('Fichas','FichasABM2') or IdPadre in ('Fichas','FichasABM','FichasABM2')
    or id='FacturacionElectronica' or IdPadre='FacturacionElectronica' OR id='FacturacionElectro'
    or id='MensajeMail'
    or id='Produccion' or IdPadre='Produccion'
    or id IN ('Contabilidad', 'ContabilidadAsientosABM', 'ContabilidadGeneracionAsientos') or idpadre IN ('Contabilidad', 'ContabilidadAsientosABM', 'ContabilidadGeneracionAsientos')
    or id='Alquileres' or IdPadre='Alquileres'
    or id='Cargos' or IdPadre='Cargos'
    or id IN ('CobranzasMovil','SiMovil','SiMovilWeb') OR IdPadre IN ('CobranzasMovil','SiMovil','SiMovilWeb')
    or id='CRM' or IdPadre IN ('CRM','CRMNovedadesABMCRM', 'CRMNovedadesABMPROSP', 'CRMNovedadesABMRECCLTE', 'CRMNovedadesABMRECPROV','CRMNovedadesABMSERVICE')
 )
GO

--Produccion Avanzada.
--   OR id in ('OrdenesDeProduccion','ConsultarOrdenesProduccion','AnularOrdenesProduccion','OrdenesProduccionAdmin','EstadosOrdenesProduccionABM','ProduccionFormasABM','ProduccionProcesosABM')


DELETE RolesFunciones 
where IdFuncion in
 (
SELECT id FROM [Funciones]
 where id='Sueldos' or IdPadre='Sueldos' or IdPadre='SueldosLiquidacion'
    or id='Presupuestos' or IdPadre IN ('Presupuestos', 'PresupuestosAdmin', 'InfPresupuestosSumaPorProducto', 'ConsultarPresupuestos')
    or id='Service' or IdPadre='Service'
    or id='ServiceF' or IdPadre='ServiceF'
    or id in ('Fichas','FichasABM2') or IdPadre in ('Fichas','FichasABM','FichasABM2')
    or id='FacturacionElectronica' or IdPadre='FacturacionElectronica' OR id='FacturacionElectro'
    or id='MensajeMail'
    or id='Produccion' or IdPadre='Produccion'
    or id IN ('Contabilidad', 'ContabilidadAsientosABM', 'ContabilidadGeneracionAsientos') or idpadre IN ('Contabilidad', 'ContabilidadAsientosABM', 'ContabilidadGeneracionAsientos')
    or id='Alquileres' or IdPadre='Alquileres'
    or id='Cargos' or IdPadre='Cargos'
    or id IN ('CobranzasMovil','SiMovil','SiMovilWeb') OR IdPadre IN ('CobranzasMovil','SiMovil','SiMovilWeb')
    or id='CRM' or IdPadre IN ('CRM','CRMNovedadesABMCRM', 'CRMNovedadesABMPROSP', 'CRMNovedadesABMRECCLTE', 'CRMNovedadesABMRECPROV','CRMNovedadesABMSERVICE')
 )
GO

DELETE [Funciones]
 where id='Sueldos' or IdPadre='Sueldos' or idPadre='SueldosLiquidacion'
    or id='Presupuestos' or IdPadre IN ('Presupuestos', 'PresupuestosAdmin', 'InfPresupuestosSumaPorProducto', 'ConsultarPresupuestos')
    or id='Service' or IdPadre='Service'
    or id='ServiceF' or IdPadre='ServiceF'
    or id in ('Fichas','FichasABM2') or IdPadre in ('Fichas','FichasABM','FichasABM2')
    or id='FacturacionElectronica' or IdPadre='FacturacionElectronica' OR id='FacturacionElectro'
    or id='MensajeMail'
    or id='Produccion' or IdPadre='Produccion'
    or id IN ('Contabilidad', 'ContabilidadAsientosABM', 'ContabilidadGeneracionAsientos') or idpadre IN ('Contabilidad', 'ContabilidadAsientosABM', 'ContabilidadGeneracionAsientos')
    or id='Alquileres' or IdPadre='Alquileres'
    or id='Cargos' or IdPadre='Cargos'
    or id IN ('CobranzasMovil','SiMovil','SiMovilWeb') OR IdPadre IN ('CobranzasMovil','SiMovil','SiMovilWeb')
    or id='CRM' or IdPadre IN ('CRM','CRMNovedadesABMCRM', 'CRMNovedadesABMPROSP', 'CRMNovedadesABMRECCLTE', 'CRMNovedadesABMRECPROV','CRMNovedadesABMSERVICE')
GO

DELETE ImpresorasPCs WHERE IdImpresora IN ('ELECTRONICA','ELECTRONICO')
GO

DELETE Impresoras WHERE IdImpresora IN ('ELECTRONICA','ELECTRONICO')
GO

UPDATE Parametros SET ValorParametro = 'False'
 WHERE IdParametro IN ('MODULOSERVICE', 'MODULOFACTURACIONELECTRONICA', 'MODULOPRODUCCION', 'MODULOSUELDOS', 'MODULOCONTABILIDAD', 'MODULOALQUILER')
GO
