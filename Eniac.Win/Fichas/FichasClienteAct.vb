Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win
Imports Eniac.Reglas
Imports Eniac.Entidades

Public Class FichasClienteAct

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Eniac.Win.Publicos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Function Valida() As Boolean
      Return True
   End Function
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString.Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString.Trim()
      Dim oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Me.CargarOperaciones()
      Me.cmbOperacion.Focus()
   End Sub
   Private Sub CargarOperaciones()
      Dim oReglas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Me.cmbOperacion.DataSource = oReglas.GetTodas(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), actual.Sucursal.Id)
      Me.cmbOperacion.DisplayMember = "NroOperacion"
      Me.cmbOperacion.ValueMember = "NroOperacion"
   End Sub
   Private Sub CargarDatosClienteRec(ByVal dr As DataGridViewRow)
      Me.bscClienteRec.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoClienteRec.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoClienteRec.Tag = dr.Cells("IdCliente").Value.ToString.Trim()
      Dim oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Me.CargarOperacionesRec()
   End Sub
   Private Sub CargarOperacionesRec()
      Dim oReglas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Me.dgvOperaciones.DataSource = oReglas.GetTodas(Long.Parse(Me.bscCodigoClienteRec.Tag.ToString()), actual.Sucursal.Id)
      Me.SetearGrillaOperaciones()
   End Sub
   Private Sub Actualizar()
      Dim oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
      Dim oFichaOrigen As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      Dim oFichaDestino As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      With oFichaOrigen
         .NroOperacion = Int32.Parse(Me.cmbOperacion.Text)
         .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End With
      With oFichaDestino
         .IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End With
      oFichas.ActualizarFichaACliente(oFichaOrigen, oFichaDestino)
      MessageBox.Show("Los datos se actualizaron con exito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.LimpiarCampos()
   End Sub
   Private Sub LimpiarCampos()
      Me.bscCodigoCliente.Text = ""
      Me.bscCodigoClienteRec.Text = ""
      Me.bscCliente.Text = ""
      Me.bscClienteRec.Text = ""
      Me.cmbOperacion.DataSource = Nothing
      Me.cmbOperacion.SelectedIndex = -1
      Me.dgvOperaciones.DataSource = Nothing
      Me.bscCliente.Focus()
   End Sub
   Private Sub SetearGrillaOperaciones()
      With Me.dgvOperaciones
         .Columns("IdCliente").Visible = False
      End With
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Clientes = New Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Clientes = New Clientes
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscClienteRec_BuscadorClick() Handles bscClienteRec.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscClienteRec)
         Dim oClientes As Clientes = New Clientes
         Me.bscClienteRec.Datos = oClientes.GetFiltradoPorNombre(Me.bscClienteRec.Text.Trim(), False)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscClienteRec_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscClienteRec.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteRec(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoClienteRec_BuscadorClick() Handles bscCodigoClienteRec.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoClienteRec_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoClienteRec.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteRec(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsbActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActualizar.Click
      Try
         If Me.Valida() Then
            Dim men As String = "Usted va a transferir la operación nº " & Me.cmbOperacion.Text & _
                              " desde el cliente " & Convert.ToChar(Keys.Enter) & _
                              Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text & " al cliente " & Convert.ToChar(Keys.Enter) & _
                              Me.bscCodigoClienteRec.Text & " - " & Me.bscClienteRec.Text & Convert.ToChar(Keys.Enter) & _
                              "Esta seguro de realizar esta operación?"
            If MessageBox.Show(men, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.Cursor = Cursors.WaitCursor
               Me.Actualizar()
            Else
               MessageBox.Show("Usted ha cancelado la actualización!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region

End Class
