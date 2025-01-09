
Public Class EmpresaActividades

#Region "Campos"

   Private _publicos As Publicos
   Private _actividades As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.cmbProvincia.DisplayMember = "NombreProvincia"
         Me.cmbProvincia.ValueMember = "IdProvincia"
         Me.cmbProvincia.DataSource = New Reglas.Provincias().GetAll()

         Me.cmbProvincia.Text = New Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa).NombreProvincia.ToString()

         Me.CargarActividades()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      Try
         If Me.bscActividades.FilaDevuelta IsNot Nothing Then
            If Me.bscActividades.Text <> "" Then
               If Me.ExisteActividad(Integer.Parse(Me.bscActividades.FilaDevuelta.Cells("IdActividad").Value.ToString()), Me.cmbProvincia.SelectedValue.ToString()) Then
                  MessageBox.Show("Ya existe la Actividad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Else
                  If Me.ExistePrincipal() Then
                     MessageBox.Show("Ya existe la Actividad Principal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Else
                     Me.AgregarActividad()
                  End If

               End If
               Me.Refrescar()
               Me.tsbGrabar.Enabled = True
               Me.cmbProvincia.Focus()
            Else
               MessageBox.Show("No selecciono la Actividad", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la Actividad seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.cmbProvincia.Focus()
               Me.EliminarLineaActividad()
               Me.tsbGrabar.Enabled = True
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscActividades_BuscadorClick() Handles bscActividades.BuscadorClick
      Try
         Me._publicos.PreparaGrillaActividades(Me.bscActividades)
         Dim oActividades As Reglas.Actividades = New Reglas.Actividades
         Me.bscActividades.Datos = oActividades.GetPorNombre(Me.bscActividades.Text.Trim(), Me.cmbProvincia.SelectedValue.ToString())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscActividades_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscActividades.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosActividad(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbGrabar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGrabar.Click
      Try

         Dim dt As DataTable = DirectCast(Me.dgvDetalle.DataSource, DataTable)
         Dim reg As Reglas.EmpresaActividades = New Reglas.EmpresaActividades()

         reg.GrabarEmpresaActividades(dt)

         MessageBox.Show("Se actualizaron los datos correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.Refrescar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"
   Private Sub AgregarActividad()

      Dim dr As DataRow = Me._actividades.NewRow()

      dr(0) = Me.bscActividades.FilaDevuelta.Cells("IdProvincia").Value.ToString()
      dr(1) = Me.bscActividades.FilaDevuelta.Cells("NombreProvincia").Value.ToString()
      dr(2) = Me.bscActividades.FilaDevuelta.Cells("IdActividad").Value.ToString()
      dr(3) = Me.bscActividades.FilaDevuelta.Cells("NombreActividad").Value.ToString()
      dr(4) = Me.bscActividades.FilaDevuelta.Cells("Porcentaje").Value.ToString()
      dr(5) = Me.chbPrincipal.Checked

      Me._actividades.Rows.Add(dr)

      Me.dgvDetalle.DataSource = Me._actividades



   End Sub

   Private Sub EliminarLineaActividad()

      Me._actividades.Rows(Me.dgvDetalle.SelectedRows(0).Index).Delete()
      Me.dgvDetalle.DataSource = Me._actividades

      If Me.dgvDetalle.Rows.Count > 0 Then
         Me.dgvDetalle.FirstDisplayedScrollingRowIndex = Me.dgvDetalle.Rows.Count - 1
         Me.dgvDetalle.Rows(Me.dgvDetalle.Rows.Count - 1).Selected = True
      End If

   End Sub

   Private Sub CargarDatosActividad(ByVal dr As DataGridViewRow)

      Me.bscActividades.Text = dr.Cells("NombreActividad").Value.ToString()
      Me.txtPorcentaje.Text = Decimal.Parse(dr.Cells("Porcentaje").Value.ToString()).ToString()
      Me.bscActividades.Enabled = False
      Me.txtPorcentaje.Enabled = False
      Me.cmbProvincia.Enabled = False

   End Sub

   Private Function ExisteActividad(ByVal idActividad As Integer, ByVal idProvincia As String) As Boolean

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If Integer.Parse(dr.Cells("IdActividad").Value.ToString()) = idActividad And dr.Cells("IdProvincia").Value.ToString() = idProvincia Then
            Return True
         End If

      Next

      Return False

   End Function

   Private Function ExistePrincipal() As Boolean

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If Boolean.Parse(dr.Cells("Principal").Value.ToString()) = True And Me.chbPrincipal.Checked = True Then
            If dr.Cells("IdProvincia").Value.ToString() = Me.cmbProvincia.SelectedValue.ToString() Then

               Return True
            End If
         End If
      Next

      Return False

   End Function
   Public Sub CargarActividades()


      Dim reg As Reglas.EmpresaActividades

      reg = New Reglas.EmpresaActividades()

      Me._actividades = reg.GetEmpresaActividades("")

      Me.dgvDetalle.DataSource = Me._actividades


   End Sub

   Public Sub Refrescar()
      Me.bscActividades.Text = ""
      Me.txtPorcentaje.Text = "0.00"
      Me.cmbProvincia.Text = New Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa).NombreProvincia.ToString()
      Me.bscActividades.Enabled = True
      Me.txtPorcentaje.Enabled = True
      Me.tsbGrabar.Enabled = False
      Me.chbPrincipal.Checked = False
      Me.cmbProvincia.Enabled = True
      Me.cmbProvincia.Focus()
   End Sub

#End Region



End Class