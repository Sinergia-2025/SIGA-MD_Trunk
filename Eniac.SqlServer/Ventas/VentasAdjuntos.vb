Option Strict On
Option Explicit On
Public Class VentasAdjuntos
   Inherits Comunes

   Private Property NombreBaseAdjuntos As String

   Public Sub New(ByVal da As Eniac.Datos.DataAccess, nombreBaseAdjuntos As String)
      MyBase.New(da)
      Me.NombreBaseAdjuntos = nombreBaseAdjuntos
   End Sub

   Public Sub VentasAdjuntos_I(idSucursal As Integer,
                               idTipoComprobante As String,
                               letra As String,
                               centroEmisor As Short,
                               numeroComprobante As Long,
                               idVentaAdjunto As Long,
                               idProducto As String,
                               orden As Integer,
                               idTipoAdjunto As Integer,
                               nombreAdjunto As String,
                               adjunto As Byte(),
                               observaciones As String,
                               nivelAutorizacion As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0}VentasAdjuntos ", NombreBaseAdjuntos).AppendLine()
         .AppendFormat("      ({0}", Entidades.VentaAdjunto.Columnas.IdSucursal.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.IdTipoComprobante.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.Letra.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.CentroEmisor.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.NumeroComprobante.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.IdVentaAdjunto.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.IdProducto.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.Orden.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.IdTipoAdjunto.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.NombreAdjunto.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.Adjunto.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.Observaciones.ToString()).AppendLine()
         .AppendFormat("      ,{0}", Entidades.VentaAdjunto.Columnas.NivelAutorizacion.ToString()).AppendLine()
         .AppendFormat("   ) VALUES (").AppendLine()
         .AppendFormat("       {0} ", idSucursal).AppendLine()
         .AppendFormat("     ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("     ,'{0}'", letra).AppendLine()
         .AppendFormat("     , {0} ", centroEmisor).AppendLine()
         .AppendFormat("     , {0} ", numeroComprobante).AppendLine()
         .AppendFormat("     , {0} ", idVentaAdjunto).AppendLine()
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("     ,'{0}'", idProducto).AppendLine()
         Else
            .AppendFormat("     ,NULL").AppendLine()
         End If
         If orden > 0 Then
            .AppendFormat("     , {0} ", orden).AppendLine()
         Else
            .AppendFormat("     ,NULL").AppendLine()
         End If
         .AppendFormat("     ,'{0}'", idTipoAdjunto).AppendLine()
         .AppendFormat("     ,'{0}'", nombreAdjunto).AppendLine()
         .AppendFormat("     , @adjunto ").AppendLine()
         .AppendFormat("     ,'{0}'", observaciones).AppendLine()
         .AppendFormat("     ,{0}", nivelAutorizacion).AppendLine()
         .AppendLine(")")

         Me._da.Command.CommandText = .ToString()
         Me._da.Command.CommandType = CommandType.Text
         Me._da.Command.Transaction = Me._da.Transaction
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@adjunto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = adjunto.Length
         oParameter.Value = adjunto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      End With
      'Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasAdjuntos_U(idSucursal As Integer,
                               idTipoComprobante As String,
                               letra As String,
                               centroEmisor As Short,
                               numeroComprobante As Long,
                               idVentaAdjunto As Long,
                               idTipoAdjunto As Integer,
                               nombreAdjunto As String,
                               observaciones As String,
                               nivelAutorizacion As Short)
      ''                         idProducto As String,   'No es parte de la clave primaria, pero no es un dato que se puede modificar
      ''                         orden As Integer,       'No es parte de la clave primaria, pero no es un dato que se puede modificar
      ''                         adjunto As Byte(),      'El adjunto no se puede cambiar, solo observaciones, nombre y tipo.
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}VentasAdjuntos ", NombreBaseAdjuntos).AppendLine()
         .AppendFormat("   SET {0} =  {1} ", Entidades.VentaAdjunto.Columnas.IdTipoAdjunto.ToString(), idTipoAdjunto).AppendLine()
         .AppendFormat("     , {0} = '{1}'", Entidades.VentaAdjunto.Columnas.NombreAdjunto.ToString(), nombreAdjunto).AppendLine()
         .AppendFormat("     , {0} = '{1}'", Entidades.VentaAdjunto.Columnas.Observaciones.ToString(), observaciones).AppendLine()
         .AppendFormat("     , {0} =  {1}", Entidades.VentaAdjunto.Columnas.NivelAutorizacion.ToString(), nivelAutorizacion).AppendLine()

         .AppendFormat(" WHERE {0} =  {1} ", Entidades.VentaAdjunto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND {0} = '{1}'", Entidades.VentaAdjunto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormat("   AND {0} = '{1}'", Entidades.VentaAdjunto.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND {0} =  {1} ", Entidades.VentaAdjunto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormat("   AND {0} =  {1} ", Entidades.VentaAdjunto.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormat("   AND {0} =  {1} ", Entidades.VentaAdjunto.Columnas.IdVentaAdjunto.ToString(), idVentaAdjunto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasAdjuntos_D(idSucursal As Integer,
                               idTipoComprobante As String,
                               letra As String,
                               centroEmisor As Short,
                               numeroComprobante As Long,
                               idVentaAdjunto As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}VentasAdjuntos", NombreBaseAdjuntos).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.VentaAdjunto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND {0} = '{1}'", Entidades.VentaAdjunto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormat("   AND {0} = '{1}'", Entidades.VentaAdjunto.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND {0} =  {1} ", Entidades.VentaAdjunto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormat("   AND {0} =  {1} ", Entidades.VentaAdjunto.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormat("   AND {0} =  {1} ", Entidades.VentaAdjunto.Columnas.IdVentaAdjunto.ToString(), idVentaAdjunto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder, incluirAdjunto As Boolean)
      With stb
         .AppendFormat("SELECT VA.{0}", Entidades.VentaAdjunto.Columnas.IdSucursal.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.IdTipoComprobante.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.Letra.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.CentroEmisor.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.NumeroComprobante.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.IdVentaAdjunto.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.IdProducto.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.Orden.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.IdTipoAdjunto.ToString()).AppendLine()
         .AppendFormat("      ,TA.{0}", Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.NombreAdjunto.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.Observaciones.ToString()).AppendLine()
         .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.NivelAutorizacion.ToString()).AppendLine()
         If incluirAdjunto Then
            .AppendFormat("      ,VA.{0}", Entidades.VentaAdjunto.Columnas.Adjunto.ToString()).AppendLine()
         Else
            .AppendFormat("      ,NULL AS {0}", Entidades.VentaAdjunto.Columnas.Adjunto.ToString()).AppendLine()
         End If

         .AppendFormat("  FROM {0}VentasAdjuntos AS VA", NombreBaseAdjuntos).AppendLine()
         .AppendFormat(" INNER JOIN TiposAdjuntos AS TA ON TA.IdTipoAdjunto = VA.IdTipoAdjunto")
      End With
   End Sub

   Public Function VentasAdjuntos_GA(incluirAdjunto As Boolean) As DataTable
      Return VentasAdjuntos_G(idSucursal:=Nothing, idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=Nothing, numeroComprobante:=Nothing,
                              idVentaAdjunto:=Nothing, idProducto:=String.Empty, orden:=Nothing,
                              idTipoAdjunto:=Nothing, nombreAdjunto:=String.Empty, nombreExacto:=False,
                              incluirAdjunto:=incluirAdjunto, nivelAutorizacion:=Nothing)
   End Function
   Public Function VentasAdjuntos_GA(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Short?, numeroComprobante As Long?,
                                     incluirAdjunto As Boolean, nivelAutorizacion As Short) As DataTable
      Return VentasAdjuntos_G(idSucursal:=idSucursal, idTipoComprobante:=idTipoComprobante, letra:=letra, centroEmisor:=centroEmisor, numeroComprobante:=numeroComprobante,
                              idVentaAdjunto:=Nothing, idProducto:=String.Empty, orden:=Nothing,
                              idTipoAdjunto:=Nothing, nombreAdjunto:=String.Empty, nombreExacto:=False,
                              incluirAdjunto:=incluirAdjunto, nivelAutorizacion:=nivelAutorizacion)
   End Function
   Public Function VentasAdjuntos_GA(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Short?, numeroComprobante As Long?,
                                     idProducto As String, orden As Integer?,
                                     incluirAdjunto As Boolean, nivelAutorizacion As Short) As DataTable
      Return VentasAdjuntos_G(idSucursal:=idSucursal, idTipoComprobante:=idTipoComprobante, letra:=letra, centroEmisor:=centroEmisor, numeroComprobante:=numeroComprobante,
                              idVentaAdjunto:=Nothing, idProducto:=idProducto, orden:=orden,
                              idTipoAdjunto:=Nothing, nombreAdjunto:=String.Empty, nombreExacto:=False,
                              incluirAdjunto:=incluirAdjunto, nivelAutorizacion:=nivelAutorizacion)
   End Function
   Private Function VentasAdjuntos_G(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Short?, numeroComprobante As Long?,
                                     idVentaAdjunto As Long?, idProducto As String, orden As Integer?,
                                     idTipoAdjunto As Integer?,
                                     nombreAdjunto As String, nombreExacto As Boolean,
                                     incluirAdjunto As Boolean,
                                     nivelAutorizacion As Short?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery, incluirAdjunto)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal.HasValue Then
            .AppendFormat("   AND VA.{0} = {1}", Entidades.VentaAdjunto.Columnas.IdSucursal.ToString(), idSucursal.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND VA.{0} = '{1}'", Entidades.VentaAdjunto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND VA.{0} = '{1}'", Entidades.VentaAdjunto.Columnas.Letra.ToString(), letra).AppendLine()
         End If
         If centroEmisor.HasValue Then
            .AppendFormat("   AND VA.{0} = {1}", Entidades.VentaAdjunto.Columnas.CentroEmisor.ToString(), centroEmisor.Value).AppendLine()
         End If
         If numeroComprobante.HasValue Then
            .AppendFormat("   AND VA.{0} = {1}", Entidades.VentaAdjunto.Columnas.NumeroComprobante.ToString(), numeroComprobante.Value).AppendLine()
         End If

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND VA.{0} = '{1}'", Entidades.VentaAdjunto.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         End If
         If orden.HasValue Then
            .AppendFormat("   AND VA.{0} = {1}", Entidades.VentaAdjunto.Columnas.Orden.ToString(), orden.Value).AppendLine()
         End If

         If idVentaAdjunto.HasValue Then
            .AppendFormat("   AND VA.IdVentaAdjunto = {0}", idVentaAdjunto.Value).AppendLine()
         End If
         If idTipoAdjunto.HasValue Then
            .AppendFormat("   AND VA.IdTipoAdjunto = {0}", idTipoAdjunto.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nombreAdjunto) Then
            If nombreExacto Then
               .AppendFormat("   AND VA.NombreAdjunto = '{0}'", nombreAdjunto).AppendLine()
            Else
               .AppendFormat("   AND VA.NombreAdjunto LIKE '%{0}%'", nombreAdjunto).AppendLine()
            End If
         End If
         If nivelAutorizacion.HasValue Then
            .AppendFormat("   AND VA.nivelAutorizacion <= {0}", nivelAutorizacion.Value).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function VentasAdjuntos_G1(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Short?, numeroComprobante As Long?,
                                     idVentaAdjunto As Long?, incluirAdjunto As Boolean, nivelAutorizacion As Short) As DataTable
      Return VentasAdjuntos_G(idSucursal:=idSucursal, idTipoComprobante:=idTipoComprobante, letra:=letra, centroEmisor:=centroEmisor, numeroComprobante:=numeroComprobante,
                              idVentaAdjunto:=idVentaAdjunto, idProducto:=String.Empty, orden:=Nothing,
                              idTipoAdjunto:=Nothing, nombreAdjunto:=String.Empty, nombreExacto:=False,
                              incluirAdjunto:=incluirAdjunto, nivelAutorizacion:=nivelAutorizacion)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String, incluirAdjunto As Boolean) As DataTable
      If columna = Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString() Then
         columna = "TA." + columna
      Else
         columna = "CA." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb, incluirAdjunto)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(idSucursal As Long, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As Long
      Return MyBase.GetCodigoMaximo(Entidades.VentaAdjunto.Columnas.IdVentaAdjunto.ToString(), String.Format("{0}VentasAdjuntos", NombreBaseAdjuntos),
                                    String.Format("{0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                                  Entidades.VentaAdjunto.Columnas.IdSucursal.ToString(), idSucursal,
                                                  Entidades.VentaAdjunto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante,
                                                  Entidades.VentaAdjunto.Columnas.Letra.ToString(), letra,
                                                  Entidades.VentaAdjunto.Columnas.CentroEmisor.ToString(), centroEmisor,
                                                  Entidades.VentaAdjunto.Columnas.NumeroComprobante.ToString(), numeroComprobante))
   End Function

End Class