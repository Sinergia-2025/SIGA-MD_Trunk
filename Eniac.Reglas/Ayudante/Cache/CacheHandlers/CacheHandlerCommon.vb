Namespace Cache
   Public MustInherit Class CacheHandlerCommon
      Implements IDisposable

      Private _componentes As List(Of IDisposable) = New List(Of IDisposable)()

      Protected Sub AddComponente(obj As IDisposable)
         _componentes.Add(obj)
      End Sub

      '#Region "Singleton"
      '      Private Shared _instancia As CacheHandlerCommon = New CacheHandlerCommon()
      '      ''' <summary>
      '      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      '      ''' </summary>
      '      ''' <returns>Instancia del Cache de Parámetros</returns>
      '      ''' <remarks></remarks>
      '      Public Shared ReadOnly Property Instancia As CacheHandlerCommon
      '         Get
      '            Return _instancia
      '         End Get
      '      End Property
      '#End Region

#Region "Cache Singleton"
      Private _lockCache As New Object()
      Protected Function GetCacheInstance(Of T As IDisposable)(ByRef cache As T, newCache As Func(Of T)) As T
         If cache Is Nothing Then
            SyncLock _lockCache
               If cache Is Nothing Then
                  cache = newCache()
                  AddComponente(cache)
               End If
            End SyncLock
         End If
         Return cache
      End Function
#End Region

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
         If Not Me.disposedValue Then
            If disposing Then
               _componentes.All(Function(x)
                                   x.Dispose()
                                   Return True
                                End Function)
               _componentes.Clear()
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
End Namespace