Public Class EstadosPedidos
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosPedidos_I(idEstado As String,
                               idTipoComprobante As String,
                               idTipoEstado As String,
                               orden As Integer,
                               afectaPendiente As Boolean,
                               tipoEstadoPedido As String,
                               color As Integer,
                               reservaStock As Boolean,
                               divide As Boolean,
                               idEstadoDivideA As String,
                               idEstadoDivideB As String,
                               porcDivideA As Decimal,
                               porcDivideB As Decimal,
                               solicitaSucursalParaTipoComprobante As Boolean)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("INSERT INTO EstadosPedidos")
         .AppendLine("   (IdEstado")
         .AppendLine("   ,idTipoComprobante")
         .AppendLine("   ,idTipoEstado")
         .AppendLine("   ,Orden")
         .AppendLine("   ,AfectaPendiente")
         .AppendLine("   ,TipoEstadoPedido")
         .AppendLine("   ,Color")
         .AppendLine("   ,ReservaStock")

         .AppendLine("   ,Divide")
         .AppendLine("   ,IdEstadoDivideA")
         .AppendLine("   ,IdEstadoDivideB")
         .AppendLine("   ,PorcDivideA")
         .AppendLine("   ,PorcDivideB")
         .AppendLine("   ,SolicitaSucursalParaTipoComprobante")

         .AppendLine(" ) VALUES ( ")
         .AppendLine("   '" & idEstado & "'")
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("   ,'" & idTipoComprobante & "'")
         Else
            .AppendLine("   ,NULL")
         End If
         .AppendLine("   ,'" & idTipoEstado.ToUpper & "'")
         .AppendLine("   ," & orden.ToString())
         .AppendLine("  ," & GetStringFromBoolean(afectaPendiente))
         .AppendFormat("  ,'{0}'", tipoEstadoPedido).AppendLine()
         .AppendFormat("  ,{0}", color).AppendLine()
         .AppendFormat("  ,{0}", GetStringFromBoolean(reservaStock)).AppendLine()

         .AppendFormatLine("   ,{0}", GetStringFromBoolean(divide))
         If Not String.IsNullOrWhiteSpace(idEstadoDivideA) Then
            .AppendFormatLine("   ,'{0}'", idEstadoDivideA)
         Else
            .AppendFormatLine("   ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idEstadoDivideB) Then
            .AppendFormatLine("   ,'{0}'", idEstadoDivideB)
         Else
            .AppendFormatLine("   ,NULL")
         End If
         .AppendFormatLine("   ,{0}", porcDivideA)
         .AppendFormatLine("   ,{0}", porcDivideB)

         .AppendFormatLine("   ,{0}", GetStringFromBoolean(solicitaSucursalParaTipoComprobante))

         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub EstadosPedidos_U(idEstado As String,
                               idTipoComprobante As String,
                               idTipoEstado As String,
                               orden As Integer,
                               afectaPendiente As Boolean,
                               tipoEstadoPedido As String,
                               color As Integer,
                               reservaStock As Boolean,
                               divide As Boolean,
                               idEstadoDivideA As String,
                               idEstadoDivideB As String,
                               porcDivideA As Decimal,
                               porcDivideB As Decimal,
                               solicitaSucursalParaTipoComprobante As Boolean)

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine(" UPDATE EstadosPedidos SET ")
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("   idTipoComprobante = '" & idTipoComprobante & "'")
         Else
            .AppendLine("   idTipoComprobante = NULL")
         End If
         .AppendLine("   ,idTipoEstado = '" & idTipoEstado.ToUpper & "'")
         .AppendLine("   ,Orden = " & orden.ToString())
         .AppendLine("  ,AfectaPendiente = " & GetStringFromBoolean(afectaPendiente))
         .AppendFormat("  ,Color = {0}", color)
         .AppendFormat("  ,ReservaStock = {0}", GetStringFromBoolean(reservaStock)).AppendLine()

         .AppendFormatLine("  ,Divide = {0}", GetStringFromBoolean(divide))
         If Not String.IsNullOrWhiteSpace(idEstadoDivideA) Then
            .AppendFormatLine("  ,IdEstadoDivideA = '{0}'", idEstadoDivideA)
         Else
            .AppendFormatLine("  ,IdEstadoDivideA = NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idEstadoDivideB) Then
            .AppendFormatLine("  ,IdEstadoDivideB = '{0}'", idEstadoDivideB)
         Else
            .AppendFormatLine("  ,IdEstadoDivideB = NULL")
         End If
         .AppendFormatLine("  ,PorcDivideA = {0}", porcDivideA)
         .AppendFormatLine("  ,PorcDivideB = {0}", porcDivideB)

         .AppendFormatLine("  ,SolicitaSucursalParaTipoComprobante = {0}", GetStringFromBoolean(solicitaSucursalParaTipoComprobante))

         .AppendLine(" WHERE IdEstado = '" & idEstado & "'")
         .AppendFormat("   AND TipoEstadoPedido = '{0}'", tipoEstadoPedido).AppendLine()
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub EstadosPedidos_D(IdEstado As String, TipoEstadoPedido As String)

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("DELETE FROM EstadosPedidos")
         .AppendLine(" WHERE IdEstado = '" & IdEstado & "'")
         .AppendFormat("   AND TipoEstadoPedido = '{0}'", TipoEstadoPedido).AppendLine()
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(stb As StringBuilder, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos)
      With stb
         .AppendLine("SELECT E.*, ")

         .AppendLine(" 	ISNULL(EPS.IdDeposito, 0) AS IdDeposito, ")
         .AppendLine(" 	CASE WHEN ReservaStock = 0 THEN '' ELSE ISNULL(SDE.NombreDeposito, '') END AS NombreDeposito,")
         .AppendLine(" 	ISNULL(EPS.IdUbicacion, 0) AS IdUbicacion , ")
         .AppendLine(" 	CASE WHEN ReservaStock = 0 THEN '' ELSE ISNULL(SUB.NombreUbicacion, '') END AS NombreUbicacion")

         If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.TODOS Then
            .AppendLine(" FROM EstadosPedidos E ")
         Else
            .AppendFormatLine(" FROM (SELECT *")
            .AppendFormatLine("         FROM EstadosPedidos E")
            .AppendFormatLine("        WHERE EXISTS(")
            .AppendFormatLine("                     SELECT *")
            .AppendFormatLine("                       FROM EstadosPedidosRoles EPR")
            .AppendFormatLine("                      INNER JOIN UsuariosRoles UR ON UR.IdRol = EPR.IdRol")
            .AppendFormatLine("                      WHERE UR.IdSucursal = {0}", actual.Sucursal.Id)
            .AppendFormatLine("                        AND UR.IdUsuario = '{0}'", actual.Nombre)
            If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.ESCRITURA Then
               .AppendFormatLine("                        AND EPR.PermitirEscritura = 'True'")
            End If
            .AppendFormatLine("                        AND EPR.TipoEstadoPedido = E.TipoEstadoPedido AND EPR.IdEstado = E.IdEstado)) E")
         End If
         .AppendFormatLine("  LEFT JOIN EstadosPedidosSucursales EPS ON E.IdEstado = EPS.IdEstado AND E.TipoEstadoPedido = EPS.TipoEstadoPedido AND EPS.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendLine("  LEFT JOIN SucursalesDepositos SDE ON  SDE.idSucursal = EPS.IdSucursal AND SDE.IdDeposito = EPS.IdDeposito")
         .AppendLine("  LEFT JOIN SucursalesUbicaciones SUB  ON  SUB.idSucursal = EPS.IdSucursal AND SUB.IdDeposito = EPS.IdDeposito AND SUB.IdUbicacion = EPS.IdUbicacion")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String, TipoEstadoPedido As String) As DataTable
      columna = "E." + columna
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, Entidades.Publicos.LecturaEscrituraTodos.TODOS)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
         .AppendFormat("   AND E.TipoEstadoPedido = '{0}'", TipoEstadoPedido).AppendLine()
      End With
      Return GetDataTable(stb)
   End Function

   Public Function EstadosPedidos_GA(TipoEstadoPedido As String, todos As Boolean, idTipoComprobante As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos, activos As Entidades.Publicos.SiNoTodos) As DataTable
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
         If Not String.IsNullOrWhiteSpace(TipoEstadoPedido) Then
            .AppendFormat("   AND E.TipoEstadoPedido = '{0}'", TipoEstadoPedido).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND E.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         .Append("  ORDER BY E.Orden")
      End With
      Return Me.GetDataTable(stb)
   End Function

   Public Function EstadosPedidos_G1(idEstado As String, TipoEstadoPedido As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, Entidades.Publicos.LecturaEscrituraTodos.TODOS)
         .AppendLine(" WHERE E.IdEstado = '" & idEstado & "'")
         .AppendFormat("   AND E.TipoEstadoPedido = '{0}'", TipoEstadoPedido).AppendLine()
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPorNombre(idEstado As String, TipoEstadoPedido As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, Entidades.Publicos.LecturaEscrituraTodos.TODOS)
         .AppendLine(" WHERE E.IdEstado LIKE '%" & idEstado & "%'")
         .AppendFormat("   AND E.TipoEstadoPedido = '{0}'", TipoEstadoPedido).AppendLine()
         .AppendLine(" ORDER BY E.IdEstado")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetEstados(agregarTODOS As Boolean, agregarSOLOPendientes As Boolean,
                              agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean, agregarEstadosPendientes As Boolean,
                              tipoEstadoPedido As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT IdEstado")
         '.AppendLine("      ,ROW_NUMBER() OVER (ORDER BY IdEstado) AS Orden")
         .AppendLine("      ,Orden")
         If seguridadRol = Entidades.Publicos.LecturaEscrituraTodos.TODOS Then
            .AppendLine(" FROM EstadosPedidos")
         Else
            .AppendFormatLine(" FROM (SELECT *")
            .AppendFormatLine("         FROM EstadosPedidos E")
            .AppendFormatLine("        WHERE EXISTS(")
            .AppendFormatLine("                     SELECT *")
            .AppendFormatLine("                       FROM EstadosPedidosRoles EPR")
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

   Public Function GetTiposEstados(TipoEstadoPedido As String) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT DISTINCT IdTipoEstado")
         .AppendLine(" FROM EstadosPedidos")
         .AppendLine(" ORDER BY 1")
      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Function GetIdEstadosXTipo(IdTipoEstado As String, TipoEstadoPedido As String) As DataTable

      Dim stbQuery = New StringBuilder()
      Dim dt As New DataTable

      With stbQuery
         .AppendLine("SELECT IdEstado, IdTipoEstado")
         .AppendLine("  FROM EstadosPedidos")
         .AppendLine(" WHERE IdtipoEstado = '" & IdTipoEstado & "'")
         .AppendFormat("   AND TipoEstadoPedido = '{0}'", TipoEstadoPedido)
      End With

      dt = GetDataTable(stbQuery)

      Return dt

   End Function

   Public Function getComprobanteXEstado(IdEstado As String, TipoEstadoPedido As String) As String

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT IdTipoComprobante ")
         .AppendLine("  FROM EstadosPedidos ")
         .AppendLine(" WHERE idEstado = '" & IdEstado & "'")
         .AppendFormat("   AND TipoEstadoPedido = '{0}'", TipoEstadoPedido)
      End With

      Dim dt As New DataTable
      dt = GetDataTable(stbQuery)

      If dt.Rows.Count = 1 Then
         Return dt.Rows(0)("idTipoComprobante").ToString
      Else
         Return String.Empty
      End If

   End Function

End Class
