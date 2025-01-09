Public Class ConsultarCAE

   Private _tiposComprobantes As List(Of Entidades.TipoComprobante)

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._tiposComprobantes = New Reglas.TiposComprobantes().GetElectronicos("NO")

      For Each col As DataGridViewColumn In Me.dgvComprobantes.Columns
         If col.Name = "colTipoComprobante" Then
            DirectCast(col, Windows.Forms.DataGridViewComboBoxColumn).DataSource = Me._tiposComprobantes
            DirectCast(col, Windows.Forms.DataGridViewComboBoxColumn).DisplayMember = Entidades.TipoComprobante.Columnas.Descripcion.ToString()
            DirectCast(col, Windows.Forms.DataGridViewComboBoxColumn).ValueMember = Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString()
         End If
      Next

   End Sub

   Private Sub tsbVerificarCAEs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbVerificarCAEs.Click
      Try
         Dim reg As Reglas.AFIPFE = New Reglas.AFIPFE()
         Dim cae As String
         Dim nroComprobante As Long
         Dim cuitEmisor As Long
         Dim fechaComprobante As DateTime
         Dim importeTotal As Decimal
         Dim puntoVenta As Integer
         Dim idTipoComprobante As String
         Dim letra As String
         For Each dr As DataGridViewRow In Me.dgvComprobantes.Rows
            cae = dr.Cells("colCAE").Value.ToString()
            nroComprobante = Long.Parse(dr.Cells("colNroComprobante").Value.ToString())
            cuitEmisor = Long.Parse(dr.Cells("colCuitEmisor").Value.ToString())
            fechaComprobante = DateTime.Parse(dr.Cells("colFechaComprobante").Value.ToString())
            importeTotal = Decimal.Parse(dr.Cells("colImporteTotal").Value.ToString())
            puntoVenta = Int32.Parse(dr.Cells("colPuntoVenta").Value.ToString())
            idTipoComprobante = dr.Cells("colTipoComprobante").Value.ToString()
            letra = dr.Cells("colLetra").Value.ToString()

            'If reg.ElCAEEsValido(cae, _
            '                     nroComprobante, _
            '                     cuitEmisor, _
            '                     fechaComprobante, _
            '                     importeTotal, _
            '                     puntoVenta, _
            '                     idTipoComprobante, _
            '                     letra) Then
            '   dr.Cells("colVerificar").Value = "OK"
            'Else
            '   dr.Cells("colVerificar").Value = "ERROR"
            'End If
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

End Class