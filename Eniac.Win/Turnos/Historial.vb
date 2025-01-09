Public Class Historial

#Region "Campos"

   Private _Cliente As Entidades.Cliente

   Private _historial As List(Of Entidades.ClienteHistoria)

#End Region

#Region "Constructores"

   Public Sub New(ByVal IdCliente As Long)
      MyBase.New()
      Me.InitializeComponent()

      Me._Cliente = New Reglas.Clientes().GetUno(IdCliente)
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.CargarDatosSocio()
      Me.CargarDatos()

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosSocio()

      Me.txtNroDocumento.Text = Me._Cliente.CodigoCliente.ToString()
      Me.txtNombreSocio.Text = Me._Cliente.NombreCliente
      Me.picImagen.Image = Me._Cliente.Foto
      Dim dire As String = Me._Cliente.Direccion
      Me.txtDireccion.Text = dire + " - " + Me._Cliente.Localidad.NombreLocalidad
      Me.txtTelefono.Text = Me._Cliente.Telefono
      Me.txtCelular.Text = Me._Cliente.Celular

      Dim socant As Reglas.ClientesAntecedentes = New Reglas.ClientesAntecedentes()

      Me.ugdAntecedentes.DataSource = socant.GetAntecedentesDeCliente(Me._Cliente.IdCliente)

   End Sub

   Private Sub CargarDatos()

      Dim reg As Reglas.ClientesHistorias = New Reglas.ClientesHistorias()
      Me._historial = reg.GetHistorialDeUnCliente(Me._Cliente.IdCliente)

      Me.lsbFechas.DataSource = Me._historial
      Me.lsbFechas.DisplayMember = Entidades.ClienteHistoria.Columnas.FechaHoraItem.ToString()

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub tsbAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAgregar.Click
      Try
         Dim it As HistorialItem = New HistorialItem(Me._Cliente)
         If it.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Me.CargarDatos()
            Me.Cursor = Cursors.Default
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEliminar.Click
      Try
         If Me.lsbFechas.SelectedIndex <> -1 Then
            If MessageBox.Show("Realmente desea eliminar el item?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.Cursor = Cursors.WaitCursor
               Dim reg As Reglas.ClientesHistorias = New Reglas.ClientesHistorias()
               reg.Borrar(DirectCast(Me.lsbFechas.SelectedItem, Entidades.ClienteHistoria))
               Me.CargarDatos()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub lsbFechas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsbFechas.SelectedIndexChanged
      Try
         Me.rtbItem.Text = DirectCast(Me.lsbFechas.SelectedItem, Entidades.ClienteHistoria).Item
         Me.txtUsuario.Text = DirectCast(Me.lsbFechas.SelectedItem, Entidades.ClienteHistoria).Usuario
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class