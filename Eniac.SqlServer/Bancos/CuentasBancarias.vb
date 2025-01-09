Public Class CuentasBancarias
   Inherits Comunes

   Private _tieneModuloContabilidad As Boolean
   Public Sub New(da As Datos.DataAccess, tieneModuloContabilidad As Boolean)
      MyBase.New(da)
      _tieneModuloContabilidad = tieneModuloContabilidad
   End Sub

   Public Sub CuentasBancarias_I(idCuentaBancaria As Integer,
                                 codigoBancario As String,
                                 idCuentaBancariaClase As Integer,
                                 tieneChequera As Boolean,
                                 idMoneda As Integer,
                                 idBanco As Integer,
                                 idBancoSucursal As Integer,
                                 idLocalidad As Integer,
                                 nombreCuenta As String,
                                 activo As Boolean,
                                 idPlanCuenta As Integer,
                                 idCuentaContable As Integer,
                                 cbu As String,
                                 cbuAlias As String,
                                 paraInformarEnFEC As Boolean,
                                 idEmpresa As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO CuentasBancarias (")
         .AppendLine("            IdCuentaBancaria")
         .AppendLine("          , CodigoBancario")
         .AppendLine("          , IdCuentaBancariaClase")
         .AppendLine("          , TieneChequera")
         .AppendLine("          , IdMoneda")
         .AppendLine("          , IdBanco")
         .AppendLine("          , IdBancoSucursal")
         .AppendLine("          , IdLocalidad")
         .AppendLine("          , NombreCuenta")
         .AppendLine("          , Activo")
         .AppendLine("          , IdPlanCuenta")
         .AppendLine("          , IdCuentaContable")
         .AppendLine("          , Cbu")
         .AppendLine("          , CbuAlias")
         .AppendLine("          , ParaInformarEnFEC")
         .AppendLine("          , IdEmpresa")
         .AppendLine("  ) VALUES ( ")
         .AppendFormatLine("            {0} ", idCuentaBancaria)
         .AppendFormatLine("          ,'{0}'", codigoBancario)
         .AppendFormatLine("          , {0} ", idCuentaBancariaClase)
         .AppendFormatLine("          ,'{0}'", tieneChequera.ToString())
         .AppendFormatLine("          , {0} ", idMoneda)
         .AppendFormatLine("          , {0} ", idBanco)
         .AppendFormatLine("          , {0} ", idBancoSucursal)
         .AppendFormatLine("          , {0} ", idLocalidad)
         .AppendFormatLine("          ,'{0}'", nombreCuenta)
         .AppendFormatLine("          ,'{0}'", activo.ToString())

         .AppendFormatLine("          , {0} ", GetStringFromNumber(idPlanCuenta))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(idCuentaContable))

         .AppendFormatLine("          ,'{0}'", cbu)
         .AppendFormatLine("          ,'{0}'", cbuAlias)
         .AppendFormatLine("          , {0} ", GetStringFromBoolean(paraInformarEnFEC))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(idEmpresa))
         .AppendFormatLine(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasBancarias")

   End Sub

   Public Sub CuentasBancarias_U(idCuentaBancaria As Integer,
                                 codigoBancario As String,
                                 idCuentaBancariaClase As Integer,
                                 tieneChequera As Boolean,
                                 idMoneda As Integer,
                                 idBanco As Integer,
                                 idBancoSucursal As Integer,
                                 idLocalidad As Integer,
                                 nombreCuenta As String,
                                 activo As Boolean,
                                 idPLanCuenta As Integer,
                                 idCuentaContable As Integer,
                                 cbu As String,
                                 cbuAlias As String,
                                 paraInformarEnFEC As Boolean,
                                 idEmpresa As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasBancarias SET")
         .AppendFormatLine("       CodigoBancario = '{0}'", codigoBancario)
         .AppendFormatLine("      ,IdCuentaBancariaClase = {0}", idCuentaBancariaClase)
         .AppendFormatLine("      ,TieneChequera = '{0}'", tieneChequera.ToString())
         .AppendFormatLine("      ,IdMoneda = {0}", idMoneda)
         .AppendFormatLine("      ,IdBanco = {0}", idBanco)
         .AppendFormatLine("      ,IdBancoSucursal = {0}", idBancoSucursal)
         .AppendFormatLine("      ,IdLocalidad = {0}", idLocalidad)
         .AppendFormatLine("      ,NombreCuenta = '{0}'", nombreCuenta)
         .AppendFormatLine("      ,Activo = '{0}'", activo.ToString())

         .AppendFormatLine("      ,IdPlanCuenta = {0}", GetStringFromNumber(idPLanCuenta))
         .AppendFormatLine("      ,IdCuentaContable = {0}", GetStringFromNumber(idCuentaContable))

         .AppendFormatLine("      ,Cbu = '{0}'", cbu)
         .AppendFormatLine("      ,CbuAlias= '{0}'", cbuAlias)

         .AppendFormatLine("      ,ParaInformarEnFEC = {0}", GetStringFromBoolean(paraInformarEnFEC))

         .AppendFormatLine("      ,IdEmpresa = {0}", GetStringFromNumber(idEmpresa))

         .AppendFormatLine(" WHERE IdCuentaBancaria = {0}", idCuentaBancaria)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasBancarias")

   End Sub

   Public Sub CuentasBancarias_D(idCuentaBancaria As Integer)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM CuentasBancarias")
         .AppendFormatLine(" WHERE IdCuentaBancaria = {0}", idCuentaBancaria)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasBancarias")

   End Sub

   Public Function CuentasBancarias_GA_Activos() As DataTable
      Return CuentasBancarias_G(paraInformarEnFEC:=Nothing, activos:=True, idCuenta:=Nothing, nombreCuenta:=String.Empty, nombreCuentaExacto:=True, idMoneda:=0, ignorarEspeciales:=False)
   End Function
   Public Function CuentasBancarias_GA_PorNombre(nombreCuenta As String, nombreCuentaExacto As Boolean, idMoneda As Integer, ignorarEspeciales As Boolean) As DataTable
      Return CuentasBancarias_G(paraInformarEnFEC:=Nothing, activos:=True, idCuenta:=Nothing, nombreCuenta:=nombreCuenta, nombreCuentaExacto:=nombreCuentaExacto, idMoneda, ignorarEspeciales)
   End Function
   Public Function CuentasBancarias_GA_PorNombreCBU(nombreCuenta As String, nombreCuentaExacto As Boolean, idMoneda As Integer) As DataTable
      Return CuentasBancarias_GconCBU()
   End Function
   Public Function CuentasBancarias_GA_PorCodigo(idCuenta As Integer?) As DataTable
      Return CuentasBancarias_GA_PorCodigo(idCuenta, activos:=Nothing, ignorarEspeciales:=False)
   End Function
   Public Function CuentasBancarias_GA_PorCodigo(idCuenta As Integer?, activos As Boolean?, ignorarEspeciales As Boolean) As DataTable
      Return CuentasBancarias_G(paraInformarEnFEC:=Nothing, activos, idCuenta:=idCuenta, nombreCuenta:=String.Empty, nombreCuentaExacto:=True, idMoneda:=0, ignorarEspeciales)
   End Function

   Public Function CuentasBancarias_GA() As DataTable
      Return CuentasBancarias_G(paraInformarEnFEC:=Nothing, activos:=Nothing, idCuenta:=Nothing, nombreCuenta:=String.Empty, nombreCuentaExacto:=True, idMoneda:=0, ignorarEspeciales:=False)
   End Function
   Public Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT IdCuentaBancaria")
         .AppendLine("     , Cb.NombreCuenta")
         .AppendLine("     , CodigoBancario")
         .AppendLine("     , Ccb.IdCuentaBancariaClase")
         .AppendLine("     , Ccb.NombreCuentaBancariaClase")
         .AppendLine("     , M.NombreMoneda")
         .AppendLine("     , TieneChequera")
         .AppendLine("     , Cb.IdBanco")
         .AppendLine("     , B.NombreBanco")
         .AppendLine("     , Cb.IdBancoSucursal")
         .AppendLine("     , L.IdLocalidad")
         .AppendLine("     , L.NombreLocalidad")
         .AppendLine("     , Saldo")
         .AppendLine("     , SaldoConfirmado")
         .AppendLine("     , Cb.IdMoneda")
         .AppendLine("     , Cb.Activo")
         .AppendLine("     , Cb.IdPlanCuenta")
         .AppendLine("     , CB.IdCuentaContable")
         If _tieneModuloContabilidad Then
            .AppendLine("     , (SELECT CP.NombrePlanCuenta FROM ContabilidadPlanes CP WHERE Cb.idPlanCuenta=CP.idPlanCuenta) AS NombrePlanCuenta")
            .AppendLine("     , (SELECT CC.NombreCuenta FROM ContabilidadCuentas CC WHERE CC.idCuenta=Cb.idCuentaContable) AS NombreCuentaContable")
         Else
            .AppendLine("     , NULL AS NombrePlanCuenta")
            .AppendLine("     , NULL AS NombreCuentaContable")
         End If
         .AppendLine("     , Cbu ")
         .AppendLine("     , CbuAlias ")
         .AppendLine("     , ParaInformarEnFEC ")
         .AppendLine("     , Cb.IdEmpresa")
         .AppendLine("     , E.NombreEmpresa")
         'Agregar inner para nombre Empresa
         .AppendLine("  FROM CuentasBancarias Cb ")
         .AppendLine(" INNER JOIN CuentasBancariasClase Ccb On Cb.IdCuentaBancariaClase = Ccb.IdCuentaBancariaClase ")
         .AppendLine(" INNER JOIN Monedas M On Cb.IdMoneda = M.IdMoneda ")
         .AppendLine(" INNER JOIN Bancos B On Cb.IdBanco = B.IdBanco ")
         .AppendLine(" INNER JOIN Localidades L On Cb.IdLocalidad = L.IdLocalidad ")
         .AppendLine(" INNER JOIN Provincias P On L.IdProvincia = P.IdProvincia ")
         .AppendLine(" LEFT JOIN Empresas E On Cb.IdEmpresa = E.IdEmpresa")

      End With
   End Sub

   Public Function CuentasBancarias_G(paraInformarEnFEC As Boolean?,
                                      activos As Boolean?,
                                      idCuenta As Integer?,
                                      nombreCuenta As String, nombreCuentaExacto As Boolean,
                                      idMoneda As Integer,
                                      ignorarEspeciales As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         .AppendFormatLine("   AND (Cb.IdEmpresa = {0} OR Cb.IdEmpresa IS NULL)", actual.Sucursal.Empresa.IdEmpresa)
         If paraInformarEnFEC.HasValue Then
            .AppendFormatLine("   AND Cb.ParaInformarEnFEC = {0}", GetStringFromBoolean(paraInformarEnFEC.Value))
         End If
         If activos.HasValue Then
            .AppendFormatLine("   AND Cb.Activo = {0}", GetStringFromBoolean(activos.Value))
         End If
         If Not String.IsNullOrWhiteSpace(nombreCuenta) Then
            If nombreCuentaExacto Then
               .AppendFormatLine("   AND cb.NombreCuenta = '{0}'", nombreCuenta)
            Else
               .AppendFormatLine("   AND cb.NombreCuenta LIKE '%{0}%'", nombreCuenta)
            End If
         End If
         If idCuenta.HasValue Then
            .AppendFormatLine("   AND cb.IdCuentaBancaria = {0}", idCuenta.Value)
         End If
         If idMoneda > 0 Then
            .AppendFormatLine("   AND cb.IdMoneda = {0}", idMoneda)
         End If
         If ignorarEspeciales Then
            .AppendFormatLine("   AND cb.IdCuentaBancaria <> 999")
         End If
         .AppendLine("ORDER BY Cb.NombreCuenta")
      End With

      Return GetDataTable(myQuery)
   End Function
   Public Function CuentasBancarias_GconCBU() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         .AppendFormatLine("    AND (Cb.CBU <> '' AND Cb.IdEmpresa IS NOT NULL)", actual.Sucursal.Empresa.IdEmpresa)
         .AppendLine("ORDER BY Cb.NombreCuenta")
      End With

      Return GetDataTable(myQuery)
   End Function
   Public Function CuentasBancarias_GA_ParaInformarEnFEC() As DataTable
      Return CuentasBancarias_G(paraInformarEnFEC:=True, activos:=Nothing, idCuenta:=Nothing, nombreCuenta:=String.Empty, nombreCuentaExacto:=True, idMoneda:=0, ignorarEspeciales:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "Cb.",
                    New Dictionary(Of String, String) From {{"NombreCuentaBancoClase", "CCB.NombreCuentaBancoClase"},
                                                            {"NombreMoneda", "M.NombreMoneda"},
                                                            {"NombreBanco", "B.NombreBanco"},
                                                            {"NombreLocalidad", "L.NombreLocalidad"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdCuentaBancaria", "CuentasBancarias", "IdCuentaBancaria <> 999"))
   End Function

End Class