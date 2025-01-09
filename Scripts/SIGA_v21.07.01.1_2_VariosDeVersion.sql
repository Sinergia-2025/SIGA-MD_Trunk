PRINT ''
PRINT '1. Nueva función menú Calidad: Informe de Chasis'
IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
    
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
      VALUES
       ('PanelFechasSalidaSeccion', 'Panel de Fechas de Salida de Sección', 'Panel de Fechas de Salida de Sección', 'True', 'False', 'True', 'True'
        ,'Calidad', 26, 'Eniac.Win', 'PanelFechasSalidaSeccion', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
       
END

PRINT ''
PRINT '2. Función InformeLeadTimePorTipo: Ajustar nombre'
UPDATE Funciones
   SET Nombre = 'Informe Lead Time'
     , Descripcion = 'Informe Lead Time'
 WHERE Id = 'InformeLeadTimePorTipo'

PRINT ''
PRINT '3. Función SemaforoVentasUtilidadesABM: Ajustar nombre'
UPDATE Funciones
   SET Nombre = REPLACE(Nombre, 'Ventas Utilidades', '')
     , Descripcion = REPLACE(Descripcion, 'Ventas Utilidades', '')
 WHERE Id = 'SemaforoVentasUtilidadesABM'

PRINT ''
PRINT '4. Tabla SemaforoVentasUtilidades: Definir colores para Estrellas'
IF dbo.SoyHAR() = 1
BEGIN
    INSERT INTO SemaforoVentasUtilidades
               (IdSemaforo, IdTipoSemaforoVentaUtilidad, PorcentajeHasta, NombreColor, Negrita, ColorSemaforo, ColorLetra)
         VALUES
               (10100, 'ESTRELLAS', 10,  'Verde',      'False', -16744448, -1),
               (10075, 'ESTRELLAS', 7.5, 'Amarillo',   'False', -256, -16777216),
               (10050, 'ESTRELLAS', 5,   'Anaranjado', 'False', -23296, -16777216),
               (10025, 'ESTRELLAS', 2.5, 'Rojo',       'False', -65536, -1)
END

PRINT ''
PRINT '5. Tabla CategoriasFiscales: Valor por defecto para CodigoExportacion'
UPDATE CategoriasFiscales
   SET CodigoExportacion = 0
 WHERE CodigoExportacion IS NULL
