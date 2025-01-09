Public Class ExportarCitiVentasConfirmacion
   Private _dtComprobantes As DataTable
   Private _dtAlicuotas As DataTable
   Private _dtAnulados As DataTable

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() MostrarInformacion())
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Public Overloads Function ShowDialog(owner As IWin32Window, dtComprobantes As DataTable, dtAlicuotas As DataTable, dtAnulados As DataTable) As DialogResult
      _dtComprobantes = dtComprobantes
      _dtAlicuotas = dtAlicuotas
      _dtAnulados = dtAnulados
      Return ShowDialog(owner)
   End Function

   Private Sub Aceptar()
      Dim ok = True
      If txtRegistrosSinSeleccionarComprobantes.ValorNumericoPorDefecto(0I) <> 0 Or
         txtRegistrosSinSeleccionarAlicuotas.ValorNumericoPorDefecto(0I) <> 0 Or
         txtRegistrosSinSeleccionarAnuladas.ValorNumericoPorDefecto(0I) <> 0 Then
         ok = ShowPregunta("Hay registros sin seleccionar los cuales no se exportarán. ¿Está seguro de continuar?",
                           defaultButton:=MessageBoxDefaultButton.Button2) = DialogResult.Yes
      End If
      If ok Then
         Close(DialogResult.OK)
      End If
   End Sub
   Private Sub MostrarInformacion()
      Dim sinSeleccionarComprobantes = _dtComprobantes.AsEnumerable().Count(Function(dr) dr.Field(Of Boolean)("Procesar"))
      Dim sinSeleccionarAlicuotas = _dtAlicuotas.AsEnumerable().Count(Function(dr) dr.Field(Of Boolean)("Procesar"))
      Dim sinSeleccionarAnulados = _dtAnulados.AsEnumerable().Count(Function(dr) dr.Field(Of Boolean)("Procesar"))

      txtCantidadRegistrosComprobantes.SetValor(_dtComprobantes.Count)
      txtCantidadRegistrosAlicuotas.SetValor(_dtAlicuotas.Count)
      txtCantidadRegistrosAnulados.SetValor(_dtAnulados.Count)

      txtRegistrosSeleccionadosComprobantes.SetValor(sinSeleccionarComprobantes)
      txtRegistrosSeleccionadosAlicuotas.SetValor(sinSeleccionarAlicuotas)
      txtRegistrosSeleccionadosAnulados.SetValor(sinSeleccionarAnulados)

      txtRegistrosSinSeleccionarComprobantes.SetValor(_dtComprobantes.Count - sinSeleccionarComprobantes)
      txtRegistrosSinSeleccionarAlicuotas.SetValor(_dtAlicuotas.Count - sinSeleccionarAlicuotas)
      txtRegistrosSinSeleccionarAnuladas.SetValor(_dtAnulados.Count - sinSeleccionarAnulados)

      txtRegistrosConErrorComprobantes.SetValor(_dtComprobantes.AsEnumerable().Count(Function(dr) Not String.IsNullOrWhiteSpace(dr.Field(Of String)("TipoError"))))
      txtRegistrosConErrorAlicuotas.SetValor(_dtAlicuotas.AsEnumerable().Count(Function(dr) Not String.IsNullOrWhiteSpace(dr.Field(Of String)("TipoError"))))
      txtRegistrosConErrorAnulados.SetValor(_dtAnulados.AsEnumerable().Count(Function(dr) Not String.IsNullOrWhiteSpace(dr.Field(Of String)("TipoError"))))

      If txtRegistrosConErrorComprobantes.ValorNumericoPorDefecto(0I) > 0 Or
         txtRegistrosConErrorAlicuotas.ValorNumericoPorDefecto(0I) > 0 Or
         txtRegistrosConErrorAnulados.ValorNumericoPorDefecto(0I) > 0 Then
         PictureBox1.Visible = True
         If txtRegistrosConErrorComprobantes.ValorNumericoPorDefecto(0I) > 0 Then
            txtRegistrosConErrorComprobantes.Focus()
         ElseIf txtRegistrosConErrorAlicuotas.ValorNumericoPorDefecto(0I) > 0 Then
            txtRegistrosConErrorAlicuotas.Focus()
         ElseIf txtRegistrosConErrorAnulados.ValorNumericoPorDefecto(0I) > 0 Then
            txtRegistrosConErrorAnulados.Focus()
         End If
      Else
         txtCantidadRegistrosComprobantes.Focus()
      End If

   End Sub

End Class