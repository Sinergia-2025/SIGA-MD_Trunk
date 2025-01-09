Public Class RepartosComprobantes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub RepartosComprobantes_I(idSucursal As Integer,
                                     idReparto As Integer,
                                     orden As Integer,
                                     idTipoComprobantePedido As String,
                                     letraPedido As String,
                                     centroEmisorPedido As Short?,
                                     numeroPedido As Long?,
                                     idTipoComprobanteFact As String,
                                     letraFact As String,
                                     centroEmisorFact As Short?,
                                     numeroComprobante As Long?,
                                     idSucursalRecibo As Integer?,
                                     idTipoComprobanteRecibo As String,
                                     letraRecibo As String,
                                     centroEmisorRecibo As Short?,
                                     numeroComprobanteRecibo As Long?,
                                     importeTotalFact As Decimal?,
                                     importeTotalRecibo As Decimal?)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.RepartoComprobante.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.RepartoComprobante.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.IdReparto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.Orden.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.IdTipoComprobantePedido.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.LetraPedido.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.CentroEmisorPedido.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.NumeroPedido.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.IdTipoComprobanteFact.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.LetraFact.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.CentroEmisorFact.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.IdSucursalRecibo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.IdTipoComprobanteRecibo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.LetraRecibo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.CentroEmisorRecibo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.NumeroComprobanteRecibo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.ImporteTotalFact.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobante.Columnas.ImporteTotalRecibo.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           , {0} ", idReparto)

         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(idTipoComprobantePedido))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(letraPedido))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(centroEmisorPedido))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(numeroPedido))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(idTipoComprobanteFact))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(letraFact))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(centroEmisorFact))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(numeroComprobante))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(idSucursalRecibo))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(idTipoComprobanteRecibo))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(letraRecibo))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(centroEmisorRecibo))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(numeroComprobanteRecibo))
         .AppendFormatLine("           , {0} ", GetStringFromDecimal(importeTotalFact))
         .AppendFormatLine("           , {0} ", GetStringFromDecimal(importeTotalRecibo))

         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosComprobantes_U(idSucursal As Integer,
                                     idReparto As Integer,
                                     orden As Integer,
                                     idTipoComprobantePedido As String,
                                     letraPedido As String,
                                     centroEmisorPedido As Short?,
                                     numeroPedido As Long?,
                                     idTipoComprobanteFact As String,
                                     letraFact As String,
                                     centroEmisorFact As Short?,
                                     numeroComprobante As Long?,
                                     idSucursalRecibo As Integer?,
                                     idTipoComprobanteRecibo As String,
                                     letraRecibo As String,
                                     centroEmisorRecibo As Short?,
                                     numeroComprobanteRecibo As Long?,
                                     importeTotalFact As Decimal?,
                                     importeTotalRecibo As Decimal?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.RepartoComprobante.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdTipoComprobantePedido.ToString(), GetStringParaQueryConComillas(idTipoComprobantePedido))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.LetraPedido.ToString(), GetStringParaQueryConComillas(letraPedido))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.CentroEmisorPedido.ToString(), GetStringFromNumber(centroEmisorPedido))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.NumeroPedido.ToString(), GetStringFromNumber(numeroPedido))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdTipoComprobanteFact.ToString(), GetStringParaQueryConComillas(idTipoComprobanteFact))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.LetraFact.ToString(), GetStringParaQueryConComillas(letraFact))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.CentroEmisorFact.ToString(), GetStringFromNumber(centroEmisorFact))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.NumeroComprobante.ToString(), GetStringFromNumber(numeroComprobante))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdSucursalRecibo.ToString(), GetStringFromNumber(idSucursalRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdTipoComprobanteRecibo.ToString(), GetStringParaQueryConComillas(idTipoComprobanteRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.LetraRecibo.ToString(), GetStringParaQueryConComillas(letraRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.CentroEmisorRecibo.ToString(), GetStringFromNumber(centroEmisorRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.NumeroComprobanteRecibo.ToString(), GetStringFromNumber(numeroComprobanteRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.ImporteTotalFact.ToString(), GetStringFromDecimal(importeTotalFact))

         If importeTotalRecibo.HasValue Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobante.Columnas.ImporteTotalRecibo.ToString(), GetStringFromDecimal(importeTotalRecibo))
         Else
            .AppendLine("     , NULL")
         End If

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoComprobante.Columnas.Orden.ToString(), orden)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub RepartosComprobantes_D(idSucursal As Integer, idReparto As Integer)
      RepartosComprobantes_D(idSucursal, idReparto, -1)
   End Sub

   Public Sub RepartosComprobantes_D(idSucursal As Integer, idReparto As Integer, orden As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM RepartosComprobantes ")
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND {0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdReparto.ToString(), idReparto)
         If orden >= 0 Then
            .AppendFormat("   AND {0} =  {1} ", Entidades.RepartoComprobante.Columnas.Orden.ToString(), orden)
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub
#End Region

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RC.*")
         .AppendFormatLine("  FROM {0} AS RC", Entidades.RepartoComprobante.NombreTabla)
      End With
   End Sub

#Region "GetAll"
   'Public Function RepartosComprobantes_GA(idSucursal As Integer) As DataTable
   '   Return RepartosComprobantes_G(idSucursal, idReparto:=0, orden:=0)
   'End Function
   Public Function RepartosComprobantes_GA(idSucursal As Integer, idReparto As Integer) As DataTable
      Return RepartosComprobantes_G(idSucursal, idReparto, orden:=0,
                                    idSucursalPedido:=0, idTipoComprobantePedido:=String.Empty, letraPedido:=String.Empty, centroEmisorPedido:=0, numeroPedido:=0)
   End Function
   Private Function RepartosComprobantes_G(idSucursal As Integer, idReparto As Integer, orden As Integer,
                                           idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Short, numeroPedido As Long) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND  RC.{0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdReparto.ToString(), idReparto)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND  RC.{0} =  {1} ", Entidades.RepartoComprobante.Columnas.Orden.ToString(), orden)
         End If
         If idSucursalPedido <> 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RepartoComprobante.Columnas.IdSucursal.ToString(), idSucursalPedido)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobantePedido) Then
            .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RepartoComprobante.Columnas.IdTipoComprobantePedido.ToString(), idTipoComprobantePedido)
         End If
         If Not String.IsNullOrWhiteSpace(letraPedido) Then
            .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RepartoComprobante.Columnas.LetraPedido.ToString(), letraPedido)
         End If
         If centroEmisorPedido <> 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RepartoComprobante.Columnas.CentroEmisorPedido.ToString(), centroEmisorPedido)
         End If
         If numeroPedido <> 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RepartoComprobante.Columnas.NumeroPedido.ToString(), numeroPedido)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function RepartosComprobantes_G1(idSucursal As Integer, idReparto As Integer, orden As Integer) As DataTable
      Return RepartosComprobantes_G(idSucursal, idReparto, orden,
                                    idSucursalPedido:=0, idTipoComprobantePedido:=String.Empty, letraPedido:=String.Empty, centroEmisorPedido:=0, numeroPedido:=0)
   End Function

   Public Function RepartosComprobantes_G_PorPedido(idSucursal As Integer,
                                                    idTipoComprobante As String,
                                                    letra As String,
                                                    centroEmisor As Short,
                                                    numeroPedido As Long) As DataTable
      Return RepartosComprobantes_G(idSucursal:=0, idReparto:=0, orden:=0,
                                    idSucursalPedido:=idSucursal, idTipoComprobantePedido:=idTipoComprobante, letraPedido:=letra, centroEmisorPedido:=centroEmisor, numeroPedido:=numeroPedido)
   End Function


   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "CategoriaParametro" Or columna = "DescripcionParametro" Then
      '   columna = "P." + columna
      'ElseIf columna = "ValorParametroOriginal" Then
      '   columna = "P.ValorParametro"
      'Else
      columna = "RC." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
