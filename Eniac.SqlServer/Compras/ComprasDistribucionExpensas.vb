Public Class ComprasDistribucionExpensas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasDistribucionExpensas_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                            idProveedor As Long, idAreaComun As String,
                                            importe As Decimal)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ComprasDistribucionExpensas")
         .AppendFormatLine("   (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor, IdAreaComun, Importe)")
         .AppendFormatLine("  VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, '{6}', {7}) ", idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idAreaComun, importe)
      End With
      Execute(stb)
   End Sub

   Public Sub ComprasDistribucionExpensas_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                            idProveedor As Long, idAreaComun As String,
                                            importe As Decimal)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ComprasDistribucionExpensas SET ")
         .AppendFormatLine("       Importe           = '{0}',", importe)
         .AppendFormatLine(" WHERE IdSucursal        =  {0}  ", idAreaComun)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}',", idTipoComprobante)
         .AppendFormatLine("   AND Letra             = '{0}',", letra)
         .AppendFormatLine("   AND CentroEmisor      =  {0}, ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante =  {0}, ", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor       =  {0}, ", idProveedor)
         .AppendFormatLine("   AND IdAreaComun       = '{0}' ", idAreaComun)
      End With
      Execute(stb)
   End Sub

   Public Sub ComprasDistribucionExpensas_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                            idProveedor As Long, idAreaComun As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ComprasDistribucionExpensas")
         .AppendFormatLine(" WHERE IdSucursal        =  {0}  ", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}' ", idTipoComprobante)
         .AppendFormatLine("   AND Letra             = '{0}' ", letra)
         .AppendFormatLine("   AND CentroEmisor      =  {0}  ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante =  {0}  ", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor       =  {0}  ", idProveedor)
         If Not String.IsNullOrWhiteSpace(idAreaComun) Then
            .AppendFormatLine("   AND IdAreaComun       = '{0}' ", idAreaComun)
         End If
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT S.*")
         .AppendFormatLine("     , AC.NombreAreaComun")
         .AppendFormatLine(" FROM ComprasDistribucionExpensas S")
         .AppendFormatLine(" LEFT JOIN AreasComunes AC ON AC.IdAreaComun = S.IdAreaComun")
      End With
   End Sub

   Public Function ComprasDistribucionExpensas_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                  idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE IdSucursal        =  {0}  ", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}' ", idTipoComprobante)
         .AppendFormatLine("   AND Letra             = '{0}' ", letra)
         .AppendFormatLine("   AND CentroEmisor      =  {0}  ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante =  {0}  ", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor       =  {0}  ", idProveedor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "S.",
                    New Dictionary(Of String, String) From {{"NombreAreaComun", "AC.NombreAreaComun"}})
   End Function

End Class