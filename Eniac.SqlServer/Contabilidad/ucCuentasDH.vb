Public Class ucCuentasDH
    Inherits Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
   End Sub

   Public Function Existe(idRubro As Integer,
                          idCuenta As Long,
                          idPlanCuenta As Integer) As Boolean
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Append("SELECT [idRubro]")
         .Append("      ,[IdCuenta]")
         .Append("      ,[IdPlanCuenta]")
         .Append("      ,[Tipo]")
         .Append("      ,[debe]")
         .Append("      ,[haber]")
         .Append("      ,[grupoAsiento]")
         .Append("      ,[Campo]")
         .Append("  FROM ContabilidadCuentasRubros")
         .AppendFormat("  WHERE [idRubro] = {0}", idRubro)
         .AppendFormat("     and [IdCuenta] = {0}", idCuenta)
         .AppendFormat("     and [IdPlanCuenta] = {0}", idPlanCuenta)
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows IsNot Nothing AndAlso dt.Rows.Count > 0 Then
         Return True
      End If

      Return False
   End Function

   Public Sub CuentaRubro_I(idRubro As Integer,
                            idPlanCuenta As Integer,
                            tipo As String,
                            idCuenta As Long,
                            imputaDebe As Boolean,
                            imputaHaber As Boolean,
                            campo As String)

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ContabilidadCuentasRubros")
         .AppendLine("   (idRubro,IdCuenta,idPlanCuenta,tipo")
         .AppendLine("   ,debe,haber,campo")
         .AppendLine(" ) VALUES ( ")
         .AppendLine("   " & idRubro.ToString())
         .AppendLine("   ," & idCuenta)
         .AppendLine("   ," & idPlanCuenta.ToString())
         .AppendLine("   ,'" & tipo & "'")
         .AppendLine("   ,'" & imputaDebe.ToString & "'")
         .AppendLine("   ,'" & imputaHaber.ToString & "'")
         .AppendLine("   ,'" & campo & "'")
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())


   End Sub



   Public Sub CuentaRubro_D(idPlanCuenta As Integer,
                            idRubro As Integer,
                            tipo As String)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ContabilidadCuentasRubros")
         .AppendLine(" WHERE idPlanCuenta = " & idPlanCuenta.ToString())
         .AppendLine("   and idrubro = " & idRubro.ToString())
         .AppendLine("   and tipo = '" & tipo & "'")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub EliminoUnaCuenta(idRubro As Integer,
                               idPlanCuenta As Integer,
                               idCuenta As Long)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ContabilidadCuentasRubros")
         .AppendFormat(" WHERE idPlanCuenta = {0}", idPlanCuenta)
         .AppendFormat("   and idrubro = {0}", idRubro)
         .AppendFormat("   and IdCuenta = {0}", idCuenta)
      End With

      Me.Execute(stb.ToString())
   End Sub

End Class