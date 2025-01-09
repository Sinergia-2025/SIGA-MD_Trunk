Option Strict On
Option Explicit On
Option Infer On
Imports Eniac.Entidades.Publicos

Public Class PreventaV3SeleccionarRutasPedidosPendientes

   Private _publicos As Publicos

   Public Property RutasSeleccionadas As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)
   Public Property tiposComprobantes As List(Of Entidades.TipoComprobante)

   Public Sub New()
      InitializeComponent()
      RutasSeleccionadas = New List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)()
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
         MostrarRutas()

         cmbTiposComprobantesFact.Initializar(True, True, True, False, "VENTAS",,,, True)
         cmbTiposComprobantesFact.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         cmbTiposComprobantesFact.Enabled = Reglas.Publicos.ParametrosSiMovil.SolicitaTipoComprobante

         Dim oTiposComprobantes = New Reglas.TiposComprobantes()
         tiposComprobantes = oTiposComprobantes.GetHabilitados(actual.Sucursal.Id,
                                                               "",
                                                               "VENTAS",
                                                               Tipo2:="",
                                                               AfectaCaja:="",
                                                               UsaFacturacionRapida:="",
                                                               UsaFacturacion:=True,
                                                               IgnoraSucursal:=False,
                                                               esRecibo:=Nothing,
                                                               coeficionesStock:=Nothing,
                                                               grabaLibro:=Nothing,
                                                               esReciboClienteVinculado:=Nothing, coeficienteValor:=Nothing, importeComprobante:=Nothing,
                                                               esElectronico:=Nothing, clase:=String.Empty)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub radTodas_CheckedChanged(sender As Object, e As EventArgs) Handles radTodas.CheckedChanged
      Try
         HabilitaControles(0)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub HabilitaControles(delta As Integer)
      chbRutas.Enabled = radSeleccionadas.Checked
      btnAceptar.Enabled = radTodas.Checked OrElse (chbRutas.CheckedItems.Count + delta) > 0
   End Sub

   Private Sub MostrarRutas()
      InicializaBackgroundWorker()
   End Sub
   Private Sub MostrarRutasContinue(rutas As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas))
      Try
         chbRutas.Items.AddRange(rutas.ToArray())
         If rutas.Count = 0 Then
            lblEstadoAvance.Text = "No se encontraron rutas pendientes de descargar"
         Else
            lblEstadoAvance.Visible = False
         End If
         HabilitaControles(0)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "BackgroundWorker"
   Public Sub InicializaBackgroundWorker()
      lblEstadoAvance.Visible = True
      bkwObtenerRutas.RunWorkerAsync()
   End Sub
   Private Sub bkwObtenerRutas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bkwObtenerRutas.DoWork
      Try
         Dim rEjecucionBackup As New Reglas.ServiciosRest.Pedidos.PedidosSiMovilPedidos()
         Dim rutas As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas) = rEjecucionBackup.GetRutasPedidosPendientes()
         e.Result = rutas
      Catch ex As Exception
         bkwObtenerRutas.ReportProgress(0, ex)
         bkwObtenerRutas.CancelAsync()
      End Try
   End Sub

   Private Sub bkwObtenerRutas_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bkwObtenerRutas.ProgressChanged
      If TypeOf (e.UserState) Is Exception Then
         ShowError(DirectCast(e.UserState, Exception))
         'ElseIf TypeOf (e.UserState) Is String Then
         '   tssInfo.Text = e.UserState.ToString()
      End If
   End Sub

   Private Sub bkwObtenerRutas_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bkwObtenerRutas.RunWorkerCompleted
      MostrarRutasContinue(DirectCast(e.Result, List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)))
   End Sub
#End Region

   Private Sub chbRutas_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles chbRutas.ItemCheck
      Try
         HabilitaControles(If(e.CurrentValue = CheckState.Checked And e.NewValue = CheckState.Unchecked, -1, 1))
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         RutasSeleccionadas.Clear()
         For Each item In chbRutas.CheckedItems
            If TypeOf (item) Is Entidades.JSonEntidades.CobranzasMovil.Rutas Then
               RutasSeleccionadas.Add(DirectCast(item, Entidades.JSonEntidades.CobranzasMovil.Rutas))
            End If
         Next

         If cmbTiposComprobantesFact.Enabled Then
            Dim comprobantes = cmbTiposComprobantesFact.GetTiposComprobantes().ToList()
            If comprobantes.Count <> 0 Then
               tiposComprobantes = comprobantes
            End If
         End If


         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         RutasSeleccionadas.Clear()
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
   End Sub
End Class