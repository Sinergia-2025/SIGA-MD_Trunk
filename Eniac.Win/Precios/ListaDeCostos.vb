Option Strict Off

Public Class ListaDeCostos

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()
         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)

         Dim oMarca As Reglas.Marcas = New Reglas.Marcas()
         Me.cmbMarca.ValueMember = "IdMarca"
         Me.cmbMarca.DisplayMember = "NombreMarca"

         Me.cmbMarca.DataSource = oMarca.GetAll()
         Me.cmbMarca.SelectedIndex = -1

         Dim oRubro As Reglas.Rubros = New Reglas.Rubros()
         'Me.cmbRubro.ValueMember = "IdRubro"
         'Me.cmbRubro.DisplayMember = "NombreRubro"

         'Me.cmbRubro.DataSource = oRubro.GetAll()
         'Me.cmbRubro.SelectedIndex = -1

         '###########################################
         '# Nuevos combos para Rubro, Sub, y SubSub #
         '###########################################
         Dim rubros As Entidades.Rubro()
         Dim subrubros As Entidades.SubRubro()

         ' Incializo el combo de Rubros
         ' Pongo en 'Todos' los combos de Rubros, Sub, y SubSub
         Me.cmbRubro.Inicializar(True, True, True)
         Me.cmbSubRubro.Inicializar(True, True, True, rubros)
         Me.cmbSubSubRubro.Inicializar(True, True, True, subrubros)

         Me.cmbRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         Me.cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         Me.cmbSubSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)

         ' Verifico si se utiliza SubRubro
         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.lblSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         ' Verifico si se utiliza SubSubRubro
         If Not Reglas.Publicos.ProductoTieneSubSubRubro Then
            Me.lblSubSubRubro.Visible = False
            Me.cmbSubSubRubro.Visible = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         Dim habilitaSubRubro As Boolean = False
         If cmbRubro.SelectedIndex > 0 Then
            Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
            If rubros.Length = 1 Then
               cmbSubRubro.Inicializar(True, True, True, rubros)
               habilitaSubRubro = True
            End If
         End If
         Me.cmbSubRubro.Enabled = habilitaSubRubro
         cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbSubRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.AfterSelectedIndexChanged
      Dim habilitaSubSubRubro As Boolean = False
      If cmbSubRubro.SelectedIndex > 0 Then
         Dim subRubros As Entidades.SubRubro() = cmbSubRubro.GetSubRubros()
         If subRubros.Length = 1 Then
            cmbSubSubRubro.Inicializar(True, True, True, subRubros)
            habilitaSubSubRubro = True
         End If
      End If
      Me.cmbSubSubRubro.Enabled = habilitaSubSubRubro
      cmbSubSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked
      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
      End If
   End Sub

   Private Sub optAlfabetico_CheckedChanged(sender As Object, e As EventArgs) Handles optAlfabetico.CheckedChanged
      If Me.optAlfabetico.Checked Then
         Me.chbImportarProductos.Visible = True
         Me.chbImportarProductos.Checked = True
      End If
   End Sub

   Private Sub optPorRubro_CheckedChanged(sender As Object, e As EventArgs) Handles optPorRubro.CheckedChanged
      If Me.optPorRubro.Checked Then
         Me.chbImportarProductos.Visible = False
      End If
   End Sub

   Private Sub optPorMarca_CheckedChanged(sender As Object, e As EventArgs) Handles optPorMarca.CheckedChanged
      If Me.optPorMarca.Checked Then
         Me.chbImportarProductos.Visible = False
      End If
   End Sub

   Private Sub chbFechaActualizado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaActualizado.CheckedChanged
      Try
         Me.dtpDesde.Enabled = Me.chbFechaActualizado.Checked
         Me.dtpHasta.Enabled = Me.chbFechaActualizado.Checked
         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
         If Me.chbFechaActualizado.Checked Then
            Me.dtpDesde.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      Try
         Dim IdMarca As Integer = 0
         Dim NombreMarca As String = String.Empty

         Dim IdRubro As Integer = 0
         Dim NombreRubro As String = String.Empty

         Dim IdSubRubro As Integer = 0
         Dim NombreSubRubro As String = String.Empty

         Dim IdSubSubRubro As Integer = 0
         Dim NombreSubSubRubro As String = String.Empty

         Dim FechaActDesde As Date = Nothing
         Dim FechaActHasta As Date = Nothing

         If Me.chbFechaActualizado.Checked Then
            FechaActDesde = Me.dtpDesde.Value
            FechaActHasta = Me.dtpHasta.Value
         End If

         Dim Filtros As String

         Me.Cursor = Cursors.WaitCursor

         Dim oListaPrecios As Reglas.PreciosCostoVenta = New Reglas.PreciosCostoVenta()

         If Me.chbMarca.Checked Then
            If Me.cmbMarca.SelectedIndex <> -1 Then
               IdMarca = Me.cmbMarca.SelectedItem("IdMarca").ToString()
               NombreMarca = Me.cmbMarca.Text
            End If
         End If

         If Me.cmbSubRubro.Enabled Then
            IdSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
            NombreSubRubro = Me.cmbSubRubro.Text
         End If

         If Me.cmbSubSubRubro.Enabled Then
            IdSubSubRubro = Integer.Parse(Me.cmbSubSubRubro.SelectedValue.ToString())
            NombreSubSubRubro = Me.cmbSubSubRubro.Text
         End If

         Dim rubros As Entidades.Rubro() = Me.cmbRubro.GetRubros(True)
         Dim subrubros As Entidades.SubRubro() = Me.cmbSubRubro.GetSubRubros(True)
         Dim subsubrubros As Entidades.SubSubRubro() = Me.cmbSubSubRubro.GetSubSubRubros(True)

         Dim dt As DataTable = oListaPrecios.GetListaCosto(Eniac.Entidades.Usuario.Actual.Sucursal.Id, _
                                                           DirectCast(Me.cmbListaDePrecios.SelectedItem,  _
                                                           Entidades.ListaDePrecios).IdListaPrecios, _
                                                           IdMarca, _
                                                           rubros,
                                                           subrubros,
                                                           subsubrubros,
                                                           FechaActDesde, FechaActHasta)

         Filtros = "Filtros: Marca: " & IIf(NombreMarca = "", "TODAS", NombreMarca)

         Filtros = Filtros & " / Rubro: " & IIf(NombreRubro = "", "TODOS", NombreRubro)

         ' Verifico si el producto utiliza SubRubro
         If Reglas.Publicos.ProductoTieneSubRubro Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "SubRubro: " & Me.cmbSubRubro.Text
         End If

         ' Verifico si el producto utiliza SubSubRubro
         If Reglas.Publicos.ProductoTieneSubSubRubro Then
            If Filtros.Length > 0 Then Filtros = Filtros & " / "
            Filtros = Filtros & "SubSubRubro: " & Me.cmbSubSubRubro.Text
         End If

         Filtros = Filtros & " / Lista de Precios: " & Me.cmbListaDePrecios.Text

         ImprimirInformes(dt, Filtros, True)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub

