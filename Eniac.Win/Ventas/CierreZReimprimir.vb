Public Class CierreZReimprimir

#Region "Campos"

   Dim oImpresora As Entidades.Impresora

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         oImpresora = New Reglas.Impresoras().GetPorSucursalPC(actual.Sucursal.Id, My.Computer.Name, True)

         If oImpresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.BATCH Then
            MessageBox.Show("ATENCION: la configuracion de la impresora fisacal NO permite emitir Cierre Z Anteriores.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub txtNumeroDesde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroDesde.LostFocus
      If Me.txtNumeroHasta.Text = "" OrElse Long.Parse(Me.txtNumeroDesde.Text) > Long.Parse(Me.txtNumeroHasta.Text) Then
         Me.txtNumeroHasta.Text = Me.txtNumeroDesde.Text
      End If
   End Sub

   Private Sub btnProceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceder.Click

      Try

         If Me.txtNumeroDesde.Text = "" Or Me.txtNumeroDesde.Text = "0" Then
            MessageBox.Show("ATENCION: Debe cargar el Numero Desde.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroDesde.Focus()
            Exit Sub
         End If

         If Long.Parse(Me.txtNumeroDesde.Text) > Long.Parse(Me.txtNumeroHasta.Text) Then
            MessageBox.Show("ATENCION: El Numero Desde es nayor que el Hasta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumeroDesde.Focus()
            Exit Sub
         End If

         If MessageBox.Show("Confirma realizar el Cierra Z?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.HacerCierreZDLLs()

         Else

            MessageBox.Show("Usted ha cancelado el Cierre 'Z' !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If


      Catch ex As Exception

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally

         Me.Cursor = Cursors.Default

      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub HacerCierreZDLLs()

      Me.Cursor = Cursors.WaitCursor
      Dim mensaje As String

      If oImpresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2 Then
         'Metodo nuevo de impresion
         Dim impf As ImpresionFiscalV2 = New ImpresionFiscalV2(oImpresora)
         mensaje = impf.CierreZReimprimir(Long.Parse(Me.txtNumeroDesde.Text), Long.Parse(Me.txtNumeroHasta.Text), True)
      Else
         Dim impf As ImpresionFiscal = New ImpresionFiscal(oImpresora.Modelo, oImpresora.Puerto)
         mensaje = impf.CierreZReimprimir(Long.Parse(Me.txtNumeroDesde.Text), Long.Parse(Me.txtNumeroHasta.Text), True)
      End If

      MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Me.txtNumeroDesde.Focus()

   End Sub


#End Region

End Class