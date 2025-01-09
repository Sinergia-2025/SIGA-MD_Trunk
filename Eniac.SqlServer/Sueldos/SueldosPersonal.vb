Public Class SueldosPersonal

    Inherits Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

   Public Sub SueldosPersonal_I(ByVal idLegajo As Integer, _
                                   ByVal NombrePersonal As String, _
                                   ByVal Domicilio As String, _
                                   ByVal IdLocalidad As Integer, _
                                   ByVal TipoDocPersonal As String, _
                                   ByVal NroDocPersonal As Long, _
                                   ByVal idNacionalidad As Integer, _
                                   ByVal Sexo As String, _
                                   ByVal IdEstadoCivil As Integer, _
                                   ByVal Cuil As Long, _
                                   ByVal LegajoMinTrabajo As Long, _
                                   ByVal idObraSocial As Integer, _
                                   ByVal CodObraSocial As Integer, _
                                   ByVal FechaNacimiento As DateTime, _
                                   ByVal FechaIngreso As DateTime, _
                                   ByVal FechaBaja As DateTime, _
                                   ByVal idCategoria As Integer, _
                                   ByVal CentroCosto As Integer, _
                                   ByVal SueldoBasico As Decimal, _
                                   ByVal MejorSueldo As Decimal, _
                                   ByVal AcumuladoAnual As Decimal, _
                                   ByVal AcumuladoSalarioFamiliar As Decimal, _
                                   ByVal SueldoActual As Decimal, _
                                   ByVal SalarioFamiliarActual As Decimal, _
                                   ByVal AFJP As String, _
                                   ByVal AnteriorAcumuladoAnual As Decimal, _
                                   ByVal AnteriorMejorSueldo As Decimal, _
                                   ByVal AnteriorSalarioFamiliar As Decimal, _
                                   ByVal IdMotivoBaja As Integer, _
                                   ByVal IdLugarActividad As Integer, _
                                   ByVal DatosFamiliares As String, _
                                   ByVal IdBancoCtaBancaria As Integer, _
                                   ByVal IdCuentasBancariasClaseCtaBancaria As Integer, _
                                   ByVal NumeroCuentaBancaria As String, _
                                   ByVal CBU As String)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO SueldosPersonal (")
         .Append("           idLegajo")
         .Append("           ,NombrePersonal")
         .Append("           ,Domicilio")
         .Append("           ,IdLocalidad")
         .Append("           ,TipoDocPersonal")
         .Append("           ,NroDocPersonal")
         .Append("           ,idNacionalidad")
         .Append("           ,Sexo")
         .Append("           ,IdEstadoCivil")
         .Append("           ,Cuil")
         .Append("           ,LegajoMinTrabajo")
         .Append("           ,idObraSocial")
         .Append("           ,CodObraSocial")
         .Append("           ,FechaNacimiento")
         .Append("           ,FechaIngreso")
         .Append("           ,FechaBaja")
         .Append("           ,idCategoria")
         .Append("           ,CentroCosto")
         .Append("           ,SueldoBasico")
         .Append("           ,MejorSueldo")
         .Append("           ,AcumuladoAnual")
         .Append("           ,AcumuladoSalarioFamiliar")
         .Append("           ,SueldoActual")
         .Append("           ,SalarioFamiliarActual")
         .Append("           ,AFJP")
         .Append("           ,AnteriorAcumuladoAnual")
         .Append("           ,AnteriorMejorSueldo")
         .Append("           ,AnteriorSalarioFamiliar")
         .Append("           ,IdMotivoBaja")
         .Append("           ,IdLugarActividad")
         .Append("           ,DatosFamiliares")
         .Append("           ,IdBancoCtaBancaria")
         .Append("           ,IdCuentasBancariasClaseCtaBancaria")
         .Append("           ,NumeroCuentaBancaria")
         .Append("           ,CBU")
         .Append(")     VALUES(")
         .AppendFormat("           {0}", idLegajo)
         .AppendFormat("           ,'{0}'", NombrePersonal)
         .AppendFormat("           ,'{0}'", Domicilio)
         .AppendFormat("           ,{0}", IdLocalidad)
         .AppendFormat("           ,'{0}'", TipoDocPersonal)
         .AppendFormat("           ,{0}", NroDocPersonal)
         .AppendFormat("           ,{0}", idNacionalidad)
         .AppendFormat("           ,'{0}'", Sexo)
         .AppendFormat("           ,{0}", IdEstadoCivil)
         .AppendFormat("           ,{0}", Cuil)
         .AppendFormat("           ,{0}", LegajoMinTrabajo)
         If idObraSocial = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", idObraSocial)
         End If
         .AppendFormat("           ,{0}", CodObraSocial)
         .AppendFormat("           ,'{0}'", FechaNacimiento.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("           ,'{0}'", FechaIngreso.ToString("yyyyMMdd HH:mm:ss"))
         If FechaBaja = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", FechaBaja.ToString("yyyyMMdd HH:mm:ss"))
         End If
         .AppendFormat("           ,{0}", idCategoria)
         .AppendFormat("           ,{0}", CentroCosto)
         .AppendFormat("           ,{0}", SueldoBasico)
         .AppendFormat("           ,{0}", MejorSueldo)
         .AppendFormat("           ,{0}", AcumuladoAnual)
         .AppendFormat("           ,{0}", AcumuladoSalarioFamiliar)
         .AppendFormat("           ,{0}", SueldoActual)
         .AppendFormat("           ,{0}", SalarioFamiliarActual)
         If String.IsNullOrEmpty(AFJP) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", AFJP)
         End If
         .AppendFormat("           ,{0}", AnteriorAcumuladoAnual)
         .AppendFormat("           ,{0}", AnteriorMejorSueldo)
         .AppendFormat("           ,{0}", AnteriorSalarioFamiliar)
         If IdMotivoBaja = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdMotivoBaja)
         End If
         If IdLugarActividad = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdLugarActividad)
         End If
         If String.IsNullOrEmpty(DatosFamiliares) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", DatosFamiliares)
         End If
         If IdBancoCtaBancaria = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdBancoCtaBancaria)
         End If
         If IdCuentasBancariasClaseCtaBancaria = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdCuentasBancariasClaseCtaBancaria)
         End If
         If String.IsNullOrEmpty(NumeroCuentaBancaria) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", NumeroCuentaBancaria)
         End If
         If Not String.IsNullOrEmpty(CBU) Then
            .AppendFormat("           ,'{0}'", CBU)
         Else
            .AppendFormat("           ,null")
         End If
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosPersonal")
   End Sub

   Public Sub SueldosPersonal_U(ByVal idLegajo As Integer, _
                              ByVal NombrePersonal As String, _
                              ByVal Domicilio As String, _
                              ByVal IdLocalidad As Integer, _
                              ByVal TipoDocPersonal As String, _
                              ByVal NroDocPersonal As Long, _
                              ByVal idNacionalidad As Integer, _
                              ByVal Sexo As String, _
                              ByVal IdEstadoCivil As Integer, _
                              ByVal Cuil As Long, _
                              ByVal LegajoMinTrabajo As Long, _
                              ByVal idObraSocial As Integer, _
                              ByVal CodObraSocial As Integer, _
                              ByVal FechaNacimiento As DateTime, _
                              ByVal FechaIngreso As DateTime, _
                              ByVal FechaBaja As DateTime, _
                              ByVal idCategoria As Integer, _
                              ByVal CentroCosto As Integer, _
                              ByVal SueldoBasico As Decimal, _
                              ByVal MejorSueldo As Decimal, _
                              ByVal AcumuladoAnual As Decimal, _
                              ByVal AcumuladoSalarioFamiliar As Decimal, _
                              ByVal SueldoActual As Decimal, _
                              ByVal SalarioFamiliarActual As Decimal, _
                              ByVal AFJP As String, _
                              ByVal AnteriorAcumuladoAnual As Decimal, _
                              ByVal AnteriorMejorSueldo As Decimal, _
                              ByVal AnteriorSalarioFamiliar As Decimal, _
                              ByVal IdMotivoBaja As Integer, _
                              ByVal IdLugarActividad As Integer, _
                              ByVal DatosFamiliares As String, _
                              ByVal IdBancoCtaBancaria As Integer, _
                              ByVal IdCuentasBancariasClaseCtaBancaria As Integer, _
                              ByVal NumeroCuentaBancaria As String, _
                              ByVal CBU As String)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE SueldosPersonal SET ")
         .AppendFormat("      idLegajo = {0}", idLegajo)
         .AppendFormat("      ,NombrePersonal = '{0}'", NombrePersonal)
         .AppendFormat("      ,Domicilio = '{0}'", Domicilio)
         .AppendFormat("      ,IdLocalidad = {0}", IdLocalidad)
         .AppendFormat("      ,TipoDocPersonal = '{0}'", TipoDocPersonal)
         .AppendFormat("      ,NroDocPersonal = {0}", NroDocPersonal)
         .AppendFormat("      ,idNacionalidad = {0}", idNacionalidad)
         .AppendFormat("      ,Sexo = '{0}'", Sexo)
         .AppendFormat("      ,IdEstadoCivil = {0}", IdEstadoCivil)
         .AppendFormat("      ,Cuil = {0}", Cuil)
         .AppendFormat("      ,LegajoMinTrabajo = {0}", LegajoMinTrabajo)
         If idObraSocial = 0 Then
            .AppendFormat("      ,idObraSocial = null")
         Else
            .AppendFormat("      ,idObraSocial = {0}", idObraSocial)
         End If
         .AppendFormat("      ,CodObraSocial = {0}", CodObraSocial)
         .AppendFormat("      ,FechaNacimiento = '{0}'", FechaNacimiento.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("      ,FechaIngreso = '{0}'", FechaIngreso.ToString("yyyyMMdd HH:mm:ss"))
         If FechaBaja = Nothing Then
            .AppendFormat("      ,FechaBaja = null")
         Else
            .AppendFormat("      ,FechaBaja = '{0}'", FechaBaja.ToString("yyyyMMdd HH:mm:ss"))
         End If
         .AppendFormat("      ,idCategoria = {0}", idCategoria)
         .AppendFormat("      ,CentroCosto = {0}", CentroCosto)
         .AppendFormat("      ,SueldoBasico = {0}", SueldoBasico)
         .AppendFormat("      ,MejorSueldo = {0}", MejorSueldo)
         .AppendFormat("      ,AcumuladoAnual = {0}", AcumuladoAnual)
         .AppendFormat("      ,AcumuladoSalarioFamiliar = {0}", AcumuladoSalarioFamiliar)
         .AppendFormat("      ,SueldoActual = {0}", SueldoActual)
         .AppendFormat("      ,SalarioFamiliarActual = {0}", SalarioFamiliarActual)
         If String.IsNullOrEmpty(AFJP) Then
            .AppendFormat("      ,AFJP = null")
         Else
            .AppendFormat("      ,AFJP = '{0}'", AFJP)
         End If
         .AppendFormat("      ,AnteriorAcumuladoAnual = {0}", AnteriorAcumuladoAnual)
         .AppendFormat("      ,AnteriorMejorSueldo = {0}", AnteriorMejorSueldo)
         .AppendFormat("      ,AnteriorSalarioFamiliar = {0}", AnteriorSalarioFamiliar)
         If IdMotivoBaja = 0 Then
            .AppendFormat("      ,IdMotivoBaja = null")
         Else
            .AppendFormat("      ,IdMotivoBaja = {0}", IdMotivoBaja)
         End If
         If IdLugarActividad = 0 Then
            .AppendFormat("      ,IdLugarActividad = null")
         Else
            .AppendFormat("      ,IdLugarActividad = {0}", IdLugarActividad)
         End If
         If String.IsNullOrEmpty(DatosFamiliares) Then
            .AppendFormat("      ,DatosFamiliares = null")
         Else
            .AppendFormat("      ,DatosFamiliares = '{0}'", DatosFamiliares)
         End If
         If IdBancoCtaBancaria = 0 Then
            .AppendFormat("      ,IdBancoCtaBancaria = null")
         Else
            .AppendFormat("      ,IdBancoCtaBancaria = {0}", IdBancoCtaBancaria)
         End If
         If IdCuentasBancariasClaseCtaBancaria = 0 Then
            .AppendFormat("      ,IdCuentasBancariasClaseCtaBancaria = null")
         Else
            .AppendFormat("      ,IdCuentasBancariasClaseCtaBancaria = {0}", IdCuentasBancariasClaseCtaBancaria)
         End If
         If String.IsNullOrEmpty(NumeroCuentaBancaria) Then
            .AppendFormat("      ,NumeroCuentaBancaria = null")
         Else
            .AppendFormat("      ,NumeroCuentaBancaria = '{0}'", NumeroCuentaBancaria)
         End If
         If Not String.IsNullOrEmpty(CBU) Then
            .AppendFormat("      ,CBU = '{0}'", CBU)
         Else
            .AppendFormat("      ,CBU = NULL")
         End If
         .Append(" WHERE ")
         .AppendFormat("      idLegajo = {0}", idLegajo)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosPersonal")
   End Sub

   Public Sub SueldosPersonal_D(ByVal idLegajo As Integer)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM SueldosPersonal WHERE ")
         .AppendFormat("       idLegajo = {0}", idLegajo)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosPersonal")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT ")
         .Append("           SP.idLegajo")
         .Append("           ,SP.NombrePersonal")
         .Append("           ,SP.Domicilio")
         .Append("           ,SP.IdLocalidad")
         .Append("           ,SP.TipoDocPersonal")
         .Append("           ,SP.NroDocPersonal")
         .Append("           ,SP.idNacionalidad")
         .Append("           ,N.NombreNacionalidad")
         .Append("           ,SP.Sexo")
         .Append("           ,SP.IdEstadoCivil")
         .Append("           ,SP.Cuil")
         .Append("           ,SP.LegajoMinTrabajo")
         .Append("           ,SP.idObraSocial")
         .Append("           ,SP.CodObraSocial")
         .Append("           ,SP.FechaNacimiento")
         .Append("           ,SP.FechaIngreso")
         .Append("           ,SP.FechaBaja")
         .Append("           ,SP.idCategoria")
         .Append("           ,SP.CentroCosto")
         .Append("           ,SP.SueldoBasico")
         .Append("           ,SP.MejorSueldo")
         .Append("           ,SP.AcumuladoAnual")
         .Append("           ,SP.AcumuladoSalarioFamiliar")
         .Append("           ,SP.SueldoActual")
         .Append("           ,SP.SalarioFamiliarActual")
         .Append("           ,SP.AFJP")
         .Append("           ,SP.AnteriorAcumuladoAnual")
         .Append("           ,SP.AnteriorMejorSueldo")
         .Append("           ,SP.AnteriorSalarioFamiliar")
         .Append("           ,SP.IdMotivoBaja")
         .Append("           ,SP.IdLugarActividad")
         .Append("           ,SP.DatosFamiliares")
         .Append("           ,SP.IdBancoCtaBancaria")
         .Append("           ,SP.IdCuentasBancariasClaseCtaBancaria")
         .Append("           ,SP.NumeroCuentaBancaria")
         .Append("           ,SP.CBU")
         .Append("  FROM SueldosPersonal SP")
         .Append("   INNER JOIN Nacionalidades N on SP.IdNacionalidad = N.IdNacionalidad")
      End With
   End Sub

   Public Function GetPersonalActivo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append(" WHERE SP.FechaBaja is null")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPersonalActivoPorConcepto(ByVal idTipoConcepto As Integer, ByVal idConcepto As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" LEFT JOIN SueldosPersonalCodigos SPC ON SP.idLegajo = SPC.idLegajo ")
         .Append(" WHERE SP.FechaBaja is null")
         .AppendFormat(" AND SPC.idTipoConcepto = {0}", idTipoConcepto)
         .AppendFormat(" AND SPC.idConcepto = {0}", idConcepto)
         .Append(" ORDER BY SP.NombrePersonal")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPersonalActivoPorLugarActividad(ByVal idLugarActividad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append(" WHERE SP.FechaBaja is null ")
         .AppendFormat(" AND SP.IdLugarActividad = {0}", idLugarActividad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function SueldosPersonal_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery

         .AppendLine("  SELECT [idLegajo]")
         .AppendLine("       ,[NombrePersonal]")
         .AppendLine("       ,[Domicilio]")
         .AppendLine("       ,c.IdLocalidad")
         .AppendLine("        , L.NombreLocalidad ")

         .AppendLine("       ,[TipoDocPersonal]")
         .AppendLine("       ,[NroDocPersonal]")
         .AppendLine("       ,C.idNacionalidad")
         .AppendLine("       ,N.NombreNacionalidad")
         .AppendLine("       ,[Sexo]")
         .AppendLine("       ,c.idEstadoCivil")
         .AppendLine("        , e.NombreEstadoCivil ")
         .AppendLine("       ,[Cuil]")
         .AppendLine("       ,[LegajoMinTrabajo]")
         .AppendLine("        , A.NombreCategoria")
         .AppendLine("       ,c.idObraSocial")
         .AppendLine("       ,[CodObraSocial]")

         .AppendLine("        , O.NombreObraSocial")
         .AppendLine("       ,[FechaNacimiento]")
         .AppendLine("       ,[FechaIngreso]")
         .AppendLine("       ,[FechaBaja]")
         .AppendLine("       ,c.idCategoria")
         .AppendLine("       ,[CentroCosto]")
         .AppendLine("       ,[SueldoBasico]")
         .AppendLine("       ,[MejorSueldo]")
         .AppendLine("       ,[AcumuladoAnual]")
         .AppendLine("       ,[AcumuladoSalarioFamiliar]")
         .AppendLine("       ,[SueldoActual]")
         .AppendLine("       ,[SalarioFamiliarActual]")
         .AppendLine("       ,[AFJP]")
         .AppendLine("       ,[AnteriorAcumuladoAnual]")
         .AppendLine("       ,[AnteriorMejorSueldo]")
         .AppendLine("       ,[AnteriorSalarioFamiliar]")


         .AppendLine("       ")
         .AppendLine("    FROM SueldosPersonal C")
         .AppendLine("    LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine("    LEFT JOIN SueldosEstadoCivil E ON E.idEstadoCivil = C.IdEstadoCivil ")
         .AppendLine("    LEFT JOIN SueldosCategorias A ON A.idCategoria = C.idCategoria")
         .AppendLine("    LEFT JOIN SueldosObraSocial O ON O.idObraSocial = C.idObraSocial")
         .AppendLine("    LEFT JOIN Nacionalidades N ON N.IdNacionalidad = C.IdNacionalidad")
         .AppendLine("    ")


      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("select ")
         .Append(" max(idLegajo) as maximo ")
         .Append(" from  SueldosPersonal")
      End With

      'Para el Importador de Productos (Airoldi y Generico)
      'Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function SueldosPersonal_G1(ByVal idTipoConcepto As Integer, ByVal idConcepto As Integer) As DataTable

      Return Nothing
   End Function

   Public Sub SueldosPersonal_U_AcumAnual(ByVal idLegajo As Integer _
      , ByVal AcumuladoAnual As System.Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosPersonal  ")
         .Append("SET  ")
         .AppendFormat(" AcumuladoAnual= {0}", AcumuladoAnual.ToString())
         .Append(" WHERE ")
         .Append("idlEGAJO = " & idLegajo)

      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub SueldosPersonal_U_AcumuladoSalarioFAmiliar(ByVal idLegajo As Integer, _
                                                         ByVal AcumuladoSalarioFamiliar As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosPersonal  ")
         .Append("SET  ")
         .AppendFormat(" AcumuladoSalarioFAmiliar= {0}", AcumuladoSalarioFamiliar.ToString())
         .Append(" WHERE ")
         .Append("idLegajo = " & idLegajo)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

End Class
