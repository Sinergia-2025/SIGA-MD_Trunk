Option Strict Off

Public Class ListadoDeStock

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbTipoInforme, GetType(Entidades.EnumSql.Stock_TipoReporte))
         cmbTipoInforme.SelectedValue = Entidades.EnumSql.Stock_TipoReporte.General
         'Dim aTipoInforme As ArrayList = New ArrayList
         'aTipoInforme.Insert(0, "General")
         'aTipoInforme.Insert(1, "Mayor ó Igual a Cero ( > = 0 )")
         'aTipoInforme.Insert(2, "Mayor a Cero ( > 0 )")
         'aTipoInforme.Insert(3, "Igual a Cero ( = 0 )")
         'aTipoInforme.Insert(4, "Negativo ( < 0 )")
         'Me.cmbTipoInforme.DataSource = aTipoInforme
         'Me.cmbTipoInforme.SelectedIndex = 0

         cmbMarca_M.Inicializar(True, True, True)
         cmbRubro_M.Inicializar(True, True, True)
         cmbSubRubro_M.Inicializar(True, True, True, {})
         cmbSubSubRubro_M.Inicializar(True, True, True, {})

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.lblSubRubro.Visible = False
            cmbSubRubro_M.Visible = False
            Me.optPorSubRubro.Visible = False


         End If

         If Not Reglas.Publicos.ProductoTieneSubSubRubro Then
            Me.lblSubSubRubro.Visible = False
            cmbSubSubRubro_M.Visible = False
         End If

         'Seguridad del campo Precio de Costo
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         Me.grbPrecio.Visible = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ConsultarPrecios-PrecioCosto")
         '--------------------------------------------------------------------------------

         Me.chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged
      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked
      Me.chbProveedorHabitual.Enabled = False
      Me.chbProveedorHabitual.Checked = False
      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty
      Me.chbEmbalaje.Enabled = False
      Me.chbEmbalaje.Checked = False

      Me.bscCodigoProveedor.Focus()

   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnImprimir.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnImprimir.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

      If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
         MessageBox.Show("ATENCION: Activo el filtro de Proveedor, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProveedor.Focus()
         Exit Sub
      End If

      Try
         Dim IdProveedor As Long = 0

         Dim Filtros As StringBuilder = New StringBuilder()
         'Dim Filtro As String = String.Empty
         Dim QuePrecio As String = String.Empty

         Me.Cursor = Cursors.WaitCursor

         Filtros.AppendFormat("Filtros: Tipo de Informe : {0} - ", Me.cmbTipoInforme.Text)

         cmbMarca_M.CargarFiltrosImpresionMarcas(Filtros, False, True)
         Filtros.AppendFormat(" - ")
         cmbRubro_M.CargarFiltrosImpresionRubros(Filtros, False, True)
         If cmbSubRubro_M.Visible Then
            Filtros.AppendFormat(" - ")
            cmbSubRubro_M.CargarFiltrosImpresionSubRubros(Filtros, False, True)
         End If

         'Select Case Me.cmbTipoInforme.SelectedIndex
         '   Case 0
         '      Filtro = ""
         '   Case 1
         '      Filtro = " > = 0"
         '   Case 2
         '      Filtro = " > 0"
         '   Case 3
         '      Filtro = " = 0"
         '   Case 4
         '      Filtro = " < 0"
         'End Select

         If Me.rdbPrecioDeVenta.Checked Then
            QuePrecio = "VENTA"
         Else
            QuePrecio = "COSTO"
         End If

         Filtros.AppendFormat(" - Mostrando ")

         If rdbNinguno.Checked Then
            Filtros.AppendFormat(rdbNinguno.Text)
         ElseIf rdbPrecioDeCosto.Checked Then
            Filtros.AppendFormat("{0} {1}", rdbPrecioDeCosto.Text, If(chbConIVA.Checked, "Con IVA", "Sin IVA"))
         ElseIf rdbPrecioDeVenta.Checked Then
            Filtros.AppendFormat("{0} {1}", rdbPrecioDeVenta.Text, If(chbConIVA.Checked, "Con IVA", "Sin IVA"))
         End If

         If Me.chbProveedor.Checked Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
            Filtros.AppendFormat(" - ")
            Filtros.AppendFormat("Proveedor : {0}", Me.bscProveedor.Text)
         End If

         Dim oListadoDeStock As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()

         Dim dt As DataTable

         Dim rubros As Entidades.Rubro() = cmbRubro_M.GetRubros(True)
         Dim subRubros As Entidades.SubRubro() = cmbSubRubro_M.GetSubRubros(True)
         dt = oListadoDeStock.GetListadoDeStock({actual.Sucursal}, {}, idProducto:=String.Empty,
                                                cmbMarca_M.GetMarcas(True),
                                                modelos:={},
                                                rubros,
                                                If(rubros.Length = 1, cmbSubRubro_M.GetSubRubros(True), {}),
                                                If(subRubros.Length = 1, cmbSubSubRubro_M.GetSubSubRubros(True), {}),
                                                cmbTipoInforme.ValorSeleccionado(Of Entidades.EnumSql.Stock_TipoReporte)(),
                                                Entidades.EnumSql.InformeStock_OrdenadoPor.Alfabetico,
                                                IdProveedor, chbProveedorHabitual.Checked, Publicos.ListaPreciosPredeterminada,
                                                stockUnificadoPor:=Entidades.EnumSql.InformeStock_UnificadoPor.Ubicacion, tipoDeposito:=Nothing, sucursalesSeleccionoTodos:=False)

         Dim expresionPrecioVenta As String = String.Concat(If(QuePrecio = "COSTO", "PrecioCosto", "PrecioVenta"), If(chbConIVA.Checked, "Con", "Sin"), "Impuestos")
         dt.Columns.Add("PrecioVenta", GetType(Decimal), expresionPrecioVenta)

         Dim parm = New ReportParameterCollection(Filtros.ToString())
         parm.Add("MuestraPrecios", Not rdbNinguno.Checked)

         Dim strReporte As String = String.Empty
         Select Case True

            Case optAlfabetico.Checked

               If Not Me.chbProveedor.Checked Then
                  strReporte = "ListadoDeStock.rdlc"  'Estandar
               Else
                  If Me.chbEmbalaje.Checked Then
                     strReporte = "ListadoDeStock_Alfabetico_Proveedor.rdlc"
                  Else
                     strReporte = "ListadoDeStock.rdlc"  'Estandar
                  End If
               End If

            Case optPorMarca.Checked
               strReporte = "ListadoDeStock_Marca.rdlc"

            Case optPorRubro.Checked
               strReporte = "ListadoDeStock_Rubro.rdlc"

            Case optPorSubRubro.Checked
               strReporte = "ListadoDeStock_SubRubro.rdlc"

               'Case Else
               '   strReporte = "ListadoDeStock_Codigo.rdlc"

         End Select

         Dim frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_ListadoDeStock", dt, parm, True, 1) With {
            .Text = "Listado de Stock",
            .WindowState = FormWindowState.Maximized
         } '# 1 = Cantidad Copias
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro_M.AfterSelectedIndexChanged
      Try
         Dim habilitaSubRubro As Boolean = False
         If cmbRubro_M.SelectedIndex > 0 Then
            Dim rubros As Entidades.Rubro() = cmbRubro_M.GetRubros()
            If rubros.Length = 1 Then
               cmbSubRubro_M.Inicializar(True, True, True, rubros(0))
               habilitaSubRubro = True
            End If
         End If
         cmbSubRubro_M.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         cmbSubRubro_M.Enabled = habilitaSubRubro
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub cmbSubRubro_M_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro_M.AfterSelectedIndexChanged
      Dim habilitaSubSubRubro As Boolean = False
      If cmbSubRubro_M.SelectedIndex > 0 Then
         Dim subRubros As Entidades.SubRubro() = cmbSubRubro_M.GetSubRubros()
         If subRubros.Length = 1 Then
            cmbSubSubRubro_M.Inicializar(True, True, True, subRubros(0))
            habilitaSubSubRubro = True
         End If
      End If
      cmbSubSubRubro_M.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      cmbSubSubRubro_M.Enabled = habilitaSubSubRubro
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
      Me.chbProveedorHabitual.Enabled = True
      Me.chbEmbalaje.Enabled = True
   End Sub

