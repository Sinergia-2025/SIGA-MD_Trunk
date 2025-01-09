Public Class VincularDispositivos
   Private solicitarOficina As Reglas.SimovilOficina.VincularSimovilOficina
   Private sincronizacion As Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil

   Public Sub New()
      InitializeComponent()
      Try
         solicitarOficina = New Reglas.SimovilOficina.VincularSimovilOficina()
         sincronizacion = New Reglas.ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      tsbSincronicionAutomatica.Visible = Reglas.Publicos.ExtrasSinergia

      MostrarCodigos()

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         MostrarCodigos()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      MostrarCodigos()
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub btnCopiarSoporte_Click(sender As Object, e As EventArgs) Handles btnCopiarOficina.Click
      CopiarImagenPortapapeles(pnlVincularOficina.BackgroundImage)
   End Sub

   Private Sub btnCopiarCobranza_Click(sender As Object, e As EventArgs) Handles btnCopiarCobranza.Click
      CopiarImagenPortapapeles(pnlVincularCobranza.BackgroundImage)
   End Sub

   Private Sub btnCopiarPedido_Click(sender As Object, e As EventArgs) Handles btnCopiarPedido.Click
      CopiarImagenPortapapeles(pnlVincularPedido.BackgroundImage)
   End Sub
#End Region
#End Region

#Region "Metodos"
#Region "Metodos Mostrar Codigos"
   Private Sub MostrarCodigos()
      TryCatched(Sub() MostrarCodigosOficina())
      TryCatched(Sub() MostrarCodigosCobranza())
      TryCatched(Sub() MostrarCodigosPedidos())
   End Sub

   Private Sub MostrarCodigosOficina()
      If solicitarOficina IsNot Nothing Then
         MostrarCodigo(pnlVincularOficina, QRCodeHelper.GenerarQR(solicitarOficina.GetInfoParaVinculacion()))
      Else
         btnCopiarOficina.Enabled = False
      End If
   End Sub

   Private Sub MostrarCodigosPedidos()
      If sincronizacion IsNot Nothing Then
         MostrarCodigo(pnlVincularPedido, QRCodeHelper.GenerarQR(sincronizacion.GetInfoParaVinculacion()))
      Else
         btnCopiarPedido.Enabled = False
      End If
   End Sub

   Private Sub MostrarCodigosCobranza()
      If sincronizacion IsNot Nothing Then
         MostrarCodigo(pnlVincularCobranza, QRCodeHelper.GenerarQR(sincronizacion.GetInfoParaVinculacion()))
      Else
         btnCopiarCobranza.Enabled = False
      End If
   End Sub

   Private Sub MostrarCodigo(pnl As Panel, img As Image)
      Dim imgTemp As Image = Nothing
      If pnl.BackgroundImage IsNot Nothing Then
         imgTemp = pnl.BackgroundImage
      End If
      pnl.BackgroundImage = img
      If imgTemp IsNot Nothing Then
         imgTemp.Dispose()
      End If
   End Sub

#End Region

   Private Sub CopiarImagenPortapapeles(imagen As Image)
      TryCatched(Sub() Clipboard.SetImage(imagen))
   End Sub
#End Region

   Private Sub tsbSincronicionAutomatica_Click(sender As Object, e As EventArgs) Handles tsbSincronicionAutomatica.Click
      TryCatched(
      Sub()
         Dim regla = New Reglas.ServiciosRest.Soporte.SincronizarTickets()
         Dim sw = New Stopwatch()
         sw.Start()
         regla.ImportarAutomaticamente()
         sw.Stop()
         ShowMessage(String.Format("Sincronización finalizada exitosamente - Tiempo transcurrido {0}", sw.Elapsed.ToString()))
      End Sub)
   End Sub
End Class