
<Serializable()> _
Public Class RecepcionNotaEstadoF
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _nota As Entidades.RecepcionNotaF
   Private _fechaEstado As DateTime = DateTime.Now
   Private _estado As RecepcionEstadoF = Nothing
   Private _observacion As String

#End Region

#Region "Propiedades"

   Public Property Nota() As Entidades.RecepcionNotaF
      Get
         If Me._nota Is Nothing Then
            Me._nota = New Entidades.RecepcionNotaF()
         End If
         Return _nota
      End Get
      Set(ByVal value As Entidades.RecepcionNotaF)
         _nota = value
      End Set
   End Property
   Public Property FechaEstado() As DateTime
      Get
         Return _fechaEstado
      End Get
      Set(ByVal value As DateTime)
         _fechaEstado = value
      End Set
   End Property
   Public Property Estado() As RecepcionEstadoF
      Get
         Return _estado
      End Get
      Set(ByVal value As RecepcionEstadoF)
         _estado = value
      End Set
   End Property
   Public Property Observacion() As String
      Get
         Return _observacion
      End Get
      Set(ByVal value As String)
         _observacion = value
      End Set
   End Property

#End Region

End Class