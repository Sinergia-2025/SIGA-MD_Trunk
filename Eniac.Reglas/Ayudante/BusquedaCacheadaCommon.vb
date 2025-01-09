Namespace Ayudante
   Public MustInherit Class BusquedaCacheadaCommon(Of T As Entidades.Entidad)
      Implements IDisposable

      Private _getTodos As Func(Of List(Of T))
      'Private _predicate As System.Func(Of T, Boolean)

      Public Sub New(getTodos As Func(Of List(Of T)))
         _getTodos = getTodos
      End Sub

      Private _cache As List(Of T)

      Protected Sub InicializaCache()
         If _cache Is Nothing OrElse _cache.Count = 0 Then
            _cache = _getTodos()
         End If
      End Sub

      Protected Function Buscar(predicate As Func(Of T, Boolean)) As T
         InicializaCache()
         Return _cache.FirstOrDefault(predicate)
      End Function

      Public Function GetTodos() As List(Of T)
         InicializaCache()
         Return _cache
      End Function

      Public Sub LimpiarCache()
         'Limpio el cache
         _cache.Clear()
         _cache = Nothing
      End Sub

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls
      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
         If Not Me.disposedValue Then
            If disposing AndAlso _cache IsNot Nothing Then
               _cache.Clear()
            End If
         End If
         Me.disposedValue = True
      End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
         ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
         Dispose(True)
         GC.SuppressFinalize(Me)
      End Sub
#End Region

   End Class

   Public MustInherit Class BusquedaCacheadaCommonCRM(Of T As Entidades.CRMEntidad)
      Inherits BusquedaCacheadaCommon(Of T)
      Public Sub New(getTodos As Func(Of List(Of T)))
         MyBase.New(getTodos)
      End Sub

      Public Overloads Function GetTodos(idTipoNovedad As String) As List(Of T)
         Return GetTodos().Where(Function(x) x.IdTipoNovedad = idTipoNovedad).ToList()
      End Function

   End Class

End Namespace