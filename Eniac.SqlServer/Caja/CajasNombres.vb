Imports System.Text

Public Class CajasNombres
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CajasNombres_I(idSucursal As Integer,
                             idCaja As Integer,
                             nombreCaja As String,
                             nombrePC As String,
                             idUsuario As String,
                             idPlanCuenta As Integer,
                             topeAviso As Double,
                             topeBloqueo As Double,
                             idCuentaContable As Long,
                             color As Integer?,
                             IdTipoComprobanteF3 As String,
                             IdtipoComprobanteF4 As String,
                             IdTipoComprobanteF10Origen As String,
                             IdTipoComprobanteF10Destino As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Append("INSERT INTO CajasNombres  ")
         .Append("    (IdSucursal")
         .Append("    ,IdCaja")
         .Append("    ,NombreCaja")
         .Append("    ,NombrePC")
         .Append("    ,IdUsuario")
         .Append("    ,idPlanCuenta")
         .Append("    ,TopeAviso")
         .Append("    ,TopeBloqueo")
         .Append("    ,IdCuentaContable")
         .Append("    ,Color")
         .AppendLine(" ,IdTipoComprobanteF3")
         .AppendLine(" ,IdTipoComprobanteF4")
         .AppendLine(" ,IdTipoComprobanteF10Origen")
         .AppendLine(" ,IdTipoComprobanteF10Destino")
         .Append("  ) VALUES (")
         .Append(idSucursal.ToString())
         .Append(", " & idCaja.ToString())
         .Append(", '" & nombreCaja & "'")
         .Append(", '" & nombrePC & "'")
         If Not String.IsNullOrEmpty(idUsuario) Then
            .Append(", '" & idUsuario & "'")
         Else
            .Append(", NULL")
         End If

         If idPlanCuenta > 0 Then
            .AppendLine(", " & idPlanCuenta.ToString())
         Else
            .AppendLine(", NULL")
         End If

         .Append(", " & topeAviso.ToString())
         .Append(", " & topeBloqueo.ToString())


         If idCuentaContable > 0 Then
            .AppendLine(", " & idCuentaContable.ToString())
         Else
            .AppendLine(", NULL")
         End If

         If color.HasValue Then
            .AppendLine(", " & color.Value.ToString())
         Else
            .AppendLine(", NULL")
         End If

         If Not String.IsNullOrEmpty(IdTipoComprobanteF3) Then
            .Append(", '" & IdTipoComprobanteF3 & "'")
         Else
            .Append(", NULL")
         End If

         If Not String.IsNullOrEmpty(IdtipoComprobanteF4) Then
            .Append(", '" & IdtipoComprobanteF4 & "'")
         Else
            .Append(", NULL")
         End If

         If Not String.IsNullOrEmpty(IdTipoComprobanteF10Origen) Then
            .Append(", '" & IdTipoComprobanteF10Origen & "'")
         Else
            .Append(", NULL")
         End If
         If Not String.IsNullOrEmpty(IdTipoComprobanteF10Destino) Then
            .Append(", '" & IdTipoComprobanteF10Destino & "'")
         Else
            .Append(", NULL")
         End If

         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CajasNombres")

   End Sub

   Public Sub CajasNombres_U(idSucursal As Integer,
                             idCaja As Integer,
                             nombreCaja As String,
                             nombrePC As String,
                             idUsuario As String,
                             idPlanCuenta As Integer,
                             topeAviso As Double,
                             topeBloqueo As Double,
                             idCuentaContable As Long,
                             color As Integer?,
                             IdTipoComprobanteF3 As String,
                             IdtipoComprobanteF4 As String,
                             IdTipoComprobanteF10Origen As String,
                             IdTipoComprobanteF10Destino As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CajasNombres")
         .AppendLine("   SET NombreCaja = '" & nombreCaja & "'")
         .AppendLine("     , NombrePC = '" & nombrePC & "'")
         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("     , IdUsuario = '" & idUsuario & "'")
         Else
            .AppendLine("     , IdUsuario = NULL")
         End If
         If idPlanCuenta > 0 Then
            .AppendLine("     , IdPlanCuenta = " & idPlanCuenta.ToString)
         Else
            .AppendLine("     , IdPlanCuenta = NULL")
         End If
         .AppendLine("     , TopeAviso = " & topeAviso.ToString())
         .AppendLine("     , TopeBloqueo = " & topeBloqueo.ToString())
         If idCuentaContable > 0 Then
            .AppendLine("     , IdCuentaContable = " & idCuentaContable.ToString)
         Else
            .AppendLine("     , IdCuentaContable = NULL")
         End If
         If color.HasValue Then
            .AppendLine("     , Color = " & color.Value.ToString())
         Else
            .AppendLine("     , Color = NULL")
         End If

         If Not String.IsNullOrEmpty(IdTipoComprobanteF3) Then
            .AppendLine("     , IdTipoComprobanteF3 = '" & IdTipoComprobanteF3 & "'")
         Else
            .AppendLine("     , IdTipoComprobanteF3 = NULL")
         End If

         If Not String.IsNullOrEmpty(IdtipoComprobanteF4) Then
            .AppendLine("     , IdtipoComprobanteF4 = '" & IdtipoComprobanteF4 & "'")
         Else
            .AppendLine("     , IdtipoComprobanteF4 = NULL")
         End If

         If Not String.IsNullOrEmpty(IdTipoComprobanteF10Origen) Then
            .AppendLine("     , IdTipoComprobanteF10Origen = '" & IdTipoComprobanteF10Origen & "'")
         Else
            .AppendLine("     , IdTipoComprobanteF10Origen = NULL")
         End If

         If Not String.IsNullOrEmpty(IdTipoComprobanteF10Destino) Then
            .AppendLine("     , IdTipoComprobanteF10Destino = '" & IdTipoComprobanteF10Destino & "'")
         Else
            .AppendLine("     , IdTipoComprobanteF10Destino = NULL")
         End If

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdCaja = " & idCaja.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CajasNombres")

   End Sub

   Public Sub CajasNombres_D(ByVal IdSucursal As Integer, _
                             ByVal IdCaja As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CajasNombres")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         If IdCaja > 0 Then
            .AppendLine("  AND IdCaja = " & IdCaja.ToString())
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CajasNombres")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT CN.IdSucursal")
         .AppendLine("      ,S.Nombre")
         .AppendLine("      ,CN.IdCaja")
         .AppendLine("      ,CN.NombreCaja")
         .AppendLine("      ,CN.NombrePC")
         .AppendLine("      ,CN.IdUsuario")
         .AppendLine("      ,CN.IdplanCuenta")
         .AppendLine("      ,CP.NombrePlanCuenta")
         .AppendLine("      ,CN.TopeAviso")
         .AppendLine("      ,CN.TopeBloqueo")
         .AppendLine("      ,CN.idCuentaContable")
         .AppendLine("      ,CC.NombreCuenta")
         .AppendLine("      ,CN.Color")
         .AppendLine("      ,CN.IdTipoComprobanteF3")
         .AppendLine("      ,CN.IdTipoComprobanteF4")
         .AppendLine("      ,CN.IdTipoComprobanteF10Origen")
         .AppendLine("      ,CN.IdTipoComprobanteF10Destino")

         .AppendLine("  FROM CajasNombres CN")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = CN.IdSucursal")
         .AppendLine("  LEFT JOIN ContabilidadPlanes CP ON CP.IdPlanCuenta = CN.IdPlanCuenta")
         .AppendLine("  LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = CN.IdCuentaContable")
      End With
   End Sub

   Public Function CajasNombres_GA(ByVal IdSucursal As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         If IdSucursal > 0 Then
            .AppendLine("  WHERE CN.IdSucursal = " & IdSucursal.ToString())
         End If
         .AppendLine(" ORDER BY S.Nombre, CN.NombreCaja")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CajasNombres_GA(sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         'If IdSucursal > 0 Then
         '   .AppendLine("  WHERE CN.IdSucursal = " & IdSucursal.ToString())
         'End If
         .AppendLine("  WHERE 1 = 1")
         SqlServer.Comunes.GetListaSucursalesMultiples(myQuery, sucursales, "CN")

         If Not String.IsNullOrEmpty(usuario) Then
            .AppendLine("   and cu.IdUsuario = '" & usuario & "'")
         End If
         If Not String.IsNullOrEmpty(nombrePC) Then
            .AppendLine("   AND cn.NombrePC = '" & nombrePC & "'")
         End If
         If cajasModificables = True Then
            .AppendLine(" AND CU.PermitirEscritura = 'True'")
         End If

         .AppendLine(" ORDER BY S.Nombre, CN.NombreCaja")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CajasNombres_G1(ByVal IdSucursal As Integer, _
                       ByVal IdCaja As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE CN.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND CN.IdCaja = " & IdCaja.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String, idSucursal As Integer) As DataTable
      If columna = "Nombre" Then
         columna = "S." + columna
      ElseIf columna = "NombrePlanCuenta" Then
         columna = "CP" + columna
      ElseIf columna = "NombreCuenta" Then
         columna = "CC" + columna
      Else
         columna = "CN." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class