PRINT ''
PRINT '1. Parametros: Actualizar URL al nuevo servidor de sinergia'
DECLARE @servidorOriginal VARCHAR(MAX) = 'wi531792.ferozo.com'
DECLARE @servidorNuevo    VARCHAR(MAX) = 'sinergiamovil.com.ar'

UPDATE Parametros
   SET ValorParametro = REPLACE(ValorParametro, @servidorOriginal, @servidorNuevo)
  FROM Parametros
 WHERE ValorParametro LIKE '%' + @servidorOriginal + '%'


PRINT ''
PRINT '2. Tabla EstadosCheques: Nuevo campo NombreEstadoCheque'
ALTER TABLE EstadosCheques ADD NombreEstadoCheque varchar(100) null
GO

PRINT ''
PRINT '2.1. Tabla EstadosCheques: Valores por defecto para NombreEstadoCheque'
UPDATE EstadosCheques SET NombreEstadoCheque = IdEstadoCheque
GO

PRINT ''
PRINT '3. Parametros: Máximo descuento para Simovil Pedidos 99%'
UPDATE Parametros
   SET ValorParametro = '99'
  FROM (SELECT *
          FROM Parametros
         WHERE IdParametro = 'SIMOVILPORCMAXDESCUENTO') Parametros
 WHERE CONVERT(decimal(14,2), REPLACE(ValorParametro, ',', '')) >= 99

PRINT ''
PRINT '4. Menu Permisos - Listas de Control por Productos '

IF dbo.SoyHAR() = 'True' OR dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN
    PRINT ''
    PRINT '. Menu ListasControlProductos-Produccion.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ListasControlProductos-P', 'Ejecución de Listas de Control por Productos-Producción', 'Ejecución de Listas de Control por Productos-Producción', 
        'False', 'False', 'True', 'True', 'ListasControlProductos', 10, 'Eniac.Win', 'ListasControlProductos-P', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ListasControlProductos-P' AS Pantalla FROM dbo.RolesFunciones
        WHERE IdFuncion = 'ListasControlProductos'

    PRINT ''
    PRINT '. Menu ListasControlProductos-5SP.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ListasControlProductos-5SP', 'Ejecución de Listas de Control por Productos-5S Producción', 'Ejecución de Listas de Control por Productos-5S Producción', 
        'False', 'False', 'True', 'True', 'ListasControlProductos', 10, 'Eniac.Win', 'ListasControlProductos-5SP', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ListasControlProductos-5SP' AS Pantalla FROM dbo.RolesFunciones
        WHERE IdFuncion = 'ListasControlProductos'

  
   PRINT ''
    PRINT '. Menu ListasControlProductos-5SC.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ListasControlProductos-5SC', 'Ejecución de Listas de Control por Productos-5S Calidad', 'Ejecución de Listas de Control por Productos-5S Calidad', 
        'False', 'False', 'True', 'True', 'ListasControlProductos', 10, 'Eniac.Win', 'ListasControlProductos-5SC', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ListasControlProductos-5SC' AS Pantalla FROM dbo.RolesFunciones
        WHERE IdFuncion = 'ListasControlProductos'

--	SET Nombre = 'Ejecución de Listas de Control por Productos-Calidad' 
--, Descripcion = 'Ejecución de Listas de Control por Productos-Calidad', IdPadre = 'ListasControlProductos'
	  PRINT ''
    PRINT '. Menu ListasControlProductos-Calidad.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ListasControlProductos-C', 'Ejecución de Listas de Control por Productos-Calidad', 'Ejecución de Listas de Control por Productos-Calidad', 
        'False', 'False', 'True', 'True', 'ListasControlProductos', 10, 'Eniac.Win', 'ListasControlProductos-C', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ListasControlProductos-C' AS Pantalla FROM dbo.RolesFunciones
        WHERE IdFuncion = 'ListasControlProductos'

			  PRINT ''
    PRINT '. Menu ListasControlProductos-Vista Gerencia.'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ListasControlProductos-VG', 'Ejecución de Listas de Control por Productos-Vista Gerencia', 'Ejecución de Listas de Control por Productos-Vista Gerencia', 
        'False', 'False', 'True', 'True', 'ListasControlProductos', 10, 'Eniac.Win', 'ListasControlProductos-VG', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
    INSERT INTO RolesFunciones (IdRol,IdFuncion)
    SELECT IdRol, 'ListasControlProductos-VG' AS Pantalla FROM dbo.RolesFunciones
        WHERE IdFuncion = 'ListasControlProductos'

    DELETE FROM Bitacora WHERE IdFuncion = 'ProductosListasControl-Calidad'
    DELETE FROM Bitacora WHERE IdFuncion = 'ProductosListasControl-Gerenc'
    DELETE FROM RolesFunciones WHERE IdFuncion = 'ProductosListasControl-Calidad'
    DELETE FROM RolesFunciones WHERE IdFuncion = 'ProductosListasControl-Gerenc'
	DELETE FROM Funciones  WHERE id = 'ProductosListasControl-Calidad'
--SET Nombre = 'Ejecución de Listas de Control por Productos-Vista Gerencia' 
--, Descripcion = 'Ejecución de Listas de Control por Productos-Vista Gerencia', IdPadre = 'ListasControlProductos'
 	DELETE FROM Funciones  WHERE id = 'ProductosListasControl-Gerenc'



END;

