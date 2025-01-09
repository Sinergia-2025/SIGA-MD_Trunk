Public Class ucConfProcesos

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)
      e.Publicos.CargaComboMonedas1(cmbExportarPrecioProductoUsandoMoneda,
                                    agregarAlPrincipio:={New Entidades.Moneda() With {.IdMoneda = -1, .NombreMoneda = "del producto"}},
                                    agregarAlFinal:={})
   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)
      chbTareasPorUsuario.Checked = Reglas.Publicos.TareasPorUsuario
      chbImportarProductosGeneraHistorialPrecios.Checked = Reglas.Publicos.ImportarProductosGeneraHistorialPrecios

      Select Case Reglas.Publicos.ActualizarPreciosExcel
         Case rdbAPExcelActual.Tag.ToString()
            rdbAPExcelActual.Checked = True
         Case rdbAPExcelVenta.Tag.ToString()
            rdbAPExcelVenta.Checked = True
         Case Else
            rdbAPExcelCosto.Checked = True
      End Select

      cmbExportarPrecioProductoUsandoMoneda.SelectedValue = Reglas.Publicos.ExportarPrecioProductoUsandoMoneda
      chbExportarPreciosConIVA.Checked = Reglas.Publicos.ExportarPreciosConIVA
      txtExportarProductosDecimalesRedondeoEnPrecio.Text = Reglas.Publicos.ExportarProductosDecimalesRedondeoEnPrecio.ToString()
      txtCorreoPruebaPara.Text = Reglas.Publicos.ProcesosCorreoPruebaPara

      'SUBIR A LA WEB
      chbClientesSubirWeb.Checked = Reglas.Publicos.ClientesSubirALaWeb
      chbProductosSubirWeb.Checked = Reglas.Publicos.ProductosSubirALaWeb
      chbRubrosSubirWeb.Checked = Reglas.Publicos.RubrosSubirALaWeb
      chbMarcasSubirWeb.Checked = Reglas.Publicos.MarcasSubirALaWeb
      chbLocalidadesSubirWeb.Checked = Reglas.Publicos.LocalidadesSubirALaWeb
      chbProveedoresSubirWeb.Checked = Reglas.Publicos.ProveedoresSubirALaWeb
      chbRubrosComprasSubirWeb.Checked = Reglas.Publicos.RubrosComprasSubirALaWeb
      'BAJAR DE LA WEB
      chbClientesBajarWeb.Checked = Reglas.Publicos.ClientesBajarDeLaWeb
      chbProductosBajarWeb.Checked = Reglas.Publicos.ProductosBajarDeLaWeb
      chbRubrosBajarWeb.Checked = Reglas.Publicos.RubrosBajarDeLaWeb
      chbMarcasBajarWeb.Checked = Reglas.Publicos.MarcasBajarDeLaWeb
      chbLocalidadesBajarWeb.Checked = Reglas.Publicos.LocalidadesBajarDeLaWeb
      chbProveedoresBajarWeb.Checked = Reglas.Publicos.ProveedoresBajarDeLaWeb
      chbRubrosComprasBajarWeb.Checked = Reglas.Publicos.RubrosComprasBajarDeLaWeb

      txtEjecutableTareaProgramada.Text = Reglas.Publicos.EjecutableTareaProgramada

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)
      ActualizarParametro(Entidades.Parametro.Parametros.TAREASPORUSUARIO, chbTareasPorUsuario, Nothing, chbTareasPorUsuario.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.IMPORTARPRODUCTOSGENERAHISTORIALPRECIOS, chbImportarProductosGeneraHistorialPrecios, Nothing, chbImportarProductosGeneraHistorialPrecios.Text)

      ActualizarParametroTexto(Entidades.Parametro.Parametros.ACTUALIZARPRECIOSEXCEL,
                           If(rdbAPExcelActual.Checked, rdbAPExcelActual.Tag.ToString(), If(rdbAPExcelVenta.Checked, rdbAPExcelVenta.Tag.ToString(), rdbAPExcelCosto.Tag.ToString())),
                           Nothing, grbActualizarPreciosPlantillaExcel.Text)

      If cmbExportarPrecioProductoUsandoMoneda.SelectedIndex = -1 Then cmbExportarPrecioProductoUsandoMoneda.SelectedIndex = 0
      ActualizarParametro(Of Integer)(Entidades.Parametro.Parametros.EXPORTARPRECIOPRODUCTOUSANDOMONEDA, cmbExportarPrecioProductoUsandoMoneda, Nothing, lblExportarPrecioProductoUsandoMoneda.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.EXPORTARPRECIOSCONIVA, chbExportarPreciosConIVA, Nothing, chbExportarPreciosConIVA.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.EXPORTARPRODUCTOSDECIMALESREDONDEOENPRECIO, txtExportarProductosDecimalesRedondeoEnPrecio, Nothing, lblExportarProductosDecimalesRedondeoEnPrecio.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PROCESOSCORREOPRUEBAPARA, txtCorreoPruebaPara, Nothing, lblCorreoPruebaPara.Text)


      'SUBIR A LA WEB
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTESSUBIRALAWEB, chbClientesSubirWeb, Nothing, "Subir a la Web " + chbClientesSubirWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOSSUBIRALAWEB, chbProductosSubirWeb, Nothing, "Subir a la Web " + chbProductosSubirWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RUBROSSUBIRALAWEB, chbRubrosSubirWeb, Nothing, "Subir a la Web " + chbRubrosSubirWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MARCASSUBIRALAWEB, chbMarcasSubirWeb, Nothing, "Subir a la Web " + chbMarcasSubirWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.LOCALIDADESSUBIRALAWEB, chbLocalidadesSubirWeb, Nothing, "Subir a la Web " + chbLocalidadesSubirWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PROVEEDORESSUBIRALAWEB, chbProveedoresSubirWeb, Nothing, "Subir a la Web " + chbProveedoresSubirWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RUBROSCOMPRASSUBIRALAWEB, chbRubrosComprasSubirWeb, Nothing, "Subir a la Web " + chbRubrosComprasSubirWeb.Text)
      'BAJAR DE LA WEB
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTESBAJARDELAWEB, chbClientesBajarWeb, Nothing, "Bajar de la Web " + chbClientesBajarWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOSBAJARDELAWEB, chbProductosBajarWeb, Nothing, "Bajar de la Web " + chbProductosBajarWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RUBROSBAJARDELAWEB, chbRubrosBajarWeb, Nothing, "Bajar de la Web " + chbRubrosBajarWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.MARCASBAJARDELAWEB, chbMarcasBajarWeb, Nothing, "Bajar de la Web " + chbMarcasBajarWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.LOCALIDADESBAJARDELAWEB, chbLocalidadesBajarWeb, Nothing, "Bajar de la Web " + chbLocalidadesBajarWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PROVEEDORESBAJARDELAWEB, chbProveedoresBajarWeb, Nothing, "Bajar de la Web " + chbProveedoresBajarWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RUBROSCOMPRASBAJARDELAWEB, chbRubrosComprasBajarWeb, Nothing, "Bajar de la Web " + chbRubrosComprasBajarWeb.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.EJECUTABLETAREAPROGRAMADA, txtEjecutableTareaProgramada, Nothing, lblEjecutableTareaProgramada.Text)

   End Sub

   Private Sub btnEjecutableTareaProgramada_Click(sender As Object, e As EventArgs) Handles btnEjecutableTareaProgramada.Click
      FindForm().TryCatched(
         Sub()
            ofdEjecutableTareaProgramada.FileName = txtEjecutableTareaProgramada.Text
            If ofdEjecutableTareaProgramada.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
               txtEjecutableTareaProgramada.Text = ofdEjecutableTareaProgramada.FileName
            End If
         End Sub)
   End Sub

End Class