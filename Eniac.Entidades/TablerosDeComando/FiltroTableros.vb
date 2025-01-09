Namespace TablerosDeComando
   Public Enum VerNombreCliente
      <Description("Nombre de Cliente")> NombreCliente
      <Description("Nombre de Fantasia")> NombreDeFantasia
   End Enum
   Public Class FiltroTableros
      Public Sub New()
      End Sub

      Public Sub New(categorias As ICollection(Of Entidades.Categoria), actualizarAplicacion As Entidades.Publicos.SiNoTodos, verNombreCliente As VerNombreCliente)
         Me.New()
         Me.Categorias = categorias
         Me.ActualizarAplicacion = actualizarAplicacion
         Me.VerNombreCliente = verNombreCliente
      End Sub
      Public Sub New(idTipoNovedad As String)
         Me.New()
         Me.IdTipoNovedad = idTipoNovedad
      End Sub
      Public Sub New(idTipoNovedad As String, descripcionesGlobalEntregas As ICollection(Of String))
         Me.New(idTipoNovedad)
         Me.DescripcionesGlobalEntregas = descripcionesGlobalEntregas
      End Sub

      Public Property Categorias As ICollection(Of Entidades.Categoria)
      Public Property ActualizarAplicacion As Entidades.Publicos.SiNoTodos
      Public Property VerNombreCliente As VerNombreCliente

      Public Property IdTipoNovedad As String
      Public Property DescripcionesGlobalEntregas As ICollection(Of String)
      Public Property IdEstados As ICollection(Of Integer)
      Public Property AgrupadoPorUsuario As Boolean
      Public Property MesesHistoricos As Integer

   End Class
End Namespace