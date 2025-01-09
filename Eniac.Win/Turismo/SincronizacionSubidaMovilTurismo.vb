#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class SincronizacionSubidaMovilTurismo

   Private WithEvents sincronizacion As Reglas.ServiciosRest.Turismo.SincronizacionSubidaMovilTurismo

   Private _publicos As Publicos

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.

      Try
         sincronizacion = New Reglas.ServiciosRest.Turismo.SincronizacionSubidaMovilTurismo()

         _publicos = New Publicos()
         _publicos.CargaComboDesdeEnum(cmbNombreCliente, GetType(Reglas.ServiciosRest.CobranzasMovil.Clientes.NombreCliente))
         _publicos.CargaComboDesdeEnum(cmbIncluir, GetType(Reglas.ServiciosRest.CobranzasMovil.Clientes.IncluirClientes))
         Dim tipoDireccionPrincipal As Entidades.TipoDireccion = New Entidades.TipoDireccion()
         tipoDireccionPrincipal.IdTipoDireccion = -1
         tipoDireccionPrincipal.NombreTipoDireccion = "Principal"

         _publicos.CargaComboTiposDirecciones(cmbDireccionCliente, 0, tipoDireccionPrincipal)

         If Reglas.Publicos.Simovil.Subida.IncluirProductos Then
            Me.chbPrecioConIVA.Checked = Reglas.Publicos.Simovil.PreciosConIVA
            Me.chbSoloProductosConStock.Checked = Reglas.Publicos.Simovil.SoloProductosConStock
         End If

         RefrescarGrilla()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      Try
         Cursor = Cursors.WaitCursor
         tstBarra.Enabled = False

         Dim nombreCliente As Reglas.ServiciosRest.CobranzasMovil.Clientes.NombreCliente
         If cmbNombreCliente.SelectedIndex > -1 Then
            nombreCliente = DirectCast(cmbNombreCliente.SelectedValue, Reglas.ServiciosRest.CobranzasMovil.Clientes.NombreCliente)
         Else
            ShowMessage("Debe seleccionar el origen del nombre del cliente")
            Exit Sub
         End If

         Dim incluirClientes As Reglas.ServiciosRest.CobranzasMovil.Clientes.IncluirClientes
         If cmbIncluir.SelectedIndex > -1 Then
            incluirClientes = DirectCast(cmbIncluir.SelectedValue, Reglas.ServiciosRest.CobranzasMovil.Clientes.IncluirClientes)
         Else
            ShowMessage("Debe seleccionar los clientes a incluir")
            Exit Sub
         End If

         Dim tipoDireccion As Entidades.TipoDireccion
         If cmbDireccionCliente.SelectedIndex > -1 Then
            tipoDireccion = DirectCast(cmbDireccionCliente.SelectedItem, Entidades.TipoDireccion)
         Else
            ShowMessage("Debe seleccionar el origen de la dirección del cliente")
            Exit Sub
         End If

         'Valido esto solo si tengo que sincronizar algo que contemple el campo PublicarEnWeb de la Sucursal hasta el momento 
         '     IncluirProductosPrecios
         If Reglas.Publicos.Simovil.Subida.IncluirProductosPrecios Then
            Dim cantidadSucursalesPublicarEnWeb As Integer = New Reglas.Sucursales().GetTodas(Entidades.Publicos.SiNoTodos.SI, False).Count
            If cantidadSucursalesPublicarEnWeb > 1 Then
               ShowMessage("Hay más de unas sucursal seleccionada para publicar en web. Solo puede haber una seleccionada.")
               Exit Sub
            End If
            If cantidadSucursalesPublicarEnWeb = 0 Then
               ShowMessage("No hay ninguna sucursal seleccionada para publicar en web. Debe haber una seleccionada.")
               Exit Sub
            End If
         End If

         Using frm As New SincronizacionSubidaMovilTurismoSincronizar()
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

               ResetearEstados()
               'sincronizacion.SubirInformacion(nombreCliente, tipoDireccion, incluirClientes, chbPrecioConIVA.Checked, chbSoloProductosConStock.Checked)
               sincronizacion.SubirInformacion(nombreCliente, tipoDireccion, incluirClientes, frm.AccionSeleccionada.Value)

               ShowMessage("Subida realizada existosamente.")

            End If
         End Using


      Catch ex As Reglas.ServiciosRest.ErrorResponseException
         ShowError(ex)
         MuestraInfo(ex)
      Catch ex As Exception
         ShowError(ex)
         MuestraInfo(ex)
      Finally
         MuestraFechaUltimaSincronizacion()
         tstBarra.Enabled = True
         Cursor = Cursors.Default
      End Try
   End Sub

   Public Sub sincronizacion_Avance(sender As Object, e As Reglas.ServiciosRest.SincronizacionEventArgs) Handles sincronizacion.Avance
      MuestraAvance(e)
   End Sub

   Public Sub sincronizacion_Estado(sender As Object, e As Reglas.ServiciosRest.SincronizacionEstadoEventArgs) Handles sincronizacion.Estado
      MostrarEstado(e)
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub RefrescarGrilla()
      MuestraAvance(Nothing)

      Dim version As String
      Try
         version = sincronizacion.GetVersion()
      Catch ex As Exception
         version = String.Empty
      End Try

      tssVersionAPI.Text = String.Format("Versión API: {0}", version)

      MuestraFechaUltimaSincronizacion()

      MuestraAvance(Nothing)

      cmbNombreCliente.SelectedValue = Reglas.Publicos.SimovilCobranzaNombreCliente ' Reglas.ServiciosRest.CobranzasMovil.Clientes.NombreCliente.NombreCliente
      cmbDireccionCliente.SelectedValue = Reglas.Publicos.SimovilCobranzaTipoDireccion  ' -1
      cmbIncluir.SelectedValue = Reglas.Publicos.SimovilCobranzaIncluirClientes

      MuestraInfo(Reglas.Publicos.SimovilCobranzaURLBase)

   End Sub

   Private Sub MuestraFechaUltimaSincronizacion()
      Dim fechaUltimaSincronizacion As DateTime?
      Try
         fechaUltimaSincronizacion = sincronizacion.GetFechaUltimaSincronizacion()
      Catch ex As Exception
         fechaUltimaSincronizacion = Nothing
      End Try

      Const prefijoLabelFechaUltimaSincronizacion As String = "Fecha última sincronización:"
      If fechaUltimaSincronizacion.HasValue Then
         lblFechaUltimaSincronizacion.Text = String.Format("{0} {1:dd/MM/yyyy HH:mm:ss}", prefijoLabelFechaUltimaSincronizacion, fechaUltimaSincronizacion.Value)
      Else
         lblFechaUltimaSincronizacion.Text = prefijoLabelFechaUltimaSincronizacion
      End If
   End Sub

   Private Sub MuestraAvance(avance As Reglas.ServiciosRest.SincronizacionEventArgs)
      If avance Is Nothing Then
         MuestraInfo(String.Empty)
         txtMensajeAvance.Text = String.Empty
         txtMetodoAvance.Text = String.Empty
         txtUrlAvance.Text = String.Empty
         grpAvance.Visible = False
      Else
         grpAvance.Visible = True
         MuestraInfo(avance.Mensaje)
         txtMensajeAvance.Text = avance.Mensaje
         txtMetodoAvance.Text = avance.Metodo
         If avance.Url IsNot Nothing Then
            txtUrlAvance.Text = avance.Url.ToString()
         Else
            txtUrlAvance.Text = String.Empty
         End If
      End If
      Application.DoEvents()
   End Sub

   Private Sub MuestraInfo(ex As Exception)
      MuestraInfo(ex.Message)
   End Sub

   Private Sub MuestraInfo(mensaje As String)
      tssInfo.Text = mensaje
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private estados As Dictionary(Of String, SincronizacionSubidaMovilEstadoTablaUserControl)
   Private Sub ResetearEstados()
      If estados IsNot Nothing Then
         For Each keyvalue As KeyValuePair(Of String, SincronizacionSubidaMovilEstadoTablaUserControl) In estados
            If pnlEstado.Controls.Contains(keyvalue.Value) Then
               pnlEstado.Controls.Remove(keyvalue.Value)
               keyvalue.Value.Dispose()
            End If
         Next
         estados.Clear()
      End If
   End Sub
   Private Sub MostrarEstado(estado As Reglas.ServiciosRest.SincronizacionEstadoEventArgs)
      If estados Is Nothing Then estados = New Dictionary(Of String, SincronizacionSubidaMovilEstadoTablaUserControl)()

      If Not estados.ContainsKey(estado.Metodo) Then
         Dim uc As New SincronizacionSubidaMovilEstadoTablaUserControl()
         estados.Add(estado.Metodo, uc)
         pnlEstado.Controls.Add(uc)
      End If

      estados(estado.Metodo).SetAvance(estado.Metodo.ToString(), estado.Estado.ToString(), estado.TotalRegistrosSubidos)
      Application.DoEvents()
   End Sub

End Class