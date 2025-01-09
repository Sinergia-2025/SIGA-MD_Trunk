<Serializable()> _
Public Class Banco
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "Bancos"

#Region "Campos"

   Private _idBanco As Integer
   Private _nombreBanco As String
   Private _debitoDirecto As Boolean
   Private _empresa As Integer
   Private _convenio As Integer
   Private _servicio As String

#End Region

#Region "Enumeraciones"

   Public Enum Codigos
      Nacion_Argentina = 11
      Citibank = 16
      Santander_Rio = 72
      Macro = 285
      Credicoop = 191
   End Enum

#End Region

#Region "Propiedades"

   Public Property IdBanco() As Integer
      Get
         Return Me._idBanco
      End Get
      Set(ByVal value As Integer)
         Me._idBanco = value
      End Set
   End Property
   Public Property NombreBanco() As String
      Get
         Return Me._nombreBanco
      End Get
      Set(ByVal value As String)
         If value.Length <= 40 Then
            Me._nombreBanco = value
         Else
            Throw New Exception("La descripción del Banco no puede tener mas de 40 caracteres")
         End If
      End Set
   End Property

   Public Property DebitoDirecto() As Boolean
      Get
         Return Me._debitoDirecto
      End Get
      Set(ByVal value As Boolean)
         Me._debitoDirecto = value
      End Set
   End Property

   Public Property Empresa() As Integer
      Get
         Return _empresa
      End Get
      Set(ByVal value As Integer)
         _empresa = value
      End Set
   End Property

   Public Property Convenio() As Integer
      Get
         Return _convenio
      End Get
      Set(ByVal value As Integer)
         _convenio = value
      End Set
   End Property

   Public Property Servicio() As String
      Get
         Return _servicio
      End Get
      Set(ByVal value As String)
         _servicio = value
      End Set
   End Property

#End Region

End Class