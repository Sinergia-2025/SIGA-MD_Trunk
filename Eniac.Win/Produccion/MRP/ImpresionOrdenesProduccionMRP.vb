Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports Eniac.Entidades
Imports Eniac.Reglas
Imports Microsoft.Reporting.WinForms
Public Class ImpresionOrdenesProduccionMRP
   Public Sub ImprimirHojaRutaOperacion(OrdProdOper As Entidades.OrdenProduccionMRPOperacion, Visualizar As Boolean)
      Dim reporteNombre As String = "Eniac.Win.HojaRutaMRP.rdlc"
      Dim reporteEmbebido = True

      ImprimirHojaRutaOperacion(OrdProdOper, Visualizar, reporteNombre, reporteEmbebido)
   End Sub
   Private Function ConvierteTiempos(valTiempo As Decimal) As String
      Dim tt As TimeSpan = TimeSpan.FromHours(Decimal.ToDouble(valTiempo))
      Return String.Format("{0} Hs. {1} Min. {2} Seg.", tt.Hours.ToString("00"), tt.Minutes.ToString("00"), tt.Seconds.ToString("00"))
   End Function


   Public Sub ImprimirHojaRutaOperacion(OrdProdOper As Entidades.OrdenProduccionMRPOperacion, Visualizar As Boolean, reporteNombre As String, reporteEmbebido As Boolean)
      Try
         Dim dtsNecesarios = "dtProductosNecesarios"
         Dim dtsNormasFabr = "dtNormasFabrica"

         Dim parm = New ReportParameterCollection()
         '--
         parm.Add("TituloReporte", "Orden de Producción")
         '--
         parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
         Dim eCentroProductor = New Reglas.MRPCentrosProductores().GetUno(OrdProdOper.CentroProductorOperacion)
         parm.Add("CentroProduccion", String.Format("{0} {1}", eCentroProductor.CodigoCentroProductor, OrdProdOper.DescripcionCentro))
         parm.Add("TipoCentroProduccion", String.Format("{0}", eCentroProductor.ClaseCentroProductor))
         parm.Add("CantidadControlesCentroProduccion", String.Format("{0}", eCentroProductor.CantidadControles))


         parm.Add("Articulo", String.Format("{0} {1}", OrdProdOper.IdProducto, OrdProdOper.NombreProducto))
         parm.Add("Operacion", String.Format("{0} {1}", OrdProdOper.CodigoProcProdOperacion, OrdProdOper.DescripcionOperacion))
         '--
         parm.Add("Cantidad", String.Format("{0} {1}", OrdProdOper.CantidadOP.ToString("0"), "UNID"))
         parm.Add("Lote", String.Format("{0}", String.Empty))
         '-- Nro de Pedido si existe.- --------------------------------------------------------------------
         If OrdProdOper.NumeroPedido > 0 Then
            parm.Add("Pedido", String.Format("{0} {1}", OrdProdOper.NumeroPedido, OrdProdOper.LineaPedido))
         Else
            parm.Add("Pedido", String.Empty)
         End If
         '-------------------------------------------------------------------------------------------------
         parm.Add("Cliente", String.Format("{0} - {1}", OrdProdOper.CodigoCliente, OrdProdOper.NombreCliente))
         parm.Add("FechaEntrega", String.Format("{0}", OrdProdOper.FechaEntrega.ToString("dd/MM/yyyy")))

         '-- Calcula Valor Horas Totales Orden Produccion.- -------------------------------------------------
         If OrdProdOper.UnidadesHora = 0 Then
            parm.Add("TiempoTotal", String.Format("{0}", ConvierteTiempos(0)))
            parm.Add("TiempoPAP", String.Format("{0}", ConvierteTiempos(0)))
            parm.Add("Produccion", String.Format("{0} UNID/Hora", 0))
         Else
            Dim valorHHOrden = (OrdProdOper.CantidadOP * OrdProdOper.ProdTiemposHHombre) + OrdProdOper.PAPTiemposHHombre

            parm.Add("TiempoTotal", String.Format("{0}", ConvierteTiempos(valorHHOrden)))
            parm.Add("TiempoPAP", String.Format("{0}", ConvierteTiempos(OrdProdOper.PAPTiemposHHombre)))
            parm.Add("Produccion", String.Format("{0} UNID/Hora", OrdProdOper.UnidadesHora.ToString("0")))
         End If
         '-- Productos Necesarios.- -------------------------------------------------------------------------
         Dim dtHRNecesarios As New DtsHojaRutaMRP.dtHojaRutaMRPDataTable
         Dim drHRNecesarios As DtsHojaRutaMRP.dtHojaRutaMRPRow
         For Each dr In OrdProdOper.ProductosNecesarios
            drHRNecesarios = dtHRNecesarios.NewdtHojaRutaMRPRow
            With drHRNecesarios
               .IdProducto = dr.MRPProducto.IdProductoProceso
               If dr.MRPProducto.IdProductoProceso = OrdProdOper.IdProducto Then
                  '-- Busca el codigo de Operacion Anterior.- --------------------
                  Dim operAnt = New Reglas.OrdenesProduccionMRPOperaciones().GetUnaAnterior(OrdProdOper.IdSucursal,
                                                                                                 OrdProdOper.IdTipoComprobante,
                                                                                                 OrdProdOper.LetraComprobante,
                                                                                                 OrdProdOper.CentroEmisor,
                                                                                                 OrdProdOper.NumeroOrdenProduccion,
                                                                                                 OrdProdOper.Orden,
                                                                                                 OrdProdOper.IdProducto,
                                                                                                 OrdProdOper.IdProcesoProductivo,
                                                                                                 OrdProdOper.CodigoProcProdOperacion).CodigoProcProdOperacion
                  .CodigoOperacion = If(operAnt Is Nothing, "ANT", operAnt)
               Else
                  .CodigoOperacion = "FIN"
               End If
               .DescripcionProducto = dr.MRPProducto.NombreProducto
               .Unidad = dr.MRPProducto.UnidadMedidaProd
               .Unitaria = dr.CantidadUnitaria.ToString("N2")
               .Prevista = (OrdProdOper.CantidadOP * dr.CantidadUnitaria).ToString("N2")
            End With
            dtHRNecesarios.AdddtHojaRutaMRPRow(drHRNecesarios)
         Next
         '-- Normas de Fabricacion.- -------------------------------------------------------------------------
         Dim dtHRNormas As New DtsHojaRutaMRP.dtHojaRutaNormasDataTable
         '-- Dispositivos.- --------------------------------
         CargaNormas("Dispositivos", OrdProdOper.NormasDispositivos, dtHRNormas)
         '-- Metodos.- --------------------------------
         CargaNormas("Métodos", OrdProdOper.NormasMetodos, dtHRNormas)
         '-- Seguridad.- --------------------------------
         CargaNormas("Seguridad", OrdProdOper.NormasSeguridad, dtHRNormas)
         '-- Control Calidad.- --------------------------------
         CargaNormas("Calidad", OrdProdOper.NormasControlCalidad, dtHRNormas)
         '----------------------------------------------------------------------------------------------------
         If Visualizar Then
            Using frmImprime = New VisorReportes(reporteNombre, dtsNecesarios, dtHRNecesarios, dtsNormasFabr, dtHRNormas, parm, reporteEmbebido, 1)
               frmImprime.Text = String.Empty
               frmImprime.rvReporte.DocumentMapCollapsed = True
               frmImprime.Size = New Size(780, 600)
               frmImprime.StartPosition = FormStartPosition.CenterScreen
               frmImprime.WindowState = FormWindowState.Maximized
               frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
               frmImprime.ShowDialog()
            End Using
         Else
            Dim imp As Imprimir = New Imprimir(ConfigImprimir)
            imp.Run(reporteNombre,
                    dtsNecesarios,
                    dtHRNecesarios,
                    dtsNormasFabr,
                    dtHRNormas,
                    parm,
                    reporteEmbebido,
                    "",
                    1,
                    seteaMargenes:=False)
         End If


      Catch ex As LocalProcessingException
         If ex.InnerException IsNot Nothing Then
            Throw New Exception(String.Format("{0}: {1}", ex.Message, ex.InnerException.Message), ex)
         Else
            Throw New Exception(ex.Message, ex)
         End If
      End Try
   End Sub
   Private Sub CargaNormas(codigo As String, descripcion As String, dtHRNormas As DtsHojaRutaMRP.dtHojaRutaNormasDataTable)
      Dim drHRNormas As DtsHojaRutaMRP.dtHojaRutaNormasRow
      If Not String.IsNullOrEmpty(descripcion) AndAlso descripcion.Trim() <> "-" Then
         drHRNormas = dtHRNormas.NewdtHojaRutaNormasRow
         With drHRNormas
            .Codigo = codigo
            .Detalle = descripcion
         End With
         dtHRNormas.AdddtHojaRutaNormasRow(drHRNormas)
      End If
   End Sub
#Region "Propiedades"
   Private Property _ConfigImprimir As ConfiguracionImprimir
   Public Property ConfigImprimir As ConfiguracionImprimir
      Get
         If _ConfigImprimir Is Nothing Then
            _ConfigImprimir = New ConfiguracionImprimir(0, 0)
         End If
         Return _ConfigImprimir
      End Get
      Set(value As ConfiguracionImprimir)
         _ConfigImprimir = value
      End Set
   End Property

#End Region
End Class
