Option Strict On
Option Explicit On
Namespace Cache
   Public Class SeguridadCacheHandler
      Inherits CacheHandlerCommon

#Region "Singleton"
      Private Shared _instancia As SeguridadCacheHandler = New SeguridadCacheHandler()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As SeguridadCacheHandler
         Get
            Return _instancia
         End Get
      End Property

#End Region

      Private _tipos As Ayudante.Cache.Seguridad.CacheUsuarios
      Public ReadOnly Property Usuarios() As Ayudante.Cache.Seguridad.CacheUsuarios
         Get
            Return GetCacheInstance(_tipos, Function() New Ayudante.Cache.Seguridad.CacheUsuarios())
         End Get
      End Property

   End Class
End Namespace