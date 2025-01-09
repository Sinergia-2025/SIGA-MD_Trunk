Public Class EstadosVenta
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosVenta_I(idEstadoVenta As Integer,
                             nombreEstadoVenta As String,
                             IdTipoMovimiento As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.EstadoVenta.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}, {1}, {2})",
                           Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString(),
                           Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString(),
                           Entidades.EstadoVenta.Columnas.IdTipoMovimiento.ToString())
         .AppendFormatLine("    VALUES ({0}, '{1}', '{2}')",
                           idEstadoVenta,
                           nombreEstadoVenta,
                           IdTipoMovimiento)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EstadosVenta_U(idEstadoVenta As Integer,
                             nombreEstadoVenta As String,
                             IdTipoMovimiento As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.EstadoVenta.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString(), nombreEstadoVenta)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.EstadoVenta.Columnas.IdTipoMovimiento.ToString(), IdTipoMovimiento)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString(), idEstadoVenta)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EstadosVenta_D(idEstadoVenta As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}",
                       Entidades.EstadoVenta.NombreTabla, Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString(), idEstadoVenta)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EV.*")
         .AppendFormatLine("  FROM {0} AS EV", Entidades.EstadoVenta.NombreTabla)
      End With
   End Sub

   Public Function EstadosVenta_GA() As DataTable
      Return EstadosVenta_G(idEstadoVenta:=-1, nombreEstadoVenta:=String.Empty, nombreExacto:=False)
   End Function
   Public Function EstadosVenta_GA(nombreEstadoVenta As String, nombreExacto As Boolean) As DataTable
      Return EstadosVenta_G(idEstadoVenta:=-1, nombreEstadoVenta:=nombreEstadoVenta, nombreExacto:=nombreExacto)
   End Function
   Private Function EstadosVenta_G(idEstadoVenta As Integer, nombreEstadoVenta As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idEstadoVenta >= 0 Then
            .AppendFormatLine("   AND EV.{0} = {1}", Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString(), idEstadoVenta)
         End If
         If Not String.IsNullOrWhiteSpace(nombreEstadoVenta) Then
            If nombreExacto Then
               .AppendFormatLine("   AND EV.{0} = '{1}'", Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString(), nombreEstadoVenta)
            Else
               .AppendFormatLine("   AND EV.{0} LIKE '%{1}%'", Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString(), nombreEstadoVenta)
            End If
         End If
         .AppendFormatLine(" ORDER BY EV.{0}", Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function EstadosVenta_G1(idEstadoVenta As Integer) As DataTable
      Return EstadosVenta_G(idEstadoVenta:=idEstadoVenta, nombreEstadoVenta:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreVendedor" Then
      '   columna = "E.NombreEmpleado"
      'Else
      columna = "EV." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString(), Entidades.EstadoVenta.NombreTabla))
   End Function

End Class