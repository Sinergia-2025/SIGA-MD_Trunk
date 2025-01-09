Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class InfKilosCompMensualPorCliente

#Region "Campos"

   Private _publicos As Publicos
   Private _periodos As Long
   Private M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, M11, M12 As Date
   Private Mes1, Mes2, Mes3, Mes4, Mes5, Mes6, Mes7, Mes8, Mes9, Mes10, Mes11, Mes12 As String
   Private _Imprimir As DataTable = New DataTable()
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)

         'Me._publicos.CargaComboMarcas(Me.cmbMarca)
         'Me._publicos.CargaComboRubros(Me.cmbRubro)

         '-.PE-31812.-
         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub InfKilosCompMensualPorCliente_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Dim Filtros As String

         Dim IdVendedor As Integer

         Me.Cursor = Cursors.WaitCursor

         Filtros = "Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado

            Filtros = Filtros & " / Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         End If

         If Me.chbCliente.Checked And (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            Filtros = Filtros & " / Zona Geografica: " & Me.cmbZonaGeografica.Text
         End If

         'If Me.chbMarca.Checked Then
         '   Filtros = Filtros & " / Marca: " & Me.cmbMarca.Text
         'End If

         'If Me.chbRubro.Checked Then
         '   Filtros = Filtros & " / Rubro: " & Me.cmbRubro.Text
         'End If

         If Me.chbProducto.Checked Then
            Filtros = Filtros & " / Producto: " & Me.bscCodigoProducto2.Text & " - " & Me.bscProducto2.Text
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            Filtros = Filtros & " / Localidad: " & Me.bscCodigoLocalidad.Text.Trim() & " - " & Me.bscNombreLocalidad.Text.Trim()
         End If

         If Me.rbtPorKilos.Checked Then
            Filtros = Filtros & " / Por Kilos"
         Else
            Filtros = Filtros & " / Por Importe " & IIf(Me.chbConIVA.Checked, "Con IVA", "Sin IVA").ToString()
         End If

         Dim dt As DataTable

         dt = DirectCast(Me._Imprimir, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         If 1 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes1", Mes1))
         End If
         If 2 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes2", Mes2))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes2", ""))
         End If
         If 3 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes3", Mes3))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes3", ""))
         End If
         If 4 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes4", Mes4))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes4", ""))
         End If
         If 5 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes5", Mes5))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes5", ""))
         End If
         If 6 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes6", Mes6))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes6", ""))
         End If
         If 7 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes7", Mes7))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes7", ""))
         End If
         If 8 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes8", Mes8))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes8", ""))
         End If
         If 9 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes9", Mes9))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes9", ""))
         End If
         If 10 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes10", Mes10))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes10", ""))
         End If
         If 11 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes11", Mes11))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes11", ""))
         End If
         If 12 <= Me._periodos Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes12", Mes12))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Mes12", ""))
         End If



         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfKilosCompMensualPorCliente.rdlc", "DSReportes_InfKilosCompMensualPorCliente", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If

   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If
      End If

      Me.cmbVendedor.Focus()

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Permitido = Me.chbCliente.Checked
      Me.bscCodigoCliente.Permitido = Me.chbCliente.Checked
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty
      Else
         Me.bscCodigoCliente.Focus()
      End If
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbLocalidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLocalidad.CheckedChanged

      Me.bscCodigoLocalidad.Permitido = Me.chbLocalidad.Checked
      Me.bscNombreLocalidad.Permitido = Me.chbLocalidad.Checked

      Me.bscCodigoLocalidad.Text = String.Empty
      Me.bscNombreLocalidad.Text = String.Empty

      Me.bscCodigoLocalidad.Focus()

   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad)
         Me.bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try

         If Me.dtpDesde.Value.Date > Me.dtpHasta.Value.Date Then
            MessageBox.Show("ATENCION: El periodo Desde es INVALIDO.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If

         Me._periodos = DateDiff(DateInterval.Month, Me.dtpDesde.Value.Date, Me.dtpHasta.Value.Date) + 1
         If Me._periodos > 12 Then
            MessageBox.Show("ATENCION: No puede elegir mas de 12 meses.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpDesde.Focus()
            Exit Sub
         End If

         'If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: Debe seleccionar un VENDEDOR.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbVendedor.Focus()
         '   Exit Sub
         'End If

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un CLIENTE aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbProducto.Checked And Me.bscCodigoProducto2.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un PRODUCTO aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbLocalidad.Checked And Not Me.bscCodigoLocalidad.Selecciono And Not Me.bscNombreLocalidad.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó una LOCALIDAD aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoLocalidad.Focus()
            Exit Sub
         End If

         If Me.chbClienteVinculado.Checked And Not (Me.bscCodigoClienteVinculado.Selecciono Or Me.bscClienteVinculado.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un CLIENTE VINCULADO aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoClienteVinculado.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged

      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked

      'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
         cmbMarcas.Refrescar()
         cmbRubros.Refrescar()
      End If

      Me.bscCodigoProducto2.Focus()

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
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
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

   'Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   Me.cmbMarca.Enabled = Me.chbMarca.Checked

   '   If Not Me.chbMarca.Checked Then
   '      Me.cmbMarca.SelectedIndex = -1
   '   Else
   '      If Me.cmbMarca.Items.Count > 0 Then
   '         Me.cmbMarca.SelectedIndex = 0
   '      End If
   '      'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
   '      'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
   '      Me.chbProducto.Checked = False
   '   End If

   '   Me.cmbMarca.Focus()

   'End Sub

   'Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   Me.cmbRubro.Enabled = Me.chbRubro.Checked

   '   If Not Me.chbRubro.Checked Then
   '      Me.cmbRubro.SelectedIndex = -1
   '   Else
   '      If Me.cmbRubro.Items.Count > 0 Then
   '         Me.cmbRubro.SelectedIndex = 0
   '      End If
   '      'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
   '      'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
   '      Me.chbProducto.Checked = False
   '   End If

   '   Me.cmbRubro.Focus()

   'End Sub
   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
                    cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
                    cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                           marcas:=marcas)
                 End Sub)
   End Sub

   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
                    cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
                    cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                             rubros:=rubros)
                 End Sub)
   End Sub

   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
                    cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
                    cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                                subRubro:=subRubros)
                 End Sub)

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Permitido = False
      Me.bscCodigoCliente.Permitido = False

   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)

      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.bscCodigoLocalidad.Permitido = False
      Me.bscNombreLocalidad.Permitido = False

   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now.AddYears(-1)
      Me.dtpHasta.Value = Date.Now.AddMonths(-1)

      Me.chbVendedor.Checked = False
      Me.chbZonaGeografica.Checked = False

      Me.chbCliente.Checked = False

      'Me.chbMarca.Checked = False
      'Me.chbRubro.Checked = False
      Me.chbProducto.Checked = False

      Me.chbLocalidad.Checked = False
      Me.rbtPorKilos.Checked = True
      Me.chbClienteVinculado.Checked = False
      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      cmbSucursal.Refrescar()
      cmbMarcas.Refrescar()
      cmbRubros.Refrescar()

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim IdCliente As Long = 0
      Dim IdClienteVinculado As Long = 0

      Dim IdVendedor As Integer = 0

      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim IdProducto As String = String.Empty

      Dim IdZonaGeografica As String = String.Empty

      Dim IdLocalidad As Integer = 0

      Dim decTotalKilos As Decimal = 0

      Dim TipoInforme As String = String.Empty

      Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

      Try

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         'If Me.chbMarca.Checked Then
         '   IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
         'End If

         'If Me.chbRubro.Checked Then
         '   IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         'End If

         If Me.cmbZonaGeografica.Enabled Then
            IdZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If

         If Me.chbProducto.Checked Then
            IdProducto = Me.bscCodigoProducto2.Text
         End If

         If Me.chbLocalidad.Checked And (Me.bscCodigoLocalidad.Selecciono Or Me.bscNombreLocalidad.Selecciono) Then
            IdLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
         End If

         If Me.chbClienteVinculado.Checked Then
            IdClienteVinculado = Long.Parse(Me.bscCodigoClienteVinculado.Tag.ToString())
         End If

         TipoInforme = IIf(Me.rbtPorKilos.Checked, "KILOS", "IMPORTE").ToString()


         dtDetalle = oVentas.GetKilosCompMensualPorCliente(cmbSucursal.GetSucursales(),
                                                           Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                           IdVendedor, IdCliente,
                                                           cmbMarcas.GetMarcas(todosVacio:=True).ToList(),
                                       cmbModelos.GetModelos(todosVacio:=True).ToList(),
                                       cmbRubros.GetRubros(todosVacio:=True).ToList(),
                                       cmbSubRubros.GetSubRubros(todosVacio:=True).ToList(),
                                       cmbSubSubRubros.GetSubSubRubros(todosVacio:=True).ToList(),
                                                           IdProducto,
                                                           IdZonaGeografica,
                                                           IdLocalidad,
                                                           TipoInforme,
                                                           Me.chbConIVA.Checked,
                                                           IdClienteVinculado)



         dt = Me.CrearDT()

         Me.DefinirPeriodos()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdSucursal") = dr("IdSucursal") '-.PE-31812.-
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
            drCl("MesActual") = Decimal.Parse(dr("MesActual").ToString())
            drCl("Total") = Decimal.Parse(dr("Total").ToString())
            drCl("Promedio") = Decimal.Parse(dr("Promedio").ToString())

            If 1 <= Me._periodos Then
               drCl("Mes1") = Decimal.Parse(dr(Mes1).ToString())
            End If
            If 2 <= Me._periodos Then
               drCl("Mes2") = Decimal.Parse(dr(Mes2).ToString())
            Else
               drCl("Mes2") = 0
            End If
            If 3 <= Me._periodos Then
               drCl("Mes3") = Decimal.Parse(dr(Mes3).ToString())
            Else
               drCl("Mes3") = 0
            End If
            If 4 <= Me._periodos Then
               drCl("Mes4") = Decimal.Parse(dr(Mes4).ToString())
            Else
               drCl("Mes4") = 0
            End If
            If 5 <= Me._periodos Then
               drCl("Mes5") = Decimal.Parse(dr(Mes5).ToString())
            Else
               drCl("Mes5") = 0
            End If
            If 6 <= Me._periodos Then
               drCl("Mes6") = Decimal.Parse(dr(Mes6).ToString())
            Else
               drCl("Mes6") = 0
            End If
            If 7 <= Me._periodos Then
               drCl("Mes7") = Decimal.Parse(dr(Mes7).ToString())
            Else
               drCl("Mes7") = 0
            End If
            If 8 <= Me._periodos Then
               drCl("Mes8") = Decimal.Parse(dr(Mes8).ToString())
            Else
               drCl("Mes8") = 0
            End If
            If 9 <= Me._periodos Then
               drCl("Mes9") = Decimal.Parse(dr(Mes9).ToString())
            Else
               drCl("Mes9") = 0
            End If
            If 10 <= Me._periodos Then
               drCl("Mes10") = Decimal.Parse(dr(Mes10).ToString())
            Else
               drCl("Mes10") = 0
            End If
            If 11 <= Me._periodos Then
               drCl("Mes11") = Decimal.Parse(dr(Mes11).ToString())
            Else
               drCl("Mes11") = 0
            End If
            If 12 <= Me._periodos Then
               drCl("Mes12") = Decimal.Parse(dr(Mes12).ToString())
            Else
               drCl("Mes12") = 0
            End If



            decTotalKilos = decTotalKilos + Decimal.Parse(dr("Total").ToString())

            dt.Rows.Add(drCl)

         Next

         Me._Imprimir = dt

         Me.ugDetalle.DataSource = dtDetalle

         Me.FormatearGrilla()

         Me.CargarColumnasASumar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearGrilla()

      With Me.ugDetalle.DisplayLayout.Bands(0)

         .Columns("IdCliente").Hidden = True
         .Columns("CodigoCliente").Header.Caption = "Codigo"
         .Columns("CodigoCliente").Width = 100
         .Columns("CodigoCliente").Header.VisiblePosition = 0
         .Columns("NombreCliente").Header.Caption = "Cliente"
         .Columns("NombreCliente").Width = 250
         .Columns("NombreCliente").Header.VisiblePosition = 1
         .Columns("NombreLocalidad").Header.Caption = "Localidad"
         .Columns("NombreLocalidad").Width = 180
         .Columns("NombreLocalidad").Header.VisiblePosition = 2
         .Columns("MesActual").Header.Caption = "Mes Actual"
         .Columns("MesActual").Format = "N2"
         .Columns("MesActual").CellAppearance.TextHAlign = HAlign.Right
         .Columns("MesActual").Header.VisiblePosition = 3
         .Columns("Total").Header.Caption = "Total"
         .Columns("Total").Format = "N2"
         .Columns("Total").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Total").Header.VisiblePosition = 4
         .Columns("Promedio").Header.Caption = "Promedio"
         .Columns("Promedio").Format = "N2"
         .Columns("Promedio").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Promedio").Header.VisiblePosition = 5
         If 1 <= Me._periodos Then
            .Columns(Mes1).Format = "N2"
            .Columns(Mes1).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 2 <= Me._periodos Then
            .Columns(Mes2).Format = "N2"
            .Columns(Mes2).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 3 <= Me._periodos Then
            .Columns(Mes3).Format = "N2"
            .Columns(Mes3).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 4 <= Me._periodos Then
            .Columns(Mes4).Format = "N2"
            .Columns(Mes4).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 5 <= Me._periodos Then
            .Columns(Mes5).Format = "N2"
            .Columns(Mes5).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 6 <= Me._periodos Then
            .Columns(Mes6).Format = "N2"
            .Columns(Mes6).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 7 <= Me._periodos Then
            .Columns(Mes7).Format = "N2"
            .Columns(Mes7).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 8 <= Me._periodos Then
            .Columns(Mes8).Format = "N2"
            .Columns(Mes8).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 9 <= Me._periodos Then
            .Columns(Mes9).Format = "N2"
            .Columns(Mes9).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 10 <= Me._periodos Then
            .Columns(Mes10).Format = "N2"
            .Columns(Mes10).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 11 <= Me._periodos Then
            .Columns(Mes11).Format = "N2"
            .Columns(Mes11).CellAppearance.TextHAlign = HAlign.Right
         End If

         If 12 <= Me._periodos Then
            .Columns(Mes12).Format = "N2"
            .Columns(Mes12).CellAppearance.TextHAlign = HAlign.Right
         End If

      End With
   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
         .Columns.Add("Promedio", System.Type.GetType("System.Decimal"))
         .Columns.Add("MesActual", System.Type.GetType("System.Decimal"))
         For Cont As Long = 1 To 12
            .Columns.Add("Mes" & Cont.ToString(), System.Type.GetType("System.Decimal"))
         Next

      End With

      Return dtTemp

   End Function

