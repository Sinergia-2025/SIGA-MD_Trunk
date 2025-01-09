Imports System.Drawing.Printing
Imports System.Text
Imports System.IO

Public Class PersonalizacionDeInformes

   Private _tit As Dictionary(Of String, String)

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _tit = GetColumnasVisiblesGrilla(ugPersonalizacionInformes)

         Dim pub As Publicos = New Publicos()
         pub.CargaComboDesdeEnum(Me.cmbInforme, GetType(Entidades.PersonalizacionDeInforme.Informes), , True)

         LimpiarCampos()
         Me.RefrescarGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub RefrescarGrilla()
      Dim reg As Reglas.PersonalizacionDeInformes = New Reglas.PersonalizacionDeInformes()
      Me.ugPersonalizacionInformes.DataSource = reg.GetTodos()
      AjustarColumnasGrilla(ugPersonalizacionInformes, _tit)
   End Sub

   Private Function GetEntidadControles() As Entidades.PersonalizacionDeInforme
      Dim pdi As Entidades.PersonalizacionDeInforme = New Entidades.PersonalizacionDeInforme()
      pdi.IdInforme = cmbInforme.SelectedValue.ToString()
      pdi.NombreArchivo = txtArchivoAImprimir.Text
      pdi.Embebido = chbArchivoEmbebido.Checked
      Return pdi
   End Function

   Private Function GetEntidadGrilla() As Entidades.PersonalizacionDeInforme
      Dim pdi As Entidades.PersonalizacionDeInforme = Nothing
      If ugPersonalizacionInformes.ActiveRow IsNot Nothing AndAlso
         ugPersonalizacionInformes.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugPersonalizacionInformes.ActiveRow.ListObject) Is Entidades.PersonalizacionDeInforme Then
         pdi = DirectCast(ugPersonalizacionInformes.ActiveRow.ListObject, Entidades.PersonalizacionDeInforme)
      End If
      Return pdi
   End Function

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click

      Try

         If Me.cmbInforme.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe selecionar el Informe.")
            Me.cmbInforme.Focus()
            Exit Sub
         End If

         If Me.txtArchivoAImprimir.Text.Trim.Length = 0 Then
            ShowMessage("ATENCION: Debe ingresar el Archivo a Imprimir.")
            Me.txtArchivoAImprimir.Focus()
            Exit Sub
         End If

         Dim pdi As Reglas.PersonalizacionDeInformes = New Reglas.PersonalizacionDeInformes()
         pdi.Insertar(Me.GetEntidadControles())

         Me.RefrescarGrilla()
         LimpiarCampos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.ugPersonalizacionInformes.ActiveRow IsNot Nothing Then
            If ShowPregunta("¿Realmente desea eliminar el registro seleccionado?") = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaConfiguracion()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub LimpiarCampos()
      Me.cmbInforme.SelectedIndex = -1
      Me.txtArchivoAImprimir.Text = ""
      Me.chbArchivoEmbebido.Checked = False
   End Sub

   Private Sub CargarConfiguracionCompleta(pdi As Entidades.PersonalizacionDeInforme)
      cmbInforme.SelectedValue = pdi.IdInforme
      txtArchivoAImprimir.Text = pdi.NombreArchivo
      chbArchivoEmbebido.Checked = pdi.Embebido
   End Sub

   Private Sub EliminarLineaConfiguracion()
      Dim pdi As Reglas.PersonalizacionDeInformes = New Reglas.PersonalizacionDeInformes()
      pdi.Borrar(Me.GetEntidadGrilla())
      Me.RefrescarGrilla()
   End Sub

   Private Sub ugPersonalizacionInformes_DoubleClickRow(sender As Object, e As UltraWinGrid.DoubleClickRowEventArgs) Handles ugPersonalizacionInformes.DoubleClickRow
      Try
         'limpia los textbox, y demas controles
         Me.LimpiarCampos()

         'carga la configuracion seleccionada de la grilla en los textbox 
         Me.CargarConfiguracionCompleta(GetEntidadGrilla())

         'elimina la configuracion de la grilla
         Me.EliminarLineaConfiguracion()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class