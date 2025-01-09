delete Bitacora
where IdFuncion in
 (
SELECT id FROM [Funciones]
 WHERE id='FeriadosABM'
    or id='InteresesABM'
    or id='MediosdePagoABM'
    or id='TarjetasABM'
    or id='PlanesTarjetasABM'
    or id='SemaforoVentasUtilidadesABM'
    or id='ConsultarCodigosLibres'
    or id='ImportarProductosAiroldi'
    or id='ExportarSaldosCtaCtClientesWeb'
    or id='ExportarCtaCteClientes'
)
GO


delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM [Funciones]
 WHERE id='FeriadosABM'
    or id='InteresesABM'
    or id='MediosdePagoABM'
    or id='TarjetasABM'
    or id='PlanesTarjetasABM'
    or id='SemaforoVentasUtilidadesABM'
    or id='ConsultarCodigosLibres'
    or id='ImportarProductosAiroldi'
    or id='ExportarSaldosCtaCtClientesWeb'
    or id='ExportarCtaCteClientes'
)
GO

delete [Funciones]
 WHERE id='FeriadosABM'
    or id='InteresesABM'
    or id='MediosdePagoABM'
    or id='TarjetasABM'
    or id='PlanesTarjetasABM'
    or id='SemaforoVentasUtilidadesABM'
    or id='ConsultarCodigosLibres'
    or id='ImportarProductosAiroldi'
    or id='ExportarSaldosCtaCtClientesWeb'
    or id='ExportarCtaCteClientes'
GO