#End Region

#Region "Métodos"

   Public Sub ImprimirInformes(dt As DataTable,
                               filtros As String,
                               visualiza As Boolean)

      Try
         Dim reporte As Entidades.InformePersonalizadoResuelto
         Dim frmImprime As VisorReportes
         Dim strReporte As String = String.Empty
         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", filtros))

         'Por ahora asi, tal vez a futuro lo tome de alguna tabla
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now))


         ' #### SELECCiÓN DE INFORME

         ' Primer checkbox ( Marca )
         If Me.optPorMarca.Checked Then
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDeCostos_Marcas, "Eniac.Win.ListaDeCosto_Marca.rdlc")
         End If

         ' Segundo checkbox ( Rubros )
         If Me.optPorRubro.Checked Then
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDeCostos_Rubros, "Eniac.Win.ListaDeCosto_Rubro.rdlc")
         End If

         ' Tercer checkbox ( alfabético )
         If Me.optAlfabetico.Checked Then
            If Me.chbImportarProductos.Checked Then
               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDeCostos_ImportarP, "Eniac.Win.ListaDeCostoImportar.rdlc")
            Else
               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDeCostos_Alfabetico, "Eniac.Win.ListaDeCosto.rdlc")
            End If
         End If


         'frmImprime = New VisorReportes("Eniac.Win." & strReporte, "dsPrecios_ListaDePreciosCosto", dt, parm, True)

         If visualiza Then
            frmImprime = New VisorReportes(reporte.NombreArchivo, "dsPrecios_ListaDePreciosCosto", dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias

            frmImprime.Text = Me.Text
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.Show()
         Else
            Dim ePDF As Eniac.Win.ExportarPDF = New Eniac.Win.ExportarPDF()
            ePDF.Run(reporte.NombreArchivo, "dsPrecios_ListaDePreciosCosto", dt, parm, reporte.ReporteEmbebido, "")
         End If

      Catch ex As Exception

         ShowError(ex)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

End Class