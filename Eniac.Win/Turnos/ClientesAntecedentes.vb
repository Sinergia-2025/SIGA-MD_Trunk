Option Strict On
Option Explicit On

Public Class ClientesAntecedentes

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()

      Dim ta As Reglas.TiposAntecedentes = New Reglas.TiposAntecedentes()
      Me.lsbTiposAntecedentes.DataSource = ta.GetTodos()
      Me.lsbTiposAntecedentes.DisplayMember = Entidades.TipoAntecedente.Columnas.NombreTipoAntecedente.ToString()

   End Sub

#End Region

#Region "Constructores"

   Public Sub New()
      MyBase.New()
      Me.InitializeComponent()

      Me._publicos = New Publicos()

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub lsbTiposAntecedentes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsbTiposAntecedentes.SelectedIndexChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.CargaAntecedentes()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
         Me.bscCodigoCliente.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvAntecedentes_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAntecedentes.CellEndEdit
      Try
         Me.AgregarValor(e.RowIndex)
      Catch ex As Exception
         Me.dgvAntecedentes.Rows(e.RowIndex).Cells("colValor").Value = String.Empty
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub SociosAntecedentes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Try
         If e.KeyCode = Keys.F5 Then
            Me.Refrescar()
            Me.bscCodigoCliente.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         If IsNumeric(Me.bscCodigoCliente.Text) Then codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         Me.bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Me.bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()
      Me.bscCliente.Text = String.Empty
      Me.bscCodigoCliente.Text = String.Empty

      Me.picImagen.Image = Nothing

      Me.lsbTiposAntecedentes.SelectedIndex = 0
      If Me.dgvAntecedentes.DataSource IsNot Nothing Then
         DirectCast(Me.dgvAntecedentes.DataSource, DataTable).Rows.Clear()
      End If

      Me.grbFiltros.Enabled = True

   End Sub

   Private Sub CargaAntecedentes()
      If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         Dim ant As Reglas.ClientesAntecedentes = New Reglas.ClientesAntecedentes()
         Me.dgvAntecedentes.DataSource = ant.GetPorTipoAntecedenteYCliente(DirectCast(Me.lsbTiposAntecedentes.SelectedItem, Entidades.TipoAntecedente).IdTipoAntecedente, Long.Parse(Me.bscCodigoCliente.Tag.ToString()))
      End If
   End Sub

   Private Sub AgregarValor(ByVal fila As Integer)
      If Not String.IsNullOrEmpty(Me.dgvAntecedentes.Rows(fila).Cells("colValor").Value.ToString()) Then
         Dim reg As Reglas.ClientesAntecedentes = New Reglas.ClientesAntecedentes()
         Dim an As Entidades.ClienteAntecedente = New Entidades.ClienteAntecedente()
         an.Cliente.IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         an.Cliente.NombreCliente = Me.bscCliente.Text
         an.Antecedente.IdAntecedente = Int32.Parse(Me.dgvAntecedentes.Rows(fila).Cells("colIdAntecedente").Value.ToString())
         an.Valor = Me.dgvAntecedentes.Rows(fila).Cells("colValor").Value.ToString()
         reg.Insertar(an)
      Else
         MessageBox.Show("No puede ingresar valores vacios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Protected Overridable Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString()).Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Value.ToString().Trim()
      Me.bscCodigoCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      Me.bscCliente.Tag = New Reglas.Clientes().GetUno(Long.Parse(dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()))


   End Sub

#End Region

  
   'Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
   '   Try
   '      Dim ant As Reglas.ClientesAntecedentes
   '      For Each item As DataRowView In lsbTiposAntecedentes.SelectedItems

   '         Dim row As DataRow = item.Row

   '         ' Obtenemos el valor del primer campo
   '         MessageBox.Show(CStr(row(0)))

   '         ant = New Reglas.ClientesAntecedentes()
   '         Me.dgvAntecedentes.DataSource = ant.GetPorTipoAntecedenteYCliente(DirectCast(Me.lsbTiposAntecedentes.SelectedItem, Entidades.TipoAntecedente).IdTipoAntecedente, Long.Parse(Me.bscCodigoCliente.Tag.ToString()))



   '      Next

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
   '   End Try
   'End Sub
End Class