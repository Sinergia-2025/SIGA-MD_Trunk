Imports Eniac.Entidades

Public Class PedidosAdminDepositos

#Region "Campos/Constantes"
   Public dt As New DataTable
   Private sucOrigen As Integer
   Private depOrigen As Integer

   Private _cargaComboDestino As Boolean

   Private _publicos As Publicos

#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(_dts As DataTable)
      Me.New()
      dt = _dts
   End Sub
#End Region

#Region "Overrides/Overloads"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
         '-- Arma Tabla de Pedidos.- 
         FormateGrillaCampos()
      Catch ex As Exception
      End Try
   End Sub
#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      dt.AcceptChanges()
      DialogResult = Windows.Forms.DialogResult.Yes
      Me.Close()
   End Sub
   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell

      Using oFormDepo = New PedidosAdminCambioUbicacion(ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row))
         oFormDepo.ShowDialog()
         dt = oFormDepo.dr.Table
      End Using
      ugDetalle.UpdateData()
   End Sub
#End Region

#Region "Metodos"
   Private Sub ArmaTablaPedidos()
      ugDetalle.DataSource = dt
      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
   End Sub
   Private Sub FormateGrillaCampos()
      Dim pos As Integer = 0
      ArmaTablaPedidos()

      With ugDetalle.DisplayLayout.Bands(0)
         _publicos.OcultaColumnas(ugDetalle)

         .Columns("IdProducto").FormatearColumna("Codigo", pos, 100, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Descripción", pos, 300, HAlign.Left)

         .Columns("CantEntregada").FormatearColumna("Cantidad", pos, 80, HAlign.Right,, "N2")

         .Columns("NombreDepositoDefecto").FormatearColumna("Deposito", pos, 120, HAlign.Left)
         .Columns("NombreUbicacionDefecto").FormatearColumna("Ubicación", pos, 120, HAlign.Left)

         .Columns("Stock").FormatearColumna("Stock", pos, 80, HAlign.Right,, "N2")
         .Columns("StockActual").FormatearColumna("Stock Actual", pos, 80, HAlign.Right,, "N2")


      End With
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      dt.RejectChanges()
      DialogResult = Windows.Forms.DialogResult.Cancel
   End Sub
#End Region

End Class