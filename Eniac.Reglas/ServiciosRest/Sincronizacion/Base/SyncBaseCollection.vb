#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace ServiciosRest.Sincronizacion
   Public Class SyncBaseCollection
      Inherits Dictionary(Of Type, ISyncBase)
      Implements IDisposable, ISyncBase

      Public Event NotificarEstadoVerbose(sender As Object, e As NotificarEstadoEventDetalladoArgs) Implements ISyncBase.NotificarEstadoVerbose
      Public Event NotificarEstadoInformation(sender As Object, e As NotificarEstadoEventDetalladoArgs) Implements ISyncBase.NotificarEstadoInformation
      Public Event LuegoObtenerCantidadRegistros(sender As Object, e As CantidadRegistrosEventArgs) Implements ISyncBase.LuegoObtenerCantidadRegistros
      Public Event RecibiendoDatos(sender As Object, e As RecibiendoDatosPaginaInicialEventArgs) Implements ISyncBase.RecibiendoDatos
      Public Event RecibiendoDatosFinalizado(sender As Object, e As RecibiendoDatosPaginaInicialEventArgs) Implements ISyncBase.RecibiendoDatosFinalizado
      Public Event DespuesRecibiendoDatos(sender As Object, e As DatosRecibidosEventArgs) Implements ISyncBase.DespuesRecibiendoDatos

      Protected Sub OnNotificarEstadoVerbose(sender As Object, e As NotificarEstadoEventDetalladoArgs)
         RaiseEvent NotificarEstadoVerbose(sender, e)
      End Sub
      Protected Sub OnNotificarEstadoInformation(sender As Object, e As NotificarEstadoEventDetalladoArgs)
         RaiseEvent NotificarEstadoInformation(sender, e)
      End Sub
      Protected Sub OnLuegoObtenerCantidadRegistros(sender As Object, e As CantidadRegistrosEventArgs)
         RaiseEvent LuegoObtenerCantidadRegistros(sender, e)
      End Sub
      Protected Sub OnRecibiendoDatos(sender As Object, e As RecibiendoDatosPaginaInicialEventArgs)
         RaiseEvent RecibiendoDatos(sender, e)
      End Sub
      Protected Sub OnRecibiendoDatosFinalizado(sender As Object, e As RecibiendoDatosPaginaInicialEventArgs)
         RaiseEvent RecibiendoDatosFinalizado(sender, e)
      End Sub
      Protected Sub OnDespuesRecibiendoDatos(sender As Object, e As DatosRecibidosEventArgs)
         RaiseEvent DespuesRecibiendoDatos(sender, e)
      End Sub


      Public Shadows Function Add(item As ISyncBase) As ISyncBase
         AddHandler item.NotificarEstadoVerbose, AddressOf OnNotificarEstadoVerbose
         AddHandler item.NotificarEstadoInformation, AddressOf OnNotificarEstadoInformation
         AddHandler item.LuegoObtenerCantidadRegistros, AddressOf OnLuegoObtenerCantidadRegistros
         AddHandler item.RecibiendoDatos, AddressOf OnRecibiendoDatos
         AddHandler item.RecibiendoDatosFinalizado, AddressOf OnRecibiendoDatosFinalizado
         AddHandler item.DespuesRecibiendoDatos, AddressOf OnDespuesRecibiendoDatos

         MyBase.Add(item.GetEntityType(), item)
         Return item
      End Function

      Public Function GetEntityType() As Type Implements ISyncBase.GetEntityType
         Return Me.GetType()
      End Function

      Public Function SincronizarAutomaticamente(grabaArchivoLocal As Boolean) As Boolean
         Return SincronizarAutomaticamente(grabaArchivoLocal, Me)
      End Function
      Public Function SincronizarAutomaticamente(grabaArchivoLocal As Boolean, syncs As SyncBaseCollection) As Boolean Implements ISyncBase.SincronizarAutomaticamente
         ImportarAutomaticamente(syncs)
         EnviarAutomaticamente(grabaArchivoLocal)
      End Function

      Public Function EnviarAutomaticamente(grabaArchivoLocal As Boolean) As Boolean Implements ISyncBase.EnviarAutomaticamente
         Return Me.All(Function(x) x.Value.EnviarAutomaticamente(grabaArchivoLocal))
      End Function
      Public Function CargarDatos() As Boolean Implements ISyncBase.CargarDatos
         Return Me.All(Function(x) x.Value.CargarDatos())
      End Function
      Public Function EnviarDatos(grabaArchivoLocal As Boolean) As Boolean Implements ISyncBase.EnviarDatos
         Return Me.All(Function(x) x.Value.EnviarDatos(grabaArchivoLocal))
      End Function

      Public Function ImportarAutomaticamente(syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean Implements ISyncBase.ImportarAutomaticamente
         Return Me.All(Function(x) x.Value.ImportarAutomaticamente(syncs))
      End Function
      Public Function DescargarDatos() As Boolean Implements ISyncBase.DescargarDatos
         Return Me.All(Function(x) x.Value.DescargarDatos())
      End Function
      Public Function ImportarDatos() As Boolean Implements ISyncBase.ImportarDatos
         Return Me.All(Function(x) x.Value.ImportarDatos())
      End Function
      Public Function ValidarDatos(syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean Implements ISyncBase.ValidarDatos
         Return Me.All(Function(x) x.Value.ValidarDatos(syncs))
      End Function

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      <DebuggerStepThrough()>
      Protected Overridable Sub Dispose(disposing As Boolean)
         If Not Me.disposedValue Then
            If disposing Then
               Me.All(Function(x)
                         RemoveHandler x.Value.NotificarEstadoVerbose, AddressOf OnNotificarEstadoVerbose
                         RemoveHandler x.Value.NotificarEstadoInformation, AddressOf OnNotificarEstadoInformation
                         RemoveHandler x.Value.LuegoObtenerCantidadRegistros, AddressOf OnLuegoObtenerCantidadRegistros
                         RemoveHandler x.Value.RecibiendoDatos, AddressOf OnRecibiendoDatos
                         RemoveHandler x.Value.RecibiendoDatosFinalizado, AddressOf OnRecibiendoDatosFinalizado
                         RemoveHandler x.Value.DespuesRecibiendoDatos, AddressOf OnDespuesRecibiendoDatos

                         Return True
                      End Function)
            End If
         End If
         Me.disposedValue = True
      End Sub

      ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
      'Protected Overrides Sub Finalize()
      '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      '    Dispose(False)
      '    MyBase.Finalize()
      'End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      <DebuggerStepThrough()>
      Public Sub Dispose() Implements IDisposable.Dispose
         ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
         Dispose(True)
         GC.SuppressFinalize(Me)
      End Sub
#End Region

      Public ReadOnly Property DatosRecibidos As IList Implements ISyncBase.DatosRecibidos
         Get
            Return Nothing
         End Get
      End Property

      Private _datosRecibidosCustom As New Dictionary(Of Type, IList)()
      Public Function AgregarDatosRecibidosCustom(tipo As Type, lista As IList) As SyncBaseCollection
         If Not _datosRecibidosCustom.ContainsKey(tipo) Then
            _datosRecibidosCustom.Add(tipo, lista)
         Else
            _datosRecibidosCustom(tipo) = lista
         End If
         Return Me
      End Function
      Public Function DatosRecibidosCustom(tipo As Type) As IList
         If ContainsKey(tipo) Then
            Return Me(tipo).DatosRecibidos
         Else
            If _datosRecibidosCustom.ContainsKey(tipo) Then
               Return _datosRecibidosCustom(tipo)
            End If
         End If
         Return Nothing
      End Function

   End Class
End Namespace