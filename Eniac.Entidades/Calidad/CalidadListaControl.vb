Public Class CalidadListaControl
   Inherits Entidad
   Public Const NombreTabla As String = "CalidadListasControl"

   Public Enum Columnas
      IdListaControl
      NombreListaControl
      Orden
      IdListaControlTipo

   End Enum

   Public Property IdListaControl As Integer
   Public Property NombreListaControl As String
   Public Property Orden As Integer
   Public Property Tipo As CalidadListaControlTipo
   Public Property Items As List(Of CalidadListaControlConfig)

   Public Sub New()
      Tipo = New CalidadListaControlTipo()
      Items = New List(Of CalidadListaControlConfig)()
   End Sub


#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdListaControlTipo As Integer
      Get
         Return Tipo.IdListaControlTipo
      End Get
   End Property
#End Region
End Class