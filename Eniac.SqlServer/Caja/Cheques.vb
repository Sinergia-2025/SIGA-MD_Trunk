Imports Eniac.Entidades

Public Class Cheques
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Cheques_I(idSucursal As Integer,
                        idCheque As Long,
                        idBanco As Integer,
                        idBancoSucursal As Integer,
                        idLocalidad As Integer,
                        numeroCheque As Integer,
                        fechaEmision As Date,
                        fechaCobro As Date,
                        titular As String,
                        importe As Double,
                        idCajaIngreso As Integer,
                        nroPlanillaIngreso As Integer,
                        nroMovimientoIngreso As Integer,
                        idCajaEgreso As Integer,
                        nroPlanillaEgreso As Integer,
                        nroMovimientoEgreso As Integer,
                        esPropio As Boolean,
                        idCuentaBancaria As Integer,
                        idEstadoCheque As Entidades.Cheque.Estados,
                        idCliente As Long,
                        idProveedor As Long,
                        cuit As String,
                        idProveedorPreasignado As Long,
                        idUsuarioActualizacion As String,
                        idTipoCheque As String,
                        nroOperacion As String,
                        idChequera As Integer?,
                        idSituacionCheque As Integer,
                        observacion As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Append("INSERT INTO Cheques")
         .Append("           (IdSucursal")
         .Append("           ,IdCheque")
         .Append("           ,NumeroCheque")
         .Append("           ,IdBanco")
         .Append("           ,IdBancoSucursal")
         .Append("           ,idLocalidad")
         .Append("           ,FechaEmision")
         .Append("           ,FechaCobro")
         .Append("           ,Titular")
         .Append("           ,Importe")
         .Append("           ,IdCajaIngreso")
         .Append("           ,NroPlanillaIngreso")
         .Append("           ,NroMovimientoIngreso")
         .Append("           ,IdCajaEgreso")
         .Append("           ,NroPlanillaEgreso")
         .Append("           ,NroMovimientoEgreso")
         .Append("           ,EsPropio")
         .Append("           ,IdCuentaBancaria")
         .Append("           ,IdEstadoCheque")
         .Append("           ,IdEstadoChequeAnt")
         .Append("           ,IdCliente")
         .Append("           ,IdProveedor")
         .Append("           ,Cuit")
         .Append("           ,IdProveedorPreasignado")
         .Append("           ,IdUsuarioActualizacion")
         .Append("           ,IdTipoCheque")
         .Append("           ,NroOperacion")
         .Append("           ,IdChequera")
         'PE-31207
         .Append("           ,IdSituacionCheque")
         .Append("           ,Observacion")
         .Append(" ) VALUES ( ")
         .AppendFormat("           {0}", idSucursal)
         .AppendFormat("           ,{0}", idCheque)
         .AppendFormat("           ,{0}", numeroCheque)
         .AppendFormat("           ,{0}", idBanco)
         .AppendFormat("           ,{0}", idBancoSucursal)
         .AppendFormat("           ,{0}", idLocalidad)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaEmision, True))
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaCobro, True))
         .AppendFormat("           ,'{0}'", titular)
         .AppendFormat("           ,{0}", importe.ToString())

         If nroPlanillaIngreso > 0 Then
            .AppendFormat("           ,{0}", idCajaIngreso)
            .AppendFormat("           ,{0}", nroPlanillaIngreso)
            .AppendFormat("           ,{0}", nroMovimientoIngreso)
         Else
            .AppendFormat("           ,NULL")
            .AppendFormat("           ,NULL")
            .AppendFormat("           ,NULL")
         End If

         If nroPlanillaEgreso > 0 Then
            .AppendFormat("           ,{0}", idCajaEgreso)
            .AppendFormat("           ,{0}", nroPlanillaEgreso)
            .AppendFormat("           ,{0}", nroMovimientoEgreso)
         Else
            .AppendFormat("           ,NULL")
            .AppendFormat("           ,NULL")
            .AppendFormat("           ,NULL")
         End If

         If esPropio Then
            .AppendFormat("           ,{0}", 1)
            .AppendFormat("           ,{0}", idCuentaBancaria)
         Else
            .AppendFormat("           ,{0}", 0)
            .AppendFormat("           ,NULL")
         End If
         .AppendFormat("           ,'{0}'", idEstadoCheque.ToString())
         '.AppendFormat("           ,NULL")
         .AppendFormat("           ,'{0}'", idEstadoCheque.ToString())

         If idCliente > 0 Then
            .AppendFormat("           ,{0}", idCliente)
         Else
            .AppendFormat("           ,NULL")
         End If

         If idProveedor > 0 Then
            .AppendFormat("           ,{0}", idProveedor)
         Else
            .AppendFormat("           ,NULL")
         End If

         If Long.Parse("0" & cuit) > 0 Then
            .AppendFormat("           ,'{0}'", cuit)
         Else
            .AppendFormat("           ,NULL")
         End If
         If idProveedorPreasignado > 0 Then
            .AppendFormat("           ,{0}", idProveedorPreasignado)
         Else
            .AppendFormat("           ,NULL")
         End If
         .AppendFormatLine("           ,'{0}'", idUsuarioActualizacion)

         '# Tipo de Cheque y Nro de Operación
         .AppendFormatLine("           ,'{0}'", idTipoCheque)
         If Not String.IsNullOrEmpty(nroOperacion) Then
            .AppendFormatLine("           ,'{0}'", nroOperacion.ToUpper())
         Else
            .AppendFormat("           ,NULL")
         End If
         If idChequera.HasValue Then
            .AppendFormatLine("           ,{0}", idChequera.Value)
         Else
            .AppendFormat("           ,NULL")
         End If

         .AppendFormatLine("        ,{0}", idSituacionCheque)
         .AppendFormatLine("        ,'{0}'", observacion)
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub Cheques_U(idSucursal As Integer,
                        idCheque As Long,
                        idBanco As Integer,
                        idBancoSucursal As Integer,
                        idLocalidad As Integer,
                        numeroCheque As Integer,
                        fechaEmision As Date,
                        fechaCobro As Date,
                        titular As String,
                        importe As Double,
                        idCajaIngreso As Integer,
                        nroPlanillaIngreso As Integer,
                        nroMovimientoIngreso As Integer,
                        idCajaEgreso As Integer,
                        nroPlanillaEgreso As Integer,
                        nroMovimientoEgreso As Integer,
                        idCliente As Long,
                        idProveedor As Long,
                        cuit As String,
                        idProveedorPreasignado As Long,
                        idUsuarioActualizacion As String,
                        idTipoCheque As String,
                        nroOperacion As String,
                        idChequera As Integer?,
                        idSituacionCheque As Integer,
                        observacion As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Cheques")
         .AppendLine("   SET FechaEmision = '" & Me.ObtenerFecha(fechaEmision, False) & "'")
         .AppendLine("      ,FechaCobro = '" & Me.ObtenerFecha(fechaCobro, False) & "'")
         .AppendLine("      ,Titular = '" & titular & "'")

         If Long.Parse("0" & cuit) > 0 Then
            .AppendLine("      ,CUIT = '" & cuit & "'")
         Else
            .AppendLine("      ,CUIT = NULL")
         End If

         .AppendLine(" ,Importe = " & importe.ToString())

         If nroPlanillaIngreso > 0 Then
            .AppendLine(" ,IdCajaIngreso = " & idCajaIngreso.ToString())
            .AppendLine(" ,NroPlanillaIngreso = " & nroPlanillaIngreso.ToString())
            .AppendLine(" ,NroMovimientoIngreso = " & nroMovimientoIngreso.ToString())

            If idCliente <> 0 Then
               .AppendFormat(" ,IdCliente = {0}", idCliente)
            Else
               .AppendLine(" ,IdCliente = NULL")
            End If

         Else
            .AppendLine(" ,IdCajaIngreso = NULL")
            .AppendLine(" ,NroPlanillaIngreso = NULL")
            .AppendLine(" ,NroMovimientoIngreso = NULL")
            .AppendLine(" ,IdCliente = NULL")
         End If

         If nroPlanillaEgreso > 0 Then
            .AppendFormat(" ,IdCajaEgreso = {0}", idCajaEgreso)
            .AppendLine(" ,NroPlanillaEgreso = " & nroPlanillaEgreso.ToString())
            .AppendLine(" ,NroMovimientoEgreso = " & nroMovimientoEgreso.ToString())

            If idProveedor > 0 Then
               .AppendFormat(" ,IdProveedor = {0}", idProveedor)
            Else
               .AppendLine(" ,IdProveedor = NULL")
            End If

         Else
            .AppendLine(" ,IdCajaEgreso = NULL")
            .AppendLine(" ,NroPlanillaEgreso = NULL")
            .AppendLine(" ,NroMovimientoEgreso = NULL")
            .AppendLine(" ,IdProveedor = NULL")
         End If

         If idProveedorPreasignado > 0 Then
            .AppendFormat(" ,IdProveedorPreasignado = {0}", idProveedorPreasignado)
         Else
            .AppendFormat(" ,IdProveedorPreasignado = NULL")
         End If

         .AppendFormat(" ,IdUsuarioActualizacion = '{0}'", idUsuarioActualizacion)

         .AppendFormat(" ,idBancoSucursal = {0}", idBancoSucursal)
         .AppendFormat(" ,idBanco = {0}", idBanco)
         .AppendFormat(" ,IdLocalidad = {0}", idLocalidad)


         '# Tipo Cheque y Nro Operacion
         .AppendFormatLine(" ,IdTipoCheque = '{0}'", idTipoCheque)
         If Not String.IsNullOrEmpty(nroOperacion) Then
            .AppendFormatLine(" ,NroOperacion = '{0}'", nroOperacion.ToUpper())
         Else
            .AppendLine(" ,NroOperacion = NULL")
         End If

         If idChequera.HasValue Then
            .AppendFormatLine(" ,IdChequera = {0}", idChequera.Value)
         Else
            .AppendLine(" ,IdChequera = NULL")
         End If

         'PE-31207
         If idSituacionCheque <> 0 Then
            .AppendFormatLine(" ,IdSituacionCheque = {0}", idSituacionCheque)
         Else
            'En caso de venir en 0 asumo que no lo debe cambiar porque puede venir de un comportamiento anterior que no cambiaba este valor.
         End If
         .AppendFormat(" ,Observacion = '{0}'", observacion)

         .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Cheques_D(idCheque As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM Cheques ")
         .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function Cheques_GA(idSucursal As Integer, esPropio As Boolean) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      Me.SelectFiltrado(myQuery)

      With myQuery
         .AppendLine("  WHERE C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("    AND C.EsPropio = '" & esPropio.ToString() & "'")
         .AppendLine("  ORDER BY C.NumeroCheque")
         .AppendLine("          ,C.IdBanco")
         .AppendLine("          ,C.IdBancoSucursal")
         .AppendLine("          ,C.IdLocalidad")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   '# Get1 por PK nueva (IdCheque)
   Public Function Get1(idCheque As Long) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectFiltrado(query)
         .AppendFormatLine("  WHERE  C.IdCheque = {0}", idCheque)
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   '# Get1 por PK anterior (Sucursal, Numero, Banco, BancoSucursal, Localidad)
   Public Function Get1PorNumeroCheque(idSucursal As Integer, numeroCheque As Integer, idBanco As Integer,
                                        idBancoSucursal As Integer, idLocalidad As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Me.SelectFiltrado(stb)
      With stb
         .AppendFormat("  WHERE  C.IdSucursal = {0}", idSucursal)
         .AppendFormat("	  AND C.NumeroCheque = {0}", numeroCheque)
         .AppendFormat("	  AND C.IdBanco = {0}", idBanco)
         .AppendFormat("	  AND C.IdBancoSucursal = {0}", idBancoSucursal)
         .AppendFormat("	  AND C.IdLocalidad = {0}", idLocalidad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(campo As String, valor As String, esPropio As Boolean) As DataTable
      Return Buscar(campo, valor, Sub(stb) SelectFiltrado(stb), "C.",
                    mapColumnas:=New Dictionary(Of String, String) From {
                        {"NombreBanco", "B.NombreBanco"},
                        {"NombreCliente", "CL.NombreCliente"},
                        {"NombreLocalidad", "L.NombreLocalidad"},
                        {"NombreCuenta", "CB.NombreCuenta"},
                        {"NombreProveedor", "P.NombreProveedor"},
                        {"NombreTipoCheque", "TC.NombreTipoCheque"},
                        {"NombreSituacionCheque", "SC.NombreSituacionCheque"}},
                    mapearColumnaCustom:=Nothing,
                    agregarCondicionAdicional:=
                    Sub(stb)
                       stb.AppendFormatLine("   AND C.idSucursal = {0}", actual.Sucursal.Id)
                       stb.AppendFormatLine("   AND C.EsPropio   = {0}", GetStringFromBoolean(esPropio))
                    End Sub)
   End Function

   Public Sub Cheques_UDesasociarNroMovimiento(idSucursal As Integer,
                                               tipoMovimiento As String,
                                               idBanco As Integer,
                                               IdBancoSucursal As Integer,
                                               IdLocalidad As Integer,
                                               numeroCheque As Integer,
                                               idUsuarioActualizacion As String,
                                               IdCheque As Long)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Cheques SET ")
         If tipoMovimiento = "I" Then
            .AppendLine("       IdCajaIngreso = NULL, ")
            .AppendLine("       NroPlanillaIngreso = NULL, ")
            .AppendLine("       NroMovimientoIngreso = NULL, ")
            .AppendLine("       IdCliente = NULL, ")

         ElseIf tipoMovimiento = "E" Then
            .AppendLine("       IdCajaEgreso = NULL, ")
            .AppendLine("       NroPlanillaEgreso = NULL, ")
            .AppendLine("       NroMovimientoEgreso = NULL, ")
            .AppendLine("       IdProveedor = NULL, ")
         End If
         .AppendLine("       IdEstadoCheque = IdEstadoChequeAnt, ")
         .AppendLine("       IdEstadoChequeAnt = IdEstadoCheque")

         .AppendFormat(" ,IdUsuarioActualizacion = '{0}'", idUsuarioActualizacion)


         .AppendFormatLine(" WHERE IdCheque = {0}", IdCheque)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function RecuperarEstadosChequeAnteriores(idCheque As Long) As DataTable

      '# Obtengo el estado actual del cheque sobre el cual voy a eliminar el movimiento
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT TOP(1) * FROM ChequesHistorial CH")
         .AppendFormatLine("WHERE CH.IdEstadoCheque <> (Select TOP(1) CH.IdEstadoCheque FROM ChequesHistorial CH")
         .AppendFormatLine("         						WHERE CH.idCheque = {0} ", idCheque)
         .AppendFormatLine("         						ORDER BY CH.FechaActualizacion DESC ) ")
         .AppendFormatLine("			And CH.idCheque = {0}", idCheque)
         .AppendFormatLine("         	ORDER BY CH.FechaActualizacion DESC")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetTodos(idSucursal As Integer,
                               idCajaIngreso As Integer,
                               FechaCobroDesde As Date,
                               FechaCobroHasta As Date,
                               TipoMovimiento As String,
                               IdBanco As Integer,
                               IdLocalidad As Integer,
                               EsPropio As Boolean) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("Select ")
         .AppendLine("  Convert(Bit,0) As Selecciono , ")
         .AppendLine("  C.IdCheque, ")
         .AppendLine("  C.IdBanco, ")
         .AppendLine("  B.NombreBanco, ")
         .AppendLine("  C.IdBancoSucursal, ")
         .AppendLine("  C.IdLocalidad, ")
         .AppendLine("  L.NombreLocalidad Localidad, ")
         .AppendLine("  C.NumeroCheque, ")
         .AppendLine("  C.FechaEmision, ")
         .AppendLine("  C.FechaCobro, ")
         .AppendLine("  C.Titular, ")
         .AppendLine("  C.CUIT, ")
         .AppendLine("  C.Importe, ")
         .AppendLine("  C.IdEstadoCheque, ")
         .AppendLine("  C.IdCajaIngreso, ")
         .AppendLine("  C.NroPlanillaIngreso, ")
         .AppendLine("  C.NroMovimientoIngreso, ")
         .AppendLine("  CI.Observacion As ObservacionIngreso, ")
         .AppendLine("  CI.FechaMovimiento As FechaIngreso, ")
         .AppendLine("  C.IdCajaEgreso, ")
         .AppendLine("  C.NroPlanillaEgreso, ")
         .AppendLine("  C.NroMovimientoEgreso, ")
         .AppendLine("  C.IdTipoCheque, ")
         .AppendLine("  TC.NombreTipoCheque, ")
         .AppendLine("  C.NroOperacion, ")
         .AppendLine("  C.IdChequera, ")
         .AppendLine("  CE.Observacion As ObservacionEgreso, ")
         .AppendLine("  CE.FechaMovimiento As FechaEgreso, ")
         .AppendLine("  CS.NombreCliente As Cliente ")
         'PE-31207 DEBERIA AGREGAR CAMPOS NUEVOS?

         .AppendLine(" FROM Cheques C INNER JOIN Bancos B On C.IdBanco = B.IdBanco ")
         .AppendLine(" INNER JOIN TiposCheques TC On C.IdTipoCheque = TC.IdTipoCheque")
         .AppendLine(" INNER JOIN Localidades L On C.IdLocalidad = L.IdLocalidad ")
         .AppendLine(" LEFT JOIN CajasDetalle CI On C.NroPlanillaIngreso = CI.NumeroPlanilla And C.NroMovimientoIngreso = CI.NumeroMovimiento  And C.IdCajaIngreso = CI.IdCaja And CI.IdSucursal = " & idSucursal.ToString())
         .AppendLine(" LEFT JOIN CajasDetalle CE On C.NroPlanillaEgreso = CE.NumeroPlanilla And C.NroMovimientoEgreso = CE.NumeroMovimiento And C.IdCajaEgreso = CE.IdCaja And CE.IdSucursal = " & idSucursal.ToString())
         .AppendLine(" LEFT JOIN Clientes CS On CS.IdCLiente = C.IdCLiente")

         .AppendLine(" WHERE C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   And C.EsPropio = " & IIf(EsPropio, 1, 0).ToString())

         If IdBanco > 0 Then
            .AppendLine("   And C.IdBanco = " & IdBanco.ToString())
         End If

         If IdLocalidad > 0 Then
            .AppendLine("   And C.IdLocalidad = " & IdLocalidad.ToString())
         End If

         If TipoMovimiento = "I" Then
            .AppendFormat(" And C.IdEstadoCheque In ('{0}')", Entidades.Cheque.Estados.ALTA.ToString())
         ElseIf TipoMovimiento = "E" Then
            .AppendFormat("   AND C.IdCajaIngreso = {0}", idCajaIngreso)
            .AppendFormat(" AND C.IdEstadoCheque IN ('{0}')", Entidades.Cheque.Estados.ENCARTERA.ToString())
         ElseIf TipoMovimiento = "G" Then
            .AppendFormat("   AND C.IdCajaIngreso = {0}", idCajaIngreso)
            .AppendFormat(" AND C.IdEstadoCheque IN ('{0}','{1}','{2}')", Entidades.Cheque.Estados.EGRESOCAJA.ToString(),
                           Entidades.Cheque.Estados.DEPOSITADO.ToString(),
                           Entidades.Cheque.Estados.PROVEEDOR.ToString())
         End If

         .AppendLine("   AND C.FechaCobro >= '" & FechaCobroDesde.ToString("yyyyMMdd") & " 00:00:00' ")
         .AppendLine("   AND C.FechaCobro <= '" & FechaCobroHasta.ToString("yyyyMMdd") & " 23:59:59' ")

         .AppendLine("   ORDER BY C.FechaCobro")
      End With

      Return Me.GetDataTable(stbQuery.ToString())
   End Function

   Public Sub Cheques_UAsociarNroMovimientoIngreso(idSucursal As Integer,
                                                   idCaja As Integer,
                                                   nroDePlanilla As Integer,
                                                   nroDeMovimiento As Integer,
                                                   idBanco As Integer,
                                                   idBancoSucursal As Integer,
                                                   idLocalidad As Integer,
                                                   numeroCheque As Integer,
                                                   idEstadoCheque As Entidades.Cheque.Estados,
                                                   idCliente As Long,
                                                   idUsuarioActualizacion As String,
                                                   nroCUIT As String) ',
      '                                             idCheque As Long)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Cheques SET ")
         .AppendFormat("       IdCajaIngreso = {0}", idCaja)
         .AppendLine("       ,NroPlanillaIngreso = " & nroDePlanilla.ToString())
         .AppendLine("      ,NroMovimientoIngreso = " & nroDeMovimiento.ToString())
         .AppendLine("      ,IdEstadoChequeAnt = IdEstadoCheque ")
         .AppendLine("      ,IdEstadoCheque = '" & idEstadoCheque.ToString() & "'")
         If idCliente <> 0 Then
            .AppendLine("      ,IdCliente = " & idCliente)
         End If

         .AppendFormat(" ,IdUsuarioActualizacion = '{0}'", idUsuarioActualizacion)

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND NumeroCheque = " & numeroCheque.ToString())
         .AppendLine("   AND IdBanco = " & idBanco.ToString())
         .AppendLine("   AND Cuit = " & nroCUIT)
         .AppendLine("   AND IdBancoSucursal = " & idBancoSucursal.ToString())
         .AppendLine("   AND IdLocalidad = " & idLocalidad.ToString())
         '.AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Cheques_UAsociarNroMovimientoEgreso(idsucursal As Integer,
                                                  idcaja As Integer,
                                                  nrodeplanilla As Integer,
                                                  nrodemovimiento As Integer,
                                                  idbanco As Integer,
                                                  idbancosucursal As Integer,
                                                  idlocalidad As Integer,
                                                  numerocheque As Integer,
                                                  idestadocheque As Entidades.Cheque.Estados,
                                                  idproveedor As Long,
                                                  idusuarioactualizacion As String,
                                                  idCheque As Long)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Cheques SET ")
         .AppendFormat("       IdCajaEgreso = {0}", idcaja)
         .AppendLine("       ,NroPlanillaEgreso = " & nrodeplanilla.ToString())
         .AppendLine("      ,NroMovimientoEgreso = " & nrodemovimiento.ToString())
         .AppendLine("      ,IdEstadoChequeAnt = IdEstadoCheque")
         .AppendLine("      ,IdEstadoCheque = '" & idestadocheque.ToString() & "'")
         If idproveedor > 0 Then
            .AppendLine("      ,IdProveedor = " & idproveedor.ToString())
         End If

         .AppendFormat(" ,IdUsuarioActualizacion = '{0}'", idusuarioactualizacion)

         .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Cheques_ActualizaEstado(idSucursal As Integer,
                                      idBanco As Integer,
                                      idBancoSucursal As Integer,
                                      idLocalidad As Integer,
                                      numeroCheque As Integer,
                                      idEstadoCheque As Entidades.Cheque.Estados,
                                      idUsuarioActualizacion As String,
                                      idCheque As Long)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Cheques SET")
         .AppendLine("   IdEstadoChequeAnt = IdEstadoCheque")
         .AppendLine("   ,IdEstadoCheque = '" & idEstadoCheque.ToString() & "'")

         .AppendFormat(" ,IdUsuarioActualizacion = '{0}'", idUsuarioActualizacion)

         .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   'Public Sub Cheques_VuelveEstadoAnt(idSucursal As Integer,
   '                                   idBanco As Integer,
   '                                   idBancoSucursal As Integer,
   '                                   idLocalidad As Integer,
   '                                   numeroCheque As Integer,
   '                                   idUsuarioActualizacion As String,
   '                                   idCheque As Long)
   '   Me.Cheques_VuelveEstadoAnt(idSucursal,
   '                              idBanco,
   '                              idBancoSucursal,
   '                              idLocalidad,
   '                              numeroCheque,
   '                              idUsuarioActualizacion,
   '                              idEstadoCheque:=Nothing,
   '                              idEstadoChequeAnt:=Nothing,
   '                              idCheque:=idCheque,
   '                              limpiaPlanillaCaja:=False)
   'End Sub

   '# Sobrecarga del método original, el cual setea los estados exactamente iguales a como estaban en el movimiento anterior
   '# No guarda el estado actual como anterior
   Public Sub Cheques_VuelveEstadoAnt(idSucursal As Integer,
                                      idBanco As Integer,
                                      idBancoSucursal As Integer,
                                      idLocalidad As Integer,
                                      numeroCheque As Integer,
                                      idUsuarioActualizacion As String,
                                      idEstadoCheque As String,
                                      idEstadoChequeAnt As String,
                                      idCheque As Long,
                                      limpiaPlanillaCaja As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Cheques SET")

         If String.IsNullOrEmpty(idEstadoCheque) Then
            .AppendLine("   IdEstadoCheque = IdEstadoChequeAnt")
            .AppendLine("   ,IdEstadoChequeAnt = NULL")
         Else
            .AppendFormatLine("   IdEstadoCheque = '{0}'", idEstadoCheque)
            .AppendFormatLine("   ,IdEstadoChequeAnt = '{0}'", idEstadoChequeAnt)
         End If

         .AppendFormat(" ,IdUsuarioActualizacion = '{0}'", idUsuarioActualizacion)

         If limpiaPlanillaCaja Then
            .AppendFormatLine("   ,NroPlanillaEgreso     = NULL")
            .AppendFormatLine("   ,NroMovimientoEgreso   = NULL")
         End If

         .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function Cheques_GetAll(idSucursal As Integer,
                            FechaCobroDesde As Date,
                            FechaCobroHasta As Date,
                            TipoMovimiento As String,
                            IdBanco As Integer,
                            EsPropio As Boolean) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT ")
         .AppendLine("   	C.NumeroCheque, ")
         .AppendLine("   	C.IdBanco, ")
         .AppendLine("   	C.IdCheque, ")
         .AppendLine("   	B.NombreBanco, ")
         .AppendLine("   	C.IdBancoSucursal, ")
         .AppendLine("   	C.FechaEmision, ")
         .AppendLine("   	C.FechaCobro, ")
         .AppendLine("   	C.Titular, ")
         .AppendLine("   	C.IdLocalidad, ")
         .AppendLine("   	C.Importe, ")
         .AppendLine("   	C.IdEstadoCheque, ")
         .AppendLine("   	C.IdCajaIngreso, ")
         .AppendLine("   	C.NroPlanillaIngreso, ")
         .AppendLine("   	C.NroMovimientoIngreso, ")
         .AppendLine("   	C.IdCajaEgreso, ")
         .AppendLine("   	C.NroPlanillaEgreso, ")
         .AppendLine("   	C.NroMovimientoEgreso, ")
         .AppendLine("   	C.IdTipoCheque, ")
         .AppendLine("   	C.NroOperacion, ")
         .AppendLine("   	C.IdChequera, ")
         'PE-31207
         .AppendLine("     C.IdSituacionCheque")
         .AppendLine("    ,SC.NombreSituacionCheque")
         '---
         .AppendLine("   	,C.Observacion ")
         .AppendLine("   From Cheques C Inner Join Bancos B On C.IdBanco = B.IdBanco ")
         .AppendLine(" LEFT JOIN SituacionCheques SC ON C.IdSituacionCheque = SC.IdSituacionCheque")

         .AppendLine("   WHERE C.idSucursal = " & idSucursal.ToString())

         .AppendLine("     AND C.EsPropio = " & IIf(EsPropio, 1, 0).ToString())

         If IdBanco > 0 Then
            .AppendLine("  AND C.IdBanco = " & IdBanco.ToString())
         End If

         If TipoMovimiento = "I" Then
            .AppendLine("   And C.IdCajaIngreso IS NULL")
            .AppendLine("   And C.NroMovimientoIngreso IS NULL")
            .AppendLine("   And C.NroPlanillaIngreso IS NULL")
         ElseIf TipoMovimiento = "E" Then
            .AppendLine("   And C.IdCajaEgreso IS NULL")
            .AppendLine("   And C.NroMovimientoEgreso IS NULL")
            .AppendLine("   And C.NroPlanillaEgreso IS NULL")
         End If

         .AppendLine("   And C.FechaCobro Between '" & FechaCobroDesde.ToString("yyyyMMdd") & " 00:00:00' And '" & FechaCobroHasta.ToString("yyyyMMdd") & " 23:59:59' ")

         .AppendLine("   Order By C.FechaCobro")

      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetCantChequesEgresados(idSucursal As Integer, nroPlanillaIngreso As Integer, nroMovimientoIngreso As Integer, esPropio As Boolean) As Integer
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT COUNT(*) as Registros")
         .AppendFormatLine("  FROM Cheques")
         .AppendFormatLine(" WHERE IdSucursal            = {0}", idSucursal)
         .AppendFormatLine("   AND EsPropio              = {0}", GetStringFromBoolean(esPropio))
         .AppendFormatLine("   AND NroPlanillaIngreso    = {0}", nroPlanillaIngreso)
         .AppendFormatLine("   AND NroMovimientoIngreso  = {0}", nroMovimientoIngreso)
         .AppendFormatLine("   AND NroPlanillaEgreso     > 0")
      End With
      Using dtCheques = GetDataTable(stbQuery)
         Return dtCheques.AsEnumerable().SumSecure(Function(dr) dr.Field(Of Integer?)("Registros").IfNull()).IfNull()
      End Using
   End Function

   Public Function GetPorCuentaCorriente(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.* ")
         .AppendFormatLine("     , TC.NombreTipoCheque")
         .AppendFormatLine("     , SC.NombreSituacionCheque")
         .AppendFormatLine("  FROM CuentasCorrientesCheques CCC")
         .AppendFormatLine(" INNER JOIN Cheques C ON C.IdCheque = CCC.IdCheque ")
         .AppendFormatLine(" INNER JOIN TiposCheques TC ON C.IdTipoCheque = TC.IdTipoCheque")
         .AppendFormatLine("  LEFT JOIN SituacionCheques SC ON SC.IdSituacionCheque = C.IdSituacionCheque")
         .AppendFormatLine(" WHERE CCC.IdSucursal        =  {0} ", idSucursal)
         .AppendFormatLine("   AND CCC.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCC.Letra             = '{0}'", letra)
         .AppendFormatLine("   AND CCC.CentroEmisor      =  {0} ", centroEmisor)
         .AppendFormatLine("   AND CCC.NumeroComprobante =  {0} ", numeroComprobante)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPorCuentaCorrienteProv(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                             esPropio As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.* ")
         .AppendFormatLine("     , TC.NombreTipoCheque")
         .AppendFormatLine("     , SC.NombreSituacionCheque")
         .AppendFormatLine("  FROM CuentasCorrientesProvCheques CCC")
         .AppendFormatLine(" INNER JOIN Cheques C ON C.IdCheque = CCC.IdCheque")
         .AppendFormatLine(" INNER JOIN TiposCheques TC ON C.IdTipoCheque = TC.IdTipoCheque")
         .AppendFormatLine("  LEFT JOIN SituacionCheques SC ON SC.IdSituacionCheque = C.IdSituacionCheque")
         .AppendFormatLine(" WHERE CCC.IdSucursal = {0}   ", idSucursal)
         .AppendFormatLine("   AND CCC.IdProveedor = {0} ", idProveedor)
         .AppendFormatLine("   AND CCC.IdTipoComprobante = '{0}'   ", idTipoComprobante)
         .AppendFormatLine("   AND CCC.Letra = '{0}'   ", letra)
         .AppendFormatLine("   AND CCC.CentroEmisor = {0}   ", centroEmisor)
         .AppendFormatLine("   AND CCC.NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND C.EsPropio = {0}", GetStringFromBoolean(esPropio))
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPorDeposito(idSucursal As Integer, idTipoComprobante As String, numeroDeposito As Long,
                                  esPropio As Boolean?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.*")
         .AppendFormatLine("     , TC.NombreTipoCheque")
         .AppendFormatLine("     , SC.NombreSituacionCheque")
         .AppendFormatLine("  FROM DepositosCheques DC")
         .AppendFormatLine(" INNER JOIN Cheques C ON C.IdCheque = DC.IdCheque")
         .AppendFormatLine(" INNER JOIN TiposCheques TC ON C.IdTipoCheque = TC.IdTipoCheque")
         .AppendFormatLine("  LEFT JOIN SituacionCheques SC ON SC.IdSituacionCheque = C.IdSituacionCheque")
         .AppendFormatLine(" WHERE DC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND DC.NumeroDeposito = {0}", numeroDeposito)
         .AppendFormatLine("   AND DC.IdTipoComprobante = '{0}'", idTipoComprobante)
         If esPropio.HasValue Then
            .AppendFormatLine("   AND C.EsPropio = {0}", GetStringFromBoolean(esPropio.Value))
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetChequesDetalleAyuda(idSucursal As Integer,
                               IdCaja As Integer,
                               FechaCobroDesde As Date,
                               FechaCobroHasta As Date,
                               FechaEnCarteraAl As Date,
                               Numero As Long,
                               IdBanco As Integer,
                               IdLocalidad As Integer,
                               EsPropio As Boolean,
                               IdCliente As Long,
                               IdProveedor As Long,
                               Titular As String,
                                  TipoMovimiento As String,
                                 tipoCheque As String) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT C.IdBanco")
         .AppendLine("      ,B.NombreBanco")
         .AppendLine("      ,C.IdCheque")
         .AppendLine("      ,C.IdBancoSucursal")
         .AppendLine("      ,C.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,C.NumeroCheque")
         .AppendLine("      ,C.FechaEmision")
         .AppendLine("      ,C.FechaCobro")
         .AppendLine("      ,C.Titular")
         .AppendLine("      ,C.Importe")
         .AppendLine("      ,C.IdEstadoCheque")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,Cl.NombreCliente")
         .AppendLine("      ,Cl.CodigoCliente")
         .AppendLine("      ,C.IdCajaIngreso")
         .AppendLine("      ,CNI.NombreCaja NombreCajaIngreso")
         .AppendLine("      ,C.NroPlanillaIngreso")
         .AppendLine("      ,C.NroMovimientoIngreso")
         .AppendLine("      ,CI.Observacion as ObservacionIngreso")
         .AppendLine("      ,CI.FechaMovimiento as FechaIngreso")
         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,C.IdCajaEgreso")
         .AppendLine("      ,C.NroPlanillaEgreso")
         .AppendLine("      ,C.NroMovimientoEgreso")
         .AppendLine("      ,C.IdTipoCheque")
         .AppendLine("      ,TC.NombreTipoCheque")
         .AppendLine("      ,C.NroOperacion")
         .AppendLine("      ,C.IdChequera")
         .AppendLine("      ,CE.Observacion as ObservacionEgreso")
         .AppendLine("      ,CE.FechaMovimiento as FechaEgreso")
         '-- REQ-32950.- --
         .AppendLine("     ,C.Cuit")

         .AppendLine(" FROM Cheques C INNER JOIN Bancos B ON C.IdBanco = B.IdBanco ")
         .AppendLine(" INNER JOIN TiposCheques TC ON C.IdTipoCheque = TC.IdTipoCheque")
         .AppendLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad ")
         .AppendLine(" LEFT OUTER JOIN Clientes Cl ON C.IdCliente = Cl.IdCliente ")
         .AppendLine(" LEFT OUTER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor ")

         .AppendLine(" LEFT JOIN CajasDetalle CI ON C.NroPlanillaIngreso = CI.NumeroPlanilla AND C.NroMovimientoIngreso = CI.NumeroMovimiento  AND C.IdCajaIngreso = CI.IdCaja AND CI.IdSucursal = " & idSucursal.ToString())
         .AppendLine(" LEFT JOIN CajasDetalle CE ON C.NroPlanillaEgreso = CE.NumeroPlanilla AND C.NroMovimientoEgreso = CE.NumeroMovimiento AND C.IdCajaEgreso = CE.IdCaja AND CE.IdSucursal = " & idSucursal.ToString())

         .AppendLine(" LEFT JOIN CajasNombres CNI ON C.IdSucursal = CNI.IdSucursal AND C.IdCajaIngreso = CNI.IdCaja")

         .AppendLine(" WHERE C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND C.EsPropio = '" & EsPropio.ToString() & "'")

         '# Tipo de Cheque
         If Not String.IsNullOrEmpty(tipoCheque) Then
            .AppendFormatLine("AND C.IdTipoCheque = '{0}'", tipoCheque)
         End If

         If IdCaja > 0 Then
            .AppendLine("   AND C.IdCajaIngreso = " & IdCaja.ToString())
         End If

         If FechaCobroDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND CONVERT(varchar(11), C.FechaCobro, 120) >= '" & FechaCobroDesde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("   AND CONVERT(varchar(11), C.FechaCobro, 120) <= '" & FechaCobroHasta.ToString("yyyy-MM-dd") & "'")
         End If

         'Los que ingresaron hasta esa fecha y salieron posterior (en Cartera a una fecha).
         'Habria que hacer un seguimiento del estado, por las dudas.
         If FechaEnCarteraAl > Date.Parse("01/01/1990") Then
            .AppendLine("   AND CONVERT(varchar(11), CI.FechaMovimiento , 120) <= '" & FechaEnCarteraAl.ToString("yyyy-MM-dd") & "'")
            .AppendLine("   AND ( CE.FechaMovimiento IS NULL OR CONVERT(varchar(11), CE.FechaMovimiento , 120) > '" & FechaEnCarteraAl.ToString("yyyy-MM-dd") & "')")
         End If

         If Numero > 0 Then
            .AppendLine("   AND C.NumeroCheque = " & Numero.ToString())
         End If

         If IdBanco > 0 Then
            .AppendLine("   AND C.IdBanco = " & IdBanco.ToString())
         End If

         If IdLocalidad > 0 Then
            .AppendLine("   AND C.IdLocalidad = " & IdLocalidad.ToString())
         End If

         If IdCliente <> 0 Then
            .AppendLine("	AND Cl.IdCliente = " & IdCliente)
         End If

         If IdProveedor <> 0 Then
            .AppendLine("	AND P.IdProveedor = " & IdProveedor.ToString())
         End If

         If Not String.IsNullOrEmpty(Titular) Then
            .AppendLine("	AND C.Titular LIKE '%" & Titular & "%'")
         End If

         If TipoMovimiento = "I" Then
            .AppendFormat(" AND C.IdEstadoCheque IN ('{0}')", Entidades.Cheque.Estados.ALTA.ToString())
         ElseIf TipoMovimiento = "E" Then
            .AppendFormat("   AND C.IdCajaIngreso = {0}", IdCaja)
            .AppendFormat(" AND C.IdEstadoCheque IN ('{0}')", Entidades.Cheque.Estados.ENCARTERA.ToString())
         ElseIf TipoMovimiento = "G" Then
            .AppendFormat("   AND C.IdCajaIngreso = {0}", IdCaja)
            .AppendFormat(" AND C.IdEstadoCheque IN ('{0}','{1}','{2}')", Entidades.Cheque.Estados.EGRESOCAJA.ToString(),
                           Entidades.Cheque.Estados.DEPOSITADO.ToString(),
                           Entidades.Cheque.Estados.PROVEEDOR.ToString())
         End If

         .AppendLine("   ORDER BY C.FechaCobro")

      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetInforme(
         sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(), estados As Entidades.EstadoCheque(),
         fechaCobroDesde As Date, fechaCobroHasta As Date, fechaEnCarteraAl As Date,
         numero As Long, idBanco As Integer, idLocalidad As Integer, esPropio As Boolean,
         idCliente As Long, idProveedor As Long, titular As String,
         fechaIngresoDesde As Date, fechaIngresoHasta As Date,
         idCuentaBancaria As Integer, orden As Entidades.Cheque.Ordenamiento, tipoCheque As String, conciliado As Boolean?,
         observacion As String) As DataTable

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT C.IdBanco")
         .AppendLine("      ,C.IdCheque")
         .AppendLine("      ,B.NombreBanco")
         .AppendLine("      ,C.IdBancoSucursal")
         .AppendLine("      ,C.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,C.NumeroCheque")
         .AppendLine("      ,CONVERT(date, C.FechaEmision) as FechaEmision")
         .AppendLine("      ,CONVERT(date, C.FechaCobro) as FechaCobro")
         .AppendLine("      ,C.Titular")
         .AppendLine("      ,C.Importe")
         .AppendLine("      ,C.IdEstadoCheque")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,Cl.NombreCliente")
         .AppendLine("      ,Cl.IdCliente")
         .AppendLine("      ,Cl.CodigoCliente")
         .AppendLine("      ,C.IdCajaIngreso")
         .AppendLine("      ,CNI.NombreCaja NombreCajaIngreso")
         .AppendLine("      ,C.NroPlanillaIngreso")
         .AppendLine("      ,C.NroMovimientoIngreso")
         .AppendLine("      ,CI.Observacion as ObservacionIngreso")
         .AppendLine("      ,CONVERT(date, CI.FechaMovimiento) as FechaIngreso")
         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,C.IdCajaEgreso")
         .AppendLine("      ,CNe.NombreCaja NombreCajaEgreso")
         .AppendLine("      ,C.NroPlanillaEgreso")
         .AppendLine("      ,C.NroMovimientoEgreso")
         .AppendLine("      ,CE.Observacion as ObservacionEgreso")
         .AppendLine("      ,CONVERT(date, CE.FechaMovimiento) as FechaEgreso")
         .AppendLine("      ,C.Cuit")
         .AppendLine("      ,C.IdCuentaBancaria")
         .AppendLine("      ,CB.NombreCuenta")
         .AppendLine("      ,C.IdProveedorPreasignado")
         .AppendLine("      ,C.IdTipoCheque")
         .AppendLine("      ,TC.NombreTipoCheque")
         .AppendLine("      ,C.NroOperacion")
         .AppendLine("      ,C.IdChequera")
         .AppendLine("      ,PA.CodigoProveedor AS CodigoProveedorPreasignado")
         .AppendLine("      ,PA.NombreProveedor AS ProveedorPreasignado")

         .AppendLine("      ,C.idSituacionCheque")
         .AppendLine("      ,SCH.NombreSituacionCheque")

         .AppendLine("      ,CASE WHEN CE.FechaMovimiento IS NULL THEN '' ELSE")
         .AppendLine("       CASE WHEN C.FechaCobro >  CE.FechaMovimiento THEN 'Pend. Fecha de Cobro' ELSE")
         .AppendLine("       CASE WHEN C.FechaCobro <= CE.FechaMovimiento THEN 'Cobro al Día' ELSE '' END END END SituacionCobro")
         .AppendLine("      ,'C: ' + CONVERT(VARCHAR(MAX), C.IdCajaIngreso) + ' - P: ' + CONVERT(VARCHAR(MAX), C.NroPlanillaIngreso) + ' - M: ' + CONVERT(VARCHAR(MAX), C.NroMovimientoIngreso) + ' - ' + CONVERT(VARCHAR(MAX), CI.FechaMovimiento, 103) + ' / ' + CI.Observacion Ingreso")
         .AppendLine("      ,'C: ' + CONVERT(VARCHAR(MAX), C.IdCajaEgreso)  + ' - P: ' + CONVERT(VARCHAR(MAX), C.NroPlanillaEgreso)  + ' - M: ' + CONVERT(VARCHAR(MAX), C.NroMovimientoEgreso)  + ' - ' + CONVERT(VARCHAR(MAX), CE.FechaMovimiento, 103) + ' / ' + CE.Observacion Egreso ")
         .AppendLine("      ,C.Observacion")
         .AppendLine(" FROM Cheques C INNER JOIN Bancos B ON C.IdBanco = B.IdBanco ")
         .AppendLine(" INNER JOIN TiposCheques TC ON C.IdTipoCheque = TC.IdTipoCheque")
         .AppendLine(" INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad ")

         .AppendLine(" INNER JOIN SituacionCheques SCH ON SCH.IdSituacionCheque = C.IdSituacionCheque ")


         .AppendLine(" LEFT OUTER JOIN Clientes Cl ON C.IdCliente = Cl.IdCliente ")
         .AppendLine(" LEFT OUTER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor ")
         .AppendLine(" LEFT OUTER JOIN Proveedores PA ON C.IdProveedorPreasignado = PA.IdProveedor ")
         .AppendLine(" LEFT OUTER JOIN CuentasBancarias CB ON CB.idCuentaBancaria = C.IdCuentaBancaria")

         .AppendLine(" LEFT JOIN CajasDetalle CI ON C.NroPlanillaIngreso = CI.NumeroPlanilla AND C.NroMovimientoIngreso = CI.NumeroMovimiento  AND C.IdCajaIngreso = CI.IdCaja AND CI.IdSucursal = C.IdSucursal")
         .AppendLine(" LEFT JOIN CajasDetalle CE ON C.NroPlanillaEgreso = CE.NumeroPlanilla AND C.NroMovimientoEgreso = CE.NumeroMovimiento AND C.IdCajaEgreso = CE.IdCaja AND CE.IdSucursal = C.IdSucursal")

         .AppendLine(" LEFT JOIN CajasNombres CNI ON C.IdSucursal = CNI.IdSucursal AND C.IdCajaIngreso = CNI.IdCaja")
         .AppendLine(" LEFT JOIN CajasNombres CNE ON C.IdSucursal = CNE.IdSucursal AND C.IdCajaEgreso = CNE.IdCaja")
         .AppendLine(" LEFT JOIN LibrosBancos LB ON LB.IdCheque = C.IdCheque")
         .AppendLine(" WHERE 1 = 1")
         '.AppendLine(" WHERE C.IdSucursal = " & idSucursal.ToString())
         ' agrego la multiple sucursal

         GetListaSucursalesMultiples(stbQuery, sucursales, "C")

         .AppendLine("   AND C.EsPropio = '" & esPropio.ToString() & "'")

         If Not String.IsNullOrEmpty(tipoCheque) Then
            .AppendFormatLine("   AND C.IdTipoCheque = '{0}'", tipoCheque)
         End If

         If idCuentaBancaria > 0 Then
            .AppendLine("   AND C.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If

         If cajas.Length > 0 Then
            If esPropio Then
               GetListaMultiples(stbQuery, cajas, "C", "IdCajaEgreso")
            Else
               GetListaMultiples(stbQuery, cajas, "C", "IdCajaIngreso")
            End If
         End If

         GetListaEstadosChequesMultiples(stbQuery, estados, "C")

         'If IdEstado <> Cheque.Estados.NINGUNO Then
         '   .AppendLine("   AND C.IdEstadoCheque = '" & IdEstado.ToString() & "'")
         'End If

         If fechaCobroDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND CONVERT(date, FechaCobro) >= '" & fechaCobroDesde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("   AND CONVERT(date, FechaCobro) <= '" & fechaCobroHasta.ToString("yyyy-MM-dd") & "'")
         End If

         'Los que ingresaron hasta esa fecha y salieron posterior (en Cartera a una fecha).
         'Habria que hacer un seguimiento del estado, por las dudas.
         If fechaEnCarteraAl > Date.Parse("01/01/1990") Then
            .AppendLine("   AND ( CONVERT(date, CI.FechaMovimiento) <= '" & fechaEnCarteraAl.ToString("yyyy-MM-dd") & "'")
            .AppendLine("         AND (CONVERT(date, CE.FechaMovimiento) IS NULL OR CONVERT(date, CE.FechaMovimiento) > '" & fechaEnCarteraAl.ToString("yyyy-MM-dd") & "'))")
         End If

         If numero > 0 Then
            .AppendLine("   AND C.NumeroCheque = " & numero.ToString())
         End If

         If idBanco > 0 Then
            .AppendLine("   AND C.IdBanco = " & idBanco.ToString())
         End If

         If idLocalidad > 0 Then
            .AppendLine("   AND C.IdLocalidad = " & idLocalidad.ToString())
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND Cl.IdCliente = " & idCliente)
         End If

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If Not String.IsNullOrEmpty(titular) Then
            .AppendLine("	AND C.Titular LIKE '%" & titular & "%'")
         End If

         If Not String.IsNullOrEmpty(observacion) Then
            .AppendLine("	AND C.Observacion LIKE '%" & observacion & "%'")
         End If

         If fechaIngresoDesde > Date.Parse("01/01/1990") Then
            If esPropio Then
               .AppendLine("   AND CONVERT(date, C.FechaEmision) >= '" & fechaIngresoDesde.ToString("yyyy-MM-dd") & "'")
               .AppendLine("   AND CONVERT(date, C.FechaEmision) <= '" & fechaIngresoHasta.ToString("yyyy-MM-dd") & "'")
            Else
               .AppendLine("   AND CONVERT(date, CI.FechaMovimiento) >= '" & fechaIngresoDesde.ToString("yyyy-MM-dd") & "'")
               .AppendLine("   AND CONVERT(date, CI.FechaMovimiento) <= '" & fechaIngresoHasta.ToString("yyyy-MM-dd") & "'")
            End If
         End If
         If conciliado.HasValue Then
            .AppendLine("    AND LB.Conciliado = 0")
         End If
         If orden = Entidades.Cheque.Ordenamiento.FECHACOBRO Then
            .AppendLine("   ORDER BY C.FechaCobro")
         ElseIf orden = Entidades.Cheque.Ordenamiento.NOMBREYFECHACOBRO Then
            .AppendLine("   ORDER BY Cl.NombreCliente , C.FechaCobro")
         End If

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPorComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.*")
         .AppendFormatLine("     , TC.NombreTipoCheque")
         .AppendFormatLine("     , SC.NombreSituacionCheque")
         .AppendFormatLine("  FROM VentasCheques VC")
         .AppendFormatLine(" INNER JOIN Cheques C ON C.IdCheque = VC.IdCheque")
         .AppendFormatLine(" INNER JOIN TiposCheques TC ON TC.IdTipoCheque = C.IdTipoCheque")
         .AppendFormatLine("  LEFT JOIN SituacionCheques SC ON SC.IdSituacionCheque = C.IdSituacionCheque")
         .AppendFormatLine("  WHERE VC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("    AND VC.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("    AND VC.Letra = '{0}'", letra)
         .AppendFormatLine("    AND VC.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("    AND VC.NumeroComprobante = {0}", numeroComprobante)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPorComprobanteCtaCte(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.*")
         .AppendFormatLine("     , TC.NombreTipoCheque")
         .AppendFormatLine("     , SC.NombreSituacionCheque")
         .AppendFormatLine("  FROM CuentasCorrientesCheques VC")
         .AppendFormatLine(" INNER JOIN Cheques C ON C.IdCheque = VC.IdCheque")
         .AppendFormatLine(" INNER JOIN TiposCheques TC ON TC.IdTipoCheque = C.IdTipoCheque")
         .AppendFormatLine("  LEFT JOIN SituacionCheques SC ON SC.IdSituacionCheque = C.IdSituacionCheque")
         .AppendFormatLine("  WHERE VC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("    AND VC.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("    AND VC.Letra = '{0}'", letra)
         .AppendFormatLine("    AND VC.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("    AND VC.NumeroComprobante = {0}", numeroComprobante)
      End With
      Return GetDataTable(stb)
   End Function

   'Public Function GetPorComprobanteCompra(idSucursal As Integer,
   '                                        IdProveedor As Long,
   '                                        idTipoComprobante As String,
   '                                        letra As String,
   '                                        centroEmisor As Short,
   '                                        numeroComprobante As Long) As DataTable

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT C.* ")
   '      .AppendLine(",TC.NombreTipoCheque")
   '      .AppendLine("FROM Cheques C, ComprasCheques CC, TiposCheques TC")
   '      .AppendLine("  WHERE C.IdCheque = CC.IdCheque")
   '      .AppendLine("    AND C.IdTipoCheque = TC.IdTipoCheque")
   '      .AppendLine("    AND CC.IdSucursal = " & idSucursal.ToString())
   '      .AppendLine("    AND CC.IdTipoComprobante = '" & idTipoComprobante & "'")
   '      .AppendLine("    AND CC.Letra = '" & letra & "'")
   '      .AppendLine("    AND CC.CentroEmisor = " & centroEmisor.ToString())
   '      .AppendLine("    AND CC.NumeroComprobante = " & numeroComprobante.ToString())
   '      .AppendLine("    AND CC.IdProveedor = " & IdProveedor.ToString())
   '   End With

   '   Return Me.GetDataTable(stb.ToString())

   'End Function

   Public Function GetPorComprobanteCompraCH(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                             esPropio As Boolean?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.* ")
         .AppendFormatLine("     , TC.NombreTipoCheque")
         .AppendFormatLine("     , SC.NombreSituacionCheque")
         .AppendFormatLine("  FROM ComprasCheques CC")
         .AppendFormatLine(" INNER JOIN Cheques C ON C.IdCheque = CC.IdCheque")
         .AppendFormatLine(" INNER JOIN TiposCheques TC ON TC.IdTipoCheque = C.IdTipoCheque")
         .AppendFormatLine("  LEFT JOIN SituacionCheques SC ON SC.IdSituacionCheque = C.IdSituacionCheque")
         .AppendFormatLine("  WHERE CC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("    AND CC.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("    AND CC.Letra = '{0}'", letra)
         .AppendFormatLine("    AND CC.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("    AND CC.NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("    AND CC.IdProveedor = {0}", idProveedor)
         If esPropio.HasValue Then
            .AppendFormatLine("    AND C.EsPropio = {0}", GetStringFromBoolean(esPropio.Value))
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetRechazadosPorComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.* ")
         .AppendFormatLine("     , TC.NombreTipoCheque")
         .AppendFormatLine("     , SC.NombreSituacionCheque")
         .AppendFormatLine("  FROM VentasChequesRechazados VC")
         .AppendFormatLine(" INNER JOIN Cheques C ON VC.IdCheque = C.IdCheque")
         .AppendFormatLine(" INNER JOIN TiposCheques TC ON TC.IdTipoCheque = C.IdTipoCheque")
         .AppendFormatLine("  LEFT JOIN SituacionCheques SC ON SC.IdSituacionCheque = C.IdSituacionCheque")
         .AppendFormatLine("  WHERE VC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("    AND VC.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("    AND VC.Letra = '{0}'", letra)
         .AppendFormatLine("    AND VC.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("    AND VC.NumeroComprobante = {0}", numeroComprobante)
      End With
      Return GetDataTable(stb)
   End Function

   'El método de Reglas no se estaría usando por lo que lo comento para estar seguro.
   'De tener que habilitarlo debemos agregar el campo NombreSituacionCheque a la consulta.
   'Public Function GetPorMovimientoCaja(idSucursal As Integer,
   '                                     IdCaja As Integer,
   '                                        NroPlanilla As Integer,
   '                                        NroMovimiento As Integer,
   '                                        EsPropio As Boolean) As DataTable

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT C.*")
   '      .AppendLine(",TC.NombreTipoCheque")
   '      .AppendLine("FROM Cheques C")
   '      'No hace falta. Ademas, para que todas las sucursales lo vean y modifiquen, tiene que quitarlo.
   '      .AppendFormatLine("INNER JOIN TiposCheques TC ON C.IdTipoCheque = TC.IdTipoCheque")
   '      .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
   '      .AppendLine("   AND C.EsPropio = " & IIf(EsPropio, 1, 0).ToString())
   '      .AppendLine("   AND ")
   '      .AppendLine("       ( ")
   '      .AppendFormat("           C.IdCajaIngreso = {0}", IdCaja)
   '      .AppendLine("       AND C.NroPlanillaIngreso = " & NroPlanilla.ToString())
   '      .AppendLine("       AND C.NroMovimientoIngreso = " & NroMovimiento.ToString())
   '      .AppendLine("       ) Or ( ")
   '      .AppendFormat("           C.IdCajaEgreso = {0}", IdCaja)
   '      .AppendLine("       AND C.NroPlanillaEgreso = " & NroPlanilla.ToString())
   '      .AppendLine("       AND C.NroMovimientoEgreso = " & NroMovimiento.ToString())
   '      .AppendLine("       ) ")
   '   End With

   '   Return Me.GetDataTable(stb.ToString())

   'End Function

   Private Sub SelectFiltrado(stb As StringBuilder)

      With stb
         .Length = 0
         .AppendLine("SELECT C.IdSucursal")
         .AppendLine("      ,C.IdCheque")
         .AppendLine("      ,C.IdCuentaBancaria")
         .AppendLine("      ,CB.NombreCuenta")
         .AppendLine("      ,C.NumeroCheque")
         .AppendLine("      ,C.IdBanco")
         .AppendLine("      ,B.NombreBanco")
         .AppendLine("      ,C.IdBancoSucursal")
         .AppendLine("      ,C.FechaEmision")
         .AppendLine("      ,C.FechaCobro")
         .AppendLine("      ,C.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,C.Titular")
         .AppendLine("      ,C.Cuit")
         .AppendLine("      ,C.Importe")
         .AppendLine("      ,C.IdEstadoCheque")
         .AppendLine("      ,C.IdCajaIngreso")
         .AppendLine("      ,C.NroPlanillaIngreso")
         .AppendLine("      ,C.NroMovimientoIngreso")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,Cl.CodigoCliente")
         .AppendLine("      ,Cl.NombreCliente")
         .AppendLine("      ,C.IdCajaEgreso")
         .AppendLine("      ,C.NroPlanillaEgreso")
         .AppendLine("      ,C.NroMovimientoEgreso")
         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,C.EsPropio")
         .AppendLine("      ,C.IdEstadoChequeAnt")
         .AppendLine("      ,C.FotoFrente")
         .AppendLine("      ,C.FotoDorso")
         .AppendLine("      ,C.IdProveedorPreasignado")
         .AppendLine("      ,C.IdTipoCheque")
         .AppendLine("      ,TC.NombreTipoCheque")
         .AppendLine("      ,C.NroOperacion")
         .AppendLine("      ,C.IdChequera")
         .AppendLine("      ,PA.CodigoProveedor AS CodigoProveedorPreasignado")
         .AppendLine("      ,PA.NombreProveedor AS ProveedorPreasignado")
         '---PE-31207
         .AppendLine("      ,C.IdSituacionCheque")
         .AppendLine("      ,SC.NombreSituacionCheque")
         '---.
         .AppendLine("      ,C.Observacion")

         .AppendLine(" FROM Cheques C")
         .AppendLine(" INNER JOIN TiposCheques TC ON C.IdTipoCheque = TC.IdTipoCheque")
         .AppendLine(" INNER JOIN Bancos B On C.IdBanco = B.IdBanco ")
         .AppendLine(" INNER JOIN Localidades L On C.IdLocalidad = L.IdLocalidad ")
         '---PE-31207
         .AppendLine(" LEFT JOIN SituacionCheques SC ON C.IdSituacionCheque = SC.IdSituacionCheque")
         '---.
         .AppendLine(" LEFT OUTER JOIN CuentasBancarias CB ON C.IdCuentaBancaria = CB.IdCuentaBancaria")
         .AppendLine(" LEFT OUTER JOIN Clientes Cl ON C.IdCliente = Cl.IdCliente ")
         .AppendLine(" LEFT OUTER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor ")
         .AppendLine(" LEFT OUTER JOIN Proveedores PA ON C.IdProveedorPreasignado = PA.IdProveedor ")
      End With

   End Sub

   Public Function GetCantidadADepositar(idSucursal As Integer, alDia As DateTime) As Integer

      Dim stb As StringBuilder = New StringBuilder()

      'With stb
      '   .Length = 0
      '   .AppendLine("SELECT COUNT(idbanco) AS Cantidad")
      '   .AppendLine(" FROM Cheques")
      '   .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
      '   .AppendFormat("   AND IdEstadoCheque = '{0}'", Entidades.Cheque.Estados.ENCARTERA.ToString())
      '   .AppendFormatLine("   AND FechaCobro >= '{0}'", ObtenerFecha(alDia.AddMonths(-1), True))
      '   .AppendLine("   AND FechaCobro < '" & alDia.ToString("yyyyMMdd") & " 23:59:59'")
      'End With

      With stb
         .AppendFormatLine("SELECT COUNT(idbanco) AS Cantidad")
         .AppendFormatLine(" FROM Cheques C")
         .AppendFormatLine(" WHERE EXISTS")
         .AppendFormatLine(" (SELECT * FROM CajasUsuarios CU")
         .AppendFormatLine("   WHERE CU.IdUsuario = '{0}' AND CU.IdCaja = C.IdCajaIngreso)", actual.Nombre)
         .AppendFormatLine("   AND C.idSucursal = {0}", actual.Sucursal.Id)
         .AppendFormatLine("   AND C.IdEstadoCheque = '{0}'", Entidades.Cheque.Estados.ENCARTERA.ToString())
         .AppendFormatLine("   AND C.FechaCobro >= '{0}'", ObtenerFecha(alDia.AddMonths(-1), True))
         .AppendFormatLine("   AND C.FechaCobro <= '{0}'", ObtenerFecha(UltimoSegundoDelDia(alDia), True))
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("Cantidad").ToString())
      Else
         Return 0
      End If

   End Function
   Public Function GetCantidadProximoAPagar(idSucursal As Integer, fechaHoraDesde As DateTime, fechaHoraHasta As DateTime) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT COUNT(idbanco) AS Cantidad")
         .AppendFormatLine("  FROM Cheques C")
         .AppendFormatLine("   INNER JOIN LibrosBancos LB ON LB.IdCheque = C.IdCheque")
         .AppendFormatLine(" WHERE C.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND EsPropio = 'True'")
         .AppendFormatLine("   AND IdEstadoCheque = '{0}'", Entidades.Cheque.Estados.PROVEEDOR.ToString())
         .AppendFormatLine("   AND FechaCobro  >= '{0}'", Me.ObtenerFecha(fechaHoraDesde, True))
         .AppendFormatLine("   AND FechaCobro  <= '{0}'", Me.ObtenerFecha(fechaHoraHasta, True))
         .AppendFormatLine("   AND LB.Conciliado = 0")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
   Public Function GetChequesADepositar(idSucursal As Integer, alDia As DateTime) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT CH.Importe, ")
         .AppendLine("	CH.FechaCobro [Fecha],")
         .AppendLine("	B.NombreBanco [Banco],")
         .AppendLine("	L.NombreLocalidad [Localidad],")
         .AppendLine("	CH.NumeroCheque [Numero],")
         .AppendLine("	CL.NombreCliente [Cliente]")
         .AppendLine(" FROM Cheques CH")
         .AppendLine(" LEFT JOIN Clientes CL ON CH.IdCliente = CL.IdCliente")
         .AppendLine(" LEFT JOIN Bancos B ON B.IdBanco = CH.IdBanco")
         .AppendLine(" LEFT JOIN Localidades L ON L.IdLocalidad = CH.IdLocalidad")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdEstadoCheque = '{0}'", Entidades.Cheque.Estados.ENCARTERA.ToString())
         .AppendLine("   AND FechaCobro < '" & alDia.ToString("yyyyMMdd") & " 23:59:59'")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function Cheques_GetUltimoEmitido(IdCuentaBancaria As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT MAX(NumeroCheque) AS maximo ")
         .AppendLine(" FROM Cheques")
         .AppendLine(" WHERE EsPropio = 1")        'Por las dudas, no haria falta.
         .AppendLine("   AND IdCuentaBancaria = " & IdCuentaBancaria.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function Existe(idSucursal As Integer,
                            numeroCheque As Integer,
                            idBanco As Integer,
                            IdBancoSucursal As Integer,
                            IdLocalidad As Integer,
                          cuit As String) As Boolean

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT idSucursal FROM Cheques")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND NumeroCheque = " & numeroCheque.ToString())
         .AppendLine("   AND IdBanco = " & idBanco.ToString())
         .AppendLine("   AND IdBancoSucursal = " & IdBancoSucursal.ToString())
         .AppendLine("   AND IdLocalidad = " & IdLocalidad.ToString())
         .AppendFormatLine("   AND Cuit = '{0}'", cuit)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      Return (dt.Rows.Count > 0)

   End Function

   Public Function GetSaldoCheqPropio(fechaCobroDesde As DateTime,
                                        fechaCobroHasta As DateTime,
                                        suc As List(Of Integer),
                                        esPropio As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      With stb

         .AppendLine("SELECT C.IdCuentaBancaria ")
         .AppendLine(" ,CB.NombreCuenta ")
         .AppendLine(" ,S.Nombre ")
         .AppendLine(" ,SUM(C.Importe) AS Saldo")
         .AppendLine(" FROM Cheques C")
         .AppendLine(" LEFT OUTER JOIN CuentasBancarias CB ON C.IdCuentaBancaria = CB.IdCuentaBancaria")
         .AppendLine("  INNER JOIN Sucursales S on S.IdSucursal = C.IdSucursal ")
         .AppendLine("	WHERE C.FechaCobro >= '" & fechaCobroDesde.ToString("yyyyMMdd") & " 00:00:00'")
         .AppendLine("	  AND C.FechaCobro <= '" & fechaCobroHasta.ToString("yyyyMMdd") & " 23:59:59'")
         .AppendLine(" AND C.EsPropio = 'True' ")
         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat(" AND C.IdSucursal = 0")
         Else
            .AppendFormat(" AND C.IdSucursal IN ({0})", sucur)
         End If
         .AppendLine(" GROUP BY C.IdCuentaBancaria ,CB.NombreCuenta ,S.Nombre")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetInfCheques(idSucursal As Integer,
                                  esPropio As Boolean?) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT C.NumeroCheque")
         .AppendLine("      ,C.IdBanco")
         .AppendLine("      ,B.NombreBanco")
         .AppendLine("      ,C.IdBancoSucursal")
         .AppendLine("      ,C.FechaEmision")
         .AppendLine("      ,C.FechaCobro")
         .AppendLine("      ,C.Titular")
         .AppendLine("      ,C.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad Localidad")
         If esPropio.HasValue Then
            .AppendLine("      ,C.Importe")
         Else
            .AppendLine("      ,C.Importe * CASE WHEN C.EsPropio = 1 THEN -1 ELSE 1 END AS Importe")
         End If
         '.AppendLine("      ,C.NroPlanillaIngreso")
         '.AppendLine("      ,C.NroMovimientoIngreso")
         '.AppendLine("      ,C.NroPlanillaEgreso")
         '.AppendLine("      ,C.NroMovimientoEgreso")
         '.AppendLine("      ,C.Cuit")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.IdTipoCheque")
         .AppendLine("      ,C.NroOperacion")
         .AppendLine("      ,CL.CodigoCliente")
         .AppendLine("      ,CL.NombreCliente")
         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,C.IdChequera")
         .AppendLine("      ,PV.CodigoProveedor")
         .AppendLine("      ,PV.NombreProveedor")

         .AppendLine("  FROM Cheques C")
         .AppendLine(" INNER JOIN Bancos B ON C.IdBanco = B.IdBanco ")
         .AppendLine(" INNER JOIN Localidades L On C.IdLocalidad = L.IdLocalidad ")
         .AppendLine("  LEFT JOIN Clientes CL ON CL.IdCliente = C.IdCliente")
         .AppendLine("  LEFT JOIN Proveedores PV ON PV.IdProveedor = C.IdProveedor")

         .AppendLine("   WHERE C.IdSucursal = " & idSucursal.ToString())
         If esPropio.HasValue Then
            .AppendLine("   AND C.EsPropio = " & GetStringFromBoolean(esPropio.Value))
         End If
         .AppendLine("   AND (C.EsPropio = 1 OR C.IdEstadoCheque = '" & Entidades.Cheque.Estados.ENCARTERA.ToString() & "')")
      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetSaldoChequesEnCartera(IdSucursal As Integer,
                                              IdCaja As Integer) As Decimal

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT SUM(Importe) AS Saldo FROM Cheques")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND IdCajaIngreso = " & IdCaja.ToString())
         .AppendLine("   AND IdEstadoCheque = 'ENCARTERA'")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Saldo").ToString()) Then
            Return Decimal.Parse(dt.Rows(0)("Saldo").ToString())
         End If
      End If

      Return 0

   End Function

   Public Sub GrabarFotoFrente(imagen As System.Drawing.Image, idSucursal As Integer,
                        idBanco As Integer,
                        idBancoSucursal As Integer,
                        idLocalidad As Integer,
                        numeroCheque As Integer,
                               idCheque As Long)

      If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If

      Dim path As String = Entidades.Publicos.DriverBase + "Eniac\" + idSucursal.ToString() +
          "-" + idBanco.ToString() + "-" + idBancoSucursal.ToString() + "-" + idLocalidad.ToString() + "-" +
          numeroCheque.ToString() + "Frente" + ".jpg"

      Dim stbQuery As StringBuilder = New StringBuilder("")

      If imagen IsNot Nothing Then
         imagen.Save(path)

         Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(foto, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .Append(" UPDATE Cheques ")
            .Append(" SET FotoFrente = ")
            .Append(" @Foto ")
            .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
         End With

         Me._da.Command.CommandText = stbQuery.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Foto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = foto.Length
         oParameter.Value = foto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      Else
         With stbQuery
            .Append(" UPDATE Cheques ")
            .Append(" SET FotoFrente = ")
            .Append(" null ")
            .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
         End With

         Me.Execute(stbQuery.ToString())
      End If

   End Sub

   Public Sub GrabarFotoDorso(imagen As System.Drawing.Image, idSucursal As Integer,
                      idBanco As Integer,
                      idBancoSucursal As Integer,
                      idLocalidad As Integer,
                      numeroCheque As Integer,
                              idCheque As Long)

      If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If

      Dim path As String = Entidades.Publicos.DriverBase + "Eniac\" + idSucursal.ToString() +
          "-" + idBanco.ToString() + "-" + idBancoSucursal.ToString() + "-" + idLocalidad.ToString() + "-" +
          numeroCheque.ToString() + "Dorso" + ".jpg"

      Dim stbQuery As StringBuilder = New StringBuilder("")

      If imagen IsNot Nothing Then
         imagen.Save(path)

         Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         Dim foto1(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(foto1, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .Append(" UPDATE Cheques ")
            .Append(" SET FotoDorso = ")
            .Append(" @Foto1 ")
            .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
         End With

         Me._da.Command.CommandText = stbQuery.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Foto1"
         oParameter.DbType = DbType.Binary
         oParameter.Size = foto1.Length
         oParameter.Value = foto1
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      Else
         With stbQuery
            .Append(" UPDATE Cheques ")
            .Append(" SET FotoDorso = ")
            .Append(" null ")
            .AppendFormatLine(" WHERE IdCheque = {0}", idCheque)
         End With

         Me.Execute(stbQuery.ToString())
      End If

   End Sub

   Public Function GetChequesDeMovimiento(idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer, esPropio As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT C.IdCheque")
         .AppendFormatLine("     , C.NumeroCheque")
         .AppendFormatLine("     , C.IdBanco")
         .AppendFormatLine("     , B.NombreBanco")
         .AppendFormatLine("     , C.IdBancoSucursal")
         .AppendFormatLine("     , C.IdLocalidad")
         .AppendFormatLine("     , L.NombreLocalidad")
         .AppendFormatLine("     , C.FechaEmision")
         .AppendFormatLine("     , C.FechaCobro")
         .AppendFormatLine("     , C.Importe")
         .AppendFormatLine("     , C.Titular")
         .AppendFormatLine("     , C.NroPlanillaIngreso")
         .AppendFormatLine("     , C.NroMovimientoIngreso")
         .AppendFormatLine("     , C.NroPlanillaEgreso")
         .AppendFormatLine("     , C.CUIT")
         .AppendFormatLine("     , C.NroMovimientoEgreso")
         .AppendFormatLine(" FROM Cheques C")
         .AppendFormatLine(" INNER JOIN Bancos B On C.IdBanco = B.IdBanco ")
         .AppendFormatLine(" INNER JOIN Localidades L On C.IdLocalidad = L.IdLocalidad")

         .AppendFormatLine("  WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("    AND C.EsPropio = {0}", GetStringFromBoolean(esPropio))
         .AppendFormatLine("    AND ((C.IdCajaIngreso = {0} AND C.NroPlanillaIngreso = {1} AND C.NroMovimientoIngreso = {2}) OR ", idCaja, nroPlanilla, nroMovimiento)
         .AppendFormatLine("         (C.IdCajaEgreso  = {0} AND C.NroPlanillaEgreso  = {1} AND C.NroMovimientoEgreso  = {2}))", idCaja, nroPlanilla, nroMovimiento)
      End With
      Return GetDataTable(stbQuery)
   End Function


End Class