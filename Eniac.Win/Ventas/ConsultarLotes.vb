Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ConsultarLotes

#Region "Campos"

   Private _publicos As Publicos

   Private _idSucursal As Integer
   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Integer
   Private _numeroComprobante As Long
   Private _orden As Integer

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.Cursor = Cursors.Default

      Catch ex As Exception

         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub

#End Region

#Region "Constructores"

   Public Sub New(idTipoComprobante As String,
                  letra As String,
                  centroEmisor As Integer,
                  numeroComprobante As Long,
                  orden As Integer)
      Me.New(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden)
   End Sub
   Public Sub New(idSucursal As Integer,
                  idTipoComprobante As String,
                  letra As String,
                  centroEmisor As Integer,
                  numeroComprobante As Long,
                  orden As Integer)
      Me.InitializeComponent()
      _idSucursal = idSucursal
      _idTipoComprobante = idTipoComprobante
      _letra = letra
      _centroEmisor = centroEmisor
      _numeroComprobante = numeroComprobante
      _orden = orden
   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarLotes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
      If e.KeyCode = Keys.Escape Then
         Me.Close()
      End If
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaGrillaDetalle()

      Dim mvpl As Reglas.VentasProductosLotes = New Reglas.VentasProductosLotes()

      Dim TotalCantidad As Decimal = 0

      Try

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = mvpl.Get1(_idSucursal,
                               Me._idTipoComprobante,
                               Me._letra,
                               Me._centroEmisor,
                               Me._numeroComprobante,
                               Me._orden)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()
            drCl("IdLote") = dr("IdLote").ToString()
            drCl("FechaVencimiento") = dr("FechaVencimiento")
            drCl("Cantidad") = Decimal.Parse(dr("Cantidad").ToString())

            dt.Rows.Add(drCl)

            TotalCantidad += Decimal.Parse(drCl("Cantidad").ToString())
         Next

         Me.txtTotalCantidad.Text = TotalCantidad.ToString("#,##0.00")

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("IdLote", System.Type.GetType("System.String"))
         .Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

#End Region

End Class