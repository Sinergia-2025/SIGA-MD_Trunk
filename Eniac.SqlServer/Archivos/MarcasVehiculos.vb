Public Class MarcasVehiculos

    Inherits Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

   Public Sub MarcasVehiculos_I(IdMarcaVehiculo As Integer,
                                NombreMarcaVehiculo As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2})",
                          Entidades.MarcaVehiculo.NombreTabla,
                          Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString(),
                          Entidades.MarcaVehiculo.Columnas.NombreMarcaVehiculo.ToString()).AppendLine()
         .AppendFormat("     VALUES ({1}, '{2}'",
                          Entidades.MarcaVehiculo.NombreTabla, IdMarcaVehiculo, NombreMarcaVehiculo)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub MarcasVehiculos_U(IdMarcaVehiculo As Integer,
                                NombreMarcaVehiculo As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.MarcaVehiculo.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.MarcaVehiculo.Columnas.NombreMarcaVehiculo.ToString(), NombreMarcaVehiculo).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString(), IdMarcaVehiculo).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub MarcasVehiculos_D(IdMarcaVehiculo As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.MarcaVehiculo.NombreTabla, Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString(), IdMarcaVehiculo)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
        With stb
            .AppendFormat("SELECT MV.* FROM {0} AS MV", Entidades.MarcaVehiculo.NombreTabla).AppendLine()
        End With
    End Sub

    Public Function MarcasVehiculos_GA() As DataTable
      Return MarcasVehiculos_G(IdMarcaVehiculo:=0, NombreMarcaVehiculo:=String.Empty)
   End Function

   Private Function MarcasVehiculos_G(IdMarcaVehiculo As Integer, NombreMarcaVehiculo As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If IdMarcaVehiculo > 0 Then
            .AppendFormat("   AND MV.IdMarcaVehiculo = {0}", IdMarcaVehiculo).AppendLine()
         End If
         .AppendLine(" ORDER BY IdMarcaVehiculo ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function MarcasVehiculos_G1(IdMarcaVehiculo As Integer) As DataTable
      Return MarcasVehiculos_G(IdMarcaVehiculo:=IdMarcaVehiculo, NombreMarcaVehiculo:=String.Empty)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
        'If columna = "NombreSucursal" Then
        '   columna = "S." + columna
        'Else
        columna = "MV." + columna
        'End If
        Dim stb As StringBuilder = New StringBuilder()
        With stb
            Me.SelectTexto(stb)
            .AppendFormatLine(FormatoBuscar, columna, valor)
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function
    Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString(), "MarcasVehiculos"))
   End Function

End Class
