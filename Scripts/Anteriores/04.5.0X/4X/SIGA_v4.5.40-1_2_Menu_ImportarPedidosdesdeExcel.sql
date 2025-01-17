
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Pedidos')

BEGIN

	-- Inserto la pantalla nueva

	INSERT INTO Funciones
		 (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
		 ,IdPadre, Posicion, Archivo, Pantalla, Icono)
	  VALUES
		 ('ImportarPedidosExcel', 'Importar Pedidos desde Excel', 'Importar Pedidos desde Excel', 'True', 'False', 'True', 'True',
		  'Pedidos', 100, 'Eniac.Win', 'ImportarPedidosExcel', NULL);


	INSERT INTO RolesFunciones 
		  (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ImportarPedidosExcel' AS Pantalla FROM dbo.Roles
		WHERE Id IN ('Adm', 'Supervisor', 'Oficina');


	--- Solo lo habilito si no lo estaba.
	
	IF NOT EXISTS (SELECT 1 FROM Impresoras WHERE IdImpresora = 'NORMAL' AND ComprobantesHabilitados LIKE '%,PEDIDOWEB%')
		UPDATE Impresoras 
		   SET ComprobantesHabilitados = ComprobantesHabilitados + ',PEDIDOWEB'
		 WHERE IdImpresora = 'NORMAL';

END;
