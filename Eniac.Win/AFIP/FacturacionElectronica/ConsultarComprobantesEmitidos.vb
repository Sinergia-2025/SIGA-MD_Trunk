Option Strict Off
Public Class ConsultarComprobantesEmitidos

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.dtpDesde.Value = DateTime.Today.AddDays(-7)
      Me.dtpHasta.Value = DateTime.Today

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()
         Dim dtDetalle As DataTable

         Dim fechaDesde As DateTime = Nothing
         Dim fechahasta As DateTime = Nothing

         fechaDesde = Me.dtpDesde.Value
         fechahasta = Me.dtpHasta.Value

         dtDetalle = oVenta.GetComprobantesElectronicos(Entidades.AFIPCAE.EstadoElectronicos.Todos, fechaDesde, fechahasta,
                                                        idCliente:=0,
                                                        numeroRepartoDesde:=0,
                                                        numeroRepartoHasta:=0,
                                                        tipoComprobantes:=Nothing,
                                                        letraFiscal:="",
                                                        centroEmisor:=0,
                                                        numeroComprobante:=0,
                                                        idCategoria:=0,
                                                        idUsuario:=Nothing,
                                                        IdVendedor:=0,
                                                        idFormasPago:=0,
                                                        nroRepartoInvocacionMasiva:=0)

         Me.dgvDetalle.DataSource = dtDetalle

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvDetalle_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetalle.SelectionChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.dgvDetalle.SelectedRows.Count = 0 Then
            Exit Sub
         End If
         Dim dr As DataRow = dgvDetalle.FilaSeleccionada(Of DataRow)()
         If dr Is Nothing Then
            Exit Sub
         End If

         If Not Publicos.HayInternet() Then
            MessageBox.Show("No tiene internet para realizar esta acción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
         End If

         Dim idTipoComprobante As String = dr("IdTipoComprobante").ToString()
         Dim letra As String = dr("Letra").ToString()
         Dim centroEmisor As Short = dr.ValorNumericoPorDefecto("CentroEmisor", 0S)
         Dim numeroComprobante As Long = dr.ValorNumericoPorDefecto("NumeroComprobante", 0L)

         Dim impresora = New Reglas.Impresoras().GetUna(actual.Sucursal.Id, centroEmisor)

         If impresora.UtilizaBonosFiscalesElectronicos Then
            Dim reg = New Reglas.AFIPBFE()
            Dim comp = reg.GetComprobanteEmitido(idTipoComprobante, letra, numeroComprobante, centroEmisor)
            ptgInfo.SelectedObject = comp
            lblInformacionAFIP.Text = "Información en AFIP."
         Else
            Dim reg = New Reglas.AFIPFE()
            Dim comp = reg.GetComprobanteEmitidoV1(idTipoComprobante, letra, numeroComprobante, centroEmisor)
            ptgInfo.SelectedObject = comp
            lblInformacionAFIP.Text = "Información en AFIP."
         End If

         tsbAplicar.Enabled = IsDBNull(dr("CAE"))

      Catch ex As Exception
         Me.lblInformacionAFIP.Text = "No hay información en AFIP."
         Me.ptgInfo.SelectedObject = Nothing
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

   Private Sub tsbAplicar_Click(sender As Object, e As EventArgs) Handles tsbAplicar.Click
      Try
         Aplicar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub Aplicar()

      If dgvDetalle.RowCount > 0 Then

         Dim dr As DataRow = dgvDetalle.FilaSeleccionada(Of DataRow)()
         If dr Is Nothing Then
            ShowPregunta("Seleccione un comprobante")
            Exit Sub
         End If

         If Not IsDBNull(dr("CAE")) Then
            If Not ShowPregunta("El comprobante seleccionado ya posee CAE. ¿Desea actualizar dicha información?") Then
               Exit Sub
            End If
         End If

         If ptgInfo.SelectedObject Is Nothing Or Not TypeOf (ptgInfo.SelectedObject) Is Reglas.WSFEv1.FECompConsResponse Then
            ShowPregunta("No se encontró la información en AFIP")
            Exit Sub
         End If

         Dim idSucursal As Integer = dr.ValorNumericoPorDefecto("IdSucursal", 0I)
         Dim idTipoComprobante As String = dr("IdTipoComprobante").ToString()
         Dim letra As String = dr("Letra").ToString()
         Dim centroEmisor As Short = dr.ValorNumericoPorDefecto("CentroEmisor", 0S)
         Dim numeroComprobante As Long = dr.ValorNumericoPorDefecto("NumeroComprobante", 0L)


         Dim comp As Reglas.WSFEv1.FECompConsResponse = DirectCast(ptgInfo.SelectedObject, Reglas.WSFEv1.FECompConsResponse)
         Dim fechaVtoCAE As DateTime = DateTime.ParseExact(comp.FchVto, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture)

         Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
         rVentas.ActualizarCAE(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, comp.CodAutorizacion, fechaVtoCAE)

         btnConsultar.PerformClick()
         ShowMessage("Actualización realizada exitosamente")
      End If

   End Sub

End Class