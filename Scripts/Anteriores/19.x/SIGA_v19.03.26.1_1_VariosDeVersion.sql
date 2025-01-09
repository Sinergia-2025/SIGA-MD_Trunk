
PRINT ''
PRINT '1. Cambiar Nombre Libro de IVA Dinamico Ventas por Libro de IVA Ventas V2'

UPDATE Funciones
   SET Nombre = 'Libro de IVA Ventas (v2)'
     , Descripcion = 'Libro de IVA Ventas (v2)'
  WHERE Id = 'LibrodeIvaVentasV2'
GO
