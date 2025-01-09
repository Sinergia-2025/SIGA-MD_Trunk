Public Class AlquileresTarifasProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT T.IdProducto")
         .AppendLine("      ,(P.NombreProducto + ' - ' + P.EquipoMarca + ' - ' + P.EquipoModelo + ' - ' + P.NumeroSerie + ' - ' + LTRIM(STR(P.Anio)) + ' - ' + P.CaractSII) AS NombreProducto ")
         '.AppendLine("      ,P.NombreProducto")
         '.AppendLine("      ,P.EquipoModelo")
         '.AppendLine("      ,P.EquipoMarca")
         '.AppendLine("      ,P.NumeroSerie")
         .AppendLine("      ,T.CantDias")
         .AppendLine("      ,T.PrecioAlquiler")
         .AppendLine(" FROM AlquileresTarifasProductos T")
         .AppendLine(" INNER JOIN Productos P on P.IdProducto = T.IdProducto")
      End With
   End Sub

   Public Function Buscar(ByVal idSucursal As Integer, ByVal columna As String, ByVal valor As String) As DataTable
      columna = "T." + columna
      If columna = "T.NombreProducto" Then columna = "(P.NombreProducto + ' - ' + P.EquipoMarca + ' - ' + P.EquipoModelo + ' - ' + P.NumeroSerie + ' - ' + LTRIM(STR(P.Anio)) + ' - ' + P.CaractSII)"
      'If columna = "T.EquipoModelo" Then columna = columna.Replace("T.", "P.")
      'If columna = "T.EquipoMarca" Then columna = columna.Replace("T.", "P.")
      'If columna = "T.NumeroSerie" Then columna = columna.Replace("T.", "P.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE T.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TarifaProducto_GA(ByVal idSucursal As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE T.IdSucursal = " & idSucursal.ToString())
         .AppendLine(" ORDER BY NombreProducto, T.CantDias")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TarifaProducto_G1(ByVal idSucursal As Integer, ByVal IdProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE T.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND T.IdProducto = '" & IdProducto & "'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Tarifa_GetDetalle(ByVal idSucursal As Integer, ByVal IdProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine(" SELECT *   ")
         .AppendLine(" FROM AlquileresTarifasProductos T")
         .AppendLine(" WHERE T.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND T.IdProducto = '" & IdProducto & "'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub Tarifa_I(ByVal idSucursal As Integer, _
                       ByVal IdProducto As String, _
                       ByVal dtdetalle As DataTable)

      Dim stb As StringBuilder = New StringBuilder("")

      For Each fila As DataRow In dtdetalle.Rows
         With stb
            .Length = 0
            .AppendLine("INSERT INTO AlquileresTarifasProductos")
            .AppendLine("   (idSucursal")
            .AppendLine("   ,IdProducto")
            .AppendLine("   ,cantdias")
            .AppendLine("   ,PrecioAlquiler)")
            .AppendLine(" VALUES ( ")
            .AppendLine("   " & idSucursal.ToString())
            .AppendLine("  ,'" & IdProducto & "'")
            .AppendLine("  ,'" & fila("cantdias").ToString & "'")
            .AppendLine("  ," & fila("PrecioAlquiler").ToString)
            .AppendLine(")")
         End With
         Me.Execute(stb.ToString())

      Next

   End Sub

   Public Sub Tarifa_U(ByVal idSucursal As Integer, _
                       ByVal IdProducto As String, _
                       ByVal dtdetalle As DataTable)

      Dim stb As StringBuilder = New StringBuilder("")

      For Each fila As DataRow In dtDetalle.Rows

         With stb
            .Length = 0
            .AppendLine("UPDATE AlquileresTarifasProductos ")
            .AppendLine("   SET PrecioAlquiler = " & fila("PrecioAlquiler").ToString)
            .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
            .AppendLine("   AND IdProducto = '" & IdProducto & "'")
            .AppendLine("   AND cantdias = '" & fila("cantdias").ToString & "'")
         End With

         Me.Execute(stb.ToString())

      Next

   End Sub

   Public Sub Tarifa_D(ByVal idSucursal As Integer, _
                       ByVal IdProducto As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM AlquileresTarifasProductos")
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdProducto = '" & IdProducto & "'")
      End With

      Me.Execute(stb.ToString())

   End Sub

End Class
