Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO

#End Region

Public Class eFactExportarVentas

#Region "Campos"

   Private _publicos As Publicos
   Private nombreArchivo As String
   'Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.CargarValoresIniciales()

      'Me._estaCargando = False

   End Sub

#End Region

#Region "Eventos"

   Private Sub eFactExportarVentas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportar.Click
      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         If Me.txtArchivoDestino.Text.Trim() = "" Then Exit Sub

         If My.Computer.FileSystem.FileExists(txtArchivoDestino.Text) Then
            MessageBox.Show("ATENCION: El archivo a Exportar YA Existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         'If ProductosConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ProductosConError.ToString() & " productos que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
         '   Exit Sub
         'End If

         Me.Cursor = Cursors.WaitCursor

         Me.ExportarComprobantes()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se Exportaron " & Me.dgvDetalle.RowCount.ToString() & " Comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         'Me.prbExportando.Value = 0
         Me.Close()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnBuscarDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDestino.Click
      Try
         If Me.fbdBase.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Strings.Right(Me.fbdBase.SelectedPath, 1) = "\" Then
               Me.txtArchivoDestino.Text = Me.fbdBase.SelectedPath & nombreArchivo
            Else
               Me.txtArchivoDestino.Text = Me.fbdBase.SelectedPath & "\" & nombreArchivo
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59)

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      nombreArchivo = "eFact_" & Date.Now.ToString("yyyyMMddHHmmss") & ".txt"

      Me.txtArchivoDestino.Text = Entidades.Publicos.CarpetaEniac + "eFact\Exportaciones\" & nombreArchivo

      Me.prbExportando.Value = 0

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

         Dim TotalExento As Decimal = 0
         Dim TotalNeto As Decimal = 0
         Dim TotalIVA As Decimal = 0
         Dim TotalPercepcion As Decimal = 0
         Dim decTotal As Decimal = 0


         Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

         dtDetalle = oVenta.GetComprobantesSinCAE(actual.Sucursal.Id, _
                                                  Me.dtpDesde.Value, Me.dtpHasta.Value)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("IdTipoComprobanteFiscal") = dr("IdTipoComprobanteFiscal").ToString()
            drCl("Descripcion") = dr("Descripcion").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("TipoDocCliente") = dr("TipoDocCliente").ToString()
            drCl("IdTipoDocumentoFiscal") = dr("IdTipoDocumentoFiscal").ToString()
            drCl("NroDocCliente") = dr("NroDocCliente").ToString()

            If dr("IdEstadoComprobante").ToString() <> "ANULADO" Then
               drCl("NombreCliente") = dr("NombreCliente").ToString()
            Else
               drCl("NombreCliente") = "** COMPROBANTE ANULADO **"
            End If

            drCl("ImporteExento") = Decimal.Parse(dr("ImporteExento").ToString())
            drCl("ImporteNeto") = Decimal.Parse(dr("ImporteNeto").ToString())
            drCl("IVA") = Decimal.Parse(dr("IVA").ToString())
            drCl("ImportePercepcion") = Decimal.Parse(dr("ImportePercepcion").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            dt.Rows.Add(drCl)

            TotalExento = TotalExento + Decimal.Parse(drCl("ImporteExento").ToString())
            TotalNeto = TotalNeto + Decimal.Parse(drCl("ImporteNeto").ToString())
            TotalIVA = TotalIVA + Decimal.Parse(drCl("IVA").ToString())
            TotalPercepcion = TotalPercepcion + Decimal.Parse(drCl("ImportePercepcion").ToString())
            decTotal = decTotal + Decimal.Parse(drCl("ImporteTotal").ToString())

         Next

         'txtSubtotal.Text = decSubTotal.ToString("##,##0.00")
         'txtTotalIVA.Text = TotalIVA.ToString("##,##0.00")
         'txtTotalPercepciones.Text = TotalPercepcion.ToString("##,##0.00")
         'txtTotal.Text = decTotal.ToString("##,##0.00")

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobanteFiscal", System.Type.GetType("System.String"))
         .Columns.Add("Descripcion", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("TipoDocCliente", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoDocumentoFiscal", System.Type.GetType("System.String"))
         .Columns.Add("NroDocCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("ImporteExento", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteNeto", System.Type.GetType("System.Decimal"))
         .Columns.Add("IVA", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImportePercepcion", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function


   Private Sub ExportarComprobantes()

      Dim ioArchivoGraba As System.IO.StreamWriter = Nothing

      Try

         ioArchivoGraba = My.Computer.FileSystem.OpenTextFileWriter(Me.txtArchivoDestino.Text, False, System.Text.Encoding.ASCII)

         Dim Registro As String = ""
         Dim Total12 As Decimal = 0
         Dim Total13 As Decimal = 0
         Dim Total14 As Decimal = 0
         Dim Total15 As Decimal = 0
         Dim Total16 As Decimal = 0
         Dim Total17 As Decimal = 0
         Dim Importe As Decimal = 0


         'VarConsulta.Add(CompVtas.VT31_FECEMI_FD)  '0
         'VarConsulta.Add(CompVtas.VT11_TIPCOM_FD)  '1
         'VarConsulta.Add(CompVtas.VT12_PUNVEN_FD)  '2
         'VarConsulta.Add(CompVtas.VT13_NUMCOM_FD)  '3
         'VarConsulta.Add(CompVtas.VT21_TIPDOC_FD)  '4
         'VarConsulta.Add(CompVtas.VT22_NUMDOC_FD)  '5
         'VarConsulta.Add(Personas.PER21_APELLIDO)  '6
         'VarConsulta.Add(Personas.PER22_NOMBRE)    '7
         'VarConsulta.Add(CompVtas.VT92_TOTVT1_FD)  '8
         'VarConsulta.Add(CompVtas.VT92_EXENTO_FD)  '9
         'VarConsulta.Add(CompVtas.VT92_PERCEP_FD)  '10
         'VarConsulta.Add(CompVtas.VT92_NETGRA_FD)  '11
         'VarConsulta.Add(CompVtas.VT92_IVA_FD)     '12
         'VarConsulta.Add(Personas.PER91_TIPCON)    '13
         'VarConsulta.Add(CompVtas.VT96_CAE_FD)     '14
         'VarConsulta.Add(Personas.PER91_TIPCON)    '15
         'VarConsulta.Add(CompVtas.VT96_FVCAE_FD)   '16


         Dim i As Integer = 0

         Me.prbExportando.Maximum = Me.dgvDetalle.Rows.Count
         Me.prbExportando.Minimum = 0
         Me.prbExportando.Value = 0

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

            i += 1
            prbExportando.Value = i

            'TIPO 1
            'Campo 1: Tipo de Registro Se deberá completar con la constante "1".
            Registro = "1"

            'Campo 2: Fecha del comprobante (AAAAMMDD).   ORD
            Registro = Registro & Date.Parse(dr.Cells("Fecha").Value.ToString()).ToString("yyyyMMdd")

            'Campo 3: Tipo de Comprobante.                ORD 
            Registro = Registro & dr.Cells("IdTipoComprobanteFiscal").Value.ToString()   '2 digitos "00"

            'Campo 4: Controlador Fiscal. blanco
            Registro = Registro & Space(1)

            'Campo 5: Punto de Venta 4 dígitos            ORD
            Registro = Registro & Integer.Parse(dr.Cells("CentroEmisor").Value.ToString()).ToString("0000")

            'Campo 6: Número de Comprobante  8 dígitos    ORD
            Registro = Registro & Long.Parse(dr.Cells("NumeroComprobante").Value.ToString()).ToString("00000000")

            'Campo 7: Número de Comprobante Registrado. = AL ANTERIOR
            Registro = Registro & Long.Parse(dr.Cells("NumeroComprobante").Value.ToString()).ToString("00000000")

            'Campo 8: Cantidad de Hojas 001
            Registro = Registro & "001"


            'Campo 9: Código de documento identificatorio del comprador.
            Registro = Registro & dr.Cells("IdTipoDocumentoFiscal").Value.ToString()   '2 digitos "00"

            ' Campo 10: Número de identificación del comprador 11 digitos.
            Registro = Registro & Long.Parse(dr.Cells("NroDocCliente").Value.ToString()).ToString("00000000000")


            'Campo 11: Apellido y nombres o denominación del comprador  30 caracteres.

            If dr.Cells("NombreCliente").Value.ToString.Length > 30 Then
               Registro = Registro & dr.Cells("NombreCliente").Value.ToString.Substring(0, 30)
            Else
               Registro = Registro & Strings.Left(dr.Cells("NombreCliente").Value.ToString() + Space(30), 30)
            End If


            'Campo 12: Importe total de la operación. "000000000000000"
            Importe = dr.Cells("ImporteTotal").Value * 100
            Registro = Registro & Importe.ToString("000000000000000")
            Total12 = Total12 + Importe

            'Campo 13: Importe total de conceptos que no integran el precio neto gravado.
            Importe = (dr.Cells("ImporteExento").Value + dr.Cells("ImportePercepcion").Value) * 100
            Registro = Registro & Importe.ToString("000000000000000")
            Total13 = Total13 + Importe

            'Campo 14: Importe Neto Gravado.
            Importe = dr.Cells("ImporteNeto").Value * 100
            Registro = Registro & Importe.ToString("000000000000000")
            Total14 = Total14 + Importe

            'Campo 15: Impuesto liquidado.
            Importe = dr.Cells("IVA").Value * 100
            Registro = Registro & Importe.ToString("000000000000000")
            Total15 = Total15 + Importe

            'Campo 16: Impuesto liquidado a RNI o percepción a no categorizados.
            Importe = dr.Cells("ImportePercepcion").Value * 100
            Registro = Registro & Importe.ToString("000000000000000")
            Total16 = Total16 + Importe

            'Campo 17: Importe de operaciones exentas.
            Importe = dr.Cells("ImporteExento").Value * 100
            Registro = Registro & Importe.ToString("000000000000000")
            Total17 = Total17 + Importe

            'Campo 18: Importe de percepciones o pagos a cuenta de impuestos nacionales.
            Registro = Registro & "000000000000000"

            'Campo 19: Importe de percepción de ingresos brutos.
            Registro = Registro & "000000000000000"

            'Campo 20: Importe de percepciones por impuestos municipales.
            Registro = Registro & "000000000000000"

            'Campo 21: Importe de impuestos internos.
            Registro = Registro & "000000000000000"

            'Campo 22: Fecha desde del servicio facturado
            Registro = Registro & Date.Parse(dr.Cells("Fecha").Value.ToString()).ToString("yyyyMMdd") ' & "01"

            'Campo 23: Fecha hasta del servicio facturado
            Registro = Registro & Date.Parse(dr.Cells("Fecha").Value.ToString()).ToString("yyyyMMdd") ' & "28"

            'Campo 24: Fecha vencimiento del servicio facturado
            Registro = Registro & Date.Parse(dr.Cells("Fecha").Value.ToString()).ToString("yyyyMMdd") ' & "28"

            'Campo 25: Relleno
            Registro = Registro & "000000"

            'Campo 26: cantidad de alícuotas de IVA
            Registro = Registro & "1"

            'Campo 27: Código de operación "N"  1 digito
            Registro = Registro & "N"

            'Campo 28: CAI. INGRESARLO 14 digitos
            Registro = Registro & "00000000000000"

            'Campo 29: Fecha de vencimiento DEL COMPROBANTE IMPRESO.
            Registro = Registro & "00000000"

            'Campo 30: Fecha anulación del comprobante.
            If dr.Cells("ImporteNeto").Value = 0 And dr.Cells("IVA").Value = 0 And dr.Cells("ImporteTotal").Value = 0 Then
               'Registro = Registro & Format(DatosVent.Tables(0).Rows(k).Item(0), "yyyyMMdd")
               ' El renglon anterior lo anulé el 03/06/2009 porque el afip daba error y perdía el campo en cero
               Registro = Registro & "00000000"
            Else
               Registro = Registro & "00000000"
            End If

            ioArchivoGraba.WriteLine(Registro)

            'CuentaComp = CuentaComp + 1

         Next


         'SECCION 2: DESCRIPCION DE REGISTRO TIPO 2 - CABECERA
         Dim Registro2 As String

         ' Campo 1: Tipo de Registro Se deberá completar con la constante "2".
         Registro2 = "2"

         'Campo 2: Período() Se deberá completar con el período fiscal que se registra (AAAAMM).

         'QUE PASA SI TRANSMITE COMPROBANTES DE DISTINTOS MESES?
         Registro2 = Registro2 & Date.Parse(Me.dgvDetalle.Rows(0).Cells("Fecha").Value.ToString()).ToString("yyyyMMdd")

         'Campo 3: Relleno  13 Se completará con blancos.
         Registro2 = Registro2 & Space(13)

         'Campo 4: Cantidad de Registros de tipo 1
         Registro2 = Registro2 & Me.dgvDetalle.Rows.Count.ToString("00000000")

         'Campo 5: Relleno 17.
         Registro2 = Registro2 & Space(17)

         'Campo 6: CUIT del informanteSe deberá completar con la CUIT del emisor de los comprobantes.
         Registro2 = Registro2 & Publicos.CuitEmpresa

         'Campo(7) Relleno 22 Se completará con blancos.
         Registro2 = Registro2 & Space(22)

         'Campo 8: Importe total de la operación SUMATORIA CAMPO 12
         Registro2 = Registro2 & Total12.ToString("000000000000000")

         'Campo 9: Importe total de conceptos que no integran el precio neto gravado SUMATORIA CAMPO 13.
         Registro2 = Registro2 & Total13.ToString("000000000000000")

         'Campo 10: Importe Neto Gravado SUMATORIA CAMPO 14
         Registro2 = Registro2 & Total14.ToString("000000000000000")

         'Campo 11: Impuesto liquidado SUMATORIA CAMPO 15.
         Registro2 = Registro2 & Total15.ToString("000000000000000")

         'Campo 12: Impuesto liquidado a RNI o percepción a no categorizados.SUMATORIA CAMPO 16
         Registro2 = Registro2 & Total16.ToString("000000000000000")

         'Campo 13: Importe de operaciones exentas SUMATORIA CAMPO 17.
         Registro2 = Registro2 & Total17.ToString("000000000000000")

         'Campo 14: Importe de percepciones o pagos a cuenta de impuestos nacionales SUMATORIA CAMPO 18.
         Registro2 = Registro2 & "000000000000000"

         'Campo 15: Importe de percepción de ingresos brutos SUMATORIA CAMPO 19.
         Registro2 = Registro2 & "000000000000000"

         'Campo 16: Importe de percepción de impuestos municipales SUMATORIA CAMPO 20
         Registro2 = Registro2 & "000000000000000"

         'Campo 17: Importe de impuestos internos SUMATORIA CAMPO 21
         Registro2 = Registro2 & "000000000000000"

         ' Campo 18: Relleno 62
         Registro2 = Registro2 & Space(62)

         ioArchivoGraba.WriteLine(Registro2)

      Catch ex As Exception
         Throw New Exception(ex.Message)

      Finally
         ioArchivoGraba.Close()

      End Try

   End Sub

#End Region

End Class