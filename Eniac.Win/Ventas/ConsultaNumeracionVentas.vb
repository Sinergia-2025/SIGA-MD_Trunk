Public Class ConsultaNumeracionVentas
   Implements IConParametros

   Private _tipoTipoComprobante As String

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "VENTAS"
            CargaGrillaDetalle()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() CargaGrillaDetalle())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Métodos"
   Private Sub CargaGrillaDetalle()
      Dim rVentas = New Reglas.Ventas()
      dtgVentas.DataSource = rVentas.GetUltimosNumerosComprobantes(actual.Sucursal.Id, _tipoTipoComprobante, anularComprobantesSinEmitir:=False)
   End Sub
   Private Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: VENTAS")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function
#End Region

End Class