#End Region
   Private Sub DefinirPeriodos()
      M1 = Me.dtpDesde.Value
      Mes1 = M1.ToString("yyyyMM")
      M2 = M1.AddMonths(1)
      Mes2 = M2.ToString("yyyyMM")
      M3 = M2.AddMonths(1)
      Mes3 = M3.ToString("yyyyMM")
      M4 = M3.AddMonths(1)
      Mes4 = M4.ToString("yyyyMM")
      M5 = M4.AddMonths(1)
      Mes5 = M5.ToString("yyyyMM")
      M6 = M5.AddMonths(1)
      Mes6 = M6.ToString("yyyyMM")
      M7 = M6.AddMonths(1)
      Mes7 = M7.ToString("yyyyMM")
      M8 = M7.AddMonths(1)
      Mes8 = M8.ToString("yyyyMM")
      M9 = M8.AddMonths(1)
      Mes9 = M9.ToString("yyyyMM")
      M10 = M9.AddMonths(1)
      Mes10 = M10.ToString("yyyyMM")
      M11 = M10.AddMonths(1)
      Mes11 = M11.ToString("yyyyMM")
      M12 = M11.AddMonths(1)
      Mes12 = M12.ToString("yyyyMM")
   End Sub

   Private Sub rbtPorMonto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPorMonto.CheckedChanged
      Try
         If Me.rbtPorMonto.Checked Then
            Me.chbConIVA.Visible = True
         Else
            Me.chbConIVA.Visible = False
         End If

      Catch ex As Exception

      End Try
   End Sub

   Private Sub CargarColumnasASumar()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("MesActual") Then
         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("MesActual")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("MesActual", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Total")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Total", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Promedio")
         Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Promedio", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:N2}"
         summary3.Appearance.TextHAlign = HAlign.Right

         If 1 <= Me._periodos Then
            Dim columnToSummarize4 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes1)
            Dim summary4 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes1, SummaryType.Sum, columnToSummarize4)
            summary4.DisplayFormat = "{0:N2}"
            summary4.Appearance.TextHAlign = HAlign.Right
         End If

         If 2 <= Me._periodos Then
            Dim columnToSummarize5 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes2)
            Dim summary5 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes2, SummaryType.Sum, columnToSummarize5)
            summary5.DisplayFormat = "{0:N2}"
            summary5.Appearance.TextHAlign = HAlign.Right
         End If

         If 3 <= Me._periodos Then
            Dim columnToSummarize6 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes3)
            Dim summary6 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes3, SummaryType.Sum, columnToSummarize6)
            summary6.DisplayFormat = "{0:N2}"
            summary6.Appearance.TextHAlign = HAlign.Right
         End If

         If 4 <= Me._periodos Then
            Dim columnToSummarize7 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes4)
            Dim summary7 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes4, SummaryType.Sum, columnToSummarize7)
            summary7.DisplayFormat = "{0:N2}"
            summary7.Appearance.TextHAlign = HAlign.Right
         End If

         If 5 <= Me._periodos Then
            Dim columnToSummarize8 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes5)
            Dim summary8 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes5, SummaryType.Sum, columnToSummarize8)
            summary8.DisplayFormat = "{0:N2}"
            summary8.Appearance.TextHAlign = HAlign.Right
         End If

         If 6 <= Me._periodos Then
            Dim columnToSummarize9 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes6)
            Dim summary9 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes6, SummaryType.Sum, columnToSummarize9)
            summary9.DisplayFormat = "{0:N2}"
            summary9.Appearance.TextHAlign = HAlign.Right
         End If

         If 7 <= Me._periodos Then
            Dim columnToSummarize10 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes7)
            Dim summary10 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes7, SummaryType.Sum, columnToSummarize10)
            summary10.DisplayFormat = "{0:N2}"
            summary10.Appearance.TextHAlign = HAlign.Right
         End If

         If 8 <= Me._periodos Then
            Dim columnToSummarize11 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes8)
            Dim summary11 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes8, SummaryType.Sum, columnToSummarize11)
            summary11.DisplayFormat = "{0:N2}"
            summary11.Appearance.TextHAlign = HAlign.Right
         End If

         If 9 <= Me._periodos Then
            Dim columnToSummarize12 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes9)
            Dim summary12 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes9, SummaryType.Sum, columnToSummarize12)
            summary12.DisplayFormat = "{0:N2}"
            summary12.Appearance.TextHAlign = HAlign.Right
         End If

         If 10 <= Me._periodos Then
            Dim columnToSummarize13 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes10)
            Dim summary13 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes10, SummaryType.Sum, columnToSummarize13)
            summary13.DisplayFormat = "{0:N2}"
            summary13.Appearance.TextHAlign = HAlign.Right
         End If

         If 11 <= Me._periodos Then
            Dim columnToSummarize14 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes11)
            Dim summary14 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes11, SummaryType.Sum, columnToSummarize14)
            summary14.DisplayFormat = "{0:N2}"
            summary14.Appearance.TextHAlign = HAlign.Right
         End If

         If 12 <= Me._periodos Then
            Dim columnToSummarize15 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns(Mes12)
            Dim summary15 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add(Mes12, SummaryType.Sum, columnToSummarize15)
            summary15.DisplayFormat = "{0:N2}"
            summary15.Appearance.TextHAlign = HAlign.Right
         End If


         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"
      End If

   End Sub

   Private Sub tsbImprimirInf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirInf.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         If Me.chbCliente.Checked Then
            Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         End If

         'If Me.cmbTiposComprobantes.Enabled Then
         '   Filtros = Filtros & " / Tipo Comprobante: " & Me.cmbTiposComprobantes.Text
         'End If

         If Me.cmbVendedor.Enabled Then
            Dim IdVendedor As Integer
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
            Filtros = Filtros & " / Vendedor: " & IdVendedor & " - " & Me.cmbVendedor.Text
         End If

         'If Me.cmbFormaPago.Enabled Then
         '   Filtros = Filtros & " / F. de Pago: " & Me.cmbFormaPago.Text
         'End If

         'If Me.cmbUsuario.Enabled Then
         '   Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
         'End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub


   Private Sub CargarDatosClienteVinculado(ByVal dr As DataGridViewRow)

      Me.bscClienteVinculado.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoClienteVinculado.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      Me.bscCodigoClienteVinculado.Tag = dr.Cells("IdCliente").Value.ToString()
   End Sub

   Private Sub chbClienteVinculado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbClienteVinculado.CheckedChanged
      Me.bscCodigoClienteVinculado.Enabled = Me.chbClienteVinculado.Checked
      Me.bscClienteVinculado.Enabled = Me.chbClienteVinculado.Checked
      If Not Me.chbClienteVinculado.Checked Then
         Me.bscCodigoClienteVinculado.Text = String.Empty
         Me.bscCodigoClienteVinculado.Tag = Nothing
         Me.bscClienteVinculado.Text = String.Empty
      Else
         Me.bscCodigoClienteVinculado.Focus()
      End If
   End Sub
   Private Sub bscCodigoClienteVinculado_BuscadorClick() Handles bscCodigoClienteVinculado.BuscadorClick, bscCodigoClienteVinculado.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoClienteVinculado)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoClienteVinculado.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoClienteVinculado.Text.Trim())
         End If
         Me.bscCodigoClienteVinculado.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub bscCodigoClienteVinculado_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoClienteVinculado.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteVinculado(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscClienteVinculado_BuscadorClick() Handles bscClienteVinculado.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscClienteVinculado)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscClienteVinculado.Datos = oClientes.GetFiltradoPorNombre(Me.bscClienteVinculado.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscClienteVinculado_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscClienteVinculado.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteVinculado(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class