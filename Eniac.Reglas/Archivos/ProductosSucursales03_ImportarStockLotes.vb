Partial Class ProductosSucursales
   Public Class ImportarStockLotes
      Inherits Base

      Private Const ColumnaIdProducto As Integer = 0
      Private Const ColumnaNombreProducto As Integer = 1
      Private Const ColumnaLote As Integer = 2
      Private Const ColumnaFechaVencimiento As Integer = 3
      Private Const ColumnaStock As Integer = 4
      Private Const ColumnaNombreDeposito As Integer = 5
      Private Const ColumnaNombreUbicacion As Integer = 6

      Public Const ImportaColumnName As String = "Importa"
      Private Const EstadoImportaColumnName As String = "EstadoImporta"
      Public Const AccionColumnName As String = "Accion"
      Private Const CodigoColumnName As String = "Codigo"
      Public Const DescripcionColumnName As String = "Descripcion"
      Private Const IdLoteColumnName As String = "IdLote"
      Private Const FechaVencimientoColumnName As String = "FechaVencimiento"
      Private Const IdDepositoColumnName As String = "IdDeposito"
      Private Const NombreDepositoColumnName As String = "NombreDeposito"
      Private Const IdUbicacionColumnName As String = "IdUbicacion"
      Private Const NombreUbicacionColumnName As String = "NombreUbicacion"
      Private Const StockColumnName As String = "Stock"
      Public Const MensajeColumnName As String = "Mensaje"

      Public Const AccionAlta = "A"
      Public Const AccionModif = "M"
      Public Const AccionError = "X"

#Region "Constructores"
      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub
      Public Sub New(accesoDatos As Datos.DataAccess)
         MyBase.New("ProductosSucursales", accesoDatos)
      End Sub
