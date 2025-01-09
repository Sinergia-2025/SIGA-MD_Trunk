Public Class SueldosConceptosMasivoEliminar

   Private _publicos As Publicos
   Private _idTipoConcepto As Integer = 0
   Private _idConcepto As Integer = 0


   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

   End Sub

   Private Sub ugvPersonal_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugvPersonal.CellChange
      Try
         If e.Cell.Row.Index >= 0 AndAlso e.Cell.Column.Key = "Check" Then
            Me.ugvPersonal.UpdateData()
         End If
         Dim entro As Boolean = False
         For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugvPersonal.Rows
            If dr.Cells("Check").Value.ToString() = "True" Then
               entro = True
               Exit For
            End If
         Next
         Me.tsbEliminar.Enabled = entro
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbPersonalSeleccionarTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPersonalSeleccionarTodos.CheckedChanged
      Try
         For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugvPersonal.Rows
            dr.Cells("Check").Value = Me.chbPersonalSeleccionarTodos.Checked
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoConcepto_BuscadorClick() Handles bscCodigoConcepto.BuscadorClick

      Dim NroDoc As Long = -1

      Try
         Me._publicos.PreparaGrillaSueldosConceptos(Me.bscCodigoConcepto)
         Dim oConceptos As Reglas.SueldosConceptos = New Reglas.SueldosConceptos
         If Me.bscCodigoConcepto.Text.Trim.Length > 0 Then
            NroDoc = Long.Parse(Me.bscCodigoConcepto.Text.Trim())
         End If

         Dim aguinaldo As Boolean = Me.RadioModoAguinaldo.Checked

         Me.bscCodigoConcepto.Datos = oConceptos.GetPorCodigo(NroDoc.ToString(), aguinaldo)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoConcepto_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCodigoConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreConcepto_BuscadorClick() Handles bscNombreConcepto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaSueldosConceptos(Me.bscNombreConcepto)
         Dim oClientes As Reglas.SueldosConceptos = New Reglas.SueldosConceptos

         Dim aguinaldo As Boolean = Me.RadioModoAguinaldo.Checked

         Me.bscNombreConcepto.Datos = oClientes.GetPorNombre(Me.bscNombreConcepto.Text.Trim(), Aguinaldo)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarDatosConcepto(ByVal dr As DataGridViewRow)

      Me.bscNombreConcepto.Text = dr.Cells("NombreConcepto").Value.ToString()
      Me.bscNombreConcepto.Enabled = False
      Me.bscCodigoConcepto.Text = dr.Cells("idConcepto").Value.ToString()
      Me.bscCodigoConcepto.Enabled = False

      Me.btnConsultar.Enabled = True
      Me.btnConsultar.Focus()

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Me.CargarGrillaPersonal()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarGrillaPersonal()

      If Me.bscCodigoConcepto.Selecciono Then
         Me._idTipoConcepto = Int32.Parse(Me.bscCodigoConcepto.FilaDevuelta.Cells(Entidades.SueldosPersonaConcepto.Columnas.idTipoConcepto.ToString()).Value.ToString())
         Me._idConcepto = Int32.Parse(Me.bscCodigoConcepto.FilaDevuelta.Cells(Entidades.SueldosPersonaConcepto.Columnas.idConcepto.ToString()).Value.ToString())
      Else
         If Me.bscNombreConcepto.Selecciono Then
            Me._idTipoConcepto = Int32.Parse(Me.bscNombreConcepto.FilaDevuelta.Cells(Entidades.SueldosPersonaConcepto.Columnas.idTipoConcepto.ToString()).Value.ToString())
            Me._idConcepto = Int32.Parse(Me.bscNombreConcepto.FilaDevuelta.Cells(Entidades.SueldosPersonaConcepto.Columnas.idConcepto.ToString()).Value.ToString())
         End If

      End If

      Dim lis As List(Of Entidades.SueldosPersonal) = New Reglas.SueldosPersonal().GetTodosActivosPorConcepto(Me._idTipoConcepto, Me._idConcepto)

      Dim dt As DataSetSueldos.PersonalDataTable = New DataSetSueldos.PersonalDataTable()
      Dim dr As DataSetSueldos.PersonalRow

      For Each p As Entidades.SueldosPersonal In lis
         dr = dt.NewPersonalRow()
         dr.IdLegajo = p.idLegajo
         dr.NombrePersonal = p.NombrePersonal
         dr.Domicilio = p.Domicilio
         dr.TipoDocPersonal = p.TipoDocPersonal
         dr.NroDocPersonal = p.NroDocPersonal
         dt.AddPersonalRow(dr)
      Next

      Me.ugvPersonal.DataSource = dt
      Me.chbPersonalSeleccionarTodos.Checked = False
      Me.tsbEliminar.Enabled = False

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEliminar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.EliminarConceptos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub EliminarConceptos()
      Dim oMovimientos As Reglas.SueldosPersonalCodigos = New Reglas.SueldosPersonalCodigos()

      Dim ListaDatos As New List(Of Entidades.SueldosPersonaConcepto)

      Dim ObjConcepto As Entidades.SueldosPersonaConcepto

      For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugvPersonal.Rows
         If dr.Cells("Check").Value.ToString() = "True" Then
            ObjConcepto = New Entidades.SueldosPersonaConcepto()

            With ObjConcepto
               .idLegajo = Int32.Parse(dr.Cells(DataSetSueldos.Personal.IdLegajoColumn.ColumnName).Value.ToString())
               .idConcepto = Me._idConcepto
               .idTipoConcepto = Me._idTipoConcepto
            End With

            ListaDatos.Add(ObjConcepto)
         End If
      Next

      oMovimientos.EliminarConceptosDelPersonal(ListaDatos)

      MessageBox.Show("Los conceptos fueron eliminados exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.CargarGrillaPersonal()

   End Sub

   Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
      Me.bscCodigoConcepto.Text = ""
      Me.bscCodigoConcepto.Enabled = True
      Me.bscNombreConcepto.Text = ""
      Me.bscNombreConcepto.Tag = ""
      Me.bscNombreConcepto.Enabled = True
      Me.btnConsultar.Enabled = False
      Me.bscCodigoConcepto.Focus()
   End Sub
End Class