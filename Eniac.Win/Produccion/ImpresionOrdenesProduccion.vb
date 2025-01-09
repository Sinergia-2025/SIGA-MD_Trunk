Public Class ImpresionOrdenesProduccion

   Public Sub ImprimirOrdenProduccionDetallado(oOrdenProduccion As Entidades.OrdenProduccion, visualizar As Boolean)
      ImprimirOrdenProduccion(oOrdenProduccion, visualizar, "Eniac.Win.OrdenProduccionDetalle.rdlc", True)
   End Sub
   Public Sub ImprimirOrdenProduccion(oOrdenProduccion As Entidades.OrdenProduccion, visualizar As Boolean)
      Dim tipoLetra = New Reglas.TiposComprobantesLetras().GetUno(oOrdenProduccion.TipoComprobante.IdTipoComprobante, oOrdenProduccion.LetraComprobante)

      Dim reporteNombre = "Eniac.Win.OrdenProduccion.rdlc"
      Dim reporteEmbebido = True

      If tipoLetra IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(tipoLetra.ArchivoAImprimir) Then
         reporteNombre = tipoLetra.ArchivoAImprimir
         reporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
         ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir, tipoLetra.DesplazamientoYArchivoAImprimir)
         If Not reporteEmbebido Then
            reporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
         End If
      End If

      ImprimirOrdenProduccion(oOrdenProduccion, visualizar, reporteNombre, reporteEmbebido)
   End Sub
   Private Sub ImprimirOrdenProduccion(oOrdenProduccion As Entidades.OrdenProduccion, visualizar As Boolean, reporteNombre As String, reporteEmbebido As Boolean)
      Dim reporteDataSource = "dtsOrdenProduccion_dtOrdenProduccion"
      Dim titulo = oOrdenProduccion.TipoComprobante.Descripcion

      Dim sucursal = New Reglas.Sucursales().GetUna(oOrdenProduccion.IdSucursal, False)

      Using dtReporte = New Reglas.OrdenesProduccionProductos().GetOrdenesProduccionProductos(oOrdenProduccion.IdSucursal, oOrdenProduccion.IdTipoComprobante, oOrdenProduccion.LetraComprobante,
                                                                                              oOrdenProduccion.CentroEmisor, oOrdenProduccion.NumeroOrdenProduccion)
         Using dtDetalle = dtReporte.Clone()
            For Each drRep In dtReporte.AsEnumerable
               dtDetalle.AddCopy(drRep)
               If Reglas.Publicos.DetalleProduccion.ImprimirComponentesNecesarios Then
                  'MULTIDEPOSITO: CAMBIAR PARA QUE BUSQUE EN OrdenesProduccionProductosFormulas EN LUGAR DE ProductosComponentes
                  Using dtPC = New Reglas.ProductosComponentes().GetComponentes(oOrdenProduccion.IdSucursal, drRep.Field(Of String)("IdProducto"),
                                                                                drRep.Field(Of Integer)("IdFormula"), drRep.Field(Of Integer)("IdListaPrecios"))
                     For Each drPC In dtPC.AsEnumerable()
                        Dim drCompImp = dtDetalle.NewRow()
                        drCompImp("NombreProducto") = "    " + drPC.Field(Of String)("NombreProducto")
                        Dim cantidad = If(Reglas.Publicos.DetalleProduccion.CantidadNecesariaUnitaria, 1, drRep.Field(Of Decimal)("Cantidad"))
                        drCompImp("Cantidad") = drPC.Field(Of Decimal)("Cantidad") * cantidad
                        dtDetalle.Rows.Add(drCompImp)
                     Next
                  End Using
                  For i = 0 To Reglas.Publicos.DetalleProduccion.CantidadLineaSeparacion - 1
                     Dim drCompImp = dtDetalle.NewRow()
                     dtDetalle.Rows.Add(drCompImp)
                  Next
               End If
            Next

            Dim dtVO = New SistemaDataSet.VentasObservacionesDataTable()
            For Each vo In oOrdenProduccion.OrdenesProduccionObservaciones
               Dim drVO = dtVO.NewVentasObservacionesRow()

               drVO.IdSucursal = vo.IdSucursal
               drVO.IdTipoComprobante = vo.IdTipoComprobante
               drVO.Letra = vo.Letra
               drVO.CentroEmisor = vo.CentroEmisor
               drVO.NumeroComprobante = vo.NumeroOrdenProduccion
               drVO.Linea = vo.Linea
               drVO.Observacion = vo.Observacion

               dtVO.AddVentasObservacionesRow(drVO)
            Next

            Dim parm = New ReportParameterCollection()
            parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion)
            parm.Add("DireccionEmpresa", Reglas.Publicos.DireccionEmpresa)
            parm.Add("TelefonoEmpresa", sucursal.Telefono)
            parm.Add("fechaOrdenProduccion", oOrdenProduccion.Fecha.ToString("dd/MM/yyyy")) '.ToShortDateString())
            parm.Add("doc", oOrdenProduccion.Cliente.CodigoCliente)
            parm.Add("nombre", oOrdenProduccion.Cliente.NombreCliente)
            parm.Add("IdTipoComprobante", oOrdenProduccion.IdTipoComprobante)
            parm.Add("Letra", oOrdenProduccion.LetraComprobante)
            parm.Add("CentroEmisor", oOrdenProduccion.CentroEmisor)
            parm.Add("NumeroOrdenProduccion", oOrdenProduccion.NumeroOrdenProduccion)
            parm.Add("ObservacionOrdenProduccion", oOrdenProduccion.Observacion)
            parm.Add("NumeroOrdenCompra", oOrdenProduccion.NumeroOrdenCompra)

            Dim cliente = New Reglas.Clientes().GetUnoPorCodigo(oOrdenProduccion.Cliente.CodigoCliente)
            parm.Add("Direccion", cliente.Direccion)
            parm.Add("Localidad", cliente.NombreLocalidad)

            Dim localidad = New Reglas.Localidades().GetUna(cliente.IdLocalidad)
            parm.Add("Provincia", localidad.NombreProvincia)
            parm.Add("CategoriaIVA", cliente.CategoriaFiscal.NombreCategoriaFiscal)
            parm.Add("Cuit", cliente.Cuit)

            If oOrdenProduccion.IdFormaPago.HasValue AndAlso oOrdenProduccion.FormaPago IsNot Nothing Then
               parm.Add("FormaPago", oOrdenProduccion.FormaPago.DescripcionFormasPago)
            Else
               parm.Add("FormaPago", String.Empty)
            End If
            If oOrdenProduccion.Vendedor IsNot Nothing Then
               parm.Add("Vendedor", oOrdenProduccion.Vendedor.NombreEmpleado)
            Else
               parm.Add("Vendedor", String.Empty)
            End If


            If visualizar Then
               'Using frmImprime = New VisorReportes(reporteNombre, reporteDataSource, dtReporte, "SistemaDataSet_VentasObservaciones", dtVO, parm, reporteEmbebido, 1) '# 1 = Cantidad Copias
               Using frmImprime = New VisorReportes(reporteNombre, reporteDataSource, dtDetalle, "SistemaDataSet_VentasObservaciones", dtVO, parm, reporteEmbebido, 1) '# 1 = Cantidad Copias
                  frmImprime.Text = titulo
                  frmImprime.rvReporte.DocumentMapCollapsed = True
                  frmImprime.Size = New Size(780, 600)
                  frmImprime.StartPosition = FormStartPosition.CenterScreen
                  frmImprime.WindowState = FormWindowState.Maximized

                  frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout

                  frmImprime.ShowDialog()
               End Using
            Else
               Dim imp = New Imprimir(ConfigImprimir)
               imp.Run(reporteNombre, reporteDataSource, dtReporte, parm, reporteEmbebido, "", oOrdenProduccion.TipoComprobante.CantidadCopias)
            End If
         End Using
      End Using
   End Sub

   Public Sub New()
      _ConfigImprimir = New ConfiguracionImprimir(0, 0)
   End Sub
#Region "Propiedades"
   Public Property ConfigImprimir As ConfiguracionImprimir
#End Region
End Class