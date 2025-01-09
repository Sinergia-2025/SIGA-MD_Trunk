Partial Class Sucursales

   Public Function GetVinculaciones(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("  	SUO.IdSucursal, ")
         .AppendFormatLine("  	SSO.Nombre SucursalOrigen,")
         .AppendFormatLine("  	SUO.IdDeposito, ")
         .AppendFormatLine("  	SDO.NombreDeposito DepositoOrigen, ")
         .AppendFormatLine("  	SUO.IdUbicacion, ")
         .AppendFormatLine("  	SUO.NombreUbicacion UbicacionOrigen,")
         .AppendFormatLine("  	SUO.SucursalAsociada IdSucursalAsociada, ")
         .AppendFormatLine("  	SSA.Nombre SucursalAsociada,")
         .AppendFormatLine("  	SUO.DepositoAsociado IdDepositoAsociado, ")
         .AppendFormatLine("  	SDA.NombreDeposito DepositoAsociado,")
         .AppendFormatLine("  	SUO.UbicacionAsociada IdUbicacionAsociada, ")
         .AppendFormatLine("  	SUA.NombreUbicacion UbicacionAsociada")
         .AppendFormatLine("  FROM SucursalesUbicaciones SUO")
         .AppendFormatLine("  	INNER JOIN SucursalesDepositos SDO")
         .AppendFormatLine("  		ON SDO.IdSucursal = SUO.IdSucursal")
         .AppendFormatLine("  	   AND SDO.IdDeposito = SUO.IdDeposito")
         .AppendFormatLine("  	INNER JOIN Sucursales SSO")
         .AppendFormatLine("  		ON SSO.IdSucursal = SUO.IdSucursal")
         .AppendFormatLine("  	INNER JOIN Sucursales SSA")
         .AppendFormatLine("  		ON SUO.SucursalAsociada = SSA.IdSucursal")
         .AppendFormatLine("  	INNER JOIN SucursalesDepositos SDA")
         .AppendFormatLine("  		ON SUO.SucursalAsociada = SDA.IdSucursal")
         .AppendFormatLine("  	   AND SUO.DepositoAsociado = SDA.IdDeposito")
         .AppendFormatLine("  	INNER JOIN SucursalesUbicaciones SUA")
         .AppendFormatLine("  		ON SUO.SucursalAsociada = SUA.IdSucursal")
         .AppendFormatLine("  	   AND SUO.DepositoAsociado = SUA.IdDeposito")
         .AppendFormatLine("  	   AND SUO.UbicacionAsociada = SUA.IdUbicacion")
         .AppendFormatLine(" WHERE SUO.IdSucursal = {0}", idSucursal)
      End With
      Return GetDataTable(stb)
   End Function

End Class
