Namespace JSonEntidades.CobranzasMovil
   Public Class Embarcaciones
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer


      Public Property IdEmbarcacion As Long 
      Public Property CodigoEmbarcacion As Long
      Public Property NombreEmbarcacion As String
      Public Property Matricula As String

      Public Property Clientes As IEnumerable(Of Long)

      Public Property Activo As Boolean
      Public Property EnMantenimiento As Boolean

      Public Property Estado As String
      Public Property Situacion As String
      Public Property EstadoBotado As String             '' VERDE / AMARILLO / ROJO
      Public Property BotadoRestringidoPrefectura As Boolean

      Public Property IdCama As Long
      Public Property CodigoCama As String
      Public Property IdNave As Short
      Public Property NombreNave As String


      Public Property IdCategoriaEmbarcacion As Integer
      Public Property NombreCategoriaEmbarcacion As String
      Public Property IdMarcaEmbarcacion As Integer
      Public Property NombreMarcaEmbarcacion As String
      Public Property IdModeloEmbarcacion As Integer
      Public Property NombreModeloEmbarcacion As String

      Public Property TieneObservacionesTurno As Boolean
      Public Property ObservacionesTurno As String
      Public Property BloqueaTurno As Boolean

   End Class
End Namespace