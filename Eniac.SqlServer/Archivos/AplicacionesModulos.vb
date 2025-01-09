Public Class AplicacionesModulos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Modulos_I(idModulo As Integer, nombreModulo As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.AplicacionModulo.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}", Entidades.AplicacionModulo.Columnas.IdModulo.ToString())
         .AppendFormatLine("           ,{0}", Entidades.AplicacionModulo.Columnas.NombreModulo.ToString())
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("            {0}", idModulo)
         .AppendFormatLine("          ,'{0}'", nombreModulo)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Modulos_U(idModulo As Integer, nombreModulo As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.AplicacionModulo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.AplicacionModulo.Columnas.NombreModulo.ToString(), nombreModulo)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.AplicacionModulo.Columnas.IdModulo.ToString(), idModulo)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Modulos_D(idModulo As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.AplicacionModulo.NombreTabla, Entidades.AplicacionModulo.Columnas.IdModulo.ToString(), idModulo)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT M.*")
         .AppendFormatLine("  FROM {0} AS M", Entidades.AplicacionModulo.NombreTabla)
      End With
   End Sub

   Public Function Modulos_GA() As DataTable
      Return Modulos_G(idModulo:=0, nombreModulo:=String.Empty, nombreExacto:=False)
   End Function
   Public Function Modulos_GA(nombreModulo As String, nombreExacto As Boolean) As DataTable
      Return Modulos_G(idModulo:=0, nombreModulo:=nombreModulo, nombreExacto:=nombreExacto)
   End Function
   Public Function Modulos_GA_Cuit(cuitModulo As String, cuitExacto As Boolean) As DataTable
      Return Modulos_G(idModulo:=0, nombreModulo:=String.Empty, nombreExacto:=False)
   End Function
   Private Function Modulos_G(idModulo As Integer, nombreModulo As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idModulo > 0 Then
            .AppendFormatLine("   AND M.{0} = {1}", Entidades.AplicacionModulo.Columnas.IdModulo.ToString(), idModulo)
         End If
         If Not String.IsNullOrWhiteSpace(nombreModulo) Then
            If nombreExacto Then
               .AppendFormatLine("   AND M.{0} = '{1}'", Entidades.AplicacionModulo.Columnas.NombreModulo.ToString(), nombreModulo)
            Else
               .AppendFormatLine("   AND M.{0} LIKE '%{1}%'", Entidades.AplicacionModulo.Columnas.NombreModulo.ToString(), nombreModulo)
            End If
         End If
         .AppendFormatLine(" ORDER BY M.{0}", Entidades.AplicacionModulo.Columnas.NombreModulo.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Modulos_G1(idModulo As Integer) As DataTable
      Return Modulos_G(idModulo:=idModulo, nombreModulo:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable

      columna = "M." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.AplicacionModulo.Columnas.IdModulo.ToString(), Entidades.AplicacionModulo.NombreTabla))
   End Function

End Class