Public Class EstadosOrdenesProduccionSucursales
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosOrdenesProduccionSucursales_I(idEstado As String,
                                                   idSucursal As Integer,
                                                   idDeposito As Integer,
                                                   idUbicacion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormat("INSERT INTO {0}  (", Entidades.EstadoOrdenProduccionSucursal.NombreTabla.ToString())
         .AppendFormat("            {0},  ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdEstado.ToString())
         .AppendFormat("            {0},  ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdSucursal.ToString())
         .AppendFormat("            {0},  ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdDeposito.ToString())
         .AppendFormat("            {0}   ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdUbicacion.ToString())

         .AppendLine(" ) VALUES ( ")

         .AppendFormat("           '{0}',  ", idEstado)
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
   Public Sub EstadosOrdenesProduccionSucursales_U(idEstado As String,
                                                   idSucursal As Integer,
                                                   idDeposito As Integer,
                                                   idUbicacion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormat("UPDATE {0} SET ", Entidades.EstadoOrdenProduccionSucursal.NombreTabla.ToString())
         .AppendFormat("       {0} =  {1} , ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormat("       {0} =  {1}   ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdUbicacion.ToString(), idUbicacion)

         .AppendFormat(" WHERE {0} = '{1}'  ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdEstado.ToString(), idEstado)
         .AppendFormat("   AND {0} =  {1}   ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdSucursal.ToString(), idSucursal)
      End With
      Execute(stb.ToString())

   End Sub
   Public Sub EstadosOrdenesProduccionSucursales_D(idEstado As String, idSucursal As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormat("DELETE  FROM  {0}  ", Entidades.EstadoOrdenProduccionSucursal.NombreTabla.ToString())
         .AppendFormat(" WHERE {0} = '{1}' ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdEstado.ToString(), idEstado)
         If idSucursal = 0 Then
            .AppendFormat(" AND {0} = {1}  ", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         End If
      End With
      Me.Execute(stb.ToString())
   End Sub
   Public Sub EstadosOrdenesProduccionSucursales_M(idEstado As String,
                                                   idSucursal As Integer,
                                                   idDeposito As Integer,
                                                   idUbicacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS D               ", Entidades.EstadoOrdenProduccionSucursal.NombreTabla)
         .AppendFormatLine("        USING (SELECT '{1}' AS {0}", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdEstado.ToString(), idEstado)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.EstadoOrdenProduccionSucursal.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1}",
                           Entidades.EstadoOrdenProduccionSucursal.Columnas.IdEstado.ToString(),
                           Entidades.EstadoOrdenProduccionSucursal.Columnas.IdSucursal.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = O.{0}, D.{1} = O.{1}",
                           Entidades.EstadoOrdenProduccionSucursal.Columnas.IdDeposito.ToString(),
                           Entidades.EstadoOrdenProduccionSucursal.Columnas.IdUbicacion.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}) VALUES (O.{0}, O.{1}, O.{2}, O.{3})",
                           Entidades.EstadoOrdenProduccionSucursal.Columnas.IdEstado.ToString(),
                           Entidades.EstadoOrdenProduccionSucursal.Columnas.IdSucursal.ToString(),
                           Entidades.EstadoOrdenProduccionSucursal.Columnas.IdDeposito.ToString(),
                           Entidades.EstadoOrdenProduccionSucursal.Columnas.IdUbicacion.ToString())
         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT EOPS.* ")
         .AppendLine(" FROM EstadosOrdenesProduccionSucursales EOPS")
      End With
   End Sub

   Public Function EstadosOrdenesProduccionSucursales_GA() As DataTable
      Return EstadosOrdenesProduccionSucursales_G(idEstado:="", idSucursal:=0)
   End Function

   Public Function EstadosOrdenesProduccionSucursales_G(idEstado As String,
                                                        idSucursal As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" WHERE EOPS.IdEstado = '{0}'", idEstado)
         .AppendFormat("   AND EOPS.IdSucursal = {0}", idSucursal)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetCantidadSucursalesDepositos(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM {0} as EOPS", Entidades.EstadoOrdenProduccionSucursal.NombreTabla)
         .AppendFormatLine("     WHERE EOPS.IdSucursal = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND EOPS.IdDeposito = {0}", IdDeposito)
         End If
      End With

      Return GetDataTable(stb)
   End Function
End Class
