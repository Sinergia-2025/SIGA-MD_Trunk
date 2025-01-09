Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class CalculoProduccion

#Region "Campos"

   Private _publicos As Publicos
   Private _listaProductos As System.Collections.Generic.List(Of Entidades.ProduccionProducto)
   Private _numeroOrden As Integer
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit2 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titUG As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titUG2 As Dictionary(Of String, String) = New Dictionary(Of String, String)()


#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _titUG = GetColumnasVisiblesGrilla(Me.ugDetalle)
         tbcCalculoProduccion.SelectedTab = tbpComponentes
         _titUG2 = GetColumnasVisiblesGrilla(Me.ugDetalleComponentes)
         tbcCalculoProduccion.SelectedTab = tbpProductosParaProduccion

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto"})
         ugDetalleComponentes.AgregarFiltroEnLinea({"NOMBREPRODUCTO1"})

         Me._listaProductos = New List(Of Entidades.ProduccionProducto)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub CalculoProduccion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
         Me.tbcCalculoProduccion.SelectedTab = tbpProductosParaProduccion
      End If
      If e.KeyCode = Keys.F4 Then
         Me.tsbCalcular_Click(Me.tsbCalcular, New EventArgs())
         Me.tbcCalculoProduccion.SelectedTab = tbpComponentes
      End If
      If e.KeyCode = Keys.F3 Then
         Me.tbcCalculoProduccion.SelectedTab = tbpProductosParaProduccion
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.Nuevo()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCalcular.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then
            If Not Me.ugDetalleComponentes.DataSource Is Nothing Then
               DirectCast(Me.ugDetalleComponentes.DataSource, DataTable).Rows.Clear()
            End If
            Exit Sub
         End If

         Dim sucursal As Integer
         sucursal = actual.Sucursal.IdSucursal

         Dim productos As DataTable = New DataTable()
         productos.Columns.Add("IdProducto", GetType(String))
         productos.Columns.Add("Cantidad", GetType(Decimal))
         productos.Columns.Add("IdFormula", GetType(Int32))

         For Each Prod As Entidades.ProduccionProducto In Me._listaProductos

            Dim dr As DataRow = productos.NewRow()

            dr("IdProducto") = Prod.IdProducto
            dr("Cantidad") = Prod.Cantidad
            dr("IdFormula") = Prod.IdFormula

            productos.Rows.Add(dr)

         Next

         Me.ugDetalleComponentes.DataSource = New Reglas.ProductosComponentes().GetComponentesProduccion(productos, sucursal)

         Dim cantidadXcelda As Double = 0

         AjustarColumnasGrilla(Me.ugDetalleComponentes, _titUG2)
         FormatearColumnasGrilla(Me.ugDetalleComponentes)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub FormatearColumnasGrilla(grilla As UltraWinGrid.UltraGrid)
      For Each dr As UltraWinGrid.UltraGridRow In Me.ugDetalleComponentes.Rows
         If Double.Parse(dr.Cells("CantidadComp").Value.ToString()) > 0 Then
            dr.Cells("CantidadComp").Appearance.BackColor = Color.Red
            dr.Cells("CantidadComp").ActiveAppearance.BackColor = Color.Red
            dr.Cells("CantidadComp").ActiveAppearance.ForeColor = Color.White
         End If
      Next
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
      Me.LimpiarCamposProductos()
      Me.bscCodigoProducto2.Focus()
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
      Me.PresionarTab(e)
   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click

      Try

         If Me.bscCodigoProducto2.Text = "" Then
            MessageBox.Show("Debe elegir un Producto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Decimal.Parse(Me.txtCantidad.Text) = 0 Then
            MessageBox.Show("La cantidad no puede ser 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCantidad.Focus()
            Exit Sub
         End If

         Me.tsbCalcular.Enabled = True

         Me._numeroOrden += 1

         Dim oLineaProducto As Entidades.ProduccionProducto = New Entidades.ProduccionProducto()

         With oLineaProducto
            .IdSucursal = actual.Sucursal.IdSucursal
            .Usuario = actual.Nombre
            .IdProduccion = 1
            .Orden = Me._numeroOrden
            .IdProducto = Me.bscCodigoProducto2.Text
            .NombreProducto = Me.bscProducto2.Text
            .IdFormula = Integer.Parse(Me.cmbFormulas.SelectedValue.ToString())
            .NombreFormula = Me.cmbFormulas.Text
            .Cantidad = Decimal.Parse(Me.txtCantidad.Text)
            .IdLote = ""
            .VtoLote = Nothing
         End With

         Me._listaProductos.Add(oLineaProducto)

         Me.ugDetalle.DataSource = Me._listaProductos.ToArray()

         AjustarColumnasGrilla(Me.ugDetalle, _titUG)

         Me.ugDetalle.Refresh()


         Me.LimpiarCamposProductos()

         Me.bscCodigoProducto2.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         Dim dr As Entidades.ProduccionProducto = ugDetalle.FilaSeleccionada(Of Entidades.ProduccionProducto)()
         If dr IsNot Nothing Then
            If MessageBox.Show("Esta seguro de eliminar el producto seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaProducto(dr)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

#Region "Metodos"

   Private Sub Nuevo()
      Me._numeroOrden = 0
      Me.LimpiarCamposProductos()
      Me._listaProductos.Clear()

      Me.ugDetalle.DataSource = Me._listaProductos.ToArray()
      Me.ugDetalle.Refresh()

      If Me.ugDetalle.Rows.Count = 0 Then
         If Not Me.ugDetalleComponentes.DataSource Is Nothing Then
            DirectCast(Me.ugDetalleComponentes.DataSource, DataTable).Rows.Clear()
         End If
         Exit Sub
      End If

      Me.cmbFormulas.Enabled = False
      Me.cmbFormulas.DataSource = Nothing
      Me.bscCodigoProducto2.Focus()
   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

      Me.cmbFormulas.Enabled = True
      Me._publicos.CargaComboFormulasDeProductos(Me.cmbFormulas, Me.bscCodigoProducto2.Text)
      If Me.cmbFormulas.Items.Count > 0 Then
         Me.cmbFormulas.SelectedValue = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text).IdFormula 'Si esta NULL viene en cero y al no encontrar elemento queda en -1
         If Me.cmbFormulas.SelectedIndex = -1 Then
            Me.cmbFormulas.SelectedIndex = 0
         End If
      End If

      Me.txtCantidad.Focus()
   End Sub

   Private Sub LimpiarCamposProductos()
      Me.bscCodigoProducto2.Enabled = True
      Me.bscCodigoProducto2.Text = ""
      Me.bscProducto2.Enabled = True
      Me.bscProducto2.Text = ""
      Me.txtCantidad.Text = "0.00"
   End Sub

   Private Sub EliminarLineaProducto(dr As Entidades.ProduccionProducto)
      Me._listaProductos.Remove(dr)
      Me.ugDetalle.DataSource = Me._listaProductos.ToArray()
   End Sub

   'Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
   '   If e.KeyCode = Keys.Enter Then
   '      Me.ProcessTabKey(True)
   '   End If
   'End Sub

#End Region

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then
            ShowMessage("No existen datos para imprimir.")
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TituloReporte", Me.Text))


         Dim dt1 As DataTable = New DataTable()
         dt1.Columns.Add("IdProducto", GetType(String))
         dt1.Columns.Add("NombreProducto", GetType(String))
         dt1.Columns.Add("NombreFormula", GetType(String))
         dt1.Columns.Add("Cantidad", GetType(Decimal))


         Dim dt2 As DataTable = New DataTable()
         dt2.Columns.Add("IdProductoComponente", GetType(String))
         dt2.Columns.Add("NOMBREPRODUCTO1", GetType(String))
         dt2.Columns.Add("Necesitox1", GetType(Decimal))
         dt2.Columns.Add("CantidadNec", GetType(Decimal))
         dt2.Columns.Add("Stock", GetType(Decimal))
         dt2.Columns.Add("CantidadComp", GetType(Decimal))


         Dim dr1 As DataRow
         Dim dr2 As DataRow

         For Each dr As UltraWinGrid.UltraGridRow In Me.ugDetalle.Rows
            dr1 = dt1.NewRow()
            dr1(0) = dr.Cells("IdProducto").Value.ToString()
            dr1(1) = dr.Cells("NombreProducto").Value.ToString()
            dr1(2) = dr.Cells("NombreFormula").Value.ToString()
            dr1(3) = Decimal.Parse(dr.Cells("Cantidad").Value.ToString())
            dt1.Rows.Add(dr1)
         Next
         dt1.TableName = "Productos"


         For Each dr0 As UltraWinGrid.UltraGridRow In Me.ugDetalleComponentes.Rows
            dr2 = dt2.NewRow()
            dr2(0) = dr0.Cells("IdProductoComponente").Value.ToString()
            dr2(1) = dr0.Cells("NOMBREPRODUCTO1").Value.ToString()
            dr2(2) = Decimal.Parse(dr0.Cells("Necesitox1").Value.ToString())
            dr2(3) = Decimal.Parse(dr0.Cells("CantidadNec").Value.ToString())
            dr2(4) = Decimal.Parse(dr0.Cells("Stock").Value.ToString())
            dr2(5) = Decimal.Parse(dr0.Cells("CantidadComp").Value.ToString())
            dt2.Rows.Add(dr2)
         Next
         dt2.TableName = "Componentes"

         Dim ds As DataSet = New DataSet()

         ds.Tables.Add(dt1)
         ds.Tables.Add(dt2)


         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.CalculoProduccion.rdlc", ds, parm, True, 1) '# 1 = Cantidad de Copias

         frmImprime.Text = Me.Text
         frmImprime.Show()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tbcCalculoProduccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcCalculoProduccion.SelectedIndexChanged
      Try
         If tbcCalculoProduccion.SelectedTab.Equals(tbpProductosParaProduccion) Then
            bscCodigoProducto2.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class