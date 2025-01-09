Public Class VentasNumeros
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "VentasNumeros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      Throw New NotImplementedException()
      'EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.VentaNumero), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.VentaNumero), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      Throw New NotImplementedException()
      'EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.VentaNumero), TipoSP._D))
   End Sub
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.VentasNumeros(da).VentasNumeros_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(vn As Entidades.VentaNumero, tipo As TipoSP)
      Dim sql = New SqlServer.VentasNumeros(da)
      Select Case tipo
         Case TipoSP._I
         Case TipoSP._U
            Dim _reciboComparteNumeracionEntreSucursales As Boolean
            _reciboComparteNumeracionEntreSucursales = Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales
            sql.VentasNumeros_U(vn.IdSucursal, vn.IdEmpresa, vn.IdTipoComprobante, vn.LetraFiscal, vn.CentroEmisor, vn.Numero, vn.Fecha,
                                _reciboComparteNumeracionEntreSucursales)
         Case TipoSP._D
      End Select
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub ActualizarNumero(vn As Entidades.VentaNumero)
      Try
         If vn.IdEmpresa = 0 Then
            vn.IdEmpresa = New Sucursales(da).GetUna(vn.IdSucursal, False).IdEmpresa
         End If
         EjecutaSP(vn, TipoSP._U)
      Catch ex As Exception
         Throw New Exception(String.Format("Error en VentaNumero, no se puede actualizar el {0} {1}-{2} (Empresa: {4}) - {3}", vn.IdTipoComprobante, vn.CentroEmisor, vn.Numero, ex.Message, vn.IdEmpresa), ex)
      End Try
   End Sub

   Public Sub ActualizarNumero2(vn As Entidades.VentaNumero)
      EjecutaConTransaccion(Sub() EjecutaSP(vn, TipoSP._U))
   End Sub

   Public Sub GenerarNumeracion(idSucursal As Integer, idEmpresa As Integer, centroEmisor As Short)
      Dim sql As SqlServer.VentasNumeros = New SqlServer.VentasNumeros(da)
      sql.VentasNumeros_GenerarNumeracion(idSucursal, idEmpresa, centroEmisor)
   End Sub

   Public Function GetProximoNumero(sucursal As Entidades.Sucursal,
                                    idTipoComprobante As String,
                                    letraFiscal As String,
                                    emisor As Short,
                                    Optional comparteNumeracion As Boolean = False) As Long
      Dim sql = New SqlServer.VentasNumeros(da)
      Using dt = sql.VentasNumeros_G1(sucursal.Id, sucursal.IdEmpresa, idTipoComprobante, letraFiscal, emisor, comparteNumeracion)
         Dim dr = dt.AsEnumerable().FirstOrDefault()
         Return If(dr IsNot Nothing, dr.Field(Of Integer?)("Numero").IfNull(), 0) + 1
      End Using
   End Function

   Public Function GetUno(sucursal As Entidades.Sucursal,
                          idTipoComprobante As String,
                          letraFiscal As String,
                          emisor As Short,
                          comparteNumeracion As Boolean,
                          accionSiNoExiste As AccionesSiNoExisteRegistro) As Entidades.VentaNumero
      Dim dt As DataTable = New SqlServer.VentasNumeros(da).VentasNumeros_G1(sucursal.Id, sucursal.IdEmpresa, idTipoComprobante, letraFiscal, emisor, comparteNumeracion)
      Return CargaEntidad(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaNumero(),
                          accionSiNoExiste, String.Format("No existe un numerador con Tipo ´{0}´, Letra ´{1}´ y Emisor {2}.", idTipoComprobante, letraFiscal, emisor))
   End Function


   Public Function GetUltimoNumero(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Long
      Return GetUltimoNumero(idSucursal, actual.Sucursal.IdEmpresa, idTipoComprobante, letraFiscal, emisor)
   End Function
   Public Function GetUltimoNumero(idSucursal As Integer, idEmpresa As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Long
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT Numero ")
         .AppendLine("  FROM VentasNumeros")
         .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND LetraFiscal = '" & letraFiscal & "'")
         .AppendLine("   AND CentroEmisor = " & emisor.ToString())
         .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
         .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
      End With

      Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return Long.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 0
      End If
   End Function

   Public Function GetLetrasFiscales() As DataTable
      Return New SqlServer.VentasNumeros(da).VentasNumeros_GA_LetrasFiscales(actual.Sucursal.IdEmpresa, tipo:=Nothing)
   End Function
   Public Function GetCentrosEmisores() As DataTable
      Return New SqlServer.VentasNumeros(da).VentasNumeros_GA_CentroEmisor(actual.Sucursal.IdEmpresa, tipo:=Nothing)
   End Function
   Public Function GetLetrasFiscales(tipo As Entidades.TipoComprobante.Tipos?) As DataTable
      Return New SqlServer.VentasNumeros(da).VentasNumeros_GA_LetrasFiscales(actual.Sucursal.IdEmpresa, tipo)
   End Function
   Public Function GetCentrosEmisores(tipo As Entidades.TipoComprobante.Tipos?) As DataTable
      Return New SqlServer.VentasNumeros(da).VentasNumeros_GA_CentroEmisor(actual.Sucursal.IdEmpresa, tipo)
   End Function

   Public Function GetUltimaFecha(sucursal As Entidades.Sucursal, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Date
      Return GetUltimaFecha(sucursal.IdSucursal, sucursal.IdEmpresa, idTipoComprobante, letraFiscal, emisor)
   End Function
   Public Function GetUltimaFecha(idSucursal As Integer, idEmpresa As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Date
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT Fecha ")
         .AppendLine("  FROM VentasNumeros")
         .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND LetraFiscal = '" & letraFiscal & "'")
         .AppendLine("   AND CentroEmisor = " & emisor.ToString())
         .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
         .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
         '.AppendLine("   AND Numero = " & numero.ToString())
      End With

      Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return Date.Parse(dt.Rows(0)("Fecha").ToString())
      Else
         Return Date.Parse("1900-01-01")
      End If

   End Function
   Public Function GetCompAnterior(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letraFiscal As String,
                                   emisor As Short,
                                   numero As Long) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .AppendLine(" SELECT top 1 Fecha, NumeroComprobante ")
         .AppendLine("  FROM Ventas")
         .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letraFiscal & "'")
         .AppendLine("   AND CentroEmisor = " & emisor.ToString())
         .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND NumeroComprobante < " & numero.ToString())
         .AppendLine("   ORDER BY NumeroComprobante desc ")
      End With

      Return da.GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetCompPosterior(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letraFiscal As String,
                                    emisor As Short,
                                    numero As Long) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .AppendLine(" SELECT top 1 Fecha, NumeroComprobante ")
         .AppendLine("  FROM Ventas")
         .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letraFiscal & "'")
         .AppendLine("   AND CentroEmisor = " & emisor.ToString())
         .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND NumeroComprobante > " & numero.ToString())
         .AppendLine("   ORDER BY NumeroComprobante asc ")
      End With

      Return da.GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetReciboAnterior(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letraFiscal As String,
                                     emisor As Short,
                                     numero As Long) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .AppendLine(" SELECT top 1 Fecha, NumeroComprobante ")
         .AppendLine("  FROM CuentasCorrientes")
         .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letraFiscal & "'")
         .AppendLine("   AND CentroEmisor = " & emisor.ToString())
         If idSucursal > 0 Then
            .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
         End If
         .AppendLine("   AND NumeroComprobante < " & numero.ToString())
         .AppendLine("   ORDER BY NumeroComprobante desc ")
      End With

      Return da.GetDataTable(stbQuery.ToString())
   End Function
   'Public Function GetEmisor(idSucursal As Integer, idEmpresa As Integer, idTipoComprobante As String, letraFiscal As String) As Short
   '   Dim stbQuery As StringBuilder = New StringBuilder()
   '   With stbQuery
   '      .AppendLine("SELECT CentroEmisor ")
   '      .AppendLine("  FROM VentasNumeros")
   '      .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
   '      .AppendLine("   AND LetraFiscal = '" & letraFiscal & "'")
   '      .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
   '      .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
   '   End With

   '   Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
   '   If dt.Rows.Count > 0 Then
   '      Return Short.Parse(dt.Rows(0)("Numero").ToString())
   '   Else
   '      Return 0
   '   End If

   'End Function

   Public Function GetTodos() As List(Of Entidades.VentaNumero)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaNumero())
   End Function

   Public Function GetUno(idTipoComprobante As String, letra As String, centroEmisor As Short, accionSiNoExiste As AccionesSiNoExisteRegistro) As Entidades.VentaNumero
      Dim dt As DataTable = New SqlServer.VentasNumeros(da).VentasNumeros_G1(actual.Sucursal.IdEmpresa, idTipoComprobante, letra, centroEmisor)
      Return CargaEntidad(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaNumero(),
                          accionSiNoExiste, String.Format("No existe un numerador con Tipo ´{0}´, Letra ´{1}´ y Emisor {2}.", idTipoComprobante, letra, centroEmisor))
   End Function

   Public Function GetUnoPorRelacionado(idTipoComprobanteRelacionado As String) As Entidades.VentaNumero
      Return GetUno(idTipoComprobanteRelacionado, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUno(idTipoComprobanteRelacionado As String, accionSiNoExiste As AccionesSiNoExisteRegistro) As Entidades.VentaNumero
      Dim dt As DataTable = New SqlServer.VentasNumeros(da).VentasNumeros_G1_PorRelacionado(actual.Sucursal.IdEmpresa, idTipoComprobanteRelacionado)
      Return CargaEntidad(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaNumero(),
                          accionSiNoExiste, String.Format("No existe un numerador con Tipo Relacionado ´{0}´.", idTipoComprobanteRelacionado))
   End Function

   Private Sub CargarUno(o As Entidades.VentaNumero, dr As DataRow)
      With o
         .IdEmpresa = dr.Field(Of Integer)("IdEmpresa")
         .IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
         .LetraFiscal = dr.Field(Of String)("LetraFiscal")
         .CentroEmisor = dr.Field(Of Short)("CentroEmisor")
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .Numero = dr.Field(Of Integer)("Numero")
         .IdTipoComprobanteRelacionado = dr.Field(Of String)("IdTipoComprobanteRelacionado").IfNull()
         .Fecha = dr.Field(Of Date)("Fecha")
      End With
   End Sub
   <Obsolete("", True)>
   Private Structure ControlSaltoNumeracionGrouping
      Public Property IdEmpresa As Integer
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer

      Public Sub New(idEmpresa As Integer, idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer)
         Me.IdEmpresa = idEmpresa
         Me.IdSucursal = idSucursal
         Me.IdTipoComprobante = idTipoComprobante
         Me.Letra = letra
         Me.CentroEmisor = centroEmisor
      End Sub
      Public Sub New(dr As ControlSaltoNumeracionComprobante)
         Me.New(dr.IdEmpresa, dr.IdSucursal, dr.IdTipoComprobante, dr.Letra, dr.CentroEmisor)
      End Sub
      Public Sub New(dr As DataRow)
         Me.New(dr.Field(Of Integer)("IdEmpresa"), dr.Field(Of Integer)("IdSucursal"),
                dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"), dr.Field(Of Integer)("CentroEmisor"))
      End Sub
   End Structure
   Public Class ControlSaltoNumeracionComprobante
      Public Property IdEmpresa As Integer
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroComprobante As Long

      Public Sub New(idEmpresa As Integer, idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
         Me.IdEmpresa = idEmpresa
         Me.IdSucursal = idSucursal
         Me.IdTipoComprobante = idTipoComprobante
         Me.Letra = letra
         Me.CentroEmisor = centroEmisor
         Me.NumeroComprobante = numeroComprobante
      End Sub
      Public Sub New(dr As DataRow)
         Me.New(dr, dr.Field(Of Long)("NumeroComprobante"))
      End Sub
      Public Sub New(dr As DataRow, numeroComprobante As Long)
         Me.New(dr.Field(Of Integer)("IdEmpresa"), dr.Field(Of Integer)("IdSucursal"),
                dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"), dr.Field(Of Integer)("CentroEmisor"),
                numeroComprobante)
      End Sub
      Public Sub New(dr As ControlSaltoNumeracionComprobante, numeroComprobante As Long)
         Me.New(dr.IdEmpresa, dr.IdSucursal,
                dr.IdTipoComprobante, dr.Letra, dr.CentroEmisor,
                numeroComprobante)
      End Sub
   End Class

   Public Function ControlSaltoNumeracion() As List(Of ControlSaltoNumeracionComprobante)
      Dim idEmpresa = actual.Sucursal.IdEmpresa
      Using dt = New SqlServer.VentasNumeros(da).PeriodosFiscalesParaControlSaltoNumeracion(idEmpresa)
         Return ControlSaltoNumeracion(idEmpresa, dt.AsEnumerable().ToList().ConvertAll(Function(dr) dr.Field(Of Integer)("PeriodoFiscal")))
      End Using
   End Function

   Public Function ControlSaltoNumeracion(idEmpresa As Integer, periodos As List(Of Integer)) As List(Of ControlSaltoNumeracionComprobante)
      Dim sw = New Stopwatch()
      sw.Start()
      My.Application.Log.WriteEntry(String.Format("VentasNumeros.ControlSaltoNumeracion - Inicio."), TraceEventType.Verbose)
      Dim dtResult = New List(Of ControlSaltoNumeracionComprobante)
      If periodos.Any() Then
         Dim lstVN = GetTodos()
         Dim sql = New SqlServer.VentasNumeros(da)
         Using dt = sql.GetParaControlSaltoNumeracion(idEmpresa, periodos)
            Dim lstNumeros = dt.AsEnumerable().ToList().ConvertAll(Function(dr) New ControlSaltoNumeracionComprobante(dr))
            Dim dtEnum = dt.AsEnumerable()

            'Dim ids = lstNumeros.ConvertAll(Function(dr) New ControlSaltoNumeracionComprobante(dr, 0)).Distinct()
            Dim ids = New List(Of ControlSaltoNumeracionComprobante)
            For Each dr In lstNumeros
               Dim n = New ControlSaltoNumeracionComprobante(dr, 0)
               If Not ids.Exists(Function(i) i.IdEmpresa = n.IdEmpresa AndAlso
                                             i.IdSucursal = n.IdSucursal AndAlso
                                             i.IdTipoComprobante = n.IdTipoComprobante AndAlso
                                             i.Letra = n.Letra AndAlso
                                             i.CentroEmisor = n.CentroEmisor AndAlso
                                             i.NumeroComprobante = n.NumeroComprobante) Then
                  ids.Add(n)
               End If
            Next

            For Each g In ids
               Dim w = Function(dr As DataRow) dr.Field(Of Integer)("IdEmpresa") = g.IdEmpresa And
                                               dr.Field(Of Integer)("IdSucursal") = g.IdSucursal And
                                               dr.Field(Of String)("IdTipoComprobante") = g.IdTipoComprobante And
                                               dr.Field(Of String)("Letra") = g.Letra And
                                               dr.Field(Of Integer)("CentroEmisor") = g.CentroEmisor
               Dim minimum = dtEnum.Where(w).Min(Function(dr) dr.Field(Of Long)("NumeroComprobante"))
               Dim maximum = dtEnum.Where(w).Max(Function(dr) dr.Field(Of Long)("NumeroComprobante"))
               For index = minimum To maximum
                  Dim ctrl = New ControlSaltoNumeracionComprobante(g.IdEmpresa, g.IdSucursal, g.IdTipoComprobante, g.Letra, g.CentroEmisor, index)
                  Dim drVN = lstNumeros.FirstOrDefault(Function(x) x.IdEmpresa = g.IdEmpresa And x.IdTipoComprobante = g.IdTipoComprobante And x.Letra = g.Letra And x.CentroEmisor = g.CentroEmisor And
                                                          x.NumeroComprobante = ctrl.NumeroComprobante)
                  If drVN Is Nothing Then
                     Dim vn = lstVN.FirstOrDefault(Function(x) x.IdEmpresa = g.IdEmpresa And x.IdTipoComprobante = g.IdTipoComprobante And x.LetraFiscal = g.Letra And x.CentroEmisor = g.CentroEmisor)
                     Dim existeRelacionado = False
                     If vn IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(vn.IdTipoComprobanteRelacionado) Then
                        For Each idRel In vn.IdTipoComprobanteRelacionado.Split(";"c)
                           If Not String.IsNullOrWhiteSpace(idRel) Then
                              Dim drVN1 = lstNumeros.FirstOrDefault(Function(x) x.IdEmpresa = g.IdEmpresa And x.IdTipoComprobante = idRel And x.Letra = g.Letra And x.CentroEmisor = g.CentroEmisor And
                                                                       x.NumeroComprobante = ctrl.NumeroComprobante)
                              If drVN1 IsNot Nothing Then
                                 existeRelacionado = True
                                 Exit For
                              End If
                           End If
                        Next
                     End If
                     If Not existeRelacionado Then
                        dtResult.Add(ctrl)
                     End If
                  End If
               Next
            Next
            sw.Stop()
            My.Application.Log.WriteEntry(String.Format("VentasNumeros.ControlSaltoNumeracion - Fin {0}.", sw.Elapsed.ToString()), TraceEventType.Verbose)
         End Using
      End If
      Return dtResult
   End Function

#End Region

End Class