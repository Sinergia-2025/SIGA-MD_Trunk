Option Strict On
Option Explicit On
Public Class CmdSincronizacionSubidaMovil
   Implements Eniac.Win.IComandoMenu

   Private Const Tag As String = "CmdSincronizacionSubidaMovil.Ejecutar"

   Private WithEvents sincronizacion As Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil

   Public Sub Ejecutar(owner As IWin32Window, idFuncion As String) Implements IComandoMenu.Ejecutar
      My.Application.Log.WriteEntry(String.Format("{0} - Inicia", Tag), TraceEventType.Information)

      My.Application.Log.WriteEntry(String.Format("{0} - Instancia regla de SincronizacionSubidaMovil", Tag), TraceEventType.Verbose)
      sincronizacion = New Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil()

      Dim precioConIva As Boolean = False
      Dim soloProductosConStock As Boolean = False
      If Reglas.Publicos.Simovil.Subida.IncluirProductos Then
         precioConIva = Reglas.Publicos.Simovil.PreciosConIVA
         soloProductosConStock = Reglas.Publicos.Simovil.SoloProductosConStock
      End If

      Dim tipoDireccion = New Reglas.TiposDirecciones().GetUna(Reglas.Publicos.SimovilCobranzaTipoDireccion, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      If tipoDireccion Is Nothing Then
         tipoDireccion = New Entidades.TipoDireccion()
         tipoDireccion.IdTipoDireccion = -1
         tipoDireccion.NombreTipoDireccion = "Principal"
      End If
      Dim nombreCliente = Reglas.Publicos.SimovilCobranzaNombreCliente
      Dim incluirClientes = Reglas.Publicos.SimovilCobranzaIncluirClientes
      Dim incluirSucursales = Reglas.Publicos.SimovilCobranzaSucursales

      My.Application.Log.WriteEntry(String.Format("{0} - Antes de ejecutar SubirInformacion()", Tag), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - nombreCliente: {1}", Tag, nombreCliente), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - tipoDireccion: {1}", Tag, tipoDireccion.NombreTipoDireccion), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - incluirClientes: {1}", Tag, incluirClientes), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - precioConIva: {1}", Tag, precioConIva), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - soloProductosConStock: {1}", Tag, soloProductosConStock), TraceEventType.Verbose)
      My.Application.Log.WriteEntry(String.Format("{0} - incluirSucursales: {1}", Tag, incluirSucursales), TraceEventType.Verbose)

      sincronizacion.SubirInformacion(nombreCliente, tipoDireccion, incluirClientes,
                                      precioConIva, soloProductosConStock, incluirSucursales)

      My.Application.Log.WriteEntry(String.Format("{0} - Finaliza", Tag), TraceEventType.Information)

   End Sub

   Public Sub sincronizacion_Avance(sender As Object, e As Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil.SincronizacionSubidaMovilEventArgs) Handles sincronizacion.Avance
      MuestraAvance(e)
   End Sub


   Private Sub MuestraAvance(avance As Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil.SincronizacionSubidaMovilEventArgs)
      If avance IsNot Nothing Then
         My.Application.Log.WriteEntry(String.Format("{0} - {1}", Tag, avance.Mensaje), TraceEventType.Verbose)
      End If
   End Sub

End Class