Public Class ucConfProduccion

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Produccion
      chbProduccionRecetaUnica.Checked = Reglas.Publicos.ProduccionRecetaUnica
      chbProduccionDescuentaProdFormula.Checked = Reglas.Publicos.ProduccionDescStockComponentesFormulasFacturacion
      chbDivideTamano.Checked = Reglas.Publicos.ProduccionDivideTamano
      chbSolicitaModificarFormulaLuegoDelProducto.Checked = Reglas.Publicos.SolicitaModificarFormulaLuegoDelProducto

      chbOrdProdMostrarCosto.Checked = Reglas.Publicos.DetalleProduccion.OrdProdMostrarCosto
      chbOrdProdMostrarVenta.Checked = Reglas.Publicos.DetalleProduccion.OrdProdMostrarVenta

      chbOrdProdLargoExtAlto.Checked = Reglas.Publicos.DetalleProduccion.OrdProdMostrarProductoLargoExtAlto
      chbOrdProdAnchoIntBase.Checked = Reglas.Publicos.DetalleProduccion.OrdProdMostrarProductoAnchoIntBase
      chbOrdProdArchitrave.Checked = Reglas.Publicos.DetalleProduccion.OrdProdMostrarProductoArchitrave

      chbOrdProdMostrarFormula.Checked = Reglas.Publicos.DetalleProduccion.OrdProdMostrarFormula

      chbOrdProdImprimirComponentesNecesarios.Checked = Reglas.Publicos.DetalleProduccion.ImprimirComponentesNecesarios
      chbOrdProdCantidadNecesariaUnitaria.Checked = Reglas.Publicos.DetalleProduccion.CantidadNecesariaUnitaria
      txtOrdProdCantidadLineaSeparacion.Text = Reglas.Publicos.DetalleProduccion.CantidadLineaSeparacion.ToString()

      txtProduccionDecimalesVariablesModeloForma.Text = Reglas.Publicos.ProduccionDecimalesVariablesModeloForma.ToString()
      '-- REQ-42944.- -----------------------------------------------------------------------------------------------------
      chbProductoModeloForma.Checked = Reglas.Publicos.DetalleProduccion.OrdProdMostrarProductoModeloForma
      '--------------------------------------------------------------------------------------------------------------------
      chbProduccionCalculaPrecioSegunPorcentaje.Checked = Reglas.Publicos.DetalleProduccion.CalcularPrecioVentaPorcentajeFormula

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Produccion
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCCIONRECETAUNICA, chbProduccionRecetaUnica, Nothing, chbProduccionRecetaUnica.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCCIONDESCUENTAPRODFORMULAFACTURAR, chbProduccionDescuentaProdFormula, Nothing, chbProduccionDescuentaProdFormula.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCCIONDIVIDETAMANO, chbDivideTamano, Nothing, chbDivideTamano.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.SOLICITAMODIFICARFORMULALUEGODELPRODUCTO, chbSolicitaModificarFormulaLuegoDelProducto, Nothing, chbSolicitaModificarFormulaLuegoDelProducto.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODMOSTRARCOSTO, chbOrdProdMostrarCosto, Nothing, chbOrdProdMostrarCosto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODMOSTRARVENTA, chbOrdProdMostrarVenta, Nothing, chbOrdProdMostrarVenta.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODMOSTRARPRODUCTOLARGOEXTALTO, chbOrdProdLargoExtAlto, Nothing, chbOrdProdLargoExtAlto.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODMOSTRARPRODUCTOANCHOINTBASE, chbOrdProdAnchoIntBase, Nothing, chbOrdProdAnchoIntBase.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODMOSTRARPRODUCTOARCHITRAVE, chbOrdProdArchitrave, Nothing, chbOrdProdArchitrave.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODMOSTRARFORMULA, chbOrdProdMostrarFormula, Nothing, chbOrdProdMostrarFormula.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODIMPRIMIRCOMPONENTESNECESARIOS, chbOrdProdImprimirComponentesNecesarios, Nothing, chbOrdProdImprimirComponentesNecesarios.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODCANTIDADNECESARIAUNITARIA, chbOrdProdCantidadNecesariaUnitaria, Nothing, chbOrdProdCantidadNecesariaUnitaria.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODCANTIDADLINEASEPARACION, txtOrdProdCantidadLineaSeparacion, Nothing, lblOrdProdCantidadLineaSeparacion.Text)

      '-- REQ-42944.- -----------------------------------------------------------------------------------------------------
      ActualizarParametro(Entidades.Parametro.Parametros.ORDPRODMOSTRARPRODUCTOMODELOFORMA, chbProductoModeloForma, Nothing, chbProductoModeloForma.Text)
      '--------------------------------------------------------------------------------------------------------------------

      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCCIONDECIMALESVARIABLESMODELOFORMA, txtProduccionDecimalesVariablesModeloForma, Nothing, lblProduccionDecimalesVariablesModeloForma.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCCIONCALCULARPORCENTAJEFORMULA, chbProduccionCalculaPrecioSegunPorcentaje, Nothing, chbProduccionCalculaPrecioSegunPorcentaje.Text)


   End Sub

   Private Sub chbOrdProdImprimirComponentesNecesarios_CheckedChanged(sender As Object, e As EventArgs) Handles chbOrdProdImprimirComponentesNecesarios.CheckedChanged
      TryCatched(
      Sub()
         chbOrdProdCantidadNecesariaUnitaria.Enabled = chbOrdProdImprimirComponentesNecesarios.Checked
         txtOrdProdCantidadLineaSeparacion.Enabled = chbOrdProdImprimirComponentesNecesarios.Checked

         If chbOrdProdImprimirComponentesNecesarios.Checked Then
            chbOrdProdCantidadNecesariaUnitaria.Checked = Reglas.Publicos.DetalleProduccion.CantidadNecesariaUnitaria
            txtOrdProdCantidadLineaSeparacion.Text = Reglas.Publicos.DetalleProduccion.CantidadLineaSeparacion.ToString()
         Else
            chbOrdProdCantidadNecesariaUnitaria.Checked = False
            txtOrdProdCantidadLineaSeparacion.Text = "0"
         End If
      End Sub)
   End Sub
   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      Dim decimalesVariables = txtProduccionDecimalesVariablesModeloForma.ValorNumericoPorDefecto(0I)
      If decimalesVariables < 0 Then
         e.AgregarError("La {0} en {1} no puede ser ser menor a 0.", grpCantidadDecimales.Text, lblProduccionDecimalesVariablesModeloForma.Text)
         txtProduccionDecimalesVariablesModeloForma.Focus()
      End If
      If decimalesVariables > 10 Then
         e.AgregarError("La {0} en {1} no puede ser mayor a 10.", grpCantidadDecimales.Text, lblProduccionDecimalesVariablesModeloForma.Text)
         txtProduccionDecimalesVariablesModeloForma.Focus()
      End If

   End Sub

End Class