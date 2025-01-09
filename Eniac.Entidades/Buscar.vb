<Serializable()> _
Public Class Buscar
    Inherits Entidad

    Private _columna As String
    Private _valor As Object

   Public Sub New()
   End Sub
   Public Sub New(columna As String, valor As String)
      Me.New()
      _columna = columna
      _valor = valor
   End Sub
    Public Property Columna() As String
        Get
            Return _columna
        End Get
        Set(ByVal value As String)
            Me._columna = value
        End Set
    End Property

    Public Property Valor() As Object
        Get
            Return _valor
        End Get
        Set(ByVal value As Object)
            Me._valor = value
        End Set
   End Property

End Class
