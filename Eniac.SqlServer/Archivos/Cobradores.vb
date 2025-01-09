Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class Cobradores
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Cobradores_I(idCobrador As Integer,
                           nombreCobrador As String,
                           debitoDirecto As Boolean,
                           idBanco As Integer,
                           idDispositivo As String)

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("INSERT INTO Cobradores")
         .AppendLine("   (IdCobrador")
         .AppendLine("   ,NombreCobrador")
         .AppendLine("   ,DebitoDirecto")
         .AppendLine("   ,idBanco")
         .AppendLine("   ,IdDispositivo")
         .AppendLine(" ) VALUES ( ")
         .AppendLine("   " & idCobrador.ToString())
         .AppendLine("   ,'" & nombreCobrador & "'")
         .AppendLine("   ,'" & GetStringFromBoolean(debitoDirecto) & "'")
         If debitoDirecto Then
            .AppendLine("   ," & idBanco)
         Else
            .AppendLine("   ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idDispositivo) Then
            .AppendFormat("   ,'{0}'", idDispositivo).AppendLine()
         Else
            .AppendLine("   ,NULL")
         End If

         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub Cobradores_U(idCobrador As Integer,
                           nombreCobrador As String,
                           debitoDirecto As Boolean,
                           idBanco As Integer,
                           idDispositivo As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("UPDATE Cobradores SET ")
         .AppendLine("   NombreCobrador = '" & nombreCobrador & "'")
         .AppendLine("   ,DebitoDirecto = '" & GetStringFromBoolean(debitoDirecto) & "'")
         If debitoDirecto Then
            .AppendLine("   ,idBanco = " & idBanco)
         Else
            .AppendLine("   ,idBanco = NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idDispositivo) Then
            .AppendFormat("   ,IdDispositivo = '{0}'", idDispositivo).AppendLine()
         Else
            .AppendLine("   ,IdDispositivo = NULL")
         End If

         .AppendLine(" WHERE IdCobrador = " & idCobrador.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub Cobradores_D(ByVal idCobrador As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM Cobradores")
         .AppendLine(" WHERE IdCobrador = " & idCobrador.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT C.*")
         .AppendLine("      ,B.NombreBanco")
         .AppendLine("      ,CS.IdCaja")
         .AppendLine("      ,CN.NombreCaja")
         .AppendLine("      ,CS.Observacion")
         .AppendLine(" FROM Cobradores C")
         .AppendLine(" LEFT JOIN Bancos B ON B.Idbanco = C.IdBanco")
         .AppendFormat(" LEFT JOIN CobradoresSucursales CS ON CS.IdCobrador = C.IdCobrador AND CS.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendLine(" LEFT JOIN CajasNombres CN ON CN.IdSucursal = CS.IdSucursal AND CN.IdCaja = CS.IdCaja")
      End With
   End Sub

   Public Function Cobradores_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY C.NombreCobrador")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cobradores_DebitosDirectos() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  WHERE C.DebitoDirecto = 'True' ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cobradores_G1(ByVal idCobrador As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE C.IdCobrador = " & idCobrador.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorNombre(ByVal nombreCobrador As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE C.NombreCobrador LIKE '%" & nombreCobrador & "%'")
         .AppendLine(" ORDER BY C.NombreCobrador")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = "NombreBanco" Then
         columna = "B." + columna
      ElseIf columna = "IdCaja" Or columna = "Observacion" Then
         columna = "CS." + columna
      ElseIf columna = "NombreCaja" Then
         columna = "CN." + columna
      Else
         columna = "C." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE " & columna & " LIKE '%" & valor & "%'")
         .AppendLine(" ORDER BY C.NombreCobrador")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cobradores_GetIdMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdCobrador) AS maximo ")
         .AppendLine(" FROM Cobradores")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class