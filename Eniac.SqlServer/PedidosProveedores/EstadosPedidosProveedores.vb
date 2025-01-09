Imports Eniac.Entidades

Public Class EstadosPedidosProveedores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosPedidosProveedores_I(idEstado As String,
                                          idTipoComprobante As String,
                                          idTipoEstado As String,
                                          orden As Integer,
                                          tipoEstadoPedido As String,
                                          color As Integer,
                                          tipoEstadoPedidoCliente As String,
                                          idEstadoPedidoCliente As String,
                                          idTipoMovimiento As String,
                                          stockAfectado As String,
                                          idEstadoDestino As String,
                                          idEstadoFacturado As String,
                                          generaDeclaracion As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO EstadosPedidosProveedores (")
         .AppendLine("     IdEstado")
         .AppendLine("   , idTipoComprobante")
         .AppendLine("   , idTipoEstado")
         .AppendLine("   , Orden")
         .AppendLine("   , TipoEstadoPedido")
         .AppendLine("   , Color")
         .AppendLine("   , TipoEstadoPedidoCliente")
         .AppendLine("   , IdEstadoPedidoCliente")
         .AppendLine("   , IdTipoMovimiento")
         .AppendLine("   , StockAfectado")
         .AppendLine("   , IdEstadoDestino")
         .AppendLine("   , IdEstadoFacturado")
         .AppendLine("   , GeneraDeclaracionProduccion")
         .AppendLine(" ) VALUES ( ")
         .AppendFormatLine("     '{0}'", idEstado)
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idTipoComprobante))
         .AppendFormatLine("   , '{0}'", idTipoEstado.ToUpper())
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   , '{0}'", tipoEstadoPedido)
         .AppendFormatLine("   ,  {0} ", color)
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(tipoEstadoPedidoCliente))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idEstadoPedidoCliente))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idTipoMovimiento))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(stockAfectado))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idEstadoDestino).ToUpper())
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idEstadoFacturado).ToUpper())
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(generaDeclaracion))
         .AppendLine(")")
      End With
      Execute(stb)
   End Sub

   Public Sub EstadosPedidosProveedores_U(idEstado As String,
                                          idTipoComprobante As String,
                                          idTipoEstado As String,
                                          orden As Integer,
                                          tipoEstadoPedido As String,
                                          color As Integer,
                                          tipoEstadoPedidoCliente As String,
                                          idEstadoPedidoCliente As String,
                                          idTipoMovimiento As String,
                                          stockAfectado As String,
                                          idEstadoDestino As String,
                                          idEstadoFacturado As String,
                                          generaDeclaracion As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE EstadosPedidosProveedores")
         .AppendFormatLine("   SET IdTipoComprobante = {0}", GetStringParaQueryConComillas(idTipoComprobante))
         .AppendFormatLine("     , IdTipoEstado = '{0}'", idTipoEstado.ToUpper())
         .AppendFormatLine("     , Orden = {0}", orden)
         .AppendFormatLine("     , Color = {0}", color)
         .AppendFormatLine("     , TipoEstadoPedidoCliente = {0}", GetStringParaQueryConComillas(tipoEstadoPedidoCliente).ToUpper())
         .AppendFormatLine("     , IdEstadoPedidoCliente = {0}", GetStringParaQueryConComillas(idEstadoPedidoCliente).ToUpper())
         .AppendFormatLine("     , IdTipoMovimiento = {0}", GetStringParaQueryConComillas(idTipoMovimiento).ToUpper())
         .AppendFormatLine("     , StockAfectado = {0}", GetStringParaQueryConComillas(stockAfectado).ToUpper())
         .AppendFormatLine("     , IdEstadoDestino = {0}", GetStringParaQueryConComillas(idEstadoDestino).ToUpper())
         .AppendFormatLine("     , IdEstadoFacturado = {0}", GetStringParaQueryConComillas(idEstadoFacturado).ToUpper())
         .AppendFormatLine("     , GeneraDeclaracionProduccion = {0}", GetStringFromBoolean(generaDeclaracion))

         .AppendFormatLine(" WHERE IdEstado = '{0}'", idEstado)
         .AppendFormatLine("   AND TipoEstadoPedido = '{0}'", tipoEstadoPedido)
      End With
      Execute(stb)
   End Sub

   Public Sub EstadosPedidosProveedores_D(idEstado As String, tipoEstadoPedido As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM EstadosPedidosProveedores")
         .AppendFormatLine(" WHERE IdEstado = '{0}'", idEstado)
         .AppendFormatLine("   AND TipoEstadoPedido = '{0}'", tipoEstadoPedido)
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos)
      With stb
         .AppendLine("SELECT E.* ")
         If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.TODOS Then
            .AppendLine(" FROM EstadosPedidosProveedores E")
         Else
            .AppendFormatLine(" FROM (SELECT *")
            .AppendFormatLine("         FROM EstadosPedidosProveedores E")
            .AppendFormatLine("        WHERE EXISTS(")
            .AppendFormatLine("                     SELECT *")
            .AppendFormatLine("                       FROM EstadosPedidosProveedoresRoles EPR")
            .AppendFormatLine("                      INNER JOIN UsuariosRoles UR ON UR.IdRol = EPR.IdRol")
            .AppendFormatLine("                      WHERE UR.IdSucursal = {0}", actual.Sucursal.Id)
            .AppendFormatLine("                        AND UR.IdUsuario = '{0}'", actual.Nombre)
            If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.ESCRITURA Then
               .AppendFormatLine("                        AND EPR.PermitirEscritura = 'True'")
            End If
            .AppendFormatLine("                        AND EPR.TipoEstadoPedido = E.TipoEstadoPedido AND EPR.IdEstado = E.IdEstado)) E")
         End If
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String, tipoEstadoPedido As String) As DataTable
      columna = "E." + columna
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, Entidades.Publicos.LecturaEscrituraTodos.TODOS)
         .AppendFormatLine(FormatoBuscar, columna, valor)
         .AppendFormatLine("   AND E.TipoEstadoPedido = '{0}'", tipoEstadoPedido)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function EstadosPedidosProveedores_GA_Facturable(tipoEstadoPedido As String) As DataTable
      Return EstadosPedidosProveedores_GA(tipoEstadoPedido, todos:=True, idTipoComprobante:=String.Empty, seguridadRol:=Publicos.LecturaEscrituraTodos.TODOS,
                                          activos:=Publicos.SiNoTodos.TODOS, facturable:=Publicos.SiNoTodos.SI)
   End Function

   Public Function EstadosPedidosProveedores_GA(tipoEstadoPedido As String, todos As Boolean, idTipoComprobante As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos,
                                                activos As Entidades.Publicos.SiNoTodos, facturable As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, seguridadRol)
         'If todos Then
         '    .Append(" union select '-1' as  IdEstado,'(todos)' as nombreplancuenta ")
         'End If
         .AppendLine(" WHERE 1 = 1")
         If activos <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND E.Orden {0} 0", If(activos = Entidades.Publicos.SiNoTodos.SI, "<>", "="))
         End If
         If Not String.IsNullOrWhiteSpace(tipoEstadoPedido) Then
            .AppendFormat("   AND E.TipoEstadoPedido = '{0}'", tipoEstadoPedido).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND E.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If facturable <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND E.IdEstadoFacturado IS {0} NULL", If(facturable = Entidades.Publicos.SiNoTodos.SI, "NOT", ""))
         End If
         .Append("  ORDER BY E.Orden")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function EstadosPedidosProveedores_G1(idEstado As String, tipoEstadoPedido As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, Entidades.Publicos.LecturaEscrituraTodos.TODOS)
         .AppendFormatLine(" WHERE E.IdEstado = '{0}'", idEstado)
         .AppendFormatLine("   AND E.TipoEstadoPedido = '{0}'", tipoEstadoPedido)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPorNombre(idEstado As String, tipoEstadoPedido As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, Entidades.Publicos.LecturaEscrituraTodos.TODOS)
         .AppendFormatLine(" WHERE E.IdEstado LIKE '%{0}%'", idEstado)
         .AppendFormatLine("   AND E.TipoEstadoPedido = '{0}'", tipoEstadoPedido)
         .AppendFormatLine(" ORDER BY E.IdEstado")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetEstados(agregarTODOS As Boolean, agregarSOLOPendientes As Boolean,
                              agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean, agregarEstadosPendientes As Boolean,
                              tipoEstadoPedido As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT IdEstado")
         .AppendLine("      ,Orden")
         If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.TODOS Then
            .AppendFormatLine(" FROM EstadosPedidosProveedores")
         Else
            .AppendFormatLine(" FROM (SELECT *")
            .AppendFormatLine("         FROM EstadosPedidosProveedores E")
            .AppendFormatLine("        WHERE EXISTS(")
            .AppendFormatLine("                     SELECT *")
            .AppendFormatLine("                       FROM EstadosPedidosProveedoresRoles EPR")
            .AppendFormatLine("                      INNER JOIN UsuariosRoles UR ON UR.IdRol = EPR.IdRol")
            .AppendFormatLine("                      WHERE UR.IdSucursal = {0}", actual.Sucursal.Id)
            .AppendFormatLine("                        AND UR.IdUsuario = '{0}'", actual.Nombre)
            If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.ESCRITURA Then
               .AppendFormatLine("                        AND EPR.PermitirEscritura = 'True'")
            End If
            .AppendFormatLine("                        AND EPR.TipoEstadoPedido = E.TipoEstadoPedido AND EPR.IdEstado = E.IdEstado)) E")
         End If
         .AppendLine(" WHERE Orden <> 0 ")
         .AppendFormat("   AND TipoEstadoPedido = '{0}'", tipoEstadoPedido)
         If agregarEstadosPendientes Then
            .AppendLine(" AND IdTipoEstado = 'PENDIENTE'")
         Else
            If Not agregarSOLOPendientes Then
               .AppendLine(" AND IdTipoEstado <> 'PENDIENTE'")
            End If
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

   Public Function GetEstadosCalidad(AgregarTODOS As Boolean, AgregarSOLOPendientes As Boolean,
                              AgregarSOLOEnProceso As Boolean, AgregarAnulado As Boolean, AgregarEstadosPendientes As Boolean,
                              tipoEstadoPedido As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT IdEstado")
         '.AppendLine("      ,ROW_NUMBER() OVER (ORDER BY IdEstado) AS Orden")
         .AppendLine("      ,Orden")
         .AppendLine(" FROM EstadosPedidosProveedores")
         .AppendLine(" WHERE Orden <> 0 ")
         .AppendFormat("   AND TipoEstadoPedido = '{0}'", tipoEstadoPedido)
         If AgregarEstadosPendientes Then
            .AppendLine(" AND IdTipoEstado = 'PENDIENTE'")
         Else
            If Not AgregarSOLOPendientes Then
               .AppendLine(" AND IdTipoEstado <> 'PENDIENTE'")
            End If
            If Not AgregarAnulado Then
               .AppendLine(" AND IdTipoEstado <> 'ANULADO'")
            End If
            If AgregarTODOS Then
               .AppendLine(" UNION SELECT 'TODOS' AS IdEstado, -2 AS Orden")
            End If
            If AgregarSOLOPendientes Then
               .AppendLine(" UNION SELECT 'PENDIENTE/EN PROCESO' AS IdEstado, -1 AS Orden")
            End If
            If AgregarSOLOEnProceso Then
               .AppendLine(" UNION SELECT 'SOLO EN PROCESO' AS IdEstado, 0 AS Orden")
            End If
         End If
         .AppendLine(" ORDER BY Orden")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetTiposEstados(tipoEstadoPedido As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT DISTINCT IdTipoEstado")
         .AppendLine(" FROM EstadosPedidosProveedores")
         .AppendLine(" ORDER BY 1")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetIdEstadosXTipo(IdTipoEstado As String, tipoEstadoPedido As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT IdEstado, IdTipoEstado")
         .AppendFormatLine("  FROM EstadosPedidosProveedores")
         .AppendFormatLine(" WHERE IdtipoEstado = '{0}'", IdTipoEstado)
         .AppendFormatLine("   AND TipoEstadoPedido = '{0}'", tipoEstadoPedido)
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetComprobanteXEstado(idEstado As String, tipoEstadoPedido As String) As String
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT IdTipoComprobante ")
         .AppendFormatLine("  FROM EstadosPedidosProveedores ")
         .AppendFormatLine(" WHERE IdEstado = '{0}'", idEstado)
         .AppendFormatLine("   AND TipoEstadoPedido = '{0}'", tipoEstadoPedido)
      End With
      Using dt = GetDataTable(stbQuery)
         If dt.Any() Then
            Return dt.First().Field(Of String)("idTipoComprobante").IfNull()
         Else
            Return String.Empty
         End If
      End Using
   End Function

End Class