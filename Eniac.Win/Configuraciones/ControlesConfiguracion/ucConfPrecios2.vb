Public Class ucConfPrecios2
   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboMonedas1(cmbConsultaPreciosClienteMoneda, {New Entidades.Moneda() With {.IdMoneda = -1, .NombreMoneda = "del producto"}}, {})
      cmbConsultaPreciosClienteMoneda.SelectedIndex = 0
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      chbConsultaPreciosClienteUsaPredeterminado.Checked = Reglas.Publicos.ConsultaPreciosCliente.UsaPredeterminado
      txtConsultaPreciosClienteCodigoCliente.Text = Reglas.Publicos.ConsultaPreciosCliente.CodigoCliente.ToString()

      cmbConsultaPreciosClienteMoneda.SelectedValue = Reglas.Publicos.ConsultaPreciosCliente.Moneda

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      If Not chbConsultaPreciosClienteUsaPredeterminado.Checked Then
         txtConsultaPreciosClienteCodigoCliente.SetValor(0L)
      End If

      ActualizarParametro(Entidades.Parametro.Parametros.CONSULTAPRECIOSCLIENTEUSAPREDETERMINADO, chbConsultaPreciosClienteUsaPredeterminado, Nothing,
                          String.Format("{0} - {1}", grpConsultaPreciosCliente.Text, chbConsultaPreciosClienteUsaPredeterminado.Text))
      ActualizarParametro(Entidades.Parametro.Parametros.CONSULTAPRECIOSCLIENTEUSACODIGOCLIENTE, txtConsultaPreciosClienteCodigoCliente, Nothing,
                          String.Format("{0} - {1}", grpConsultaPreciosCliente.Text, lblConsultaPreciosClienteCodigoCliente.Text))

      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.CONSULTAPRECIOSCLIENTEMONEDA, cmbConsultaPreciosClienteMoneda, Nothing,
                                      String.Format("{0} - {1}", grpConsultaPreciosCliente.Text, lblConsultaPreciosClienteMoneda.Text))

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If chbConsultaPreciosClienteUsaPredeterminado.Checked Then
         Dim rClientes = New Reglas.Clientes()
         If Not rClientes.ExisteCodigo(txtConsultaPreciosClienteCodigoCliente.ValorNumericoPorDefecto(0L)) Then
            e.AgregarError(String.Format("No existe el Código de Cliente {0}", txtConsultaPreciosClienteCodigoCliente.Text))
            txtConsultaPreciosClienteCodigoCliente.Focus()
         End If
      End If

   End Sub

End Class