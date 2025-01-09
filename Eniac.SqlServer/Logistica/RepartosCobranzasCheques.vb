Public Class RepartosCobranzasCheques
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RepartosCobranzasCheques_I(idSucursal As Integer,
                                         idReparto As Integer,
                                         idCobranza As Integer,
                                         idSucursalComp As Integer,
                                         idTipoComprobanteComp As String,
                                         letraComp As String,
                                         centroEmisorComp As Short,
                                         numeroComprobanteComp As Long,
                                         idBanco As Integer,
                                         idBancoSucursal As Integer,
                                         idLocalidad As Integer,
                                         numeroCheque As Integer,
                                         nroOperacion As String,
                                         idTipoCheque As String,
                                         fechaEmision As DateTime,
                                         fechaCobro As DateTime,
                                         titular As String,
                                         importe As Decimal,
                                         cuit As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.RepartoCobranzaCheque.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.RepartoCobranzaCheque.Columnas.IdSucursal.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.IdReparto.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.IdCobranza.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.IdSucursalComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.IdTipoComprobanteComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.LetraComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.CentroEmisorComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.NumeroComprobanteComp.ToString())

         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.IdBanco.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.IdBancoSucursal.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.IdLocalidad.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.NumeroCheque.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.NroOperacion.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.IdTipoCheque.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.FechaEmision.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.FechaCobro.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.Titular.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.Importe.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaCheque.Columnas.Cuit.ToString())


         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          , {0} ", idReparto)
         .AppendFormatLine("          , {0} ", idCobranza)
         .AppendFormatLine("          , {0} ", idSucursalComp)
         .AppendFormatLine("          ,'{0}'", idTipoComprobanteComp)
         .AppendFormatLine("          ,'{0}'", letraComp)
         .AppendFormatLine("          , {0} ", centroEmisorComp)
         .AppendFormatLine("          , {0} ", numeroComprobanteComp)

         .AppendFormatLine("          , {0} ", idBanco)
         .AppendFormatLine("          , {0} ", idBancoSucursal)
         .AppendFormatLine("          , {0} ", idLocalidad)
         .AppendFormatLine("          , {0} ", numeroCheque)
         .AppendFormatLine("          ,'{0}'", nroOperacion)
         .AppendFormatLine("          ,'{0}'", idTipoCheque)
         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaEmision, True))
         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaCobro, True))
         .AppendFormatLine("          ,'{0}'", titular)
         .AppendFormatLine("          , {0} ", importe)
         .AppendFormatLine("          , {0} ", cuit)

         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosCobranzasCheques_U(idSucursal As Integer,
                                         idReparto As Integer,
                                         idCobranza As Integer,
                                         idSucursalComp As Integer,
                                         idTipoComprobanteComp As String,
                                         letraComp As String,
                                         centroEmisorComp As Short,
                                         numeroComprobanteComp As Long,
                                         idBanco As Integer,
                                         idBancoSucursal As Integer,
                                         idLocalidad As Integer,
                                         numeroCheque As Integer,
                                         nroOperacion As String,
                                         idTipoCheque As String,
                                         fechaEmision As DateTime,
                                         fechaCobro As DateTime,
                                         titular As String,
                                         importe As Decimal,
                                         cuit As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.RepartoCobranzaCheque.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.IdTipoCheque.ToString(), idTipoCheque)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.NroOperacion.ToString(), nroOperacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.FechaEmision.ToString(), ObtenerFecha(fechaEmision, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.FechaCobro.ToString(), ObtenerFecha(fechaCobro, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.Titular.ToString(), titular)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.Importe.ToString(), importe)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.Cuit.ToString(), cuit)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdCobranza.ToString(), idCobranza)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.LetraComp.ToString(), letraComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdBanco.ToString(), idBanco)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdBancoSucursal.ToString(), idBancoSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdLocalidad.ToString(), idLocalidad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.NumeroCheque.ToString(), numeroCheque)

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosCobranzasCheques_D(idSucursal As Integer,
                                         idReparto As Integer,
                                         idCobranza As Integer,
                                         idSucursalComp As Integer,
                                         idTipoComprobanteComp As String,
                                         letraComp As String,
                                         centroEmisorComp As Short,
                                         numeroComprobanteComp As Long,
                                         idBanco As Integer,
                                         idBancoSucursal As Integer,
                                         idLocalidad As Integer,
                                         numeroCheque As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.RepartoCobranzaCheque.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdCobranza.ToString(), idCobranza)

         If idSucursalComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteComp) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(letraComp) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.LetraComp.ToString(), letraComp)
         End If
         If centroEmisorComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         End If
         If numeroComprobanteComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         End If
         If idBanco <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdBanco.ToString(), idBanco)
         End If
         If idBancoSucursal <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdBancoSucursal.ToString(), idBancoSucursal)
         End If
         If idLocalidad <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdLocalidad.ToString(), idLocalidad)
         End If
         If numeroCheque <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.NumeroCheque.ToString(), numeroCheque)
         End If

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RBCH.*")
         .AppendFormatLine("  FROM {0} AS RBCH", Entidades.RepartoCobranzaCheque.NombreTabla)
      End With
   End Sub

   Public Function RepartosCobranzasCheques_GA() As DataTable
      Return RepartosCobranzasCheques_G(idSucursal:=0, idReparto:=0, idCobranza:=0, idSucursalComp:=0, idTipoComprobanteComp:=String.Empty, letraComp:=String.Empty, centroEmisorComp:=0, numeroComprobanteComp:=0, idBanco:=0, idBancoSucursal:=0, idLocalidad:=0, numeroCheque:=0, cuit:=Nothing)
   End Function
   Public Function RepartosCobranzasCheques_GA(idSucursal As Integer, idReparto As Integer, idCobranza As Integer,
                                               idSucursalComp As Integer, idTipoComprobanteComp As String, letraComp As String, centroEmisorComp As Short, numeroComprobanteComp As Long) As DataTable
      Return RepartosCobranzasCheques_G(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp, idBanco:=0, idBancoSucursal:=0, idLocalidad:=0, numeroCheque:=0, cuit:=Nothing)
   End Function
   Private Function RepartosCobranzasCheques_G(idSucursal As Integer,
                                               idReparto As Integer,
                                               idCobranza As Integer,
                                               idSucursalComp As Integer,
                                               idTipoComprobanteComp As String,
                                               letraComp As String,
                                               centroEmisorComp As Short,
                                               numeroComprobanteComp As Long,
                                               idBanco As Integer,
                                               idBancoSucursal As Integer,
                                               idLocalidad As Integer,
                                               numeroCheque As Integer,
                                               cuit As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdReparto.ToString(), idReparto)
         End If
         If idCobranza <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdCobranza.ToString(), idCobranza)
         End If

         If idSucursalComp <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteComp) Then
            .AppendFormatLine("   AND RBCH.{0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(letraComp) Then
            .AppendFormatLine("   AND RBCH.{0} = '{1}'", Entidades.RepartoCobranzaCheque.Columnas.LetraComp.ToString(), letraComp)
         End If
         If centroEmisorComp <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         End If
         If numeroComprobanteComp <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         End If
         If idBanco <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdBanco.ToString(), idBanco)
         End If
         If idBancoSucursal <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdBancoSucursal.ToString(), idBancoSucursal)
         End If
         If idLocalidad <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.IdLocalidad.ToString(), idLocalidad)
         End If
         If numeroCheque <> 0 Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.NumeroCheque.ToString(), numeroCheque)
         End If
         If Not String.IsNullOrEmpty(cuit) Then
            .AppendFormatLine("   AND RBCH.{0} =  {1} ", Entidades.RepartoCobranzaCheque.Columnas.Cuit.ToString(), cuit)
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function RepartosCobranzasCheques_G1(idSucursal As Integer,
                                               idReparto As Integer,
                                               idCobranza As Integer,
                                               idSucursalComp As Integer,
                                               idTipoComprobanteComp As String,
                                               letraComp As String,
                                               centroEmisorComp As Short,
                                               numeroComprobanteComp As Long,
                                               idBanco As Integer,
                                               idBancoSucursal As Integer,
                                               idLocalidad As Integer,
                                               numeroCheque As Integer,
                                               cuit As String) As DataTable
      Return RepartosCobranzasCheques_G(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp, idBanco, idBancoSucursal, idLocalidad, numeroCheque, cuit)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      'If columna = "NombreTipoNovedad" Then
      '   columna = "TN." + columna
      'ElseIf columna = "PorDefecto_SN" Then
      '   columna = "CASE WHEN TCN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
      'ElseIf columna = "VisibleParaCliente_SN" Then
      '   columna = "CASE WHEN TCN.VisibleParaCliente = 0 THEN 'NO' ELSE 'SI' END"
      'ElseIf columna = "VisibleParaRepresentante_SN" Then
      '   columna = "CASE WHEN TCN.VisibleParaRepresentante = 0 THEN 'NO' ELSE 'SI' END"
      'Else
      columna = "RBCH." + columna
      ''End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class