#End Region
   Private Sub optPorMarca_CheckedChanged(sender As Object, e As EventArgs) Handles optPorMarca.CheckedChanged
      If chbProveedor.Checked Then
         Me.chbEmbalaje.Enabled = False
         Me.chbEmbalaje.Checked = False
      End If
   End Sub

   Private Sub optPorRubro_CheckedChanged(sender As Object, e As EventArgs) Handles optPorRubro.CheckedChanged
      If chbProveedor.Checked Then
         Me.chbEmbalaje.Enabled = False
         Me.chbEmbalaje.Checked = False
      End If
   End Sub

   Private Sub optPorSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles optPorSubRubro.CheckedChanged
      If chbProveedor.Checked Then
         Me.chbEmbalaje.Enabled = False
         Me.chbEmbalaje.Checked = False
      End If
   End Sub

   Private Sub chbEmbalaje_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmbalaje.CheckedChanged
      If Not optAlfabetico.Checked Then
         Me.chbEmbalaje.Enabled = False
         Me.chbEmbalaje.Checked = False
      End If
   End Sub

   Private Sub optAlfabetico_CheckedChanged(sender As Object, e As EventArgs) Handles optAlfabetico.CheckedChanged
      If chbProveedor.Checked Then
         Me.chbEmbalaje.Enabled = True
         Me.chbEmbalaje.Checked = False
      End If
   End Sub

End Class