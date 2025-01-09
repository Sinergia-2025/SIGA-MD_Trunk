Imports Infragistics.Win.UltraWinGrid

Public Class MovilRutasClientes

#Region "Campos"

   Private _dtClientes As DataTable
   Private _dtRutasClientes As DataTable
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._cargandoPantalla = True
         _publicos = New Publicos()

         _publicos.CargaComboRutas(Me.cmbRutas, activa:=True, seleccionMultiple:=False, seleccionTodos:=False, cargarListaPrecios:=False)
         If cmbRutas.Items.Count > 0 Then
            cmbRutas.SelectedIndex = 0
         End If

         Me.CargarCantidadesPorDia()
         Me._cargandoPantalla = False


         RefrescarGrilla()

         'GAR: 04/02/2019. Que sentido tiene deshabilitar la grilla??

         spcDatos.Enabled = True

         LeerPreferencias()

         spcDatos.Enabled = False


         tsbPreferencias.Enabled = True
         tsbGrabar.Enabled = False

         'FormateaGrilla(Me.ugClientes, True)


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me._cargandoPantalla = False
      End Try

   End Sub

   Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      Try
         Me.ControlaCambios()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarClientes(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtClientes = New Reglas.MovilRutasClientes().GetClientesParaRutas(tablaVacia)
         bdsClientes.DataSource = _dtClientes
         bdsClientes.Filter = String.Format("CantidadVisitas > CantidadVisitasAsignadas AND DiaActual = False")
         Me.FormateaGrillaClientes()
      End If
   End Sub

   Private Sub CargarCantidadesPorDia()
      If Me.cmbRutas.SelectedIndex > -1 And _dtRutasClientes IsNot Nothing Then
         lblDomingo.Text = _dtRutasClientes.Select(GetFiltroDiaParaRuta(Convert.ToInt32(DayOfWeek.Sunday))).Length.ToString() ' DOMINGO = DIA 0
         lblLunes.Text = _dtRutasClientes.Select(GetFiltroDiaParaRuta(Convert.ToInt32(DayOfWeek.Monday))).Length.ToString()
         lblMartes.Text = _dtRutasClientes.Select(GetFiltroDiaParaRuta(Convert.ToInt32(DayOfWeek.Tuesday))).Length.ToString()
         lblMiercoles.Text = _dtRutasClientes.Select(GetFiltroDiaParaRuta(Convert.ToInt32(DayOfWeek.Wednesday))).Length.ToString()
         lblJueves.Text = _dtRutasClientes.Select(GetFiltroDiaParaRuta(Convert.ToInt32(DayOfWeek.Thursday))).Length.ToString()
         lblViernes.Text = _dtRutasClientes.Select(GetFiltroDiaParaRuta(Convert.ToInt32(DayOfWeek.Friday))).Length.ToString()
         lblSabado.Text = _dtRutasClientes.Select(GetFiltroDiaParaRuta(Convert.ToInt32(DayOfWeek.Saturday))).Length.ToString()
         lblOtro.Text = _dtRutasClientes.Select(GetFiltroDiaParaRuta(7)).Length.ToString() ' OTRO = DIA 7
      End If
   End Sub

   Private Sub CambiarFiltroRutas()
      bdsRutas.Filter = GetFiltroDiaParaRuta()

      LimpiaDiaActualDeClientes()

      AsignaDiaActualAClietnes()

      CargarCantidadesPorDia()

   End Sub

   Private Sub AsignaDiaActualAClietnes()
      If _dtRutasClientes IsNot Nothing Then
         For Each drRuta As DataRow In _dtRutasClientes.Select(GetFiltroDiaParaRuta())
            For Each drCliente As DataRow In _dtClientes.Select(String.Format("IdCliente = {0}", drRuta("IdCliente")))
               drCliente("DiaActual") = True
            Next
         Next
      End If
   End Sub

   Private Sub LimpiaDiaActualDeClientes()
      If _dtClientes IsNot Nothing Then
         For Each dr As DataRow In _dtClientes.Rows
            dr("DiaActual") = False
         Next
      End If
   End Sub

   Private Function GetFiltroDiaParaRuta() As String
      Return GetFiltroDiaParaRuta(GetDiaSeleccionado())
   End Function

   Private Function GetFiltroDiaParaRuta(dia As Integer) As String
      Return String.Format("IdRuta = {0} AND Dia = {1}", cmbRutas.SelectedValue, dia)
   End Function

   Private Function GetDiaSeleccionado() As Integer
      If rdbDomingo.Checked Then
         Return Convert.ToInt32(DayOfWeek.Sunday)
      ElseIf rdbLunes.Checked Then
         Return Convert.ToInt32(DayOfWeek.Monday)
      ElseIf rdbMartes.Checked Then
         Return Convert.ToInt32(DayOfWeek.Tuesday)
      ElseIf rdbMiercoles.Checked Then
         Return Convert.ToInt32(DayOfWeek.Wednesday)
      ElseIf rdbJueves.Checked Then
         Return Convert.ToInt32(DayOfWeek.Thursday)
      ElseIf rdbViernes.Checked Then
         Return Convert.ToInt32(DayOfWeek.Friday)
      ElseIf rdbSabado.Checked Then
         Return Convert.ToInt32(DayOfWeek.Saturday)
      Else
         Return 7
      End If
   End Function

   Private Sub CargarRutas(tablaVacia As Boolean)
      If Me.cmbRutas.SelectedIndex > -1 Then
         _dtRutasClientes = New Reglas.MovilRutasClientes().GetClientesAsignados(tablaVacia)

         bdsRutas.Filter = String.Empty
         bdsRutas.DataSource = _dtRutasClientes
         CambiarFiltroRutas()
         FormateaGrillaRutas()
      End If
   End Sub

   Private Sub ControlaCambios()
      If Me.tsbGrabar.Enabled Then
         If ShowPregunta("¿Desea grabar los cambios?") = Windows.Forms.DialogResult.Yes Then
            Me.Grabar()
         End If
      End If
   End Sub

   Private Sub AgregarClienteARuta()
      Me.Cursor = Cursors.WaitCursor

      If ugClientes.Selected.Rows.Count = 0 And ugClientes.ActiveRow IsNot Nothing Then
         ugClientes.ActiveRow.Selected = True
      End If

      Try
         Dim drClienteCol As List(Of DataRow) = New List(Of DataRow)()
         For Each dgCliente As UltraGridRow In ugClientes.Selected.Rows
            If dgCliente.ListObject IsNot Nothing AndAlso
               TypeOf (dgCliente.ListObject) Is DataRowView AndAlso
               DirectCast(dgCliente.ListObject, DataRowView).Row IsNot Nothing Then
               drClienteCol.Add(DirectCast(dgCliente.ListObject, DataRowView).Row)
            End If
         Next
         For Each drCliente As DataRow In drClienteCol
            Dim drRutaCliente As DataRow = _dtRutasClientes.NewRow()

            For Each dc As DataColumn In _dtClientes.Columns
               If drRutaCliente.Table.Columns.Contains(dc.ColumnName) Then
                  drRutaCliente(dc.ColumnName) = drCliente(dc.ColumnName)
               End If
            Next
            drRutaCliente("Dia") = GetDiaSeleccionado()
            drRutaCliente("IdRuta") = cmbRutas.SelectedValue
            drRutaCliente("Orden") = _dtRutasClientes.Select(GetFiltroDiaParaRuta()).Length + 1

            _dtRutasClientes.Rows.Add(drRutaCliente)
            drCliente("CantidadVisitasAsignadas") = Integer.Parse(drCliente("CantidadVisitasAsignadas").ToString()) + 1

            _dtRutasClientes.AcceptChanges()
            _dtClientes.AcceptChanges()

            CambiarFiltroRutas()
         Next

         tsbGrabar.Enabled = True

      Catch
         _dtRutasClientes.RejectChanges()
         _dtClientes.RejectChanges()
         Throw
      End Try
   End Sub

   Private Sub SacarClienteDeRuta()
      If ugRutas.Selected.Rows.Count = 0 And ugRutas.ActiveRow IsNot Nothing Then
         ugRutas.ActiveRow.Selected = True
      End If

      Try
         Dim drRutasCol As List(Of DataRow) = New List(Of DataRow)()
         For Each dgRow As UltraGridRow In ugRutas.Selected.Rows
            If dgRow.ListObject IsNot Nothing AndAlso
               TypeOf (dgRow.ListObject) Is DataRowView AndAlso
               DirectCast(dgRow.ListObject, DataRowView).Row IsNot Nothing Then
               drRutasCol.Add(DirectCast(dgRow.ListObject, DataRowView).Row)
            End If
         Next

         For Each drRutas As DataRow In drRutasCol
            For Each drCliente As DataRow In _dtClientes.Select(String.Format("IdCliente = {0}", drRutas("IdCliente")))
               drCliente("CantidadVisitasAsignadas") = Integer.Parse(drCliente("CantidadVisitasAsignadas").ToString()) - 1
            Next
            drRutas.Delete()
         Next

         _dtRutasClientes.AcceptChanges()
         _dtClientes.AcceptChanges()

         CambiarFiltroRutas()

         tsbGrabar.Enabled = True
      Catch
         _dtRutasClientes.RejectChanges()
         _dtClientes.RejectChanges()
         Throw
      End Try
   End Sub

   Private Sub Grabar()
      Dim ruta As Entidades.MovilRuta
      Dim dia As Integer

      ruta = DirectCast(Me.cmbRutas.SelectedItem, Entidades.MovilRuta)
      dia = GetDiaSeleccionado()


      Dim rRutasClientes As Reglas.MovilRutasClientes = New Reglas.MovilRutasClientes()

      rRutasClientes.Guardar(ruta, _dtRutasClientes)

      Me.Cursor = Cursors.Default
      MessageBox.Show("Ruta grabada exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      'GAR: 28/01/2023 - Reemplazo el Limpiar por Grabar para que el usuario vaya grabando mientras trabaja.
      'RefrescarGrilla()
      Me.tsbGrabar.Enabled = False
      Me.btnConsultar.PerformClick()

   End Sub

   Private Sub RefrescarGrilla()
      Me.CargarClientes(True)
      Me.CargarRutas(True)
      Me.tsbGrabar.Enabled = False
      Me.tsbImprimir.Enabled = False

      spcDatos.Enabled = False
      grbDias.Enabled = False

      cmbRutas.Focus()
   End Sub

   Private Sub FormateaGrillaClientes()
      FormateaGrilla(Me.ugClientes, True)
   End Sub

   Private Sub FormateaGrillaRutas()
      FormateaGrilla(Me.ugRutas, False)
   End Sub

   Private Sub FormateaGrilla(grilla As UltraGrid, muestraCantidadVisitas As Boolean)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"Direccion", "NombreCliente", "NombreLocalidad", "NombreProvincia"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next
         If .Columns.Exists("Orden") Then
            Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Orden"), "Orden", col, 70, HAlign.Right, ,,, Activation.AllowEdit)
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("idCliente"), "id", col, 100, HAlign.Right, True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("CodigoCliente"), "Código", col, 45, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreCliente"), "Cliente", col, 150)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreDeFantasia"), "Nombre Fantasia", col, 100, HAlign.Left, True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Direccion"), "Dirección", col, 100)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdLocalidad"), "C.P.", col, 35, HAlign.Right, True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreLocalidad"), "Localidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreProvincia"), "Provincia", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("TipoDocCliente"), "TipoDocCliente", col, 100, HAlign.Right, True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NroDocCliente"), "TipoDocCliente", col, 100, HAlign.Right, True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("LimiteDeCredito"), "Limite de Credito", col, 100, HAlign.Right, True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreZonaGeografica"), "Zona", col, 60)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("CantidadVisitas"), "Cant. Visitas", col, 50, HAlign.Right, Not muestraCantidadVisitas)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("CantidadVisitasAsignadas"), "Cant. Asig.", col, 50, HAlign.Right, Not muestraCantidadVisitas)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Vendedor"), "Vendedor", col, 90)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Cobrador"), "Cobrador", col, 90)
      End With
   End Sub
