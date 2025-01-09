Public Class ucConfCtaCteClienteInformes

   Protected Overrides Sub OnInicializando(e As InicializarEventArgs)
      MyBase.OnInicializando(e)

      e.Publicos.CargaComboDesdeEnum(cmbCtaCteCliente_Informes_Modalidad, GetType(Entidades.EnumSql.GetCoeficienteCobranzasModalidad))

   End Sub

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Cta. Cte. INFORMES
      cmbCtaCteCliente_Informes_Modalidad.SelectedValue = Reglas.Publicos.CuentasCorrientes.Informes.ModalidadCoeficienteCobranzas
      ChbNombreFantasia.Checked = Reglas.Publicos.CuentasCorrientes.Informes.NombreFantasia

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Cta. Cte. INFORMES
      ActualizarParametro(Of Entidades.EnumSql.GetCoeficienteCobranzasModalidad)(Entidades.Parametro.Parametros.MODALIDADCOEFICIENTECOBRANZAS, cmbCtaCteCliente_Informes_Modalidad, Nothing, grpCtaCteCliente_Informes_InfCoeficienteCobranzas.Text + lblCtaCteCliente_Informes_Modalidad.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.CONSCCBLUEOCULTANOMFANTASIA, ChbNombreFantasia, Nothing, ChbNombreFantasia.Text)

   End Sub

End Class
