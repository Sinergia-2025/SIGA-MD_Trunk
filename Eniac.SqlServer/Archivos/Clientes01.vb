Partial Class Clientes

   Public Sub Clientes_U_Estrellas(idCliente As Long,
                                   valorizacionFacturacionMensual As Decimal,
                                   valorizacionCoeficienteFacturacion As Decimal,
                                   valorizacionFacturacion As Decimal,
                                   valorizacionImporteAdeudado As Decimal,
                                   valorizacionCoeficienteDeuda As Decimal,
                                   valorizacionDeuda As Decimal,
                                   valorizacionProyecto As Decimal,
                                   valorizacionCliente As Decimal,
                                   valorizacionEstrellas As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}s", ModoClienteProspecto.ToString())
         .AppendFormatLine("   SET ValorizacionFacturacionMensual     = {0}", valorizacionFacturacionMensual)
         .AppendFormatLine("     , ValorizacionCoeficienteFacturacion = {0}", valorizacionCoeficienteFacturacion)
         .AppendFormatLine("     , ValorizacionFacturacion            = {0}", valorizacionFacturacion)
         .AppendFormatLine("     , ValorizacionImporteAdeudado        = {0}", valorizacionImporteAdeudado)
         .AppendFormatLine("     , ValorizacionCoeficienteDeuda       = {0}", valorizacionCoeficienteDeuda)
         .AppendFormatLine("     , ValorizacionDeuda                  = {0}", valorizacionDeuda)
         .AppendFormatLine("     , ValorizacionProyecto               = {0}", valorizacionProyecto)
         .AppendFormatLine("     , Valorizacion{1}                    = {0}", valorizacionCliente, ModoClienteProspecto.ToString())
         .AppendFormatLine("     , ValorizacionEstrellas              = {0}", valorizacionEstrellas)
         .AppendFormatLine(" WHERE Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString())
      End With
      Me.Execute(myQuery.ToString())
   End Sub

End Class