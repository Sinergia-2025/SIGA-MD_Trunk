Public Class Alquileres
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

    Public Sub Alquiler_I(ByVal IdSucursal As Integer, _
                          ByVal NumeroContrato As Long, _
                          ByVal FechaContrato As Date, _
                          ByVal IdProducto As String, _
                          ByVal FechaDesde As Date, _
                          ByVal FechaHasta As Date, _
                          ByVal esRenovable As Boolean, _
                          ByVal LocatarioNroDocumento As Long, _
                          ByVal LocatarioNombre As String, _
                          ByVal LocatarioCargo As String, _
                          ByVal ImporteTotal As Decimal, _
                          ByVal PersonalCapacitado As String, _
                          ByVal LugarER As String, _
                          ByVal horaE As String, _
                          ByVal horaR As String, _
                          ByVal FechaRealFin As Date, _
                          ByVal IdUsuario As String, _
                          ByVal ImporteAlquiler As Decimal, _
                          ByVal ImporteTraslado As Decimal, _
                          ByVal IdCliente As Long)

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("INSERT INTO Alquileres (")
            .AppendLine(" IdSucursal, ")
            .AppendLine(" NumeroContrato, ")
            .AppendLine(" FechaContrato, ")
            .AppendLine(" IdProducto, ")
            .AppendLine(" FechaDesde, ")
            .AppendLine(" FechaHasta, ")
            .AppendLine(" esRenovable, ")
            .AppendLine(" LocatarioNroDocumento, ")
            .AppendLine(" LocatarioNombre, ")
            .AppendLine(" LocatarioCargo, ")
            .AppendLine(" ImporteTotal, ")
            .AppendLine(" PersonalCapacitado, ")
            .AppendLine(" LugarER, ")
            .AppendLine(" horaE, ")
            .AppendLine(" horaR, ")
            .AppendLine(" idEstado, ")
            .AppendLine(" FechaRealFin, ")
            .AppendLine(" IdUsuario, ")
            .AppendLine(" ImporteAlquiler, ")
            .AppendLine(" ImporteTraslado, ")
            .AppendLine(" IdCliente")
            .AppendLine(" ) VALUES ( ")
            .AppendLine("   " & IdSucursal.ToString())
            .AppendLine("   ," & NumeroContrato.ToString())
            .AppendLine("   ,'" & Me.ObtenerFecha(FechaContrato, False) & "'")
            .AppendLine("   ,'" & IdProducto & "'")
            .AppendLine("   ,'" & Me.ObtenerFecha(FechaDesde, False) & "'")
            .AppendLine("   ,'" & Me.ObtenerFecha(FechaHasta, False) & "'")
            .AppendLine("   ,'" & esRenovable.ToString() & "'")
            .AppendLine("   ," & LocatarioNroDocumento.ToString())
            .AppendLine("   ,'" & LocatarioNombre & "'")
            .AppendLine("   ,'" & LocatarioCargo & "'")
            .AppendLine("   ," & ImporteTotal.ToString)
            .AppendLine("   ,'" & PersonalCapacitado & "'")
            .AppendLine("   ,'" & LugarER & "'")
            .AppendLine("   ,'" & horaE & "'")
            .AppendLine("   ,'" & horaR & "'")
            .AppendLine("   ,10") ' ALTA
            .AppendLine("   ,'" & Me.ObtenerFecha(FechaRealFin, False) & "'")
            .AppendLine("   ,'" & IdUsuario & "'")
            .AppendLine("   ," & ImporteAlquiler.ToString)
            .AppendLine("   ," & ImporteTraslado.ToString)
            .AppendLine("   , " & IdCliente)

            .AppendLine("   )")

        End With

        Me.Execute(stb.ToString())

    End Sub

    Public Sub Alquiler_U(ByVal IdSucursal As Integer, _
                          ByVal NumeroContrato As Long, _
                          ByVal FechaContrato As Date, _
                          ByVal IdProducto As String, _
                          ByVal FechaDesde As Date, _
                          ByVal FechaHasta As Date, _
                          ByVal esRenovable As Boolean, _
                          ByVal LocatarioNroDocumento As Long, _
                          ByVal LocatarioNombre As String, _
                          ByVal LocatarioCargo As String, _
                          ByVal ImporteTotal As Decimal, _
                          ByVal PersonalCapacitado As String, _
                          ByVal LugarER As String, _
                          ByVal horaE As String, _
                          ByVal horaR As String, _
                          ByVal FechaRealFin As Date, _
                          ByVal IdUsuario As String, _
                          ByVal ImporteAlquiler As Decimal, _
                          ByVal ImporteTraslado As Decimal, _
                          ByVal IdCLiente As Long)

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("UPDATE Alquileres ")
            .AppendLine("  SET FechaContrato = '" & Me.ObtenerFecha(FechaContrato, False) & "'")
            .AppendLine("     ,IdProducto = '" & IdProducto & "'")
            .AppendLine("     ,FechaDesde = '" & Me.ObtenerFecha(FechaDesde, False) & "'")
            .AppendLine("     ,FechaHasta = '" & Me.ObtenerFecha(FechaHasta, False) & "'")
            .AppendLine("     ,esRenovable = '" & esRenovable.ToString() & "'")
            .AppendLine("     ,IdCliente = " & IdCLiente)
            .AppendLine("     ,LocatarioNroDocumento = " & LocatarioNroDocumento.ToString())
            .AppendLine("     ,LocatarioNombre = '" & LocatarioNombre & "'")
            .AppendLine("     ,LocatarioCargo = '" & LocatarioCargo & "'")
            .AppendLine("     ,ImporteTotal = " & ImporteTotal.ToString)
            .AppendLine("     ,PersonalCapacitado = '" & PersonalCapacitado & "'")
            .AppendLine("     ,LugarER = '" & LugarER & "'")
            .AppendLine("     ,horaE = '" & horaE & "'")
            .AppendLine("     ,horaR = '" & horaR & "'")
            .AppendLine("     ,FechaRealFin = '" & Me.ObtenerFecha(FechaRealFin, False) & "'")
            .AppendLine("     ,IdUsuario = '" & IdUsuario & "'")
            .AppendLine("     ,ImporteAlquiler = " & ImporteAlquiler.ToString)
            .AppendLine("     ,ImporteTraslado = " & ImporteTraslado.ToString)
            .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
            .AppendLine("   AND NumeroContrato = " & NumeroContrato.ToString())
        End With

        Me.Execute(stb.ToString())

    End Sub

    Public Sub Alquiler_D(ByVal IdSucursal As Integer, _
                          ByVal NumeroContrato As Long)

        'ByVal IdProducto As String, _
        'ByVal FechaDesde As Date, _
        'ByVal FechaHasta As Date)

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("DELETE FROM Alquileres")
            .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
            .AppendLine("   AND NumeroContrato = " & NumeroContrato.ToString())

            '.AppendLine("   AND IdProducto = '" & IdProducto & "'")
            '.AppendLine("   AND FechaDesde = '" & Me.ObtenerFecha(FechaDesde, False) & "'")
            '.AppendLine("   AND FechaHasta = '" & Me.ObtenerFecha(FechaHasta, False) & "'")
        End With

        Me.Execute(stb.ToString())

    End Sub

    Private Sub SelectTexto(ByVal stb As StringBuilder)
        With stb
            .Length = 0
            .AppendLine("SELECT IdSucursal")
            .AppendLine("      ,A.NumeroContrato")
            .AppendLine("      ,A.FechaContrato")
            .AppendLine("      ,A.IdProducto")
            '.AppendLine("      ,(P.NombreProducto + ' - ' + P.EquipoMarca + ' - ' + P.EquipoModelo  + ' - ' + P.NumeroSerie + ' - ' + LTRIM(STR(P.Anio)) + ' - ' + P.CaractSII) as NombreProducto")
            .AppendLine("      ,(P.NombreProducto + ' - ' + P.EquipoMarca + ' - ' + P.EquipoModelo  + ' - ' + P.NumeroSerie + ' - ' + LTRIM(STR(P.Anio)) ) as NombreProducto")
            .AppendLine("      ,A.FechaDesde")
            .AppendLine("      ,A.FechaHasta")
            .AppendLine("      ,A.EsRenovable")
            .AppendLine("      ,A.IdCliente")
            .AppendLine("      ,C.NombreCliente")
            .AppendLine("      ,A.LocatarioNroDocumento")
            .AppendLine("      ,A.LocatarioNombre")
            .AppendLine("      ,A.LocatarioCargo")
            .AppendLine("      ,A.ImporteAlquiler")
            .AppendLine("      ,A.ImporteTraslado")
            .AppendLine("      ,A.ImporteTotal")
            .AppendLine("      ,A.PersonalCapacitado")
            .AppendLine("      ,A.LugarER")
            .AppendLine("      ,A.HoraE")
            .AppendLine("      ,A.HoraR")
            .AppendLine("      ,A.IdEstado")
            .AppendLine("      ,EC.NombreEstado")
            .AppendLine("      ,A.FechaRealFin")
            .AppendLine("      ,A.IdUsuario")
            .AppendLine("      ,A.IdTipoComprobante")
            .AppendLine("      ,A.Letra")
            .AppendLine("      ,A.CentroEmisor")
            .AppendLine("      ,A.NumeroComprobante")

            '.AppendLine("       ,C.Observacion ") 'Se aplicabaa Empresa... no por ahora
            .AppendLine(" FROM Alquileres A")
            .AppendLine(" INNER JOIN Productos P ON P.IdProducto = A.IdProducto")
            .AppendLine(" INNER JOIN AlquileresEstadosContratos EC ON EC.IdEstado = A.IdEstado")
            .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = A.IdCliente")
        End With
    End Sub

    Public Overloads Function Buscar(ByVal idSucursal As Integer, ByVal columna As String, ByVal valor As String) As DataTable
        columna = "A." + columna
        'If columna = "A.NombreProducto" Then columna = "(P.NombreProducto + ' - ' + P.EquipoMarca + ' - ' + P.EquipoModelo + ' - ' + P.NumeroSerie + ' - ' + LTRIM(STR(P.Anio)) + ' - ' + P.CaractSII)"
        If columna = "A.NombreProducto" Then columna = "(P.NombreProducto + ' - ' + P.EquipoMarca + ' - ' + P.EquipoModelo + ' - ' + P.NumeroSerie + ' - ' + LTRIM(STR(P.Anio)) )"
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .AppendLine(" WHERE A.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND " & columna & " LIKE '%" & valor & "%'")
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

    Public Function Alquiler_GA(ByVal idSucursal As Integer) As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .AppendLine(" WHERE A.IdSucursal = " & idSucursal.ToString())
            .AppendLine(" ORDER BY NombreProducto")
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

    Public Function validarFechaReal(ByVal idSucursal As Integer, _
                                     ByVal IdProducto As String, _
                                     ByVal fechaReal As Date) As Boolean

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("SELECT NumeroContrato FROM Alquileres")
            .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND IdProducto = '" & IdProducto & "'")
            .AppendLine("   AND FechaDesde <= '" & fechaReal.ToString("yyyy-MM-dd") & "'")
            .AppendLine("   AND FechaRealFin >= '" & fechaReal.ToString("yyyy-MM-dd") & "'")
        End With

        Return Me.GetDataTable(stb.ToString()).Rows.Count > 0

    End Function

    Public Function Alquiler_G1(ByVal idSucursal As Integer, _
                                ByVal NumeroContrato As Long) As DataTable

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            Me.SelectTexto(stb)
            .AppendLine(" WHERE A.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND A.NumeroContrato = " & NumeroContrato.ToString())
        End With

        Return Me.GetDataTable(stb.ToString())

    End Function

    Public Function Alquiler_GetIDMaximo() As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            .Length = 0
            .AppendLine("SELECT MAX(NumeroContrato) AS Maximo")
            .AppendLine(" FROM Alquileres")
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

    Public Function GetContratos(ByVal IdSucursal As Integer _
                                , ByVal fechaDesde As Date _
                                , ByVal fechaHasta As Date _
                                , ByVal idEstado As Integer _
                                , ByVal SoloActivos As Boolean _
                                , ByVal esRenovable As String _
                                , ByVal idProducto As String) As DataTable

        Dim stbQuery As StringBuilder = New StringBuilder("")
        Dim dt As New DataTable

        With stbQuery
            Me.SelectTexto(stbQuery)
            .AppendLine(" WHERE A.IdSucursal = " & IdSucursal.ToString())
            '.AppendLine("   AND A.FechaDesde >= '" & fechaDesde.ToString("yyyy-MM-dd") & "'")
            '.AppendLine("   AND A.FechaRealFin <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
            .AppendLine("   AND A.FechaDesde <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
            .AppendLine("   AND A.FechaRealFin >= '" & fechaDesde.ToString("yyyy-MM-dd") & "'")

            If Not SoloActivos Then
                If idEstado >= 10 Then
                    .AppendLine("   AND A.IdEstado = " & idEstado.ToString())
                End If
            Else
                .AppendLine("   AND A.IdEstado IN (20, 30)")   'En Vigencia / Renovado
            End If

            If esRenovable <> "TODOS" Then
                .AppendLine("   AND A.EsRenovable = '" & IIf(esRenovable = "SI", "True", "False").ToString() & "'")
            End If

            If Not String.IsNullOrEmpty(idProducto) Then
                .AppendLine("   AND A.IdProducto = '" & idProducto & "'")
            End If

            .AppendLine(" ORDER BY A.FechaRealFin ASC")

            dt = Me.GetDataTable(stbQuery.ToString())

        End With

        Return dt

    End Function

    Public Sub ActualizarEstadoContrato(ByVal IdSucursal As Integer, _
                                        ByVal NumeroContrato As Long, _
                                        ByVal IdEstado As Integer, _
                                        ByVal FechaRealFin As Date)

        Dim stbQuery As StringBuilder = New StringBuilder("")

        With stbQuery
            .Length = 0
            .AppendLine("UPDATE Alquileres ")
            .AppendLine("   SET IdEstado = " & IdEstado.ToString())
            .AppendLine("      ,FechaRealFin = '" & Me.ObtenerFecha(FechaRealFin, False) & "'")
            .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
            .AppendLine("   AND NumeroContrato = " & NumeroContrato.ToString())
        End With

        Me.Execute(stbQuery.ToString())

    End Sub

    Public Sub ActualizarRemitoContrato(ByVal IdSucursal As Integer, _
                                        ByVal NumeroContrato As Long, _
                                        ByVal idTipoComprobante As String, _
                                        ByVal letra As String, _
                                        ByVal centroEmisor As Integer, _
                                        ByVal numeroComprobante As Long)

        Dim stbQuery As StringBuilder = New StringBuilder("")

        With stbQuery
            .Length = 0
            .AppendLine("UPDATE Alquileres ")
            .AppendLine("   SET IdTipoComprobante = '" & idTipoComprobante & "'")
            .AppendLine("      ,Letra = '" & letra & "'")
            .AppendLine("      ,CentroEmisor = " & centroEmisor.ToString())
            .AppendLine("      ,NumeroComprobante = " & numeroComprobante.ToString())
            .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
            .AppendLine("   AND NumeroContrato = " & NumeroContrato.ToString())
        End With

        Me.Execute(stbQuery.ToString())

    End Sub

End Class