#End Region

   Public Overloads Function GetCodigoMaximo(idSucursal As Integer, idReparto As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.RepartoComprobante.Columnas.Orden.ToString(),
                                             Entidades.RepartoComprobante.NombreTabla,
                                             String.Format("{0} = {1} AND {2} = {3}",
                                                           Entidades.RepartoComprobante.Columnas.IdSucursal.ToString(), idSucursal,
                                                           Entidades.RepartoComprobante.Columnas.IdReparto.ToString(), idReparto)))
   End Function

   Public Sub ActualizarComprobantePorComprobante(idSucursal As Integer,
                                                  idTipoComprobanteActual As String,
                                                  letraActual As String,
                                                  centroEmisorActual As Integer,
                                                  numeroComprobanteActual As Long,
                                                  idTipoComprobanteNuevo As String,
                                                  letraNuevo As String,
                                                  centroEmisorNuevo As Integer,
                                                  numeroComprobanteNuevo As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE RepartosComprobantes")
         .AppendFormatLine("   SET IdTipoComprobanteFact = '{0}'", idTipoComprobanteNuevo)
         .AppendFormatLine("      ,LetraFact = '{0}'", letraNuevo)
         .AppendFormatLine("      ,CentroEmisorFact = {0}", centroEmisorNuevo)
         .AppendFormatLine("      ,NumeroComprobante = {0}", numeroComprobanteNuevo)
         .AppendFormatLine("   WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("     AND IdTipoComprobanteFact = '{0}'", idTipoComprobanteActual)
         .AppendFormatLine("     AND LetraFact = '{0}'", letraActual)
         .AppendFormatLine("     AND CentroEmisorFact = {0}", centroEmisorActual)
         .AppendFormatLine("     AND NumeroComprobante = {0}", numeroComprobanteActual)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ActualizarReciboPorRecibo(idSucursalActual As Integer,
                                        idTipoComprobanteActual As String,
                                        letraActual As String,
                                        centroEmisorActual As Integer,
                                        numeroComprobanteActual As Long,
                                        idSucursalNuevo As Integer,
                                        idTipoComprobanteNuevo As String,
                                        letraNuevo As String,
                                        centroEmisorNuevo As Integer,
                                        numeroComprobanteNuevo As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE RepartosComprobantes")
         .AppendFormatLine("   SET IdSucursalRecibo = {0}", idSucursalNuevo)
         .AppendFormatLine("      ,IdTipoComprobanteRecibo = '{0}'", idTipoComprobanteNuevo)
         .AppendFormatLine("      ,LetraRecibo = '{0}'", letraNuevo)
         .AppendFormatLine("      ,CentroEmisorRecibo = {0}", centroEmisorNuevo)
         .AppendFormatLine("      ,NumeroComprobanteRecibo = {0}", numeroComprobanteNuevo)
         .AppendFormatLine("   WHERE IdSucursalRecibo = {0}", idSucursalActual)
         .AppendFormatLine("     AND IdTipoComprobanteRecibo = '{0}'", idTipoComprobanteActual)
         .AppendFormatLine("     AND LetraRecibo = '{0}'", letraActual)
         .AppendFormatLine("     AND CentroEmisorRecibo = {0}", centroEmisorActual)
         .AppendFormatLine("     AND NumeroComprobanteRecibo = {0}", numeroComprobanteActual)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ActualizarPedido(idSucursal As Integer, idReparto As Integer, orden As Integer,
                               idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Short, numeroPedido As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE RepartosComprobantes")
         .AppendFormatLine("   SET IdSucursal = {0}", idSucursal)
         .AppendFormatLine("      ,IdTipoComprobantePedido = {0}", GetStringParaQueryConComillas(idTipoComprobantePedido))
         .AppendFormatLine("      ,LetraPedido = {0}", GetStringParaQueryConComillas(letraPedido))
         .AppendFormatLine("      ,CentroEmisorPedido = {0}", GetStringFromNumber(centroEmisorPedido))
         .AppendFormatLine("      ,NumeroPedido = {0}", GetStringFromNumber(numeroPedido))
         .AppendFormatLine("   WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("     AND IdReparto = {0} ", idReparto)
         .AppendFormatLine("     AND Orden = {0}", orden)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Function ExisteFactura(idSucursal As Integer,
                                 idReparto As Integer,
                                 idTipoComprobanteFact As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         .AppendFormatLine("  AND RC.{0} = {1}", Entidades.RepartoComprobante.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("  AND RC.{0} = {1}", Entidades.RepartoComprobante.Columnas.CentroEmisorFact.ToString(), centroEmisor)
         .AppendFormatLine("  AND RC.{0} = '{1}'", Entidades.RepartoComprobante.Columnas.LetraFact.ToString(), letra)
         .AppendFormatLine("  AND RC.{0} = '{1}'", Entidades.RepartoComprobante.Columnas.IdTipoComprobanteFact.ToString(), idTipoComprobanteFact)
         .AppendFormatLine("  AND RC.{0} = {1}", Entidades.RepartoComprobante.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("  AND RC.{0} = {1}", Entidades.RepartoComprobante.Columnas.IdReparto.ToString(), idReparto)
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

End Class