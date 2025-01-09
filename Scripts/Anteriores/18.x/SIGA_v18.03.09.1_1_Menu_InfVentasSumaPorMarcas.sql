
PRINT '1. Nueva Pantalla: Ventas\Inf. Ventas Suma por Marca.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Ventas')
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('InfVentasSumaPorMarcas', 'Inf. Ventas Suma por Marca', 'Inf. Ventas Suma por Marca', 'True', 'False', 'True', 'True',
              'Ventas', 166, 'Eniac.Win', 'InfVentasSumaPorMarcas', NULL, NULL);

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT Id AS Rol, 'InfVentasSumaPorMarcas' AS Pantalla FROM dbo.Roles
            WHERE Id IN ('Adm', 'Supervisor', 'Oficina');
    END;


PRINT ''
PRINT '2. Tabla Productos: Ajusto los Productos en Orden.'
GO

UPDATE Productos
   SET Orden = 1
 WHERE Orden = 0
GO
