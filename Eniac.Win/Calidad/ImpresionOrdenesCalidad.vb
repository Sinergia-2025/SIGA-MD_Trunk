Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock
Imports Eniac.Entidades
Imports Eniac.Reglas
Imports Microsoft.Reporting.WinForms
Public Class ImpresionOrdenesCalidad
   Public Sub ImprimirOrdenDeCalidad(OrdCalidad As Entidades.CalidadOrdenDeControl, Visualizar As Boolean)
      Dim reporteNombre As String = "Eniac.Win.OrdenDeCalidad.rdlc"
      Dim reporteEmbebido = True

      ImprimirOrdenDeCalidad(OrdCalidad, Visualizar, reporteNombre, reporteEmbebido)
   End Sub
   Private Function ConvierteTiempos(valTiempo As Decimal) As String
      Dim tt As TimeSpan = TimeSpan.FromHours(Decimal.ToDouble(valTiempo))
      Return String.Format("{0} Hs. {1} Min.", tt.Hours.ToString("00"), tt.Minutes.ToString("00"))
   End Function

   Public Sub ImprimirOrdenDeCalidad(OrdControlCalidad As Entidades.CalidadOrdenDeControl, Visualizar As Boolean, reporteNombre As String, reporteEmbebido As Boolean)
      Try
         Dim dtsAtributos = "DtsControlDeCalidad_dtAtributos"

         Dim parm = New ReportParameterCollection()
         '--
         parm.Add("TituloReporte", "Orden de Control de Calidad")
         '--
         parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
         'Dim eCentroProductor = New Reglas.MRPCentrosProductores().GetUno(OrdProdOper.CentroProductorOperacion)
         'parm.Add("CentroProduccion", String.Format("{0} {1}", eCentroProductor.CodigoCentroProductor, OrdProdOper.DescripcionCentro))
         Dim Prod = New Reglas.Productos().GetUno(OrdControlCalidad.IdProducto)
         parm.Add("IdProducto", String.Format("{0}   {1}", OrdControlCalidad.IdProducto, Prod.NombreProducto))
         'parm.Add("Operacion", String.Format("{0} {1}", OrdProdOper.CodigoProcProdOperacion, OrdProdOper.DescripcionOperacion))
         ''--
         parm.Add("Fecha", String.Format("{0}", OrdControlCalidad.Fecha.ToString()))
         parm.Add("IdLote", String.Format("{0}", IIf(OrdControlCalidad.IdLote Is Nothing, String.Empty, OrdControlCalidad.IdLote)))
         parm.Add("CantidadControlar", String.Format("{0}", OrdControlCalidad.CantidadControlar.ToString()))

         If OrdControlCalidad.IdProveedor.HasValue Then
            Dim Prov = New Reglas.Proveedores().GetUno(OrdControlCalidad.IdProveedor.IfNull())
            Dim OC As DataTable = New Reglas.PedidosEstadosProveedores().GetPedidosEstadosProveedoresPorComprobanteFact(OrdControlCalidad.IdSucursalCompra.IfNull(), OrdControlCalidad.IdTipoComprobanteCompra.ToString(),
                                                                 OrdControlCalidad.LetraCompra.ToString(), OrdControlCalidad.CentroEmisorCompra.IfNull(),
                                                                 OrdControlCalidad.NumeroComprobanteCompra.IfNull(), OrdControlCalidad.IdProducto, OrdControlCalidad.Fecha, OrdControlCalidad.OrdenComprobanteCompra.IfNull())
            If OC.Rows.Count = 0 Then
               parm.Add("IdProveedor", String.Format("{0} {1} ", OrdControlCalidad.IdProveedor.ToString(), Prov.NombreProveedor))
               parm.Add("Remito", "")
            Else
               parm.Add("IdProveedor", String.Format("{0} {1} O.Compra: {2} {3} {4} {5} {6} ", OrdControlCalidad.IdProveedor.ToString(), Prov.NombreProveedor,
                                                                 OC.Rows(0).Item("IdSucursal"), OC.Rows(0).Item("IdTipoComprobante"),
                                                                OC.Rows(0).Item("Letra"), OC.Rows(0).Item("CentroEmisor"),
                                                                OC.Rows(0).Item("NumeroPedido")))
               parm.Add("Remito", String.Format("{0}", String.Format(" {0} {1} {2} {3} {4}", OrdControlCalidad.IdSucursalCompra.ToString(), OrdControlCalidad.IdTipoComprobanteCompra.ToString(),
                                                                 OrdControlCalidad.LetraCompra.ToString(), OrdControlCalidad.CentroEmisorCompra,
                                                                 OrdControlCalidad.NumeroComprobanteCompra)))

            End If





         Else
            parm.Add("IdProveedor", String.Empty)
            parm.Add("Remito", String.Empty)
         End If
         parm.Add("Observaciones", String.Format("{0}", OrdControlCalidad.Observaciones.ToString()))

         Dim InformeCalidadNumero As String = String.Empty

         If Not String.IsNullOrEmpty(OrdControlCalidad.NumeroComprobanteCompra.ToString()) Then
            Try
               Dim COMP As Entidades.Compra = New Reglas.Compras().GetUna(OrdControlCalidad.IdSucursalCompra.IfNull(), OrdControlCalidad.IdTipoComprobanteCompra.ToString(),
                                                                               OrdControlCalidad.LetraCompra.ToString(), OrdControlCalidad.CentroEmisorCompra.IfNull(),
                                                                               OrdControlCalidad.NumeroComprobanteCompra.IfNull(), OrdControlCalidad.IdProveedor.IfNull())

               For Each produ As Entidades.CompraProducto In COMP.ComprasProductos
                  If produ.Producto.IdProducto = OrdControlCalidad.IdProducto Then
                     InformeCalidadNumero = produ.InformeCalidadNumero
                  End If
               Next
            Catch ex As Exception
            End Try
         End If

         parm.Add("Colada", String.Format("{0}", InformeCalidadNumero))

         ''-- Nro de Pedido si existe.- --------------------------------------------------------------------
         'If OrdProdOper.NumeroPedido > 0 Then
         '   parm.Add("Pedido", String.Format("{0} {1}", OrdProdOper.NumeroPedido, OrdProdOper.LineaPedido))
         'Else
         '   parm.Add("Pedido", String.Empty)
         'End If
         ''-------------------------------------------------------------------------------------------------
         'parm.Add("Cliente", String.Format("{0} - {1}", OrdProdOper.CodigoCliente, OrdProdOper.NombreCliente))
         'parm.Add("FechaEntrega", String.Format("{0}", OrdProdOper.FechaEntrega.ToString("dd/MM/yyyy")))

         '-- Atributos.- -------------------------------------------------------------------------
         Dim dtAtributos As New DtsControlDeCalidad.dtAtributosDataTable
         Dim drAtributos As DtsControlDeCalidad.dtAtributosRow

         For Each dr In OrdControlCalidad.CalidadOrdenDeControlItems
            drAtributos = dtAtributos.NewdtAtributosRow
            With drAtributos
               .IdListaControl = dr.IdListaControl
               .CantidadAceptacion = dr.CantidadAceptacion
               .CantidadRechazo = dr.CantidadRechazo
               .IdListaControl = dr.IdListaControl
               .NivelInspeccion = dr.NivelInspeccion.ToString()
               .NombreListaControlItem = dr.NombreListaControlItem
               .TamanoMuestreo = dr.TamanoMuestreo
               .ValorAQL = dr.ValorAQL
               .Observacion = dr.Observacion

            End With
            dtAtributos.AdddtAtributosRow(drAtributos)
         Next
         ''----------------------------------------------------------------------------------------------------
         'If Visualizar Then
         Using frmImprime = New VisorReportes(reporteNombre, dtsAtributos, dtAtributos, parm, reporteEmbebido, 1)
            frmImprime.Text = String.Empty
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
            frmImprime.rvReporte.ZoomMode = ZoomMode.FullPage
            frmImprime.ShowDialog()
         End Using
         'Else
         '   Dim imp As Imprimir = New Imprimir(ConfigImprimir)
         '   imp.Run(reporteNombre,
         '           dtsNecesarios,
         '           dtHRNecesarios,
         '           dtsNormasFabr,
         '           dtHRNormas,
         '           parm,
         '           reporteEmbebido,
         '           "",
         '           1,
         '           seteaMargenes:=False)
         'End If


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
