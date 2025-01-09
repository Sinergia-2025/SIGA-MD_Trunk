Public Class ImprimirPlanilla

   Private _idSucursal As Integer
   Private _idCaja As Integer
   Private _numeroPlanilla As Integer

   Private _sucursal As Entidades.Sucursal
   Private _cajaNombre As Entidades.CajaNombre
   Private _planilla As Entidades.Caja

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer)
      Me.New()
      _idSucursal = idSucursal
      _idCaja = idCaja
      _numeroPlanilla = numeroPlanilla
   End Sub


   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            Dim _publicos As Publicos = New Publicos()

            If _numeroPlanilla > 0 Then
               CargarPlanilla()
            End If
         End Sub)
   End Sub

#Region "Eventos"

   Private Sub optHorizontal_CheckedChanged(sender As Object, e As EventArgs) Handles optHorizontal.CheckedChanged
      TryCatched(
         Sub()
            chkObservaciones.Checked = True
            chkObservaciones.Enabled = False
         End Sub)
   End Sub

   Private Sub optVertical_CheckedChanged(sender As Object, e As EventArgs) Handles optVertical.CheckedChanged
      TryCatched(
         Sub()
            chkObservaciones.Checked = False
            chkObservaciones.Enabled = True
         End Sub)
   End Sub

   Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
      TryCatched(Sub() ImprimirInforme())
   End Sub

   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      TryCatched(Sub() Close())
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarPlanilla()
      _sucursal = New Reglas.Sucursales().GetUna(_idSucursal, incluirLogo:=False)
      _cajaNombre = New Reglas.CajasNombres().GetUna(_idSucursal, _idCaja)
      Dim rCajas As Reglas.Cajas = New Reglas.Cajas()
      _planilla = rCajas.GetPlanilla(_idSucursal, _idCaja, _numeroPlanilla)
      If Not _planilla.FechaCierrePlanilla.HasValue Then
         rCajas.CargaSaldoFinalPlanillaAbierta(_planilla)
      End If
   End Sub

   Private Sub ImprimirInforme()
      Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreCaja", _cajaNombre.NombreCaja))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NumeroPlanilla", _numeroPlanilla.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", _planilla.FechaPlanilla.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaCierre", _planilla.FechaCierrePlanilla.ToStringValue(Nothing)))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicialPesos", _planilla.PesosSaldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicialDolares", _planilla.DolaresSaldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicialTickets", _planilla.TicketsSaldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicialCheques", _planilla.ChequesSaldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicialTarjetas", _planilla.TarjetasSaldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicialBancos", _planilla.BancosSaldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicialBancosDolares", _planilla.BancosDolaresSaldoInicial.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoInicialRetenciones", _planilla.RetencionesSaldoInicial.ToString()))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinalPesos", _planilla.PesosSaldoFinal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinalDolares", _planilla.DolaresSaldoFinal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinalTickets", _planilla.TicketsSaldoFinal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinalCheques", _planilla.ChequesSaldoFinal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinalTarjetas", _planilla.TarjetasSaldoFinal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinalBancos", _planilla.BancosSaldoFinal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinalBancosDolares", _planilla.BancosDolaresSaldoFinal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("SaldoFinalRetenciones", _planilla.RetencionesSaldoFinal.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", _sucursal.Nombre.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cerrada", _planilla.FechaCierrePlanilla.HasValue.ToString()))

      '# Preparo los DataSources
      Dim rCajaDetalles = New Reglas.CajaDetalles()
      Dim dtMovCaja = rCajaDetalles.GetTodas(actual.Sucursal.Id, _idCaja, _numeroPlanilla, If(optVertical.Checked, "FECHA", "GRUPO"))

      Dim rVentas = New Reglas.Ventas()
      Dim dtProductosAlerta As DataTable
      If Reglas.Publicos.CajaPlanillaMuestraProductosConAlerta Then
         dtProductosAlerta = rVentas.GetProductosAlertaPorCaja(_idSucursal, _idCaja, _numeroPlanilla)
      Else
         dtProductosAlerta = rVentas.GetProductosAlertaPorCaja(0, 0, 0)
      End If

      Dim dtVentasEnCtaCte As DataTable
      If Reglas.Publicos.CajaPlanillaMuestraVentasEnCtaCte Then
         dtVentasEnCtaCte = rVentas.GetInfVentasEnCtaCtePorCaja(_idSucursal, _idCaja, _numeroPlanilla)
      Else
         dtVentasEnCtaCte = rVentas.GetInfVentasEnCtaCtePorCaja(0, 0, 0)
      End If


      ' Resolver si el cliente tiene informe personalizado
      Dim reporte As Entidades.InformePersonalizadoResuelto
      If optVertical.Checked Then
         If optVertical.Checked And chkObservaciones.Checked Then
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.CajaDetallesObservacion, "Eniac.Win.CajaDetallesObservacion.rdlc")
         Else
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.CajaDetalles, "Eniac.Win.CajaDetalles.rdlc")
         End If
      Else
         reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.CajaDetallesHorizontal, "Eniac.Win.CajaDetallesHorizontal.rdlc")
      End If

      Dim frmImprime As VisorReportes
      If optVertical.Checked And Not chkObservaciones.Checked Then
         frmImprime = New VisorReportes(reporte.NombreArchivo,
                                        "SistemaDataSet_MovimientosDeCaja", dtMovCaja,
                                        "SistemaDataSet_ProductosAlerta", dtProductosAlerta,
                                        "SistemaDataSet_VentasCtaCte", dtVentasEnCtaCte,
                                        parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias
      Else
         frmImprime = New VisorReportes(reporte.NombreArchivo,
                                           "SistemaDataSet_MovimientosDeCaja", dtMovCaja,
                                           parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias
      End If
      frmImprime.Text = "Planilla De Caja"

      'Diego: como hago para que la ventana se ajuste al ancho del reporte? (sin tener que darle manualmente el size)
      frmImprime.WindowState = FormWindowState.Maximized
      frmImprime.Show()
   End Sub
#End Region

End Class