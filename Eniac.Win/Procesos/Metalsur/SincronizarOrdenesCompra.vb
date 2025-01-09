Option Strict On
Option Explicit On
Public Class SincronizarOrdenesCompra
   Private _controles As Control()
   Private _toolstrip As ToolStripItem()

   Public Sub New()
      InitializeComponent()
      _controles = {btnSincronizar, btnImportarDesdeBejerman, btnEnivarWeb, btnDescargarRespuestas}
      _toolstrip = {tsbSalir}
   End Sub


#Region "Eventos"
   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
      TryCatched(_controles, _toolstrip, Sub() Sincronizar())
   End Sub
   Private Sub btnImportarDesdeBejerman_Click(sender As Object, e As EventArgs) Handles btnImportarDesdeBejerman.Click
      TryCatched(_controles, _toolstrip, Sub() ImportarDesdeBejerman())
   End Sub
   Private Sub btnEnivarWeb_Click(sender As Object, e As EventArgs) Handles btnEnivarWeb.Click
      TryCatched(_controles, _toolstrip, Sub() EnviarWeb())
   End Sub
   Private Sub btnDescargarRespuestas_Click(sender As Object, e As EventArgs) Handles btnDescargarRespuestas.Click
      TryCatched(_controles, _toolstrip, Sub() DescargarRespuestas())
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region

   Private Sub regla_Avance(sender As Object, e As Reglas.AvanceSincronizarOrdenesCompraEventArgs)
      tssInfo.Text = e.ToString()
      Application.DoEvents()
   End Sub

   Private Sub Sincronizar()
      Dim regla = New Reglas.SincronizarOrdenesCompra(IdFuncion)
      AddHandler regla.Avance, AddressOf regla_Avance
      Try
         regla.Sincronizar(chbReimportar.Checked, chbReenviar.Checked, chbEnviarWebProveedores.Checked, chbExportarProveedores.Checked, chbEnviarWebOrdenCompra.Checked, chbExportarOrdenCompra.Checked, chbDescargarTodo.Checked)
      Finally
         RemoveHandler regla.Avance, AddressOf regla_Avance
      End Try
   End Sub
   Private Sub ImportarDesdeBejerman()
      Dim regla = New Reglas.SincronizarOrdenesCompra(IdFuncion)
      AddHandler regla.Avance, AddressOf regla_Avance
      Try
         regla.ImportarDesdeBejerman(chbReimportar.Checked)
      Finally
         RemoveHandler regla.Avance, AddressOf regla_Avance
      End Try
   End Sub
   Private Sub EnviarWeb()
      Dim regla = New Reglas.SincronizarOrdenesCompra(IdFuncion)
      AddHandler regla.Avance, AddressOf regla_Avance
      Try
         regla.EnviarWeb(chbReenviar.Checked, chbEnviarWebProveedores.Checked, chbExportarProveedores.Checked, chbEnviarWebOrdenCompra.Checked, chbExportarOrdenCompra.Checked)
      Finally
         RemoveHandler regla.Avance, AddressOf regla_Avance
      End Try
   End Sub
   Private Sub DescargarRespuestas()
      Dim regla = New Reglas.SincronizarOrdenesCompra(IdFuncion)
      AddHandler regla.Avance, AddressOf regla_Avance
      Try
         regla.DescargarRespuestas(chbDescargarTodo.Checked)
      Finally
         RemoveHandler regla.Avance, AddressOf regla_Avance
      End Try
   End Sub

   Private Sub btnFE_Click(sender As Object, e As EventArgs) Handles btnFE.Click
      TryCatched(_controles, _toolstrip, Sub() ImportarDesdeBejermanFE())
   End Sub
   Private Sub ImportarDesdeBejermanFE()
      Dim regla = New Reglas.SincronizarOrdenesCompra(IdFuncion)
      AddHandler regla.Avance, AddressOf regla_Avance
      Try
         regla.ImportarDesdeBejermanFE(chbReimportar.Checked, Me.dtpFE.Value)
      Finally
         RemoveHandler regla.Avance, AddressOf regla_Avance
      End Try
   End Sub


   Private Sub btnOCN_Click(sender As Object, e As EventArgs) Handles btnOCN.Click
      TryCatched(_controles, _toolstrip, Sub() ImportarDesdeBejermanOCN())
   End Sub
   Private Sub ImportarDesdeBejermanOCN()
      Dim regla = New Reglas.SincronizarOrdenesCompra(IdFuncion)
      AddHandler regla.Avance, AddressOf regla_Avance
      Try
         regla.ImportarDesdeBejermanOCN(chbReimportar.Checked, Me.dtpFechaOCN.Value)
      Finally
         RemoveHandler regla.Avance, AddressOf regla_Avance
      End Try
   End Sub



End Class