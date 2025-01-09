Public Class SueldosLibroDeSueldosyJornales

#Region "Campos"

   Private _publicos As Publicos
   Private DsSueldos As DataSetSueldos
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboSueldosPeriodosLiquidacion(Me.cmbPeriodoLiquidacion)

         Me.chbTipoDeRecibo.Checked = True

         Me._publicos.CargaComboSueldosTiposRecibos(Me.cmbTipoRecibo)

         Me.chbTipoDeRecibo.Checked = False

         If Me.cmbPeriodoLiquidacion.Items.Count = 0 Then
            Throw New Exception("No existen Periodos de Liquidaciones Cerrados.")
         End If

         Me.CargarComboSueldosNroLiquidacion()

         Me.tssRegistros.Text = ""

         Me.ugDetalle.DisplayLayout.Bands(0).Override.HeaderPlacement = HeaderPlacement.FixedOnTop

         Dim columnToSummarize As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(1).Columns("ImporteHaberes")
         Dim summary As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(1).Summaries.Add("ImporteHaberes", SummaryType.Sum, columnToSummarize)
         summary.DisplayFormat = "{0:N2}"
         summary.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(1).Columns("ImporteDescuentos")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(1).Summaries.Add("ImporteDescuentos", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(1).Columns("ImporteAportesPatronales")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(1).Summaries.Add("ImporteAportesPatronales", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(1).Columns("Valor")
         Me.ugDetalle.DisplayLayout.Bands(1).Summaries.Add("Valor", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Me.ugDetalle.DisplayLayout.Bands(1).Columns("Valor"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
         Me.ugDetalle.DisplayLayout.Bands(1).Summaries("Valor").Formula = "sum([ImporteHaberes]) - sum([ImporteDescuentos])"
         Me.ugDetalle.DisplayLayout.Bands(1).Summaries("Valor").DisplayFormat = "Neto a cobrar = {0:N2}"

         Me.ugDetalle.DisplayLayout.Bands(1).SummaryFooterCaption = ""

         Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
   End Sub

#End Region

#Region "Eventos"

   Private Sub SueldosEmisionRecibos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      'If e.KeyCode = Keys.F5 Then
      '   Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      'End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Dim stbTitulo = New StringBuilder()
      Dim rEmpresaAct As Reglas.EmpresaActividades = New Reglas.EmpresaActividades()
      Dim dtEmpAct As DataTable = rEmpresaAct.GetEmpresaActividades(idProvincia:="")

      stbTitulo.AppendFormatLine("{0}  CUIT: {1}", Reglas.Publicos.NombreEmpresaImpresion, Reglas.Publicos.CuitEmpresa)
      Dim separador = ""
      For Each dr As DataRow In dtEmpAct.Rows
         stbTitulo.AppendFormat("{2}{0} {1}", dr.Field(Of Integer)("IdActividad"), dr.Field(Of String)("NombreActividad"), separador)
         separador = " - "
      Next
      stbTitulo.AppendLine()
      stbTitulo.AppendLine(actual.Sucursal.Direccion)
      stbTitulo.AppendLine()
      stbTitulo.AppendLine("Libro de Sueldos y Jornales")
      stbTitulo.AppendLine(CargarFiltroImpresion())

      Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
      Me.UltraGridPrintDocument1.Header.TextCenter = stbTitulo.ToString()
      Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
      Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 5
      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 5
      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 14
      Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 8
      Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
      Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

      Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
      Me.UltraPrintPreviewDialog1.ShowDialog()

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

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscNroLegajo.BuscadorClick


      Dim NroDoc As Integer = -1

      Try
         Me._publicos.PreparaGrillaPersonal(Me.bscNroLegajo)
         Dim oLegajos As Reglas.SueldosPersonal = New Reglas.SueldosPersonal
         If Me.bscNroLegajo.Text.Trim.Length > 0 Then
            NroDoc = Integer.Parse(Me.bscNroLegajo.Text.Trim())
         End If
         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)
         Me.bscNroLegajo.Datos = oLegajos.GetFiltradoPorLegajo(NroDoc)

         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNroLegajo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPersonal(e.FilaDevuelta)
            'Me.CargaGrillasConceptos()
            'Me.bscCodigoConcepto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscSocio_BuscadorClick() Handles bscNombrePersonal.BuscadorClick
      Try
         Me._publicos.PreparaGrillaPersonal(Me.bscNombrePersonal)
         Dim oLegajos As Reglas.SueldosPersonal = New Reglas.SueldosPersonal

         Me.bscNombrePersonal.Datos = oLegajos.GetFiltradoPorNombre(Me.bscNombrePersonal.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscSocio_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombrePersonal.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPersonal(e.FilaDevuelta)
            ' Me.CargaGrillasConceptos()
            ' Me.bscCodigoConcepto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbSocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLegajo.CheckedChanged

      '  Me.cmbTipoDoc.Enabled = Me.chbSocio.Checked
      Me.bscNroLegajo.Enabled = Me.chbLegajo.Checked
      Me.bscNombrePersonal.Enabled = Me.chbLegajo.Checked

      If Not Me.chbLegajo.Checked Then
         '       Me.cmbTipoDoc.Text = Publicos.TipoDocumentoSocio()
         Me.bscNroLegajo.Text = ""
         Me.bscNombrePersonal.Text = ""
      Else
         Me.bscNroLegajo.Focus()
      End If
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Try

            If Me.cmbPeriodoLiquidacion.SelectedIndex = -1 Then
               MessageBox.Show("No seleccionó el Periodo de Liquidación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.cmbPeriodoLiquidacion.Focus()
               Exit Sub
            End If
            If Me.chbTipoDeRecibo.Checked Then
               If Me.cmbTipoRecibo.SelectedIndex = -1 Then
                  MessageBox.Show("Seleccionar un tipo de recibo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.cmbTipoRecibo.Focus()
                  Exit Sub
               End If

               If Me.cmbNroLiquidacion.SelectedIndex = -1 Then
                  MessageBox.Show("No existe la Liquidación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Me.cmbPeriodoLiquidacion.Focus()
                  Exit Sub
               End If

            End If

            Me.Cursor = Cursors.WaitCursor

            Me.CargaGrillaDetalle()

            Me.chkExpandAll.Enabled = True

            Me.tsbImprimir.Enabled = True

            If DsSueldos.ReciboSueldoCabecera.Rows.Count = 0 Then
               Me.Cursor = Cursors.Default
               MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try


         'VER !!!!!

         Dim dt1 As DataTable
         Dim dt2 As DataTable

         dt1 = DirectCast(DsSueldos.ReciboSueldoCabecera, DataSetSueldos.ReciboSueldoCabeceraDataTable).Copy()
         dt1.TableName = "DataSetSueldos_ReciboSueldoCabecera"

         dt2 = DirectCast(DsSueldos.ReciboSueldoDetalle, DataSetSueldos.ReciboSueldoDetalleDataTable).Copy()
         dt2.TableName = "DataSetSueldos_ReciboSueldoDetalle"


         Dim ds As DataSet = New DataSet()

         ds.Tables.Add(dt1)
         ds.Tables.Add(dt2)

         Dim Relacion As DataRelation
         Relacion = New DataRelation("DataSetSueldos_ReciboSueldoDetalle", dt1.Columns("Legajo"), dt2.Columns("IdLegajo"))
         ds.Relations.Add(Relacion)

         Me.ugDetalle.DataSource = ds

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged

      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugdLibroSueldos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      Dim calcManager As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
      calcManager = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Me.Container)
      e.Layout.Grid.CalcManager = calcManager

   End Sub

   Private Sub cmbTipoRecibo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoRecibo.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me.CargarComboSueldosNroLiquidacion()
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cmbPeridoLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoLiquidacion.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me.CargarComboSueldosNroLiquidacion()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbTipoDeRecibo_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoDeRecibo.CheckedChanged
      Try
         Me.cmbTipoRecibo.SelectedIndex = -1
         Me.cmbTipoRecibo.Enabled = Me.chbTipoDeRecibo.Checked

         Me.cmbNroLiquidacion.SelectedIndex = -1
         Me.cmbNroLiquidacion.Enabled = Me.chbTipoDeRecibo.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"


   Private Function CargarFiltroImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         .AppendFormat("Periodo liquidado: {0} - ", Me.cmbPeriodoLiquidacion.Text)

         If Me.chbTipoDeRecibo.Checked Then

            .AppendFormat(" Tipo : {0} - ", Me.cmbTipoRecibo.Text)
            .AppendFormat(" Nro. Liq. : {0} - ", Me.cmbNroLiquidacion.Text)

         End If

         If Me.chbLegajo.Checked Then

            .AppendFormat(" Nro. Legajo : {0} - ", Me.bscNroLegajo.Text)
            .AppendFormat(" Nombre : {0} - ", Me.bscNombrePersonal.Text)

         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub CargarComboSueldosNroLiquidacion()
      Dim idTipoRecibo As Integer? = Nothing
      If Me.cmbTipoRecibo.SelectedValue IsNot Nothing Then
         idTipoRecibo = Integer.Parse(Me.cmbTipoRecibo.SelectedValue.ToString())
      End If
      Me._publicos.CargaComboSueldosNroLiquidacion(Me.cmbNroLiquidacion,
                                                   idTipoRecibo,
                                                   Integer.Parse(cmbPeriodoLiquidacion.SelectedValue.ToString()))


   End Sub

   Private Sub CargarDatosPersonal(ByVal dr As DataGridViewRow)

      Me.bscNombrePersonal.Text = dr.Cells("NombrePersonal").Value.ToString()
      Me.bscNroLegajo.Text = dr.Cells("idLegajo").Value.ToString()
      '  Me.lblCategoriaSocio.Text = dr.Cells("NombreCategoria").Value.ToString
      '  Me.lblCategoriaSocio.Tag = dr.Cells("IdCategoria").Value.ToString
      '  Me.lblEstadoCivil.Text = dr.Cells("NombreEstadoCivil").Value.ToString
      '  Me.bscNombrePersonal.Enabled = False
      '    Me.bscNroLegajo.Enabled = False
   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oSueldos As Reglas.SueldosLiquidacion = New Reglas.SueldosLiquidacion()
         Dim oPersonal As Reglas.SueldosPersonal = New Reglas.SueldosPersonal()


         Dim dtPersonal As DataTable

         '   Dim Periodo As Integer = Integer.Parse(Me.txtPeriodo.Text)

         Dim TipoDocSocio As String = ""
         Dim NroDocSocio As Integer = 0

         If Me.chbLegajo.Checked Then
            NroDocSocio = Integer.Parse(bscNroLegajo.Text)
         End If

         If rbtNroLegajo.Checked Then
            dtPersonal = oPersonal.GetFiltradoPorLegajo(NroDocSocio, False, True)
         Else
            dtPersonal = oPersonal.GetFiltradoPorLegajo(NroDocSocio, False, False)
         End If

         DsSueldos = New DataSetSueldos()
         Dim RegCabecera As DataSetSueldos.ReciboSueldoCabeceraRow
         Dim RegDetalle As DataSetSueldos.ReciboSueldoDetalleRow
         Dim Orden As Integer = 0
         '  Dim nMes As String = MonthName(Integer.Parse(Mid(Periodo.ToString(), 5, 2))) & "/" & Mid(Periodo.ToString, 1, 4)

         Dim Total As Decimal = 0
         Dim idLegajo As Integer = 0
         Dim nroLiquidacionP As Integer = 0
         Dim TablaDetalle As DataTable
         Dim TotalHaberes As Decimal
         Dim TotalDescuentos As Decimal
         Dim TotalAportesPatronales As Decimal
         Dim nroLiquidacion As Integer? = Nothing
         If Me.cmbNroLiquidacion.SelectedValue IsNot Nothing Then
            nroLiquidacion = Int32.Parse(Me.cmbNroLiquidacion.SelectedValue.ToString())
         End If

         Dim PeriodoLiquidacion As Integer = Int32.Parse(Me.cmbPeriodoLiquidacion.SelectedValue.ToString())
         Dim banco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Dim idTipoRecibo As Integer?

         If Me.chbTipoDeRecibo.Checked Then
            idTipoRecibo = Int32.Parse(Me.cmbTipoRecibo.SelectedValue.ToString())
         End If

         For Each dr As DataRow In dtPersonal.Rows

            ' drCl = TabImpreRecibos.NewRow
            idLegajo = Integer.Parse(dr("idLegajo").ToString())

            'TablaDetalle = oSueldos.GetInformeControl(idLegajo.ToString)
            TablaDetalle = oSueldos.GetDetalleRecibo(idLegajo, nroLiquidacion, idTipoRecibo, PeriodoLiquidacion)
            If TablaDetalle.Rows.Count = 0 Then
               Continue For
            End If


            RegCabecera = DsSueldos.ReciboSueldoCabecera.NewReciboSueldoCabeceraRow


            TotalHaberes = 0
            TotalDescuentos = 0
            TotalAportesPatronales = 0
            Dim sueldoscierreliqdatos As Entidades.SueldosCierreLiqDatos = New Entidades.SueldosCierreLiqDatos()
            Dim ocierreliqdatos As Reglas.SueldosLiquidacion = New Reglas.SueldosLiquidacion()

            sueldoscierreliqdatos = ocierreliqdatos.GetUnaLiqDatos(idLegajo, idTipoRecibo, PeriodoLiquidacion, nroLiquidacion)

            Dim MesPeriodo As Integer
            Dim AnoPeriodo As Integer
            Dim AnoIngreso As Integer
            Dim MesIngreso As Integer
            Dim Antiguedad As Integer
            Dim Periodo As String = PeriodoLiquidacion.ToString()

            MesPeriodo = Integer.Parse(Strings.Right(Periodo, 2))
            AnoPeriodo = Integer.Parse(Strings.Left(Periodo, 4))

            'calcular la antiguedad del empleado
            AnoIngreso = Year(dr.Field(Of DateTime?)("fechaingreso").IfNull()) 'de no funcionar, mover la with
            MesIngreso = Month(dr.Field(Of DateTime?)("fechaingreso").IfNull())

            Antiguedad = AnoPeriodo - AnoIngreso
            If MesPeriodo < MesIngreso And Antiguedad > 0 Then
               Antiguedad = Antiguedad - 1
            End If

            With RegCabecera

               .EmpresaDomicilio = Publicos.SueldosDomicilioEmpresa

               .EmpresaCUIT = Reglas.Publicos.CuitEmpresa
               .EmpresaNombre = Reglas.Publicos.NombreEmpresaImpresion
               '.Lugar_de_Pago = Publicos.SueldosLugarDePago
               .Lugar_de_Pago = sueldoscierreliqdatos.LugarPago
               '.FechaPago = Publicos.SueldosFechaDePago
               .FechaPago = sueldoscierreliqdatos.FechaPago
               .CategoriaNombre = dr.Item("NombreCategoria").ToString
               .NombrePersonal = dr.Item("NombrePersonal").ToString()
               .PeriodoLiquidacion = Me.cmbPeriodoLiquidacion.Text
               .BancoDePago = sueldoscierreliqdatos.NombreBanco.ToString()
               .BancoClaseCta = sueldoscierreliqdatos.NombreCuentaBancariaClase.ToString()
               .NumeroCta = sueldoscierreliqdatos.NumeroCuentaBancaria.ToString()
               .CBU = sueldoscierreliqdatos.CBU.ToString()
               '.BancoDePago = Publicos.SueldosBancodeDeposito
               .Legajo = sueldoscierreliqdatos.idLegajo
               .SueldoBasico = sueldoscierreliqdatos.SueldoBasico
               .TotalDescuentos = 0
               .TotalHaberes = 0
               .TotalNeto = 0
               .TotalAportesPatronales = 0
               .CUIL = dr.Item("Cuil").ToString()
               .FechaIngreso = Date.Parse(dr.Item("FechaIngreso").ToString()) '.Substring(1, 10).
               .FechaNacimiento = Date.Parse(dr.Item("FechaNacimiento").ToString())
               .NombreNacionalidad = dr.Item("NombreNacionalidad").ToString()
               '-.PE-32033.-
               .Antiguedad = Antiguedad.ToString()
            End With


            For Each LinDeta As DataRow In TablaDetalle.Rows

               RegDetalle = DsSueldos.ReciboSueldoDetalle.NewReciboSueldoDetalleRow

               With RegDetalle
                  .idLegajo = Integer.Parse(LinDeta.Item("idLegajo").ToString())
                  .idConcepto = LinDeta.Item("idConcepto").ToString


                  Select Case Integer.Parse(LinDeta.Item("idTipoConcepto").ToString)
                     Case 1, 4, 6, 7, 8
                        .ImporteHaberes = LinDeta.Item("importe").ToString
                        TotalHaberes += Decimal.Parse(LinDeta.Item("importe").ToString)
                     Case 3, 10
                        .ImporteAportesPatronales = LinDeta.Item("importe").ToString
                        TotalAportesPatronales += Decimal.Parse(LinDeta.Item("importe").ToString)
                     Case Else
                        .ImporteDescuentos = LinDeta.Item("importe").ToString
                        TotalDescuentos += Decimal.Parse(LinDeta.Item("importe").ToString)
                  End Select

                  .NombreConcepto = LinDeta.Item("NombreConcepto").ToString
                  .Valor = Decimal.Parse(LinDeta.Item("valor").ToString())
                  .CodigoConcepto = LinDeta.Item("CodigoConcepto").ToString()

               End With

               DsSueldos.ReciboSueldoDetalle.Rows.Add(RegDetalle)
            Next

            RegCabecera.TotalDescuentos = TotalDescuentos
            RegCabecera.TotalHaberes = TotalHaberes
            RegCabecera.TotalAportesPatronales = TotalAportesPatronales
            Total = TotalHaberes - TotalDescuentos - TotalAportesPatronales

            RegCabecera.TotalNeto = Total
            RegCabecera.Importe_En_Letras = Numeros_A_Letras.EnLetras(Total.ToString)

            DsSueldos.ReciboSueldoCabecera.Rows.Add(RegCabecera)

         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class