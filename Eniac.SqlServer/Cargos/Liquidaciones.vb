Public Class Liquidaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Liquidaciones_I(ByVal Periodo As Integer,
                              ByVal IdSucursal As Integer,
                              ByVal fecha As Date,
                              ByVal totalExpensas As Decimal,
                              ByVal totalAlquiler As Decimal,
                              ByVal totalServicios As Decimal,
                              ByVal TotalGastosAdmin As Decimal,
                              ByVal totalLiquidacion As Decimal,
                              ByVal totalAlquilerAnterior As Decimal,
                              ByVal totalAlquilerAnteriorCalculos As Decimal,
                              ByVal totalGastosOperativos As Decimal, _
                              ByVal idTipoLiquidacion As Integer)


      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("INSERT INTO Liquidaciones ")
         .AppendLine("           (PeriodoLiquidacion")
         .AppendLine("            ,IdSucursal")
         .AppendLine("           ,FechaLiquidacion")
         .AppendLine("           ,TotalExpensas")
         .AppendLine("           ,TotalAlquiler")
         .AppendLine("           ,TotalServicios")
         .AppendLine("           ,TotalGastosAdmin")
         .AppendLine("           ,TotalLiquidacion")
         .AppendLine("           ,TotalAlquilerAnterior")
         .AppendLine("           ,TotalAlquilerAnteriorCalculos")
         .AppendLine("           ,TotalGastosOperativos")
         .AppendLine("           ,IdTipoLiquidacion")
         .AppendLine(") VALUES ")
         .AppendLine(" ( " & Periodo.ToString())
         .AppendLine(" ," & IdSucursal.ToString())
         .AppendLine(" ,'" & Me.ObtenerFecha(fecha, True) & "'")
         .AppendLine(" ," & totalExpensas.ToString())
         .AppendLine(" ," & totalAlquiler.ToString())
         .AppendLine(" ," & totalServicios.ToString())
         .AppendLine(" ," & TotalGastosAdmin.ToString())
         .AppendLine(" ," & totalLiquidacion.ToString())
         .AppendLine(" ," & totalAlquilerAnterior.ToString())
         .AppendLine(" ," & totalAlquilerAnteriorCalculos.ToString())
         .AppendLine(" ," & totalGastosOperativos.ToString())
         .AppendLine(" ," & idTipoLiquidacion.ToString())
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Liquidaciones")

   End Sub

   Public Sub Liquidaciones_U(ByVal Periodo As Integer, ByVal IdSucursal As Integer, ByVal totalExpensas As Decimal, ByVal totalExpensasAdicEslora As Decimal, ByVal totalExpensasAdicPuntal As Decimal, _
                              ByVal totalAlquiler As Decimal, ByVal totalServicios As Decimal, ByVal TotalGastosAdmin As Decimal, ByVal TotalGastosIntermAlq As Decimal, _
                              ByVal totalLiquidacion As Decimal, ByVal totalAlquilerAnterior As Decimal, ByVal totalAlquilerAnteriorCalculos As Decimal, _
                              ByVal totalGastosOperativos As Decimal, ByVal cantAcciones As Integer, ByVal cantAccionesExpensas As Integer, _
                              ByVal cantAccionesAlquileres As Integer, ByVal cantAccionesInversionistas As Integer, ByVal importeAdicionalPorAccion As Decimal,
                              importeAdicionalPorAccionOtros As Decimal, ProcesoAlquileres As Boolean, ProcesoExpensas As Boolean, ByVal IdTipoLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("UPDATE Liquidaciones ")
         .AppendLine("   SET TotalExpensas = " & totalExpensas.ToString())
         .AppendLine("     , TotalExpensaAdicionalEslora = " & totalExpensasAdicEslora.ToString())
         .AppendLine("     , TotalExpensaAdicionalAlturaTotal = " & totalExpensasAdicPuntal.ToString())
         .AppendLine("     , TotalAlquiler = " & totalAlquiler.ToString())
         .AppendLine("     , TotalServicios = " & totalServicios.ToString())
         .AppendLine("     , TotalGastosAdmin = " & TotalGastosAdmin.ToString())
         .AppendLine("     , TotalGastosIntermAlq = " & TotalGastosIntermAlq.ToString())
         .AppendLine("     , TotalLiquidacion = " & totalLiquidacion.ToString())
         .AppendLine("     , TotalAlquilerAnterior = " & totalAlquilerAnterior.ToString())
         .AppendLine("     , TotalAlquilerAnteriorCalculos = " & totalAlquilerAnteriorCalculos.ToString())
         .AppendLine("     , TotalGastosOperativos = " & totalGastosOperativos.ToString())
         .AppendLine("     , CantAcciones = " & cantAcciones.ToString())
         .AppendLine("     , CantAccionesExpensas = " & cantAccionesExpensas.ToString())
         .AppendLine("     , CantAccionesAlquileres = " & cantAccionesAlquileres.ToString())
         .AppendLine("     , CantAccionesInversionistas = " & cantAccionesInversionistas.ToString())
         .AppendLine("     , ImporteGananciasAdicPorAccion = " & importeAdicionalPorAccion.ToString())
         .AppendLine("     , ImporteAdicionalPorAccionOtros = " & importeAdicionalPorAccionOtros.ToString())
         .AppendLine("     , ProcesoAlquileres = " & GetStringFromBoolean(ProcesoAlquileres))
         .AppendLine("     , ProcesoExpensas = " & GetStringFromBoolean(ProcesoExpensas))
         .AppendLine(" WHERE PeriodoLiquidacion = " & Periodo.ToString())
         .AppendLine(" AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
         .AppendLine("  AND IdSucursal = " & IdSucursal.ToString())

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Liquidaciones")

   End Sub

   Public Sub Liquidaciones_D(ByVal Periodo As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM Liquidaciones ")
         .AppendLine(" WHERE PeriodoLiquidacion = " & Periodo.ToString())
         .AppendLine(" AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
         .AppendLine("  AND IdSucursal = " & IdSucursal.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Liquidaciones")
   End Sub

   Public Sub Liquidaciones_U_DatosFacturacion(ByVal Periodo As Integer, ByVal IdSucursal As Integer, ByVal fecha As Date, ByVal TotalGastosNoGravado As Decimal, _
                                               ByVal TotalGastosIVA105 As Decimal, ByVal TotalGastosNeto105 As Decimal, _
                                               ByVal TotalGastosIVA210 As Decimal, ByVal TotalGastosNeto210 As Decimal, _
                                               ByVal TotalGastosIVA270 As Decimal, ByVal TotalGastosNeto270 As Decimal,
                                               idtipoLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Liquidaciones")
         If fecha > Date.Parse("1900-01-01") Then

            .AppendLine("   SET FechaFacturado = '" & Me.ObtenerFecha(fecha, True) & "'")
            .AppendLine("      ,TotalGastosNoGravado = " & TotalGastosNoGravado.ToString())
            .AppendLine("      ,TotalGastosIVA105 = " & TotalGastosIVA105.ToString())
            .AppendLine("      ,TotalGastosNeto105 = " & TotalGastosNeto105.ToString())
            .AppendLine("      ,TotalGastosIVA210 = " & TotalGastosIVA210.ToString())
            .AppendLine("      ,TotalGastosNeto210 = " & TotalGastosNeto210.ToString())
            .AppendLine("      ,TotalGastosIVA270 = " & TotalGastosIVA270.ToString())
            .AppendLine("      ,TotalGastosNeto270 = " & TotalGastosNeto270.ToString())
         Else
            .AppendLine("   SET FechaFacturado = NULL")
            .AppendLine("      ,TotalGastosNoGravado = NULL")
            .AppendLine("      ,TotalGastosIVA105 = NULL")
            .AppendLine("      ,TotalGastosNeto105 = NULL")
            .AppendLine("      ,TotalGastosIVA210 = NULL")
            .AppendLine("      ,TotalGastosNeto210 = NULL")
            .AppendLine("      ,TotalGastosIVA270 = NULL")
            .AppendLine("      ,TotalGastosNeto270 = NULL")
         End If
         .AppendLine(" WHERE PeriodoLiquidacion = " & Periodo.ToString())
         .AppendLine(" AND IdTipoLiquidacion = " & idtipoLiquidacion.ToString())
         .AppendLine("  AND IdSucursal = " & IdSucursal.ToString())
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT L.PeriodoLiquidacion")
         .AppendLine("      ,L.IdSucursal ")
         .AppendLine("      ,L.FechaLiquidacion")
         .AppendLine("      ,L.TotalExpensas")
         .AppendLine("      ,L.TotalAlquiler")
         .AppendLine("      ,L.TotalServicios")
         .AppendLine("      ,L.TotalGastosAdmin")
         .AppendLine("      ,L.TotalLiquidacion")
         .AppendLine("      ,L.FechaFacturado")
         .AppendLine("      ,L.TotalAlquilerAnterior")
         .AppendLine("      ,L.TotalGastosOperativos")
         .AppendLine("      ,L.TotalGastosNoGravado")
         .AppendLine("      ,L.TotalGastosIVA105")
         .AppendLine("      ,L.TotalGastosNeto105")
         .AppendLine("      ,L.TotalGastosIVA210")
         .AppendLine("      ,L.TotalGastosNeto210")
         .AppendLine("      ,L.TotalGastosIVA270")
         .AppendLine("      ,L.TotalGastosNeto270")
         .AppendLine("      ,L.IdTipoLiquidacion")
         .AppendLine("  FROM Liquidaciones L")
      End With
   End Sub

   Public Function Liquidaciones_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY L.PeriodoLiquidacion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Liquidaciones_G1(ByVal PeriodoLiquidacion As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE L.PeriodoLiquidacion = " & PeriodoLiquidacion.ToString())
         .AppendLine(" AND L.IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
         .AppendLine("  AND IdSucursal = " & IdSucursal.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "L." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub Liquidaciones_D_Ultima(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)

      Dim Periodo As Integer = Me.GetUltimoPeriodoLiquidacion(IdTipoLiquidacion)

      If Not (IsNothing(Periodo)) Then
         Dim myQuery As StringBuilder = New StringBuilder("")

         With myQuery
            .AppendLine("DELETE FROM Liquidaciones ")
            .AppendLine(" WHERE PeriodoLiquidacion = " & Periodo.ToString())
            .AppendLine(" AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
            .AppendLine("  AND IdSucursal = " & IdSucursal.ToString())

         End With

         Me.Execute(myQuery.ToString())
         Me.Sincroniza_I(myQuery.ToString(), "Liquidaciones")
      End If
   End Sub

   Public Function GetUltimoPeriodoLiquidacion(ByVal IdTipoLiquidacion As Integer) As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      With stb

         .AppendLine("SELECT MAX(PeriodoLiquidacion) maximo FROM Liquidaciones WHERE IdSucursal = " + Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString())
         .AppendLine(" AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
         Return Integer.Parse(dt.Rows(0)("maximo").ToString())
      Else
         Return Nothing
      End If
   End Function

   Public Function GetUltimaLiquidacion(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT MAX(PeriodoLiquidacion) maximo FROM Liquidaciones")
         .AppendLine("  WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine(" AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
         Return Integer.Parse(dt.Rows(0)("maximo").ToString())
      Else
         Return Nothing
      End If
   End Function

   Public Function GetLiquidacionParaFacturar(ByVal Periodo As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT K.PeriodoLiquidacion")
         .AppendLine("      ,K.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.CodigoClienteLetras")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,K.ImporteExpensas")
         .AppendLine("      ,K.ImporteServicios")
         .AppendLine("      ,K.ImporteGastosAdmin")
         .AppendLine("      ,(CASE WHEN K.ImporteAlquiler = 0 THEN K.ImporteTotal-K.ImporteExpensas ELSE K.ImporteTotal-K.ImporteAlquiler END) AS ImporteVarios")
         .AppendLine("      ,K.ImporteAlquiler")
         .AppendLine("      ,K.ImporteTotal")
         .AppendLine("      ,K.IdSucursal")
         .AppendLine("      ,K.IdLiquidacionCargo")
         .AppendLine("      ,K.ImporteTotalAdicionales")
         .AppendLine("      ,K.IdTipoComprobante	")
         .AppendLine("      ,K.Letra	")
         .AppendLine("      ,K.CentroEmisor	")
         .AppendLine("      ,K.NumeroComprobante")
         .AppendLine("      ,K.SegundoVto")
         .AppendLine("      ,k.IdTipoLiquidacion")
         .AppendLine("  FROM LiquidacionesCargos K")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = K.IdCliente")
         .AppendLine(" INNER JOIN Categorias CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine(" WHERE K.PeriodoLiquidacion = " & Periodo.ToString)
         .AppendLine("   AND K.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND K.IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())

         '# Traigo solo los que el cliente seleccionó previamente para liquidar
         .AppendLine("   AND K.Selecciono = 'SI'")

         .AppendLine(" ORDER BY C.NombreCliente")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetCargosUltimaLiquidacion(ByVal IdSucursal As Integer, ByVal periodo As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT LC.IdLiquidacionCargo")
         .AppendLine("      ,LC.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.CodigoClienteLetras")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,LC.NombreCategoria")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,LC.CantidadDePCs")
         .AppendLine("      ,LC.ImporteTotal AS Importe")
         .AppendLine("  FROM LiquidacionesCargos LC")
         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = LC.IdCliente")
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica")
         .AppendLine(" WHERE LC.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND LC.PeriodoLiquidacion = " & periodo.ToString())
         .AppendLine("   ANd LC.IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())

         '# Traigo solo los cargos que el usuario liquidó
         .AppendLine("   AND LC.Selecciono = 'SI'")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
End Class
