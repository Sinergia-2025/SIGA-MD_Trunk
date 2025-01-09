Imports Microsoft.Reporting.WinForms
Public Class ImpresionProcesosProductivosMRP

   Public Sub ImprimirProcesoProductivoOperacion(ProcProdOper As Entidades.MRPProcesoProductivoOperacion, Visualizar As Boolean)
      Dim reporteNombre As String = "Eniac.Win.HojaRutaMRP.rdlc"
      Dim reporteEmbebido = True
      '--
      _ImprimirProcesoProductivoOperacion(ProcProdOper, Visualizar, reporteNombre, reporteEmbebido)
      '--
   End Sub

   Public Sub _ImprimirProcesoProductivoOperacion(ProcProdOper As Entidades.MRPProcesoProductivoOperacion, Visualizar As Boolean, reporteNombre As String, reporteEmbebido As Boolean)
      Try
         Dim dtsNecesarios = "dtProductosNecesarios"
         Dim dtsNormasFabr = "dtNormasFabrica"

         Dim parm = New ReportParameterCollection()
         '--
         parm.Add("TituloReporte", "Proceso Productivo")
         '--
         parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
         Dim eCentroProductor = New Reglas.MRPCentrosProductores().GetUno(ProcProdOper.CentroProductorOperacion)
         parm.Add("CentroProduccion", String.Format("{0} {1}", eCentroProductor.CodigoCentroProductor, eCentroProductor.Descripcion))
         parm.Add("TipoCentroProduccion", String.Format("{0}", eCentroProductor.ClaseCentroProductor))
         parm.Add("CantidadControlesCentroProduccion", String.Format("{0}", eCentroProductor.CantidadControles))
         '--
         parm.Add("Articulo", String.Format("{0} {1}", ProcProdOper.IdProductoPrincipal, ProcProdOper.DescripcionProductoPrincipal))
         '--
         parm.Add("Operacion", String.Format("{0} {1}", ProcProdOper.CodigoProcProdOperacion, ProcProdOper.DescripcionOperacion))
         '--
         parm.Add("Cantidad", String.Format("1 UNID"))
         parm.Add("Lote", String.Format("{0}", String.Empty))
         '-- Nro de Pedido no existe.- --------------------------------------------------------------------
         parm.Add("Pedido", String.Empty)
         '-------------------------------------------------------------------------------------------------
         parm.Add("Cliente", "-")
         parm.Add("FechaEntrega", String.Format("{0}", Now.Date.ToString("dd/MM/yyyy")))
         '-- Calcula Valor Horas Totales Orden Produccion.- -------------------------------------------------
         If ProcProdOper.UnidadesHora = 0 Then
            parm.Add("TiempoTotal", String.Format("{0}", ConvierteTiempos(0)))
            parm.Add("TiempoPAP", String.Format("{0}", ConvierteTiempos(0)))
            parm.Add("Produccion", String.Format("{0} UNID/Hora", 0))
         Else
            Dim valorHHOrden = ProcProdOper.PAPTiemposHHombre + ProcProdOper.ProdTiemposHHombre
            '--
            parm.Add("TiempoTotal", String.Format("{0}", ConvierteTiempos(valorHHOrden)))
            parm.Add("TiempoPAP", String.Format("{0}", ConvierteTiempos(ProcProdOper.PAPTiemposHHombre)))
            parm.Add("Produccion", String.Format("{0} UNID/Hora", ProcProdOper.UnidadesHora.ToString("0")))
         End If
         '-- Productos Necesarios.- -------------------------------------------------------------------------
         Dim dtHRNecesarios As New DtsHojaRutaMRP.dtHojaRutaMRPDataTable
         Dim drHRNecesarios As DtsHojaRutaMRP.dtHojaRutaMRPRow
         For Each dr In ProcProdOper.ProductosNecesario
            drHRNecesarios = dtHRNecesarios.NewdtHojaRutaMRPRow
            With drHRNecesarios
               .IdProducto = dr.IdProductoProceso
               If dr.IdProductoProceso = ProcProdOper.IdProductoPrincipal Then
                  '-- Busca el codigo de Operacion Anterior.- --------------------
                  Dim operAnt = New Reglas.MRPProcesosProductivosOperaciones().GetUnaAnterior(ProcProdOper.IdProcesoProductivo, ProcProdOper.CodigoProcProdOperacion).CodigoProcProdOperacion
                  .CodigoOperacion = If(operAnt, "ANT")
               Else
                  .CodigoOperacion = "FIN"
               End If
               Dim eProdNecesario = New Reglas.Productos().GetUno(dr.IdProductoProceso, False, False, Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
               .DescripcionProducto = eProdNecesario.NombreProducto
               .Unidad = eProdNecesario.UnidadDeMedida.NombreUnidadDeMedida
               .Unitaria = dr.CantidadSolicitada.ToString()
               .Prevista = dr.CantidadSolicitada.ToString()
            End With
            dtHRNecesarios.AdddtHojaRutaMRPRow(drHRNecesarios)
         Next
         '-- Normas de Fabricacion.- -------------------------------------------------------------------------
         Dim dtHRNormas As New DtsHojaRutaMRP.dtHojaRutaNormasDataTable
         '-- Dispositivos.- --------------------------------
         CargaNormas("Dispositivos", ProcProdOper.NormasDispositivos, dtHRNormas)
         '-- Metodos.- --------------------------------
         CargaNormas("Métodos", ProcProdOper.NormasMetodos, dtHRNormas)
         '-- Seguridad.- --------------------------------
         CargaNormas("Seguridad", ProcProdOper.NormasSeguridad, dtHRNormas)
         '-- Control Calidad.- --------------------------------
         CargaNormas("Calidad", ProcProdOper.NormasControlCalidad, dtHRNormas)
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
   Private Function ConvierteTiempos(valTiempo As Decimal) As String
      Dim tt As TimeSpan = TimeSpan.FromHours(Decimal.ToDouble(valTiempo))
      Return String.Format("{0} Hs. {1} Min. {2} Seg.", tt.Hours.ToString("00"), tt.Minutes.ToString("00"), tt.Seconds.ToString("00"))
   End Function

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
