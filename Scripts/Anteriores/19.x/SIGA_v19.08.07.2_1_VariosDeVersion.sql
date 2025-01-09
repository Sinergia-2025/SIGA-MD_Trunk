PRINT ''
PRINT '1. Menu: Informe de Reparto por Modelo'
IF dbo.ExisteFuncion('VentasRepartos') = 'True' and dbo.ExisteFuncion('RegistrarReparto') = 'True'
BEGIN
    PRINT ''
    PRINT '1.1. Agregar opción de Menu: Informe de Reparto por Modelo.'
	--HABILITA SEGUN EL REPARTO ESPECIFICO.
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica)
	 SELECT 'InfRepartosPorModelo', 'Informe de Reparto por Modelo', 'Informe de Reparto por Modelo', 
		EsMenu, EsBoton, [Enabled], Visible, 'VentasRepartos',57, 'Eniac.Win', 'InfRepartosPorModelo', null, null,'N','S','N','N'
	   FROM Funciones
	  WHERE Id = 'RegistrarReparto'
	END;

    PRINT ''
    PRINT '1.2. Permisos opción de Menu: Informe de Reparto por Modelo'
	INSERT INTO RolesFunciones (IdRol, IdFuncion)
	SELECT DISTINCT IdRol, 'InfRepartosPorModelo' AS Pantalla FROM dbo.RolesFunciones
	  WHERE IdFuncion = 'RegistrarReparto';
GO

PRINT ''
PRINT '2. Tabla AfipTiposComprobantesTiposCbtes: Eliminar configuración erronea de NCRED-F.'
DELETE AfipTiposComprobantesTiposCbtes
 WHERE IdTipoComprobante = 'NCRED-F'
GO


PRINT ''
PRINT '3. Tabla AFIPTiposComprobantes: Agregar comprobantes 112 y 113'
INSERT INTO AFIPTiposComprobantes (IdAFIPTipoComprobante,NombreAFIPTipoComprobante)
     VALUES (112 ,'TIQUE NOTA DE CREDITO A'), (113 ,'TIQUE NOTA DE CREDITO B'), (114 ,'TIQUE NOTA DE CREDITO C')
           ,(115 ,'TIQUE NOTA DE DEBITO A'), (116 ,'TIQUE NOTA DE DEBITO B'), (117 ,'TIQUE NOTA DE DEBITO C')
GO

PRINT ''
PRINT '4. Tabla AfipTiposComprobantesTiposCbtes: Agregar comprobantes 112 y 113'
INSERT INTO AfipTiposComprobantesTiposCbtes (IdAFIPTipoComprobante, IdTipoComprobante, Letra)
  VALUES (112, 'NCRED-F', 'A'),(113, 'NCRED-F', 'B'),(114, 'NCRED-F', 'C')
        ,(115, 'NDEB-F', 'A'),(116, 'NDEB-F', 'B'),(117, 'NDEB-F', 'C')
GO
