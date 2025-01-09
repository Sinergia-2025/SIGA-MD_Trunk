Public Class RepartosCobranzasProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RepartosCobranzasProductos_I(idSucursal As Integer,
                                           idReparto As Integer,
                                           idCobranza As Integer,
                                           idSucursalComp As Integer,
                                           idTipoComprobanteComp As String,
                                           letraComp As String,
                                           centroEmisorComp As Short,
                                           numeroComprobanteComp As Long,
                                           idProducto As String,
                                           orden As Integer,
                                           cantidadDevuelta As Decimal,
                                           idEstadoVenta As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.RepartoCobranzaProducto.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.RepartoCobranzaProducto.Columnas.IdSucursal.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.IdReparto.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.IdCobranza.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.IdSucursalComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.IdTipoComprobanteComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.LetraComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.CentroEmisorComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.NumeroComprobanteComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.Orden.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.CantidadDevuelta.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaProducto.Columnas.IdEstadoVenta.ToString())

         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          , {0} ", idReparto)
         .AppendFormatLine("          , {0} ", idCobranza)
         .AppendFormatLine("          , {0} ", idSucursalComp)
         .AppendFormatLine("          ,'{0}'", idTipoComprobanteComp)
         .AppendFormatLine("          ,'{0}'", letraComp)
         .AppendFormatLine("          , {0} ", centroEmisorComp)
         .AppendFormatLine("          , {0} ", numeroComprobanteComp)
         .AppendFormatLine("          ,'{0}'", idProducto)
         .AppendFormatLine("          , {0} ", orden)
         .AppendFormatLine("          , {0} ", cantidadDevuelta)
         .AppendFormatLine("          , {0} ", idEstadoVenta)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosCobranzasProductos_U(idSucursal As Integer,
                                           idReparto As Integer,
                                           idCobranza As Integer,
                                           idSucursalComp As Integer,
                                           idTipoComprobanteComp As String,
                                           letraComp As String,
                                           centroEmisorComp As Short,
                                           numeroComprobanteComp As Long,
                                           idProducto As String,
                                           orden As Integer,
                                           cantidadDevuelta As Decimal,
                                           idEstadoVenta As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.RepartoCobranzaProducto.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.CantidadDevuelta.ToString(), cantidadDevuelta)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdEstadoVenta.ToString(), idEstadoVenta)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdCobranza.ToString(), idCobranza)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.LetraComp.ToString(), letraComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.Orden.ToString(), orden)

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosCobranzasProductos_D(idSucursal As Integer,
                                           idReparto As Integer,
                                           idCobranza As Integer,
                                           idSucursalComp As Integer,
                                           idTipoComprobanteComp As String,
                                           letraComp As String,
                                           centroEmisorComp As Short,
                                           numeroComprobanteComp As Long,
                                           idProducto As String,
                                           orden As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.RepartoCobranzaProducto.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdCobranza.ToString(), idCobranza)

         If idSucursalComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteComp) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(letraComp) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.LetraComp.ToString(), letraComp)
         End If
         If centroEmisorComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         End If
         If numeroComprobanteComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.Orden.ToString(), orden)
         End If

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RBP.*, EV.{0}", Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString())
         .AppendFormatLine("  FROM {0} AS RBP", Entidades.RepartoCobranzaProducto.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} EV ON EV.{1} = RBP.{2}", Entidades.EstadoVenta.NombreTabla, Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString(), Entidades.RepartoCobranzaProducto.Columnas.IdEstadoVenta.ToString())
      End With
   End Sub

   Public Function RepartosCobranzasProductos_GA() As DataTable
      Return RepartosCobranzasProductos_G(idSucursal:=0, idReparto:=0, idCobranza:=0, idSucursalComp:=0, idTipoComprobanteComp:=String.Empty, letraComp:=String.Empty, centroEmisorComp:=0, numeroComprobanteComp:=0, idProducto:=String.Empty, orden:=0)
   End Function
   Public Function RepartosCobranzasProductos_GA(idSucursal As Integer, idReparto As Integer, idCobranza As Integer,
                                                 idSucursalComp As Integer, idTipoComprobanteComp As String, letraComp As String, centroEmisorComp As Short, numeroComprobanteComp As Long) As DataTable
      Return RepartosCobranzasProductos_G(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp, idProducto:=String.Empty, orden:=0)
   End Function
   Private Function RepartosCobranzasProductos_G(idSucursal As Integer,
                                                 idReparto As Integer,
                                                 idCobranza As Integer,
                                                 idSucursalComp As Integer,
                                                 idTipoComprobanteComp As String,
                                                 letraComp As String,
                                                 centroEmisorComp As Short,
                                                 numeroComprobanteComp As Long,
                                                 idProducto As String,
                                                 orden As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal <> 0 Then
            .AppendFormatLine("   AND RBP.{0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND RBP.{0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdReparto.ToString(), idReparto)
         End If
         If idCobranza <> 0 Then
            .AppendFormatLine("   AND RBP.{0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdCobranza.ToString(), idCobranza)
         End If

         If idSucursalComp <> 0 Then
            .AppendFormatLine("   AND RBP.{0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteComp) Then
            .AppendFormatLine("   AND RBP.{0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(letraComp) Then
            .AppendFormatLine("   AND RBP.{0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.LetraComp.ToString(), letraComp)
         End If
         If centroEmisorComp <> 0 Then
            .AppendFormatLine("   AND RBP.{0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         End If
         If numeroComprobanteComp <> 0 Then
            .AppendFormatLine("   AND RBP.{0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND RBP.{0} = '{1}'", Entidades.RepartoCobranzaProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND RBP.{0} =  {1} ", Entidades.RepartoCobranzaProducto.Columnas.Orden.ToString(), orden)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function RepartosCobranzasProductos_G1(idSucursal As Integer,
                                                 idReparto As Integer,
                                                 idCobranza As Integer,
                                                 idSucursalComp As Integer,
                                                 idTipoComprobanteComp As String,
                                                 letraComp As String,
                                                 centroEmisorComp As Short,
                                                 numeroComprobanteComp As Long,
                                                 idProducto As String,
                                                 orden As Integer) As DataTable
      Return RepartosCobranzasProductos_G(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp, idProducto, orden)
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
      columna = "RBP." + columna
      ''End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class