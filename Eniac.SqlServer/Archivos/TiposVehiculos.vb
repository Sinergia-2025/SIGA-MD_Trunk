Public Class TiposVehiculos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposVehiculos_I(idTipoVehiculo As Integer,
                               nombreTipoVehiculo As String,
                               capacidadMaxima As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3})",
                       Entidades.TipoVehiculo.NombreTabla,
                       Entidades.TipoVehiculo.Columnas.IdTipoVehiculo.ToString(),
                       Entidades.TipoVehiculo.Columnas.NombreTipoVehiculo.ToString(),
                       Entidades.TipoVehiculo.Columnas.CapacidadMaxima.ToString()).AppendLine()
         .AppendFormat("     VALUES ({1}, '{2}', {3}",
                       Entidades.TipoVehiculo.NombreTabla, idTipoVehiculo, nombreTipoVehiculo, capacidadMaxima)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposVehiculos_U(idTipoVehiculo As Integer,
                               nombreTipoVehiculo As String,
                               capacidadMaxima As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.TipoVehiculo.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.TipoVehiculo.Columnas.NombreTipoVehiculo.ToString(), nombreTipoVehiculo).AppendLine()
         .AppendFormat("   ,{0} = {1}", Entidades.TipoVehiculo.Columnas.CapacidadMaxima.ToString(), capacidadMaxima).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TipoVehiculo.Columnas.IdTipoVehiculo.ToString(), idTipoVehiculo).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposVehiculos_D(idTipoVehiculo As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.TipoVehiculo.NombreTabla, Entidades.TipoVehiculo.Columnas.IdTipoVehiculo.ToString(), idTipoVehiculo)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT TV.* FROM {0} AS TV", Entidades.TipoVehiculo.NombreTabla).AppendLine()
      End With
   End Sub

   Public Function TiposVehiculos_GA() As DataTable
      Return TiposVehiculos_G(idTipoVehiculo:=0, nombreTipoVehiculo:=String.Empty, nombreExacto:=False, capacidadMaxima:=0)
   End Function
   Private Function TiposVehiculos_G(idTipoVehiculo As Integer, nombreTipoVehiculo As String, nombreExacto As Boolean, capacidadMaxima As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idTipoVehiculo > 0 Then
            .AppendFormat("   AND TV.IdTipoVehiculo = {0}", idTipoVehiculo).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nombreTipoVehiculo) Then
            If nombreExacto Then
               .AppendFormat("   AND TV.NombreTipoVehiculo = '{0}'", nombreTipoVehiculo).AppendLine()
            Else
               .AppendFormat("   AND TV.NombreTipoVehiculo LIKE '%{0}%'", nombreTipoVehiculo).AppendLine()
            End If
         End If
         If capacidadMaxima > 0 Then
            .AppendFormat("   AND TV.CapacidadMaxima = {0}", capacidadMaxima).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposVehiculos_G1(idTipoVehiculo As Integer) As DataTable
      Return TiposVehiculos_G(idTipoVehiculo:=idTipoVehiculo, nombreTipoVehiculo:=String.Empty, nombreExacto:=False, capacidadMaxima:=0)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreSucursal" Then
      '   columna = "S." + columna
      'Else
      columna = "TV." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.TipoVehiculo.Columnas.IdTipoVehiculo.ToString(), "TiposVehiculos"))
   End Function

End Class