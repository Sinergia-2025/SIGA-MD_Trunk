Imports Infragistics.Win.UltraWinGrid

Public Class ProductosListasControl

#Region "Campos"

   Private _dtListasControl As DataTable
   Private _dtProductosListasControl As Entidades.ListConBorrados(Of Entidades.ListaControlProducto)
   'Private _dtProductosListasControl As DataTable
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean
   Private _IdModelo As Integer

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._cargandoPantalla = True
         _publicos = New Publicos()

         Me._cargandoPantalla = False

         '  Me.CargarListasControl(True)
         '  RefrescarGrilla()

         spcDatos.Enabled = True
         Me.btnApicarModelo.Visible = Reglas.Publicos.CalidadUtilizaModeloAsignacionListas

         LeerPreferencias()

         spcDatos.Enabled = False

         tsbPreferencias.Enabled = True
         tsbGrabar.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me._cargandoPantalla = False
      End Try

   End Sub

   Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      Try
         '  Me.ControlaCambios()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarListasControl(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtListasControl = New Reglas.ListasControl()._GetTodos()
         bdsListasControl.DataSource = _dtListasControl
         Me.FormateaGrillaListasControl()
      End If
   End Sub

   Private Sub CargarProductosListasControl(tablaVacia As Boolean)
      If Me.bscProducto2.Selecciono Or bscCodigoProducto2.Selecciono Then

         Dim lista As List(Of Entidades.ListaControlProducto) = New Reglas.ListasControlProductos().GetTodas(Me.bscCodigoProducto2.Text.ToString().Trim())

         _dtProductosListasControl = New Entidades.ListConBorrados(Of Entidades.ListaControlProducto)(lista)


         '   _dtProductosListasControl = New Reglas.ListasControlProductos().GetListasControlxProducto(Me.bscCodigoProducto2.Text.ToString().Trim())

         bdsProductosListasControl.Filter = String.Empty
         bdsProductosListasControl.DataSource = _dtProductosListasControl
         FormateaGrillaListasControlProductos()
      End If
   End Sub


   Private Sub ControlaCambios()
      If Me.tsbGrabar.Enabled Then
         If ShowPregunta("¿Desea grabar los cambios?") = Windows.Forms.DialogResult.Yes Then
            Me.Grabar()
         End If
      End If
   End Sub

   Private Sub AgregarListaAProducto()
      Me.Cursor = Cursors.WaitCursor

      If ugListasControl.Selected.Rows.Count = 0 And ugListasControl.ActiveRow IsNot Nothing Then
         ugListasControl.ActiveRow.Selected = True
      End If

      Try
         Dim _Iniciado As Boolean = False
         For Each drLista As Entidades.ListaControlProducto In _dtProductosListasControl
            If drLista.FecIngreso <> Nothing Then
               _Iniciado = True
               Exit For
            End If
         Next

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         If Not _Iniciado Or (_Iniciado And oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdListControl_ElimAgregList")) Then

            Dim drListaCol As List(Of DataRow) = New List(Of DataRow)()
            For Each dgLista As UltraGridRow In ugListasControl.Selected.Rows
               If dgLista.ListObject IsNot Nothing AndAlso
                  TypeOf (dgLista.ListObject) Is DataRowView AndAlso
                  DirectCast(dgLista.ListObject, DataRowView).Row IsNot Nothing Then

                  For Each item As Entidades.ListaControlProducto In _dtProductosListasControl
                     If item.IdListaControl = Integer.Parse(dgLista.Cells("IdListaControl").Value.ToString()) Then
                        Throw New Exception("Ya existe la lista de control: " & dgLista.Cells("NombreListaControl").Value.ToString())
                     End If
                  Next

                  drListaCol.Add(DirectCast(dgLista.ListObject, DataRowView).Row)


               End If
            Next

            Dim Lista As Entidades.ListaControlProducto

            For Each drLista As DataRow In drListaCol

               Lista = New Entidades.ListaControlProducto()

               Lista.NombreListaControl = drLista.Field(Of String)("NombreListaControl")
               Lista.IdListaControl = drLista.Field(Of Integer)("IdListaControl")
               Lista.Orden = drLista.Field(Of Integer)("Orden")
               Lista.IdUsuario = actual.Nombre
               Lista.fecha = Date.Now()
               Lista.IdProducto = bscCodigoProducto2.Text
               Lista.Aplica = True
               Lista.IdEstadoCalidad = New Reglas.EstadosListasControl().GetEstadoPorDefecto()

               _dtProductosListasControl.Add(Lista)
               ugProductoListasControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
               ugProductoListasControl.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

               _dtListasControl.AcceptChanges()

            Next

            tsbGrabar.Enabled = True
         Else
            If Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdListControl_ElimAgregList") Then
               MessageBox.Show("No puede agregar la lista de Control porque el Producto tiene listas iniciadas. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               Exit Sub
            End If
         End If

      Catch
         ' _dtProductosListasControl.RejectChanges()
         _dtListasControl.RejectChanges()
         Throw
      End Try

   End Sub

   Private Sub SacarListaDeProducto()
      If ugProductoListasControl.Selected.Rows.Count = 0 And ugProductoListasControl.ActiveRow IsNot Nothing Then
         ugProductoListasControl.ActiveRow.Selected = True
      End If



      Try
         Dim drProductoListaControl As List(Of Entidades.ListaControlProducto) = New List(Of Entidades.ListaControlProducto)()
         For Each dgRow As UltraGridRow In ugProductoListasControl.Selected.Rows
            If dgRow.ListObject IsNot Nothing AndAlso
               TypeOf (dgRow.ListObject) Is Entidades.ListaControlProducto AndAlso
               DirectCast(dgRow.ListObject, Entidades.ListaControlProducto) IsNot Nothing Then

               Dim Lista As Entidades.ListaControlProducto = GetCurrentLista()

               drProductoListaControl.Add(Lista)

            End If
         Next
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

         Dim _Iniciado As Boolean = False
         For Each drLista As Entidades.ListaControlProducto In drProductoListaControl
            If drLista.FecIngreso <> Nothing Then
               _Iniciado = True
               Exit For
            End If
         Next

         If Not _Iniciado Or (_Iniciado And oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdListControl_ElimAgregList")) Then

            For Each drLista As Entidades.ListaControlProducto In drProductoListaControl

               _dtProductosListasControl.Remove(drLista)
               ugProductoListasControl.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

               _dtListasControl.AcceptChanges()

               tsbGrabar.Enabled = True

            Next
         Else
            If Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdListControl_ElimAgregList") Then
               MessageBox.Show("No puede eliminar la lista de Control porque el Producto tiene listas iniciadas. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               Exit Sub
            End If
         End If

      Catch
         '   _dtProductosListasControl.RejectChanges()
         _dtListasControl.RejectChanges()
         Throw
      End Try
   End Sub

   Private Sub Grabar()

      '   Me._dtProductosListasControl.AcceptChanges()

      Dim rListasControlProductos As Reglas.ListasControlProductos = New Reglas.ListasControlProductos()

      rListasControlProductos.Guardar(Me._dtProductosListasControl)

      Me.Cursor = Cursors.Default
      MessageBox.Show("Lista/s de Control grabada/s exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      RefrescarGrilla()
   End Sub

   Private Sub RefrescarGrilla()
      Me.bdsProductosListasControl.DataSource = Nothing
      Me.bdsListasControl.DataSource = Nothing
      Me.tsbGrabar.Enabled = False
      spcDatos.Enabled = False
      Me.bscCodigoProducto2.Enabled = True
      Me.bscProducto2.Enabled = True
      Me.bscCodigoProducto2.Text = ""
      Me.bscProducto2.Text = ""
      Me.txtModelo.Text = ""
      Me.btnApicarModelo.Enabled = False
   End Sub

   Private Sub FormateaGrillaListasControl()
      FormateaGrillaListasControl(Me.ugListasControl)
   End Sub

   Private Sub FormateaGrillaListasControlProductos()
      FormateaGrillaListasControlProducto(Me.ugProductoListasControl)
   End Sub

   Private Sub FormateaGrillaListasControl(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreListaControl"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         ' Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControl"), "Nombre", col, 250)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Orden"), "Orden", col, 70, HAlign.Right)

      End With
   End Sub

   Private Sub FormateaGrillaListasControlProducto(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreListaControl"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next
         .Columns("Aplica").Style = ColumnStyle.CheckBox

         '     Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Aplica"), "Aplica", col, 60, , , , , Activation.AllowEdit)
         '   Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControl"), "Nombre", col, 250)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Orden"), "Orden", col, 70, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdUsuario"), "Usuario", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Fecha"), "Fecha Alta", col, 80)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("FecIngreso"), "Fecha Ingreso", col, 80,,, "dd/MM/yyyy")



      End With
   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugListasControl.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugListasControl.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarDatosProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.txtModelo.Text = dr.Cells("NombreProductoModelo").Value.ToString()
      _IdModelo = New Reglas.ProductosModelos().GetUno(Integer.Parse(dr.Cells("IdProductoModelo").Value.ToString())).IdProductoModelo

      Me.tsbGrabar.Enabled = True

      Me.CargaGrillas()

   End Sub

   Private Function ValidaLinea() As Boolean
      If Me._dtProductosListasControl IsNot Nothing Then
         'For Each item As DataRow In _dtProductosListasControl.Rows
         '   If item("IdListaControl") = Integer.Parse(ugListasControl.ActiveRow.Cells("IdListaControl").Value.ToString()) Then
         '      Throw New Exception("Ya existe la lista de control.")
         '   End If
         'Next
      End If
      Return True
   End Function

   Private Function GetCurrentLista() As Entidades.ListaControlProducto
      If ugProductoListasControl.ActiveRow IsNot Nothing AndAlso
         ugProductoListasControl.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugProductoListasControl.ActiveRow.ListObject) Is Entidades.ListaControlProducto Then
         Return DirectCast(ugProductoListasControl.ActiveRow.ListObject, Entidades.ListaControlProducto)
      End If
      Return Nothing
   End Function

   Private Sub CargaGrillas()
      Try

         Me.Cursor = Cursors.WaitCursor

         Me.bscCodigoProducto2.Enabled = False
         Me.bscProducto2.Enabled = False

         CargarListasControl(False)
         CargarProductosListasControl(False)

         spcDatos.Enabled = True

         Me.tssProductosListaControl.Text = ugProductoListasControl.Rows.Count.ToString() & " Registros"
         Me.tssListasControlAsignar.Text = ugListasControl.Rows.Count.ToString() & " Registros"

         If bdsProductosListasControl.Count = 0 Then
            Me.btnApicarModelo.Enabled = True
         End If

         If _dtListasControl.Rows.Count > 0 Then
            ugListasControl.Focus()
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
#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub dgvClientes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugListasControl.MouseDoubleClick
      Me.btnAgregar_Click(sender, e)
   End Sub

   Private Sub dgvRutas_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugProductoListasControl.MouseDoubleClick
      Me.btnSacar_Click(sender, e)
   End Sub

   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         AgregarListaAProducto()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvRutas_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ugProductoListasControl.DragEnter
      e.Effect = DragDropEffects.Copy
   End Sub

   Private Sub btnSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacar.Click
      Try
         Me.SacarListaDeProducto()
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

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

   Private Sub chbAlineacionPaneles_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlineacionPaneles.CheckedChanged
      If Me.chbAlineacionPaneles.Checked Then
         Me.spcDatos.Orientation = Orientation.Horizontal
      Else
         Me.spcDatos.Orientation = Orientation.Vertical
      End If
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            ShowMessage("ATENCION: Debe seleccionar un Producto")
            Me.bscProducto2.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.bscCodigoProducto2.Enabled = False
         Me.bscProducto2.Enabled = False

         CargarListasControl(False)
         CargarProductosListasControl(False)

         spcDatos.Enabled = True

         Me.tssProductosListaControl.Text = ugProductoListasControl.Rows.Count.ToString() & " Registros"
         Me.tssListasControlAsignar.Text = ugListasControl.Rows.Count.ToString() & " Registros"

         If _dtListasControl.Rows.Count > 0 Then
            ugListasControl.Focus()
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
         Dim pre As Preferencias = New Preferencias(Me.ugListasControl, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugListasControl.AfterRowFilterChanged
      Me.tssProductosListaControl.Text = Me.ugListasControl.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub ugListasControlUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugProductoListasControl.AfterRowFilterChanged
      Me.tssListasControlAsignar.Text = Me.ugProductoListasControl.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ProductosListasControl_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
         Case Keys.F4
            Me.tsbGrabar.PerformClick()
         Case Else
      End Select
   End Sub

   Private Sub btnApicarModelo_Click(sender As Object, e As EventArgs) Handles btnApicarModelo.Click
      Try
         Dim ListasDeControlModelos As List(Of Entidades.ListaControlModelo) = New Reglas.ListasControlModelos().GetTodas(_IdModelo)

         Dim lista As List(Of Entidades.ListaControlProducto) = New List(Of Entidades.ListaControlProducto)
         Dim lis As Entidades.ListaControlProducto

         For Each listaControl As Entidades.ListaControlModelo In ListasDeControlModelos

            lis = New Entidades.ListaControlProducto()

            lis.NombreListaControl = listaControl.NombreListaControl
            lis.IdListaControl = listaControl.IdListaControl
            lis.Orden = listaControl.Orden
            lis.IdUsuario = actual.Nombre
            lis.fecha = Date.Now()
            lis.IdProducto = bscCodigoProducto2.Text
            lis.Aplica = True
            lis.IdEstadoCalidad = New Reglas.EstadosListasControl().GetEstadoPorDefecto()
           
            lista.Add(lis)

            'ugProductoListasControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            'ugProductoListasControl.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

            '_dtListasControl.AcceptChanges()

         Next

         _dtProductosListasControl = New Entidades.ListConBorrados(Of Entidades.ListaControlProducto)(lista)
         bdsProductosListasControl.Filter = String.Empty
         bdsProductosListasControl.DataSource = _dtProductosListasControl
         FormateaGrillaListasControlProductos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region


End Class