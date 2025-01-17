delete Bitacora
where IdFuncion in
 (
SELECT id FROM [Funciones]
 where id='CuentasCorrientes' or IdPadre='CuentasCorrientes'
    or id='CobranzaElectronica' or IdPadre='CobranzaElectronica'
    or id='CuentasCorrientesProveedores' or IdPadre='CuentasCorrientesProveedores'
    or id='Caja' or IdPadre='Caja'
    or id='Bancos' or IdPadre='Bancos'
    or id='AFIP' or IdPadre='AFIP'
    or id='Procesos' or IdPadre='Procesos'
)
GO


delete RolesFunciones 
where IdFuncion in
 (
SELECT id FROM [Funciones]
 where id='CuentasCorrientes' or IdPadre='CuentasCorrientes'
    or id='CobranzaElectronica' or IdPadre='CobranzaElectronica'
    or id='CuentasCorrientesProveedores' or IdPadre='CuentasCorrientesProveedores'
    or id='Caja' or IdPadre='Caja'
    or id='Bancos' or IdPadre='Bancos'
    or id='AFIP' or IdPadre='AFIP'
    or id='Procesos' or IdPadre='Procesos'
)
GO

delete [Funciones]
 where id='CuentasCorrientes' or IdPadre='CuentasCorrientes'
    or id='CobranzaElectronica' or IdPadre='CobranzaElectronica'
    or id='CuentasCorrientesProveedores' or IdPadre='CuentasCorrientesProveedores'
    or id='Caja' or IdPadre='Caja'
    or id='Bancos' or IdPadre='Bancos'
    or id='AFIP' or IdPadre='AFIP'
    or id='Procesos' or IdPadre='Procesos'
GO


UPDATE Parametros SET ValorParametro = 'False'
 WHERE IdParametro IN ('MODULOBANCO', 'MODULOCAJA', 'MODULOCUENTACORRIENTECLIENTES', 'MODULOCUENTACORRIENTEPROVEEDORES')
GO
