Public Class CuentasBancariasClase
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasBancariasClase_I(ByVal idCuentaBancariaClase As Integer, _
                                       ByVal nombreCuentaBancariaClase As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("CuentasBancariasClase  ")
         .Append("(IdCuentaBancariaClase, ")
         .Append("NombreCuentaBancariaClase) ")
         .Append("VALUES (")
         .Append(idCuentaBancariaClase.ToString() & ", ")
         .Append("'" & nombreCuentaBancariaClase & "')")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasBancariasClase")

   End Sub

   Public Sub CuentasBancariasClase_U(ByVal idCuentaBancariaClase As Integer, _
                                       ByVal nombreCuentaBancariaClase As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE ")
         .Append("CuentasBancariasClase ")
         .Append("SET ")

         .Append("NombreCuentaBancariaClase = '" & nombreCuentaBancariaClase & "'")

         .Append("WHERE ")
         .Append("IdCuentaBancariaClase = " & idCuentaBancariaClase.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasBancariasClase")

   End Sub

   Public Sub CuentasBancariasClase_D(ByVal idCuentaBancariaClase As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM ")
         .Append("CuentasBancariasClase ")
         .Append("WHERE ")
         .Append("IdCuentaBancariaClase = " & idCuentaBancariaClase.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasBancariasClase")

   End Sub


    Private Sub SelectTexto(stb As StringBuilder)
        With stb
            .AppendLine("SELECT ")
            .AppendLine("      CBC.IdCuentaBancariaClase,")
            .AppendLine("      CBC.NombreCuentaBancariaClase")
            .AppendLine("      FROM CuentasBancariasClase CBC")
        End With
    End Sub

    Public Function CuentasBancariasClase_GA() As DataTable
        Dim myQuery As StringBuilder = New StringBuilder()
        With myQuery
            Me.SelectTexto(myQuery)
            .AppendFormat(" ORDER BY  CBC.NombreCuentaBancariaClase")
        End With
        Return Me.GetDataTable(myQuery.ToString())
    End Function

    Public Function CuentasBancariasClase_G1(IdCuentaBancariaClase As Integer) As DataTable
        Dim stb As StringBuilder = New StringBuilder()
        With stb
            Me.SelectTexto(stb)
            .AppendFormat(" WHERE CBC.{0} = {1}", Entidades.CuentaBancariaClase.Columnas.IdCuentaBancariaClase.ToString(), IdCuentaBancariaClase)
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

    Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

        Dim stb As StringBuilder = New StringBuilder()
        With stb
            Me.SelectTexto(stb)
            .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

   Public Function GetFiltradoPorNombre(nombreCuentaBancariaClase As String) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendFormat(" where NombreCuentaBancariaClase like '%{0}%' ", nombreCuentaBancariaClase)
         .Append(" Order By IdCuentaBancariaClase")
      End With
      Return Me.GetDataTable(query.tostring())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CuentaBancariaClase.Columnas.IdCuentaBancariaClase.ToString(), "CuentasBancariasClase"))
   End Function

End Class
