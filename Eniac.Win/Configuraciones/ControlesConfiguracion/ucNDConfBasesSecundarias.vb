Public Class ucNDConfBasesSecundarias

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'Bases Secundarias
      txtNombreBaseARBA.Text = Reglas.Publicos.NombreBaseARBA
      txtNombreBaseProductosWeb.Text = Reglas.Publicos.NombreBaseProductosWeb
      txtNombreBaseEmbarcionesFotos.Text = Reglas.Publicos.NombreBaseEmbarcacionesFotos
      txtCRMBaseAdjuntos.Text = Reglas.Publicos.NombreBaseAdjuntosCRM
      txtBaseAdjuntos.Text = Reglas.Publicos.NombreBaseAdjuntos

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'Bases Secundarias
      ActualizarParametro(Entidades.Parametro.Parametros.NOMBREBASEARBA, txtNombreBaseARBA, Nothing, lblNombreBaseARBA.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.NOMBREBASEPRODUCTOWEB, txtNombreBaseProductosWeb, Nothing, lblNombreBaseProductosWeb.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.NOMBREBASEEMBARCACIONESFOTOS, txtNombreBaseEmbarcionesFotos, Nothing, lblNombreBaseEmbarcacionesFotos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.NOMBREBASEADJUNTOSCRM, txtCRMBaseAdjuntos, Nothing, lblCRMBaseAdjuntos.Text)
      ActualizarParametro(Entidades.Parametro.Parametros.NOMBREBASEADJUNTOS, txtBaseAdjuntos, Nothing, lblBaseAdjuntos.Text)

   End Sub

End Class
