Public Class SueldosPersonalFamiliares

   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosPersonalFamiliares_I(ByVal idLegajo As Integer, _
                                    ByVal CuilFamiliar As Long, _
                                    ByVal NombreFamiliar As String, _
                                    ByVal FechaNacimientoFamiliar As DateTime, _
                                    ByVal IdTipoVinculoFamiliar As String, _
                                    ByVal SexoFamiliar As String)

      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO SueldosPersonalFamiliares (")
         .Append("           idLegajo")
         .Append("           ,CuilFamiliar")
         .Append("           ,NombreFamiliar")
         .Append("           ,FechaNacimientoFamiliar")
         .Append("           ,IdTipoVinculoFamiliar")
         .Append("           ,SexoFamiliar")

         .Append(")     VALUES(")
         .AppendFormat("           {0}", idLegajo)
         .AppendFormat("           ,'{0}'", CuilFamiliar)
         .AppendFormat("           ,'{0}'", NombreFamiliar)
         .AppendFormat("           ,'{0}'", FechaNacimientoFamiliar.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("           ,'{0}'", IdTipoVinculoFamiliar)
         .AppendFormat("           ,'{0}'", SexoFamiliar)
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosPersonalFamiliares")
   End Sub

   Public Sub SueldosPersonalFamiliares_D(ByVal idLegajo As Integer, ByVal CuilFamiliar As Long)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM SueldosPersonalFamiliares WHERE ")
         .AppendFormat("       idLegajo = {0}", idLegajo)
         .AppendFormat("      AND CuilFamiliar = {0}", CuilFamiliar)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosPersonalFamiliar")
   End Sub

End Class
