#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace ServiciosRest.Sincronizacion
   Public Interface ISyncRegla(Of T, E)
      Function Convertir(transporte As List(Of T)) As List(Of E)
      Function ValidarDatos(transporte As List(Of T), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Function ValidarDatos(transporte As List(Of E), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean

      Function ImportarDatos(transporte As List(Of T)) As Boolean
      Function ImportarDatos(transporte As List(Of E)) As Boolean

      Event AvanceValidarDatos(sender As Object, e As AvanceProcesoEventArgs)
      Event AvanceImportarDatos(sender As Object, e As AvanceProcesoEventArgs)

   End Interface

   Public Class AvanceProcesoEventArgs
      Public Property RegistroActual As Long
      Public Property TotalRegistros As Long
      Public Property Datos As Entidades.JSonEntidades.Archivos.IValidable
      Public ReadOnly Property Estado As String
         Get
            If Datos Is Nothing Then Return ""
            Return Datos.___Estado
         End Get
      End Property
      Public Sub New(registroActual As Long, totalRegistros As Long, datos As Entidades.JSonEntidades.Archivos.IValidable)
         Me.RegistroActual = registroActual
         Me.TotalRegistros = totalRegistros
         Me.Datos = datos
      End Sub
   End Class

End Namespace