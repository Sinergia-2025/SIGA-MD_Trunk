
-- CREAR LOS PERMISOS PARA MODIFICAR CLIENTES DESDE OTRAS PANTALLAS

-- SIGA o SICAP, el resto tiene ABM de Clientes Especificos y estas pantallas llaman al estandar.
-- LIVE podria permitirse porque no da error pero hay campos que son obligatorios (tipo comprobante, transportista, etc)


IF EXISTS (SELECT 1 FROM Parametros WHERE IdParametro = 'IDAPLICACION' AND ValorParametro IN ('SIGA','SICAP'))
    BEGIN

		-- Clientes-Puede Editar Desde Otras Pantallas

		INSERT INTO Funciones
			 (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
			  IdPadre, Posicion, Archivo, Pantalla, Icono)
		  VALUES
			 ('Clientes-PuedeUsarMasInfo', 'Permitir Editar Clientes Desde Otras Pantallas', 'Permitir Editar Clientes Desde Otras Pantallas', 'False', 'False', 'True', 'False', 
			  'Clientes', 999, 'Eniac.Win', 'Clientes-PuedeUsarMasInfo', NULL)
		;

		-- Otorgar los Permisos a quienes tienen acceso al ABM 

		INSERT INTO RolesFunciones (IdRol, IdFuncion)
		SELECT DISTINCT Id AS Rol, 'Clientes-PuedeUsarMasInfo' AS Pantalla FROM Roles
		  WHERE Id IN (SELECT IdRol as Id FROM RolesFunciones WHERE IdFuncion = 'Clientes')
		;

    END;
