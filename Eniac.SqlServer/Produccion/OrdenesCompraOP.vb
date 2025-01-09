Option Explicit On
Option Strict On
Public Class OrdenesCompraOP
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesCompra_I(ByVal NumeroOrdenCompra As Long, _
                               ByVal IdProveedor As Long, _
                               ByVal IdFormasPago As Integer, _
                               ByVal FechaPedidos As DateTime, _
                               ByVal Usuario As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("INSERT INTO OrdenesCompra")
         .AppendLine("   (NumeroOrdenCompra")
         .AppendLine("   ,IdProveedor")
         .AppendLine("   ,IdFormasPago")
         .AppendLine("   ,FechaPedidos")
         .AppendLine("   ,Usuario")
         .AppendLine(" ) VALUES ( ")
         .AppendLine("" & NumeroOrdenCompra)
         .AppendLine("   ," & IdProveedor.ToString())
         .AppendLine("  ," & IdFormasPago)
         .AppendLine("  ,'" & Me.ObtenerFecha(FechaPedidos, True) & "'")
         .AppendLine("  ,'" & Usuario & "'")
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub OrdenesCompra_U(ByVal NumeroOrdenCompra As Long, _
                               ByVal IdProveedor As Long, _
                               ByVal IdFormasPago As Integer, _
                               ByVal FechaPedidos As DateTime, _
                               ByVal Usuario As String)

      Dim stb As StringBuilder = New StringBuilder("")
      Dim afecta As Int16 = New Short()

      With stb
         .Length = 0
         .AppendLine(" UPDATE OrdenesCompra SET ")
         .AppendLine("   ,IdProveedor = " & IdProveedor)
         .AppendLine("   ,IdFormasPago = " & IdFormasPago)
         .AppendLine("   ,FechaPedidos = " & Me.ObtenerFecha(FechaPedidos, True) & "'")
         .AppendLine("   ,Usuario = " & Usuario)
         .AppendLine(" WHERE NumeroOrdenCompra = " & NumeroOrdenCompra)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub OrdenesCompra_D(ByVal NumeroOrdenCompra As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM OrdenesCompra")
         .AppendLine(" WHERE NumeroOrdenCompra = " & NumeroOrdenCompra)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT OC.* ")
         .AppendLine(" FROM OrdenesCompra OC")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "OC." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function OrdenesCompra_GA(ByVal todos As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY OC.NumeroOrdenCompra")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function OrdenesCompra_G1(ByVal NumeroOrdenCompra As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE OC.NumeroOrdenCompra = " & NumeroOrdenCompra)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
