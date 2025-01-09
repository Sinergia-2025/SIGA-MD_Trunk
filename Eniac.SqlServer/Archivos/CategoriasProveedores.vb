Imports System.Text

Public Class CategoriasProveedores
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasProveedores_I(ByVal idCategoria As Integer,
                                      ByVal nombreCategoria As String,
                                      ByVal IdCuentaContable As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO CategoriasProveedores (")
         .AppendLine("   IdCategoria")
         .AppendLine("  ,NombreCategoria")
         .AppendLine("  ,IdCuentaContable")
         .AppendLine(" ) VALUES (")
         .AppendLine("   " & idCategoria.ToString())
         .AppendLine("  ,'" & nombreCategoria & "'")
         If IdCuentaContable > 0 Then
            .AppendLine("  ," & IdCuentaContable)
         Else
            .AppendLine("  ,NULL")
         End If
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasProveedores")

   End Sub

   Public Sub CategoriasProveedores_U(ByVal idCategoria As Integer,
                                      ByVal nombreCategoria As String,
                                      ByVal IdCuentaContable As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CategoriasProveedores SET ")
         .AppendLine("    NombreCategoria = '" & nombreCategoria & "'")
         If IdCuentaContable > 0 Then
            .AppendFormat("  , IdCuentaContable = {0}", IdCuentaContable).AppendLine()
         Else
            .AppendFormat("  , IdCuentaContable = NULL").AppendLine()
         End If
         .AppendLine("  WHERE idCategoria = " & idCategoria.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasProveedores")

   End Sub

   Public Sub CategoriasProveedores_D(ByVal idCategoria As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM CategoriasProveedores ")
         .AppendLine(" WHERE idCategoria = " & idCategoria.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasProveedores")

   End Sub

   Public Function CategoriasProveedores_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT CP.IdCategoria")
         .AppendLine("      ,CP.NombreCategoria")
         .AppendLine("      ,CP.IdCuentaContable")
         .AppendLine("      ,CC.NombreCuenta")
         .AppendLine("  FROM CategoriasProveedores CP")
         .AppendLine(" LEFT OUTER JOIN ContabilidadCuentas CC ON CC.IdCuenta = CP.IdCuentaContable")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function CategoriasProveedores_GetIdMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdCategoria) AS maximo ")
         .AppendLine(" FROM CategoriasProveedores")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
