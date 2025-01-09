Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class VentasColasImpresionComprobantes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasColasImpresionComprobantes_I(idColaImpresion As Integer,
                                                 IdSucursal As Integer,
                                                 IdTipoComprobante As String,
                                                 Letra As String,
                                                 CentroEmisor As Integer,
                                                 NumeroComprobante As Long,
                                                 IdCliente As Long,
                                                 CodigoCliente As Long,
                                                 NombreCliente As String,
                                                 IdVendedor As Integer,
                                                 NombreVendedor As String,
                                                 Fecha As DateTime,
                                                 IdFormasPago As Integer,
                                                 DescripcionFormasPago As String,
                                                 ImporteTotal As Decimal,
                                                 DescuentoRecargoPorc As Decimal,
                                                 IdCategoria As Integer,
                                                 IdCategoriaFiscal As Short,
                                                 NombreCategoriaFiscal As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO VentasColasImpresionComprobantes ({0}, {1}, {2},{3}, {4}, {5},{6}, {7}, {8},{9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18})",
                       VentaColaImpresionComprobante.Columnas.IdVentaColaImpresion.ToString(),
                       VentaColaImpresionComprobante.Columnas.IdSucursal.ToString(),
                       VentaColaImpresionComprobante.Columnas.IdTipoComprobante.ToString(),
                       VentaColaImpresionComprobante.Columnas.Letra.ToString(),
                       VentaColaImpresionComprobante.Columnas.CentroEmisor.ToString(),
                       VentaColaImpresionComprobante.Columnas.NumeroComprobante.ToString(),
                       VentaColaImpresionComprobante.Columnas.IdCliente.ToString(),
                       VentaColaImpresionComprobante.Columnas.CodigoCliente.ToString(),
                       VentaColaImpresionComprobante.Columnas.NombreCliente.ToString(),
                       VentaColaImpresionComprobante.Columnas.IdVendedor.ToString(),
                       VentaColaImpresionComprobante.Columnas.NombreVendedor.ToString(),
                       VentaColaImpresionComprobante.Columnas.Fecha.ToString(),
                       VentaColaImpresionComprobante.Columnas.IdFormasPago.ToString(),
                       VentaColaImpresionComprobante.Columnas.DescripcionFormasPago.ToString(),
                       VentaColaImpresionComprobante.Columnas.ImporteTotal.ToString(),
                       VentaColaImpresionComprobante.Columnas.DescuentoRecargoPorc.ToString(),
                       VentaColaImpresionComprobante.Columnas.IdCategoria.ToString(),
                       VentaColaImpresionComprobante.Columnas.IdCategoriaFiscal.ToString(),
                       VentaColaImpresionComprobante.Columnas.NombreCategoriaFiscal.ToString()
                       ).AppendLine()
         .AppendFormat("     VALUES ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', {9}, '{10}', '{11}', {12}, '{13}', {14}, {15}, {16}, {17}, '{18}')",
                       idColaImpresion,
                       IdSucursal,
                       IdTipoComprobante,
                       Letra,
                       CentroEmisor,
                       NumeroComprobante,
                       IdCliente,
                       CodigoCliente,
                       NombreCliente,
                       IdVendedor,
                       NombreVendedor,
                       ObtenerFecha(Fecha, True),
                       IdFormasPago,
                       DescripcionFormasPago,
                       ImporteTotal,
                       DescuentoRecargoPorc,
                       IdCategoria,
                       IdCategoriaFiscal,
                       NombreCategoriaFiscal
                       )
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasColasImpresionComprobantes_U(idColaImpresion As Integer,
                                                 IdSucursal As Integer,
                                                 IdTipoComprobante As String,
                                                 Letra As String,
                                                 CentroEmisor As Integer,
                                                 NumeroComprobante As Long,
                                                 IdCliente As Long,
                                                 CodigoCliente As Long,
                                                 NombreCliente As String,
                                                 IdVendedor As Integer,
                                                 NombreVendedor As String,
                                                 Fecha As DateTime,
                                                 IdFormasPago As Integer,
                                                 DescripcionFormasPago As String,
                                                 ImporteTotal As Decimal,
                                                 DescuentoRecargoPorc As Decimal,
                                                 IdCategoria As Integer,
                                                 IdCategoriaFiscal As Short,
                                                 NombreCategoriaFiscal As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("UPDATE VentasColasImpresionComprobantes ").AppendLine()
         .AppendFormat("   SET {0} = {1}", VentaColaImpresionComprobante.Columnas.IdCliente.ToString(), IdCliente).AppendLine()
         .AppendFormat("      ,{0} = {1}", VentaColaImpresionComprobante.Columnas.CodigoCliente.ToString(), CodigoCliente).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", VentaColaImpresionComprobante.Columnas.NombreCliente.ToString(), NombreCliente).AppendLine()
         .AppendFormat("      ,{0} = {1}", VentaColaImpresionComprobante.Columnas.IdVendedor.ToString(), IdVendedor).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", VentaColaImpresionComprobante.Columnas.NombreVendedor.ToString(), NombreVendedor).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", VentaColaImpresionComprobante.Columnas.Fecha.ToString(), ObtenerFecha(Fecha, True)).AppendLine()
         .AppendFormat("      ,{0} = {1}", VentaColaImpresionComprobante.Columnas.IdFormasPago.ToString(), IdFormasPago).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", VentaColaImpresionComprobante.Columnas.DescripcionFormasPago.ToString(), DescripcionFormasPago).AppendLine()
         .AppendFormat("      ,{0} = {1}", VentaColaImpresionComprobante.Columnas.ImporteTotal.ToString(), ImporteTotal).AppendLine()
         .AppendFormat("      ,{0} = {1}", VentaColaImpresionComprobante.Columnas.DescuentoRecargoPorc.ToString(), DescuentoRecargoPorc).AppendLine()
         .AppendFormat("      ,{0} = {1}", VentaColaImpresionComprobante.Columnas.IdCategoria.ToString(), IdCategoria).AppendLine()
         .AppendFormat("      ,{0} = {1}", VentaColaImpresionComprobante.Columnas.IdCategoriaFiscal.ToString(), IdCategoriaFiscal).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", VentaColaImpresionComprobante.Columnas.NombreCategoriaFiscal.ToString(), NombreCategoriaFiscal).AppendLine()
         .AppendFormat(" WHERE {0} = {1}", VentaColaImpresionComprobante.Columnas.IdVentaColaImpresion.ToString(), idColaImpresion).AppendLine()
         .AppendFormat("   AND {0} = {1}", VentaColaImpresionComprobante.Columnas.IdSucursal.ToString(), IdSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}'", VentaColaImpresionComprobante.Columnas.IdTipoComprobante.ToString(), IdTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}'", VentaColaImpresionComprobante.Columnas.Letra.ToString(), Letra).AppendLine()
         .AppendFormat("   AND {0} = {1}", VentaColaImpresionComprobante.Columnas.CentroEmisor.ToString(), CentroEmisor).AppendLine()
         .AppendFormat("   AND {0} = {1}", VentaColaImpresionComprobante.Columnas.NumeroComprobante.ToString(), NumeroComprobante).AppendLine()

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasColasImpresionComprobantes_D(idColaImpresion As Integer,
                                                 IdSucursal As Integer,
                                                 IdTipoComprobante As String,
                                                 Letra As String,
                                                 CentroEmisor As Integer,
                                                 NumeroComprobante As Long)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM VentasColasImpresionComprobantes ")
         .AppendFormat(" WHERE {0} = {1}", VentaColaImpresionComprobante.Columnas.IdVentaColaImpresion.ToString(), idColaImpresion).AppendLine()
         .AppendFormat("   AND {0} = {1}", VentaColaImpresionComprobante.Columnas.IdSucursal.ToString(), IdSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}'", VentaColaImpresionComprobante.Columnas.IdTipoComprobante.ToString(), IdTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}'", VentaColaImpresionComprobante.Columnas.Letra.ToString(), Letra).AppendLine()
         .AppendFormat("   AND {0} = {1}", VentaColaImpresionComprobante.Columnas.CentroEmisor.ToString(), CentroEmisor).AppendLine()
         .AppendFormat("   AND {0} = {1}", VentaColaImpresionComprobante.Columnas.NumeroComprobante.ToString(), NumeroComprobante).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendFormat("SELECT VC.* FROM VentasColasImpresionComprobantes AS VC").AppendLine()
      End With
   End Sub

   Public Function VentasColasImpresionComprobantes_GA(idColaImpresion As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1 ")
         If idColaImpresion > 0 Then
            .AppendFormat("   AND {0} = {1}", VentaColaImpresionComprobante.Columnas.IdVentaColaImpresion.ToString(), idColaImpresion)
         End If
         .AppendFormat(" ORDER BY VC.IdVentaColaImpresion, VC.IdSucursal, VC.IdTipoComprobante, VC.Letra, VC.CentroEmisor, VC.NumeroComprobante")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function VentasColasImpresionComprobantes_G1(idColaImpresion As Integer,
                                                       IdSucursal As Integer,
                                                       IdTipoComprobante As String,
                                                       Letra As String,
                                                       CentroEmisor As Integer,
                                                       NumeroComprobante As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE VC.{0} = {1}", VentaColaImpresionComprobante.Columnas.IdVentaColaImpresion.ToString(), idColaImpresion).AppendLine()
         .AppendFormat("   AND VC.{0} = {1}", VentaColaImpresionComprobante.Columnas.IdSucursal.ToString(), IdSucursal).AppendLine()
         .AppendFormat("   AND VC.{0} = '{1}'", VentaColaImpresionComprobante.Columnas.IdTipoComprobante.ToString(), IdTipoComprobante).AppendLine()
         .AppendFormat("   AND VC.{0} = '{1}'", VentaColaImpresionComprobante.Columnas.Letra.ToString(), Letra).AppendLine()
         .AppendFormat("   AND VC.{0} = {1}", VentaColaImpresionComprobante.Columnas.CentroEmisor.ToString(), CentroEmisor).AppendLine()
         .AppendFormat("   AND VC.{0} = {1}", VentaColaImpresionComprobante.Columnas.NumeroComprobante.ToString(), NumeroComprobante).AppendLine()
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "VC." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
