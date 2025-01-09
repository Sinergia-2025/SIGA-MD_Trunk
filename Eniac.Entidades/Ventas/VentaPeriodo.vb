<Serializable()>
Public Class VentaPeriodo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdPeriodo
      DescripcionPeriodo
      Dias

   End Enum

#Region "Campos"

   Private _idPeriodo As Integer
   Private _descripcionPeriodo As String
   Private _dias As Integer

#End Region

#Region "Propiedades"

   Public Property IdPeriodo() As Integer
      Get
         Return Me._idPeriodo
      End Get
      Set(ByVal value As Integer)
         Me._idPeriodo = value
      End Set
   End Property
   Public Property DescripcionPeriodo() As String
      Get
         Return Me._descripcionPeriodo
      End Get
      Set(ByVal value As String)
         If value.Length <= 50 Then
            Me._descripcionPeriodo = value
         Else
            Throw New Exception("La descripción del Período no puede tener mas de 50 caracteres")
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