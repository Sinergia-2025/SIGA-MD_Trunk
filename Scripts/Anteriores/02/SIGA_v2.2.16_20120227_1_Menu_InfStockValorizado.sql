
--Inserto la pantalla nueva

INSERT INTO Funciones
     (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
     , IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
     ('InfStockValorizado', 'Inf. Stock Valorizado', 'Inf. Stock Valorizado', 'True', 'False', 'True', 'True',
      'Stock', 40, 'Eniac.Win', 'InfStockValorizado', NULL)
GO

UPDATE RolesFunciones 
   SET IdFuncion = 'InfStockValorizado'
 WHERE IdFuncion = 'CapitalInvertido'
GO

-- Ajusto la posicion de la pantalla estandar

DELETE Funciones
 WHERE Id = 'CapitalInvertido'
GO