#End Region

#Region "Eventos"

   Private Sub MovilRutasClientes_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F4 Then
         'GAR: Cual de los 2?
         Me.tsbGrabar.PerformClick()
         'Me.tsbGrabar_Click(Me.tsbGrabar, New EventArgs())
      End If
   End Sub

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub rdbDias_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbViernes.CheckedChanged, rdbSabado.CheckedChanged, rdbMiercoles.CheckedChanged, rdbMartes.CheckedChanged, rdbLunes.CheckedChanged, rdbJueves.CheckedChanged, rdbOtro.CheckedChanged, rdbDomingo.CheckedChanged
      Try
         CambiarFiltroRutas()
         If ugClientes.Rows.Count > 0 Then
            ugClientes.ActiveRow = ugClientes.Rows(0)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvClientes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugClientes.MouseDoubleClick
      Me.btnAgregar_Click(sender, e)
   End Sub

   Private Sub dgvRutas_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugRutas.MouseDoubleClick
      Me.btnSacar_Click(sender, e)
   End Sub


   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         AgregarClienteARuta()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvRutas_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ugRutas.DragEnter
      e.Effect = DragDropEffects.Copy
   End Sub

   Private Sub btnSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubir.Click
      Try
         If Me.ugRutas.ActiveRow IsNot Nothing AndAlso
            ugRutas.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugRutas.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugRutas.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then

            Dim drActual As DataRow = DirectCast(ugRutas.ActiveRow.ListObject, DataRowView).Row
            Dim ordenActual As Integer = Integer.Parse(drActual("Orden").ToString())
            Dim drArriba As DataRow = Nothing
            Dim maxOrden As Integer = Integer.MinValue
            For Each drRutas As DataRow In _dtRutasClientes.Select(GetFiltroDiaParaRuta() + " AND Orden < " + ordenActual.ToString())
               If maxOrden < Integer.Parse(drRutas("Orden").ToString()) Then
                  maxOrden = Integer.Parse(drRutas("Orden").ToString())
                  drArriba = drRutas
               End If
            Next
            If drArriba IsNot Nothing Then
               drActual("Orden") = drArriba("Orden")
               drArriba("Orden") = ordenActual
               _dtRutasClientes.AcceptChanges()

               ugRutas.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
            End If
            tsbGrabar.Enabled = True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBajar.Click
      Try
         If Me.ugRutas.ActiveRow IsNot Nothing AndAlso
            ugRutas.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugRutas.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugRutas.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then

            Dim drActual As DataRow = DirectCast(ugRutas.ActiveRow.ListObject, DataRowView).Row
            Dim ordenActual As Integer = Integer.Parse(drActual("Orden").ToString())
            Dim drArriba As DataRow = Nothing
            Dim minOrden As Integer = Integer.MaxValue
            For Each drRutas As DataRow In _dtRutasClientes.Select(GetFiltroDiaParaRuta() + " AND Orden > " + ordenActual.ToString())
               If minOrden > Integer.Parse(drRutas("Orden").ToString()) Then
                  minOrden = Integer.Parse(drRutas("Orden").ToString())
                  drArriba = drRutas
               End If
            Next
            If drArriba IsNot Nothing Then
               drActual("Orden") = drArriba("Orden")
               drArriba("Orden") = ordenActual
               _dtRutasClientes.AcceptChanges()
               ugRutas.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
            End If
            tsbGrabar.Enabled = True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacar.Click
      Try
         Me.SacarClienteDeRuta()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.Grabar()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         '' '' '' ''Dim sFecha As String
         '' '' '' ''Dim sVendedor As String
         '' '' '' ''Dim ru As Reglas.RutasClientes = New Reglas.RutasClientes()
         '' '' '' ''Dim idRuta As Integer = DirectCast(Me.cmbRutas.SelectedItem, Entidades.Ruta).IdRuta
         '' '' '' ''Dim dt As DataTable

         '' '' '' ''Me.Cursor = Cursors.WaitCursor

         '' '' '' ''sFecha = "Fecha : " & DateTime.Now().ToString("dd/MM/yyyy hh:mm tt")
         '' '' '' ''sVendedor = DirectCast(Me.cmbRutas.SelectedItem, Entidades.Ruta).Vendedor.NombreEmpleado
         '' '' '' ''Me._ruta = ru.GetPorVendedor(idRuta)
         '' '' '' ''dt = DirectCast(Me._ruta, DataTable)

         '' '' '' ''Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Vendedor", sVendedor))

         ' '' '' '' ''GAR: 02/10/2017 - Esta Parametro se quito del reporte porque esta la fecha de impresion. Tal vez alguna vez tenia la fecha de actualizado.
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", sFecha))

         '' '' '' ''Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiLIVE.Win.ListadoRutaClientes.rdlc", "DataSet_log", dt, parm, True)
         '' '' '' ''frmImprime.Text = Me.Text
         '' '' '' ''frmImprime.WindowState = FormWindowState.Maximized
         '' '' '' ''frmImprime.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

   Private Sub dgvClientes_AfterRowActivate(sender As Object, e As EventArgs) Handles ugClientes.AfterRowActivate
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.ugClientes.ActiveRow IsNot Nothing Then
            If Me.ugClientes.ActiveRow.Cells("idCliente").Value.ToString() = String.Empty Then Exit Sub
            Me.txtInfoClientes.Text = Me.ugClientes.ActiveRow.Cells("NombreCliente").Value.ToString() + " - Credito = " + Decimal.Parse(Me.ugClientes.ActiveRow.Cells("LimiteDeCredito").Value.ToString()).ToString("#,##0.00")
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvRutas_AfterRowActivate(sender As Object, e As EventArgs) Handles ugRutas.AfterRowActivate
      Try
         If Me.ugRutas.ActiveRow IsNot Nothing Then
            If Me.ugRutas.ActiveRow.Cells("IdCliente").Value.ToString() = String.Empty Then Exit Sub
            Me.txtInfoClienteAVisitar.Text = Me.ugRutas.ActiveRow.Cells("NombreCliente").Value.ToString() + " - Credito = " + Decimal.Parse(Me.ugRutas.ActiveRow.Cells("LimiteDeCredito").Value.ToString()).ToString("#,##0.00")
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub ugRutas_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles ugRutas.BeforeRowUpdate
      Me.tsbGrabar.Enabled = True
   End Sub

   Private Sub chbAlineacionPaneles_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlineacionPaneles.CheckedChanged
      If Me.chbAlineacionPaneles.Checked Then
         Me.spcDatos.Orientation = Orientation.Horizontal
      Else
         Me.spcDatos.Orientation = Orientation.Vertical
      End If
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         If Me.cmbRutas.SelectedIndex < 0 Then
            ShowMessage("ATENCION: Debe seleccionar una Ruta.")
            Me.cmbRutas.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         CargarClientes(False)
         CargarRutas(False)

         CargarCantidadesPorDia()

         spcDatos.Enabled = True
         grbDias.Enabled = True

         If _dtClientes.Rows.Count > 0 Then
            ugClientes.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugClientes, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugClientes.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugClientes.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class