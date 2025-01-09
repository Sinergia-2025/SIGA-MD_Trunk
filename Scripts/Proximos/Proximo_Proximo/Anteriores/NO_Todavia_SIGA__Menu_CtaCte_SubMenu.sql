PRINT ''
PRINT '1.-. Creo Menu CuentasCorrientes\AnularModificarEliminar'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id IN ('ModificarComprobantesDeCtaCte', 'ModificarNumeracionCtaCte', 'ModificarRecibosAClientes', 'AnulacionRecibosAClientes', 'AnularRecibos', 'EliminarMovCtaCteClientes', 'EliminarRecibosDeClientes') )
    BEGIN
        --Inserto la pantalla nueva
    INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo)
          VALUES
             ('CtaCteAnulModifElim', 'Anular / Modificar / Eliminar', 'Anular / Modificar / Eliminar', 'True', 'False', 'True', 'True',
              'CuentasCorrientes', 255, NULL, NULL, NULL, NULL,'True','S',	'N','N','N',NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'CtaCteAnulModifElim' AS Pantalla FROM dbo.RolesFunciones
            WHERE IdFuncion IN  ('ModificarComprobantesDeCtaCte' 
								 ,'ModificarNumeracionCtaCte'
								 ,'ModificarRecibosAClientes'
								 ,'AnulacionRecibosAClientes'
								 ,'AnularRecibos'
								 ,'EliminarMovCtaCteClientes'
								 ,'EliminarRecibosDeClientes'); 
        ;

		UPDATE Funciones
		   SET IdPadre = 'CtaCteAnulModifElim'
		 WHERE Id IN  ('ModificarComprobantesDeCtaCte' 
				      ,'ModificarNumeracionCtaCte'
					  ,'ModificarRecibosAClientes'
					  ,'AnulacionRecibosAClientes'
					  ,'AnularRecibos'
					  ,'EliminarMovCtaCteClientes'
					  ,'EliminarRecibosDeClientes'); 
    END;

	PRINT ''
PRINT '2. Reorganizo Menu CuentasCorrientes\AnularModificarEliminar'
GO

UPDATE Funciones SET
   Posicion = 
(CASE ID  	WHEN 'AnulacionRecibosAClientes' THEN 10
			WHEN 'AnularRecibos' THEN 20
			WHEN 'EliminarMovCtaCteClientes' THEN 30
			WHEN 'EliminarRecibosDeClientes' THEN 40
			WHEN 'ModificarComprobantesDeCtaCte' THEN 50
			WHEN 'ModificarNumeracionCtaCte' THEN 60
			WHEN 'ModificarRecibosAClientes' THEN 70
            ELSE 0 END)
WHERE Id IN  ('ModificarComprobantesDeCtaCte' 
			,'ModificarNumeracionCtaCte'
			,'ModificarRecibosAClientes'
			,'AnulacionRecibosAClientes'
			,'AnularRecibos'
			,'EliminarMovCtaCteClientes'
			,'EliminarRecibosDeClientes'); 

PRINT ''
PRINT '3.-. Creo Menu CuentasCorrientes\Listados Con Vencimiento'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id IN ('ModificarComprobantesDeCtaCte', 'ModificarNumeracionCtaCte', 'ModificarRecibosAClientes', 'AnulacionRecibosAClientes', 'AnularRecibos', 'EliminarMovCtaCteClientes', 'EliminarRecibosDeClientes') )
    BEGIN
        --Inserto la pantalla nueva
    INSERT INTO Funciones
			(Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
			,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
			,PermiteMultiplesInstancias,Plus,Express,Basica,PV,IdModulo)
          VALUES
             ('CtaCteListVencimiento', 'Listados Con Vencimiento', 'Listados Con Vencimiento', 'True', 'False', 'True', 'True',
              'CuentasCorrientes', 455, NULL, NULL, NULL, NULL,'True','S',	'N','N','N',NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'CtaCteListVencimiento' AS Pantalla FROM dbo.RolesFunciones
            WHERE IdFuncion  IN  ('InfCtaCteDetalleClientes'
								  ,'ConsultarCtaCteDetalleClientes'
								  ,'InfCtaCteDetalleProximoPago'
								  ,'ConsultarCtaCteDetClientesDH'
								  ,'InfCCDetClientesCobranzaYDeuda'); 
        ;

		UPDATE Funciones
		   SET IdPadre = 'CtaCteListVencimiento'
		 WHERE Id   IN  ('InfCtaCteDetalleClientes'
						,'ConsultarCtaCteDetalleClientes'
						,'InfCtaCteDetalleProximoPago'
						,'ConsultarCtaCteDetClientesDH'
						,'InfCCDetClientesCobranzaYDeuda'); 
    END;

	PRINT ''
PRINT '4. Reorganizo Menu CuentasCorrientes\Listados Con Vencimiento'
GO

UPDATE Funciones SET
   Posicion = 
(CASE ID    WHEN 'InfCtaCteDetalleClientes' THEN 10
			WHEN 'ConsultarCtaCteDetalleClientes' THEN 20
			WHEN 'InfCtaCteDetalleProximoPago' THEN 30
			WHEN 'ConsultarCtaCteDetClientesDH' THEN 40
			WHEN 'InfCCDetClientesCobranzaYDeuda' THEN 50
            ELSE 0 END)
WHERE Id   IN  ('InfCtaCteDetalleClientes'
			,'ConsultarCtaCteDetalleClientes'
			,'InfCtaCteDetalleProximoPago'
			,'ConsultarCtaCteDetClientesDH'
			,'InfCCDetClientesCobranzaYDeuda'); 
GO





