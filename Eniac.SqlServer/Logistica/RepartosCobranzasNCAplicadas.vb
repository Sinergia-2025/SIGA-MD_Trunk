Public Class RepartosCobranzasNCAplicadas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RepartosCobranzasNCAplicadas_I(idSucursal As Integer,
                                             idReparto As Integer,
                                             idCobranza As Integer,
                                             idSucursalComp As Integer,
                                             idTipoComprobanteComp As String,
                                             letraComp As String,
                                             centroEmisorComp As Short,
                                             numeroComprobanteComp As Long,
                                             idSucursalNC As Integer,
                                             idTipoComprobanteNC As String,
                                             letraNC As String,
                                             centroEmisorNC As Short,
                                             numeroComprobanteNC As Long,
                                             saldoComprobante As Decimal,
                                             importeAplicado As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.RepartoCobranzaNCAplicada.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursal.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.IdReparto.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.IdCobranza.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.LetraComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalNC.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteNC.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.LetraNC.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorNC.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteNC.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.SaldoComprobante.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaNCAplicada.Columnas.ImporteAplicado.ToString())

         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          , {0} ", idReparto)
         .AppendFormatLine("          , {0} ", idCobranza)
         .AppendFormatLine("          , {0} ", idSucursalComp)
         .AppendFormatLine("          ,'{0}'", idTipoComprobanteComp)
         .AppendFormatLine("          ,'{0}'", letraComp)
         .AppendFormatLine("          , {0} ", centroEmisorComp)
         .AppendFormatLine("          , {0} ", numeroComprobanteComp)
         .AppendFormatLine("          , {0} ", idSucursalNC)
         .AppendFormatLine("          ,'{0}'", idTipoComprobanteNC)
         .AppendFormatLine("          ,'{0}'", letraNC)
         .AppendFormatLine("          , {0} ", centroEmisorNC)
         .AppendFormatLine("          , {0} ", numeroComprobanteNC)
         .AppendFormatLine("          , {0} ", saldoComprobante)
         .AppendFormatLine("          , {0} ", importeAplicado)

         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosCobranzasNCAplicadas_U(idSucursal As Integer,
                                             idReparto As Integer,
                                             idCobranza As Integer,
                                             idSucursalComp As Integer,
                                             idTipoComprobanteComp As String,
                                             letraComp As String,
                                             centroEmisorComp As Short,
                                             numeroComprobanteComp As Long,
                                             idSucursalNC As Integer,
                                             idTipoComprobanteNC As String,
                                             letraNC As String,
                                             centroEmisorNC As Short,
                                             numeroComprobanteNC As Long,
                                             saldoComprobante As Decimal,
                                             importeAplicado As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.RepartoCobranzaNCAplicada.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.SaldoComprobante.ToString(), saldoComprobante)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.ImporteAplicado.ToString(), importeAplicado)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdCobranza.ToString(), idCobranza)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.LetraComp.ToString(), letraComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalNC.ToString(), idSucursalNC)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteNC.ToString(), idTipoComprobanteNC)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.LetraNC.ToString(), letraNC)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorNC.ToString(), centroEmisorNC)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteNC.ToString(), numeroComprobanteNC)

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosCobranzasNCAplicadas_D(idSucursal As Integer,
                                             idReparto As Integer,
                                             idCobranza As Integer,
                                             idSucursalComp As Integer,
                                             idTipoComprobanteComp As String,
                                             letraComp As String,
                                             centroEmisorComp As Short,
                                             numeroComprobanteComp As Long,
                                             idSucursalNC As Integer,
                                             idTipoComprobanteNC As String,
                                             letraNC As String,
                                             centroEmisorNC As Short,
                                             numeroComprobanteNC As Long)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.RepartoCobranzaNCAplicada.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdCobranza.ToString(), idCobranza)

         If idSucursalComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteComp) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(letraComp) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.LetraComp.ToString(), letraComp)
         End If
         If centroEmisorComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         End If
         If numeroComprobanteComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         End If

         If idSucursalNC <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalNC.ToString(), idSucursalNC)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteNC) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteNC.ToString(), idTipoComprobanteNC)
         End If
         If Not String.IsNullOrWhiteSpace(letraNC) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.LetraNC.ToString(), letraNC)
         End If
         If centroEmisorNC <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorNC.ToString(), centroEmisorNC)
         End If
         If numeroComprobanteNC <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteNC.ToString(), numeroComprobanteNC)
         End If

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RBNC.*")
         .AppendFormatLine("  FROM {0} AS RBNC", Entidades.RepartoCobranzaNCAplicada.NombreTabla)
      End With
   End Sub

   Public Function RepartosCobranzasNCAplicadas_GA() As DataTable
      Return RepartosCobranzasNCAplicadas_G(idSucursal:=0, idReparto:=0, idCobranza:=0,
                                            idSucursalComp:=0, idTipoComprobanteComp:=String.Empty, letraComp:=String.Empty, centroEmisorComp:=0, numeroComprobanteComp:=0,
                                            idSucursalNC:=0, idTipoComprobanteNC:=String.Empty, letraNC:=String.Empty, centroEmisorNC:=0, numeroComprobanteNC:=0)
   End Function
   Public Function RepartosCobranzasNCAplicadas_GA(idSucursal As Integer, idReparto As Integer, idCobranza As Integer,
                                                   idSucursalComp As Integer, idTipoComprobanteComp As String, letraComp As String, centroEmisorComp As Short, numeroComprobanteComp As Long) As DataTable
      Return RepartosCobranzasNCAplicadas_G(idSucursal, idReparto, idCobranza,
                                            idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp,
                                            idSucursalNC:=0, idTipoComprobanteNC:=String.Empty, letraNC:=String.Empty, centroEmisorNC:=0, numeroComprobanteNC:=0)
   End Function
   Private Function RepartosCobranzasNCAplicadas_G(idSucursal As Integer,
                                                   idReparto As Integer,
                                                   idCobranza As Integer,
                                                   idSucursalComp As Integer,
                                                   idTipoComprobanteComp As String,
                                                   letraComp As String,
                                                   centroEmisorComp As Short,
                                                   numeroComprobanteComp As Long,
                                                   idSucursalNC As Integer,
                                                   idTipoComprobanteNC As String,
                                                   letraNC As String,
                                                   centroEmisorNC As Short,
                                                   numeroComprobanteNC As Long) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdReparto.ToString(), idReparto)
         End If
         If idCobranza <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdCobranza.ToString(), idCobranza)
         End If

         If idSucursalComp <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteComp) Then
            .AppendFormatLine("   AND RBNC.{0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(letraComp) Then
            .AppendFormatLine("   AND RBNC.{0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.LetraComp.ToString(), letraComp)
         End If
         If centroEmisorComp <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         End If
         If numeroComprobanteComp <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         End If

         If idSucursalNC <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalNC.ToString(), idSucursalNC)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteNC) Then
            .AppendFormatLine("   AND RBNC.{0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteNC.ToString(), idTipoComprobanteNC)
         End If
         If Not String.IsNullOrWhiteSpace(letraNC) Then
            .AppendFormatLine("   AND RBNC.{0} = '{1}'", Entidades.RepartoCobranzaNCAplicada.Columnas.LetraNC.ToString(), letraNC)
         End If
         If centroEmisorNC <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorNC.ToString(), centroEmisorNC)
         End If
         If numeroComprobanteNC <> 0 Then
            .AppendFormatLine("   AND RBNC.{0} =  {1} ", Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteNC.ToString(), numeroComprobanteNC)
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function RepartosCobranzasNCAplicadas_G1(idSucursal As Integer,
                                                   idReparto As Integer,
                                                   idCobranza As Integer,
                                                   idSucursalComp As Integer,
                                                   idTipoComprobanteComp As String,
                                                   letraComp As String,
                                                   centroEmisorComp As Short,
                                                   numeroComprobanteComp As Long,
                                                   idSucursalNC As Integer,
                                                   idTipoComprobanteNC As String,
                                                   letraNC As String,
                                                   centroEmisorNC As Short,
                                                   numeroComprobanteNC As Long) As DataTable
      Return RepartosCobranzasNCAplicadas_G(idSucursal, idReparto, idCobranza,
                                            idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp,
                                            idSucursalNC, idTipoComprobanteNC, letraNC, centroEmisorNC, numeroComprobanteNC)
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
      columna = "RBNC." + columna
      ''End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class