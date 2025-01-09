Public Class ImprimirMovimientoCaja
   Public Sub Imprimir(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer, numeroMovimiento As Integer, visualiza As Boolean)

      Dim cajaNombres = New Reglas.CajasNombres().GetUna(idSucursal, idCaja)
      Dim planilla = New Reglas.Cajas().GetPlanillaCaja(idSucursal, idCaja, numeroPlanilla)

      Dim rCajaDet = New Reglas.CajaDetalles()
      Using dtMov = rCajaDet.GetMovimiento(idSucursal, idCaja, numeroPlanilla, numeroMovimiento)

         If dtMov.Rows.Count = 0 Then
            Throw New Exception("No existe el movimiento seleccionado.")
         End If

         Dim drMov = dtMov.First()

         Dim fechaMovimiento = drMov.Field(Of Date)("FechaMovimiento")
         Dim idCuentaCaja = drMov.Field(Of Integer)("IdCuentaCaja")
         Dim nombreCuentaCaja = drMov.Field(Of String)("NombreCuentaCaja")

         Dim tipoMovimiento = String.Empty
         Dim coef As Integer

         If drMov.Field(Of String)("IdTipoMovimiento") = "I" Then
            tipoMovimiento = "Ingreso"
            coef = 1
         ElseIf drMov.Field(Of String)("IdTipoMovimiento") = "E" Then
            tipoMovimiento = "Egreso"
            coef = -1
         End If

         Dim importePesos = drMov.Field(Of Decimal)("ImportePesos") * coef
         Dim importeCheques = drMov.Field(Of Decimal)("ImporteCheques") * coef
         Dim importeTarjetas = drMov.Field(Of Decimal)("ImporteTarjetas") * coef
         Dim importeTickets = drMov.Field(Of Decimal)("ImporteTickets") * coef
         Dim importeDolares = drMov.Field(Of Decimal)("ImporteDolares") * coef
         Dim importeEuros = drMov.Field(Of Decimal)("ImporteEuros") * coef
         Dim importeBancos = drMov.Field(Of Decimal)("ImporteBancos") * coef
         Dim importeRetenciones = drMov.Field(Of Decimal)("ImporteRetenciones") * coef

         Dim importeTotal = importePesos + importeCheques + importeTarjetas + importeTickets + importeBancos + importeRetenciones

         Dim observaciones = drMov.Field(Of String)("Observacion")

         'creo la coleccion de parametros
         Dim parm = New ReportParameterCollection() ' List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresa)
         parm.Add("NombreSucursal", actual.Sucursal.Nombre)
         parm.Add("NombreCaja", cajaNombres.NombreCaja)
         parm.Add("FechaPlanilla", planilla.FechaPlanilla)
         parm.Add("NumeroPlanilla", numeroPlanilla)
         parm.Add("FechaMovimiento", fechaMovimiento)
         parm.Add("NumeroMovimiento", numeroMovimiento)
         parm.Add("IdCuentaCaja", idCuentaCaja)
         parm.Add("NombreCuentaCaja", nombreCuentaCaja)
         parm.Add("TipoMovimiento", tipoMovimiento)
         parm.Add("ImportePesos", importePesos)
         parm.Add("ImporteTarjetas", importeTarjetas)
         parm.Add("ImporteTickets", importeTickets)
         parm.Add("ImporteDolares", importeDolares)
         parm.Add("ImporteBancos", importeBancos)
         parm.Add("ImporteRetenciones", importeRetenciones)

         parm.Add("ImporteTotal", importeTotal)
         parm.Add("Observacion", observaciones)

         Dim rCheques = New Reglas.Cheques()
         Dim dtCheques = rCheques.GetChequesDeMovimiento(idSucursal, idCaja, numeroPlanilla, numeroMovimiento, False)

         ImprimirInformes(dtCheques, tipoMovimiento, parm, visualiza)
      End Using

   End Sub

   Private Sub ImprimirInformes(dt As DataTable, title As String, parm As ReportParameterCollection, visualiza As Boolean)
      ' Resolver si el cliente tiene informe personalizado
      Dim reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.TicketCajaMovimiento, "Eniac.Win.CajaMovimiento.rdlc")

      If visualiza Then
         Dim frmImprime = New VisorReportes(reporte.NombreArchivo, "SistemaDataSet_Cheques", dt, parm, reporte.ReporteEmbebido, 1) With { '# 1 = Cantidad Copias
            .Text = title,
            .WindowState = FormWindowState.Maximized,
            .StartPosition = FormStartPosition.CenterScreen
         }
         frmImprime.rvReporte.DocumentMapCollapsed = True   'Si no hago esto, muestra una grilla a la izquierda.
         frmImprime.Show()
      Else
         Dim ePDF = New ExportarPDF()
         ePDF.Run(reporte.NombreArchivo, "SistemaDataSet_Cheques", dt, parm, reporte.ReporteEmbebido, "")
      End If
   End Sub


End Class