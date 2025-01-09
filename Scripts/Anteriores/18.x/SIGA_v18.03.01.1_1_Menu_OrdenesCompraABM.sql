
IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Pedidos') AND
   EXISTS (SELECT 1 FROM Funciones WHERE Id = 'GeneraPedidoProvDesdeClie')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('OrdenesCompraABM', 'ABM de Ordenes de Compra', 'ABM de Ordenes de Compra', 'True', 'False', 'True', 'True',
              'Pedidos', 130, 'Eniac.Win', 'OrdenesCompraABM', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'OrdenesCompraABM' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;
