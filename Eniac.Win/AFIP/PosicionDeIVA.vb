Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Entidades

Public Class PosicionDeIVA

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.dtpPeriodoFiscal.Value = Today.PrimerDiaMes()
         'Me.dtpPeriodoFiscalHasta.Value = Today.UltimoDiaMes(True)
         tsbImprimir.Enabled = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarPantalla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvVentas.RowCount = 0 Then

         End If
         Me.Cursor = Cursors.WaitCursor

         Dim Filtros As String

         Filtros = "Período Fiscal: " & Me.dtpPeriodoFiscal.Text & "."

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PosicionNeto", Me.txtPosicionNeto.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PosicionIVA", Me.txtPosicionIVA.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PosicionTotal", Me.txtPosicionTotal.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Percepciones", Me.txtPercepciones.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Retenciones", Me.txtRetenciones.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PosicionFinalIVA", Me.txtPosicionFinalIVA.Text))

         Dim dt1 As DataTable
         Dim dt2 As DataTable

         dt1 = DirectCast(Me.dgvVentas.DataSource, DataTable).Copy()
         dt1.TableName = "DSReportes_PosicionIVAVentas"
         dt2 = DirectCast(Me.dgvCompras.DataSource, DataTable).Copy()
         dt2.TableName = "DSReportes_PosicionIVACompras"

         Dim ds As DataSet = New DataSet()

         ds.Tables.Add(dt1)
         ds.Tables.Add(dt2)

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.PosicionDeIVA.rdlc", ds, parm, True, 1) '# 1 = Cantidad de Copias

         frmImprime.Text = Me.Text
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


   Private Sub btnConsultar_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Dim Suc As List(Of Integer) = New List(Of Integer)
         Suc.Add(actual.Sucursal.Id)

         Me.TotalVentas()

         Me.TotalCompras(Suc)

         Me.RetencionyPercepcion()

         Me.CalcularPosicion()

         Me.tsbImprimir.Enabled = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarPantalla()

      Me.dtpPeriodoFiscal.Value = Today.PrimerDiaMes()
      'Me.dtpPeriodoFiscalHasta.Value = Today.UltimoDiaMes(True)
      tsbImprimir.Enabled = False
      Me.RefrescarDatosGrillas()

   End Sub

   Private Sub RefrescarDatosGrillas()

      If Not Me.dgvVentas.DataSource Is Nothing Then
         DirectCast(Me.dgvVentas.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.dgvCompras.DataSource Is Nothing Then
         DirectCast(Me.dgvCompras.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtVentasNeto.Text = ""
      Me.txtVentasIVA.Text = ""
      Me.txtVentasImpInt.Text = ""
      Me.txtVentasTotal.Text = ""

      Me.txtComprasNeto.Text = ""
      Me.txtComprasIVA.Text = ""
      Me.txtComprasImpInt.Text = ""
      Me.txtComprasTotal.Text = ""

      Me.txtPosicionNeto.Text = ""
      Me.txtPosicionIVA.Text = ""
      Me.txtPosicionTotal.Text = ""

   End Sub

   Private Sub TotalVentas()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim dtDetalle As DataTable

      Dim TotalNeto As Decimal = 0
      Dim TotalIVA As Decimal = 0
      Dim TotalGeneral As Decimal = 0

      '-.PE-31598.-
      Dim TotalImpuestosInternos As Decimal = 0

      Dim dtComprobante As DataTable

      dtComprobante = Me.CrearDTComprobante()

      Dim periodoFiscal As Integer = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))

      dtDetalle = oVentas.GetTotalPorComprobante(periodoFiscal, "SI")

      Dim drComp As DataRow

      For Each dr As DataRow In dtDetalle.Rows
         drComp = dtComprobante.NewRow()
         drComp("NombreSucursal") = dr("NombreSucursal").ToString()
         drComp("Descripcion") = dr("Descripcion").ToString()
         drComp("Letra") = dr("Letra").ToString()

         'Por ahora dejo afuera el no gravado.

         drComp("Neto") = Decimal.Parse(dr("Neto").ToString())
         drComp("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())

         '-.PE-31598.-
         drComp("TotalImpuestosInternos") = Decimal.Parse(CType(dr("TotalImpuestoInterno"), String)).ToString()

         drComp("Total") = Decimal.Parse(dr("Total").ToString())

         dtComprobante.Rows.Add(drComp)

         TotalNeto += Decimal.Parse(dr("Neto").ToString())
         TotalIVA += Decimal.Parse(dr("TotalImpuestos").ToString())
         '-.PE-31598.-
         TotalImpuestosInternos += CDec(Decimal.Parse(CType(dr("TotalImpuestoInterno"), String)).ToString())
         TotalGeneral += Decimal.Parse(dr("Total").ToString())
      Next

      Me.txtVentasNeto.Text = TotalNeto.ToString("##,##0.00")
      Me.txtVentasIVA.Text = TotalIVA.ToString("##,##0.00")
      Me.txtVentasImpInt.Text = TotalImpuestosInternos.ToString("##,##0.00")
      Me.txtVentasTotal.Text = TotalGeneral.ToString("##,##0.00")

      Me.dgvVentas.DataSource = dtComprobante

   End Sub

   Private Sub TotalCompras(ByVal suc As List(Of Integer))

      Dim oCompras As Reglas.Compras = New Reglas.Compras()

      Dim TotalNeto As Decimal = 0
      Dim TotalIVA As Decimal = 0
      Dim TotalGeneral As Decimal = 0

      '-.PE-31598.-
      Dim TotalImpuestosInternos As Decimal = 0

      Dim dtComprobante As DataTable

      dtComprobante = Me.CrearDTComprobante()

      Dim PeriodoFiscal As Integer = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))

      Dim dsDetalle As DataSet = oCompras.GetResumenDeCompras({actual.Sucursal}, actual.Sucursal.IdEmpresa, PeriodoFiscal, PeriodoFiscal, "SI", "TODOS", "SI", "TODOS", True, separarNetos:=False) ' "TODOS" en el lugar de InformaLibroIva para no alterar el comportamiento actual.
      Dim drComp As DataRow

      For Each dr As DataRow In dsDetalle.Tables(Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra.ToString()).Rows
         drComp = dtComprobante.NewRow()
         drComp("NombreSucursal") = dr("NombreSucursal").ToString()
         drComp("Descripcion") = dr("Descripcion").ToString()
         drComp("Letra") = dr("Letra").ToString()
         drComp("Neto") = Decimal.Parse(dr("NetoNoGravado").ToString()) + Decimal.Parse(dr("Neto").ToString())
         Dim TotalImpuestos As Decimal = 0
         For Each dc As DataColumn In dsDetalle.Tables(Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra.ToString()).Columns
            If dc.ColumnName.StartsWith("____IVA") Then
               TotalImpuestos += Decimal.Parse(dr(dc.ColumnName).ToString())
            End If
         Next

         drComp("TotalImpuestos") = TotalImpuestos

         '-.PE-31598.-
         drComp("TotalImpuestosInternos") = Decimal.Parse(CType(dr("____IMINT_Imp. Internos"), String)).ToString()

         drComp("Total") = Decimal.Parse(dr("Total").ToString())

         dtComprobante.Rows.Add(drComp)

         TotalNeto += Decimal.Parse(dr("NetoNoGravado").ToString()) + Decimal.Parse(dr("Neto").ToString())
         TotalIVA += TotalImpuestos
         TotalImpuestosInternos += CDec(Decimal.Parse(CType(dr("____IMINT_Imp. Internos"), String)).ToString())
         TotalGeneral += Decimal.Parse(dr("Total").ToString())
      Next

      Me.txtComprasNeto.Text = TotalNeto.ToString("##,##0.00")
      Me.txtComprasIVA.Text = TotalIVA.ToString("##,##0.00")
      Me.txtComprasImpInt.Text = TotalImpuestosInternos.ToString("##,##0.00")
      Me.txtComprasTotal.Text = TotalGeneral.ToString("##,##0.00")

      Me.dgvCompras.DataSource = dtComprobante

   End Sub

   Private Function CrearDTComprobante() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("NombreSucursal", System.Type.GetType("System.String"))
         .Columns.Add("Descripcion", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("Neto", System.Type.GetType("System.Decimal"))
         '-.PE-31598.-
         .Columns.Add("TotalImpuestosInternos", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("Total", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

   Private Sub RetencionyPercepcion()

      Dim dt As DataTable
      Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
      Dim periodo As Integer = 0
      Dim ret As Decimal = 0
      Dim per As Decimal = 0

      periodo = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))
      dt = oPF.Get1(actual.Sucursal.IdEmpresa, periodo)

      For Each dr As DataRow In dt.Rows
         ret += Decimal.Parse(dr("TotalRetenciones").ToString())
         per += Decimal.Parse(dr("TotalPercepciones").ToString())
      Next
      Me.txtRetenciones.Text = ret.ToString("##,##0.00")
      Me.txtPercepciones.Text = per.ToString("##,##0.00")

   End Sub

   Private Sub CalcularPosicion()
      Me.txtPosicionNeto.Text = Strings.Format(Decimal.Parse(Me.txtVentasNeto.Text) - Decimal.Parse(Me.txtComprasNeto.Text), "##,##0.00")
      Me.txtPosicionIVA.Text = Strings.Format(Decimal.Parse(Me.txtVentasIVA.Text) - Decimal.Parse(Me.txtComprasIVA.Text), "##,##0.00")
      Me.txtPosicionImpInt.Text = String.Format(CType(Decimal.Parse(Me.txtVentasImpInt.Text) - Decimal.Parse(Me.txtComprasImpInt.Text), String), "##,##0.00")
      Me.txtPosicionTotal.Text = Strings.Format(Decimal.Parse(Me.txtVentasTotal.Text) - Decimal.Parse(Me.txtComprasTotal.Text), "##,##0.00")
      Me.txtPosicionFinalIVA.Text = Strings.Format(Decimal.Parse(Me.txtVentasIVA.Text) - Decimal.Parse(Me.txtComprasIVA.Text) - Decimal.Parse(Me.txtRetenciones.Text) - Decimal.Parse(Me.txtPercepciones.Text), "##,##0.00")
   End Sub

#End Region

   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes()
      Me.tsbImprimir.Enabled = False
   End Sub

End Class