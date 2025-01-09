Option Explicit On
Option Strict On
Imports Eniac.Entidades
Public Class LibrodeIvaVentas

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.dtpPeriodoFiscal.Value = Today.PrimerDiaMes()

      Me._publicos.CargaComboEmpleados(Me.cmbVendedores, Entidades.Publicos.TiposEmpleados.VENDEDOR)

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         Dim PeriodoFiscal As Integer = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))

         Dim IdVen As Integer = 0

         Dim nombreVen As String = String.Empty

         Dim Filtros As String
         Dim NumeroDeHoja As Integer = 1

         Me.Cursor = Cursors.WaitCursor

         Filtros = "Filtros: Periodo: " & Me.dtpPeriodoFiscal.Value.ToString("MMMMM") & " " & Me.dtpPeriodoFiscal.Value.ToString("yyyy")

         If Me.chkConVendedor.Checked And Me.cmbVendedores.SelectedIndex <> -1 Then
            IdVen = DirectCast(Me.cmbVendedores.SelectedItem, Entidades.Empleado).IdEmpleado
            nombreVen = Me.cmbVendedores.Text
            Filtros = Filtros & " // Vendedor: " & IdVen & " - " & nombreVen
         End If


         If chkVersionFinal.Checked Then

            If Not String.IsNullOrEmpty(txtNumeroInicialHoja.Text.ToString) Then
               NumeroDeHoja = Integer.Parse(txtNumeroInicialHoja.Text)
            End If

            Filtros = "Periodo: " & Me.dtpPeriodoFiscal.Value.ToString("MMMMM") & " " & Me.dtpPeriodoFiscal.Value.ToString("yyyy")

         End If

         If NumeroDeHoja <= 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: Numero de Hoja Inicial es INVALIDO !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpPeriodoFiscal.Focus()
            Exit Sub
         End If

         Dim Orden As String
         If optPorFecha.Checked Then
            Orden = "FECHA"
         ElseIf optPorProvincia.Checked Then
            Orden = "PROVINCIA"
         Else
            Orden = "PROVINCIAIMPUESTO"
         End If

         Dim dt As DataTable = New DataTable()
         Dim dt1 As DataTable = New DataTable()
         Dim dtFilasUnificadas As DataTable = New DataTable()

         dt = oVentas.GetLibroDeIVA(actual.Sucursal.IdEmpresa, PeriodoFiscal, Orden, IdVen)

         dt.Columns.Add("Percepciones", Type.GetType("System.Decimal"))
         dt.Columns.Add("NetoNoGravado", Type.GetType("System.Decimal"))
         dt.Columns.Add("Iva1050", Type.GetType("System.Decimal"))
         dt.Columns.Add("Iva2100", Type.GetType("System.Decimal"))
         dt.Columns.Add("Iva2700", Type.GetType("System.Decimal"))
         dt.Columns.Add("ImpInt", Type.GetType("System.Decimal"))

         dt1 = dt.Clone()

         Dim tipoImpuesto As Entidades.TipoImpuesto = New Entidades.TipoImpuesto()

         For Each dr As DataRow In dt.Rows

            If Not String.IsNullOrEmpty(dr("IdTipoImpuesto").ToString()) Then
               tipoImpuesto = New Reglas.TiposImpuestos().GetxTipo(dr("IdTipoImpuesto").ToString())

               If tipoImpuesto.Tipo = "PERCEPCION" Then

                  dr("Percepciones") = Decimal.Parse(dr("Importe").ToString())
                  dr("Total") = Decimal.Parse(dr("Importe").ToString())    'No lo esta grabando el sistema
                  dr("Neto") = 0          'Si lo muestra lo suma al total
                  dr("Importe") = 0

                  If Not String.IsNullOrWhiteSpace(dr("IdProvincia").ToString()) Then
                     dr("IdTipoImpuesto") = dr("IdTipoImpuesto").ToString() + " " + dr("IdProvinciaImpuesto").ToString()
                  End If

               Else
                  dr("Percepciones") = 0
               End If

               If tipoImpuesto.Tipo = "INTERNO" Then
                  dr("ImpInt") = Decimal.Parse(dr("Importe").ToString())
                  dr("Total") = Decimal.Parse(dr("Importe").ToString())    'No lo esta grabando el sistema
                  dr("Neto") = 0          'Si lo muestra lo suma al total
                  dr("Importe") = 0
               Else
                  dr("ImpInt") = 0
               End If

            End If

            dr("NetoNoGravado") = 0
            dr("Iva1050") = 0
            dr("Iva2100") = 0
            dr("Iva2700") = 0

            If dr("Alicuota").ToString() <> "" Then

               If Decimal.Parse(dr("Alicuota").ToString()) = 0 Then
                  dr("NetoNoGravado") = dr("ImporteBruto")
                  dr("Neto") = 0
               Else

                  'If Decimal.Parse(dr("Alicuota").ToString()) = 2.5 Then
                  '   Stop
                  'End If

                  If tipoImpuesto.Tipo = "IVA" And Decimal.Parse(dr("Alicuota").ToString()) <> 0 And
                     dr.Table.Columns.Contains("Iva" + dr("Alicuota").ToString().Replace(".", "").ToString()) Then
                     dr("Iva" + dr("Alicuota").ToString().Replace(".", "").ToString()) = dr("Importe").ToString()
                  End If

               End If

            Else
               If Me.chbFormatoHorizontal.Checked Then
                  dr("Neto") = 0
                  dr("Total") = 0
               End If
            End If

         Next

         If dt.Rows.Count = 0 Then
            Me.Cursor = Cursors.Default
            If MessageBox.Show("NO hay registros que cumplan con la seleccion!! Desea imprimir de todas maneras?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Cancel Then
               Me.dtpPeriodoFiscal.Focus()
               Exit Sub
            Else
               Dim drCl As DataRow
               drCl = dt.NewRow()

               drCl("Neto") = 0
               drCl("NetoNoGravado") = 0
               drCl("Iva2100") = 0
               drCl("Iva2700") = 0
               drCl("Iva1050") = 0
               drCl("Percepciones") = 0
               drCl("Importe") = 0
               drCl("Total") = 0
               drCl("ImpInt") = 0
               drCl("NombreCliente") = ""
               drCl("CodigoCliente") = 0



               dt.Rows.Add(drCl)
            End If
         End If


         If Me.chbFormatoHorizontal.Checked Then
            'Unifico los registros de las mismas facturas

            Dim fecha As Date
            Dim comprobante As String
            Dim letra As String
            Dim emisor As Short
            Dim numero As Long = 0
            Dim i As Integer = 0
            Dim entro As Boolean = False
            Dim dr2 As DataRow
            Dim ImporteBruto, Neto, Importe, Total, IVA1050, IVA2100, IVA2700, Percepciones, NetoNoGravado, ImpInt As Decimal

            dtFilasUnificadas = oVentas.GetLibroDeIVAUnificado(actual.Sucursal.IdEmpresa, PeriodoFiscal, Orden, IdVen)

            If dtFilasUnificadas.Rows.Count <> 0 Then

               For Each dr3 As DataRow In dtFilasUnificadas.Rows

                  fecha = Date.Parse(dr3("Fecha").ToString())
                  comprobante = dr3("IdTipoComprobante").ToString()
                  letra = dr3("Letra").ToString()
                  emisor = Short.Parse(dr3("CentroEmisor").ToString())
                  numero = Long.Parse(dr3("NumeroComprobante").ToString())

                  For Each dr1 As DataRow In dt.Rows

                     If fecha = Date.Parse(dr1("Fecha").ToString()) And _
                        comprobante = dr1("IdTipoComprobante").ToString() And _
                        letra = dr1("Letra").ToString() And _
                        emisor = Short.Parse(dr1("CentroEmisor").ToString()) And _
                        numero = Long.Parse(dr1("NumeroComprobante").ToString()) Then

                        If Not String.IsNullOrEmpty(dr1("ImporteBruto").ToString()) Then
                           ImporteBruto += Decimal.Parse(dr1("ImporteBruto").ToString())
                           NetoNoGravado += Decimal.Parse(dr1("NetoNoGravado").ToString())
                           Neto += Decimal.Parse(dr1("Neto").ToString())
                           Importe += Decimal.Parse(dr1("Importe").ToString())
                           Total += Decimal.Parse(dr1("Total").ToString())
                           IVA1050 += Decimal.Parse(dr1("IVA1050").ToString())
                           IVA2100 += Decimal.Parse(dr1("IVA2100").ToString())
                           IVA2700 += Decimal.Parse(dr1("IVA2700").ToString())
                           Percepciones += Decimal.Parse(dr1("Percepciones").ToString())
                           ImpInt += Decimal.Parse(dr1("ImpInt").ToString())
                        End If


                     End If
                  Next

                  dr2 = dt1.NewRow

                  dr2("NombreProvincia") = dr3("NombreProvincia").ToString()
                  dr2("Fecha") = Date.Parse(dr3("Fecha").ToString())
                  dr2("IdTipoComprobante") = dr3("IdTipoComprobante").ToString()
                  dr2("Letra") = dr3("Letra").ToString()
                  dr2("CentroEmisor") = Short.Parse(dr3("CentroEmisor").ToString())
                  dr2("NumeroComprobante") = Long.Parse(dr3("NumeroComprobante").ToString())
                  dr2("DescripcionAbrev") = dr3("DescripcionAbrev").ToString()
                  dr2("NombreCliente") = dr3("NombreCliente").ToString()
                  dr2("NombreCategoriaFiscal") = dr3("NombreCategoriaFiscal").ToString()
                  dr2("CUIT") = dr3("CUIT").ToString()
                  dr2("IdEstadoComprobante") = dr3("IdEstadoComprobante")
                  dr2("ImporteBruto") = ImporteBruto
                  dr2("NetoNoGravado") = NetoNoGravado
                  dr2("Neto") = Neto
                  dr2("Importe") = Importe
                  dr2("Total") = Total
                  dr2("IVA1050") = IVA1050
                  dr2("IVA2100") = IVA2100
                  dr2("IVA2700") = IVA2700
                  dr2("Percepciones") = Percepciones
                  dr2("ImpInt") = ImpInt

                  dt1.Rows.Add(dr2)
                  dt1.AcceptChanges()

                  ImporteBruto = 0
                  Neto = 0
                  Importe = 0
                  Total = 0
                  IVA1050 = 0
                  IVA2100 = 0
                  IVA2700 = 0
                  Percepciones = 0
                  NetoNoGravado = 0

               Next
            Else
               Dim drCl As DataRow
               drCl = dt1.NewRow()

               drCl("Neto") = 0
               drCl("NetoNoGravado") = 0
               drCl("Iva2100") = 0
               drCl("Iva2700") = 0
               drCl("Iva1050") = 0
               drCl("Percepciones") = 0
               drCl("Importe") = 0
               drCl("Total") = 0
               drCl("ImpInt") = 0
               drCl("NombreCliente") = ""
               drCl("CodigoCliente") = 0



               dt1.Rows.Add(drCl)
            End If
         End If


         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PaginaInicial", NumeroDeHoja.ToString()))

         'Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.LibrodeIvaVentas.rdlc", "SistemaDataSet_Ventas", dt, parm, True)
         Dim frmImprime As VisorReportes
         Dim strReporte As String = String.Empty

         If Me.optPorFecha.Checked Then
            If Me.chbFormatoHorizontal.Checked Then
               strReporte = "LibrodeIvaVentas_Horizontal.rdlc"
               'frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_LibroIvaVentas", dt1, parm, True)
               frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_LibroIvaVentas", dt1, parm, True, 1) '# 1 = Cantidad Copias
            Else
               strReporte = "LibrodeIvaVentas.rdlc"
               frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_Ventas", dt, parm, True, 1) '# 1 = Cantidad Copias
            End If
         Else
            strReporte = "LibrodeIvaVentas_PorProvincias.rdlc"
            frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_Ventas", dt, parm, True, 1) '# 1 = Cantidad Copias
         End If

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         If chkVersionFinal.Checked Then
            Me.Cursor = Cursors.Default
            If MessageBox.Show("El Libro Mensual de I.V.A. fue impreso correctamente ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Publicos.NroHojaLibroIvaVentas = NumeroDeHoja + frmImprime.rvReporte.LocalReport.GetTotalPages()
               Me.Close()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkConVendedor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConVendedor.CheckedChanged
      Me.cmbVendedores.Enabled = Me.chkConVendedor.Checked
   End Sub

   Private Sub chkVersionFinal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVersionFinal.CheckedChanged

      Try

         If chkVersionFinal.Checked Then

            Me.txtNumeroInicialHoja.Text = Publicos.NroHojaLibroIvaVentas.ToString()

            'Quito el check
            Me.chkConVendedor.Checked = False

         Else

            Me.txtNumeroInicialHoja.Text = ""

         End If

         Me.txtNumeroInicialHoja.Enabled = Me.chkVersionFinal.Checked
         Me.txtNumeroInicialHoja.IsRequired = Me.chkVersionFinal.Checked

         Me.chkConVendedor.Enabled = Not chkVersionFinal.Checked

      Catch ex As Exception

         Me.Cursor = Cursors.Default
         chkVersionFinal.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub optPorFecha_CheckedChanged(sender As Object, e As EventArgs) Handles optPorFecha.CheckedChanged
      Me.chbFormatoHorizontal.Visible = True
   End Sub

   Private Sub optPorProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles optPorProvincia.CheckedChanged, optPorProvinciaImpuesto.CheckedChanged
      Me.chbFormatoHorizontal.Checked = False
      Me.chbFormatoHorizontal.Visible = False
   End Sub


#End Region

#Region "Metodos"


   'Public Function GetAlicuotas(ByVal idSucursal As Integer, _
   '                          ByVal PeriodoFiscal As Integer, _
   '                          ByVal Orden As String, _
   '                          ByVal TipoDocVendedor As String, _
   '                          ByVal NroDocVendedor As String) As DataTable

   '   Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

   '   Return oVentas.GetAlicuotas(idSucursal, PeriodoFiscal, Orden, TipoDocVendedor, NroDocVendedor)

   'End Function

#End Region

   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes()
   End Sub
End Class