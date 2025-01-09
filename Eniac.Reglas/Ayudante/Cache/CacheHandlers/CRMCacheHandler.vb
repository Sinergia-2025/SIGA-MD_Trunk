Option Strict On
Option Explicit On
Namespace Cache
   Public Class CRMCacheHandler
      Inherits CacheHandlerCommon

#Region "Singleton"
      Private Shared _instancia As CRMCacheHandler = New CRMCacheHandler()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CRMCacheHandler
         Get
            Return _instancia
         End Get
      End Property

#End Region

      Private _tipos As Ayudante.BusquedaCacheadaCRMTipoNovedad
      Public ReadOnly Property Tipos() As Ayudante.BusquedaCacheadaCRMTipoNovedad
         Get
            Return GetCacheInstance(_tipos, Function() New Ayudante.BusquedaCacheadaCRMTipoNovedad())
         End Get
      End Property

      Private _categorias As Ayudante.BusquedaCacheadaCRMCategoriaNovedad
      Public ReadOnly Property Categorias() As Ayudante.BusquedaCacheadaCRMCategoriaNovedad
         Get
            Return GetCacheInstance(_categorias, Function() New Ayudante.BusquedaCacheadaCRMCategoriaNovedad())
         End Get
      End Property

      Private _estados As Ayudante.BusquedaCacheadaCRMEstadoNovedad
      Public ReadOnly Property Estados() As Ayudante.BusquedaCacheadaCRMEstadoNovedad
         Get
            Return GetCacheInstance(_estados, Function() New Ayudante.BusquedaCacheadaCRMEstadoNovedad())
         End Get
      End Property

      Private _prioridades As Ayudante.BusquedaCacheadaCRMPrioridadNovedad
      Public ReadOnly Property Prioridades() As Ayudante.BusquedaCacheadaCRMPrioridadNovedad
         Get
            Return GetCacheInstance(_prioridades, Function() New Ayudante.BusquedaCacheadaCRMPrioridadNovedad())
         End Get
      End Property

      Private _medios As Ayudante.BusquedaCacheadaCRMMedioComunicacionNovedad
      Public ReadOnly Property Medios() As Ayudante.BusquedaCacheadaCRMMedioComunicacionNovedad
         Get
            Return GetCacheInstance(_medios, Function() New Ayudante.BusquedaCacheadaCRMMedioComunicacionNovedad())
         End Get
      End Property

      Private _metodos As Ayudante.BusquedaCacheadaMetodoResolucionNovedad
      Public ReadOnly Property Metodos() As Ayudante.BusquedaCacheadaMetodoResolucionNovedad
         Get
            Return GetCacheInstance(_metodos, Function() New Ayudante.BusquedaCacheadaMetodoResolucionNovedad())
         End Get
      End Property

      Private _tiposComentarios As Ayudante.BusquedaCacheadaCRMTipoComentarioNovedad
      Public ReadOnly Property TiposComentarios() As Ayudante.BusquedaCacheadaCRMTipoComentarioNovedad
         Get
            Return GetCacheInstance(_tiposComentarios, Function() New Ayudante.BusquedaCacheadaCRMTipoComentarioNovedad())
         End Get
      End Property

   End Class
End Namespace