Namespace Cache
   Public Class TurnosCacheHandler
      Inherits CacheHandlerCommon

#Region "Singleton"
      Private Shared _instancia As TurnosCacheHandler = New TurnosCacheHandler()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As TurnosCacheHandler
         Get
            Return _instancia
         End Get
      End Property

#End Region

      Private _estadosTurnos As Ayudante.Cache.Turnos.CacheTurnosEstados
      Public ReadOnly Property EstadosTurnos() As Ayudante.Cache.Turnos.CacheTurnosEstados
         Get
            Return GetCacheInstance(_estadosTurnos, Function() New Ayudante.Cache.Turnos.CacheTurnosEstados())
         End Get
      End Property

      Private _tiposTurnos As Ayudante.Cache.Turnos.CacheTiposTurnos
      Public ReadOnly Property TiposTurnos() As Ayudante.Cache.Turnos.CacheTiposTurnos
         Get
            Return GetCacheInstance(_tiposTurnos, Function() New Ayudante.Cache.Turnos.CacheTiposTurnos())
         End Get
      End Property

      Private _calendarios As Ayudante.Cache.Turnos.CacheCalendarios
      Public ReadOnly Property Calendarios() As Ayudante.Cache.Turnos.CacheCalendarios
         Get
            Return GetCacheInstance(_calendarios, Function() New Ayudante.Cache.Turnos.CacheCalendarios())
         End Get
      End Property

   End Class
End Namespace