Imports actual = Eniac.Entidades.Usuario.Actual

Public Class FichasPendientes1

#Region "Constructores"

   Public Sub New(ByVal IdCliente As Long, ByVal todas As Boolean)
      MyBase.New()
      InitializeComponent()

      Dim oCliente As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
      Me._clienteGrilla = oCliente.GetUno(IdCliente)

      Dim oComprobantes As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes
      Dim idSucursal As Integer = actual.Sucursal.Id
      If New Reglas.Usuarios().TienePermisos("Fichas-BuscarTodasSucursales") Then
         idSucursal = 0
         dgvOperacionesPendientes.Columns(NombreSucursal.Name).Visible = True
      End If
      Me.dgvOperacionesPendientes.DataSource = oComprobantes.BuscarPendientesFichas(idSucursal, Me._clienteGrilla, todas)

   End Sub

#End Region

#Region "Campos"

   Private _selecciono As Boolean = False
   Private _clienteGrilla As Eniac.Entidades.Cliente
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
            If dr.Cells("IdEstadoComprobante").Value.ToString() = "INACTIVO" Then
               dr.DefaultCellStyle.BackColor = Color.Salmon
            End If
         Next
      End With
   End Sub
   Private Sub SetearGrilla()
      With Me.dgvOperacionesPendientes
         .Columns("IdEstadoComprobante").Visible = False

         .Columns("Numero").HeaderText = "Nro."
         .Columns("Numero").Width = 40
         .Columns("Numero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("Fecha").HeaderText = "Fecha"
         .Columns("Fecha").Width = 80
         .Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"

         .Columns("Saldo").HeaderText = "Saldo"
         .Columns("Saldo").Width = 70
         .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("Producto").HeaderText = "Producto"
         .Columns("Producto").Width = 180

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
   Public ReadOnly Property IdSucursalSeleccionado() As Integer
      Get
         If Me.Selecciono Then
            Return Integer.Parse(Me.FilaSeleccionada.Cells(IdSucursal.Name).Value.ToString())
         Else
            Return Nothing
         End If
      End Get
   End Property
   Public ReadOnly Property IdTipoComprobanteSeleccionado() As String
      Get
         If Me.Selecciono Then
            Return Me.FilaSeleccionada.Cells(IdTipoComprobante.Name).Value.ToString()
         Else
            Return Nothing
         End If
      End Get
   End Property
   Public ReadOnly Property LetraSeleccionado() As String
      Get
         If Me.Selecciono Then
            Return Me.FilaSeleccionada.Cells(Letra.Name).Value.ToString()
         Else
            Return Nothing
         End If
      End Get
   End Property
   Public ReadOnly Property CentroEmisorSeleccionado() As Short
      Get
         If Me.Selecciono Then
            Return Short.Parse(Me.FilaSeleccionada.Cells(Emisor.Name).Value.ToString())
         Else
            Return 0
         End If
      End Get
   End Property
   Public ReadOnly Property NumeroComprobanteSeleccionado() As Long
      Get
         If Me.Selecciono Then
            Return Long.Parse(Me.FilaSeleccionada.Cells(Numero.Name).Value.ToString())
         Else
            Return 0
         End If
      End Get
   End Property
   Public ReadOnly Property FechaOperacion() As DateTime
      Get
         If Me.Selecciono Then
            Return Date.Parse(Me.FilaSeleccionada.Cells("Fecha").Value.ToString())
         End If
      End Get
   End Property

#End Region

End Class