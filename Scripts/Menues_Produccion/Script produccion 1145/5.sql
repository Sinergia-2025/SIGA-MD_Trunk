
INSERT INTO Funciones
      (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
       IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
  VALUES
      ('FormulasABM', 'ABM de Formulas / Componentes de Productos', 'ABM de Formulas / Componentes de Productos', 'True', 'False', 'True', 'True', 
       'Produccion' , 40, 'Eniac.Win', 'FormulasABM' , NULL, NULL
            ,'True', 'S', 'N', 'N', 'N',NULL,'True')
GO

UPDATE RolesFunciones
   SET IdFuncion = 'FormulasABM'
  WHERE IdFuncion = 'ProductosComponentes'
GO

DELETE Funciones
  WHERE Id = 'ProductosComponentes'
GO
