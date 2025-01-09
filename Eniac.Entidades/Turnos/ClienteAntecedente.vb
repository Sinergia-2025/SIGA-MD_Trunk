<Serializable()> _
Public Class ClienteAntecedente
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdAntecedente
      IdCliente
      Valor
      FechaActualizacion
   End Enum

   Private _antecedente As Entidades.Antecedente
   Public Property Antecedente() As Entidades.Antecedente
      Get
         If Me._antecedente Is Nothing Then
            Me._antecedente = New Entidades.Antecedente()
         End If
         Return _antecedente
      End Get
      Set(ByVal value As Entidades.Antecedente)
         _antecedente = value
      End Set
   End Property

   Private _Cliente As Entidades.Cliente
   Public Property Cliente() As Entidades.Cliente
      Get
         If Me._Cliente Is Nothing Then
            Me._Cliente = New Entidades.Cliente()
         End If
         Return _Cliente
      End Get
      Set(ByVal value As Entidades.Cliente)
         _Cliente = value
      End Set
   End Property

   Private _valor As String
   Public Property Valor() As String
      Get
         Return _valor
      End Get
      Set(ByVal value As String)
         _valor = value
      End Set
   End Property

   Private _fechaActualizacion As DateTime
   Public Property FechaActualizacion() As DateTime
      Get
         Return _fechaActualizacion
      End Get
      Set(ByVal value As DateTime)
         _fechaActualizacion = value
      End Set
   End Property

End Class
