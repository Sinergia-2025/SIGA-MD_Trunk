Public Class Marcas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Marcas_I(idMarca As Integer, nombreMarca As String,
                       comisionPorVenta As Decimal, descuentoRecargoPorc1 As Decimal, descuentoRecargoPorc2 As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.Marca.NombreTabla)
         .AppendFormatLine("    ({0}", Entidades.Marca.Columnas.IdMarca.ToString())
         .AppendFormatLine("    ,{0}", Entidades.Marca.Columnas.NombreMarca.ToString())
         .AppendFormatLine("    ,{0}", Entidades.Marca.Columnas.ComisionPorVenta.ToString())
         .AppendFormatLine("    ,{0}", Entidades.Marca.Columnas.DescuentoRecargoPorc1.ToString())
         .AppendFormatLine("    ,{0}", Entidades.Marca.Columnas.DescuentoRecargoPorc2.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0}  ", idMarca)
         .AppendFormatLine("    ,'{0}' ", nombreMarca)
         .AppendFormatLine("    , {0}  ", comisionPorVenta)
         .AppendFormatLine("    , {0}  ", descuentoRecargoPorc1)
         .AppendFormatLine("    , {0}  ", descuentoRecargoPorc2)
         .Append(") ")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Marcas")
   End Sub
   Public Sub Marcas_U(idMarca As Integer, nombreMarca As String,
                       comisionPorVenta As Decimal, descuentoRecargoPorc1 As Decimal, descuentoRecargoPorc2 As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Marca.NombreTabla)
         .AppendFormatLine("   SET ")
         .AppendFormatLine("       {0} = '{1}'", Entidades.Marca.Columnas.NombreMarca.ToString(), nombreMarca)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Marca.Columnas.ComisionPorVenta.ToString(), comisionPorVenta)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Marca.Columnas.DescuentoRecargoPorc1.ToString(), descuentoRecargoPorc1)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Marca.Columnas.DescuentoRecargoPorc2.ToString(), descuentoRecargoPorc2)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Marca.Columnas.IdMarca.ToString(), idMarca)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Marcas")
   End Sub
   Public Sub Marcas_D(idMarca As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.Marca.NombreTabla)
         .AppendFormat(" WHERE {0} = {1}", Entidades.Marca.Columnas.IdMarca.ToString(), idMarca)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Marcas")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, top As Integer)
      With stb
         .AppendFormatLine("SELECT{0} M.*", If(top > 0, String.Format(" TOP {0}", top), String.Empty))
         .AppendFormatLine("  FROM Marcas M ")
      End With
   End Sub

   Public Function Marcas_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, top:=0)
         .AppendLine(" ORDER BY M.NombreMarca ")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function Marcas_G1(IdMarca As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, top:=0)
         If IdMarca > 0 Then
            .AppendFormatLine(" WHERE M.IdMarca = {0}", IdMarca)
         End If
      End With
      Return GetDataTable(stb)
   End Function
   Public Function Marcas_GA_PorNombre(nombreMarca As String, nombreExacto As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, top:=0)
         If nombreExacto Then
            .AppendFormatLine(" WHERE NombreMarca = '{0}'", nombreMarca)
         Else
            .AppendFormatLine(" WHERE NombreMarca LIKE '%{0}%'", nombreMarca)
         End If
      End With
      Return GetDataTable(stb)
   End Function
   Public Function Marcas_GetPrimeraMarca() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, top:=1)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb, top:=0), "M.")
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.Marca.Columnas.IdMarca.ToString(), Entidades.Marca.NombreTabla).ToInteger()
   End Function
End Class