Public Class TiposMovimientos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposMovimientos_I(idTipoMovimiento As String,
                                 descripcion As String,
                                 coeficienteStock As Integer,
                                 comprobantesAsociados As String,
                                 asociaSucursal As Boolean,
                                 muestraCombo As Boolean,
                                 habilitaDestinatario As Boolean,
                                 habilitaRubro As Boolean,
                                 imprime As Boolean,
                                 cargaPrecio As String,
                                 idContraTipoMovimiento As String,
                                 habilitaEmpleado As Boolean,
                                 reservaMercaderia As Boolean)


      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Append("INSERT INTO TiposMovimientos")
         .Append("           (IdTipoMovimiento")
         .Append("           ,Descripcion")
         .Append("           ,CoeficienteStock")
         .Append("           ,ComprobantesAsociados")
         .Append("           ,AsociaSucursal")
         .Append("           ,MuestraCombo")
         .Append("           ,HabilitaDestinatario")
         .Append("           ,HabilitaRubro")
         .Append("           ,Imprime")
         .Append("           ,CargaPrecio")
         .Append("           ,IdContraTipoMovimiento")
         .Append("           ,HabilitaEmpleado")
         .Append("           ,ReservaMercaderia")
         .Append("    ) VALUES (")
         .Append("   '" & idTipoMovimiento & "'")
         .Append(",  '" & descripcion & "'")
         .Append(",   " & coeficienteStock)

         If Not String.IsNullOrEmpty(comprobantesAsociados) Then
            .Append(",  '" & comprobantesAsociados & "'")
         Else
            .AppendLine(", Null")
         End If

         .Append(",  '" & asociaSucursal & "'")
         .Append(",  '" & muestraCombo & "'")
         .Append(",  '" & habilitaDestinatario & "'")
         .Append(",  '" & habilitaRubro & "'")
         .Append(",  '" & imprime & "'")
         .Append(",  '" & cargaPrecio & "'")
         If Not String.IsNullOrEmpty(idContraTipoMovimiento) Then
            .Append(",  '" & comprobantesAsociados & "'")
         Else
            .AppendLine(", Null")
         End If
         .AppendFormat(" ,{0}", GetStringFromBoolean(habilitaEmpleado)).AppendLine()
         .AppendFormat(" ,{0}", GetStringFromBoolean(reservaMercaderia)).AppendLine()
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposMovimientos")
   End Sub


   Public Sub TiposMovimientos_U(idTipoMovimiento As String,
                                 descripcion As String,
                                 coeficienteStock As Integer,
                                 comprobantesAsociados As String,
                                 asociaSucursal As Boolean,
                                 muestraCombo As Boolean,
                                 habilitaDestinatario As Boolean,
                                 habilitaRubro As Boolean,
                                 imprime As Boolean,
                                 cargaPrecio As String,
                                 idContraTipoMovimiento As String,
                                 habilitaEmpleado As Boolean,
                                 reservaMercaderia As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("TiposMovimientos  ")
         .Append("SET  ")

         .Append("   Descripcion = '" & descripcion & "'")
         .Append(",  CoeficienteStock = " & coeficienteStock & "")

         If Not String.IsNullOrEmpty(comprobantesAsociados) Then
            .Append(",  ComprobantesAsociados = '" & comprobantesAsociados & "'")
         Else
            .AppendLine(",  ComprobantesAsociados = Null")
         End If

         .Append(",  AsociaSucursal = '" & asociaSucursal & "'")
         .Append(",  MuestraCombo = '" & muestraCombo & "'")
         .Append(",  HabilitaDestinatario = '" & habilitaDestinatario & "'")
         .Append(",  HabilitaRubro = '" & habilitaRubro & "'")
         .Append(",  Imprime = '" & imprime & "'")
         .Append(",  CargaPrecio = '" & cargaPrecio & "'")

         If Not String.IsNullOrEmpty(idContraTipoMovimiento) Then
            .Append(",  IdContraTipoMovimiento = '" & idContraTipoMovimiento & "'")
         Else
            .AppendLine(",  IdContraTipoMovimiento = Null")
         End If

         .AppendFormat(" ,HabilitaEmpleado = {0}", GetStringFromBoolean(habilitaEmpleado))

         .AppendFormat(" ,ReservaMercaderia = {0}", GetStringFromBoolean(reservaMercaderia))

         .Append("WHERE ")
         .Append("IdTipoMovimiento = '" & idTipoMovimiento & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposMovimientos")
   End Sub

   Public Sub TiposMovimientos_D(ByVal idTipoMovimiento As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("TiposMovimientos  ")
         .Append("WHERE  ")
         .Append("IdTipoMovimiento = '" & idTipoMovimiento & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "TiposMovimientos")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT TM.*")
         .AppendLine("  FROM TiposMovimientos TM")
      End With
   End Sub


   Public Function TiposMovimientos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         SelectTexto(myQuery)
         .AppendLine("  ORDER BY TM.Descripcion")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "TM." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class