Public Class ContabilidadCuentasTitulos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function obtenerUltimaCuenta3(ByVal idCuenta As String) As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      '2 02 01

      With stb
         .AppendLine("SELECT max(substring(str(IdCuenta),6,2))+1 as siguiente ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendLine(" WHERE substring(str(IdCuenta),3,1)= '" & IdCuenta.Substring(0, 1) & "'")
         .AppendLine(" and substring(str(IdCuenta),4,2)= '" & IdCuenta.Substring(1, 2) & "'")
         '.AppendLine(" and substring(str(IdCuenta),6,2)<> '00'")
         .AppendLine(" and substring(str(IdCuenta),8,3)= '000'")
      End With

      Return CInt((IdCuenta.Substring(0, 3) & CStr(Me.GetDataTable(stb.ToString()).Rows(0)("siguiente")).PadLeft(2, "0"c)).PadRight(8, "0"c))




   End Function

   Public Function obtenerUltimaCuenta4(ByVal idCuenta As String) As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      '2 02 01

      With stb
         .AppendLine("SELECT max(substring(str(IdCuenta),8,3))+1 as siguiente ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendLine(" WHERE substring(str(IdCuenta),3,1)= '" & IdCuenta.Substring(0, 1) & "'")
         .AppendLine(" and substring(str(IdCuenta),4,2)= '" & IdCuenta.Substring(1, 2) & "'")
         .AppendLine(" and substring(str(IdCuenta),6,2)= '" & IdCuenta.Substring(3, 2) & "'")
         ' .AppendLine(" and substring(str(IdCuenta),8,3)<> '000'")
      End With

      Return CInt((IdCuenta.Substring(0, 5) & CStr(Me.GetDataTable(stb.ToString()).Rows(0)("siguiente")).PadLeft(3, "0"c)))




   End Function

   Public Sub Cuentas_I(ByVal IdCuenta As Integer, _
                               ByVal NombreCuenta As String, _
                               ByVal nivel As Integer, _
                               ByVal IdCentroCosto As Integer, _
                               ByVal esImputable As Boolean, _
                               ByVal activa As Boolean)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("INSERT INTO ContabilidadCuentas")
         .AppendLine("   (IdCuenta")
         .AppendLine("   ,NombreCuenta")
         .AppendLine("   ,nivel")
         .AppendLine("   ,IdCentroCosto")
         .AppendLine("   ,esImputable")
         .AppendLine("   ,activa")

         .AppendLine(" ) VALUES ( ")
         .AppendLine("   " & IdCuenta.ToString())
         .AppendLine("   ,'" & NombreCuenta & "'")
         .AppendLine("   ," & nivel.ToString())
         .AppendLine("   ," & IdCentroCosto.ToString())
         .AppendLine("   ,'" & esImputable.ToString() & "'")
         .AppendLine("   ,'" & activa.ToString() & "'")
         .AppendLine(")")

      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub Cuentas_U(ByVal IdCuenta As Long, _
                               ByVal NombreCuenta As String, _
                              ByVal IdCentroCosto As Integer, _
                               ByVal activa As Boolean)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("UPDATE ContabilidadCuentas SET ")
         .AppendLine("   NombreCuenta = '" & NombreCuenta & "'")
         .AppendLine("   ,IdCentroCosto = " & IdCentroCosto.ToString)
         .AppendLine("   ,activa = '" & activa.ToString() & "'")
         .AppendLine(" WHERE IdCuenta = " & IdCuenta.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub Cuentas_D(ByVal IdCuenta As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM ContabilidadCuentas")
         .AppendLine(" WHERE IdCuenta = " & IdCuenta.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT C.* ")
         .AppendLine(" FROM ContabilidadCuentas C")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "C." + columna
      'If columna = "N.NombreAreaComun" Then columna = columna.Replace("N.", "AC.")
      'If columna = "N.NombrePorteria" Then columna = columna.Replace("N.", "P.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE substring(str(C.IdCuenta),8,3)= '000' AND " & columna & " LIKE '%" & valor & "%'")
         .AppendLine(" AND substring(str(C.IdCuenta),6,2)<> '00'")
         .AppendFormat("")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cuentas_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append(" WHERE  substring(str(c.IdCuenta),8,3)= '000'") ' solo muestro las cuentas nivel 3
         .AppendLine(" and substring(str(C.IdCuenta),6,2)<> '00'")
         .Append("  ORDER BY C.NombreCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cuentas_G1(ByVal IdCuenta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT * ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendLine(" WHERE substring(str(IdCuenta),6,2)= '" & IdCuenta.ToString.Substring(3, 2) & "'")
         .AppendLine(" and substring(str(IdCuenta),3,1)= '" & IdCuenta.ToString.Substring(0, 1) & "'")
         .AppendLine(" and substring(str(IdCuenta),4,2)= '" & IdCuenta.ToString.Substring(1, 2) & "'")
         .AppendLine(" and substring(str(IdCuenta),8,3)= '000'")
         '.AppendLine(" and substring(str(IdCuenta),8,3)= '" & IdCuenta.ToString.Substring(5, 3) & "'")

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorNombre(ByVal NombreCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE C.NombreCuenta LIKE '%" & NombreCuenta & "%'")
         .AppendLine(" ORDER BY C.NombreCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cuenta_GetIdMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdCuenta) AS maximo ")
         .AppendLine(" FROM ContabilidadCuentas")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   ''' <summary>
   '''  para las de nivel 3
   ''' </summary>
   ''' <param name="IdCuenta"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function TieneHijosLaCuenta(ByVal IdCuenta As Integer) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdCuenta ")
         .AppendLine(" FROM ContabilidadCuentas ")

         .AppendLine(" WHERE substring(str(IdCuenta),6,2)= '" & IdCuenta.ToString.Substring(3, 2) & "'")
         .AppendLine(" and substring(str(IdCuenta),3,1)= '" & IdCuenta.ToString.Substring(0, 1) & "'")
         .AppendLine(" and substring(str(IdCuenta),4,2)= '" & IdCuenta.ToString.Substring(1, 2) & "'")
         .AppendLine(" and substring(str(IdCuenta),8,3)<> '000'")

      End With

      Return Me.GetDataTable(stb.ToString()).Rows.Count > 1

   End Function

   Public Function Cuentas_nivel2(ByVal nivel1 As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT IdCuenta,NombreCuenta ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendLine(" WHERE substring(str(IdCuenta),3,1)= '" & nivel1.Substring(0, 1) & "'")
         .AppendLine(" and substring(str(IdCuenta),6,5)= '00000'")

      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function Cuentas_nivel3(ByVal nivel2 As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT IdCuenta,NombreCuenta ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendLine(" WHERE substring(str(IdCuenta),3,1)= '" & nivel2.Substring(0, 1) & "'")
         .AppendLine(" and substring(str(IdCuenta),4,2)= '" & nivel2.Substring(1, 2) & "'")
         .AppendLine(" and substring(str(IdCuenta),6,2)<> '00'")
         .AppendLine(" and substring(str(IdCuenta),8,3)= '000'")
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function CuentasNivel3ALL() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT IdCuenta,NombreCuenta ")
         .AppendLine(" FROM ContabilidadCuentas ")
         '.AppendLine(" WHERE substring(str(IdCuenta),3,1)= '" & nivel2.Substring(0, 1) & "'")
         '.AppendLine(" and substring(str(IdCuenta),4,2)= '" & nivel2.Substring(1, 2) & "'")
         '.AppendLine(" and substring(str(IdCuenta),6,2)<> '00'")
         .AppendLine(" WHERE  substring(str(IdCuenta),8,3)= '000'")
         .AppendLine(" and substring(str(IdCuenta),6,2)<> '00'")

      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function Cuentas_nivel4(ByVal nivel3 As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT IdCuenta,NombreCuenta ")
         .AppendLine(" FROM ContabilidadCuentas ")
         .AppendLine(" WHERE substring(str(IdCuenta),6,2)= '" & nivel3.Substring(3, 2) & "'")
         .AppendLine(" and substring(str(IdCuenta),3,1)= '" & nivel3.Substring(0, 1) & "'")
         .AppendLine(" and substring(str(IdCuenta),4,2)= '" & nivel3.Substring(1, 2) & "'")
         .AppendLine(" and substring(str(IdCuenta),8,3)<> '000'")
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
