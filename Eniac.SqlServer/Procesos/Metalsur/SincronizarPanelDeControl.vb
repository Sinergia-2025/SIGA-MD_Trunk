Public Class SincronizarPanelDeControl
   Inherits Comunes
   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub


   Public Function GetCabecerasBejerman(nombreBase As String,
                                        fechaModificacionDesde As DateTime?,
                                        fechaModificacionHasta As DateTime?,
                                        fechaIngresoDesde As DateTime?,
                                        fechaIngresoHasta As DateTime?) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT C.*")
         .AppendFormatLine("  FROM {0}Vista_OCCabecera C", nombreBase)
         .AppendFormatLine(" WHERE 1 = 1")

         .AppendFormatLine("   AND C.spc_Orig = 'O'")   '' Traemos solo las OC que tienen número Original // "Blanco = sin numeración / O=Original / T=Transitorio / R=Revertido / C=ContraAsiento"

         '# Fecha de Ingreso
         If fechaIngresoDesde.HasValue Then
            .AppendFormatLine("   AND C.scc_FIngreso >= '{0}'", ObtenerFecha(fechaIngresoDesde.Value, True))
         End If
         If fechaIngresoHasta.HasValue Then
            .AppendFormatLine("   AND C.scc_FIngreso <= '{0}'", ObtenerFecha(fechaIngresoHasta.Value, True))
         End If

         '# Fecha de Modificación
         If fechaModificacionDesde.HasValue Then
            .AppendFormatLine("   AND C.scc_FecMod >= '{0}'", ObtenerFecha(fechaModificacionDesde.Value, True))
         End If
         If fechaModificacionHasta.HasValue Then
            .AppendFormatLine("   AND C.scc_FecMod <= '{0}'", ObtenerFecha(fechaModificacionHasta.Value, True))
         End If

         .AppendFormatLine(" ORDER BY C.scc_FecMod ASC")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetDetallesBejerman(nombreBase As String,
                                       fechaDesde As DateTime?,
                                       fechaHasta As DateTime?) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT D.*")
         .AppendFormatLine("  FROM {0}Vista_OCCabecera C", nombreBase)
         .AppendFormatLine(" INNER JOIN {0}Vista_OCDetalle D ON C.spcemp_Codigo   = D.spcemp_Codigo", nombreBase)
         .AppendFormatLine("                                AND C.spcsuc_Cod      = D.spcsuc_Cod")
         .AppendFormatLine("                                AND C.spcscc_ID       = D.spcscc_ID")
         .AppendFormatLine("                                AND C.spctco_Circuito = D.spctco_Circuito")
         .AppendFormatLine("                                AND C.spctco_Cod      = D.spctco_Cod")

         .AppendFormatLine(" WHERE 1 = 1")

         .AppendFormatLine("   AND C.spc_Orig = 'O'")   '' Traemos solo las OC que tienen número Original // "Blanco = sin numeración / O=Original / T=Transitorio / R=Revertido / C=ContraAsiento"

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND C.scc_FecMod >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND C.scc_FecMod <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         .AppendFormatLine(" ORDER BY C.scc_FecMod ASC, D.sdc_NReng")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetProveedoresBejerman(nombreBase As String,
                                          fechaDesde As DateTime?,
                                          fechaHasta As DateTime?) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT P.*")
         .AppendFormatLine("  FROM {0}Vista_OCProveed P", nombreBase)
         .AppendFormatLine(" WHERE 1 = 1")

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND P.pro_FecMod >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND P.pro_FecMod <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         .AppendFormatLine(" ORDER BY P.pro_FecMod ASC")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetProveedoresSIGA(fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT P.*")
         .AppendFormatLine("  FROM Proveedores P")
         .AppendFormatLine(" WHERE 1 = 1")

         'If fechaDesde.HasValue Then
         '   .AppendFormatLine("   AND P.pro_FecMod >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         'End If
         'If fechaHasta.HasValue Then
         '   .AppendFormatLine("   AND P.pro_FecMod <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         'End If

         '.AppendFormatLine(" ORDER BY P.pro_FecMod ASC")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetCabeceraSIGA(fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P.*")
         .AppendFormatLine("  FROM PedidosProveedores P")
         .AppendFormatLine(" WHERE 1 = 1")

         'If fechaDesde.HasValue Then
         '   .AppendFormatLine("   AND P.pro_FecMod >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         'End If
         'If fechaHasta.HasValue Then
         '   .AppendFormatLine("   AND P.pro_FecMod <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         'End If

         '.AppendFormatLine(" ORDER BY P.pro_FecMod ASC")

      End With

      Return GetDataTable(stb)

   End Function


   Public Function GetDetalleSIGA(fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT P.*, PE.IdEstado")
         .AppendFormatLine("  FROM PedidosProductosProveedores P")

         .AppendFormatLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = P.IdSucursal")
         .AppendFormatLine("                                        AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("                                        AND PE.Letra = P.Letra")
         .AppendFormatLine("                                        AND PE.CentroEmisor = P.CentroEmisor")
         .AppendFormatLine("                                        AND PE.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine("                                        AND PE.IdProducto = P.IdProducto")
         .AppendFormatLine("                                        AND PE.Orden = P.Orden")

         .AppendFormatLine(" WHERE 1 = 1")

         'If fechaDesde.HasValue Then
         '   .AppendFormatLine("   AND P.pro_FecMod >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         'End If
         'If fechaHasta.HasValue Then
         '   .AppendFormatLine("   AND P.pro_FecMod <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         'End If

         '.AppendFormatLine(" ORDER BY P.pro_FecMod ASC")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetVistaProveedores(nombreBase As String, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT P.*")
         .AppendFormatLine("  FROM {0}Vista_OCProveed P", nombreBase)
         .AppendFormatLine(" WHERE 1 = 1")

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND P.pro_FecMod >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND P.pro_FecMod <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         .AppendFormatLine(" ORDER BY P.pro_FecMod ASC")

      End With

      Return GetDataTable(stb)
   End Function


   Public Function GetVistaDetalles(nombreBase As String,
                                       fechaDesdeModificacion As DateTime?,
                                       fechaHastaModificacion As DateTime?, fechaDesdeIngreso As DateTime?,
                                       fechaHastaIngreso As DateTime?) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT D.*")
         .AppendFormatLine("  FROM {0}Vista_OCCabecera C", nombreBase)

         .AppendFormatLine(" WHERE 1 = 1")

         .AppendFormatLine("   AND C.spc_Orig = 'O'")   '' Traemos solo las OC que tienen número Original // "Blanco = sin numeración / O=Original / T=Transitorio / R=Revertido / C=ContraAsiento"

         If fechaDesdeModificacion.HasValue Then
            .AppendFormatLine("   AND C.scc_FecMod >= '{0}'", ObtenerFecha(fechaDesdeModificacion.Value, True))
         End If
         If fechaHastaModificacion.HasValue Then
            .AppendFormatLine("   AND C.scc_FecMod <= '{0}'", ObtenerFecha(fechaHastaModificacion.Value, True))
         End If
         If fechaDesdeIngreso.HasValue Then
            .AppendFormatLine("   AND C.scc_FIngreso >= '{0}'", ObtenerFecha(fechaDesdeIngreso.Value, True))
         End If
         If fechaHastaIngreso.HasValue Then
            .AppendFormatLine("   AND C.scc_FIngreso <= '{0}'", ObtenerFecha(fechaHastaIngreso.Value, True))
         End If
         .AppendFormatLine(" ORDER BY C.scc_FecMod ASC, D.sdc_NReng")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetVistaCabeceras(nombreBase As String,
                                       fechaDesdeModificacion As DateTime?,
                                       fechaHastaModificacion As DateTime?, fechaDesdeIngreso As DateTime?,
                                       fechaHastaIngreso As DateTime?) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT C.*")
         .AppendFormatLine("  FROM {0}Vista_OCCabecera C", nombreBase)
         .AppendFormatLine(" WHERE 1 = 1")

         .AppendFormatLine("   AND C.spc_Orig = 'O'")   '' Traemos solo las OC que tienen número Original // "Blanco = sin numeración / O=Original / T=Transitorio / R=Revertido / C=ContraAsiento"

         If fechaDesdeModificacion.HasValue Then
            .AppendFormatLine("   AND C.scc_FecMod >= '{0}'", ObtenerFecha(fechaDesdeModificacion.Value, True))
         End If
         If fechaHastaModificacion.HasValue Then
            .AppendFormatLine("   AND C.scc_FecMod <= '{0}'", ObtenerFecha(fechaHastaModificacion.Value, True))
         End If
         If fechaDesdeIngreso.HasValue Then
            .AppendFormatLine("   AND C.scc_FIngreso >= '{0}'", ObtenerFecha(fechaDesdeIngreso.Value, True))
         End If
         If fechaHastaIngreso.HasValue Then
            .AppendFormatLine("   AND C.scc_FIngreso <= '{0}'", ObtenerFecha(fechaHastaIngreso.Value, True))
         End If
         .AppendFormatLine(" ORDER BY C.scc_FecMod ASC")

      End With

      Return GetDataTable(stb)
   End Function

End Class