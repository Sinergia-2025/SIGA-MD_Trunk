Option Strict On
Option Explicit On
Public Class ClientesAdjuntos
   Inherits Comunes

   Private Property NombreBaseAdjuntos As String

   Public Sub New(ByVal da As Eniac.Datos.DataAccess, nombreBaseAdjuntos As String)
      MyBase.New(da)
      Me.NombreBaseAdjuntos = nombreBaseAdjuntos
   End Sub

   Public Sub ClientesAdjuntos_I(idCliente As Long,
                                 idClienteAdjunto As Long,
                                 idTipoAdjunto As Integer,
                                 nombreAdjunto As String,
                                 adjunto As Byte(),
                                 observaciones As String,
                                 nivelAutorizacion As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0}ClientesAdjuntos ({1}, {2}, {3}, {4}, {5}, {6},{7})", NombreBaseAdjuntos,
                       Entidades.ClienteAdjunto.Columnas.IdCliente.ToString(),
                       Entidades.ClienteAdjunto.Columnas.IdClienteAdjunto.ToString(),
                       Entidades.ClienteAdjunto.Columnas.IdTipoAdjunto.ToString(),
                       Entidades.ClienteAdjunto.Columnas.NombreAdjunto.ToString(),
                       Entidades.ClienteAdjunto.Columnas.Adjunto.ToString(),
                       Entidades.ClienteAdjunto.Columnas.Observaciones.ToString(),
                       Entidades.ClienteAdjunto.Columnas.NivelAutorizacion.ToString()).AppendLine()
         .AppendFormat("     VALUES ({1}, {2}, {3}, '{4}', @adjunto, '{6}', {7}",
                       NombreBaseAdjuntos, idCliente, idClienteAdjunto, idTipoAdjunto, nombreAdjunto, adjunto, observaciones, nivelAutorizacion)
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

   Public Sub ClientesAdjuntos_U(idCliente As Long,
                                 idClienteAdjunto As Long,
                                 idTipoAdjunto As Integer,
                                 nombreAdjunto As String,
                                 observaciones As String,
                                 nivelAutorizacion As Short)
      ''                         adjunto As Byte(),
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}ClientesAdjuntos ", NombreBaseAdjuntos).AppendLine()
         .AppendFormat("   SET {0} =  {1} ", Entidades.ClienteAdjunto.Columnas.IdTipoAdjunto.ToString(), idTipoAdjunto).AppendLine()
         .AppendFormat("     , {0} = '{1}'", Entidades.ClienteAdjunto.Columnas.NombreAdjunto.ToString(), nombreAdjunto).AppendLine()
         .AppendFormat("     , {0} = '{1}'", Entidades.ClienteAdjunto.Columnas.Observaciones.ToString(), observaciones).AppendLine()
         .AppendFormat("     , {0} =  {1}", Entidades.ClienteAdjunto.Columnas.NivelAutorizacion.ToString(), nivelAutorizacion).AppendLine()

         .AppendFormat(" WHERE {0} =  {1} ", Entidades.ClienteAdjunto.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormat("   AND {0} =  {1} ", Entidades.ClienteAdjunto.Columnas.IdClienteAdjunto.ToString(), idClienteAdjunto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesAdjuntos_D(idCliente As Long,
                                 idClienteAdjunto As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}ClientesAdjuntos", NombreBaseAdjuntos).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.ClienteAdjunto.Columnas.IdCliente.ToString(), idCliente).AppendLine()
         .AppendFormat("   AND {0} =  {1} ", Entidades.ClienteAdjunto.Columnas.IdClienteAdjunto.ToString(), idClienteAdjunto).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder, incluirAdjunto As Boolean)
      With stb
         .AppendFormat("SELECT CA.IdCliente").AppendLine()
         .AppendFormat("      ,CA.IdClienteAdjunto").AppendLine()
         .AppendFormat("      ,CA.IdTipoAdjunto").AppendLine()
         .AppendFormat("      ,TA.NombreTipoAdjunto").AppendLine()
         .AppendFormat("      ,CA.NombreAdjunto").AppendLine()
         .AppendFormat("      ,CA.Observaciones").AppendLine()
         .AppendFormat("      ,CA.NivelAutorizacion").AppendLine()
         If incluirAdjunto Then
            .AppendFormat("      ,CA.Adjunto").AppendLine()
         Else
            .AppendFormat("      ,NULL AS Adjunto").AppendLine()
         End If

         .AppendFormat("  FROM {0}ClientesAdjuntos AS CA", NombreBaseAdjuntos).AppendLine()
         .AppendFormat(" INNER JOIN TiposAdjuntos AS TA ON TA.IdTipoAdjunto = CA.IdTipoAdjunto")
      End With
   End Sub

   Public Function ClientesAdjuntos_GA(incluirAdjunto As Boolean) As DataTable
      Return ClientesAdjuntos_G(idCliente:=Nothing, idClienteAdjunto:=Nothing, idTipoAdjunto:=Nothing, nombreAdjunto:=String.Empty, nombreExacto:=False,
                                incluirAdjunto:=incluirAdjunto, nivelAutorizacion:=Nothing)
   End Function
   Public Function ClientesAdjuntos_GA(idCliente As Long, incluirAdjunto As Boolean, nivelAutorizacion As Short) As DataTable
      Return ClientesAdjuntos_G(idCliente:=idCliente, idClienteAdjunto:=Nothing, idTipoAdjunto:=Nothing, nombreAdjunto:=String.Empty, nombreExacto:=False,
                                incluirAdjunto:=incluirAdjunto, nivelAutorizacion:=nivelAutorizacion)
   End Function
   Private Function ClientesAdjuntos_G(idCliente As Long?, idClienteAdjunto As Long?, idTipoAdjunto As Integer?,
                                       nombreAdjunto As String, nombreExacto As Boolean,
                                       incluirAdjunto As Boolean, nivelAutorizacion As Short?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery, incluirAdjunto)
         .AppendLine(" WHERE 1 = 1")
         If idCliente.HasValue Then
            .AppendFormat("   AND CA.IdCliente = {0}", idCliente.Value).AppendLine()
         End If
         If idClienteAdjunto.HasValue Then
            .AppendFormat("   AND CA.IdClienteAdjunto = {0}", idClienteAdjunto.Value).AppendLine()
         End If
         If idTipoAdjunto.HasValue Then
            .AppendFormat("   AND CA.IdTipoAdjunto = {0}", idTipoAdjunto.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nombreAdjunto) Then
            If nombreExacto Then
               .AppendFormat("   AND CA.NombreAdjunto = '{0}'", nombreAdjunto).AppendLine()
            Else
               .AppendFormat("   AND CA.NombreAdjunto LIKE '%{0}%'", nombreAdjunto).AppendLine()
            End If
         End If
         If nivelAutorizacion.HasValue Then
            .AppendFormat("   AND CA.nivelAutorizacion <= {0}", nivelAutorizacion.Value).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ClientesAdjuntos_G1(idCliente As Long?, idClienteAdjunto As Long?, incluirAdjunto As Boolean, nivelAutorizacion As Short?) As DataTable
      Return ClientesAdjuntos_G(idCliente:=idCliente, idClienteAdjunto:=idClienteAdjunto, idTipoAdjunto:=Nothing, nombreAdjunto:=String.Empty, nombreExacto:=False,
                                incluirAdjunto:=incluirAdjunto, nivelAutorizacion:=Nothing)
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

   Public Overloads Function GetCodigoMaximo(idCliente As Long) As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.ClienteAdjunto.Columnas.IdClienteAdjunto.ToString(), String.Format("{0}ClientesAdjuntos", NombreBaseAdjuntos),
                                                    String.Format("{0} = {1}",
                                                                  Entidades.ClienteAdjunto.Columnas.IdCliente.ToString(),
                                                                  idCliente)))
   End Function


End Class