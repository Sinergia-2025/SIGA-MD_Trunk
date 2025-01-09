Namespace JSonEntidades.Gestion.Soporte
   Public Class Ticket
      Public Property CodigoEmpresa As Long
      Public Property IdTipoNovedad As String
      Public Property NombreTipoNovedad As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property IdNovedad As Long
      Public Property FechaNovedad As Date
      Public Property Descripcion As String
      Public Property IdCategoriaNovedad As Integer
      Public Property NombreCategoriaNovedad As String
      Public Property ColorCategoriaNovedad As Integer?
      Public Property IdEstadoNovedad As Integer
      Public Property NombreEstadoNovedad As String
      Public Property ColorEstadoNovedad As Integer?
      Public Property EstadoFinalizado As Boolean
      Public Property Comentarios As String
      Public Property Interlocutor As String

      Public Property IdCliente As Long
      Public Property CodigoCliente As Long
      Public Property NombreCliente As String

      Public Property ComentariosLista As IEnumerable(Of Comentario)

   End Class
End Namespace