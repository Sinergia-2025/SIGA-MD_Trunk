Public Class ucNDConfArchivos

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Archivos
      chbProductoTieneModelo.Checked = Reglas.Publicos.ProductoTieneModelo
      chbProductoTieneSubRubro.Checked = Reglas.Publicos.ProductoTieneSubRubro
      chbProductoTieneSubSubRubro.Checked = Reglas.Publicos.ProductoTieneSubSubRubro
      chbUtilizaAlicuota2.Checked = Reglas.Publicos.ProductoUtilizaAlicuota2

      chbClienteUtilizaCBU.Checked = Reglas.Publicos.ClienteUtilizaCBU  ' Boolean.Parse(par.GetValorPD(Me.chbClienteUtilizaCBU.Tag.ToString(), "False"))
      chbRecalculaValoracionesEstrellas.Checked = Reglas.Publicos.RecalculaValoracionesEstrellas
      chbClienteDRporGrabaLibro.Checked = Reglas.Publicos.ClienteDRporGrabaLibro

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Archivos
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOTIENEMODELO, chbProductoTieneModelo, Nothing, chbProductoTieneModelo.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOTIENESUBRUBRO, chbProductoTieneSubRubro, Nothing, chbProductoTieneSubRubro.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOTIENESUBSUBRUBRO, Me.chbProductoTieneSubSubRubro, Nothing, chbProductoTieneSubSubRubro.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.PRODUCTOUTILIZAALICUOTA2, chbUtilizaAlicuota2, Nothing, chbUtilizaAlicuota2.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEUTILIZACBU, chbClienteUtilizaCBU, Nothing, chbClienteUtilizaCBU.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.RECALCULAVALORACIONESESTRELLAS, chbRecalculaValoracionesEstrellas, Nothing, chbRecalculaValoracionesEstrellas.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CLIENTEDRGRABALIBRO, chbClienteDRporGrabaLibro, Nothing, chbClienteDRporGrabaLibro.Text)

   End Sub

End Class