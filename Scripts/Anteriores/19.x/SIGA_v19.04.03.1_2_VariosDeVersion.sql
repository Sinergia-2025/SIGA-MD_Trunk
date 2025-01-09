
PRINT ''
PRINT '1. Nueva opción de Menu Libro de IVA Compras (v2)'
GO

IF dbo.ExisteFuncion('LibrodeIvaComprasV2') = 'False' AND
   dbo.ExisteFuncion('Compras') = 'True'
--Inserto la Pantalla Nueva
BEGIN
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
     VALUES
       ('LibrodeIvaComprasV2', 'Libro de IVA Compras (v2)', 'Libro de IVA Compras (v2)', 
        'True', 'False', 'True', 'True', 'Compras',15, 'Eniac.Win', 'LibrodeIvaComprasV2', null, null,'N','S','N','N')

    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT DISTINCT Id AS Rol, 'LibrodeIvaComprasV2' AS Pantalla FROM dbo.Roles
	    WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
END;

PRINT ''
PRINT '2. Seguridad para ver PrecioCosto en Inf. Pedidos Detallados'
--SOLO SAURO POLIETILENO
IF dbo.ExisteFuncion('InfPedidosDetallados') = 'True'
BEGIN
    INSERT INTO [dbo].Funciones
            	    (Id, Nombre, Descripcion
	    ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
            VALUES
                ('InfPedidosDetallados-VerPCosto', 'Ver Precio Costo en Inf.Ped. Detallados', 'Ver Precio Costo en Inf.Ped. Detallados', 'False', 'False', 'True', 'True', 
                'InfPedidosDetallados', 999, 'Eniac.Win', 'InfPedidosDetallados-VerPCosto', NULL, NULL,'N','S','N','N');

    IF dbo.BaseConCuit('20220875181') = 'True'
    BEGIN
		INSERT INTO RolesFunciones (IdRol,IdFuncion)
		SELECT DISTINCT Id AS Rol, 'InfPedidosDetallados-VerPCosto' AS Pantalla FROM dbo.Roles
			WHERE Id IN ('Adm', 'Supervisor');
    END
    ELSE
    BEGIN
	    INSERT INTO RolesFunciones (IdRol,IdFuncion)
	    SELECT IdRol, 'InfPedidosDetallados-VerPCosto' FROM RolesFunciones
	     WHERE IdFuncion = 'InfPedidosDetallados';
    END
END
