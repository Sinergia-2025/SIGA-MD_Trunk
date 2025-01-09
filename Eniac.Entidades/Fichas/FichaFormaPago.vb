<Serializable()>
Public Class FichaFormaPago
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _idFormasPago As Integer
   Private _descripcionFormasPago As String
   Private _dias As Integer

#End Region

#Region "Propiedades"

   Public Property IdFormasPago() As Integer
      Get
         Return Me._idFormasPago
      End Get
      Set(ByVal value As Integer)
         Me._idFormasPago = value
      End Set
   End Property
   Public Property DescripcionFormasPago() As String
      Get
         Return Me._descripcionFormasPago
      End Get
      Set(ByVal value As String)
         If value.Length <= 50 Then
            Me._descripcionFormasPago = value
         Else
            Throw New Exception("La descripción de la Forma de Pago no puede tener mas de 50 caracteres")
         End If
      End Set
   End Property
   Public Property Dias() As Integer
      Get
         Return Me._dias
      End Get
      Set(ByVal value As Integer)
         Me._dias = value
      End Set
   End Property

#End Region

End Class