Namespace JSonEntidades.Exportaciones.Pirelli
   Public Class Request
      Public Enum Campos
         JerarquiaId
         Clave
         Lineas
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property JerarquiaId As Integer
      Public Property Clave As String
      Public Property Lineas As List(Of Ventas)

   End Class

   Public Class Ventas
      Public Enum Campos
         SucursalId
         ProductoId
         Fecha
         Cantidad
      End Enum

      '# Solo las propiedades que voy a enviar
      Public Property SucursalId As Integer
      Public Property ProductoId As Integer
      Public Property Fecha As String
      Public Property Cantidad As Integer
   End Class

End Namespace