Public Class EstadosOrdenesProduccion
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosOrdenesProduccion_I(idEstado As String,
                                         idTipoComprobante As String,
                                         idTipoEstado As String,
                                         orden As Integer,
                                         color As Integer,
                                         reservaMateriaPrima As Boolean,
                                         generaProductoTerminado As Boolean,
                                         tipoEstadoPedido As String,
                                         idEstadoPedido As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO EstadosOrdenesProduccion")
         .AppendFormatLine("   ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                           Entidades.EstadoOrdenProduccion.Columnas.IdEstado.ToString(),
                           Entidades.EstadoOrdenProduccion.Columnas.IdTipoComprobante.ToString(),
                           Entidades.EstadoOrdenProduccion.Columnas.IdTipoEstado.ToString(),
                           Entidades.EstadoOrdenProduccion.Columnas.Orden.ToString(),
                           Entidades.EstadoOrdenProduccion.Columnas.Color.ToString(),
                           Entidades.EstadoOrdenProduccion.Columnas.ReservaMateriaPrima.ToString(),
                           Entidades.EstadoOrdenProduccion.Columnas.GeneraProductoTerminado.ToString(),
                           Entidades.EstadoOrdenProduccion.Columnas.TipoEstadoPedido.ToString(),
                           Entidades.EstadoOrdenProduccion.Columnas.IdEstadoPedido.ToString())
         .AppendFormatLine("  VALUES ('{0}', {1}, '{2}', {3}, {4}, {5}, {6}, {7}, {8})",
                           idEstado,
                           If(String.IsNullOrWhiteSpace(idTipoComprobante), "NULL", String.Format("'{0}'", idTipoComprobante)),
                           idTipoEstado.ToUpper(),
                           orden,
                           color,
                           GetStringFromBoolean(reservaMateriaPrima),
                           GetStringFromBoolean(generaProductoTerminado),
                           If(String.IsNullOrWhiteSpace(tipoEstadoPedido), "NULL", String.Format("'{0}'", tipoEstadoPedido)),
                           If(String.IsNullOrWhiteSpace(idEstadoPedido), "NULL", String.Format("'{0}'", idEstadoPedido)))
      End With
      Execute(stb)
   End Sub

   Public Sub EstadosOrdenesProduccion_U(idEstado As String,
                                         idTipoComprobante As String,
                                         idTipoEstado As String,
                                         orden As Integer,
                                         color As Integer,
                                         reservaMateriaPrima As Boolean,
                                         generaProductoTerminado As Boolean,
                                         tipoEstadoPedido As String,
                                         idEstadoPedido As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" UPDATE EstadosOrdenesProduccion SET ")
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("        IdTipoComprobante = '{0}'", idTipoComprobante)
         Else
            .AppendFormatLine("        IdTipoComprobante = NULL")
         End If
         .AppendFormatLine("       ,IdTipoEstado = '{0}'", idTipoEstado.ToUpper)
         .AppendFormatLine("       ,Orden = {0}", orden)
         .AppendFormatLine("       ,Color = {0}", color)
         .AppendFormatLine("       ,ReservaMateriaPrima = {0}", GetStringFromBoolean(reservaMateriaPrima))
         .AppendFormatLine("       ,GeneraProductoTerminado = {0}", GetStringFromBoolean(generaProductoTerminado))

         If Not String.IsNullOrEmpty(tipoEstadoPedido) Then
            .AppendFormatLine("       ,TipoEstadoPedido = '{0}'", tipoEstadoPedido)
         Else
            .AppendFormatLine("       ,TipoEstadoPedido = NULL")
         End If
         If Not String.IsNullOrEmpty(idEstadoPedido) Then
            .AppendFormatLine("       ,IdEstadoPedido = '{0}'", idEstadoPedido)
         Else
            .AppendFormatLine("       ,IdEstadoPedido = NULL")
         End If

         .AppendFormatLine(" WHERE IdEstado = '{0}'", idEstado)
      End With
      Execute(stb)
   End Sub

   Public Sub EstadosOrdenesProduccion_D(idEstado As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM EstadosOrdenesProduccion")
         .AppendFormatLine(" WHERE IdEstado = '{0}'", idEstado)
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT E.*, ")

         .AppendFormatLine(" 	ISNULL(EPS.IdDeposito, 0) AS IdDeposito, ")
         .AppendFormatLine(" 	CASE WHEN ReservaMateriaPrima = 0 THEN '' ELSE ISNULL(SDE.NombreDeposito, '') END AS NombreDeposito,")
         .AppendFormatLine(" 	ISNULL(EPS.IdUbicacion, 0) AS IdUbicacion , ")
         .AppendFormatLine(" 	CASE WHEN ReservaMateriaPrima = 0 THEN '' ELSE ISNULL(SUB.NombreUbicacion, '') END AS NombreUbicacion")

         .AppendFormatLine(" FROM EstadosOrdenesProduccion E")

         .AppendFormatLine("  LEFT JOIN EstadosOrdenesProduccionSucursales EPS ON E.IdEstado = EPS.IdEstado AND EPS.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendFormatLine("  LEFT JOIN SucursalesDepositos SDE ON  SDE.idSucursal = EPS.IdSucursal AND SDE.IdDeposito = EPS.IdDeposito")
         .AppendFormatLine("  LEFT JOIN SucursalesUbicaciones SUB  ON  SUB.idSucursal = EPS.IdSucursal AND SUB.IdDeposito = EPS.IdDeposito AND SUB.IdUbicacion = EPS.IdUbicacion")

      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "E.")
   End Function

   Public Function EstadosOrdenesProduccion_G(idEstado As String, idEstadoExacto As Boolean, idTipoEstado As String, orden As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idEstado) Then
            If idEstadoExacto Then
               .AppendFormat("   AND E.IdEstado = '{0}'", idEstado).AppendLine()
            Else
               .AppendFormat("   AND E.IdEstado LIKE '%{0}%'", idEstado).AppendLine()
            End If
         End If
         If Not String.IsNullOrWhiteSpace(idTipoEstado) Then
            .AppendFormat("   AND E.IdTipoEstado = '{0}'", idTipoEstado).AppendLine()
         End If
         .AppendFormat("  ORDER BY E.{0}", orden)
      End With
      Return GetDataTable(stb)
   End Function


   Public Function EstadosOrdenesProduccion_GA() As DataTable
      Return EstadosOrdenesProduccion_G(String.Empty, True, String.Empty, Entidades.EstadoOrdenProduccion.Columnas.Orden.ToString())
   End Function

   Public Function EstadosOrdenesProduccion_G1(idEstado As String) As DataTable
      Return EstadosOrdenesProduccion_G(idEstado, True, String.Empty, Entidades.EstadoOrdenProduccion.Columnas.Orden.ToString())
   End Function

   Public Function GetPorNombre(idEstado As String) As DataTable
      Return EstadosOrdenesProduccion_G(idEstado, False, String.Empty, Entidades.EstadoOrdenProduccion.Columnas.IdEstado.ToString())
   End Function

   Public Function GetIdEstadosXTipo(IdTipoEstado As String) As DataTable
      Return EstadosOrdenesProduccion_G(String.Empty, False, IdTipoEstado, Entidades.EstadoOrdenProduccion.Columnas.Orden.ToString())
   End Function

   Public Function GetEstados(agregarTODOS As Boolean, agregarSOLOPendientes As Boolean, agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean, tipoEstado As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT IdEstado ,Orden")
         .AppendLine(" FROM EstadosOrdenesProduccion")
         .AppendLine(" WHERE Orden <> 0 ")
         If Not String.IsNullOrEmpty(tipoEstado) Then
            .AppendFormatLine(" AND IdTipoEstado = '{0}'", tipoEstado)
         Else
            If Not agregarAnulado Then
               .AppendLine(" AND IdTipoEstado <> 'ANULADO'")
            End If
            If agregarTODOS Then
               .AppendLine(" UNION SELECT 'TODOS' AS IdEstado, -2 AS Orden")
            End If
            If agregarSOLOPendientes Then
               .AppendLine(" UNION SELECT 'SOLO PENDIENTES' AS IdEstado, -1 AS Orden")
            End If
            If agregarSOLOEnProceso Then
               .AppendLine(" UNION SELECT 'SOLO EN PROCESO' AS IdEstado, 0 AS Orden")
            End If
         End If
         .AppendLine(" ORDER BY Orden")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetTiposEstados() As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT DISTINCT IdTipoEstado")
         .AppendLine("  FROM EstadosOrdenesProduccion")
         .AppendLine(" ORDER BY 1")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetComprobanteXEstado(IdEstado As String) As String
      Using dt = EstadosOrdenesProduccion_G(IdEstado, True, String.Empty, Entidades.EstadoOrdenProduccion.Columnas.Orden.ToString())
         Return If(dt.Any(), dt.First().Field(Of String)("IdTipoComprobante"), String.Empty)
      End Using
   End Function
End Class