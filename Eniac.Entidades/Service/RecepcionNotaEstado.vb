
<Serializable()> _
Public Class RecepcionNotaEstado
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _nota As Entidades.RecepcionNota
   Private _fechaEstado As DateTime = DateTime.Now
   Private _estado As RecepcionEstado = Nothing
   Private _observacion As String

#End Region

#Region "Propiedades"

   Public Property Nota() As Entidades.RecepcionNota
      Get
         If Me._nota Is Nothing Then
            Me._nota = New Entidades.RecepcionNota()
         End If
         Return _nota
      End Get
      Set(ByVal value As Entidades.RecepcionNota)
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

   Public Property Estado() As RecepcionEstado
      Get
         Return _estado
      End Get
      Set(ByVal value As RecepcionEstado)
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