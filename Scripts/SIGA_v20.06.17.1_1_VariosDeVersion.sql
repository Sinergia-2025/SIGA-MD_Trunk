PRINT ''
PRINT '1. Nuevo Indice por IdEstadoCheque en Cheques'
CREATE NONCLUSTERED INDEX IX_Cheques_IdEstadoCheque
	ON [dbo].[Cheques] ([IdEstadoCheque])
	INCLUDE ([Importe],[IdCliente])
GO

PRINT ''
PRINT '2. Actualización de Campo: UtilizaImpuestos para los comprobantes RES-BANCARIO y RES-TARJETA'
UPDATE TiposComprobantes SET
	UtilizaImpuestos = 1 WHERE 
		IdTipoComprobante = 'RES-BANCARIO' OR
		IdTipoComprobante = 'RES-TARJETA'

PRINT ''
PRINT '3. Opciones de menu nuevas para Garzon'
--Para Garzon
IF dbo.BaseConCuit('30709024295') = 1 
BEGIN

    PRINT ''
    PRINT '3.1. Nueva opción de menú Exportacion de Ventas (Coca Cola - PDA)'
    IF dbo.ExisteFuncion('ExportacionDeVentas') = 1 AND dbo.ExisteFuncion('ExportacionDeVentasPDA') = 0
    BEGIN
      INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo)
	     VALUES
	       ('ExportacionDeVentasPDA', 'Exportacion de Ventas (Coca Cola - PDA)', 'Exportacion de Ventas (Coca Cola - PDA)', 
		    'True', 'False', 'True', 'True', 'Ventas', 46, 'Eniac.Win', 'ExportacionDeVentas', null, 'Formato=PDA;ComprobanteInvocado=PEDIDOPDA',
                  'True', 'S', 'N', 'N', 'N',NULL)
	

	    INSERT INTO RolesFunciones 
				      (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'ExportacionDeVentasPDA' AS Pantalla FROM dbo.Roles
		    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END

    PRINT ''
    PRINT '3.2. Nueva opción de menú Exportacion de Ventas (Coca Cola - Mostrador)'
    IF dbo.ExisteFuncion('ExportacionDeVentas') = 1 AND dbo.ExisteFuncion('ExportacionDeVentasMostrador') = 0
    BEGIN
      INSERT INTO Funciones
                 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
                 ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
                 ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo)
	     VALUES
	       ('ExportacionDeVentasMostrador', 'Exportacion de Ventas (Coca Cola - Mostrador)', 'Exportacion de Ventas (Coca Cola - Mostrador)', 
		    'True', 'False', 'True', 'True', 'Ventas', 46, 'Eniac.Win', 'ExportacionDeVentas', null, 'Formato=Mostrador;TipoComprobanteVenta=eFACT,eNCRED,eNDEB',
                  'True', 'S', 'N', 'N', 'N',NULL)
	

	    INSERT INTO RolesFunciones 
				      (IdRol,IdFuncion)
	    SELECT DISTINCT Id AS Rol, 'ExportacionDeVentasMostrador' AS Pantalla FROM dbo.Roles
		    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    END
END


PRINT ''
PRINT '4.1 Copiar permisos de AnularRecibos a AnulacionRecibosAClientes'
MERGE INTO RolesFunciones AS D
        USING (
               SELECT IdRol, IdFuncion
                 FROM RolesFunciones RF WHERE RF.IdFuncion = 'AnularRecibos'
              ) AS O ON O.IdRol = D.IdRol AND D.IdFuncion = 'AnulacionRecibosAClientes'
    WHEN NOT MATCHED THEN
        INSERT (IdRol, IdFuncion) 
        VALUES (O.IdRol, 'AnulacionRecibosAClientes')
;

PRINT ''
PRINT '4.2 Eliminar Roles'
DELETE RolesFunciones WHERE IdFuncion = 'AnularRecibos'

PRINT ''
PRINT '4.3 Desactivar Función'
UPDATE Funciones SET
	[Enabled] = 0,
	Visible = 0
		WHERE Id = 'AnularRecibos'
GO