Public Class Retenciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Retenciones_I(idRetencion As Integer,
                            idSucursal As Integer, idTipoImpuesto As Entidades.TipoImpuesto.Tipos, emisorRetencion As Integer, numeroRetencion As Long,
                            fechaEmision As Date,
                            baseImponible As Decimal, alicuota As Decimal, importeTotal As Decimal,
                            idCajaIngreso As Integer, nroPlanillaIngreso As Integer, nroMovimientoIngreso As Integer,
                            idEstado As Entidades.Retencion.Estados, idCliente As Long,
                            idProvincia As String, idLocalidad As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.Retencion.NombreTabla)
         .AppendFormatLine("     IdRetencion")
         .AppendFormatLine("   , IdSucursal")
         .AppendFormatLine("   , IdTipoImpuesto")
         .AppendFormatLine("   , EmisorRetencion")
         .AppendFormatLine("   , NumeroRetencion")
         .AppendFormatLine("   , FechaEmision")
         .AppendFormatLine("   , BaseImponible")
         .AppendFormatLine("   , Alicuota")
         .AppendFormatLine("   , ImporteTotal")
         .AppendFormatLine("   , IdCajaIngreso")
         .AppendFormatLine("   , NroPlanillaIngreso")
         .AppendFormatLine("   , NroMovimientoIngreso")
         .AppendFormatLine("   , IdEstado")
         .AppendFormatLine("   , IdCliente")
         .AppendFormatLine("   , IdProvincia")
         .AppendFormatLine("   , IdLocalidad")
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0} ", idRetencion)
         .AppendFormatLine("   ,  {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoImpuesto.ToString())
         .AppendFormatLine("   ,  {0} ", emisorRetencion)
         .AppendFormatLine("   ,  {0} ", numeroRetencion)
         .AppendFormatLine("   , '{0}'", ObtenerFecha(fechaEmision, True))

         .AppendFormatLine("   ,  {0} ", baseImponible)
         .AppendFormatLine("   ,  {0} ", alicuota)
         .AppendFormatLine("   ,  {0} ", importeTotal)

         If nroPlanillaIngreso > 0 Then
            .AppendFormatLine("   ,  {0} ", idCajaIngreso)
            .AppendFormatLine("   ,  {0} ", nroPlanillaIngreso)
            .AppendFormatLine("   ,  {0} ", nroMovimientoIngreso)
         Else
            .AppendFormatLine("   , NULL")
            .AppendFormatLine("   , NULL")
            .AppendFormatLine("   , NULL")
         End If

         .AppendFormatLine("   , '{0}'", idEstado.ToString())
         .AppendFormatLine("   , '{0}'", idCliente)

         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idProvincia))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idLocalidad))
         .AppendFormatLine(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Retenciones")
   End Sub
   Public Sub Retenciones_U(idRetencion As Integer,
                            idSucursal As Integer, idTipoImpuesto As Entidades.TipoImpuesto.Tipos, emisorRetencion As Integer, numeroRetencion As Long,
                            fechaEmision As Date,
                            baseImponible As Decimal, alicuota As Decimal, importeTotal As Decimal,
                            idCajaIngreso As Integer, nroPlanillaIngreso As Integer, nroMovimientoIngreso As Integer,
                            idEstado As Entidades.Retencion.Estados, idCliente As Long,
                            idProvincia As String, idLocalidad As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Retencion.NombreTabla)

         .AppendFormatLine("   SET {0} =  {1} ", Entidades.Retencion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Retencion.Columnas.IdTipoImpuesto.ToString(), idTipoImpuesto.ToString())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.EmisorRetencion.ToString(), emisorRetencion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.NumeroRetencion.ToString(), numeroRetencion)

         .AppendFormatLine("     , {0} = '{1}'", Entidades.Retencion.Columnas.FechaEmision.ToString(), ObtenerFecha(fechaEmision, True))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.BaseImponible.ToString(), baseImponible)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.Alicuota.ToString(), alicuota)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.ImporteTotal.ToString(), importeTotal)

         If nroPlanillaIngreso > 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.IdCajaIngreso.ToString(), idCajaIngreso)
            .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.NroPlanillaIngreso.ToString(), nroPlanillaIngreso)
            .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.NroMovimientoIngreso.ToString(), nroMovimientoIngreso)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.Retencion.Columnas.IdCajaIngreso.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.Retencion.Columnas.NroPlanillaIngreso.ToString())
            .AppendFormatLine("     , {0} = NULL", Entidades.Retencion.Columnas.NroMovimientoIngreso.ToString())
         End If

         .AppendFormatLine("     , {0} = '{1}'", Entidades.Retencion.Columnas.IdEstado.ToString(), idEstado.ToString())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.IdCliente.ToString(), idCliente)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.IdProvincia.ToString(), GetStringParaQueryConComillas(idProvincia))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Retencion.Columnas.IdLocalidad.ToString(), GetStringFromNumber(idLocalidad))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Retencion.Columnas.IdRetencion.ToString(), idRetencion.ToString())
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Retenciones")
   End Sub
   Public Sub Retenciones_D(idRetencion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.Retencion.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.Retencion.Columnas.IdRetencion.ToString(), idRetencion.ToString())
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Retenciones")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT R.*")
         .AppendLine("     , TI.NombreTipoImpuesto")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , C.CUIT")
         .AppendLine("     , PV.IdProvincia")
         .AppendLine("     , PV.NombreProvincia")
         .AppendLine("     , L.IdLocalidad")
         .AppendLine("     , L.NombreLocalidad")
         .AppendLine("  FROM Retenciones R")
         .AppendLine("  LEFT JOIN TiposImpuestos TI ON R.IdTipoImpuesto = TI.IdTipoImpuesto")
         .AppendLine("  LEFT JOIN Clientes C ON R.IdCliente = C.IdCliente")
         .AppendLine("  LEFT JOIN Provincias PV ON PV.IdProvincia = R.IdProvincia")
         .AppendLine("  LEFT JOIN Localidades L ON L.IdLocalidad = R.IdLocalidad")
      End With
   End Sub

   Public Function Retenciones_G1(idRetencion As Integer) As DataTable
      Return Retenciones_G(idRetencion, idSucursal:=0, nroPlanilla:=0, nroMovimiento:=0,
                           idTipoImpuesto:=Nothing, emisorRetencion:=0, numeroRetencion:=0, idCliente:=0)
   End Function
   Public Function Retenciones_GA(idSucursal As Integer,
                                  idTipoImpuesto As Entidades.TipoImpuesto.Tipos, emisorRetencion As Integer, numeroRetencion As Long,
                                  idCliente As Long) As DataTable
      Return Retenciones_G(idRetencion:=0, idSucursal, nroPlanilla:=0, nroMovimiento:=0,
                           idTipoImpuesto, emisorRetencion, numeroRetencion, idCliente)
   End Function
   Public Function Retenciones_GA(idSucursal As Integer) As DataTable
      Return Retenciones_G(idRetencion:=0, idSucursal, nroPlanilla:=0, nroMovimiento:=0,
                           idTipoImpuesto:=Nothing, emisorRetencion:=0, numeroRetencion:=0, idCliente:=0)
   End Function
   Private Function Retenciones_G(idRetencion As Integer, idSucursal As Integer, nroPlanilla As Integer, nroMovimiento As Integer,
                                  idTipoImpuesto As Entidades.TipoImpuesto.Tipos?, emisorRetencion As Integer, numeroRetencion As Long, idCliente As Long) As DataTable
      Dim myQuery = New StringBuilder()
      SelectTexto(myQuery)
      With myQuery
         .AppendFormatLine(" WHERE 1 = 1")
         If idRetencion <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Retencion.Columnas.IdRetencion.ToString(), idRetencion.ToString())
         End If
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Retencion.Columnas.IdSucursal.ToString(), idSucursal.ToString())
         End If
         If nroPlanilla <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Retencion.Columnas.NroPlanillaIngreso.ToString(), nroPlanilla.ToString())
         End If
         If nroMovimiento <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Retencion.Columnas.NroMovimientoIngreso.ToString(), nroMovimiento.ToString())
         End If
         If idTipoImpuesto.HasValue Then
            .AppendFormatLine("   AND R.{0} = '{1}'", Entidades.Retencion.Columnas.IdTipoImpuesto.ToString(), idTipoImpuesto.Value)
         End If

         If emisorRetencion <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Retencion.Columnas.EmisorRetencion.ToString(), emisorRetencion.ToString())
         End If
         If numeroRetencion <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Retencion.Columnas.NumeroRetencion.ToString(), numeroRetencion.ToString())
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Retencion.Columnas.IdCliente.ToString(), idCliente.ToString())
         End If

         .AppendFormatLine(" ORDER BY R.IdSucursal, TI.NombreTipoImpuesto, R.EmisorRetencion, R.NumeroRetencion")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function GetPorMovimientoCaja(idSucursal As Integer, nroPlanilla As Integer, nroMovimiento As Integer) As DataTable
      Return Retenciones_G(idRetencion:=0, idSucursal, nroPlanilla, nroMovimiento,
                           idTipoImpuesto:=Nothing, emisorRetencion:=0, numeroRetencion:=0, idCliente:=0)
   End Function

   Public Function GetInformeRetenciones(idSucursal As Integer, fechaDesde As Date?, fechaHasta As Date?,
                            idTipoImpuesto As Entidades.TipoImpuesto.Tipos, idProvincia As String, idCliente As Long) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery)
      With stbQuery
         .AppendFormatLine(" WHERE R.{0} =  {1} ", Entidades.Retencion.Columnas.IdSucursal.ToString(), idSucursal)

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND R.{0} >= '{1}'", Entidades.Retencion.Columnas.FechaEmision.ToString(), ObtenerFecha(fechaDesde.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND R.{0} <= '{1}'", Entidades.Retencion.Columnas.FechaEmision.ToString(), ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If
         If idTipoImpuesto <> Entidades.TipoImpuesto.Tipos.Ninguno Then
            .AppendFormatLine("   AND R.{0} = '{1}'", Entidades.Retencion.Columnas.IdTipoImpuesto.ToString(), idTipoImpuesto.ToString())
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Retencion.Columnas.IdCliente.ToString, idCliente)
         End If
         If Not String.IsNullOrWhiteSpace(idProvincia) Then
            .AppendFormatLine("   AND R.{0} = '{1}'", Entidades.Retencion.Columnas.IdProvincia.ToString(), idProvincia)
         End If
         .AppendLine(" ORDER BY R.FechaEmision")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPorCuentaCorriente(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                         idCliente As Long) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" LEFT JOIN CuentasCorrientesRetenciones CCR")
         .AppendFormatLine("        ON R.idSucursal      = CCR.idSucursal")
         .AppendFormatLine("       AND R.IdTipoImpuesto  = CCR.IdTipoImpuesto")
         .AppendFormatLine("       AND R.EmisorRetencion = CCR.EmisorRetencion")
         .AppendFormatLine("       AND R.NumeroRetencion = CCR.NumeroRetencion")
         .AppendFormatLine("       AND R.IdCliente       = CCR.IdCliente")
         .AppendFormatLine(" WHERE CCR.{0} =  {1} ", Entidades.CuentaCorrienteRetencion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND CCR.{0} = '{1}'", Entidades.CuentaCorrienteRetencion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND CCR.{0} = '{1}'", Entidades.CuentaCorrienteRetencion.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND CCR.{0} =  {1} ", Entidades.CuentaCorrienteRetencion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND CCR.{0} =  {1} ", Entidades.CuentaCorrienteRetencion.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("   AND CCR.{0} =  {1} ", Entidades.CuentaCorrienteRetencion.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.Retencion.Columnas.IdRetencion.ToString(), Entidades.Retencion.NombreTabla).ToInteger()
   End Function

End Class