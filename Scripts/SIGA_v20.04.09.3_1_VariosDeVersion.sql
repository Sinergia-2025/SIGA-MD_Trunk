PRINT ''
PRINT '1. Tabla CuentasCorrientes: Nuevo Campo NumeroReparto(INT) NULL'
ALTER TABLE CuentasCorrientes ADD NumeroReparto INT NULL


PRINT ''
PRINT '2. Nueva Funcion: Asignar Impresoras a Comprobantes.'
PRINT ''
PRINT '2.1. Agregar opción de Menu: Impresoras a Comprobantes'
INSERT INTO Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
    ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
VALUES
    ('ImpresorasAComprobantesABM', 'Asignar Impresoras a Comprobantes', 'Asignar Impresoras a Comprobantes', 'True', 'False', 'True', 'True'
    ,'Configuraciones', 31, 'Eniac.Win', 'ImpresorasAComprobantesABM', NULL, NULL
    ,'True', 'S', 'N', 'N', 'N')
GO
PRINT ''
PRINT '2.2. Agregar roles a función: Impresoras a Comprobantes'
INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ImpresorasAComprobantesABM' AS Pantalla FROM dbo.Roles
 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
GO
PRINT ''
PRINT '2.3. Ocultar la vieja pantalla de Asignar Impresoras a Comprobantes'
UPDATE Funciones
	SET [Enabled] = 0,
		Visible = 0 WHERE Id = 'ImpresorasAComprobantes'

