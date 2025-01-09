Imports System.Globalization
Imports System.Text
Imports Eniac.Entidades.JSonEntidades.Turismo
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class CuentasCorrientesCheques
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Private _cache As BusquedasCacheadas

   Public Sub New()
      Me.NombreEntidad = "CuentasCorrientesCheques"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CuentasCorrientesCheques"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Public Sub GrabaCuentaCorrienteCheque(ByVal ctacte As Entidades.CuentaCorriente, ByVal cheque As Entidades.Cheque)

      Dim sql As SqlServer.CuentasCorrientesCheques = New SqlServer.CuentasCorrientesCheques(Me.da)

      With ctacte
         sql.CuentasCorrientesCheques_I(.IdSucursal, .TipoComprobante.IdTipoComprobante, .Letra,
                                       .CentroEmisor, .NumeroComprobante, cheque.IdCheque)
      End With

   End Sub

   Public Sub Eliminar(ByVal ctacte As Entidades.CuentaCorriente)

      Dim sql As SqlServer.CuentasCorrientesCheques = New SqlServer.CuentasCorrientesCheques(Me.da)

      With ctacte
         sql.CuentasCorrientesCheques_D(.IdSucursal, .TipoComprobante.IdTipoComprobante, .Letra,
                                       .CentroEmisor, .NumeroComprobante)
      End With

   End Sub
   Public Function ObtieneFormatFile(rangoExcel As String, origenExcel As String, bancoOrig As String, ByRef _result As Integer) As DataTable
      _cache = New BusquedasCacheadas()

      Dim dt = CrearDT()
      Dim drCl As DataRow
      Dim fecha As Date

      Using ConexionExcel As System.Data.OleDb.OleDbConnection = Publicos.AbrirExcel(origenExcel)
         ConexionExcel.Open()
         Using da = New System.Data.OleDb.OleDbDataAdapter("Select * From " + rangoExcel, ConexionExcel)
            Using ds = New DataSet()
               da.Fill(ds)

               Dim lineaProcesada As Long = 0

               Try
                  For Each drE As DataRow In ds.Tables(0).Rows
                     lineaProcesada += 1

                     Dim Accion As String = "A"
                     Dim Mensaje As StringBuilder = New StringBuilder()

                     Dim Importa As Boolean = True

                     drCl = dt.NewRow()

                     Select Case bancoOrig
                        Case Reglas.Publicos.BancosImportacionCheques.MACRO.ToString()
                           '-- Valida CUIT.- -------------------------------------------------------------------------------------------------------------------------------------------------------- 
                           Dim CUITCliente As String = drE(6).ToString()
                           '-- Carga Razon Social.- --
                           drCl(Entidades.CuentaCorrienteCheque.Columnas.RazonSocial.ToString()) = drE(4).ToString().Truncar(40)
                           drCl("CUIT") = CUITCliente
                           '--------------------------
                           If IsNumeric(CUITCliente) AndAlso Convert.ToInt64(CUITCliente) > 0 Then
                              Dim drTemp = _cache._BuscaClienteporCUIT(CUITCliente)

                              If drTemp Is Nothing OrElse drTemp.Length = 0 Then
                                 Accion = "X"
                                 Mensaje.AppendFormat("No existe el CUIT del Cliente - ")
                                 _result += 1
                              Else
                                 If drTemp.Length > 1 Then
                                    Accion = "X"
                                    Mensaje.AppendFormat("El CUIT esta signado a mas de un Cliente. No es valido. - ")
                                    _result += 1
                                 Else
                                    drCl("IdCliente") = drTemp(0)(Entidades.Cliente.Columnas.IdCliente.ToString())
                                    drCl("CodigoCliente") = drTemp(0)(Entidades.Cliente.Columnas.CodigoCliente.ToString())
                                    drCl(Entidades.CuentaCorrienteCheque.Columnas.RazonSocial.ToString()) = drTemp(0).Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())
                                 End If
                              End If
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El formato del CUIT del Cliente no es valido. - ")
                              _result += 1
                           End If

                           '-- REQ-35400.- --------------------------------------------------------------------------------------------------
                           '-- Valida IdBancoEmisor.- ---
                           If IsNumeric(drE(12).ToString()) AndAlso Convert.ToInt32(drE(12).ToString()) > 0 Then
                              Dim drTemp = _cache.BuscaBanco(Convert.ToInt32(drE(12).ToString()))
                              If drTemp Is Nothing Then
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.IdBancoEmisor.ToString()) = Convert.ToInt32(drE(12).ToString())
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.BancoEmisor.ToString()) = drE(11).ToString()

                                 Accion = "X"
                                 Mensaje.AppendFormat("No existe el Número de Banco Emisor - ")
                                 _result += 1
                              Else
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.IdBancoEmisor.ToString()) = drTemp.IdBanco
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.BancoEmisor.ToString()) = drTemp.NombreBanco
                              End If
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El Número de Banco Emisor no es valido. - ")
                              _result += 1
                           End If
                           '-- Valida Sucursal Banco Emisor.- --
                           If Not String.IsNullOrWhiteSpace(drE(13).ToString()) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.SucBancoEmisor.ToString()) = Convert.ToInt32(drE(13))
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El Nro de Sucursal es nulo o tiene un formato incorrecto - ")
                              _result += 1
                           End If
                           '-- Valida Localidad.- ---
                           If IsNumeric(drE(14).ToString()) AndAlso Convert.ToInt32(drE(14).ToString()) > 0 Then
                              Dim drTemp = _cache.BuscaLocalidad(Convert.ToInt32(drE(14).ToString()))
                              If drTemp Is Nothing Then
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.CodigoPostal.ToString()) = Convert.ToInt32(drE(14).ToString())
                                 Accion = "X"
                                 Mensaje.AppendFormat("No existe la Localidad informada - ")
                                 _result += 1
                              Else
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.CodigoPostal.ToString()) = drTemp.IdLocalidad
                              End If
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("La Localidad ingresada no es valida. - ")
                              _result += 1
                           End If
                           '-- Valida Proveedor.- ---
                           If IsNumeric(drE(15).ToString()) AndAlso Convert.ToInt32(drE(15).ToString()) > 0 Then
                              Dim drTemp = _cache.BuscaProveedor(drE(15).ToString())
                              If drTemp Is Nothing Then
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.IdProveedor.ToString()) = 0
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.CodigoProveedor.ToString()) = Convert.ToInt32(drE(15).ToString())
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.NombreProveedor.ToString()) = drE(16).ToString()

                                 Accion = "X"
                                 Mensaje.AppendFormat("No existe el Codigo de Proveedor - ")
                                 _result += 1
                              Else
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.IdProveedor.ToString()) = drTemp.IdProveedor
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.CodigoProveedor.ToString()) = drTemp.CodigoProveedor
                                 drCl(Entidades.CuentaCorrienteCheque.Columnas.NombreProveedor.ToString()) = drTemp.NombreProveedor
                              End If

                           End If
                           '---------------------------------------------------------------------------------------------------------------
                           '-- Valida Orden Compra.- --
                           If IsNumeric(drE(17)) Then
                              Dim nroOC = Convert.ToInt64(drE(17))
                              drCl(Entidades.CuentaCorriente.Columnas.NumeroOrdenCompra.ToString()) = nroOC

                              If New OrdenesCompra().Get1(actual.Sucursal.Id, nroOC).Count = 0 Then
                                 Accion = "X"
                                 Mensaje.AppendFormat("Número de Orden de Compra Inexistente - ")
                                 _result += 1
                              End If
                           Else
                              drCl(Entidades.CuentaCorriente.Columnas.NumeroOrdenCompra.ToString()) = 0
                              If String.IsNullOrEmpty(drE(18).ToString()) Then
                                 Accion = "X"
                                 Mensaje.AppendFormat("Nro. de Orden de Compra u Observación Requeridos, complete alguno de los dos campos - ")
                                 _result += 1
                              Else
                                 drCl(Entidades.CuentaCorriente.Columnas.Observacion.ToString()) = drE(18).ToString()
                              End If
                           End If
                           '---------------------------------------------------------------------------------------------------------------
                           '-- Valida Fecha de Emision.- ---
                           fecha = Nothing
                           If IsDate(drE(0)) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.FechaEmision.ToString()) = drE(0).ToString()
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("La Fecha de Emision tiene un formato incorrecto - ")
                              _result += 1
                           End If
                           '-- Valida Fecha de Cobro.- ---
                           fecha = Nothing
                           If IsDate(drE(1)) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.FechaCobro.ToString()) = drE(1).ToString()
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("La Fecha de Cobro tiene un formato incorrecto - ")
                              _result += 1
                           End If
                           '-- Valida Nro de Cheque.- ---
                           If IsNumeric(drE(2)) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.NroCheque.ToString()) = Convert.ToInt32(drE(2))
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El numero de Cheque tiene un formato incorrecto - ")
                           End If
                           '-- Valida Ids Cheques.- --
                           If Not String.IsNullOrWhiteSpace(drE(3).ToString()) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.IdsCheque.ToString()) = drE(3)
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El ID de Cheque es nulo o tiene un formato incorrecto - ")
                              _result += 1
                           End If

                           If ds.Tables(0).Select(String.Format("[{0}] = '{1}' AND [{2}] = '{3}' ",
                                                                ds.Tables(0).Columns(2).ToString(),
                                                                drE(2),
                                                                ds.Tables(0).Columns(3).ToString(),
                                                                drE(3))).Count > 1 Then
                              Accion = "X"
                              Mensaje.AppendFormat("El Cheque se encuentra ingresado por Duplicado - ")
                              _result += 1
                           End If


                           '-- Valida Importe.- --
                           If IsNumeric(drE(5)) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.Importe.ToString()) = Convert.ToDecimal(drE(5))
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El importe no es numerico - ")
                              _result += 1
                           End If
                           '-- Datos del Emisor.- --
                           drCl(Entidades.CuentaCorrienteCheque.Columnas.RazonSocialEmisor.ToString()) = drE.Field(Of String)(7).IfNull().Truncar(40)
                           drCl(Entidades.CuentaCorrienteCheque.Columnas.CUITEmisor.ToString()) = drE.Field(Of String)(8).IfNull()

                        Case Reglas.Publicos.BancosImportacionCheques.BBVA.ToString()

                           '-- Valida CUIT.- -------------------------------------------------------------------------------------------------------------------------------------------------------- 
                           Dim CUITCliente As String = drE(10).ToString()
                           '-- Carga Razon Social.- --
                           drCl(Entidades.CuentaCorrienteCheque.Columnas.RazonSocial.ToString()) = String.Empty
                           drCl("CUIT") = CUITCliente
                           '--------------------------
                           If IsNumeric(CUITCliente) AndAlso Convert.ToInt64(CUITCliente) > 0 Then
                              Dim drTemp = _cache._BuscaClienteporCUIT(CUITCliente)

                              If drTemp Is Nothing Then
                                 Accion = "C"
                                 Mensaje.AppendFormat("No existe el CUIT del Cliente - ")
                                 _result += 1
                              Else
                                 If drTemp.Length > 1 Then
                                    Accion = "C"
                                    Mensaje.AppendFormat("El CUIT esta signado a mas de un Cliente. No es valido. - ")
                                    _result += 1
                                 Else
                                    drCl("IdCliente") = drTemp(0)(Entidades.Cliente.Columnas.IdCliente.ToString())
                                    drCl("CodigoCliente") = drTemp(0)(Entidades.Cliente.Columnas.CodigoCliente.ToString())
                                    drCl(Entidades.CuentaCorrienteCheque.Columnas.RazonSocial.ToString()) = drTemp(0).Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())
                                 End If
                              End If
                           Else
                              Accion = "C"
                              Mensaje.AppendFormat("El formato del CUIT del Cliente no es valido. - ")
                              _result += 1
                           End If
                           '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                           '-- Valida Fecha de Emision.- ---
                           fecha = Nothing
                           If IsDate(drE(3)) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.FechaEmision.ToString()) = drE(3).ToString()
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("La Fecha de Emision tiene un formato incorrecto - ")
                              _result += 1
                           End If
                           '-- Valida Fecha de Cobro.- ---
                           fecha = Nothing
                           If IsDate(drE(4)) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.FechaCobro.ToString()) = drE(4).ToString()
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("La Fecha de Cobro tiene un formato incorrecto - ")
                              _result += 1
                           End If
                           '-- Valida Nro de Cheque.- ---
                           If IsNumeric(drE(8)) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.NroCheque.ToString()) = Convert.ToInt32(drE(8))
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El numero de Cheque tiene un formato incorrecto - ")
                           End If
                           '-- Valida Ids Cheques.- --
                           If Not String.IsNullOrWhiteSpace(drE(7).ToString()) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.IdsCheque.ToString()) = drE(7)
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El ID de Cheque es nulo o tiene un formato incorrecto - ")
                              _result += 1
                           End If
                           '-- Valida Importe.- --
                           If IsNumeric(drE(6)) Then
                              drCl(Entidades.CuentaCorrienteCheque.Columnas.Importe.ToString()) = Convert.ToDecimal(drE(6))
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("El importe no es numerico - ")
                              _result += 1
                           End If
                           '-- Datos del Emisor.- --
                           drCl(Entidades.CuentaCorrienteCheque.Columnas.RazonSocialEmisor.ToString()) = String.Empty
                           drCl(Entidades.CuentaCorrienteCheque.Columnas.CUITEmisor.ToString()) = drE(10).ToString()
                           ''-- Datos CMC7.- --
                           'drCl(Entidades.CuentaCorrienteCheque.Columnas.CMC7.ToString()) = drE.Field(Of String)(11).IfNull()
                     End Select

                     If New Cheques().Existe(actual.Sucursal.IdSucursal,
                                             drCl.Field(Of Integer)(Entidades.CuentaCorrienteCheque.Columnas.NroCheque.ToString()),
                                             drCl.Field(Of Integer)(Entidades.CuentaCorrienteCheque.Columnas.IdBancoEmisor.ToString()),
                                             drCl.Field(Of String)(Entidades.CuentaCorrienteCheque.Columnas.SucBancoEmisor.ToString()).ToInt32().IfNull(),
                                             drCl.Field(Of Integer)(Entidades.CuentaCorrienteCheque.Columnas.CodigoPostal.ToString()),
                                             drCl.Field(Of String)("CUIT")) Then
                        Accion = "X"
                        Mensaje.AppendFormat("El Cheque fué Ingresado con Anterioridad. - ")
                        _result += 1
                     End If

                     '-- Carga Mensajes.- --
                     drCl(Entidades.CuentaCorrienteCheque.Columnas.EstadoExportacion.ToString()) = Accion
                     drCl("Mensaje") = Mensaje.ToString()
                     '----------------------
                     dt.Rows.Add(drCl)
                     '----------------------
                  Next
               Catch ex As Exception
                  Throw New Exception(String.Format("Error procesando línea {0}: {1}", lineaProcesada, ex.Message), ex)
               End Try
            End Using
         End Using
         ConexionExcel.Close()
      End Using
      '-- Retorna Valor.- --
      Return dt
   End Function

   Public Sub RevalidaFilaGrilla(ByRef dr As DataRow)
      _cache = New BusquedasCacheadas()
      '---------------------------------------------------------------
      Dim Mensaje = New StringBuilder()
      Dim Accion As String = "A"
      Dim fecha As Date
      '---------------------------------------------------------------
      dr("Mensaje") = String.Empty
      dr("EstadoExportacion") = "A"
      '-- Valida CUIT.- -------------------------------------------------------------------------------------------------------------------------------------------------------- 
      If IsNumeric(dr("CodigoCliente").ToString()) AndAlso Convert.ToInt64(dr("CodigoCliente").ToString()) > 0 Then
         Dim drTemp = _cache._BuscaClienteporCUIT(dr("CodigoCliente").ToString())

         If drTemp Is Nothing Then
            Accion = "X"
            Mensaje.AppendFormat("No existe el CUIT del Cliente - ")
         Else
            If drTemp.Length > 1 Then
               Accion = "X"
               Mensaje.AppendFormat("El CUIT esta signado a mas de un Cliente. No es valido. - ")
            End If
         End If
      Else
         Accion = "X"
         Mensaje.AppendFormat("El formato del CUIT del Cliente no es valido. - ")
      End If
      '-- Valida IdBancoEmisor.- ---
      If IsNumeric(dr("IdBancoEmisor").ToString()) AndAlso Convert.ToInt32(dr("IdBancoEmisor").ToString()) > 0 Then
         Dim drTemp = _cache.BuscaBanco(Convert.ToInt32(dr("IdBancoEmisor").ToString()))
         If drTemp Is Nothing Then
            Accion = "X"
            Mensaje.AppendFormat("No existe el Número de Banco Emisor - ")
         End If
      Else
         Accion = "X"
         Mensaje.AppendFormat("El Número de Banco Emisor no es valido. - ")
      End If
      '-- Valida Sucursal Banco Emisor.- --
      If String.IsNullOrWhiteSpace(dr("SucBancoEmisor").ToString()) Then
         Accion = "X"
         Mensaje.AppendFormat("El Nro de Sucursal es nulo o tiene un formato incorrecto - ")
      End If
      '-- Valida Localidad.- ---
      If IsNumeric(dr("CodigoPostal").ToString()) AndAlso Convert.ToInt32(dr("CodigoPostal").ToString()) > 0 Then
         Dim drTemp = _cache.BuscaLocalidad(Convert.ToInt32(dr("CodigoPostal").ToString()))
         If drTemp Is Nothing Then
            Accion = "X"
            Mensaje.AppendFormat("No existe la Localidad informada - ")
         End If
      Else
         Accion = "X"
         Mensaje.AppendFormat("La Localidad ingresada no es valida. - ")
      End If
      '-- Valida Proveedor.- ---
      If IsNumeric(dr("CodigoProveedor").ToString()) AndAlso Convert.ToInt32(dr("CodigoProveedor").ToString()) > 0 Then
         Dim drTemp = _cache.BuscaProveedor(dr("CodigoProveedor").ToString())
         If drTemp Is Nothing Then
            Accion = "X"
            Mensaje.AppendFormat("No existe el Codigo de Proveedor - ")
         End If
      End If
      '-- Valida Fecha de Emision.- ---
      fecha = Nothing
      If Not IsDate(dr("FechaEmision")) Then
         Accion = "X"
         Mensaje.AppendFormat("La Fecha de Emision tiene un formato incorrecto - ")
      End If
      '-- Valida Fecha de Cobro.- ---
      fecha = Nothing
      If Not IsDate(dr("FechaCobro")) Then
         Accion = "X"
         Mensaje.AppendFormat("La Fecha de Cobro tiene un formato incorrecto - ")
      End If
      '-- Valida Nro de Cheque.- ---
      If Not IsNumeric(dr("NroCheque")) Then
         Accion = "X"
         Mensaje.AppendFormat("El numero de Cheque tiene un formato incorrecto - ")
      End If
      '-- Valida Ids Cheques.- --
      If String.IsNullOrWhiteSpace(dr("IdsCheque").ToString()) Then
         Accion = "X"
         Mensaje.AppendFormat("El ID de Cheque es nulo o tiene un formato incorrecto - ")
      End If
      '-- Valida Importe.- --
      If Not IsNumeric(dr("Importe")) Then
         Accion = "X"
         Mensaje.AppendFormat("El importe no es numerico - ")
      End If
      '-- Carga Mensajes.- --
      dr(Entidades.CuentaCorrienteCheque.Columnas.EstadoExportacion.ToString()) = Accion
      dr("Mensaje") = Mensaje.ToString()
      '---------------------------------------------------------------

   End Sub


   Public Shared Function CrearDT() As DataTable

      Dim dtTemp = New DataTable()

      With dtTemp
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.EstadoExportacion.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.FechaEmision.ToString(), GetType(Date))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.FechaCobro.ToString(), GetType(Date))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.NroCheque.ToString(), GetType(Integer))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.IdsCheque.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.Importe.ToString(), GetType(Decimal))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.RazonSocial.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.CUIT.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.RazonSocialEmisor.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.CUITEmisor.ToString(), GetType(String))
         '-- REQ-35400.- -------------------------------------------------------------------------------------
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.IdBancoEmisor.ToString(), GetType(Integer))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.BancoEmisor.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.SucBancoEmisor.ToString(), GetType(String))

         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.CodigoPostal.ToString(), GetType(Integer))

         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.IdProveedor.ToString(), GetType(Integer))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.CodigoProveedor.ToString(), GetType(Integer))
         .Columns.Add(Entidades.CuentaCorrienteCheque.Columnas.NombreProveedor.ToString(), GetType(String))

         .Columns.Add(Entidades.CuentaCorriente.Columnas.NumeroOrdenCompra.ToString(), GetType(Long))
         '----------------------------------------------------------------------------------------------------
         .Columns.Add(Entidades.CuentaCorriente.Columnas.Observacion.ToString(), GetType(String))

         .Columns.Add("Mensaje", GetType(String))

         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("CodigoCliente", GetType(Long))

      End With

      Return dtTemp

   End Function

   Public Sub GrabarRecibos(cobrador As Entidades.Empleado, idCaja As Integer, tipoComprobante As Entidades.TipoComprobante,
                            dt As DataTable, fecha As Date, nombreArchivo As String, tipoArchivo As String, idFuncion As String)
      Dim listadosCtasCtes As New List(Of Eniac.Entidades.CuentaCorriente)()
      Dim idTipoLiquidacion As Integer? = Nothing

      Dim rCliente = New Reglas.Clientes()

      Dim rCtaCte = New Reglas.CtaCteClienteRecibo()

      Dim eTipoCheque = New Reglas.TiposCheques().GetUno("E")

      Dim eCtaCte = New Entidades.CuentaCorriente()
      Dim rRegRecibos = New Eniac.Reglas.CuentasCorrientes()
      '---------------------------------------------------------------
      Dim dccClientes = New Dictionary(Of Tuple(Of Long, Long), List(Of DataRow))()
      '---------------------------------------------------------------
      For Each dr As DataRow In dt.AsEnumerable().Where(Function(dr1) dr1.Field(Of String)("EstadoExportacion") = "A")
         Dim idCliente = dr.Field(Of Long)("IdCliente")
         Dim nroOC = dr.Field(Of Long?)("NumeroOrdenCompra").IfNull()
         Dim key = New Tuple(Of Long, Long)(idCliente, nroOC)
         If Not dccClientes.ContainsKey(key) Then
            dccClientes.Add(key, New List(Of DataRow)())
         End If
         dccClientes(key).Add(dr)
      Next

      For Each kvClientes In dccClientes
         Dim key = kvClientes.Key
         Dim drChequesCol = kvClientes.Value
         Dim Observacion As String = String.Empty

         Dim _cheques = drChequesCol.ToList().ConvertAll(
            Function(dr)
               Dim cheque = New Entidades.Cheque()
               With cheque
                  .NombreTipoCheque = eTipoCheque.NombreTipoCheque
                  .IdTipoCheque = eTipoCheque.IdTipoCheque
                  .IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA

                  .NumeroCheque = dr.Field(Of Integer)("NroCheque")
                  .NroOperacion = dr.Field(Of String)("IdsCheque")

                  .FechaEmision = dr.Field(Of Date)("FechaEmision")
                  .FechaCobro = dr.Field(Of Date)("FechaCobro")
                  .Importe = dr.Field(Of Decimal)("Importe")

                  .Cliente.IdCliente = key.Item1

                  .Titular = dr.Field(Of String)("RazonSocialEmisor")
                  .Cuit = dr.Field(Of String)("CUITEmisor")

                  .Usuario = actual.Nombre

                  Dim eBanco = New Reglas.Bancos().GetUno(dr.Field(Of Integer)("IdBancoEmisor"))
                  .Banco = eBanco
                  .Localidad.IdLocalidad = dr.Field(Of Integer)("CodigoPostal")

                  .IdBancoSucursal = Integer.Parse(dr("SucBancoEmisor").ToString())

                  If Not String.IsNullOrEmpty(dr("IdProveedor").ToString) Then
                     .IdProveedorPreasignado = Long.Parse(dr("IdProveedor").ToString())
                  Else
                     .IdProveedorPreasignado = 0
                  End If
                  If Not String.IsNullOrEmpty(dr("Observacion").ToString) Then
                     Observacion = dr.Field(Of String)("Observacion").ToString()
                  End If
                  If IsNumeric(dr("NumeroOrdenCompra").ToString()) Then
                     If Long.Parse(dr("NumeroOrdenCompra").ToString()) <> 0 Then
                        .Observacion = String.Format("OC: {0}", dr("NumeroOrdenCompra"))
                     End If
                  End If

               End With
               Return cheque
            End Function)
         '-- Cliente.- --------------------------------------------------
         Dim eCliente = rCliente._GetUno(key.Item1)
         '-- Letra.-  ---------------------------------------------------
         Dim letra As String = tipoComprobante.LetrasHabilitadas
         'Si tiene configurado mas de una Letra (A,B,C) significa que la toma de la categoria fiscal en lugar de fija (R o X)
         If letra.Trim.Length > 1 Then
            letra = eCliente.CategoriaFiscal.LetraFiscal
         End If
         '---------------------------------------------------------------
         Dim numeroComprobante = 0
         Dim observ As String = Observacion
         '---------------------------------------------------------------
         Dim idFormaPago As Integer = New Reglas.VentasFormasPago().GetUna("VENTAS", True).IdFormasPago
         '---------------------------------------------------------------
         Dim importeTotal = _cheques.Sum(Function(x) x.Importe)
         '---------------------------------------------------------------
         eCtaCte = rCtaCte.GetCtaCteCliente(tipoComprobante.IdTipoComprobante, letra, numeroComprobante,
                                         fecha,
                                         idFormaPago,
                                         eCliente, eCliente.Vendedor, cobrador,
                                         observ,
                                         importeTotal,
                                         importeEfectivo:=0, importeDolares:=0, importeTarjetas:=0, importeTransferencia:=0,
                                         idCuentaBancaria:=0,
                                         idCaja,
                                         pagos:=Nothing, _cheques, tarjetas:=Nothing, retenciones:=Nothing,
                                         key.Item2)
         '---------------------------------------------------------------
         listadosCtasCtes.Add(eCtaCte)
      Next
      '---------------------------------------------------------------
      rRegRecibos.GrabarPagosAutomaticos(listadosCtasCtes, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, idTipoLiquidacion, tipoArchivo, nombreArchivo, False)
      '---------------------------------------------------------------
   End Sub

   Public Function RecuperaCantidadDiasCobro(ent As Entidades.CuentaCorrientePago, comprobantePrin As String, fechacobro As Date?) As Boolean
      fechacobro = Nothing
      Dim Resp As Boolean = False
      Dim sql = New SqlServer.CuentasCorrientesCheques(Me.da)
      Dim dt = sql.RecuperaCantidadDiasCobro(ent.IdSucursal, comprobantePrin, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)
      If dt.Rows.Count > 0 Then
         fechacobro = dt(0).Field(Of Date)("FechaCobro")
         Resp = True
      End If

      Return Resp
   End Function
#End Region

End Class
