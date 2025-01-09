
UPDATE Funciones SET
    Nombre = 'ABM de Impuestos'  
   ,Descripcion = 'ABM de Impuestos'  
   ,IdPadre = 'AFIP'
   ,Posicion = 110
  WHERE ID = 'ImpuestosABM'
GO

UPDATE Funciones SET 
    Nombre = 'ABM de Tipos de Impuestos'  
   ,Descripcion = 'ABM de Tipos de Impuestos'  
   ,IdPadre = 'AFIP'
   ,Posicion = 120
  WHERE ID = 'TiposImpuestosABM'
GO
