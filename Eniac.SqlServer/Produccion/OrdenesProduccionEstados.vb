Option Explicit On
Option Strict On
Public Class OrdenesProduccionEstados
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT PE.*, EP.IdTipoEstado")
         .AppendLine("      ,E.NombreEmpleado AS NombreResponsable")
         .AppendLine("      ,TC.Descripcion AS DescripcionTipoComprobante")
         .AppendLine("  FROM OrdenesProduccionEstados PE")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine("  LEFT JOIN Empleados E ON PE.IdResponsable = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN TiposComprobantes TC ON PE.IdTipoComprobante = TC.IdTipoComprobante ")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "PE." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub OrdenesProduccionEstados_D(IdSucursal As Integer,
                               IdTipoComprobante As String, Letra As String,
                               CentroEmisor As Integer, NumeroOrdenProduccion As Long,
                               Orden As Integer?, IdProducto As String,
                               FechaEstado As DateTime?,
                               Optional IdEstado As String = "")

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendFormat("DELETE FROM OrdenesProduccionEstados").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", IdSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", Letra)
         .AppendFormat("   AND CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("   AND NumeroOrdenProduccion = {0}", NumeroOrdenProduccion)
         If Orden.HasValue Then
            .AppendFormat("   AND Orden = {0}", Orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(IdProducto) Then
            .AppendFormat("   AND IdProducto = '{0}'", IdProducto)
         End If
         If FechaEstado.HasValue Then
            .AppendFormat("   AND FechaEstado = '{0}'", ObtenerFecha(FechaEstado.Value, True))
         End If
         If Not String.IsNullOrWhiteSpace(IdEstado) Then
            .AppendFormat("   AND IdEstado = '{0}'", IdEstado)
         End If
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Function OrdenesProduccionEstados_GA() As DataTable
      Return OrdenesProduccionEstados_G(Nothing, String.Empty, String.Empty, Nothing, Nothing, Nothing, String.Empty, Nothing, String.Empty)
   End Function

   Public Function OrdenesProduccionEstados_GA(IdSucursal As Integer,
                                     IdTipoComprobante As String, Letra As String,
                                     CentroEmisor As Integer, NumeroOrdenProduccion As Long,
                                     Optional idTipoEstado As String = "") As DataTable
      Return OrdenesProduccionEstados_G(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, Nothing, String.Empty, Nothing, idTipoEstado)
   End Function

   Public Function OrdenesProduccionEstados_GA(IdSucursal As Integer,
                                       IdTipoComprobante As String, Letra As String,
                                       CentroEmisor As Integer, NumeroOrdenProduccion As Long,
                                       Orden As Integer, IdProducto As String) As DataTable
      Return OrdenesProduccionEstados_G(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, Orden, IdProducto, Nothing, String.Empty)
   End Function

   Public Function OrdenesProduccionEstados_G1(IdSucursal As Integer,
                                       IdTipoComprobante As String, Letra As String,
                                       CentroEmisor As Integer, NumeroOrdenProduccion As Long,
                                       Orden As Integer, IdProducto As String,
                                       FechaEstado As Date?) As DataTable
      Return OrdenesProduccionEstados_G(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion, Orden, IdProducto, FechaEstado, String.Empty)
   End Function

   Private Function OrdenesProduccionEstados_G(IdSucursal As Integer?,
                                     IdTipoComprobante As String, Letra As String,
                                     CentroEmisor As Integer?, NumeroOrdenProduccion As Long?,
                                     Orden As Integer?, IdProducto As String,
                                     FechaEstado As Date?,
                                     idTipoEstado As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If IdSucursal.HasValue Then
            .AppendFormat("   AND PE.IdSucursal = {0}", IdSucursal.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(IdTipoComprobante) Then
            .AppendFormat("   AND PE.IdTipoComprobante = '{0}'", IdTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(Letra) Then
            .AppendFormat("   AND PE.Letra = '{0}'", Letra).AppendLine()
         End If
         If CentroEmisor.HasValue Then
            .AppendFormat("   AND PE.CentroEmisor = {0}", CentroEmisor.Value).AppendLine()
         End If
         If NumeroOrdenProduccion.HasValue Then
            .AppendFormat("   AND PE.NumeroOrdenProduccion = {0}", NumeroOrdenProduccion.Value).AppendLine()
         End If
         If Orden.HasValue Then
            .AppendFormat("   AND PE.Orden = {0}", Orden.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(IdProducto) Then
            .AppendFormat("   AND PE.IdProducto = '{0}'", IdProducto).AppendLine()
         End If
         If FechaEstado.HasValue Then
            .AppendFormat("   AND PE.FechaEstado = '{0}'", ObtenerFecha(FechaEstado.Value, True)).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoEstado) Then
            .AppendFormat("   AND EP.IdTipoEstado = '{0}'", idTipoEstado).AppendLine()
         End If
         .AppendFormat(" ORDER BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroOrdenProduccion, PE.Orden, PE.IdProducto")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub OrdenesProduccionEstados_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                         idproducto As String, fechaEstado As Date, idEstado As String,
                                         idUsuario As String, observacion As String,
                                         cantEstado As Decimal,
                                         idTipoComprobanteFact As String, letraFact As String, centroEmisorFact As Integer, numeroComprobanteFact As Long, orden As Integer,
                                         criticidad As String, fechaEntrega As Date?, numeroReparto As Integer, idFormula As Integer, idResponsable As Integer,
                                         planMaestroNumero As Integer?, planMaestroFecha As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO OrdenesProduccionEstados")
         .AppendFormatLine("         ({0}", Entidades.OrdenProduccion.Columnas.IdSucursal.ToString())
         .AppendFormatLine("         ,{0}", Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("         ,{0}", Entidades.OrdenProduccion.Columnas.Letra.ToString())
         .AppendFormatLine("         ,{0}", Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("         ,{0}", Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString())
         .AppendFormatLine("         ,idProducto")
         .AppendFormatLine("         ,fechaEstado")
         .AppendFormatLine("         ,idEstado")
         .AppendFormatLine("         ,IdUsuario")
         .AppendFormatLine("         ,observacion")
         .AppendFormatLine("         ,CantEstado")
         .AppendFormatLine("         ,IdTipoComprobanteFact")
         .AppendFormatLine("         ,LetraFact")
         .AppendFormatLine("         ,CentroEmisorFact")
         .AppendFormatLine("         ,NumeroComprobanteFact")
         .AppendFormatLine("         ,Orden")
         .AppendFormatLine("         ,IdCriticidad")
         .AppendFormatLine("         ,FechaEntrega")
         .AppendFormatLine("         ,NumeroReparto")
         .AppendFormatLine("         ,IdFormula")
         .AppendFormatLine("         ,IdResponsable")
         .AppendFormatLine("         ,PlanMaestroNumero")
         .AppendFormatLine("         ,PlanMaestroFecha")
         .AppendFormatLine(" ) VALUES (")

         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          ,'{0}'", idTipoComprobante)
         .AppendFormatLine("          ,'{0}'", letra)
         .AppendFormatLine("          , {0} ", centroEmisor)
         .AppendFormatLine("          , {0} ", numeroOrdenProduccion)
         .AppendFormatLine("          ,'{0}'", idproducto)
         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaEstado, True))
         .AppendFormatLine("          ,'{0}'", idEstado)
         .AppendFormatLine("          ,'{0}'", idUsuario)
         .AppendFormatLine("          ,'{0}'", observacion)
         .AppendFormatLine("          , {0} ", cantEstado)
         .AppendFormatLine("          , {0} ", GetStringParaQueryConComillas(idTipoComprobanteFact))
         .AppendFormatLine("          , {0} ", GetStringParaQueryConComillas(letraFact))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(centroEmisorFact))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(numeroComprobanteFact))
         .AppendFormatLine("          , {0} ", orden)
         .AppendFormatLine("          ,'{0}'", criticidad)
         .AppendFormatLine("          , {0} ", ObtenerFecha(fechaEntrega, True))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(numeroReparto))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(idFormula))
         .AppendFormatLine("          , {0} ", idResponsable)
         .AppendFormatLine("          , {0} ", GetStringFromNumber(planMaestroNumero))
         .AppendFormatLine("          , {0} ", ObtenerFecha(planMaestroFecha, True))

         .Append(")").AppendLine()
      End With
      Execute(myQuery)
   End Sub

   Public Sub OrdenesProduccionEstados_U_Cantidad(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Integer,
                                        numeroOrdenProduccion As Long,
                                        idproducto As String,
                                        orden As Integer,
                                        fechaEstado As Date,
                                        deltaCantEstado As Decimal)
      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("UPDATE OrdenesProduccionEstados")
         .AppendLine("   SET CantEstado = CantEstado + " & deltaCantEstado.ToString())
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
      End With

      Execute(stbQuery)
   End Sub

   Public Sub OrdenesProduccionEstados_U_Estado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                idproducto As String, fechaEstado As Date, idEstado As String, cantEstado As Decimal, fechaNuevoEstado As Date,
                                                observacion As String, orden As Integer,
                                                criticidad As String, fechaEntrega As Date, numeroReparto As Integer, idResponsable As Integer,
                                                planMaestroNumero As Integer?, planMaestroFecha As Date?)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("UPDATE OrdenesProduccionEstados")
         .AppendFormatLine("   SET CantEstado = {0}", cantEstado)
         .AppendFormatLine("     , IdEstado = '{0}'", idEstado)
         .AppendFormatLine("     , FechaEstado = '{0}'", ObtenerFecha(fechaNuevoEstado, True))
         .AppendFormatLine("     , Observacion = '{0}'", observacion)
         .AppendFormatLine("     , IdCriticidad = '{0}'", criticidad)
         .AppendFormatLine("     , FechaEntrega = '{0}'", ObtenerFecha(fechaEntrega, True))
         If numeroReparto > 0 Then
            .AppendFormatLine("     , NumeroReparto = {0}", numeroReparto)
         End If
         .AppendFormatLine("     , PlanMaestroNumero = {0}", GetStringFromNumber(planMaestroNumero))
         .AppendFormatLine("     , PlanMaestroFecha = {0}", ObtenerFecha(planMaestroFecha, True))
         .AppendFormatLine("     , IdResponsable = " & idResponsable)

         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroOrdenProduccion = {0}", numeroOrdenProduccion)
         .AppendFormatLine("   AND FechaEstado = '{0}'", ObtenerFecha(fechaEstado, True))
         .AppendFormatLine("   AND IdProducto = '{0}'", idproducto)
         .AppendFormatLine("   AND Orden = {0}", orden)
      End With
      Execute(stbQuery)
   End Sub


   Public Sub OrdenesProduccionEstados_U_Anular(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numeroOrdenProduccion As Long,
                                      idproducto As String,
                                      fechaEstado As Date,
                                      orden As Integer,
                                      idEstadoNuevo As String,
                                      fechaNuevoEstado As Date,
                                      observacion As String)

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("UPDATE OrdenesProduccionEstados")
         .AppendLine("   SET IdEstado = '" & idEstadoNuevo & "'")
         .AppendLine("      ,FechaEstado = '" & ObtenerFecha(fechaNuevoEstado, True) & "'")
         .AppendLine("      ,Observacion = '" & observacion & "'")
         .AppendLine("      ,IdTipoComprobanteFact = null ")
         .AppendLine("      ,LetraFact = null ")
         .AppendLine("      ,CentroEmisorFact = null ")
         .AppendLine("      ,NumeroComprobanteFact = null ")
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)

      End With

      Execute(stbQuery)

   End Sub

   Public Sub OrdenesProduccionEstados_U_Fact(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Integer,
                                    numeroOrdenProduccion As Long,
                                    idProducto As String,
                                    fechaEstado As Date,
                                    idTipoComprobanteFact As String,
                                    letraFact As String,
                                    centroEmisorFact As Integer,
                                    numeroComprobanteFact As Long,
                                    Orden As Integer)

      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .Length = 0
         .AppendLine("UPDATE OrdenesProduccionEstados")
         .AppendLine("   SET IdTipoComprobanteFact = '" & idTipoComprobanteFact & "'")
         .AppendLine("      ,LetraFact = '" & letraFact & "'")
         .AppendLine("      ,CentroEmisorFact =" & centroEmisorFact.ToString)
         .AppendLine("      ,NumeroComprobanteFact = " & numeroComprobanteFact.ToString)
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
         .AppendLine("   AND Orden = " & Orden.ToString)
      End With

      Execute(stbQuery)

   End Sub


   Public Function OrdenesProduccionEstados_G_PorComprobanteFact(idSucursal As Integer,
                                                       idTipoComprobanteFact As String,
                                                       letraFact As String,
                                                       centroEmisorFact As Short,
                                                       numeroComprobanteFact As Long) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .Length = 0
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroOrdenProduccion")
         .AppendLine("      ,P.FechaOrdenProduccion")
         .AppendLine("      ,P.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano, Pr.IdUnidadDeMedida, pp.Orden")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE ")
         .AppendLine("           (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE PE.CantEstado END) END) AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")
         .AppendLine(" FROM OrdenesProduccion P")

         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         '.AppendLine("   AND P.IdTipoComprobante = '" & idTipoComprobante & "'")
         '.AppendLine("   AND P.Letra = '" & letra & "'")
         '.AppendLine("   AND P.CentroEmisor = " & centroEmisor.ToString())
         '.AppendLine("   AND P.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         .AppendLine("   AND PE.IdTipoComprobanteFact = '" & idTipoComprobanteFact & "'")
         .AppendLine("   AND PE.LetraFact = '" & letraFact & "'")
         .AppendLine("   AND PE.CentroEmisorFact = " & centroEmisorFact.ToString())
         .AppendLine("   AND PE.NumeroComprobanteFact = " & numeroComprobanteFact.ToString())

         .AppendLine(" ORDER BY p.fechaOrdenProduccion")
      End With
      Return Me.GetDataTable(stbQuery.ToString())
   End Function


   'TODO: Para revisar
   Public Function GetOrdenesProduccionEstadosUno(IdSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroOrdenProduccion As Long,
                                     idProducto As String,
                                     fechaEstado As Date,
                                     orden As Integer) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT '' as Color")
         .AppendLine("      ,'False' as masivo")
         .AppendLine("      ,pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroOrdenProduccion")
         .AppendLine("      ,P.FechaOrdenProduccion")
         .AppendLine("      ,P.IdCliente, C.NombreCliente")
         ' Agrego orden ############## 17*03*13
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pp.Precio, pp.Orden")
         .AppendLine("      ,pe.CantEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE ")
         .AppendLine(" (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE PE.CantEstado END) END) AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine(" FROM OrdenesProduccion P")
         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN Productos PR ON PR.IdProducto = PE.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")

         .AppendLine(" WHERE p.IdSucursal = " & IdSucursal.ToString())

         .AppendFormat("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND P.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND P.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND P.NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()

         .AppendLine("   AND pe.FechaEstado = '" & Me.ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND pe.IdProducto = '" & idProducto & "'")

         .AppendLine("   AND pe.Orden = " & orden.ToString)

      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetOrdenesProduccionMRP(idEstado As String, idCliente As Long, fechaDesde As Date?, fechaHasta As Date?, fechaDesdeEntrega As Date?, fechaHastaEntrega As Date?) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT 'False' as Masivo,")
         .AppendLine("       OPE.IdSucursal,")
         .AppendLine("       OPE.IdTipoComprobante,")
         .AppendLine("       OPE.Letra,")
         .AppendLine("       OPE.CentroEmisor, ")
         .AppendLine("       OPE.NumeroOrdenProduccion, ")
         .AppendLine("       OPE.FechaEstado,")
         .AppendLine("       CONVERT(DATE, OPE.FechaEstado) FechaEstado_Fecha,")
         .AppendLine("       CONVERT(TIME, OPE.FechaEstado) FechaEstado_Hora,")
         .AppendLine("       OPE.IdProducto,")
         .AppendLine("       PRD.NombreProducto,")
         .AppendLine("       OPE.FechaEntrega,")
         .AppendLine("       OPE.Orden,")
         .AppendLine("       OPE.CantEstado,")
         .AppendLine("       OPE.IdCriticidad,")
         .AppendLine("       OPE.IdResponsable,")
         .AppendLine("       EOP.IdEstado,")
         .AppendLine("       OPR.IdCliente, ")
         .AppendLine("       CNT.NombreCliente, ")
         .AppendLine("       MRC.IdMarca, MRC.NombreMarca,")
         .AppendLine("       RBS.IdRubro, RBS.NombreRubro,")
         .AppendLine("       SRB.IdSubRubro, SRB.NombreSubRubro,")
         .AppendLine("       OMR.IdProcesoProductivo, ")
         .AppendLine("       OMR.CodigoProcesoProductivo, MPP.DescripcionProceso,")
         '-- REQ-41643.- ------------------------------------------------------------
         .AppendLine("       OPP.IdSucursalPedido,")
         .AppendLine("       OPP.IdTipoComprobantePedido,")
         .AppendLine("       OPP.LetraPedido,")
         .AppendLine("       OPP.CentroEmisorPedido,")
         .AppendLine("       OPP.NumeroPedido,")
         .AppendLine("       OPP.IdProductoPedido,")
         .AppendLine("       OPP.OrdenPedido,")
         '---------------------------------------------------------------------------
         .AppendLine("       '' AS IdFormula")
         '----------------------------------------------------------------------------
         .AppendLine("  FROM OrdenesProduccionEstados OPE")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EOP ON EOP.idEstado = OPE.IdEstado")
         .AppendLine(" INNER JOIN Productos PRD ON PRD.idProducto = OPE.IdProducto ")

         .AppendLine(" INNER JOIN OrdenesProduccion OPR ")
         .AppendLine("         ON OPR.IdSucursal = OPE.IdSucursal ")
         .AppendLine("        AND OPR.IdTipoComprobante = OPE.IdTipoComprobante ")
         .AppendLine("        AND OPR.Letra = OPE.Letra ")
         .AppendLine("        AND OPR.NumeroOrdenProduccion = OPE.NumeroOrdenProduccion ")
         '----------------------------------------------------------------------------
         .AppendLine(" INNER JOIN OrdenesProduccionMRP OMR ")
         .AppendLine("         ON OMR.IdSucursal = OPE.IdSucursal ")
         .AppendLine("        AND OMR.IdTipoComprobante = OPE.IdTipoComprobante ")
         .AppendLine("        AND OMR.LetraComprobante = OPE.Letra ")
         .AppendLine("        AND OMR.NumeroOrdenProduccion = OPE.NumeroOrdenProduccion")
         .AppendLine("        AND OMR.IdProducto = OPE.IdProducto ")
         .AppendLine("        AND OMR.Orden = OPE.Orden ")
         '-- REQ-41643.- ------------------------------------------------------------
         .AppendLine("   LEFT JOIN OrdenesProduccionProductos OPP ")
         .AppendLine("          ON OPP.IdSucursal = OPE.IdSucursal ")
         .AppendLine("         AND OPP.IdTipoComprobante = OPE.IdTipoComprobante ")
         .AppendLine("         AND OPP.Letra = OPE.Letra ")
         .AppendLine("         AND OPP.NumeroOrdenProduccion = OPE.NumeroOrdenProduccion")
         .AppendLine("         AND OPP.IdProducto = OPE.IdProducto ")
         .AppendLine("         AND OPP.Orden = OPE.Orden ")
         '----------------------------------------------------------------------------
         .AppendLine(" INNER JOIN MRPProcesosProductivos MPP ON MPP.IdProcesoProductivo = OMR.IdProcesoProductivo ")

         .AppendLine(" INNER JOIN Clientes CNT ON CNT.IdCliente = OPR.IdCliente ")
         .AppendLine(" INNER JOIN Marcas MRC ON MRC.IdMarca = PRD.IdMarca ")
         .AppendLine(" INNER JOIN Rubros RBS ON RBS.IdRubro = PRD.IdRubro ")
         .AppendLine("  LEFT JOIN SubRubros SRB ON SRB.IdRubro = PRD.IdRubro AND SRB.IdSubRubro = PRD.IdSubRubro")
         '----------------------------------------------------------------------------
         '.AppendLine("  LEFT JOIN PedidosEstados PE ON PE.IdSucursalProduccion = OPR.IdSucursal")
         '.AppendLine("                             AND PE.IdTipoComprobanteProduccion = OPR.IdTipoComprobante")
         '.AppendLine("                             AND PE.LetraProduccion = OPR.Letra")
         '.AppendLine("                             AND PE.CentroEmisorProduccion = OPR.CentroEmisor")
         '.AppendLine("                             AND PE.NumeroOrdenProduccion = OPR.NumeroOrdenProduccion")
         '----------------------------------------------------------------------------
         .AppendLine(" WHERE 1 = 1")
         .AppendFormatLine("   AND OPE.IdSucursal = {0}", actual.Sucursal.IdSucursal)
         .AppendFormatLine("   AND OPE.IdEstado = '{0}'", idEstado)
         .AppendFormatLine("   AND (OPE.PlanMaestroNumero IS NULL OR OPE.PlanMaestroNumero = 0)")

         If idCliente > 0 Then
            .AppendFormatLine("   AND OPR.IdCliente = {0}", idCliente)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND OPE.FechaEstado >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
            .AppendFormatLine("   AND OPE.FechaEstado <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If
         If fechaDesdeEntrega.HasValue Then
            .AppendFormatLine("   AND OPE.FechaEntrega >= '{0}'", ObtenerFecha(fechaDesdeEntrega.Value, True))
            .AppendFormatLine("   AND OPE.FechaEntrega <= '{0}'", ObtenerFecha(fechaHastaEntrega.Value, True))
         End If

      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Function GetOrdenesProduccionREQ(idCliente As Long,
                                           fechaDesde As Date,
                                           fechaHasta As Date,
                                           fechaDesdeEntrega As Date,
                                           fechaHastaEntrega As Date,
                                           idPlanMaestro As Integer,
                                           fechaDesdePM As Date,
                                           fechaHastaPM As Date) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT 'False' as Masivo,")
         .AppendLine("     	OPE.IdSucursal,")
         .AppendLine("     	OPE.IdTipoComprobante,")
         .AppendLine("     	OPE.Letra,")
         .AppendLine("     	OPE.CentroEmisor, ")
         .AppendLine("     	OPE.NumeroOrdenProduccion, ")
         .AppendLine("     	OPE.FechaEstado,")
         .AppendLine("     	OPE.IdProducto,")
         .AppendLine("     	PRD.NombreProducto,")
         .AppendLine("     	OPE.FechaEntrega,")
         .AppendLine("     	OPE.Orden,")
         .AppendLine("     	OPE.CantEstado,")
         .AppendLine("     	EOP.idEstado,")
         .AppendLine("     	OPR.IdCliente, ")
         .AppendLine("     	CNT.NombreCliente, ")
         .AppendLine("     	MRC.IdMarca, MRC.NombreMarca,")
         .AppendLine("     	RBS.IdRubro, RBS.NombreRubro,")
         .AppendLine("     	SRB.IdSubRubro, SRB.NombreSubRubro,")
         .AppendLine("     	OMR.IdProcesoProductivo, ")
         .AppendLine("     	OMR.CodigoProcesoProductivo, MPP.DescripcionProceso,")
         .AppendLine("     	'' AS IdFormula,")
         .AppendLine("     	OPE.PlanMaestroNumero, OPE.PlanMaestroFecha,")
         .AppendLine("     	OPE.IdCriticidad, OPE.IdResponsable")
         .AppendLine("        ,OPP.NumeroPedido
                        		,OPP.OrdenPedido ")
         .AppendLine("    FROM OrdenesProduccionEstados OPE")
         .AppendLine("    	    INNER JOIN EstadosOrdenesProduccion EOP ON EOP.idEstado = OPE.IdEstado")
         .AppendLine("    	    INNER JOIN Productos PRD ON PRD.idProducto = OPE.IdProducto ")

         .AppendLine("    	    INNER JOIN OrdenesProduccion OPR ")
         .AppendLine("    	    	ON OPR.IdSucursal = OPE.IdSucursal ")
         .AppendLine("    	    		AND OPR.IdTipoComprobante = OPE.IdTipoComprobante ")
         .AppendLine("    	    		AND OPR.Letra = OPE.Letra ")
         .AppendLine("    	    		AND OPR.NumeroOrdenProduccion = OPE.NumeroOrdenProduccion ")

         .AppendLine("    	    INNER JOIN OrdenesProduccionMRP OMR ")
         .AppendLine("    	    	ON OMR.IdSucursal = OPE.IdSucursal ")
         .AppendLine("    	       AND OMR.IdTipoComprobante = OPE.IdTipoComprobante ")
         .AppendLine("    	       AND OMR.LetraComprobante = OPE.Letra ")
         .AppendLine("    	       AND OMR.NumeroOrdenProduccion = OPE.NumeroOrdenProduccion")
         .AppendLine("    	       AND OMR.IdProducto = OPE.IdProducto ")

         .AppendLine("    	    INNER JOIN MRPProcesosProductivos MPP ON MPP.IdProcesoProductivo = OMR.IdProcesoProductivo ")

         .AppendLine("    	    INNER JOIN Clientes CNT ON CNT.IdCliente = OPR.IdCliente ")
         .AppendLine("    	    INNER JOIN Marcas MRC ON MRC.IdMarca = PRD.IdMarca ")
         .AppendLine("    	    INNER JOIN Rubros RBS ON RBS.IdRubro = PRD.IdRubro ")
         .AppendLine("    	    LEFT JOIN SubRubros SRB ON SRB.IdRubro = PRD.IdRubro AND SRB.IdSubRubro = PRD.IdSubRubro")
         .AppendLine("         LEFT JOIN OrdenesProduccionProductos OPP ON OPP.IdSucursal = OPE.IdSucursal
													AND OPP.NumeroOrdenProduccion = OPE.NumeroOrdenProduccion
													AND OPP.IdProducto = OPE.IdProducto
													AND OPP.Orden = OPE.Orden
													AND OPP.IdTipoComprobante = OPE.IdTipoComprobante
													AND OPP.Letra = OPE.Letra
													AND OPP.CentroEmisor = OPE.CentroEmisor")

         .AppendLine("  WHERE 1 = 1")
         .AppendFormatLine("   AND OPE.IdSucursal = {0}", actual.Sucursal.IdSucursal)
         .AppendLine("   AND OPE.IdEstado IN ('PLANEADA')")

         If idCliente > 0 Then
            .AppendFormatLine("   AND OPR.IdCliente = {0}", idCliente)
         End If
         If idPlanMaestro > 0 Then
            .AppendFormatLine("   AND OPE.PlanMaestroNumero = {0}", idPlanMaestro)
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND OPE.FechaEstado >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND OPE.FechaEstado <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If
         If fechaDesdeEntrega > Date.Parse("01/01/1990") Then
            .AppendLine("   AND OPE.FechaEntrega >= '" & fechaDesdeEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND OPE.FechaEntrega <= '" & fechaHastaEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If
         If fechaDesdePM > Date.Parse("01/01/1990") Then
            .AppendLine("   AND OPE.PlanMaestroFecha >= '" & fechaDesdePM.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND OPE.PlanMaestroFecha <= '" & fechaHastaPM.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND OPE.PlanMaestroNumero IS NOT NULL")
         End If

      End With

      Return GetDataTable(stbQuery)
   End Function


   Public Overloads Function GetPlanMaestroMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("PlanMaestroNumero", "OrdenesProduccionEstados"))
   End Function
End Class
