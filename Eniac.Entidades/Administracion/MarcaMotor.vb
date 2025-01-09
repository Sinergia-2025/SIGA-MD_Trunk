
Public Class MarcaMotor
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdMarcaMotor
      NombreMarcaMotor
   End Enum

#Region "Propiedades"

   Private _idMarcaMotor As Integer

   Public Property IdMarcaMotor() As Integer
      Get
         Return _idMarcaMotor
      End Get
      Set(ByVal value As Integer)
         _idMarcaMotor = value
      End Set
   End Property

   Private _nombreMarcaMotor As String

   Public Property NombreMarcaMotor() As String
      Get
         Return _nombreMarcaMotor
      End Get
      Set(ByVal value As String)
         _nombreMarcaMotor = value
      End Set
   End Property

#End Region

End Class