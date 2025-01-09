Imports actual = Eniac.Entidades.Usuario.Actual

Public Class FichasPendientes

#Region "Constructores"

   Public Sub New(ByVal idCliente As Long, ByVal todas As Boolean)
      MyBase.New()
      InitializeComponent()
      Dim oReglas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Me.dgvOperacionesPendientes.DataSource = oReglas.GetPendientesDePago(idCliente, actual.Sucursal.Id, todas)
   End Sub

#End Region

#Region "Campos"

   Private _selecciono As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.SetearGrilla()
      Me.SetearColorAGrilla()
   End Sub

#End Region

#Region "Metodos"

   Private Sub SetearColorAGrilla()
      With Me.dgvOperacionesPendientes
         For Each dr As DataGridViewRow In .Rows
            If dr.Cells("IdEstado").Value.ToString() = "INACTIVO" Then
               dr.DefaultCellStyle.BackColor = Color.Salmon
            End If
         Next
      End With
   End Sub
   Private Sub SetearGrilla()
      With Me.dgvOperacionesPendientes
         .Columns("IdEstado").Visible = False

         .Columns("NroOperacion").HeaderText = "Nro."
         .Columns("FechaOperacion").HeaderText = "Fecha"
         .Columns("Saldo").HeaderText = "Saldo"
         .Columns("Producto").HeaderText = "Producto"

         .Columns("NroOperacion").Width = 40
         .Columns("FechaOperacion").Width = 80
         .Columns("Saldo").Width = 70
         .Columns("Producto").Width = 180

         .Columns("FechaOperacion").DefaultCellStyle.Format = "dd/MM/yyyy"

         .Columns("NroOperacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      End With
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
      If Me.dgvOperacionesPendientes.SelectedRows.Count > 0 Then
         Me._selecciono = True
      End If
      Me.Close()
   End Sub
   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub
   Private Sub dgvOperacionesPendientes_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOperacionesPendientes.CellMouseClick
      If Me.dgvOperacionesPendientes.SelectedRows.Count > 0 Then
         Me.btnOk_Click(sender, New System.EventArgs())
      End If
   End Sub
   Private Sub dgvOperacionesPendientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvOperacionesPendientes.KeyDown
      If e.KeyCode = Windows.Forms.Keys.Enter Then
         e.Handled = True
         Me.btnOk_Click(sender, New EventArgs)
      End If
   End Sub

#End Region

#Region "Propiedades"

   Public ReadOnly Property HayRegistro() As Boolean
      Get
         Return (Me.dgvOperacionesPendientes.Rows.Count > 0)
      End Get
   End Property
   Public ReadOnly Property FilaSeleccionada() As DataGridViewRow
      Get
         Return Me.dgvOperacionesPendientes.SelectedRows(0)
      End Get
   End Property
   Public Property Selecciono() As Boolean
      Get
         Return _selecciono
      End Get
      Set(ByVal value As Boolean)
         Me._selecciono = value
      End Set
   End Property
   Public ReadOnly Property NroOperacion() As String
      Get
         If Me.Selecciono Then
            Return Me.FilaSeleccionada.Cells("NroOperacion").Value.ToString()
         Else
            Return Nothing
         End If
      End Get
   End Property
   Public ReadOnly Property FechaOperacion() As DateTime
      Get
         If Me.Selecciono Then
            Return Date.Parse(Me.FilaSeleccionada.Cells("FechaOperacion").Value.ToString())
         End If
      End Get
   End Property

#End Region

End Class