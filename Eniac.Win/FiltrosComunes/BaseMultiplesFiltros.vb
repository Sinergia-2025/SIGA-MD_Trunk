<Obsolete("Usar BaseMultiplesFiltros2", True)>
Public Class BaseMultiplesFiltros

   Protected _publicos As Publicos
   Protected _columnasAMostrar As List(Of String)
   Protected _tipoFiltro As String = String.Empty
   Protected _nombreFiltro As String = String.Empty

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me._publicos = New Publicos()
   End Sub

   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      If ValidaSeleccion() Then
         DialogResult = DialogResult.Cancel
         Close()
      End If
   End Sub

   Private Sub lnkRecuperarUltimo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRecuperarUltimo.LinkClicked
      Try
         Me.RecuperarUltimo()
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Sub RecuperarUltimo()
      Dim fila As BaseFiltrosAdmin = New BaseFiltrosAdmin(Me._tipoFiltro, BaseFiltrosAdmin.Estados.Recuperar)
      fila.ShowDialog()
      Me._nombreFiltro = fila.txtNombreArchivo.Text
      If Not String.IsNullOrEmpty(Me._nombreFiltro) Then
         Me.CargarClase()
         Me.RefrescoDatosGrilla()
      End If
   End Sub

   Public Sub CargarClase(nombreFiltro As String)
      _nombreFiltro = nombreFiltro
      CargarClase()
   End Sub

   Protected Overridable Sub CargarClase()
      Throw New Exception("Sobreescribir CargarClase()")
   End Sub


   Protected Overridable Sub RefrescoDatosGrilla()
      For Each cl As UltraWinGrid.UltraGridColumn In Me.dgvDatos.DisplayLayout.Bands(0).Columns
         If Not Me._columnasAMostrar.Contains(cl.Key) Then
            cl.Hidden = True
         End If
      Next
   End Sub

   Private Sub lnkGrabarFiltro_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGrabarFiltro.LinkClicked
      Try
         Dim fila As BaseFiltrosAdmin = New BaseFiltrosAdmin(Me._tipoFiltro, BaseFiltrosAdmin.Estados.Grabar)
         fila.ShowDialog()
         Me._nombreFiltro = fila.txtNombreArchivo.Text
         If Not String.IsNullOrEmpty(Me._nombreFiltro) Then
            Dim reg As Reglas.FiltrosValores = New Reglas.FiltrosValores()
            reg.GrabarFiltros(Me._tipoFiltro, Me._nombreFiltro, Me.GetValoresColumnasFiltros())

            MessageBox.Show("Filtro guardado satisfactoriamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function GetValoresColumnasFiltros() As List(Of Entidades.FiltroValor)
      Dim fv As Entidades.FiltroValor
      Dim fvs As List(Of Entidades.FiltroValor) = New List(Of Entidades.FiltroValor)()
      Dim i As Integer = 0

      For Each fil As UltraWinGrid.UltraGridRow In Me.dgvDatos.Rows
         For Each ce As UltraWinGrid.UltraGridCell In fil.Cells
            fv = New Entidades.FiltroValor()
            fv.IdTipoFiltro = Me._tipoFiltro
            fv.IdNombreFiltro = Me._nombreFiltro
            fv.IdColumna = ce.Column.Key
            If ce.Value IsNot Nothing Then
               fv.Valor = ce.Value.ToString()
            Else
               fv.Valor = String.Empty
            End If
            fv.IdRegistro = i
            fvs.Add(fv)
         Next
         i += 1
      Next

      Return fvs

   End Function

   Private Sub lnkAgregarTodos_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAgregarTodos.LinkClicked
      Try
         Me.AgregarTodos()
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Sub AgregarTodos()
      Throw New Exception("Sobreescribir AgregarTodos()")
   End Sub

   Private Sub lnkLimpiarFiltros_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLimpiarFiltros.LinkClicked
      Try
         Me.LimpiarFiltros()
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Sub LimpiarFiltros()
      Throw New Exception("Sobreescribir AgregarTodos()")
   End Sub

   Protected Overridable Function ValidaSeleccion() As Boolean
      Return True
   End Function

End Class