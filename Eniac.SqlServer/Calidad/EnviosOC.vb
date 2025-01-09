Option Explicit On
Option Strict On
Public Class EnviosOC
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EnviosOC_I(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     FechaEnvio As DateTime,
                                     IdUsuario As String,
                                     metodoGrabacion As String,
                                     idFuncion As String,
                                     FechaReprogramacion As DateTime)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO CalidadEnviosOC ")
         .AppendLine("   (IdSucursal")
         .AppendLine("   ,IdTipoComprobante")
         .AppendLine("   ,Letra")
         .AppendLine("   ,CentroEmisor")
         .AppendLine("   ,NumeroPedido")
         .AppendLine("   ,FechaEnvio")
         .AppendLine("   ,IdUsuario")
         .AppendLine("   ,metodoGrabacion")
         .AppendLine("   ,idFuncion")
         .AppendLine("   ,FechaReprogramacion")

         .AppendLine(") VALUES ")
         .AppendFormat("  ({0}", idSucursal).AppendLine()
         .AppendFormat(" ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat(" ,'{0}'", letra).AppendLine()
         .AppendFormat(" , {0}", centroEmisor).AppendLine()
         .AppendFormat(" , {0}", numeroPedido).AppendLine()
         .AppendFormat(" ,'{0}'", Me.ObtenerFecha(FechaEnvio, True)).AppendLine()
         .AppendFormat(" ,'{0}'", IdUsuario).AppendLine()
         .AppendFormat(" ,'{0}'", metodoGrabacion.ToString().Substring(0, 1))
         .AppendFormat(" ,'{0}'", idFuncion)
         If FechaReprogramacion <> Nothing Then
            .AppendFormat(" ,'{0}'", Me.ObtenerFecha(FechaReprogramacion, True)).AppendLine()
         Else
            .AppendLine(" , NULL")
         End If

         .AppendFormat(" )").AppendLine()
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadEnviosOC")
   End Sub

   Public Sub EnviosOC_U(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     FechaEnvio As DateTime,
                                     IdUsuario As String,
                                     metodoGrabacion As String,
                                     idFuncion As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         '.AppendFormat("UPDATE CalidadEnviosOC SET ").AppendLine()
         '.AppendFormat("  IdUsuario = '{0}'", IdUsuario).AppendLine()

         '.AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         '.AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         '.AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         '.AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         '.AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadOCActivaciones")
   End Sub

   Public Sub EnviosOC_D(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         '   .AppendLine("DELETE FROM CalidadOCActivaciones ")
         '   .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         '   .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         '   .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         '   .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         '   .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()

      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadOCActivaciones")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT OCE.* ").AppendLine()
         .AppendFormat("  FROM CalidadEnviosOC AS OCE ").AppendLine()

      End With
   End Sub

   Public Function EnviosOC_GA(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroPedido As Long) As DataTable
      Return EnviosOC_G(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    numeroPedido)
   End Function
   Private Function EnviosOC_G(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND OCE.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND OCE.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND OCE.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND OCE.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND OCE.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If

         .AppendLine(" ORDER BY OCE.FechaEnvio DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function EnviosOC_G1(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroPedido As Long,
                                           FechaEnvio As DateTime) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND OCE.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND OCE.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND OCE.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND OCE.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND OCE.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If
         If FechaEnvio <> Nothing Then
            .AppendFormat("   AND OCE.FechaEnvio = '{0}'", FechaEnvio).AppendLine()
         End If

         .AppendLine(" ORDER BY OCE.FechaEnvio DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function EnviosOC_GFechareprog(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroPedido As Long) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND OCE.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND OCE.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND OCE.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND OCE.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND OCE.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If
         'If FechaEnvio <> Nothing Then
         '   .AppendFormat("   AND OCE.FechaEnvio = '{0}'", FechaEnvio).AppendLine()
         'End If

         .AppendLine(" ORDER BY OCE.FechaEnvio DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} = '{1}'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function EnviosOC_Informe(numeroPedido As Long,
                                          Envios As String,
                                          FechaDesde As Date,
                                          FechaHasta As Date,
                                          fechaDesdeEntrega As Date,
                                          fechaHastaEntrega As Date,
                                          fechaDesdeRepEntrega As Date,
                                          fechaHastaRepEntrega As Date,
                                          tipoTipoComprobante As String,
                                          tiposComprobante As Entidades.TipoComprobante(),
                                          IdProveedor As Long,
                                          IdUsuario As String,
                                          IdEstado As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("SELECT P.NombreProveedor,  P.CodigoProveedorLetras, CEO.*, PP.FechaAutorizacion
                        FROM CalidadEnviosOC AS CEO
                        INNER JOIN PedidosProveedores PP ON PP.IdSucursal = CEO.IdSucursal
                        AND PP.IdTipoComprobante = CEO.IdTipoComprobante
                        AND PP.Letra = CEO.Letra
                        AND PP.CentroEmisor = CEO.CentroEmisor
                        AND PP.NumeroPedido = CEO.NumeroPedido
                        LEFT JOIN Proveedores P ON P.IdProveedor = PP.IdProveedor
                        INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PP.IdTipoComprobante
                        LEFT JOIN PedidosProductosProveedores PPP ON PP.IdSucursal = PP.IdSucursal
                        AND PPP.IdTipoComprobante = PP.IdTipoComprobante
                        AND PPP.Letra = PP.Letra
                        AND PPP.CentroEmisor = PP.CentroEmisor
                        AND PPP.NumeroPedido = PP.NumeroPedido
                        AND PPP.Orden = 0
                        LEFT JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PPP.IdSucursal 
                        AND PE.IdTipoComprobante = PPP.IdTipoComprobante
                        AND PE.Letra = PPP.Letra
                        AND PE.CentroEmisor = PPP.CentroEmisor
                        AND PE.NumeroPedido = PPP.NumeroPedido
                        AND PE.IdProducto = PPP.IdProducto
                        AND PE.Orden = PPP.Orden")

         .AppendLine(" WHERE 1 = 1")

         If IdEstado <> "TODOS" Then
            .AppendLine("   AND EXISTS(SELECT * FROM PedidosEstadosProveedores PE")
            .AppendLine("                      LEFT JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado")
            .AppendLine("                      WHERE PE.IdSucursal = PP.IdSucursal")
            .AppendLine("                        AND PE.IdTipoComprobante = PP.IdTipoComprobante")
            .AppendLine("                        AND PE.Letra = PP.Letra")
            .AppendLine("                        AND PE.CentroEmisor = PP.CentroEmisor")
            .AppendLine("                        AND PE.NumeroPedido = PP.NumeroPedido")

            If IdEstado = "PENDIENTE/EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO'))")
            ElseIf IdEstado = "SOLO EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado = 'EN PROCESO')")
            Else
               .AppendFormat("                        AND EP.IdEstado = '{0}')", IdEstado).AppendLine()
            End If
         End If

         If Not String.IsNullOrWhiteSpace(IdUsuario) Then
            .AppendFormat("   AND CEO.IdUsuario = '{0}'", IdUsuario).AppendLine()
         End If

         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()
         GetListaTiposComprobantesMultiples(myQuery, tiposComprobante, "PP")

         If IdProveedor > 0 Then
            .AppendFormat("   AND PP.IdProveedor = {0}", IdProveedor).AppendLine()
         End If

         If numeroPedido > 0 Then
            .AppendFormat("   AND CEO.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If

         'If Activaciones <> "Todas" Then
         '   If Activaciones = "Cabecera" Then
         '      .AppendFormat("   AND OCA.Orden = 0").AppendLine()
         '   Else
         '      .AppendFormat("   AND OCA.Orden <> 0").AppendLine()
         '   End If
         'End If


         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND CEO.FechaEnvio >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND CEO.FechaEnvio <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If fechaDesdeEntrega > Date.Parse("01/01/1990") Then
            .AppendLine("   AND  ( SELECT TOP 1 PPP.FechaEntrega	FROM PedidosProductosProveedores PPP
           WHERE PPP.IdSucursal = PP.IdSucursal
           AND PPP.IdTipoComprobante = PP.IdTipoComprobante
           AND PPP.Letra = PP.Letra
           AND PPP.CentroEmisor = PP.CentroEmisor
           AND PPP.NumeroPedido = PP.NumeroPedido) >= '" & fechaDesdeEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND ( SELECT TOP 1 PPP.FechaEntrega	FROM PedidosProductosProveedores PPP
           WHERE PPP.IdSucursal = PP.IdSucursal
           AND PPP.IdTipoComprobante = PP.IdTipoComprobante
           AND PPP.Letra = PP.Letra
           AND PPP.CentroEmisor = PP.CentroEmisor
           AND PPP.NumeroPedido = PP.NumeroPedido) <= '" & fechaHastaEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If fechaDesdeRepEntrega > Date.Parse("01/01/1990") Then
            .AppendLine("   AND PP.FechaAutorizacion >= '" & fechaDesdeRepEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND PP.FechaAutorizacion <= '" & fechaHastaRepEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If Envios <> "TODOS" Then
            .AppendFormatLine(" AND CEO.MetodoGrabacion = '{0}' ", Envios)
         End If
         'If OrdenActivacion > 0 Then
         '   .AppendFormat("   AND OCA.OrdenActivacion = {0}", OrdenActivacion).AppendLine()
         'End If
         .AppendLine("  ORDER BY CEO.FechaEnvio, P.NombreProveedor ASC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


End Class