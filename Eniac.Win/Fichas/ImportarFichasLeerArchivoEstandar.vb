#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ImportarFichasLeerArchivoEstandar
   Private _cache As Reglas.BusquedasCacheadas
   Public Property FormatoFechas As String

   Private Enum ColumnasExcel As Integer
      FechaIndex
      IdTipoComprobanteIndex
      LetraIndex
      CentroEmisorIndex
      NumeroComprobanteIndex
      CodigoClienteIndex
      IdCajaIndex
      FormaPagoIndex
      CodigoProductoIndex
      NombreProductoIndex
      CantidadIndex
      ImporteTotalIndex
      CantidadCuotasIndex
      CuotasPagasIndex
      ImportePagadoIndex
      CuotasImpagasIndex
      ImporteImpagoIndex
      SaldoIndex
      NombreVendedorIndex
      NombreCobradorIndex
      CodigoVendedorIndex
      CodigoCobradorIndex
   End Enum

   Public Sub New(cache As Reglas.BusquedasCacheadas, formatoFechas As String)
      _cache = New Reglas.BusquedasCacheadas()
      _FormatoFechas = formatoFechas
   End Sub
   Public Sub Importar(path As String, dtGrilla As DataTable, rango As String, cboEstado As String, cboAccion As String)
      Dim rVentas As Reglas.Ventas = New Reglas.Ventas()
      Using conexionExcel As System.Data.OleDb.OleDbConnection = CreaConexionExcel.AbrirExcel(path)
         conexionExcel.Open()
         Using DA As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter("Select * From " + rango, conexionExcel)
            Using dsExcel As DataSet = New DataSet()
               DA.Fill(dsExcel)

               Dim lineaProcesada As Integer = 0

               RaiseEvent IniciaImportacion(Me, New IniciaImportacionEventArgs() With {.CantidadTotalDeRegistros = dsExcel.Tables(0).Rows.Count})

               Try
                  Dim Accion As String
                  Dim Importa As Boolean
                  Dim Mensaje As StringBuilder

                  Dim drGrilla As DataRow

                  Dim tempFecha As Date?
                  Dim tempLong As Long
                  Dim tempDecimal As Decimal
                  Dim tempInteger As Integer
                  Dim tempString As String
                  Dim tempString1 As String
                  Dim tempString2 As String
                  Dim tempDR As DataRow

                  Dim tempEmpleado As Entidades.Empleado
                  Dim tempCobrador As Entidades.Empleado

                  Dim idTipoComprobante As String = ""
                  Dim letra As String = ""
                  Dim centroEmisor As Short
                  Dim numeroComprobante As Long

                  For Each drExcel As DataRow In dsExcel.Tables(0).Rows
                     lineaProcesada += 1

                     Accion = "A"
                     Importa = True
                     Mensaje = New StringBuilder()

                     '                  'System.Windows.Forms.Application.DoEvents()

                     drGrilla = dtGrilla.NewRow()

                     tempFecha = GetValorFecha(drExcel, ColumnasExcel.FechaIndex, FormatoFechas)
                     If tempFecha.HasValue Then
                        drGrilla("Fecha") = tempFecha.Value
                     Else
                        Continue For
                        'SetError("La fecha es requerida - ", Mensaje, Accion)
                     End If


                     tempString = GetValorString(drExcel, ColumnasExcel.IdTipoComprobanteIndex)
                     drGrilla(Entidades.Venta.Columnas.IdTipoComprobante.ToString()) = tempString
                     If String.IsNullOrWhiteSpace(tempString) Then
                        SetError("El Tipo de Comprobante es requerido - ", Mensaje, Accion, drExcel, ColumnasExcel.IdTipoComprobanteIndex)
                     ElseIf Not _cache.ExisteTipoComprobante(tempString) Then
                        SetError("El Tipo de Comprobante no existe - ", Mensaje, Accion, drExcel, ColumnasExcel.IdTipoComprobanteIndex)
                     Else
                        idTipoComprobante = tempString
                     End If

                     tempString = GetValorString(drExcel, ColumnasExcel.LetraIndex)
                     drGrilla(Entidades.Venta.Columnas.Letra.ToString()) = tempString
                     If String.IsNullOrWhiteSpace(tempString) Then
                        SetError("La Letra del Comprobante es requerida - ", Mensaje, Accion, drExcel, ColumnasExcel.LetraIndex)
                     Else
                        letra = tempString
                     End If

                     tempInteger = GetValorInteger(drExcel, ColumnasExcel.CentroEmisorIndex)
                     drGrilla(Entidades.Venta.Columnas.CentroEmisor.ToString()) = tempInteger
                     If tempInteger = 0 Then
                        SetError("El Centro Emisor es requerido - ", Mensaje, Accion, drExcel, ColumnasExcel.CentroEmisorIndex)
                     Else
                        centroEmisor = Convert.ToInt16(tempInteger)
                        Dim impresora As Entidades.Impresora = _cache.BuscaImpresoraPorTipoComprobante(idTipoComprobante)
                        If impresora Is Nothing Then
                           SetError("No existe impresora definida para este tipo de comprobante - ", Mensaje, Accion, drExcel, ColumnasExcel.IdTipoComprobanteIndex)
                        ElseIf impresora.CentroEmisor <> centroEmisor Then
                           SetError("El centro emisor no coincide con el de la impresora a usar - ", Mensaje, Accion, drExcel, ColumnasExcel.CentroEmisorIndex)
                        End If
                     End If

                     tempLong = GetValorLong(drExcel, ColumnasExcel.NumeroComprobanteIndex)
                     drGrilla(Entidades.Venta.Columnas.NumeroComprobante.ToString()) = tempLong
                     If tempLong = 0 Then
                        SetError("El Número de Comprobante es requerido - ", Mensaje, Accion, drExcel, ColumnasExcel.NumeroComprobanteIndex)
                     Else
                        numeroComprobante = tempLong
                     End If

                     If Not String.IsNullOrWhiteSpace(idTipoComprobante) And Not String.IsNullOrWhiteSpace(letra) And centroEmisor > 0 And numeroComprobante > 0 Then
                        If rVentas.Existe(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroComprobante) Then
                           SetError("El Comprobante ya existe - ", Mensaje, Accion, drExcel, ColumnasExcel.NumeroComprobanteIndex, "E")
                        End If
                     End If

                     tempLong = GetValorLong(drExcel, ColumnasExcel.CodigoClienteIndex)
                     If tempLong <> 0 Then
                        tempDR = _cache.BuscaClientePorCodigo(tempLong)
                        drGrilla(Entidades.Cliente.Columnas.CodigoCliente.ToString()) = tempLong
                        If tempDR IsNot Nothing Then
                           drGrilla(Entidades.Cliente.Columnas.IdCliente.ToString()) = tempDR(Entidades.Cliente.Columnas.IdCliente.ToString())
                           drGrilla(Entidades.Cliente.Columnas.NombreCliente.ToString()) = tempDR(Entidades.Cliente.Columnas.NombreCliente.ToString())
                        Else
                           SetError("El Cliente no existe - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoClienteIndex)
                        End If
                     Else
                        SetError("El Cliente es requerido - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoClienteIndex)
                     End If

                     tempString = GetValorString(drExcel, ColumnasExcel.CodigoProductoIndex)
                     If String.IsNullOrWhiteSpace(tempString) Then
                        SetError("El Producto es requerido - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoProductoIndex)
                     Else
                        drGrilla("IdProducto") = tempString
                        drGrilla("NombreProducto") = GetValorString(drExcel, ColumnasExcel.NombreProductoIndex)
                        If Not _cache.ExisteProductoPorIdRapido(tempString) Then
                           SetError("El Producto no existe - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoProductoIndex)
                        End If
                     End If

                     tempDecimal = GetValorDecimal(drExcel, ColumnasExcel.CantidadIndex)
                     If tempDecimal <= 0 Then
                        SetError("La Cantidad es requerida y debe ser positiva - ", Mensaje, Accion, drExcel, ColumnasExcel.CantidadIndex)
                     Else
                        drGrilla("Cantidad") = tempDecimal
                     End If

                     tempInteger = GetValorInteger(drExcel, ColumnasExcel.IdCajaIndex)
                     If tempInteger = 0 Then
                        SetError("La Caja es requerida - ", Mensaje, Accion, drExcel, ColumnasExcel.IdCajaIndex)
                     Else
                        drGrilla(Entidades.CajaNombre.Columnas.IdCaja.ToString()) = tempInteger
                        If Not _cache.ExisteCajaNombre(actual.Sucursal.Id, tempInteger) Then
                           SetError("La Caja no existe - ", Mensaje, Accion, drExcel, ColumnasExcel.IdCajaIndex)
                        End If
                     End If

                     tempString = GetValorString(drExcel, ColumnasExcel.FormaPagoIndex)
                     If String.IsNullOrWhiteSpace(tempString) Then
                        SetError("La Forma de Pago es requerida - ", Mensaje, Accion, drExcel, ColumnasExcel.FormaPagoIndex)
                     Else
                        drGrilla(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString()) = tempString
                        If Not _cache.ExisteFormasPago(tempString) Then
                           SetError("La Forma de Pago no existe - ", Mensaje, Accion, drExcel, ColumnasExcel.FormaPagoIndex)
                        Else
                           Dim fPago As Entidades.VentaFormaPago = _cache.BuscaFormasPago(tempString)
                           drGrilla("Entidad_FormaPago") = fPago
                           If fPago.Dias = 0 Then
                              SetError("La forma de pago es Contado - ", Mensaje, Accion, drExcel, ColumnasExcel.FormaPagoIndex)
                           End If
                        End If
                     End If

                     tempDecimal = GetValorDecimal(drExcel, ColumnasExcel.ImporteTotalIndex)
                     If tempDecimal <> 0 Then
                        drGrilla("ImporteTotal") = tempDecimal
                     Else
                        SetError("El Importe Total no puede ser cero (0) - ", Mensaje, Accion, drExcel, ColumnasExcel.ImporteTotalIndex)
                     End If

                     tempInteger = GetValorInteger(drExcel, ColumnasExcel.CantidadCuotasIndex)
                     If tempInteger <> 0 Then
                        drGrilla("CantidadCuotas") = tempInteger
                     Else
                        SetError("La Cantidad de Cuotas no puede ser cero (0) - ", Mensaje, Accion, drExcel, ColumnasExcel.CantidadCuotasIndex)
                     End If

                     drGrilla("CuotasPagas") = GetValorInteger(drExcel, ColumnasExcel.CuotasPagasIndex)
                     drGrilla("ImportePagado") = GetValorDecimal(drExcel, ColumnasExcel.ImportePagadoIndex)

                     drGrilla("CuotasImpagas") = GetValorInteger(drExcel, ColumnasExcel.CuotasImpagasIndex)
                     drGrilla("ImporteImpago") = GetValorDecimal(drExcel, ColumnasExcel.ImporteImpagoIndex)

                     drGrilla("Saldo") = GetValorDecimal(drExcel, ColumnasExcel.SaldoIndex)

                     ' # Vendedor
                     tempInteger = GetValorInteger(drExcel, ColumnasExcel.CodigoVendedorIndex)
                     tempString2 = GetValorString(drExcel, ColumnasExcel.NombreVendedorIndex)
                     If tempInteger = 0 And String.IsNullOrWhiteSpace(tempString2) Then
                        SetError("El Vendedor es requerido - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoVendedorIndex)
                     Else
                        tempEmpleado = _cache.BuscaEmpleado(tempInteger)
                        If tempEmpleado Is Nothing Then
                           tempEmpleado = _cache.BuscaEmpleado(tempString2.Trim())
                        End If
                        If tempEmpleado IsNot Nothing Then
                           drGrilla("CodigoVendedor") = tempEmpleado.IdEmpleado
                           drGrilla("NombreVendedor") = tempEmpleado.NombreEmpleado
                           drGrilla("Entidad_Vendedor") = tempEmpleado

                           Dim ruta As Entidades.MovilRuta = New Reglas.MovilRutas().GetUnoPorVendedor(tempEmpleado.IdEmpleado)
                           If ruta.IdRuta = 0 Then
                              SetError("El Vendedor no tiene Ruta Asignada - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoCobradorIndex)
                           End If
                        Else
                           drGrilla("CodigoVendedor") = tempInteger
                           drGrilla("NombreVendedor") = tempString2
                           SetError("El Vendedor no existe - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoVendedorIndex)
                        End If
                     End If

                     ' # Cobrador
                     tempInteger = GetValorInteger(drExcel, ColumnasExcel.CodigoCobradorIndex)
                     tempString = GetValorString(drExcel, ColumnasExcel.NombreCobradorIndex)

                     If tempInteger = 0 And String.IsNullOrWhiteSpace(tempString) Then
                        SetError("El Cobrador es requerido - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoCobradorIndex)
                     Else
                        tempCobrador = _cache.BuscaCobrador(tempInteger) ' Primero busca por Código
                        If tempCobrador Is Nothing Then
                           tempCobrador = _cache.BuscaCobrador(tempString.Trim())
                        End If
                        If tempCobrador IsNot Nothing Then
                           drGrilla("CodigoCobrador") = tempCobrador.IdEmpleado
                           drGrilla("NombreCobrador") = tempCobrador.NombreEmpleado
                           drGrilla("Entidad_Cobrador") = tempCobrador

                        Else
                           drGrilla("CodigoCobrador") = tempInteger
                           drGrilla("NombreCobrador") = tempString
                           SetError("El Cobrador no existe - ", Mensaje, Accion, drExcel, ColumnasExcel.CodigoCobradorIndex)
                        End If
                     End If

                     Importa = True
                     If Accion = "X" Or Accion = "E" Then
                        Importa = False
                        drGrilla("Mensaje") = Mensaje.ToString()
                     End If
                     drGrilla("Importa") = Importa
                     drGrilla("Accion") = Accion

                     If (cboEstado = "Todos" Or (cboEstado = "Validos" And Importa) Or (cboEstado = "Invalidos" And Not Importa)) And
                        (cboAccion = "Todas" Or (cboAccion = "Altas" And Accion = "A") Or (cboAccion = "Modificar" And Accion = "M")) Then
                        dtGrilla.Rows.Add(drGrilla)
                     End If
                     RaiseEvent AvanceImportacion(Me, New AvanceImportacionEventArgs() With {.RegistrosProcesados = lineaProcesada})
                  Next
               Catch ex As Exception
                  Throw New Exception(String.Format("Error procesando línea {0}: {1}", lineaProcesada, ex.Message), ex)
               End Try
            End Using
         End Using

         RaiseEvent FinalizaImportacion(Me, Nothing)

         conexionExcel.Close()
      End Using

   End Sub


#Region "Metodos Privados"
   Private Function GetValorFecha(dr As DataRow, indiceColumna As Integer, formatoFecha As String) As DateTime?
      Return Ayudante.ImportarExcel.GetValorDateTime(dr, indiceColumna, formatoFecha)
   End Function
   Private Function GetValorString(dr As DataRow, indiceColumna As Integer) As String
      Return Ayudante.ImportarExcel.GetValorString(dr, indiceColumna)
   End Function
   Private Function GetValorLong(dr As DataRow, indiceColumna As Integer) As Long
      Return Ayudante.ImportarExcel.GetValorLong(dr, indiceColumna)
   End Function
   Private Function GetValorDecimal(dr As DataRow, indiceColumna As Integer) As Decimal
      Return Ayudante.ImportarExcel.GetValorDecimal(dr, indiceColumna)
   End Function
   Private Function GetValorInteger(dr As DataRow, indiceColumna As Integer) As Integer
      Return Ayudante.ImportarExcel.GetValorInteger(dr, indiceColumna)
   End Function

   Private Sub SetError(mensaje As String, stb As StringBuilder, ByRef accion As String, dr As DataRow, idx As Integer)
      SetError(mensaje, stb, accion, dr, idx, "X")
   End Sub
   Private Sub SetError(mensaje As String, stb As StringBuilder, ByRef accion As String, dr As DataRow, idx As Integer, estadoNuevo As String)
      stb.AppendFormat(mensaje)
      accion = estadoNuevo
      dr.SetColumnError(idx, mensaje)
   End Sub
#End Region


#Region "Definición de Eventos"
   Public Event IniciaImportacion As EventHandler(Of IniciaImportacionEventArgs)
   Public Class IniciaImportacionEventArgs
      Inherits EventArgs
      Public Property CantidadTotalDeRegistros As Integer
   End Class

   Public Event AvanceImportacion As EventHandler(Of AvanceImportacionEventArgs)
   Public Class AvanceImportacionEventArgs
      Inherits EventArgs
      Public Property RegistrosProcesados As Integer
   End Class

   Public Event FinalizaImportacion As EventHandler
#End Region
End Class