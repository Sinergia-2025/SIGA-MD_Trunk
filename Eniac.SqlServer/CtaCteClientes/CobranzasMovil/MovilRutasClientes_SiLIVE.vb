Partial Class MovilRutasClientes
   Public Sub NormalizaClienteSegunRuta()
      NormalizaVendedorDeCliente()
      NormalizaTransportistaDeCliente()
   End Sub

   Private Sub NormalizaVendedorDeCliente()
      Dim qry As StringBuilder = New StringBuilder()

      With qry
         .AppendLine("UPDATE Clientes")
         .AppendLine("   SET IdVendedor = R.IdVendedor")
         .AppendLine("  FROM MovilRutasClientes AS RC")
         .AppendLine(" INNER JOIN MovilRutas AS R ON R.IdRuta = RC.IdRuta")
         .AppendLine(" INNER JOIN Clientes AS C ON C.IdCliente = RC.IdCliente ")
         .AppendLine(" WHERE NOT EXISTS (SELECT *")
         .AppendLine("                     FROM MovilRutasClientes AS ERC ")
         .AppendLine("                    INNER JOIN MovilRutas AS ER ON ER.IdRuta = ERC.IdRuta ")
         .AppendLine("                    INNER JOIN Clientes AS EC ON EC.IdCliente = ERC.IdCliente ")
         .AppendLine("                    WHERE ER.IdVendedor = EC.IdVendedor")
         .AppendLine("                      AND RC.IdCliente = ERC.IdCliente) ")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "RutasClientes")
   End Sub

   Private Sub NormalizaTransportistaDeCliente()
      Dim qry As StringBuilder = New StringBuilder()
      With qry
         .AppendLine("UPDATE Clientes")
         .AppendLine("   SET IdTransportista = R.IdTransportista")
         .AppendLine("  FROM MovilRutasClientes AS RC")
         .AppendLine(" INNER JOIN MovilRutas AS R ON R.IdRuta = RC.IdRuta")
         .AppendLine(" INNER JOIN Clientes AS C ON C.IdCliente = RC.IdCliente ")
         .AppendLine(" WHERE NOT EXISTS (SELECT *")
         .AppendLine("                     FROM MovilRutasClientes AS ERC ")
         .AppendLine("                    INNER JOIN MovilRutas AS ER ON ER.IdRuta = ERC.IdRuta ")
         .AppendLine("                    INNER JOIN Clientes AS EC ON EC.IdCliente = ERC.IdCliente ")
         .AppendLine("                    WHERE ER.IdTransportista = EC.IdTransportista")
         .AppendLine("                      AND RC.IdCliente = ERC.IdCliente) ")
      End With
      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "RutasClientes")
   End Sub

End Class