Option Strict Off
Public Class FacturablesInvocadosCom

#Region "Campos"

   Private _publicos As Publicos

   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Integer
   Private _numeroComprobante As Long
   Private _idProveedor As Long

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

   Public Sub New(ByVal idTipoComprobante As String, ByVal Letra As String, ByVal CentroEmisor As Integer, ByVal NumeroComprobante As Long, ByVal IdProveedor As Long)

      Me.InitializeComponent()

      Me._idTipoComprobante = idTipoComprobante
      Me._letra = Letra
      Me._centroEmisor = CentroEmisor
      Me._numeroComprobante = NumeroComprobante
      Me._idProveedor = IdProveedor

   End Sub

#End Region

#Region "Eventos"

   Private Sub FacturablesInvocados_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

      Dim oCompra As Reglas.Compras = New Reglas.Compras()

      Dim TotalNeto As Decimal = 0

      Try

         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oCompra.GetInvocadosCom(actual.Sucursal.Id, _
                                         Me._idTipoComprobante, _
                                         Me._letra, _
                                         Me._centroEmisor, _
                                         Me._numeroComprobante, _
                                         Me._idProveedor)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("TipoComprobante") = dr("Descripcion").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("ImporteNeto") = Decimal.Parse(dr("ImporteTotal").ToString())

            dt.Rows.Add(drCl)

            TotalNeto += Decimal.Parse(drCl("ImporteNeto").ToString())

         Next

         txtTotalNeto.Text = TotalNeto.ToString("#,##0.00")

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
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("ImporteNeto", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

#End Region

End Class