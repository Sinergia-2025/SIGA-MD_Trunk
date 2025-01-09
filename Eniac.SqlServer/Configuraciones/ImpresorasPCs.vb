

Public Class ImpresorasPCs
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ImpresorasPCs_I(ByVal nombrePC As String, ByVal idImpresora As String, ByVal idSucursal As Integer)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("INSERT INTO ImpresorasPCs	(")
         .Append("           NombrePC")
         .Append("           ,IdImpresora")
         .Append("           ,IdSucursal")
         .Append(")     VALUES (")
         .AppendFormat("           '{0}'", nombrePC)
         .AppendFormat("           ,'{0}'", idImpresora)
         .AppendFormat("           ,{0}", idSucursal)
         .Append(")")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ImpresorasPCs_D(ByVal nombrePC As String, ByVal idImpresora As String, ByVal idSucursal As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM ImpresorasPCs")
         .Append("      WHERE ")
         .AppendFormat("   NombrePC = '{0}'", nombrePC)
         .AppendFormat("   AND IdImpresora = '{0}'", idImpresora)
         .AppendFormat("   AND IdSucursal = {0}", idSucursal)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ImpresorasPCs_DAll(ByVal idImpresora As String, ByVal idSucursal As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM ImpresorasPCs")
         .Append("      WHERE ")
         .AppendFormat("   IdImpresora = '{0}'", idImpresora)
         .AppendFormat("   AND IdSucursal = {0}", idSucursal)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT IP.NombrePC")
         .Append("      ,IP.IdImpresora")
         .Append("      ,IP.IdSucursal")
         .Append("  FROM ImpresorasPCs IP")
      End With
   End Sub

   Public Function ImpresorasPCs_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY IP.NombrePC")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ImpresorasPCs_G1(ByVal nombrePC As String, ByVal idImpresora As String, ByVal idSucursal As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("   WHERE NombrePC = '{0}'", nombrePC)
         .AppendFormat("   AND IdImpresora = '{0}'", idImpresora)
         .AppendFormat("   AND IdSucursal = {0}", idSucursal)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "IP." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPCs(ByVal idImpresora As String, ByVal idSucursal As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("   WHERE ")
         .AppendFormat("   IdImpresora = '{0}'", idImpresora)
         .AppendFormat("   AND IdSucursal = {0}", idSucursal)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