#End Region

      Public Class AvanceAjusteMasivoStockEventArgs
         Inherits EventArgs
         Public Property Mensaje As String
         Public Sub New(mensaje As String)
            _Mensaje = mensaje
         End Sub
      End Class
      Public Event AvanceAjusteMasivoStock(sender As Object, e As AvanceAjusteMasivoStockEventArgs)


      Public Function LeerExcel(archivoOrigen As String, rangoExcel As String, mostrarInfo As Action(Of String)) As DataTable
         Return EjecutaConConexion(Function() _LeerExcel(archivoOrigen, rangoExcel, mostrarInfo))
      End Function

      Public Function _LeerExcel(archivoOrigen As String, rangoExcel As String, mostrarInfo As Action(Of String)) As DataTable
         Dim rProd = New Productos(da)
         Dim rProdSuc = New ProductosSucursales(da)
         Dim rProdLote = New ProductosLotes(da)
         Dim rDeposito = New SucursalesDepositos(da)
         Dim rUbicacion = New SucursalesUbicaciones(da)

         Dim sw = New Stopwatch()
         sw.Start()
         Using ConexionExcel = CreaConexionExcel.AbrirExcel(archivoOrigen)
            Try
               mostrarInfo("¡¡¡LEYENDO ARCHIVO EXCEL!!!")
               Using DA = New OleDb.OleDbDataAdapter("Select * From " & rangoExcel, ConexionExcel)
                  Dim ds = New DataSet()
                  AddHandler ds.Tables.CollectionChanged,
                  Sub(sender, e)
                     If ds.Tables.Count > 0 Then
                        AddHandler ds.Tables(0).RowChanged,
                        Sub(sender1, e1) mostrarInfo(String.Format("Leyendo fila {0} del archivo {1}", ds.Tables(0).Count, archivoOrigen))
                     End If
                  End Sub
                  DA.Fill(ds)

                  Dim lineaProcesada = 0L

                  Dim dt = CrearDT()
                  Dim totalLineas = ds.Tables(0).Count
                  For Each dr In ds.Tables(0).AsEnumerable()
                     lineaProcesada += 1

                     If lineaProcesada = 1 Or lineaProcesada Mod 10 = 0 Then
                        mostrarInfo(String.Format("Procesando linea {0}/{1} - {2:N2} Registros/Segundo", lineaProcesada, totalLineas, lineaProcesada / sw.Elapsed.TotalSeconds))
                     End If

                     Dim accion = AccionAlta
                     Dim importa = True
                     Dim stbMensaje = New StringBuilder()

                     Dim drCl = dt.NewRow()

                     Dim codigo = dr(ColumnaIdProducto).ToString().Trim()
                     drCl(CodigoColumnName) = codigo
                     If rProd.Existe(codigo.ToString()) Then
                        Dim prod = rProd._GetUnoParaM(codigo.ToString())
                        If prod.Lote = False Then
                           accion = AccionError
                           stbMensaje.AppendFormat("El Producto no utiliza lote - ")
                        End If
                        Dim prodSuc = rProdSuc.Get1(actual.Sucursal.Id, codigo.ToString())
                        If prodSuc IsNot Nothing Then
                           If prodSuc.Field(Of Decimal)(StockColumnName) < 0 Then
                              accion = AccionError
                              stbMensaje.AppendFormat("El stock es negativo - ")
                           End If
                        End If
                     Else
                        accion = AccionError
                        stbMensaje.AppendFormat("El Producto no existe - ")
                     End If

                     drCl(DescripcionColumnName) = dr(ColumnaNombreProducto).ToString()

                     Dim idLote = dr(ColumnaLote).ToString()
                     drCl(IdLoteColumnName) = idLote

                     If dr(ColumnaLote).ToString().Length > 30 Then
                        accion = AccionError
                        stbMensaje.AppendFormat("El lote tiene mas de 30 caracteres - ")
                     End If

                     If Publicos.LoteSolicitaFechaVencimiento Then
                        If Not IsDBNull(dr(ColumnaFechaVencimiento)) AndAlso IsDate(dr(ColumnaFechaVencimiento).ToString()) Then
                           drCl(FechaVencimientoColumnName) = Date.Parse(dr(ColumnaFechaVencimiento).ToString())
                        Else
                           accion = AccionError
                           stbMensaje.AppendFormat("La fecha de vencimiento no es fecha válida - ")
                        End If
                     End If

                     If Entidades.Ayudante.ImportarExcel.IsNumeric(dr, ColumnaStock) Then
                        Dim stock = Decimal.Parse(dr(ColumnaStock).ToString())
                        drCl(StockColumnName) = stock
                        If stock < 0 Then
                           accion = AccionError
                           stbMensaje.AppendFormat("El Stock es negativo - ")
                        End If
                     Else
                        accion = AccionError
                        stbMensaje.AppendFormat("El Stock no es numérico - ")
                     End If

                     Dim idDeposito = 0I
                     Dim nombreDeposito = Entidades.Ayudante.ImportarExcel.GetValorString(dr, ColumnaNombreDeposito)
                     drCl(NombreDepositoColumnName) = nombreDeposito
                     If Not String.IsNullOrWhiteSpace(nombreDeposito) Then
                        Dim depo = rDeposito.GetDepositoNombre(actual.Sucursal.Id, nombreDeposito, AccionesSiNoExisteRegistro.Nulo)
                        If depo IsNot Nothing Then
                           idDeposito = depo.IdDeposito
                           drCl(IdDepositoColumnName) = idDeposito
                        Else
                           accion = AccionError
                           stbMensaje.AppendFormat("El Depósito no existe - ")
                        End If
                     Else
                        accion = AccionError
                        stbMensaje.AppendFormat("El Depósito es obligatorio - ")
                     End If

                     Dim idUbicacion = 0I
                     Dim nombreUbicacion = Entidades.Ayudante.ImportarExcel.GetValorString(dr, ColumnaNombreUbicacion)
                     drCl(NombreUbicacionColumnName) = nombreUbicacion
                     If Not String.IsNullOrWhiteSpace(nombreUbicacion) Then
                        Dim ubic = rUbicacion.GetUbicacionNombres(actual.Sucursal.Id, nombreDeposito, nombreUbicacion, AccionesSiNoExisteRegistro.Nulo)
                        If ubic IsNot Nothing Then
                           idUbicacion = ubic.IdUbicacion
                           drCl(IdUbicacionColumnName) = idUbicacion
                        Else
                           accion = AccionError
                           stbMensaje.AppendFormat("La Ubicación no existe - ")
                        End If
                     Else
                        accion = AccionError
                        stbMensaje.AppendFormat("La Ubicación es obligatoria - ")
                     End If

                     ' controlo si exite el lote 
                     If accion <> AccionError Then
                        Dim prodLote = rProdLote.Get1(codigo.ToString(), idLote, actual.Sucursal.Id, idDeposito, idUbicacion)
                        If prodLote IsNot Nothing Then
                           accion = AccionModif
                        End If
                     End If

                     importa = True
                     dt.Rows.Add(drCl)
                     drCl(AccionColumnName) = accion
                     If accion = AccionError Then
                        importa = False
                        drCl(MensajeColumnName) = stbMensaje.ToString()

                     End If
                     drCl(ImportaColumnName) = importa
                  Next
                  Return dt
               End Using
            Catch ex As Exception
               If ex.Message.Contains("no pudo encontrar") Then
                  Throw New Exception("Rango de Celdas Invalidos.")
               Else
                  Throw
               End If
            Finally
               mostrarInfo(String.Empty)
               ConexionExcel.Close()
            End Try
         End Using
         sw.Stop()
      End Function
      Private Function CrearDT() As DataTable
         Dim dtTemp = New DataTable()
         With dtTemp
            .Columns.Add(ImportaColumnName, GetType(Boolean))
            .Columns.Add(EstadoImportaColumnName, GetType(String))
            .Columns.Add(AccionColumnName, GetType(String))
            .Columns.Add(CodigoColumnName, GetType(String))
            .Columns.Add(DescripcionColumnName, GetType(String))
            .Columns.Add(IdLoteColumnName, GetType(String))
            .Columns.Add(FechaVencimientoColumnName, GetType(Date))
            .Columns.Add(IdDepositoColumnName, GetType(Integer))
            .Columns.Add(NombreDepositoColumnName, GetType(String))
            .Columns.Add(IdUbicacionColumnName, GetType(Integer))
            .Columns.Add(NombreUbicacionColumnName, GetType(String))
            .Columns.Add(StockColumnName, GetType(Decimal))
            .Columns.Add(MensajeColumnName, GetType(String))
         End With
         Return dtTemp
      End Function

      Public Sub Importar(dt As DataTable, reprocesa As Boolean, idFuncion As String)
         Dim cache = New BusquedasCacheadas()
         EjecutaConConexion(Sub() _Importar(dt, reprocesa, idFuncion, cache))
      End Sub

      Public Sub _Importar(dt As DataTable, reprocesa As Boolean, idFuncion As String, cache As BusquedasCacheadas)
         If Not reprocesa Then
            Dim productosConStockCero = 0I
            Dim stbProductosConStockCero = New StringBuilder()
            RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("COMENZANDO VALIDACIONES")))
            'For Each dr As DataRow In dt.Select(String.Format("{0} <> {1} OR {2} <> {3}", "Stock", "NuevoStock", "Ubicacion", "NuevaUbicacion"))
            '   RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("VALIDANDO {0} - {1}", dr("IdProducto"), dr("NombreProducto"))))
            '   If dr.ValorNumericoPorDefecto("Stock", 0D) > 0 And dr.ValorNumericoPorDefecto("NuevoStock", 0D) = 0 Then
            '      productosConStockCero = 0
            '      stbProductosConStockCero.AppendFormatLine("{0} - {1}", dr("IdProducto"), dr("NombreProducto"))
            '   End If

            '   If dr.ValorNumericoPorDefecto("Stock", 0D) <> dr.ValorNumericoPorDefecto("NuevoStock", 0D) Then
            '      If dr.ValorNumericoPorDefecto("NuevoStock", 0D) < 0 Then
            '         Throw New Exception(String.Format("El producto {0} - {1} tiene nuevo Stock en negativo, NO puede continuar", dr("IdProducto"), dr("NombreProducto")))
            '      End If
            '   End If

            '   'If dr("NuevaUbicacion").ToString().Length > maxUbicacion Then
            '   '   Throw New Exception(String.Format("El producto {0} - {1} tiene una ubicación muy larga (max.: {2})", dr("IdProducto"), dr("NombreProducto"), maxUbicacion))
            '   'End If

            'Next
            If productosConStockCero > 0 Then
               '   Dim mensajeError As String
               '   If productosConStockCero = 1 Then
               '      mensajeError = String.Format("El Producto {0} tiene Stock Nuevo en 0 (cero) pero el Stock Actual NO. ¿Desea continuar en este caso?", stbProductosConStockCero.ToString())
               '   ElseIf productosConStockCero < 5 Then
               '      mensajeError = String.Format("Los Productos {0} tienen Stock Nuevo en 0 (cero) pero el Stock Actual NO. ¿Desea continuar con estos casos?", stbProductosConStockCero.ToString())
               '   Else
               '      mensajeError = String.Format("Existen {0} Productos que tienen Stock Nuevo en 0 (cero) pero el Stock Actual NO. ¿Desea continuar con estos casos?", stbProductosConStockCero.ToString())
               '   End If
               '   Throw New ValidacionAjusteMasivoStockException(mensajeError)
            End If
         End If

         For Each dr In dt.Where(Function(x) x.Field(Of Boolean)(ImportaColumnName))
            EjecutaSoloConTransaccion(Sub() _ImportarFila(idFuncion, dr, cache))
         Next
      End Sub

      Private Sub _ImportarFila(idFuncion As String, dr As DataRow, cache As BusquedasCacheadas)
         Dim idProducto = dr.Field(Of String)(CodigoColumnName).Trim()
         Dim nombreProducto = dr.Field(Of String)(DescripcionColumnName).Trim()
         RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("Producto {0} - {1} - PROCESANDO", idProducto, nombreProducto)))

         RaiseEvent AvanceAjusteMasivoStock(Me, New AvanceAjusteMasivoStockEventArgs(String.Format("Producto {0} - {1} - ACTUALIZA STOCK", idProducto, nombreProducto)))
         Dim rProductos = New Productos(da)
         rProductos._AjustarStockLote(actual.Sucursal.Id, idProducto,
                                      tablaContabilidad:=Nothing, grabaAutomatico:=True, esMultipleRubro:=False,
                                      nuevoStock:=dr.Field(Of Decimal)(StockColumnName),
                                      idLote:=dr.Field(Of String)(IdLoteColumnName), fechaVencimiento:=dr.Field(Of Date?)(FechaVencimientoColumnName),
                                      idDeposito:=dr.Field(Of Integer)(IdDepositoColumnName), idUbicacion:=dr.Field(Of Integer)(IdUbicacionColumnName),
                                      metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Manual, idFuncion:=idFuncion, cache)
      End Sub
   End Class
End Class