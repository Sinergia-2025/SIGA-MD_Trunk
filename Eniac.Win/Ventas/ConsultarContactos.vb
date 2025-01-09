Option Strict Off

Public Class ConsultarContactos

#Region "Campos"

   Private _publicos As Publicos

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

   Public Sub New(ByVal idTipoComprobante As String, _
                  ByVal letra As String, _
                  ByVal centroEmisor As Integer, _
                  ByVal numeroComprobante As Long, _
                  ByVal orden As Integer)

      Me.InitializeComponent()

      Me._idTipoComprobante = idTipoComprobante
      Me._letra = letra
      Me._centroEmisor = centroEmisor
      Me._numeroComprobante = numeroComprobante
      Me._orden = orden

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

      Dim VCC As Reglas.VentasClientesContactos = New Reglas.VentasClientesContactos()
      Dim PCC As Reglas.PedidosClientesContactos = New Reglas.PedidosClientesContactos()

      Dim TotalCantidad As Decimal = 0

      Try

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         If Me._orden = 0 Then
            dtDetalle = VCC.GetContactosCliente(actual.Sucursal.Id, Me._idTipoComprobante, _
                                          Me._letra, Me._centroEmisor, Me._numeroComprobante)
         Else
            dtDetalle = PCC.GetContactosCliente(actual.Sucursal.Id, Me._idTipoComprobante, _
                                         Me._letra, Me._centroEmisor, Me._numeroComprobante)
         End If


         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdContacto") = dr("IdContacto").ToString()
            drCl("NombreContacto") = dr("NombreContacto").ToString()
            drCl("NombreTipoContacto") = dr("NombreTipoContacto").ToString()
            drCl("Direccion") = dr("Direccion").ToString()
            drCl("IdLocalidad") = dr("IdLocalidad").ToString()
            drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
            drCl("Telefono") = dr("Telefono").ToString()
            drCl("Observacion") = dr("Observacion").ToString()

            dt.Rows.Add(drCl)

         Next

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
         .Columns.Add("IdContacto", System.Type.GetType("System.String"))
         .Columns.Add("NombreContacto", System.Type.GetType("System.String"))
         .Columns.Add("NombreTipoContacto", System.Type.GetType("System.String"))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("IdLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("Telefono", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))

      End With

      Return dtTemp

   End Function

#End Region

End Class