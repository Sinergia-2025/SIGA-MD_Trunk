#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace ServiciosRest.Sincronizacion
   Public Interface ISyncBase
      Function SincronizarAutomaticamente(grabaArchivoLocal As Boolean, syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean

      Function EnviarAutomaticamente(grabaArchivoLocal As Boolean) As Boolean
      Function CargarDatos() As Boolean
      Function EnviarDatos(grabaArchivoLocal As Boolean) As Boolean


      Function ImportarAutomaticamente(syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Function DescargarDatos() As Boolean
      Function ValidarDatos(syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Function ImportarDatos() As Boolean


      Function GetEntityType() As Type

      ReadOnly Property DatosRecibidos As IList


      Event NotificarEstadoVerbose(sender As Object, e As NotificarEstadoEventDetalladoArgs)
      Event NotificarEstadoInformation(sender As Object, e As NotificarEstadoEventDetalladoArgs)


      Event LuegoObtenerCantidadRegistros(sender As Object, e As CantidadRegistrosEventArgs)

      Event RecibiendoDatos(sender As Object, e As RecibiendoDatosPaginaInicialEventArgs)
      Event RecibiendoDatosFinalizado(sender As Object, e As RecibiendoDatosPaginaInicialEventArgs)
      Event DespuesRecibiendoDatos(sender As Object, e As DatosRecibidosEventArgs)

   End Interface
End Namespace