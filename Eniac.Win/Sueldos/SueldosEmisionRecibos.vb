Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Text

Public Class SueldosEmisionRecibos

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
         Me._publicos.CargaComboSueldosTiposRecibos(Me.cmbTipoRecibo)

         Dim periodo As Integer
         If cmbPeriodoLiquidacion.Items.Count <> 0 Then
            periodo = Integer.Parse(cmbPeriodoLiquidacion.SelectedValue.ToString())
         Else
            periodo = 0
         End If

         Me._publicos.CargaComboSueldosNroLiquidacion(Me.cmbNroLiquidacion, _
                                                    Integer.Parse(Me.cmbTipoRecibo.SelectedValue.ToString()), _
                                                    periodo)

         Me.CargarLugarDePagoYFecha()

         Me.tssRegistros.Text = ""

         Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

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

      Try
         Try

            If Me.cmbPeriodoLiquidacion.SelectedIndex = -1 Then
               MessageBox.Show("No seleccionó el Periodo de Liquidación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.cmbPeriodoLiquidacion.Focus()
               Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            If Me.cmbNroLiquidacion.Items.Count = 0 Then
               Me.Cursor = Cursors.Default
               MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            Me.CargaGrillaDetalle()

            If DsSueldos.ReciboSueldoCabecera.Rows.Count = 0 Then
               Me.Cursor = Cursors.Default
               MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         Catch ex As Exception
            'Me.tssRegistros.Text = "0 Registros"
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            '     Me.Cursor = Cursors.Default
         End Try


         ' If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         If Filtros.Length > 0 Then Filtros = Filtros & " - "

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         Dim frmImprime As VisorReportes

         Dim dt1 As DataTable
         Dim dt2 As DataTable

         dt1 = DirectCast(DsSueldos.ReciboSueldoCabecera, DataSetSueldos.ReciboSueldoCabeceraDataTable).Copy()
         dt1.TableName = "DataSetSueldos_ReciboSueldoCabecera"

         dt2 = DirectCast(DsSueldos.ReciboSueldoDetalle, DataSetSueldos.ReciboSueldoDetalleDataTable).Copy()
         dt2.TableName = "DataSetSueldos_ReciboSueldoDetalle"

         Dim ds As DataSet = New DataSet()

         ds.Tables.Add(dt1)
         ds.Tables.Add(dt2)

         frmImprime = New VisorReportes("Eniac.Win.SueldosEmisionRecibos.rdlc", dt1, dt2, True, 1) '# 1 = Cantidad Copias    ' EMBEBIDO

         frmImprime.Text = Me.Text
         frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
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

   Private Sub CargarDatosPersonal(ByVal dr As DataGridViewRow)

      Me.bscNombrePersonal.Text = dr.Cells("NombrePersonal").Value.ToString()
      Me.bscNroLegajo.Text = dr.Cells("idLegajo").Value.ToString()
      '  Me.lblCategoriaSocio.Text = dr.Cells("NombreCategoria").Value.ToString
      '  Me.lblCategoriaSocio.Tag = dr.Cells("IdCategoria").Value.ToString
      '  Me.lblEstadoCivil.Text = dr.Cells("NombreEstadoCivil").Value.ToString
      '  Me.bscNombrePersonal.Enabled = False
      '    Me.bscNroLegajo.Enabled = False

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

   Private Sub chbSocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSocio.CheckedChanged

      '  Me.cmbTipoDoc.Enabled = Me.chbSocio.Checked
      Me.bscNroLegajo.Enabled = Me.chbSocio.Checked
      Me.bscNombrePersonal.Enabled = Me.chbSocio.Checked

      If Not Me.chbSocio.Checked Then
         '       Me.cmbTipoDoc.Text = Publicos.TipoDocumentoSocio()
         Me.bscNroLegajo.Text = ""
         Me.bscNombrePersonal.Text = ""
      Else
         Me.bscNroLegajo.Focus()
      End If
   End Sub

   Private Sub cmbTipoRecibo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoRecibo.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me._publicos.CargaComboSueldosNroLiquidacion(Me.cmbNroLiquidacion, _
                                                                              Integer.Parse(Me.cmbTipoRecibo.SelectedValue.ToString()), _
                                                                              Integer.Parse(cmbPeriodoLiquidacion.SelectedValue.ToString()))

            Me.CargarLugarDePagoYFecha()

         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub cmbPeridoLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPeriodoLiquidacion.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me._publicos.CargaComboSueldosNroLiquidacion(Me.cmbNroLiquidacion, _
                                                                          Integer.Parse(Me.cmbTipoRecibo.SelectedValue.ToString()), _
                                                                          Integer.Parse(cmbPeriodoLiquidacion.SelectedValue.ToString()))

            Me.CargarLugarDePagoYFecha()

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub


   Private Sub cmbNroLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNroLiquidacion.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me.CargarLugarDePagoYFecha()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaGrillaDetalle()

      Try

         Dim oSueldos As Reglas.SueldosLiquidacion = New Reglas.SueldosLiquidacion()
         Dim oPersonal As Reglas.SueldosPersonal = New Reglas.SueldosPersonal()


         Dim dtPersonal As DataTable

         Dim TipoDocLegajo As String = ""
         Dim NroDocLegajo As Integer

         If Me.chbSocio.Checked Then

            NroDocLegajo = Integer.Parse(bscNroLegajo.Text)
            dtPersonal = oPersonal.GetFiltradoPorLegajo(NroDocLegajo, False)
         Else
            dtPersonal = oPersonal.GetFiltradoPorLegajo(0, False)
         End If


         DsSueldos = New DataSetSueldos()
         Dim RegCabecera As DataSetSueldos.ReciboSueldoCabeceraRow
         Dim RegDetalle As DataSetSueldos.ReciboSueldoDetalleRow
         Dim Orden As Integer = 0

         Dim Total As Decimal = 0
         Dim idLegajo As Integer = 0
         Dim nroLiquidacionP As Integer = 0
         Dim TablaDetalle As DataTable
         Dim TotalHaberes As Decimal
         Dim TotalDescuentos As Decimal
         Dim nroLiquidacion As Integer = Int32.Parse(Me.cmbNroLiquidacion.SelectedValue.ToString())
         Dim PeriodoLiquidacion As Integer = Int32.Parse(Me.cmbPeriodoLiquidacion.SelectedValue.ToString())
         Dim idTipoRecibo As Integer = Int32.Parse(Me.cmbTipoRecibo.SelectedValue.ToString())

         For Each dr As DataRow In dtPersonal.Rows

            idLegajo = Integer.Parse(dr("idLegajo").ToString())

            TablaDetalle = oSueldos.GetDetalleRecibo(idLegajo, nroLiquidacion, idTipoRecibo, PeriodoLiquidacion)
            If TablaDetalle.Rows.Count = 0 Then
               Continue For
            End If

            RegCabecera = DsSueldos.ReciboSueldoCabecera.NewReciboSueldoCabeceraRow

            TotalHaberes = 0
            TotalDescuentos = 0
            Dim sueldoscierreliqdatos As Entidades.SueldosCierreLiqDatos = New Entidades.SueldosCierreLiqDatos()
            Dim ocierreliqdatos As Reglas.SueldosLiquidacion = New Reglas.SueldosLiquidacion()

            sueldoscierreliqdatos = ocierreliqdatos.GetUnaLiqDatos(idLegajo, idTipoRecibo, PeriodoLiquidacion, nroLiquidacion)

            With RegCabecera
               .EmpresaDomicilio = Publicos.SueldosDomicilioEmpresa
               .EmpresaCUIT = Eniac.Win.Publicos.CuitEmpresa
               .EmpresaNombre = Eniac.Win.Publicos.NombreEmpresaImpresion
               .Lugar_de_Pago = sueldoscierreliqdatos.LugarPago
               .FechaPago = sueldoscierreliqdatos.FechaPago
               .CategoriaNombre = sueldoscierreliqdatos.SueldoCategoria.NombreCategoria
               .NombrePersonal = dr.Item("NombrePersonal").ToString()
               .PeriodoLiquidacion = Me.cmbPeriodoLiquidacion.Text
               .BancoDePago = sueldoscierreliqdatos.NombreBanco.ToString()
               .BancoClaseCta = sueldoscierreliqdatos.NombreCuentaBancariaClase.ToString()
               .NumeroCta = sueldoscierreliqdatos.NumeroCuentaBancaria.ToString()
               .CBU = sueldoscierreliqdatos.CBU.ToString()
               .Legajo = sueldoscierreliqdatos.idLegajo
               .SueldoBasico = sueldoscierreliqdatos.SueldoBasico
               .TotalDescuentos = 0
               .TotalHaberes = 0
               .TotalNeto = 0
               .CUIL = dr.Item("Cuil").ToString()
               .FechaIngreso = Date.Parse(dr.Item("FechaIngreso").ToString())

               'calcular la antiguedad del empleado
               Dim MesPeriodo As Integer
               Dim AnoPeriodo As Integer
               Dim AnoIngreso As Integer
               Dim MesIngreso As Integer

               MesPeriodo = Integer.Parse(Microsoft.VisualBasic.Right(.PeriodoLiquidacion, 2))
               AnoPeriodo = Integer.Parse(Microsoft.VisualBasic.Left(.PeriodoLiquidacion, 4))

               Dim Antig As Integer
               AnoIngreso = Year(Date.Parse(dr.Item("FechaIngreso").ToString()))
               MesIngreso = Month(Date.Parse(dr.Item("FechaIngreso").ToString()))

               Antig = AnoPeriodo - AnoIngreso
               If MesPeriodo < MesIngreso And Antig > 0 Then
                  Antig = Antig - 1
               End If
               .Antiguedad = Antig.ToString()

            End With

            For Each LinDeta As DataRow In TablaDetalle.Rows

               If Boolean.Parse(LinDeta.Item("MostrarEnRecibo").ToString()) Then

                  RegDetalle = DsSueldos.ReciboSueldoDetalle.NewReciboSueldoDetalleRow

                  With RegDetalle
                     .idLegajo = Integer.Parse(LinDeta.Item("idLegajo").ToString())
                     .idConcepto = LinDeta.Item("idConcepto").ToString
                     .CodigoConcepto = LinDeta.Item("CodigoConcepto").ToString()
                     Select Case Integer.Parse(LinDeta.Item("idTipoConcepto").ToString)
                        Case 1, 4, 6, 7, 8
                           .ImporteHaberes = LinDeta.Item("importe").ToString
                           TotalHaberes += Decimal.Parse(LinDeta.Item("importe").ToString)
                        Case Else
                           .ImporteDescuentos = LinDeta.Item("importe").ToString
                           TotalDescuentos += Decimal.Parse(LinDeta.Item("importe").ToString)
                     End Select

                     .NombreConcepto = LinDeta.Item("NombreConcepto").ToString
                     .Valor = Decimal.Parse(LinDeta.Item("valor").ToString())
                  End With

                  DsSueldos.ReciboSueldoDetalle.Rows.Add(RegDetalle)

               End If

            Next

            RegCabecera.TotalDescuentos = TotalDescuentos
            RegCabecera.TotalHaberes = TotalHaberes
            Total = TotalHaberes - TotalDescuentos

            RegCabecera.TotalNeto = Total
            RegCabecera.Importe_En_Letras = Eniac.Win.Numeros_A_Letras.EnLetras(Total.ToString)

            DsSueldos.ReciboSueldoCabecera.Rows.Add(RegCabecera)

         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarLugarDePagoYFecha()

      If cmbNroLiquidacion.Items.Count <> 0 Then
         Dim LugaryFecha As DataTable = New Reglas.SueldosLiquidacion().GetLugarDePagoyFecha(Integer.Parse(Me.cmbTipoRecibo.SelectedValue.ToString()),
                                                                                            Integer.Parse(Me.cmbPeriodoLiquidacion.SelectedValue.ToString()),
                                                                                            Integer.Parse(cmbNroLiquidacion.SelectedValue.ToString()))
         If LugaryFecha.Rows.Count <> 0 Then
            Me.txtLugarPago.Text = LugaryFecha.Rows(0).Item("LugarPago").ToString()

            Me.dtpSueldosFechaPago.Value = Date.Parse(LugaryFecha.Rows(0).Item("FechaPago").ToString())
         Else
            Me.txtLugarPago.Text = ""

            Me.dtpSueldosFechaPago.Value = Date.Today()
         End If
      Else
         Me.txtLugarPago.Text = ""

         Me.dtpSueldosFechaPago.Value = Date.Today()
      End If


   End Sub
#End Region

End Class