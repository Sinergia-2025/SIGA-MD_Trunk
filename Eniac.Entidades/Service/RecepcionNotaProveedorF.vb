
<Serializable()> _
Public Class RecepcionNotaProveedorF
   Inherits Eniac.Entidades.Entidad

#Region "Campos"


#End Region

#Region "Propiedades"


   Private _proveedor As Eniac.Entidades.Proveedor
   Public Property Proveedor() As Eniac.Entidades.Proveedor
      Get
         If Me._proveedor Is Nothing Then
            Me._proveedor = New Eniac.Entidades.Proveedor()
         End If
         Return _proveedor
      End Get
      Set(ByVal value As Eniac.Entidades.Proveedor)
         _proveedor = value
      End Set
   End Property

   Private _nota As Entidades.RecepcionNotaF
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

   Private _fechaEntrega As DateTime = DateTime.Now
   Public Property FechaEntrega() As DateTime
      Get
         Return _fechaEntrega
      End Get
      Set(ByVal value As DateTime)
         _fechaEntrega = value
      End Set
   End Property

   Private _observacion As String
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