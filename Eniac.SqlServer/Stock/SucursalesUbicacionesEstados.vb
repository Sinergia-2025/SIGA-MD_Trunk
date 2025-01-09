Public Class SucursalesUbicacionesEstados
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SucursalesUbicacionesEstados_I(idEstado As Integer,
                                             nombreEstado As String,
                                             ordenEstado As Integer,
                                             activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4})",
                          Entidades.SucursalUbicacionEstado.NombreTabla,
                          Entidades.SucursalUbicacionEstado.Columnas.IdEstado.ToString(),
                          Entidades.SucursalUbicacionEstado.Columnas.NombreEstado.ToString(),
                          Entidades.SucursalUbicacionEstado.Columnas.OrdenEstado.ToString(),
                          Entidades.SucursalUbicacionEstado.Columnas.Activo.ToString()).AppendLine()
         .AppendFormat("  VALUES ({0}, '{1}', {2}, {3}",
                          idEstado,
                          nombreEstado,
                          ordenEstado,
                          GetStringFromBoolean(activo))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SucursalesUbicacionesEstados_U(idEstado As Integer,
                                             nombreEstado As String,
                                             ordenEstado As Integer,
                                             activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}         ", Entidades.SucursalUbicacionEstado.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}',", Entidades.SucursalUbicacionEstado.Columnas.NombreEstado.ToString(), nombreEstado).AppendLine()
         .AppendFormat("       {0} = '{1}',", Entidades.SucursalUbicacionEstado.Columnas.OrdenEstado.ToString(), ordenEstado).AppendLine()
         .AppendFormat("       {0} =  {1}  ", Entidades.SucursalUbicacionEstado.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", Entidades.SucursalUbicacionEstado.Columnas.IdEstado.ToString(), idEstado).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub SucursalesUbicacionesEstados_D(IdEstado As Integer)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", Entidades.SucursalUbicacionEstado.NombreTabla)
         .AppendFormat("      WHERE {0} = {1}", Entidades.SucursalUbicacionEstado.Columnas.IdEstado.ToString(), IdEstado)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT UE.* FROM {0} AS UE ", Entidades.SucursalUbicacionEstado.NombreTabla).AppendLine()
      End With
   End Sub

   Public Function SucursalesUbicacionesEstados_GA() As DataTable
      Return SucursalesUbicacionesEstados_G(idEstado:=0)
   End Function

   Private Function SucursalesUbicacionesEstados_G(idEstado As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idEstado > 0 Then
            .AppendFormat("   AND UE.IdEstado = {0}", idEstado).AppendLine()
         End If
         .AppendFormat("    ORDER BY UE.IdEstado").AppendLine()
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function SucursalesUbicacionesEstados_G1(idEstado As Integer) As DataTable
      Return SucursalesUbicacionesEstados_G(idEstado:=idEstado)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.SucursalUbicacionEstado.Columnas.IdEstado.ToString(),
                                             "EstadosUbicaciones"))
   End Function

   Public Overloads Function GetOrdenMinimo(campo As String, tabla As String, condicion As String) As Integer
      Dim result As Integer = 0

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("SELECT {0} FROM {1} ", campo, tabla)
         If Not String.IsNullOrWhiteSpace(condicion) Then
            .AppendFormat(" WHERE {0}", condicion)
         End If
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 AndAlso dt.Columns.Contains(campo) Then
         If Not IsDBNull(dt.Rows(0)(campo)) AndAlso Not String.IsNullOrWhiteSpace(dt.Rows(0)(campo).ToString()) Then
            If Not Integer.TryParse(dt.Rows(0)(campo).ToString(), result) Then
               result = 0
            End If
         End If
      End If
      Return result

   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "UE." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
