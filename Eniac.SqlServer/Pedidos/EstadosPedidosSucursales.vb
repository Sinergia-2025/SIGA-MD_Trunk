Public Class EstadosPedidosSucursales
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosPedidosSucursales_I(idEstado As String,
                                         tipoEstadoPedido As String,
                                         idSucursal As Integer,
                                         idDeposito As Integer,
                                         idUbicacion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormat("INSERT INTO {0} (", Entidades.EstadoPedidoSucursal.NombreTabla.ToString())
         .AppendFormat("            {0},  ", Entidades.EstadoPedidoSucursal.Columnas.IdEstado.ToString())
         .AppendFormat("            {0},  ", Entidades.EstadoPedidoSucursal.Columnas.TipoEstadoPedido.ToString())
         .AppendFormat("            {0},  ", Entidades.EstadoPedidoSucursal.Columnas.IdSucursal.ToString())
         .AppendFormat("            {0},  ", Entidades.EstadoPedidoSucursal.Columnas.IdDeposito.ToString())
         .AppendFormat("            {0}   ", Entidades.EstadoPedidoSucursal.Columnas.IdUbicacion.ToString())

         .AppendLine(" ) VALUES ( ")

         .AppendFormat("           '{0}',  ", idEstado)
         .AppendFormat("           '{0}',  ", tipoEstadoPedido)
         .AppendFormat("            {0} ,  ", idSucursal)

         If idDeposito = 0 Then
            .AppendLine("   NULL, ")
         Else
            .AppendFormat("   {0}, ", idDeposito)
         End If
         If idUbicacion = 0 Then
            .AppendLine("   NULL ")
         Else
            .AppendFormat("   {0} ", idUbicacion)
         End If
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub EstadosPedidosSucursales_U(idEstado As String,
                                         tipoEstadoPedido As String,
                                         idSucursal As Integer,
                                         idDeposito As Integer,
                                         idUbicacion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormat("UPDATE {0} SET ", Entidades.EstadoPedidoSucursal.NombreTabla.ToString())
         .AppendFormat("       {0} =  {1} , ", Entidades.EstadoPedidoSucursal.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormat("       {0} =  {1}   ", Entidades.EstadoPedidoSucursal.Columnas.IdUbicacion.ToString(), idUbicacion)

         .AppendFormat(" WHERE {0} = '{1}'  ", Entidades.EstadoPedidoSucursal.Columnas.IdEstado.ToString(), idEstado)
         .AppendFormat("   AND {0} = '{1}'  ", Entidades.EstadoPedidoSucursal.Columnas.TipoEstadoPedido.ToString(), tipoEstadoPedido)
         .AppendFormat("   AND {0} =  {1}   ", Entidades.EstadoPedidoSucursal.Columnas.IdSucursal.ToString(), idSucursal)
      End With
      Execute(stb.ToString())

   End Sub

   Public Sub EstadosPedidosSucursales_D(idEstado As String, tipoEstadoPedido As String, idSucursal As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormat("DELETE FROM {0}  ", Entidades.EstadoPedidoSucursal.NombreTabla.ToString())
         If idSucursal = 0 Then
            .AppendFormat(" WHERE {0} = '{1}' ", Entidades.EstadoPedidoSucursal.Columnas.IdEstado.ToString(), idEstado)
            .AppendFormat("   AND {0} = '{1}' ", Entidades.EstadoPedidoSucursal.Columnas.TipoEstadoPedido.ToString(), tipoEstadoPedido)
         Else
            .AppendFormat(" WHERE {0} = '{1}' ", Entidades.EstadoPedidoSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         End If
      End With
      Me.Execute(stb.ToString())
   End Sub

   Public Sub EstadosPedidosSucursales_M(idEstado As String,
                                         tipoEstadoPedido As String,
                                         idSucursal As Integer,
                                         idDeposito As Integer,
                                         idUbicacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS D", Entidades.EstadoPedidoSucursal.NombreTabla)
         .AppendFormatLine("        USING (SELECT '{1}' AS {0}", Entidades.EstadoPedidoSucursal.Columnas.IdEstado.ToString(), idEstado)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.EstadoPedidoSucursal.Columnas.TipoEstadoPedido.ToString(), tipoEstadoPedido)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.EstadoPedidoSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.EstadoPedidoSucursal.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.EstadoPedidoSucursal.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1} AND O.{2} = D.{2}",
                           Entidades.EstadoPedidoSucursal.Columnas.IdEstado.ToString(),
                           Entidades.EstadoPedidoSucursal.Columnas.TipoEstadoPedido.ToString(),
                           Entidades.EstadoPedidoSucursal.Columnas.IdSucursal.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = O.{0}, D.{1} = O.{1}",
                           Entidades.EstadoPedidoSucursal.Columnas.IdDeposito.ToString(),
                           Entidades.EstadoPedidoSucursal.Columnas.IdUbicacion.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}, {4}) VALUES (O.{0}, O.{1}, O.{2}, O.{3}, O.{4})",
                           Entidades.EstadoPedidoSucursal.Columnas.IdEstado.ToString(),
                           Entidades.EstadoPedidoSucursal.Columnas.TipoEstadoPedido.ToString(),
                           Entidades.EstadoPedidoSucursal.Columnas.IdSucursal.ToString(),
                           Entidades.EstadoPedidoSucursal.Columnas.IdDeposito.ToString(),
                           Entidades.EstadoPedidoSucursal.Columnas.IdUbicacion.ToString())
         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT EPS.* ")
         .AppendLine(" FROM EstadosPedidosSucursales EPS")
      End With
   End Sub

   Public Function EstadosPedidosSucursales_GA() As DataTable
      Return EstadosPedidosSucursales_G(idEstado:="", tipoEstadoPedido:="", idSucursal:=0)
   End Function

   Public Function EstadosPedidosSucursales_G(idEstado As String,
                                               tipoEstadoPedido As String,
                                               idSucursal As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" WHERE EPS.IdEstado = '{0}'", idEstado)
         .AppendFormat("   AND EPS.TipoEstadoPedido = '{0}'", tipoEstadoPedido)
         .AppendFormat("   AND EPS.IdSucursal = {0}", idSucursal)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetCantidadSucursalesDepositos(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM EstadosPedidosSucursales as EPS")
         .AppendFormatLine("     WHERE EPS.IdSucursal = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND EPS.IdDeposito = {0}", IdDeposito)
         End If
      End With

      Return GetDataTable(stb)
   End Function
End Class
