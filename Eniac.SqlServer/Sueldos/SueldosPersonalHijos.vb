Public Class SueldosPersonalHijos

   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosPersonalHijos_I(ByVal idLegajo As Integer, _
                                    ByVal CuilHijo As Long, _
                                    ByVal NombreHijo As String, _
                                    ByVal FechaNacimientoHijo As DateTime)

      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO SueldosPersonalHijos (")
         .Append("           idLegajo")
         .Append("           ,CuilHijo")
         .Append("           ,NombreHijo")
         .Append("           ,FechaNacimientoHijo")

         .Append(")     VALUES(")
         .AppendFormat("           {0}", idLegajo)
         .AppendFormat("           ,'{0}'", CuilHijo)
         .AppendFormat("           ,'{0}'", NombreHijo)
         .AppendFormat("           ,'{0}'", FechaNacimientoHijo.ToString("yyyyMMdd HH:mm:ss"))
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosPersonalHijos")
   End Sub

   Public Sub SueldosPersonalHijos_D(ByVal idLegajo As Integer, ByVal CuilHijo As Long)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM SueldosPersonalHijos WHERE ")
         .AppendFormat("       idLegajo = {0}", idLegajo)
         .AppendFormat("      AND CuilHijo = {0}", CuilHijo)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosPersonalHijo")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      'With stb
      '   .Append("SELECT ")
      '   .Append("           SP.idLegajo")
      '   .Append("           ,SP.NombrePersonal")
      '   .Append("           ,SP.Domicilio")
      '   .Append("           ,SP.IdLocalidad")
      '   .Append("           ,SP.TipoDocPersonal")
      '   .Append("           ,SP.NroDocPersonal")
      '   .Append("           ,SP.idNacionalidad")
      '   .Append("           ,SP.Sexo")
      '   .Append("           ,SP.IdEstadoCivil")
      '   .Append("           ,SP.Cuil")
      '   .Append("           ,SP.LegajoMinTrabajo")
      '   .Append("           ,SP.idObraSocial")
      '   .Append("           ,SP.CodObraSocial")
      '   .Append("           ,SP.FechaNacimiento")
      '   .Append("           ,SP.FechaIngreso")
      '   .Append("           ,SP.FechaBaja")
      '   .Append("           ,SP.idCategoria")
      '   .Append("           ,SP.CentroCosto")
      '   .Append("           ,SP.SueldoBasico")
      '   .Append("           ,SP.MejorSueldo")
      '   .Append("           ,SP.AcumuladoAnual")
      '   .Append("           ,SP.AcumuladoSalarioFamiliar")
      '   .Append("           ,SP.SueldoActual")
      '   .Append("           ,SP.SalarioFamiliarActual")
      '   .Append("           ,SP.AFJP")
      '   .Append("           ,SP.AnteriorAcumuladoAnual")
      '   .Append("           ,SP.AnteriorMejorSueldo")
      '   .Append("           ,SP.AnteriorSalarioFamiliar")
      '   .Append("           ,SP.IdMotivoBaja")
      '   .Append("           ,SP.IdLugarActividad")
      '   .Append("           ,SP.DatosFamiliares")
      '   .Append("           ,SP.IdBancoCtaBancaria")
      '   .Append("           ,SP.IdCuentasBancariasClaseCtaBancaria")
      '   .Append("           ,SP.NumeroCuentaBancaria")
      '   .Append("           ,SP.CBU")
      '   .Append("  FROM SueldosPersonal SP")
      'End With
   End Sub



End Class
