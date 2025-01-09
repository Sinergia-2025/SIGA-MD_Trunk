Public Class Cheques
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Cheques", accesoDatos)
   End Sub

#End Region

   Public Enum OrdenadoPor
      FechaCobro
      FechaEmision
      NumeroCheque
      Proveedor
   End Enum

#Region "Metodos Publicos"
   'Private Sub SelectFiltrado(ByRef stb As StringBuilder)

   '   With stb
   '      .AppendLine("SELECT C.IdSucursal")
   '      .AppendLine("      ,C.IdCheque")
   '      .AppendLine("      ,C.IdCuentaBancaria")
   '      .AppendLine("      ,CB.NombreCuenta")
   '      .AppendLine("      ,C.NumeroCheque")
   '      .AppendLine("      ,C.IdBanco")
   '      .AppendLine("      ,B.NombreBanco")
   '      .AppendLine("      ,C.IdBancoSucursal")
   '      .AppendLine("      ,C.FechaEmision")
   '      .AppendLine("      ,C.FechaCobro")
   '      .AppendLine("      ,C.Titular")
   '      .AppendLine("      ,C.CUIT")
   '      .AppendLine("      ,C.IdLocalidad")
   '      .AppendLine("      ,L.NombreLocalidad")
   '      .AppendLine("      ,C.Importe")
   '      .AppendLine("      ,C.IdEstadoCheque")
   '      .AppendLine("      ,C.IdEstadoChequeAnt")
   '      .AppendLine("      ,C.IdCajaIngreso")
   '      .AppendLine("      ,C.NroPlanillaIngreso")
   '      .AppendLine("      ,C.NroMovimientoIngreso")
   '      .AppendLine("      ,C.IdCliente")
   '      .AppendLine("      ,Cl.NombreCliente")
   '      .AppendLine("      ,C.IdCajaEgreso")
   '      .AppendLine("      ,C.NroPlanillaEgreso")
   '      .AppendLine("      ,C.NroMovimientoEgreso")
   '      .AppendLine("      ,C.IdProveedor")
   '      .AppendLine("      ,P.CodigoProveedor")
   '      .AppendLine("      ,P.NombreProveedor")
   '      .AppendLine("      ,C.EsPropio")
   '      .AppendLine("      ,Cl.CodigoCliente")
   '      .AppendLine("      ,C.IdProveedorPreasignado")
   '      .AppendLine("      ,C.IdTipoCheque")
   '      .AppendLine("      ,C.NroOperacion")
   '      .AppendLine("      ,C.IdChequera")
   '      .AppendLine("      ,TC.NombreTipoCheque")
   '      .AppendLine("      ,PA.CodigoProveedor AS CodigoProveedorPreasignado")
   '      .AppendLine("      ,PA.NombreProveedor AS ProveedorPreasignado")
   '      '---PE-31207
   '      .AppendLine("      ,C.IdSituacionCheque")
   '      .AppendLine("      ,SC.NombreSituacionCheque")
   '      '---.
   '      .AppendLine(" FROM Cheques C")
   '      .AppendLine(" INNER JOIN TiposCheques TC ON C.IdTipoCheque = TC.IdTipoCheque")
   '      .AppendLine(" INNER JOIN Bancos B On C.IdBanco = B.IdBanco ")
   '      .AppendLine(" INNER JOIN Localidades L On C.IdLocalidad = L.IdLocalidad ")
   '      '---PE-31207
   '      .AppendLine("  LEFT JOIN SituacionCheques SC ON C.IdSituacionCheque = SC.IdSituacionCheque")
   '      '---.
   '      .AppendLine(" LEFT OUTER JOIN CuentasBancarias CB ON C.IdCuentaBancaria = CB.IdCuentaBancaria")
   '      .AppendLine(" LEFT OUTER JOIN Clientes Cl ON C.IdCliente = Cl.IdCliente ")
   '      .AppendLine(" LEFT OUTER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor ")
   '      .AppendLine(" LEFT OUTER JOIN Proveedores PA ON C.IdProveedorPreasignado = PA.IdProveedor ")
   '   End With
   'End Sub

   Public Function GetInfCheques(idSucursal As Integer, esPropio As Boolean?) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Cheques(da).GetInfCheques(idSucursal, esPropio))
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idCajaIngreso As Integer,
                            fechaCobroDesde As Date,
                            fechaCobroHasta As Date,
                            tipoMovimiento As String,
                            idBanco As Integer,
                            idLocalidad As Integer,
                            esPropio As Boolean) As DataTable
      Dim sql = New SqlServer.Cheques(da)
      Return sql.GetTodos(idSucursal,
                          idCajaIngreso,
                          fechaCobroDesde,
                          fechaCobroHasta,
                          tipoMovimiento,
                          idBanco,
                          idLocalidad,
                          esPropio)
   End Function

   Public Function GetTodos() As List(Of Entidades.Cheque)
      Return EjecutaConConexion(Function() _GetTodos())
   End Function
   Public Function _GetTodos() As List(Of Entidades.Cheque)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque())
   End Function

   '# Get1 por Nueva PK (IdCheque)
   Public Function GetUno(idCheque As Long) As Entidades.Cheque
      Dim sql = New SqlServer.Cheques(da)
      Return CargaEntidad(sql.Get1(idCheque),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe el Cheque {0}", idCheque))
   End Function

   Friend Function _GetUnoPorNumeroCheque(idSucursal As Integer, numeroCheque As Integer, idBanco As Integer,
                         idBancoSucursal As Integer, idLocalidad As Integer) As Entidades.Cheque

      Dim o As Entidades.Cheque = Nothing
      Dim sql As SqlServer.Cheques
      Dim dt As DataTable

      sql = New SqlServer.Cheques(da)
      dt = sql.Get1PorNumeroCheque(idSucursal, numeroCheque, idBanco, idBancoSucursal, idLocalidad)
      If dt.Rows.Count > 0 Then
         o = New Entidades.Cheque()
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetUno(idSucursal As Integer, numeroCheque As Integer, idBanco As Integer,
                          idBancoSucursal As Integer, idLocalidad As Integer) As Entidades.Cheque
      Return EjecutaConConexion(Function() _GetUnoPorNumeroCheque(idSucursal, numeroCheque, idBanco, idBancoSucursal, idLocalidad))
   End Function

   Public Function GetInforme(
         sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(), estados As Entidades.EstadoCheque(),
         fechaCobroDesde As Date, fechaCobroHasta As Date, fechaEnCarteraAl As Date,
         numero As Long, idBanco As Integer, idLocalidad As Integer, esPropio As Boolean,
         idCliente As Long, idProveedor As Long, titular As String,
         fechaIngresoDesde As Date, fechaIngresoHasta As Date,
         idCuentaBancaria As Integer, orden As Entidades.Cheque.Ordenamiento, tipoCheque As String, conciliado As Boolean?,
         observacion As String) As DataTable

      Return New SqlServer.Cheques(da).GetInforme(
                     sucursales, cajas, estados,
                     fechaCobroDesde, fechaCobroHasta, fechaEnCarteraAl,
                     numero, idBanco, idLocalidad, esPropio,
                     idCliente, idProveedor, titular,
                     fechaIngresoDesde, fechaIngresoHasta,
                     idCuentaBancaria, orden, tipoCheque,
                     conciliado, observacion)
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

      Dim sql As SqlServer.Cheques = New SqlServer.Cheques(da)
      Return sql.GetChequesDetalleAyuda(idSucursal,
                                        IdCaja,
                                        FechaCobroDesde,
                                        FechaCobroHasta,
                                        FechaEnCarteraAl,
                                        Numero,
                                        IdBanco,
                                        IdLocalidad,
                                        EsPropio,
                                        IdCliente,
                                        IdProveedor,
                                        Titular,
                                        TipoMovimiento,
                                        tipoCheque)
   End Function

   'Public Function GetFiltradoPor(fechaCobroDesde As DateTime,
   '                                  fechaCobroHasta As DateTime,
   '                                  cuenta As Entidades.CuentaBancaria,
   '                                  ordenadoPor As OrdenadoPor,
   '                                  esPropio As Boolean) As List(Of Entidades.Cheque)

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   Me.SelectFiltrado(stb)

   '   With stb

   '      .AppendLine("	WHERE C.FechaCobro >= '" & fechaCobroDesde.ToString("yyyyMMdd") & " 00:00:00'")
   '      .AppendLine("	  AND C.FechaCobro <= '" & fechaCobroHasta.ToString("yyyyMMdd") & " 23:59:59'")

   '      .AppendLine("	AND C.EsPropio = '" & esPropio.ToString() & "'")

   '      If cuenta IsNot Nothing Then
   '         .AppendLine("	AND C.IdCuentaBancaria = " & cuenta.IdCuentaBancaria)
   '      End If

   '      Select Case ordenadoPor
   '         Case Cheques.OrdenadoPor.FechaCobro
   '            .AppendLine("	ORDER BY C.FechaCobro")
   '         Case Cheques.OrdenadoPor.FechaEmision
   '            .AppendLine("	ORDER BY C.FechaEmision")
   '         Case Cheques.OrdenadoPor.NumeroCheque
   '            .AppendLine("	ORDER BY C.NumeroCheque")
   '      End Select
   '   End With

   '   Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
   '   Dim o As Entidades.Cheque
   '   Dim oLis As List(Of Entidades.Cheque) = New List(Of Entidades.Cheque)
   '   For Each dr As DataRow In dt.Rows
   '      o = New Entidades.Cheque()
   '      Me.CargarUno(o, dr)
   '      oLis.Add(o)
   '   Next

   '   Return oLis

   'End Function

   Public Function GetSaldoCheqPropio(fechaCobroDesde As DateTime,
                                     fechaCobroHasta As DateTime,
                                     suc As List(Of Integer),
                                     esPropio As Boolean) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Cheques(da).GetSaldoCheqPropio(fechaCobroDesde, fechaCobroHasta, suc, esPropio))
   End Function

   Public Sub DesasociarChequesAMovimiento(idSucursal As Integer,
                                           tipoMovimiento As String,
                                           numeroCheque As Integer,
                                           idBanco As Integer,
                                           idBancoSucursal As Integer,
                                           idLocalidad As Integer,
                                           idCheque As Long)
      Dim sql = New SqlServer.Cheques(da)
      sql.Cheques_UDesasociarNroMovimiento(idSucursal,
                                             tipoMovimiento,
                                             idBanco,
                                             idBancoSucursal,
                                             idLocalidad,
                                             numeroCheque,
                                             actual.Nombre,
                                             idCheque)

   End Sub

   Public Function RecuperarEstadosChequeAnteriores(idCheque As Long) As Entidades.Cheque
      Dim sql = New SqlServer.Cheques(da)
      Dim dt As DataTable = sql.RecuperarEstadosChequeAnteriores(idCheque)
      If dt.Rows.Count > 0 Then
         For Each dr As DataRow In dt.Rows
            Return New Entidades.Cheque With {.IdEstadoCheque = DirectCast([Enum].Parse(GetType(Entidades.Cheque.Estados), dr("IdEstadoCheque").ToString()), Entidades.Cheque.Estados),
                                              .IdEstadoChequeAnt = DirectCast([Enum].Parse(GetType(Entidades.Cheque.Estados), dr("IdEstadoChequeAnt").ToString()), Entidades.Cheque.Estados)}
         Next
      End If
      Return Nothing
   End Function

   Public Sub AsociarChequesAMovimientoIngreso(ent As Entidades.Cheque, IdCaja As Integer, NroPlanilla As Integer, NroMovimiento As Integer)

      Dim sql = New SqlServer.Cheques(da)

      'PE-30441 - Adaptar pantalla a nueva clave primaria de Cheques - Revision 15959
      'PE-30657 - No se pueden realizar movimientos con chequeres cargados en ABM Cheques de Terceros
      'Se realiza la incorporacion de Nro de CUIT.- No se sabe el motivo del comentario de IDCheque.-
      '-- REQ-32653.- --
      sql.Cheques_UAsociarNroMovimientoIngreso(ent.IdSucursal,
                                                IdCaja,
                                                NroPlanilla,
                                                NroMovimiento,
                                                ent.Banco.IdBanco,
                                                ent.IdBancoSucursal,
                                                ent.Localidad.IdLocalidad,
                                                ent.NumeroCheque,
                                                ent.IdEstadoCheque,
                                                ent.Cliente.IdCliente,
                                                actual.Nombre, ent.Cuit) ', ent.IdCheque)

   End Sub

   Public Sub AsociarChequesAMovimientoEgreso(ent As Entidades.Cheque, IdCaja As Integer, NroPlanilla As Integer, NroMovimiento As Integer)

      Dim sql As SqlServer.Cheques = New SqlServer.Cheques(da)

      sql.Cheques_UAsociarNroMovimientoEgreso(ent.IdSucursal,
                                                IdCaja,
                                                NroPlanilla,
                                                NroMovimiento,
                                                ent.Banco.IdBanco,
                                                ent.IdBancoSucursal,
                                                ent.Localidad.IdLocalidad,
                                                ent.NumeroCheque,
                                                ent.IdEstadoCheque,
                                                ent.Proveedor.IdProveedor,
                                                actual.Nombre,
                                                ent.IdCheque)

   End Sub

   Public Function GetChequesDeMovimiento(idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer, esPropio As Boolean) As DataTable
      Return New SqlServer.Cheques(da).GetChequesDeMovimiento(idSucursal, idCaja, nroPlanilla, nroMovimiento, esPropio)
   End Function

   Public Function GetPorComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As List(Of Entidades.Cheque)
      Return CargaLista(New SqlServer.Cheques(da).GetPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque())
   End Function

   Public Function GetPorComprobanteCtaCte(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As List(Of Entidades.Cheque)
      Return CargaLista(New SqlServer.Cheques(da).GetPorComprobanteCtaCte(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque())
   End Function

   Public Function GetPorComprobanteCompraCH(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                             esPropio As Boolean) As List(Of Entidades.Cheque)
      Return CargaLista(New SqlServer.Cheques(da).GetPorComprobanteCompraCH(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante, esPropio),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque())
   End Function

   Public Function GetRechazadosPorComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As List(Of Entidades.Cheque)
      Return CargaLista(New SqlServer.Cheques(da).GetRechazadosPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque())
   End Function

   'El método no se estaría usando por lo que lo comento para estar seguro.
   'De tener que habilitarlo debemos agregar en el sql el campo NombreSituacionCheque a la consulta.
   'Public Function GetPorMovimientoCaja(idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer,
   '                                     esPropio As Boolean) As List(Of Entidades.Cheque)

   '   Dim sql As SqlServer.Cheques = New SqlServer.Cheques(da)

   '   Dim dt As DataTable = sql.GetPorMovimientoCaja(idSucursal, idCaja, nroPlanilla, nroMovimiento, esPropio)

   '   Dim o As Entidades.Cheque

   '   Dim oLis As List(Of Entidades.Cheque) = New List(Of Entidades.Cheque)
   '   For Each dr As DataRow In dt.Rows
   '      o = New Entidades.Cheque()
   '      Me.CargarUno(o, dr)
   '      oLis.Add(o)
   '   Next
   '   Return oLis

   'End Function

   Public Function GetCantChequesEgresados(idSucursal As Integer, nroPlanillaIngreso As Integer, nroMovimientoIngreso As Integer, esPropio As Boolean) As Integer
      Return New SqlServer.Cheques(da).GetCantChequesEgresados(idSucursal, nroPlanillaIngreso, nroMovimientoIngreso, esPropio)
   End Function

   Public Function GetChequesAplicados(idSucursal As Integer,
                                        IdCaja As Integer,
                                        nroPlanillaIngreso As Integer,
                                        nroMovimientoIngreso As Integer,
                                        tipoMovimiento As String,
                                        esPropio As Boolean) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .Append("SELECT C.NumeroCheque, ")
         .Append("   	C.IdBanco, ")
         .Append("   	B.NombreBanco, ")
         .Append("   	C.IdBancoSucursal, ")
         .Append("   	C.FechaEmision, ")
         .Append("   	C.FechaCobro, ")
         .Append("   	C.Titular, ")
         .Append("   	C.IdLocalidad, ")
         .Append("   	C.Importe, ")
         .Append("   	C.IdCajaIngreso, ")
         .Append("   	C.NroPlanillaIngreso, ")
         .Append("   	C.NroMovimientoIngreso, ")
         .Append("   	C.IdCajaEgreso, ")
         .Append("   	C.NroPlanillaEgreso, ")
         '-- REQ-31720.- --
         .Append("   	C.IdCheque, ")

         .Append("   	C.NroMovimientoEgreso ")
         .Append("   From Cheques C Inner Join Bancos B On C.IdBanco = B.IdBanco ")

         .Append(" WHERE IdSucursal = " & idSucursal.ToString())
         .Append("    AND C.EsPropio = " & IIf(esPropio, 1, 0).ToString())

         'Para ingreso no hace falta preguntar
         If tipoMovimiento = "I" Then
            .Append("   AND IdCajaIngreso = " & IdCaja.ToString())
            .Append("   AND NroPlanillaIngreso = " & nroPlanillaIngreso.ToString())
            .Append("   AND NroMovimientoIngreso = " & nroMovimientoIngreso.ToString())
            .Append("   AND NroPlanillaEgreso IS NULL")
         Else
            .Append("   AND IdCajaEgreso = " & IdCaja.ToString())
            .Append("   AND NroPlanillaEgreso = " & nroPlanillaIngreso.ToString())
            .Append("   AND NroMovimientoEgreso = " & nroMovimientoIngreso.ToString())
         End If
      End With

      Return da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetPorCuentaCorriente(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As List(Of Entidades.Cheque)
      Return CargaLista(New SqlServer.Cheques(da).GetPorCuentaCorriente(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque())
   End Function

   Public Function GetPorCuentaCorrienteProv(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                             esPropio As Boolean) As List(Of Entidades.Cheque)
      Return CargaLista(New SqlServer.Cheques(da).GetPorCuentaCorrienteProv(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante, esPropio),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque())
   End Function

   Public Function GetPorDeposito(idSucursal As Integer, idTipoComprobante As String, numeroDeposito As Long,
                                  esPropio As Boolean?) As List(Of Entidades.Cheque)
      Return CargaLista(New SqlServer.Cheques(da).GetPorDeposito(idSucursal, idTipoComprobante, numeroDeposito, esPropio),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Cheque())
   End Function

   Public Function Buscar2(entidad As Entidades.Buscar, esPropio As Boolean) As DataTable
      Return New SqlServer.Cheques(da).Buscar(entidad.Columna, entidad.Valor.ToString(), esPropio)
   End Function

   Public Function GetChequesADepositar(idSucursal As Integer, alDia As DateTime) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Cheques(da).GetChequesADepositar(idSucursal, alDia))
   End Function

   Public Function GetUltimoEmitido(IdCuentaBancaria As Integer) As Long

      Dim sql As SqlServer.Cheques = New SqlServer.Cheques(da)
      Dim dt As DataTable = sql.Cheques_GetUltimoEmitido(IdCuentaBancaria)
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   'Public Sub MoverChequesEntreSucursales( cheques As List(Of Entidades.Cheque),  cajaIngreso As Integer)

   '   Dim sqlChe As SqlServer.Cheques
   '   Try
   '      Me.da.OpenConection()
   '      Me.da.BeginTransaction()

   '      Dim suc As Integer = cheques(0).IdSucursal
   '      Dim NombreSuc As String = New Reglas.Sucursales(da).GetUna(cheques(0).IdSucursal).Nombre

   '      Dim suc2 As Integer = cheques(0).IdSucursal2
   '      Dim NombreSuc2 As String = New Reglas.Sucursales(da).GetUna(cheques(0).IdSucursal2).Nombre

   '      Dim totalCheques As Decimal = 0

   '      Dim ctaCaj As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas(da)
   '      Dim cajaDet As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)

   '      Dim detaI As Entidades.CajaDetalles
   '      Dim detaE As Entidades.CajaDetalles

   '      sqlChe = New SqlServer.Cheques(da)

   '      Dim cntb As Contabilidad
   '      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
   '         cntb = New Contabilidad(da)
   '      End If

   '      'hago los movimientos en los cheques
   '      For Each ch As Entidades.Cheque In cheques
   '         With ch
   '            If sqlChe.Existe(.IdSucursal2, .NumeroCheque, .IdBanco, .IdBancoSucursal, .Localidad.IdLocalidad) Then
   '            Else
   '               sqlChe.Cheques_I(.IdSucursal2, .IdBanco, .IdBancoSucursal, .Localidad.IdLocalidad, _
   '                                 .NumeroCheque, .FechaEmision, .FechaCobro, .Titular, .Importe, _
   '                                 0, 0, 0, 0, 0, 0, .EsPropio, _
   '                                 .IdCuentaBancaria, Cheque.Estados.ENCARTERA, .Cliente.IdCliente, _
   '                                 .Proveedor.IdProveedor, .Cuit)
   '            End If
   '         End With
   '      Next

   '      For Each ch As Entidades.Cheque In cheques
   '         totalCheques += ch.Importe
   '      Next

   '      'realizo el egreso en la sucursal origen de la caja -------------------------------------------
   '      detaE = New Entidades.CajaDetalles(suc, cheques(0).Usuario, cheques(0).Password)
   '      With detaE
   '         .FechaMovimiento = DateTime.Now
   '         .IdSucursal = suc
   '         .IdCaja = cheques(0).IdCajaIngreso
   '         .IdTipoMovimiento = "E"c
   '         .NumeroPlanilla = New Reglas.Cajas(da).GetPlanillaActual(suc, .IdCaja).NumeroPlanilla
   '         .NumeroMovimiento = cajaDet.GetProximoNumeroDeMovimiento(suc, .IdCaja, .NumeroPlanilla)
   '         '.Observacion = "Movimiento de egreso de cheques a otra sucursal."
   '         .Observacion = "Sucursal Destino: " & NombreSuc2 & " - Cantidad Cheques: " & cheques.Count.ToString()

   '         .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CTACAJAMOVCHEQUES.ToString(), "7"))

   '         .ImportePesos = 0
   '         .ImporteTarjetas = 0
   '         .ImporteTickets = 0
   '         'cambio el monto porque es un egreso
   '         .ImporteCheques = totalCheques * -1
   '         .EsModificable = False
   '      End With
   '      ' Insertar nuevo movimiento
   '      cajaDet.InsertarNuevoMovimiento(detaE)
   '      ' Asociar Cheques de Terceros
   '      For Each ch As Entidades.Cheque In cheques
   '         With ch
   '            sqlChe.Cheques_UAsociarNroMovimientoEgreso(.IdSucursal, detaE.IdCaja, detaE.NumeroPlanilla, _
   '                                                         detaE.NumeroMovimiento, .IdBanco, .IdBancoSucursal, _
   '                                                      .Localidad.IdLocalidad, .NumeroCheque, _
   '                                                      Cheque.Estados.EGRESOCAJA, 0)
   '         End With
   '      Next

   '      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
   '         cntb.RegistraContabilidad(detaE)
   '      End If

   '      '-------------------------------------------

   '      'realizo el ingreso en la sucursal destino -------------------------------------------
   '      detaI = New Entidades.CajaDetalles(suc2, cheques(0).Usuario, cheques(0).Password)
   '      With detaI
   '         .FechaMovimiento = DateTime.Now
   '         .IdSucursal = suc2
   '         .IdCaja = cajaIngreso
   '         .IdTipoMovimiento = "I"c
   '         .NumeroPlanilla = New Reglas.Cajas(da).GetPlanillaActual(suc2, cajaIngreso).NumeroPlanilla
   '         .NumeroMovimiento = cajaDet.GetProximoNumeroDeMovimiento(suc2, cajaIngreso, .NumeroPlanilla)
   '         '.Observacion = "Movimiento de ingreso de cheques desde otra sucursal."
   '         .Observacion = "Sucursal Origen: " & NombreSuc & " - Cantidad Cheques: " & cheques.Count.ToString()
   '         .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CTACAJAMOVCHEQUES.ToString(), "7"))
   '         .ImportePesos = 0
   '         .ImporteTarjetas = 0
   '         .ImporteTickets = 0
   '         .ImporteCheques = totalCheques
   '         .EsModificable = False
   '      End With
   '      ' Insertar nuevo movimiento
   '      cajaDet.InsertarNuevoMovimiento(detaI)
   '      ' Asociar Cheques de Terceros
   '      'cajaDet.AsociarChequesTercerosAMovimiento(Publicos.ConvierteChequesTercerosEnArray(cheques), detaI)
   '      For Each ch As Entidades.Cheque In cheques
   '         With ch
   '            sqlChe.Cheques_UAsociarNroMovimientoIngreso(.IdSucursal2, detaI.IdCaja, detaI.NumeroPlanilla, _
   '                                                         detaI.NumeroMovimiento, .IdBanco, .IdBancoSucursal, _
   '                                                      .Localidad.IdLocalidad, .NumeroCheque, _
   '                                                      Cheque.Estados.ENCARTERA, 0)
   '         End With
   '      Next

   '      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
   '         cntb.RegistraContabilidad(detaI)
   '      End If
   '      '-------------------------------------------

   '      Me.da.CommitTransaction()
   '   Catch ex As Exception
   '      Me.da.RollbakTransaction()
   '      Throw
   '   Finally
   '      Me.da.CloseConection()
   '   End Try
   'End Sub

#End Region

#Region "Metodos Privados"

   Private Sub CargarUno(o As Entidades.Cheque, dr As DataRow)

      With o
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         '.Sucursal = New Reglas.Sucursales(da).GetUna(integer.Parse(dr("idSucursal").ToString()))

         '# PK Nueva
         .IdCheque = dr.Field(Of Long)(Entidades.Cheque.Columnas.IdCheque.ToString())

         '# PK Anterior
         .NumeroCheque = Integer.Parse(dr("NumeroCheque").ToString())
         .Banco = New Reglas.Bancos(da).GetUno(Integer.Parse(dr("IdBanco").ToString()))
         .IdBancoSucursal = Integer.Parse(dr("IdBancoSucursal").ToString())
         .Localidad = New Reglas.Localidades(da).GetUna(Integer.Parse(dr("IdLocalidad").ToString()))

         .FechaEmision = DateTime.Parse(dr("FechaEmision").ToString())
         .FechaCobro = DateTime.Parse(dr("FechaCobro").ToString())
         .Titular = dr("Titular").ToString()
         .Importe = Decimal.Parse(dr("Importe").ToString())

         If Not String.IsNullOrEmpty(dr("NroPlanillaIngreso").ToString()) Then
            .IdCajaIngreso = Integer.Parse(dr("IdCajaIngreso").ToString())
            .NroPlanillaIngreso = Integer.Parse(dr("NroPlanillaIngreso").ToString())
            .NroMovimientoIngreso = Integer.Parse(dr("NroMovimientoIngreso").ToString())
         Else
            .IdCajaIngreso = 0
            .NroPlanillaIngreso = 0
            .NroMovimientoIngreso = 0
         End If

         If Not String.IsNullOrEmpty(dr("IdCliente").ToString()) Then
            .Cliente = New Reglas.Clientes(da)._GetUno(Long.Parse(dr("IdCliente").ToString()), False)
         End If

         If Not String.IsNullOrEmpty(dr("NroPlanillaEgreso").ToString()) Then
            .IdCajaEgreso = Integer.Parse(dr("IdCajaEgreso").ToString())
            .NroPlanillaEgreso = Integer.Parse(dr("NroPlanillaEgreso").ToString())
            .NroMovimientoEgreso = Integer.Parse(dr("NroMovimientoEgreso").ToString())
         Else
            .IdCajaEgreso = 0
            .NroPlanillaEgreso = 0
            .NroMovimientoEgreso = 0
         End If

         If Not String.IsNullOrEmpty(dr("IdProveedor").ToString()) Then
            .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dr("IdProveedor").ToString()))
         End If

         .EsPropio = Boolean.Parse(dr("EsPropio").ToString())

         If Not String.IsNullOrEmpty(dr("IdCuentaBancaria").ToString()) Then
            .CuentaBancaria = New Reglas.CuentasBancarias(da).GetUna(Integer.Parse(dr("IdCuentaBancaria").ToString()))
         End If

         .IdEstadoCheque = DirectCast([Enum].Parse(GetType(Eniac.Entidades.Cheque.Estados), dr("IdEstadoCheque").ToString()), Entidades.Cheque.Estados)

         If Not String.IsNullOrEmpty(dr("IdEstadoChequeAnt").ToString()) Then
            .IdEstadoChequeAnt = DirectCast([Enum].Parse(GetType(Entidades.Cheque.Estados), dr("IdEstadoChequeAnt").ToString()), Entidades.Cheque.Estados)
         End If
         .Cuit = dr("Cuit").ToString()

         If dr.Table.Columns.Contains("FotoFrente") Then
            If Not String.IsNullOrEmpty(dr("FotoFrente").ToString()) Then
               Dim content() As Byte = CType(dr("FotoFrente"), Byte())
               Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
               .FotoFrente = New System.Drawing.Bitmap(stream)
            End If
         End If

         If dr.Table.Columns.Contains("FotoDorso") Then
            If Not String.IsNullOrEmpty(dr("FotoDorso").ToString()) Then
               Dim content() As Byte = CType(dr("FotoDorso"), Byte())
               Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
               .FotoDorso = New System.Drawing.Bitmap(stream)
            End If
         End If

         If IsNumeric(dr("IdProveedorPreasignado")) Then
            .IdProveedorPreasignado = Long.Parse(dr("IdProveedorPreasignado").ToString())
         End If
         If dr.Table.Columns.Contains("CodigoProveedorPreasignado") AndAlso IsNumeric(dr("CodigoProveedorPreasignado")) Then
            .CodigoProveedorPreasignado = Long.Parse(dr("CodigoProveedorPreasignado").ToString())
         End If

         If dr.Table.Columns.Contains("ProveedorPreasignado") Then
            .ProveedorPreasignado = dr("ProveedorPreasignado").ToString()
         End If

         '# Tipo Cheque y Nro Operación
         .IdTipoCheque = dr.Field(Of String)(Entidades.Cheque.Columnas.IdTipoCheque.ToString())
         .NombreTipoCheque = dr.Field(Of String)(Entidades.TiposCheques.Columnas.NombreTipoCheque.ToString())
         .NroOperacion = dr.Field(Of String)(Entidades.Cheque.Columnas.NroOperacion.ToString())

         .IdChequera = dr.Field(Of Integer?)(Entidades.Cheque.Columnas.IdChequera.ToString())

         'PE-31207
         .IdSituacionCheque = dr.Field(Of Integer)("IdSituacionCheque")
         .NombreSituacionCheque = dr.Field(Of String)(Entidades.SituacionCheque.Columnas.NombreSituacionCheque.ToString())
         .Observacion = dr.Field(Of String)(Entidades.Cheque.Columnas.Observacion.ToString())

      End With

   End Sub

   Public Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim ch As Entidades.Cheque = DirectCast(entidad, Entidades.Cheque)

      Dim sql As SqlServer.Cheques = New SqlServer.Cheques(da)

      Dim libro As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)

      Select Case tipo

         Case TipoSP._I

            '# Get IdCheque
            ch.IdCheque = sql.GetCodigoMaximo(Entidades.Cheque.Columnas.IdCheque.ToString(), "ChequesHistorial") + 1
            '---------------------------------------------------------------------------------------------------

            If ch.IdSituacionCheque = 0 Then
               ch.IdSituacionCheque = New SituacionCheques().GetPorDefecto().IdSituacionCheque
            End If

            sql.Cheques_I(ch.IdSucursal, ch.IdCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad,
                        ch.NumeroCheque, ch.FechaEmision, ch.FechaCobro, ch.Titular, ch.Importe,
                        ch.IdCajaIngreso, ch.NroPlanillaIngreso, ch.NroMovimientoIngreso, ch.IdCajaEgreso, ch.NroPlanillaEgreso,
                        ch.NroMovimientoEgreso, ch.EsPropio, ch.CuentaBancaria.IdCuentaBancaria, ch.IdEstadoCheque,
                        ch.Cliente.IdCliente, ch.Proveedor.IdProveedor, ch.Cuit, ch.IdProveedorPreasignado, actual.Nombre,
                        ch.IdTipoCheque, ch.NroOperacion, ch.IdChequera, ch.IdSituacionCheque, ch.Observacion)

            sql.GrabarFotoFrente(ch.FotoFrente, ch.IdSucursal, ch.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.NumeroCheque, ch.IdCheque)
            sql.GrabarFotoDorso(ch.FotoDorso, ch.IdSucursal, ch.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.NumeroCheque, ch.IdCheque)

            If ch.CajaDetalleParaIngresoDirectoPorABM IsNot Nothing Then

               Dim oCajaDetalle As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)
               ch.IdEstadoCheque = DirectCast([Enum].Parse(GetType(Entidades.Cheque.Estados), IIf(ch.CajaDetalleParaIngresoDirectoPorABM.IdTipoMovimiento = "I"c, Entidades.Cheque.Estados.ENCARTERA.ToString(), Entidades.Cheque.Estados.EGRESOCAJA.ToString()).ToString()), Entidades.Cheque.Estados)
               Dim eCheques = New List(Of Entidades.Cheque)()
               eCheques.Add(ch)
               oCajaDetalle.AgregaMovimiento(ch.CajaDetalleParaIngresoDirectoPorABM, eCheques, Nothing)
            End If

         Case TipoSP._U

            sql.Cheques_U(ch.IdSucursal, ch.IdCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad,
                           ch.NumeroCheque, ch.FechaEmision, ch.FechaCobro, ch.Titular, ch.Importe,
                           ch.IdCajaIngreso, ch.NroPlanillaIngreso, ch.NroMovimientoIngreso, ch.IdCajaEgreso, ch.NroPlanillaEgreso,
                           ch.NroMovimientoEgreso, ch.Cliente.IdCliente,
                           ch.Proveedor.IdProveedor, ch.Cuit, ch.IdProveedorPreasignado, actual.Nombre,
                           ch.IdTipoCheque, ch.NroOperacion, ch.IdChequera, ch.IdSituacionCheque, ch.Observacion)

            sql.GrabarFotoFrente(ch.FotoFrente, ch.IdSucursal, ch.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.NumeroCheque, ch.IdCheque)

            sql.GrabarFotoDorso(ch.FotoDorso, ch.IdSucursal, ch.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.NumeroCheque, ch.IdCheque)

            libro.LibroBancos_UFechaCobro(ch.IdCheque, ch.FechaCobro)

            If ch.CajaDetalleParaIngresoDirectoPorABM IsNot Nothing Then

               Dim oCajaDetalle As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)
               ch.IdEstadoCheque = DirectCast([Enum].Parse(GetType(Entidades.Cheque.Estados), IIf(ch.CajaDetalleParaIngresoDirectoPorABM.IdTipoMovimiento = "I"c, Entidades.Cheque.Estados.ENCARTERA.ToString(), Entidades.Cheque.Estados.EGRESOCAJA.ToString()).ToString()), Entidades.Cheque.Estados)
               Dim eCheques = New List(Of Entidades.Cheque)()
               eCheques.Add(ch)
               oCajaDetalle.AgregaMovimiento(ch.CajaDetalleParaIngresoDirectoPorABM, eCheques, Nothing)
            End If

         Case TipoSP._D
            sql.Cheques_D(ch.IdCheque)
      End Select

   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Modifica(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Elimina(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim blnCheqPropio As Boolean = False
      Return GetAll2(actual.Sucursal.Id, blnCheqPropio)
   End Function

   Public Function GetAll2(idSucursal As Integer, esPropio As Boolean) As System.Data.DataTable
      Return New SqlServer.Cheques(da).Cheques_GA(idSucursal, esPropio)
   End Function

   Public Function _Existe(idSucursal As Integer,
                            NumeroCheque As Integer,
                            IdBanco As Integer,
                            IdBancoSucursal As Integer,
                            IdLocalidad As Integer,
                           cuit As String) As Boolean
      Dim sql As SqlServer.Cheques = New SqlServer.Cheques(da)
      Return sql.Existe(idSucursal, NumeroCheque, IdBanco, IdBancoSucursal, IdLocalidad, cuit)
   End Function

   Public Function Existe(idSucursal As Integer,
                            NumeroCheque As Integer,
                            IdBanco As Integer,
                            IdBancoSucursal As Integer,
                            IdLocalidad As Integer,
                          cuit As String) As Boolean

      Try
         Me.da.OpenConection()

         Return Me._Existe(idSucursal, NumeroCheque, IdBanco, IdBancoSucursal, IdLocalidad, cuit)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetSaldoChequesEnCartera(IdSucursal As Integer,
                                              IdCaja As Integer) As Decimal

      Dim sql As SqlServer.Cheques

      Try
         Dim Saldo As Decimal

         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Cheques(da)
         Saldo = sql.GetSaldoChequesEnCartera(IdSucursal, IdCaja)

         Me.da.CommitTransaction()

         Return Saldo

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetIdByNumeroDeCheque(idSucursal As Integer,
                                         numeroCheque As Long,
                                         idBanco As Integer,
                                         idBancoSucursal As Integer,
                                         idLocalidad As Integer) As Long
      Dim result As Long = 0
      Dim dt As DataTable = New SqlServer.Cheques(da).GetIdByNumeroDeCheque(idSucursal, numeroCheque, idBanco, idBancoSucursal, idLocalidad)
      If dt.Rows.Count > 0 Then result = dt.Rows(0).Field(Of Long)(Entidades.Cheque.Columnas.IdCheque.ToString())
      Return result
   End Function
#End Region
End Class