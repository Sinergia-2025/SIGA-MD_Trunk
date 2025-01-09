Public Class MotivoDevolucion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdMotivoDevolucion
      NombreMotivoDevolucion
   End Enum

   Private _idMotivoDevolucion As Integer
   Public Property IdMotivoDevolucion() As Integer
      Get
         Return _idMotivoDevolucion
      End Get
      Set(ByVal value As Integer)
         _idMotivoDevolucion = value
      End Set
   End Property
   Private _nombreMotivoDevolucion As String
   Public Property NombreMotivoDevolucion() As String
      Get
         Return _nombreMotivoDevolucion
      End Get
      Set(ByVal value As String)
         _nombreMotivoDevolucion = value
      End Set
   End Property
End Class