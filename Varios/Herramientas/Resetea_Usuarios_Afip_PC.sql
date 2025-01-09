
UPDATE Usuarios SET Clave = LEFT(LOWER(Id), 1) + '99';
UPDATE Parametros SET ValorParametro = 'https://wsaahomo.afip.gov.ar/ws/services/LoginCms' WHERE IdParametro = 'URLWSAA';
UPDATE Parametros SET ValorParametro = 'https://wswhomo.afip.gov.ar/wsbfe/service.asmx' WHERE IdParametro = 'URLWSBFE';
UPDATE Parametros SET ValorParametro = 'https://wswhomo.afip.gov.ar/wsfev1/service.asmx' WHERE IdParametro = 'URLWSFE';
UPDATE Parametros SET ValorParametro = 'https://wswhomo.afip.gov.ar/wsfexv1/service.asmx' WHERE IdParametro = 'URLWSFEX';


/*
--- ATENCION: NO CAMBIAR EL CUIT SLAVO QUE REALMETNE SE NECESITE PARA TRANSMITIR FACTURAS ELECTRONICAS PORQUE ALGUNOS SCRIPS MIRAN LA EMPRESA PARA AGREGAR O GUITAR COSAS---
UPDATE Parametros SET ValorParametro = '20244785922' WHERE IdParametro = 'CUITEMPRESA';
*/

/*
HOMOLOGACION CARROZZO SEBASTIAN PABLO
UPDATE Parametros SET ValorParametro = '24259000056' WHERE IdParametro = 'CUITEMPRESA';
UPDATE Parametros SET ValorParametro = 'SERIALNUMBER=CUIT 24259000056, CN=desarrollo' WHERE IdParametro = 'FACTELECTSOURCE';
*/

--UPDATE Parametros SET ValorParametro = 'C=AR, O=HAR, SERIALNUMBER=CUIT 20244785922, CN=SIGATest' WHERE IdParametro = 'FACTELECTSOURCE';
UPDATE Parametros SET ValorParametro = 'SERIALNUMBER=CUIT 20244785922, CN=Desarrollo' WHERE IdParametro = 'FACTELECTSOURCE';
UPDATE Parametros SET ValorParametro = 'cn=wsaahomo,o=afip,c=ar,serialNumber=CUIT 33693450239' WHERE IdParametro = 'FACTELECTDESTINATION';
UPDATE Parametros SET ValorParametro = 'C:\ENIAC\AFIP\COMPROBANTES' WHERE IdParametro = 'UBICACIONPDFSFE';

--Anulo el envio de Correos Automaticos
UPDATE Parametros SET ValorParametro = 'False'
 WHERE IdParametro IN ('ENVIACOMAILCOMPELECTRONICO','ENVIAMAILCLIENTE','ENVIAMAILEMPRESA','ENVIAMAILCLIENTECOMPELECTRONICO','ENVIAMAILCLIENTERECIBO');


--DELETE ParametrosArchivos WHERE IdParametroArchivo = 'TICKETACCESOFE';
GO

MERGE INTO UsuariosRoles AS D
        USING (SELECT 'Admin' IdUsuario, 'Adm' IdRol, IdSucursal FROM Sucursales) AS O
            ON D.IdUsuario = O.IdUsuario AND D.IdRol = O.IdRol AND D.IdSucursal = O.IdSucursal
    WHEN NOT MATCHED THEN
        INSERT (IdUsuario, IdRol, IdSucursal) VALUES (O.IdUsuario, O.IdRol, O.IdSucursal)
;

-- TERRA-PC es la que se encuentra en todas las bases solo en impresoras activas.
UPDATE ImpresorasPCs SET NombrePC = host_name() WHERE NombrePC = 'TERRA-PC';

SELECT * FROM Parametros WHERE IdParametro IN('VERSIONDB','CUITEMPRESA') ORDER BY IdParametro;
SELECT * FROM Parametros WHERE IdParametro IN('URLWSAA','URLWSBFE','URLWSFE','URLWSFEX','FACTELECTSOURCE', 'FACTELECTDESTINATION', 'UBICACIONPDFSFE', 'NOMBREEMPRESA','ENVIACOMAILCOMPELECTRONICO','ENVIAMAILCLIENTE','ENVIAMAILEMPRESA','ENVIAMAILCLIENTECOMPELECTRONICO','ENVIAMAILCLIENTERECIBO') ORDER BY IdParametro DESC;

SELECT * FROM Usuarios;

