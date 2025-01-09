Public Class ComprasDistribucionPorGrupo
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasDistribucionPorGrupo_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                            idProveedor As Long, idGrupoCama As Integer,
                                            importe As Decimal)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ComprasDistribucionPorGrupo")
         .AppendFormatLine("   (IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, IdProveedor, IdGrupoCama, Importe)")
         .AppendFormatLine("  VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, {6}, {7}) ", idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idGrupoCama, importe)
      End With
      Execute(stb)
   End Sub

   Public Sub ComprasDistribucionPorGrupo_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                            idProveedor As Long, idGrupoCama As String,
                                            importe As Decimal)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ComprasDistribucionPorGrupo SET ")
         .AppendFormatLine("       Importe           = '{0}',", importe)
         .AppendFormatLine(" WHERE IdSucursal        =  {0}  ", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}',", idTipoComprobante)
         .AppendFormatLine("   AND Letra             = '{0}',", letra)
         .AppendFormatLine("   AND CentroEmisor      =  {0}, ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante =  {0}, ", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor       =  {0}, ", idProveedor)
         .AppendFormatLine("   AND IdGrupoCama       = '{0}' ", idGrupoCama)
      End With
      Execute(stb)
   End Sub

   Public Sub ComprasDistribucionPorGrupo_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                            idProveedor As Long, IdGrupoCama As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ComprasDistribucionPorGrupo")
         .AppendFormatLine(" WHERE IdSucursal        =  {0}  ", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}' ", idTipoComprobante)
         .AppendFormatLine("   AND Letra             = '{0}' ", letra)
         .AppendFormatLine("   AND CentroEmisor      =  {0}  ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante =  {0}  ", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor       =  {0}  ", idProveedor)
         If IdGrupoCama <> 0 Then
            .AppendFormatLine("   AND IdGrupoCama       = '{0}' ", IdGrupoCama)
         End If
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT S.*")
         .AppendFormatLine("     , GC.NombreGrupoCama")
         .AppendFormatLine("  FROM ComprasDistribucionPorGrupo S")
         .AppendFormatLine("  LEFT JOIN GruposCamas GC ON GC.IdGrupoCama = S.IdGrupoCama")
      End With
   End Sub

   Public Function ComprasDistribucionPorGrupo_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
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
                    New Dictionary(Of String, String) From {{"NombreGrupoCama", "GC.NombreGrupoCama"}})
   End Function

End Class