Public Class ucConfAFIP

   Protected Overrides Sub OnCargando(e As CancelableEventArgs)
      MyBase.OnCargando(e)

      'AFIP
      chbAFIPHabilitaVentasPeriodoAutomaticamente.Checked = Reglas.Publicos.AFIPHabilitaVentasPeriodoAutomaticamente

      Dim prorrateoCitiCompras = Reglas.Publicos.AFIPCitiComprasProrrateo
      chbProrrateoCitiCompras.Checked = prorrateoCitiCompras <> Entidades.EnumAfip.ProrrateoCitiCompras.NO
      radProrrateoCitiComprasPorComprobante.Checked = prorrateoCitiCompras = Entidades.EnumAfip.ProrrateoCitiCompras.SI_PORCOMPROBANTE
      radProrrateoCitiComprasGlobal.Checked = prorrateoCitiCompras = Entidades.EnumAfip.ProrrateoCitiCompras.SI_GLOBAL

      chbAFIPUtilizaCM05.Checked = Reglas.Publicos.AFIPUtilizaCM05

   End Sub

   Protected Overrides Sub OnGrabando(e As CancelableEventArgs)
      MyBase.OnGrabando(e)

      'AFIP
      ActualizarParametro(Entidades.Parametro.Parametros.AFIPHABILITAVENTASPERIODOAUTOMATICAMENTE, chbAFIPHabilitaVentasPeriodoAutomaticamente, Nothing, chbAFIPHabilitaVentasPeriodoAutomaticamente.Text)

      Dim valorProrrateoCitiCompras As Entidades.EnumAfip.ProrrateoCitiCompras
      If chbProrrateoCitiCompras.Checked Then
         If radProrrateoCitiComprasGlobal.Checked Then
            valorProrrateoCitiCompras = Entidades.EnumAfip.ProrrateoCitiCompras.SI_GLOBAL
         ElseIf radProrrateoCitiComprasPorComprobante.Checked Then
            valorProrrateoCitiCompras = Entidades.EnumAfip.ProrrateoCitiCompras.SI_PORCOMPROBANTE
         End If
      Else
         valorProrrateoCitiCompras = Entidades.EnumAfip.ProrrateoCitiCompras.NO
      End If
      ActualizarParametroTexto(Entidades.Parametro.Parametros.AFIPCITICOMPRASPRORRATEO, valorProrrateoCitiCompras.ToString(), Nothing, grpProrrateoCitiCompras.Text)

      ActualizarParametro(Entidades.Parametro.Parametros.AFIPUTILIZACM05, chbAFIPUtilizaCM05, Nothing, chbAFIPUtilizaCM05.Text)

   End Sub

   Protected Overrides Sub OnValidando(e As ValidacionEventArgs)
      MyBase.OnValidando(e)

      If chbProrrateoCitiCompras.Checked Then
         If Not radProrrateoCitiComprasGlobal.Checked And Not radProrrateoCitiComprasPorComprobante.Checked Then
            e.AgregarError("Debe seleccionar un tipo de Prorrateo.")
            radProrrateoCitiComprasPorComprobante.Focus()
         End If
      End If

   End Sub

   Private Sub chbProrrateoCitiCompras_CheckedChanged(sender As Object, e As EventArgs) Handles chbProrrateoCitiCompras.CheckedChanged
      If Inicializada Then
         FindForm().TryCatched(
            Sub()
               radProrrateoCitiComprasGlobal.Visible = chbProrrateoCitiCompras.Checked
               radProrrateoCitiComprasPorComprobante.Visible = chbProrrateoCitiCompras.Checked
               If chbProrrateoCitiCompras.Checked Then
                  radProrrateoCitiComprasPorComprobante.Checked = True
               End If
            End Sub)
      End If
   End Sub


End Class