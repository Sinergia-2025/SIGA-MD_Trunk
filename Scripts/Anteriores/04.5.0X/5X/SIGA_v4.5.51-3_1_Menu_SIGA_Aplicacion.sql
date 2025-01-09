
INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
     ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
SELECT ValorParametro, 'Aplicacion ' + ValorParametro, 'Aplicacion ' + ValorParametro,
       'False', 'False', 'False', 'False',
       NULL, 0, NULL, NULL, NULL, NULL
  FROM Parametros
 WHERE IdParametro = 'IDAPLICACION'
