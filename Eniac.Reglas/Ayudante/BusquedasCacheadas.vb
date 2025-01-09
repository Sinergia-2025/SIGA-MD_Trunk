Imports Eniac.Entidades
Public Class BusquedasCacheadas

   Public ReadOnly Property CRMTipoNovedad As Ayudante.BusquedaCacheadaCRMTipoNovedad
      Get
         Return Ayudante.BusquedaCacheadaCRMTipoNovedad.Instancia
      End Get
   End Property
   Public ReadOnly Property CRMCategoriaNovedad As Ayudante.BusquedaCacheadaCRMCategoriaNovedad
      Get
         Return Ayudante.BusquedaCacheadaCRMCategoriaNovedad.Instancia
      End Get
   End Property
   Public ReadOnly Property CRMEstadoNovedad As Ayudante.BusquedaCacheadaCRMEstadoNovedad
      Get
         Return Ayudante.BusquedaCacheadaCRMEstadoNovedad.Instancia
      End Get
   End Property
   Public ReadOnly Property CRMPrioridadNovedad As Ayudante.BusquedaCacheadaCRMPrioridadNovedad
      Get
         Return Ayudante.BusquedaCacheadaCRMPrioridadNovedad.Instancia
      End Get
   End Property
   Public ReadOnly Property CRMMedioComunicacionNovedad As Ayudante.BusquedaCacheadaCRMMedioComunicacionNovedad
      Get
         Return Ayudante.BusquedaCacheadaCRMMedioComunicacionNovedad.Instancia
      End Get
   End Property
   Public ReadOnly Property CRMMetodoResolucionNovedad As Ayudante.BusquedaCacheadaMetodoResolucionNovedad
      Get
         Return Ayudante.BusquedaCacheadaMetodoResolucionNovedad.Instancia
      End Get
   End Property


#Region "Clientes"
   Private _clientesCacheados As DataTable

   Public Function BuscaCliente(nombreCliente As String) As DataRow
      If _clientesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.NombreCliente.ToString(), nombreCliente))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorNombre(nombreCliente, False)
      If _clientesCacheados Is Nothing Then
         _clientesCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _clientesCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function
   Public Function BuscaClienteporCUIT(CUITCliente As String) As DataRow
      If _clientesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.Cuit.ToString(), CUITCliente))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorCUIT(CUITCliente)
      If _clientesCacheados Is Nothing Then
         _clientesCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _clientesCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   Public Function _BuscaClienteporCUIT(CUITCliente As String) As DataRow()
      If _clientesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.Cuit.ToString(), CUITCliente))
         If drCol.Length > 0 Then
            Return drCol
         End If
      End If
      Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorCUIT(CUITCliente)
      If _clientesCacheados Is Nothing Then
         _clientesCacheados = dt
         Return _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.Cuit.ToString(), CUITCliente))
      Else
         If dt.Rows.Count > 0 Then
            _clientesCacheados.ImportRowRange(dt.Select())
            Return _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.Cuit.ToString(), CUITCliente))
         Else
            Return Nothing
         End If
      End If
   End Function

   Public Function BuscaClientePorFantasia(nombreCliente As String) As DataRow
      If _clientesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), nombreCliente))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorNombreFantasia(nombreCliente, False)
      If _clientesCacheados Is Nothing Then
         _clientesCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _clientesCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   Public Function BuscaClienteIdPorCodigo(CodigoCliente As Long) As Long
      Dim dr As DataRow = BuscaClientePorCodigo(CodigoCliente)
      If dr Is Nothing Then Return 0
      Return Long.Parse(dr("IdCliente").ToString())
   End Function
   Public Function BuscaClientePorCodigo(CodigoCliente As Long) As DataRow
      If _clientesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.CodigoCliente.ToString(), CodigoCliente))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorCodigo(CodigoCliente, False, True)
      If _clientesCacheados Is Nothing Then
         _clientesCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _clientesCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function
   Public Function BuscaClientePorId(IdCliente As Long) As DataRow
      If _clientesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.IdCliente.ToString(), IdCliente))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Clientes(Cliente.ModoClienteProspecto.Cliente).Get1(IdCliente, incluirFoto:=False, puedeVerDetalleValoracionEstrellas:=False)
      If _clientesCacheados Is Nothing Then
         _clientesCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _clientesCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   Private _clientesCacheadosList As List(Of Cliente)
   Public Function BuscaClientePorIdEntidad(IdCliente As Long) As Cliente
      If _clientesCacheadosList Is Nothing Then
         _clientesCacheadosList = New List(Of Cliente)()
      End If

      Dim result As Cliente = _clientesCacheadosList.FirstOrDefault(Function(x) x.IdCliente = IdCliente)
      If result Is Nothing Then
         Dim clte As Cliente = New Reglas.Clientes().GetUno(IdCliente)
         _clientesCacheadosList.Add(clte)
         Return clte
      Else
         Return result
      End If
   End Function


   Private _idClientesCacheado As DataTable
   Public Function ExisteClientePorIdRapido(idCliente As Long) As Boolean
      If _idClientesCacheado Is Nothing Then
         _idClientesCacheado = New Reglas.Clientes().GetAll_Ids()
      End If
      Return _idClientesCacheado.Select(String.Format("IdCliente = {0}", idCliente)).Length > 0
   End Function
   Public Function ExisteClientePorCodigoRapido(codigoCliente As Long) As Boolean
      If _idClientesCacheado Is Nothing Then
         _idClientesCacheado = New Reglas.Clientes().GetAll_Ids()
      End If
      Return _idClientesCacheado.Select(String.Format("CodigoCliente = {0}", codigoCliente)).Length > 0
   End Function

   Private _idProspectosCacheado As DataTable
   Public Function ExisteProspectoPorIdRapido(idProspecto As Long) As Boolean
      If _idProspectosCacheado Is Nothing Then
         _idProspectosCacheado = New Reglas.Clientes(Cliente.ModoClienteProspecto.Prospecto).GetAll_Ids()
      End If
      Return _idProspectosCacheado.Select(String.Format("IdProspecto = {0}", idProspecto)).Length > 0
   End Function
   Public Function ExisteProspectoPorCodigoRapido(codigoProspecto As Long) As Boolean
      If _idProspectosCacheado Is Nothing Then
         _idProspectosCacheado = New Reglas.Clientes(Cliente.ModoClienteProspecto.Prospecto).GetAll_Ids()
      End If
      Return _idProspectosCacheado.Select(String.Format("CodigoProspecto = {0}", codigoProspecto)).Length > 0
   End Function

#End Region

#Region "Clientes Entidad"
   Private _clientesEntidadCacheados As List(Of Entidades.Cliente) = New List(Of Entidades.Cliente)()

   Public Function BuscaClienteEntidadPorId(IdCliente As Long) As Entidades.Cliente
      If _clientesEntidadCacheados IsNot Nothing Then
         Dim clte As Entidades.Cliente = _clientesEntidadCacheados.FirstOrDefault(Function(x) x.IdCliente = IdCliente)
         If clte Is Nothing Then
            clte = New Reglas.Clientes(Cliente.ModoClienteProspecto.Cliente).GetUno(IdCliente)
            If clte IsNot Nothing Then
               _clientesEntidadCacheados.Add(clte)
            End If
         End If
         Return clte
      End If
      Return Nothing
   End Function

   Public Function BuscaClienteEntidadPorCodigo(codigoCliente As Long) As Entidades.Cliente
      If _clientesEntidadCacheados IsNot Nothing Then
         Dim clte As Entidades.Cliente = _clientesEntidadCacheados.FirstOrDefault(Function(x) x.CodigoCliente = codigoCliente)
         If clte Is Nothing Then
            clte = New Reglas.Clientes(Cliente.ModoClienteProspecto.Cliente).GetUnoPorCodigo(codigoCliente)
            If clte IsNot Nothing Then
               _clientesEntidadCacheados.Add(clte)
            End If
         End If
         Return clte
      End If
      Return Nothing
   End Function
#End Region

#Region "Proveedores"
   'Private _clientesCacheados As DataTable

   'Public Function BuscaCliente(nombreCliente As String) As DataRow
   '   If _clientesCacheados IsNot Nothing Then
   '      Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.NombreCliente.ToString(), nombreCliente))
   '      If drCol.Length > 0 Then
   '         Return drCol(0)
   '      End If
   '   End If
   '   Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorNombre(nombreCliente, False)
   '   If _clientesCacheados Is Nothing Then
   '      _clientesCacheados = dt
   '      Return dt(0)
   '   Else
   '      If dt.Rows.Count > 0 Then
   '         _clientesCacheados.ImportRowRange(dt.Select())
   '         Return dt(0)
   '      Else
   '         Return Nothing
   '      End If
   '   End If
   'End Function
   'Public Function BuscaClientePorFantasia(nombreCliente As String) As DataRow
   '   If _clientesCacheados IsNot Nothing Then
   '      Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), nombreCliente))
   '      If drCol.Length > 0 Then
   '         Return drCol(0)
   '      End If
   '   End If
   '   Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorNombreFantasia(nombreCliente, False)
   '   If _clientesCacheados Is Nothing Then
   '      _clientesCacheados = dt
   '      Return dt(0)
   '   Else
   '      If dt.Rows.Count > 0 Then
   '         _clientesCacheados.ImportRowRange(dt.Select())
   '         Return dt(0)
   '      Else
   '         Return Nothing
   '      End If
   '   End If
   'End Function

   'Public Function BuscaClientePorCodigo(CodigoCliente As Long) As DataRow
   '   If _clientesCacheados IsNot Nothing Then
   '      Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.CodigoCliente.ToString(), CodigoCliente))
   '      If drCol.Length > 0 Then
   '         Return drCol(0)
   '      End If
   '   End If
   '   Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorCodigo(CodigoCliente, False, True)
   '   If _clientesCacheados Is Nothing Then
   '      _clientesCacheados = dt
   '      Return dt(0)
   '   Else
   '      If dt.Rows.Count > 0 Then
   '         _clientesCacheados.ImportRowRange(dt.Select())
   '         Return dt(0)
   '      Else
   '         Return Nothing
   '      End If
   '   End If
   'End Function
   'Public Function BuscaClientePorId(IdCliente As Long) As DataRow
   '   If _clientesCacheados IsNot Nothing Then
   '      Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.IdCliente.ToString(), IdCliente))
   '      If drCol.Length > 0 Then
   '         Return drCol(0)
   '      End If
   '   End If
   '   Dim dt As DataTable = New Reglas.Clientes(Cliente.ModoClienteProspecto.Cliente).Get1(IdCliente, False)
   '   If _clientesCacheados Is Nothing Then
   '      _clientesCacheados = dt
   '      Return dt(0)
   '   Else
   '      If dt.Rows.Count > 0 Then
   '         _clientesCacheados.ImportRowRange(dt.Select())
   '         Return dt(0)
   '      Else
   '         Return Nothing
   '      End If
   '   End If
   'End Function


   Private _idProveedoresCacheado As DataTable
   Public Function ExisteProveedorPorIdRapido(idProveedor As Long) As Boolean
      If _idProveedoresCacheado Is Nothing Then
         _idProveedoresCacheado = New Reglas.Proveedores().GetAll_Ids()
      End If
      Return _idProveedoresCacheado.Select(String.Format("IdProveedor = {0}", idProveedor)).Length > 0
   End Function

#End Region

#Region "Productos"
   Private _productosCacheados As DataTable

   'Public Function BuscaCliente(nombreCliente As String) As DataRow
   '   If _clientesCacheados IsNot Nothing Then
   '      Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.NombreCliente.ToString(), nombreCliente))
   '      If drCol.Length > 0 Then
   '         Return drCol(0)
   '      End If
   '   End If
   '   Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorNombre(nombreCliente, False)
   '   If _clientesCacheados Is Nothing Then
   '      _clientesCacheados = dt
   '      Return dt(0)
   '   Else
   '      If dt.Rows.Count > 0 Then
   '         _clientesCacheados.ImportRowRange(dt.Select())
   '         Return dt(0)
   '      Else
   '         Return Nothing
   '      End If
   '   End If
   'End Function
   'Public Function BuscaClientePorFantasia(nombreCliente As String) As DataRow
   '   If _clientesCacheados IsNot Nothing Then
   '      Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), nombreCliente))
   '      If drCol.Length > 0 Then
   '         Return drCol(0)
   '      End If
   '   End If
   '   Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorNombreFantasia(nombreCliente, False)
   '   If _clientesCacheados Is Nothing Then
   '      _clientesCacheados = dt
   '      Return dt(0)
   '   Else
   '      If dt.Rows.Count > 0 Then
   '         _clientesCacheados.ImportRowRange(dt.Select())
   '         Return dt(0)
   '      Else
   '         Return Nothing
   '      End If
   '   End If
   'End Function

   'Public Function BuscaClientePorCodigo(CodigoCliente As Long) As DataRow
   '   If _clientesCacheados IsNot Nothing Then
   '      Dim drCol As DataRow() = _clientesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.CodigoCliente.ToString(), CodigoCliente))
   '      If drCol.Length > 0 Then
   '         Return drCol(0)
   '      End If
   '   End If
   '   Dim dt As DataTable = New Reglas.Clientes().GetFiltradoPorCodigo(CodigoCliente, False, True)
   '   If _clientesCacheados Is Nothing Then
   '      _clientesCacheados = dt
   '      Return dt(0)
   '   Else
   '      If dt.Rows.Count > 0 Then
   '         _clientesCacheados.ImportRowRange(dt.Select())
   '         Return dt(0)
   '      Else
   '         Return Nothing
   '      End If
   '   End If
   'End Function
   Public Function BuscaProductoPorId(idProducto As String) As DataRow
      If _productosCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _productosCacheados.Select(String.Format("{0} = '{1}'", Entidades.Producto.Columnas.IdProducto.ToString(), idProducto))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Productos().Get1(idProducto)
      If _productosCacheados Is Nothing Then
         If dt.Rows.Count > 0 Then
            _productosCacheados = dt
            Return dt.Rows(0)
         Else
            Return Nothing
         End If
      Else
         If dt.Rows.Count > 0 Then
            _productosCacheados.ImportRowRange(dt.Select())
            Return dt.Rows(0)
         Else
            Return Nothing
         End If
      End If
   End Function
   Public Function BuscaProductoPorNombre(nombreProducto As String) As DataRow
      If _productosCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _productosCacheados.Select(String.Format("{0} = '{1}'", Entidades.Producto.Columnas.NombreProducto.ToString(), nombreProducto))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Productos().GetPorNombre(nombreProducto)
      If _productosCacheados Is Nothing Then
         If dt.Rows.Count > 0 Then
            _productosCacheados = dt
            Return dt.Rows(0)
         Else
            Return Nothing
         End If
      Else
         If dt.Rows.Count > 0 Then
            _productosCacheados.ImportRowRange(dt.Select())
            Return dt.Rows(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   Private _idProductosCacheado As DataTable
   Public Function ExisteProductoPorIdRapido(idProducto As String) As Boolean
      If _idProductosCacheado Is Nothing Then
         _idProductosCacheado = New Reglas.Productos().GetAll_Ids()
      End If
      Return _idProductosCacheado.Select(String.Format("IdProducto = '{0}'", idProducto.Trim())).Length > 0
   End Function
   Public Sub AgregarParaExisteProductoPorIdRapido(idProducto As String)
      _idProductosCacheado.Rows.Add(idProducto)
   End Sub

#End Region

#Region "Productos Entidad"
   Private _productosEntidadCacheados As Dictionary(Of String, Entidades.Producto) = New Dictionary(Of String, Producto)()

   Public Function BuscaProductoEntidadPorId(idProducto As String, Optional da As Datos.DataAccess = Nothing) As Entidades.Producto
      Return BuscaProductoEntidadPorId(idProducto, Base.AccionesSiNoExisteRegistro.Excepcion, da)
   End Function
   Public Function BuscaProductoEntidadPorId(idProducto As String, accion As Reglas.Base.AccionesSiNoExisteRegistro, Optional da As Datos.DataAccess = Nothing) As Entidades.Producto
      If _productosEntidadCacheados IsNot Nothing Then
         If Not _productosEntidadCacheados.ContainsKey(idProducto) Then
            Dim r = If(da Is Nothing, New Productos(), New Productos(da))
            Dim prod = r.GetUno(idProducto, accion:=accion)
            If prod IsNot Nothing Then
               _productosEntidadCacheados.Add(idProducto, prod)
            End If
         End If
         If _productosEntidadCacheados.ContainsKey(idProducto) Then
            Return _productosEntidadCacheados(idProducto)
         Else
            Return Nothing
         End If
         'Dim prod As Entidades.Producto = _productosEntidadCacheados.FirstOrDefault(Function(x) x.IdProducto = idProducto)
         'If prod Is Nothing Then
         '   prod = New Reglas.Productos().GetUno(idProducto)
         '   If prod IsNot Nothing Then
         '      _productosEntidadCacheados.Add(prod)
         '   End If
         'End If
         'Return prod
      End If
      Return Nothing
   End Function
#End Region

#Region "Productos Liviano"
   Private _productosLivianoCacheados As Dictionary(Of String, Entidades.ProductoLivianoParaImportarProducto) = New Dictionary(Of String, Entidades.ProductoLivianoParaImportarProducto)()

   Public Function BuscaProductoLivianoPorId(idProducto As String, Optional da As Datos.DataAccess = Nothing) As Entidades.ProductoLivianoParaImportarProducto
      Return BuscaProductoLivianoPorId(idProducto, Base.AccionesSiNoExisteRegistro.Excepcion, da)
   End Function
   Public Function BuscaProductoLivianoPorId(idProducto As String, accion As Base.AccionesSiNoExisteRegistro, Optional da As Datos.DataAccess = Nothing) As Entidades.ProductoLivianoParaImportarProducto
      If _productosLivianoCacheados IsNot Nothing Then
         If Not _productosLivianoCacheados.ContainsKey(idProducto) Then
            Dim prod As Entidades.ProductoLivianoParaImportarProducto
            If da Is Nothing Then
               Dim r = New Productos()
               prod = r.GetUnoParaM(idProducto, accion:=accion)
            Else
               Dim r = New Productos(da)
               prod = r._GetUnoParaM(idProducto, accion:=accion)
            End If
            If prod IsNot Nothing Then
               _productosLivianoCacheados.Add(idProducto, prod)
            End If
         End If
         If _productosLivianoCacheados.ContainsKey(idProducto) Then
            Return _productosLivianoCacheados(idProducto)
         Else
            Return Nothing
         End If
      End If
      Return Nothing
   End Function
#End Region

#Region "Impuestos"
   Private _impuestosCacheados As List(Of Eniac.Entidades.Impuesto)
   Public Function BuscaImpuesto(idTipoImpuesto As String, alicuota As Decimal) As Eniac.Entidades.Impuesto
      If _impuestosCacheados Is Nothing Then
         _impuestosCacheados = New Eniac.Reglas.Impuestos().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.Impuesto In _impuestosCacheados
         If entidad.IdTipoImpuesto = idTipoImpuesto And entidad.Alicuota = alicuota Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteImpuesto(idTipoImpuesto As String, alicuota As Decimal) As Boolean
      Return BuscaImpuesto(idTipoImpuesto, alicuota) IsNot Nothing
   End Function
#End Region

#Region "Marcas"
   Private _marcasCacheados As List(Of Eniac.Entidades.Marca)
   Public Function GetPrimeraMarca() As Entidades.Marca
      If _marcasCacheados Is Nothing Then
         _marcasCacheados = New Eniac.Reglas.Marcas().GetTodas()
      End If
      Return _marcasCacheados.FirstOrDefault()
   End Function
   Public Function BuscaMarca(idMarca As Integer) As Eniac.Entidades.Marca
      If _marcasCacheados Is Nothing Then
         _marcasCacheados = New Eniac.Reglas.Marcas().GetTodas()
      End If

      For Each entidad As Eniac.Entidades.Marca In _marcasCacheados
         If entidad.IdMarca = idMarca Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteMarca(idMarca As Integer) As Boolean
      Return BuscaMarca(idMarca) IsNot Nothing
   End Function
#End Region

#Region "RubrosCompras"
   Private _rubrosComprasCacheados As List(Of Eniac.Entidades.RubroCompra)
   Public Function BuscaRubroCompras(idRubroCompra As Integer) As Eniac.Entidades.RubroCompra
      If _rubrosComprasCacheados Is Nothing Then
         _rubrosComprasCacheados = New Eniac.Reglas.RubrosCompras().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.RubroCompra In _rubrosComprasCacheados
         If entidad.IdRubro = idRubroCompra Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function GetPrimerRubroCompras() As Eniac.Entidades.RubroCompra
      If _rubrosComprasCacheados Is Nothing Then
         _rubrosComprasCacheados = New Eniac.Reglas.RubrosCompras().GetTodos()
      End If

      Return _rubrosComprasCacheados.FirstOrDefault()
   End Function
   Public Function ExisteRubroCompra(idRubro As Integer) As Boolean
      Return BuscaRubroCompras(idRubro) IsNot Nothing
   End Function
#End Region

#Region "Proveedores"
   Private _proveedoresCacheados As List(Of Eniac.Entidades.Proveedor)
   Public Function BuscaProveedor(idProveedor As Long) As Eniac.Entidades.Proveedor
      If _proveedoresCacheados Is Nothing Then
         _proveedoresCacheados = New Eniac.Reglas.Proveedores().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.Proveedor In _proveedoresCacheados
         If entidad.IdProveedor = idProveedor Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function BuscaProveedor(codigoProveedorLetras As String) As Eniac.Entidades.Proveedor
      If _proveedoresCacheados Is Nothing Then
         _proveedoresCacheados = New Eniac.Reglas.Proveedores().GetTodos()
      End If

      Return _proveedoresCacheados.FirstOrDefault(Function(en) en.CodigoProveedorLetras = codigoProveedorLetras)
   End Function
   Public Function ExisteProveedor(idProveedor As Long) As Boolean
      Return BuscaProveedor(idProveedor) IsNot Nothing
   End Function
#End Region

#Region "Sucursales"
   Private _sucursalesCacheados As List(Of Eniac.Entidades.Sucursal)
   Public Function BuscaSucursal(idSucursal As Integer) As Eniac.Entidades.Sucursal
      If _sucursalesCacheados Is Nothing Then
         _sucursalesCacheados = New Eniac.Reglas.Sucursales().GetTodas(False)
      End If

      For Each entidad As Eniac.Entidades.Sucursal In _sucursalesCacheados
         If entidad.IdSucursal = idSucursal Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteSucursal(idSucursal As Integer) As Boolean
      Return BuscaSucursal(idSucursal) IsNot Nothing
   End Function
#End Region

#Region "Usuarios"
   Private _usuariosCacheados As List(Of Eniac.Entidades.Usuario)
   Public Function BuscaUsuario(idUsuario As String) As Eniac.Entidades.Usuario
      If _usuariosCacheados Is Nothing Then
         _usuariosCacheados = New Eniac.Reglas.Usuarios().GetTodos(toLowerId:=True)
      End If

      For Each entidad As Eniac.Entidades.Usuario In _usuariosCacheados
         If entidad.Id = idUsuario.ToLower() Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteUsuario(idUsuario As String) As Boolean
      Return BuscaUsuario(idUsuario) IsNot Nothing
   End Function
#End Region

#Region "Modelos"
   Private _modelosCacheados As DataTable
   Public Function BuscaModelos(idModelo As Integer) As DataRow
      If _modelosCacheados Is Nothing Then
         _modelosCacheados = New Eniac.Reglas.Modelos().GetAll()
      End If

      For Each entidad As DataRow In _modelosCacheados.Select(String.Format("IdModelo = {0}", idModelo))
         Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteModelo(idModelo As Integer) As Boolean
      Return BuscaModelos(idModelo) IsNot Nothing
   End Function
#End Region

#Region "Tipos Cheques"
   Private _tiposChequesCacheados As List(Of Eniac.Entidades.TiposCheques)
   Public Function BuscaTipoCheque(idTipoCheque As String) As Eniac.Entidades.TiposCheques
      If _tiposChequesCacheados Is Nothing Then
         _tiposChequesCacheados = New Eniac.Reglas.TiposCheques().GetTodos()
      End If

      Return _tiposChequesCacheados.FirstOrDefault(Function(x) x.IdTipoCheque = idTipoCheque)
   End Function
   Public Function ExisteTipoCheque(idTipoCheque As String) As Boolean
      Return BuscaTipoCheque(idTipoCheque) IsNot Nothing
   End Function
#End Region

#Region "Bancos"
   Private _bancosCacheados As List(Of Eniac.Entidades.Banco)
   Public Function BuscaBanco(idBanco As Integer) As Eniac.Entidades.Banco
      If _bancosCacheados Is Nothing Then
         _bancosCacheados = New Eniac.Reglas.Bancos().GetTodosE()
      End If

      For Each entidad As Eniac.Entidades.Banco In _bancosCacheados
         If entidad.IdBanco = idBanco Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteBanco(idBanco As Integer) As Boolean
      Return BuscaBanco(idBanco) IsNot Nothing
   End Function
#End Region

#Region "Cuenta de Banco"
   Private _cuentaBancoCacheados As List(Of Eniac.Entidades.CuentaBanco)
   Public Function BuscaCuentaBanco(idCuentaBanco As Integer) As Eniac.Entidades.CuentaBanco
      If _cuentaBancoCacheados Is Nothing Then
         _cuentaBancoCacheados = New Eniac.Reglas.CuentasBancos().GetTodas()
      End If

      'For Each entidad As Eniac.Entidades.CuentaBanco In _cuentaBancoCacheados
      '   If entidad.IdCuentaBanco = idCuentaBanco Then Return entidad
      'Next

      'Return Nothing
      Return _cuentaBancoCacheados.Where(Function(x) x.IdCuentaBanco = idCuentaBanco).FirstOrDefault()
   End Function
   Public Function BuscaCuentaBanco(nombreCuentaBanco As String) As Eniac.Entidades.CuentaBanco
      If _cuentaBancoCacheados Is Nothing Then
         _cuentaBancoCacheados = New Eniac.Reglas.CuentasBancos().GetTodas()
      End If

      'For Each entidad As Eniac.Entidades.CuentaBanco In _cuentaBancoCacheados
      '   If entidad.NombreCuentaBanco = nombreCuentaBanco Then Return entidad
      'Next

      'Return Nothing
      Return _cuentaBancoCacheados.Where(Function(x) x.NombreCuentaBanco = nombreCuentaBanco).FirstOrDefault()
   End Function
   Public Function ExisteCuentaBanco(idCuentaBanco As Integer) As Boolean
      Return BuscaCuentaBanco(idCuentaBanco) IsNot Nothing
   End Function
#End Region


#Region "CajasNombres"
   Private _cajasNombresCacheados As List(Of Eniac.Entidades.CajaNombre)
   Public Function BuscaCajaNombre(idSucursal As Integer, idCaja As Integer) As Eniac.Entidades.CajaNombre
      If _cajasNombresCacheados Is Nothing Then
         _cajasNombresCacheados = New Eniac.Reglas.CajasNombres().GetTodas(Nothing)
      End If

      For Each entidad As Eniac.Entidades.CajaNombre In _cajasNombresCacheados
         If entidad.IdCaja = idCaja And entidad.IdSucursal = idSucursal Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteCajaNombre(idSucursal As Integer, idCaja As Integer) As Boolean
      Return BuscaCajaNombre(idSucursal, idCaja) IsNot Nothing
   End Function
#End Region

#Region "Rubros"
   Private _rubrosCacheados As List(Of Eniac.Entidades.Rubro)
   Public Sub InicializaCacheRubros()
      If _rubrosCacheados IsNot Nothing Then _rubrosCacheados.Clear()
      _rubrosCacheados = New Eniac.Reglas.Rubros().GetTodos()
   End Sub
   Public Function GetPrimerRubro() As Entidades.Rubro
      If _rubrosCacheados Is Nothing Then
         InicializaCacheRubros()
      End If
      Return _rubrosCacheados.FirstOrDefault()
   End Function
   Public Function BuscaRubro(idRubro As Integer) As Eniac.Entidades.Rubro
      If _rubrosCacheados Is Nothing Then
         InicializaCacheRubros()
      End If

      For Each entidad As Eniac.Entidades.Rubro In _rubrosCacheados
         If entidad.IdRubro = idRubro Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteRubro(idRubro As Integer) As Boolean
      Return BuscaRubro(idRubro) IsNot Nothing
   End Function
#End Region

#Region "Sub Rubro"
   Private _subRubroCacheados As DataTable
   Public Function BuscaSubRubro(idSubRubro As Integer) As DataRow
      If _subRubroCacheados Is Nothing Then
         _subRubroCacheados = New Eniac.Reglas.SubRubros().GetAll()
      End If

      For Each entidad As DataRow In _subRubroCacheados.Select(String.Format("IdSubRubro = {0}", idSubRubro))
         Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteSubRubro(idSubRubro As Integer) As Boolean
      Return BuscaSubRubro(idSubRubro) IsNot Nothing
   End Function

   Private _subRubroEntidadesCacheados As List(Of Eniac.Entidades.SubRubro)
   Public Sub InicializaCacheSubRubrosEntidad()
      If _subRubroEntidadesCacheados IsNot Nothing Then _subRubroEntidadesCacheados.Clear()
      _subRubroEntidadesCacheados = New Eniac.Reglas.SubRubros().GetTodos()
   End Sub
   Public Function BuscaSubRubroEntidad(idSubRubro As Integer) As SubRubro
      If _subRubroEntidadesCacheados Is Nothing Then
         InicializaCacheSubRubrosEntidad()
      End If

      Return _subRubroEntidadesCacheados.FirstOrDefault(Function(x) x.IdSubRubro = idSubRubro)
      'For Each entidad As DataRow In _subRubroCacheados.Select(String.Format("IdSubRubro = {0}", idSubRubro))
      '   Return entidad
      'Next

      'Return Nothing
   End Function

#End Region

#Region "Sub Sub Rubro"
   Private _subSubRubroCacheados As DataTable
   Public Function BuscaSubSubRubro(idSubSubRubro As Integer) As DataRow
      If _subSubRubroCacheados Is Nothing Then
         _subSubRubroCacheados = New Eniac.Reglas.SubSubRubros().GetAll()
      End If

      For Each entidad As DataRow In _subSubRubroCacheados.Select(String.Format("IdSubSubRubro = {0}", idSubSubRubro))
         Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteSubSubRubro(idSubSubRubro As Integer) As Boolean
      Return BuscaSubSubRubro(idSubSubRubro) IsNot Nothing
   End Function
#End Region

#Region "ClientesDescuentosRubros"
   Private _clientesDescuentosRubrosCacheados As Dictionary(Of Long, List(Of ClienteDescuentoRubro)) = New Dictionary(Of Long, List(Of ClienteDescuentoRubro))()
   Public Sub InicializaCacheClienteDescuentosRubros()
      _clientesDescuentosRubrosCacheados.Clear()
      Dim col As List(Of ClienteDescuentoRubro) = New Eniac.Reglas.ClientesDescuentosRubros().GetTodos(0)
      Dim ids = From s In col
                Select s.IdCliente
                Distinct
      For Each idCliente As Long In ids
         _clientesDescuentosRubrosCacheados.Add(idCliente, col.Where(Function(x) x.IdCliente = idCliente).ToList())
      Next
   End Sub
   Public Sub InicializaCacheClienteDescuentosRubros(idCliente As Long)
      _clientesDescuentosRubrosCacheados.Remove(idCliente)
      _clientesDescuentosRubrosCacheados.Add(idCliente, New Eniac.Reglas.ClientesDescuentosRubros().GetTodos(idCliente))
   End Sub
   Public Function BuscaClientesDescuentosRubros(idCliente As Long, idRubro As Integer) As ClienteDescuentoRubro
      If Not _clientesDescuentosRubrosCacheados.ContainsKey(idCliente) Then
         InicializaCacheClienteDescuentosRubros(idCliente)
      End If
      Return _clientesDescuentosRubrosCacheados(idCliente).FirstOrDefault(Function(x) x.IdRubro = idRubro)
   End Function
#End Region

#Region "ClientesDescuentosSubRubros"
   Private _clientesDescuentosSubRubrosCacheados As Dictionary(Of Long, List(Of ClienteDescuentoSubRubro)) = New Dictionary(Of Long, List(Of ClienteDescuentoSubRubro))()
   Public Sub InicializaCacheClienteDescuentosSubRubros()
      _clientesDescuentosSubRubrosCacheados.Clear()
      Dim col As List(Of ClienteDescuentoSubRubro) = New Eniac.Reglas.ClientesDescuentosSubRubros().GetTodos(0)
      Dim ids = From s In col
                Select s.IdCliente
                Distinct
      For Each idCliente As Long In ids
         _clientesDescuentosSubRubrosCacheados.Add(idCliente, col.Where(Function(x) x.IdCliente = idCliente).ToList())
      Next
   End Sub
   Public Sub InicializaCacheClienteDescuentosSubRubros(idCliente As Long)
      _clientesDescuentosSubRubrosCacheados.Remove(idCliente)
      _clientesDescuentosSubRubrosCacheados.Add(idCliente, New Eniac.Reglas.ClientesDescuentosSubRubros().GetTodos(idCliente))
   End Sub
   Public Function BuscaClientesDescuentosSubRubros(idCliente As Long, idSubRubro As Integer) As ClienteDescuentoSubRubro
      If Not _clientesDescuentosSubRubrosCacheados.ContainsKey(idCliente) Then
         InicializaCacheClienteDescuentosSubRubros(idCliente)
      End If
      Return _clientesDescuentosSubRubrosCacheados(idCliente).FirstOrDefault(Function(x) x.IdSubRubro = idSubRubro)
   End Function
#End Region

#Region "ClientesDescuentosMarcas"
   Private _clientesDescuentosMarcasCacheados As Dictionary(Of Long, List(Of ClienteDescuentoMarca)) = New Dictionary(Of Long, List(Of ClienteDescuentoMarca))()
   Public Sub InicializaCacheClienteDescuentosMarcas()
      _clientesDescuentosMarcasCacheados.Clear()
      Dim col As List(Of ClienteDescuentoMarca) = New Eniac.Reglas.ClientesDescuentosMarcas().GetTodos(0)
      Dim ids = From s In col
                Select s.IdCliente
                Distinct
      For Each idCliente As Long In ids
         _clientesDescuentosMarcasCacheados.Add(idCliente, col.Where(Function(x) x.IdCliente = idCliente).ToList())
      Next
   End Sub
   Public Sub InicializaCacheClienteDescuentosMarcas(idCliente As Long)
      _clientesDescuentosMarcasCacheados.Remove(idCliente)
      _clientesDescuentosMarcasCacheados.Add(idCliente, New Eniac.Reglas.ClientesDescuentosMarcas().GetTodos(idCliente))
   End Sub

   Public Function BuscaClientesDescuentosMarcas(idCliente As Long, idSubRubro As Integer) As ClienteDescuentoMarca
      If Not _clientesDescuentosMarcasCacheados.ContainsKey(idCliente) Then
         _clientesDescuentosMarcasCacheados.Add(idCliente, New Eniac.Reglas.ClientesDescuentosMarcas().GetTodos(idCliente))
      End If
      Return _clientesDescuentosMarcasCacheados(idCliente).FirstOrDefault(Function(x) x.IdMarca = idSubRubro)
   End Function
#End Region

#Region "ClientesDescuentosMarcas"
   Private _clientesDescuentosProductosCacheados As Dictionary(Of Long, DataTable) = New Dictionary(Of Long, DataTable)()
   Public Sub InicializaCacheClienteDescuentosProductos()
      InicializaCacheClienteDescuentosProductos(0)
   End Sub
   Public Sub InicializaCacheClienteDescuentosProductos(idCliente As Long)
      _clientesDescuentosProductosCacheados.Clear()
      _clientesDescuentosProductosCacheados.Add(idCliente, New Eniac.Reglas.ClientesDescuentosProductos().GetTodos(idCliente))
   End Sub
   Public Function BuscaClientesDescuentosProductos(idCliente As Long, idProducto As String) As DataRow()
      If Not _clientesDescuentosProductosCacheados.ContainsKey(idCliente) Then
         InicializaCacheClienteDescuentosProductos(idCliente)
      End If
      Return _clientesDescuentosProductosCacheados(idCliente).Select(String.Format("IdProducto = '{0}'", idProducto))
   End Function
#End Region


#Region "CategoriasDescuentosRubros"
   Private _categoriasDescuentosRubrosCacheados As Dictionary(Of Integer, List(Of Entidades.CategoriasDescuentosRubros)) = New Dictionary(Of Integer, List(Of Entidades.CategoriasDescuentosRubros))()
   Public Sub InicializaCacheCategoriasDescuentosRubros()
      _categoriasDescuentosRubrosCacheados.Clear()
      Dim col As List(Of Entidades.CategoriasDescuentosRubros) = New Eniac.Reglas.CategoriasDescuentosRubros().GetTodos(0)
      Dim ids = From s In col
                Select s.IdCategoria
                Distinct
      For Each idCategoria As Integer In ids
         _categoriasDescuentosRubrosCacheados.Add(idCategoria, col.Where(Function(x) x.IdCategoria = idCategoria).ToList())
      Next
   End Sub
   Public Sub InicializaCacheCategoriasDescuentosRubros(idCategoria As Integer)
      _categoriasDescuentosRubrosCacheados.Remove(idCategoria)
      _categoriasDescuentosRubrosCacheados.Add(idCategoria, New Eniac.Reglas.CategoriasDescuentosRubros().GetTodos(idCategoria))
   End Sub
   Public Function BuscaCategoriasDescuentosRubros(idCategoria As Integer, idRubro As Integer) As Entidades.CategoriasDescuentosRubros
      If Not _categoriasDescuentosRubrosCacheados.ContainsKey(idCategoria) Then
         InicializaCacheCategoriasDescuentosRubros(idCategoria)
      End If
      Return _categoriasDescuentosRubrosCacheados(idCategoria).FirstOrDefault(Function(x) x.IdRubro = idRubro)
   End Function
#End Region

#Region "CategoriasDescuentosSubRubros"

   Private _categoriasDescuentosSubRubrosCacheados As Dictionary(Of Integer, List(Of Entidades.CategoriasDescuentosSubRubros)) = New Dictionary(Of Integer, List(Of Entidades.CategoriasDescuentosSubRubros))()
   Public Sub InicializaCacheCategoriasDescuentosSubRubros()
      _categoriasDescuentosSubRubrosCacheados.Clear()
      Dim col As List(Of Entidades.CategoriasDescuentosSubRubros) = New Eniac.Reglas.CategoriasDescuentosSubRubros().GetTodos(0)
      Dim ids = From s In col
                Select s.IdCategoria
                Distinct
      For Each idCategoria As Integer In ids
         _categoriasDescuentosSubRubrosCacheados.Add(idCategoria, col.Where(Function(x) x.IdCategoria = idCategoria).ToList())
      Next
   End Sub
   Public Sub InicializaCacheCategoriasDescuentosSubRubros(idCategoria As Integer)
      _categoriasDescuentosSubRubrosCacheados.Remove(idCategoria)
      _categoriasDescuentosSubRubrosCacheados.Add(idCategoria, New Eniac.Reglas.CategoriasDescuentosSubRubros().GetTodos(idCategoria))
   End Sub
   Public Function BuscaCategoriasDescuentosSubRubros(idCategoria As Integer, idRubro As Integer, idSubRubro As Integer) As Entidades.CategoriasDescuentosSubRubros
      If Not _categoriasDescuentosSubRubrosCacheados.ContainsKey(idCategoria) Then
         _categoriasDescuentosSubRubrosCacheados.Add(idCategoria, New Reglas.CategoriasDescuentosSubRubros().GetTodos(idCategoria))
      End If
      Return _categoriasDescuentosSubRubrosCacheados(idCategoria).FirstOrDefault(Function(x) x.IdRubro = idRubro And x.IdSubRubro = idSubRubro)
   End Function
#End Region

#Region "CategoriasDescuentosSubSubRubros"
   Private _categoriasDescuentosSubSubRubrosCacheados As Dictionary(Of Integer, List(Of Entidades.CategoriasDescuentosSubSubRubros)) = New Dictionary(Of Integer, List(Of Entidades.CategoriasDescuentosSubSubRubros))()
   Public Sub InicializaCacheCategoriasDescuentosSubSubRubros()
      _categoriasDescuentosSubSubRubrosCacheados.Clear()
      Dim col As List(Of Entidades.CategoriasDescuentosSubSubRubros) = New Eniac.Reglas.CategoriasDescuentosSubSubRubros().GetTodos(0)
      Dim ids = From s In col
                Select s.IdCategoria
                Distinct
      For Each idCategoria As Integer In ids
         _categoriasDescuentosSubSubRubrosCacheados.Add(idCategoria, col.Where(Function(x) x.IdCategoria = idCategoria).ToList())
      Next
   End Sub
   Public Sub InicializaCacheCategoriasDescuentosSubSubRubros(idCategoria As Integer)
      _categoriasDescuentosSubSubRubrosCacheados.Remove(idCategoria)
      _categoriasDescuentosSubSubRubrosCacheados.Add(idCategoria, New Eniac.Reglas.CategoriasDescuentosSubSubRubros().GetTodos(idCategoria))
   End Sub
   Public Function BuscaCategoriasDescuentosSubSubRubros(idCategoria As Integer, idRubro As Integer, idSubRubro As Integer, idSubSubRubro As Integer) As Entidades.CategoriasDescuentosSubSubRubros
      If Not _categoriasDescuentosSubSubRubrosCacheados.ContainsKey(idCategoria) Then
         InicializaCacheCategoriasDescuentosSubSubRubros(idCategoria)
      End If
      Return _categoriasDescuentosSubSubRubrosCacheados(idCategoria).FirstOrDefault(Function(x) x.IdRubro = idRubro And x.IdSubRubro = idSubRubro And x.IdSubSubRubro = idSubSubRubro)
   End Function
#End Region


#Region "Monedas"
   Private _monedasCacheados As List(Of Eniac.Entidades.Moneda)
   Public Function BuscaMoneda(idMoneda As Integer) As Eniac.Entidades.Moneda
      If _monedasCacheados Is Nothing Then
         _monedasCacheados = New Eniac.Reglas.Monedas().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.Moneda In _monedasCacheados
         If entidad.IdMoneda = idMoneda Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteMoneda(idMoneda As Integer) As Boolean
      Return BuscaMoneda(idMoneda) IsNot Nothing
   End Function
#End Region

#Region "Produccion Formas"
   Private _produccionFormasCacheados As List(Of Eniac.Entidades.ProduccionForma)
   Public Function BuscaProduccionForma(idProduccionForma As Integer) As Eniac.Entidades.ProduccionForma
      If _produccionFormasCacheados Is Nothing Then
         _produccionFormasCacheados = New Eniac.Reglas.ProduccionFormas().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.ProduccionForma In _produccionFormasCacheados
         If entidad.IdProduccionForma = idProduccionForma Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteProduccionForma(idProduccionForma As Integer) As Boolean
      Return BuscaProduccionForma(idProduccionForma) IsNot Nothing
   End Function
#End Region

#Region "Produccion Procesos"
   Private _produccionProcesosCacheados As List(Of Eniac.Entidades.ProduccionProceso)
   Public Function BuscaProduccionProceso(idProduccionProceso As Integer) As Eniac.Entidades.ProduccionProceso
      If _produccionProcesosCacheados Is Nothing Then
         _produccionProcesosCacheados = New Eniac.Reglas.ProduccionProcesos().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.ProduccionProceso In _produccionProcesosCacheados
         If entidad.IdProduccionProceso = idProduccionProceso Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteProduccionProceso(idProduccionForma As Integer) As Boolean
      Return BuscaProduccionProceso(idProduccionForma) IsNot Nothing
   End Function
#End Region

#Region "ProductosSucursales"
   Private _productosSucursalesCacheados As Dictionary(Of String, Eniac.Entidades.ProductoSucursal)
   Public Function GetProductosSucursales(idSucursal As Integer, idProducto As String, idListaPrecios As Integer) As Eniac.Entidades.ProductoSucursal
      Return GetProductosSucursales(idSucursal, idProducto, idListaPrecios, Nothing)
   End Function
   Public Function GetProductosSucursales(idSucursal As Integer, idProducto As String, idListaPrecios As Integer, da As Eniac.Datos.DataAccess) As Eniac.Entidades.ProductoSucursal
      If _productosSucursalesCacheados Is Nothing Then _productosSucursalesCacheados = New Dictionary(Of String, Eniac.Entidades.ProductoSucursal)()
      Dim key As String = String.Format("{0}|||{1}|||{2}", idSucursal, idProducto, idListaPrecios)

      If Not _productosSucursalesCacheados.ContainsKey(key) Then
         Dim producto As Eniac.Entidades.ProductoSucursal
         Try
            Dim rProdSuc As Eniac.Reglas.ProductosSucursales
            If da Is Nothing Then
               rProdSuc = New Eniac.Reglas.ProductosSucursales()
            Else
               rProdSuc = New Eniac.Reglas.ProductosSucursales(da)
            End If
            producto = rProdSuc.GetUno(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal, idProducto, idListaPrecios)
         Catch ex As Exception
            producto = Nothing
         End Try
         If producto IsNot Nothing Then
            _productosSucursalesCacheados.Add(key, producto)
         End If
      End If

      If _productosSucursalesCacheados.ContainsKey(key) Then
         Return _productosSucursalesCacheados(key)
      Else
         Return Nothing
      End If
   End Function
#End Region

#Region "Tipos de Comprobantes"
   Private _tiposComprobantesCacheados As List(Of Eniac.Entidades.TipoComprobante)
   Public Function BuscaTipoComprobante(idTipoComprobante As String) As Eniac.Entidades.TipoComprobante
      If _tiposComprobantesCacheados Is Nothing Then
         _tiposComprobantesCacheados = New Eniac.Reglas.TiposComprobantes().GetTodos()
      End If

      For Each tpComp As Eniac.Entidades.TipoComprobante In _tiposComprobantesCacheados
         If tpComp.IdTipoComprobante = idTipoComprobante Then Return tpComp
      Next

      Return Nothing
   End Function
   Public Function ExisteTipoComprobante(idTipoComprobante As String) As Boolean
      Return BuscaTipoComprobante(idTipoComprobante) IsNot Nothing
   End Function
#End Region

#Region "Tipos de Movimiento"
   Private _tiposMovimientoCacheados As List(Of Eniac.Entidades.TipoMovimiento)
   Public Function BuscaTipoMovimiento(idTipoMovimiento As String) As Eniac.Entidades.TipoMovimiento
      If _tiposMovimientoCacheados Is Nothing Then
         _tiposMovimientoCacheados = New Eniac.Reglas.TiposMovimientos().GetTodos()
      End If

      For Each tpComp As Eniac.Entidades.TipoMovimiento In _tiposMovimientoCacheados
         If tpComp.IdTipoMovimiento = idTipoMovimiento Then Return tpComp
      Next

      Return Nothing
   End Function
   Public Function BuscaTipoMovimientoReservaMercaderia() As Eniac.Entidades.TipoMovimiento
      If _tiposMovimientoCacheados Is Nothing Then
         _tiposMovimientoCacheados = New Eniac.Reglas.TiposMovimientos().GetTodos()
      End If

      For Each tpComp As Eniac.Entidades.TipoMovimiento In _tiposMovimientoCacheados
         If tpComp.ReservaMercaderia Then Return tpComp
      Next
      Return Nothing
   End Function
   'Public Function ExisteProyecto(codigoProyecto As Integer) As Boolean
   '   Return BuscaProyecto(codigoProyecto) IsNot Nothing
   'End Function
#End Region

#Region "Formas de Pago"
   Private _formasPagoCacheados As List(Of Eniac.Entidades.VentaFormaPago)
   Public Function BuscaFormasPago(IdFormasPago As Integer) As Eniac.Entidades.VentaFormaPago
      If _formasPagoCacheados Is Nothing Then
         _formasPagoCacheados = New Eniac.Reglas.VentasFormasPago().GetTodas("TODAS", contado:=Nothing)
      End If

      For Each fPago As Eniac.Entidades.VentaFormaPago In _formasPagoCacheados
         If fPago.IdFormasPago = IdFormasPago Then Return fPago
      Next

      Return Nothing
   End Function
   Public Function BuscaFormasPago(nombreFormasPago As String) As Eniac.Entidades.VentaFormaPago
      If _formasPagoCacheados Is Nothing Then
         _formasPagoCacheados = New Eniac.Reglas.VentasFormasPago().GetTodas("TODAS", contado:=Nothing)
      End If

      For Each fPago As Eniac.Entidades.VentaFormaPago In _formasPagoCacheados
         If fPago.DescripcionFormasPago = nombreFormasPago Then Return fPago
      Next

      Return Nothing
   End Function
   Public Function ExisteFormasPago(IdFormasPago As Integer) As Boolean
      Return BuscaFormasPago(IdFormasPago) IsNot Nothing
   End Function
   Public Function ExisteFormasPago(nombreFormasPago As String) As Boolean
      Return BuscaFormasPago(nombreFormasPago) IsNot Nothing
   End Function
#End Region

#Region "Localidades"
   Private _localidadesCacheados As List(Of Eniac.Entidades.Localidad)
   Public Function BuscaLocalidad(idLocalidad As Integer) As Eniac.Entidades.Localidad
      If _localidadesCacheados Is Nothing Then
         _localidadesCacheados = New List(Of Localidad)()
      End If

      For Each entidad As Eniac.Entidades.Localidad In _localidadesCacheados
         If entidad.IdLocalidad = idLocalidad Then Return entidad
      Next

      Try
         Dim localidad As Localidad = New Reglas.Localidades().GetUna(idLocalidad)
         _localidadesCacheados.Add(localidad)
         Return localidad
      Catch ex As Exception
         Return Nothing
      End Try
   End Function
   Public Function BuscaLocalidadPorNombre(nombreLocalidad As String) As Eniac.Entidades.Localidad
      If _localidadesCacheados Is Nothing Then
         _localidadesCacheados = New List(Of Localidad)()
      End If

      For Each entidad As Eniac.Entidades.Localidad In _localidadesCacheados
         If entidad.NombreLocalidad = nombreLocalidad Then Return entidad
      Next

      Try
         Dim localidad As Localidad = New Reglas.Localidades().GetPorNombreEntidad(nombreLocalidad, Base.AccionesSiNoExisteRegistro.Nulo)
         If localidad IsNot Nothing Then
            _localidadesCacheados.Add(localidad)
         End If
         Return localidad
      Catch ex As Exception
         Return Nothing
      End Try
   End Function
   Public Function ExisteLocalidad(idLocalidad As Integer) As Boolean
      Return BuscaLocalidad(idLocalidad) IsNot Nothing
   End Function
#End Region

#Region "Provincias"
   Private _provinciasCacheados As List(Of Eniac.Entidades.Provincia)
   Public Function BuscaProvincia(idProvincia As String) As Eniac.Entidades.Provincia
      If _provinciasCacheados Is Nothing Then
         _provinciasCacheados = New Reglas.Provincias().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.Provincia In _provinciasCacheados
         If entidad.IdProvincia = idProvincia Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteProvincia(idProvincia As String) As Boolean
      Return BuscaProvincia(idProvincia) IsNot Nothing
   End Function
#End Region

#Region "Categorias"
   Private _categoriasCacheados As List(Of Eniac.Entidades.Categoria)
   Public Sub InicializaCacheCategorias()
      If _categoriasCacheados IsNot Nothing Then _categoriasCacheados.Clear()
      _categoriasCacheados = New Eniac.Reglas.Categorias().GetTodas()
   End Sub
   Public Function BuscaCategoria(idCategoria As Integer) As Eniac.Entidades.Categoria
      If _categoriasCacheados Is Nothing Then
         InicializaCacheCategorias()
      End If

      For Each entidad As Eniac.Entidades.Categoria In _categoriasCacheados
         If entidad.IdCategoria = idCategoria Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteCategoria(idCategoria As Integer) As Boolean
      Return BuscaCategoria(idCategoria) IsNot Nothing
   End Function
#End Region

#Region "Estado Venta"
   Private _estadoVentaCacheados As List(Of Eniac.Entidades.EstadoVenta)
   Public Sub InicializaCacheEstadoVenta()
      If _estadoVentaCacheados IsNot Nothing Then _estadoVentaCacheados.Clear()
      _estadoVentaCacheados = New Eniac.Reglas.EstadosVenta().GetTodos()
   End Sub
   Public Function BuscaEstadoVenta(idEstadoVenta As Integer) As Eniac.Entidades.EstadoVenta
      If _estadoVentaCacheados Is Nothing Then
         InicializaCacheEstadoVenta()
      End If

      Return _estadoVentaCacheados.FirstOrDefault(Function(x) x.IdEstadoVenta = idEstadoVenta)
   End Function
   Public Function ExisteEstadoVenta(idEstadoVenta As Integer) As Boolean
      Return BuscaEstadoVenta(idEstadoVenta) IsNot Nothing
   End Function
#End Region


#Region "Concepto"
   Private _conceptosCacheados As List(Of Eniac.Entidades.Concepto)
   Public Function BuscaConcepto(idConcepto As Integer) As Eniac.Entidades.Concepto
      If _conceptosCacheados Is Nothing Then
         _conceptosCacheados = New Eniac.Reglas.Conceptos().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.Concepto In _conceptosCacheados
         If entidad.IdConcepto = idConcepto Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteConcepto(idConcepto As Integer) As Boolean
      Return BuscaConcepto(idConcepto) IsNot Nothing
   End Function
#End Region

#Region "Cobrador"
   Private _cobradorCacheados As List(Of Entidades.Empleado)
   Private Sub InicializaCobrador()
      If _cobradorCacheados Is Nothing Then
         _cobradorCacheados = New Empleados().GetPorTipo(Entidades.Publicos.TiposEmpleados.COBRADOR, "", conDebitoTarjeta:=False)
      End If
   End Sub
   Public Function BuscaCobrador(IdCobrador As Integer) As Entidades.Empleado
      InicializaCobrador()
      Return _cobradorCacheados.FirstOrDefault(Function(x) x.IdEmpleado = IdCobrador)
   End Function
   Public Function BuscaCobrador(nombreCobrador As String) As Entidades.Empleado
      InicializaCobrador()
      Return _cobradorCacheados.FirstOrDefault(Function(x) x.NombreEmpleado = nombreCobrador)
   End Function
   Public Function BuscaCobradorPorIdDispositivo(idDispositivo As String) As Entidades.Empleado
      InicializaCobrador()
      Return _cobradorCacheados.FirstOrDefault(Function(x) x.IdDispositivo = idDispositivo)
   End Function
   Public Function BuscaCobradorPorIdUsuarioMovil(idUsuarioMovil As String) As Entidades.Empleado
      InicializaCobrador()
      Return _cobradorCacheados.FirstOrDefault(Function(x) x.IdUsuarioMovil.IfNull().ToLower() = idUsuarioMovil.ToLower())
   End Function
   Public Function ExisteCobrador(IdCobrador As Integer) As Boolean
      Return BuscaCobrador(IdCobrador) IsNot Nothing
   End Function
#End Region

#Region "Categorias Fiscales"
   Private _categoriasFiscalesCacheados As List(Of Eniac.Entidades.CategoriaFiscal)
   Public Function BuscaCategoriaFiscal(idCategoriaFiscal As Integer) As Eniac.Entidades.CategoriaFiscal
      If _categoriasFiscalesCacheados Is Nothing Then
         _categoriasFiscalesCacheados = New Eniac.Reglas.CategoriasFiscales().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.CategoriaFiscal In _categoriasFiscalesCacheados
         If entidad.IdCategoriaFiscal = idCategoriaFiscal Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteCategoriaFiscal(idCategoriaFiscal As Integer) As Boolean
      Return BuscaCategoriaFiscal(idCategoriaFiscal) IsNot Nothing
   End Function
#End Region

#Region "Lista de Precios"
   Private _listaDePreciosCacheados As List(Of Eniac.Entidades.ListaDePrecios)
   Public Function BuscaListaDePrecios(idListaPrecios As Integer) As Eniac.Entidades.ListaDePrecios
      If _listaDePreciosCacheados Is Nothing Then
         _listaDePreciosCacheados = New Eniac.Reglas.ListasDePrecios().GetTodos()
      End If

      For Each listaPrecios As Eniac.Entidades.ListaDePrecios In _listaDePreciosCacheados
         If listaPrecios.IdListaPrecios = idListaPrecios Then Return listaPrecios
      Next

      Return Nothing
   End Function
   Public Function BuscaListaDePrecios(nombreListaPrecios As String) As Eniac.Entidades.ListaDePrecios
      If _listaDePreciosCacheados Is Nothing Then
         _listaDePreciosCacheados = New Eniac.Reglas.ListasDePrecios().GetTodos()
      End If

      For Each listaPrecios As Eniac.Entidades.ListaDePrecios In _listaDePreciosCacheados
         If listaPrecios.NombreListaPrecios = nombreListaPrecios Then Return listaPrecios
      Next

      Return Nothing
   End Function
   Public Function ExisteListaDePrecios(idListaPrecios As Integer) As Boolean
      Return BuscaListaDePrecios(idListaPrecios) IsNot Nothing
   End Function
#End Region

#Region "Empleados"
   Private _empleadosCacheados As List(Of Eniac.Entidades.Empleado)
   Public Function GetPrimerComprador() As Entidades.Empleado
      If _empleadosCacheados Is Nothing Then
         _empleadosCacheados = New Eniac.Reglas.Empleados().GetTodos(False)
      End If
      Return _empleadosCacheados.FirstOrDefault(Function(x) x.EsCobrador)
   End Function
   Public Function BuscaEmpleado(IdEmpleado As Integer, Optional incluyeComisiones As Boolean = False) As Eniac.Entidades.Empleado
      If _empleadosCacheados Is Nothing Then
         _empleadosCacheados = New Eniac.Reglas.Empleados().GetTodos(incluyeComisiones)
      End If

      For Each entidad As Eniac.Entidades.Empleado In _empleadosCacheados
         If entidad.IdEmpleado = IdEmpleado Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function BuscaEmpleado(nombreEmpleado As String, Optional incluyeComisiones As Boolean = False) As Eniac.Entidades.Empleado
      If _empleadosCacheados Is Nothing Then
         _empleadosCacheados = New Eniac.Reglas.Empleados().GetTodos(incluyeComisiones)
      End If

      For Each entidad As Eniac.Entidades.Empleado In _empleadosCacheados
         If entidad.NombreEmpleado = nombreEmpleado Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function BuscaEmpleado(tipoDocEmpleado As String, nroDocEmpleado As String, Optional incluyeComisiones As Boolean = False) As Eniac.Entidades.Empleado
      If _empleadosCacheados Is Nothing Then
         _empleadosCacheados = New Eniac.Reglas.Empleados().GetTodos(incluyeComisiones)
      End If

      Return _empleadosCacheados.FirstOrDefault(Function(x) x.TipoDocEmpleado = tipoDocEmpleado And x.NroDocEmpleado = nroDocEmpleado)
   End Function
   Public Function ExisteEmpleado(IdEmpleado As Integer) As Boolean
      Return BuscaEmpleado(IdEmpleado) IsNot Nothing
   End Function
#End Region

#Region "Estados Clientes"
   Private _estadosClientesCacheados As List(Of Eniac.Entidades.EstadoCliente)
   Public Function BuscaEstadosClientes(idEstadoCliente As Integer) As Eniac.Entidades.EstadoCliente
      If _estadosClientesCacheados Is Nothing Then
         _estadosClientesCacheados = New Eniac.Reglas.EstadosClientes().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.EstadoCliente In _estadosClientesCacheados
         If entidad.IdEstadoCliente = idEstadoCliente Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteEstadosClientes(idEstadoCliente As Integer) As Boolean
      Return BuscaEstadosClientes(idEstadoCliente) IsNot Nothing
   End Function
#End Region

#Region "Tipos de Clientes"
   Private _tiposClientesCacheados As List(Of Eniac.Entidades.TipoCliente)
   Public Function BuscaTiposClientes(idTipoCliente As Integer) As Eniac.Entidades.TipoCliente
      If _tiposClientesCacheados Is Nothing Then
         _tiposClientesCacheados = New Eniac.Reglas.TiposClientes().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.TipoCliente In _tiposClientesCacheados
         If entidad.IdTipoCliente = idTipoCliente Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteTiposClientes(idTipoCliente As Integer) As Boolean
      Return BuscaTiposClientes(idTipoCliente) IsNot Nothing
   End Function
#End Region

#Region "Transportistas"
   Private _transportistaCacheados As List(Of Eniac.Entidades.Transportista)
   Public Function BuscaTransportista(idTransportista As Integer) As Eniac.Entidades.Transportista
      If _transportistaCacheados Is Nothing Then
         _transportistaCacheados = New Eniac.Reglas.Transportistas().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.Transportista In _transportistaCacheados
         If entidad.idTransportista = idTransportista Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteTransportista(idTransportista As Integer) As Boolean
      Return BuscaTransportista(idTransportista) IsNot Nothing
   End Function
#End Region

#Region "Zona Geografica"
   Private _zonaGeograficaCacheados As List(Of Eniac.Entidades.ZonaGeografica)
   Public Function BuscaZonaGeografica(IdZonaGeografica As String) As Eniac.Entidades.ZonaGeografica
      If _zonaGeograficaCacheados Is Nothing Then
         _zonaGeograficaCacheados = New Eniac.Reglas.ZonasGeograficas().GetTodas()
      End If

      For Each entidad As Eniac.Entidades.ZonaGeografica In _zonaGeograficaCacheados
         If entidad.IdZonaGeografica = IdZonaGeografica Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteZonaGeografica(IdZonaGeografica As String) As Boolean
      Return BuscaZonaGeografica(IdZonaGeografica) IsNot Nothing
   End Function
#End Region

#Region "Tipos de Exension"
   Private _tiposExensionesCacheados As List(Of Eniac.Entidades.TipoDeExension)
   Public Function BuscaTiposDeExension(idTipoDeExension As Integer) As Eniac.Entidades.TipoDeExension
      If _tiposExensionesCacheados Is Nothing Then
         _tiposExensionesCacheados = New Eniac.Reglas.TiposDeExension().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.TipoDeExension In _tiposExensionesCacheados
         If entidad.IdTipoDeExension = idTipoDeExension Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteTiposDeExension(idTipoDeExension As Integer) As Boolean
      Return BuscaTiposDeExension(idTipoDeExension) IsNot Nothing
   End Function
#End Region

#Region "Estados Ordenes de Producccion"
   Private _estadosOrdenesProduccionCacheados As List(Of Eniac.Entidades.EstadoOrdenProduccion)
   Public Function BuscaEstadosOrdenesProduccion(idEstado As String) As Eniac.Entidades.EstadoOrdenProduccion
      Return BuscaEstadosOrdenesProduccion(idEstado, Base.AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function BuscaEstadosOrdenesProduccion(idEstado As String, accion As Reglas.Base.AccionesSiNoExisteRegistro) As Entidades.EstadoOrdenProduccion
      If _estadosOrdenesProduccionCacheados Is Nothing Then
         _estadosOrdenesProduccionCacheados = New Eniac.Reglas.EstadosOrdenesProduccion().GetTodos()
      End If         'If _estadosOrdenesProduccionCacheados Is Nothing Then

      Dim result = _estadosOrdenesProduccionCacheados.FirstOrDefault(Function(e) e.IdEstado = idEstado)
      If result IsNot Nothing Then
         Return result
      End If
      If accion = Base.AccionesSiNoExisteRegistro.Excepcion Then
         Throw New Exception(String.Format("No existe Estado de OP con id {0}", idEstado))
      ElseIf accion = Base.AccionesSiNoExisteRegistro.Vacio Then
         Return New EstadoOrdenProduccion()
      End If
      Return Nothing
   End Function
   Public Function ExisteEstadosOrdenesProduccion(idEstado As String) As Boolean
      Return BuscaEstadosOrdenesProduccion(idEstado, Base.AccionesSiNoExisteRegistro.Nulo) IsNot Nothing
   End Function
#End Region

#Region "Criticidades Ordenes de Producccion"
   Private _ordenesProduccionCriticidadesCacheados As List(Of Entidades.CriticidadOrdenProduccion)
   Public Function BuscaCriticidadesOrdenesProduccion(idCriticidad As String) As Entidades.CriticidadOrdenProduccion
      Return BuscaCriticidadesOrdenesProduccion(idCriticidad, Base.AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function BuscaCriticidadesOrdenesProduccion(idCriticidad As String, accion As Base.AccionesSiNoExisteRegistro) As Entidades.CriticidadOrdenProduccion
      If _ordenesProduccionCriticidadesCacheados Is Nothing Then
         _ordenesProduccionCriticidadesCacheados = New CriticidadesOrdenesProduccion().GetTodos()
      End If         'If _ordenesProduccionCriticidadesCacheados Is Nothing Then

      Dim result = _ordenesProduccionCriticidadesCacheados.FirstOrDefault(Function(e) e.IdCriticidad = idCriticidad)
      If result IsNot Nothing Then
         Return result
      End If
      If accion = Base.AccionesSiNoExisteRegistro.Excepcion Then
         Throw New Exception(String.Format("No existe Criticidad de OP con id {0}", idCriticidad))
      ElseIf accion = Base.AccionesSiNoExisteRegistro.Vacio Then
         Return New CriticidadOrdenProduccion()
      End If
      Return Nothing
   End Function
   Public Function ExisteCriticidadesOrdenesProduccion(idCriticidad As String) As Boolean
      Return BuscaCriticidadesOrdenesProduccion(idCriticidad, Base.AccionesSiNoExisteRegistro.Nulo) IsNot Nothing
   End Function
#End Region

#Region "Estados Pedidos"
   Private _estadosPedidosCacheados As Dictionary(Of String, List(Of Eniac.Entidades.EstadoPedido))
   Public Function BuscaEstadosPedido(idEstado As String, TipoEstadoPedido As String) As Eniac.Entidades.EstadoPedido
      Return BuscaEstadosPedido(idEstado, TipoEstadoPedido, Base.AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function BuscaEstadosPedido(idEstado As String, TipoEstadoPedido As String, accion As Reglas.Base.AccionesSiNoExisteRegistro) As Eniac.Entidades.EstadoPedido
      If _estadosPedidosCacheados Is Nothing Then
         _estadosPedidosCacheados = New Dictionary(Of String, List(Of Entidades.EstadoPedido))()
      End If         'If _estadosPedidosCacheados Is Nothing Then
      If Not _estadosPedidosCacheados.ContainsKey(TipoEstadoPedido) Then
         _estadosPedidosCacheados.Add(TipoEstadoPedido, New Eniac.Reglas.EstadosPedidos().GetTodos(TipoEstadoPedido))
      End If         'If Not _estadosPedidosCacheados.ContainsKey(TipoEstadoPedido) Then

      For Each estado As Eniac.Entidades.EstadoPedido In _estadosPedidosCacheados(TipoEstadoPedido)
         If estado.IdEstado = idEstado Then Return estado
      Next           'For Each estado As Eniac.Entidades.EstadoPedido In _estadosPedidosCacheados(TipoEstadoPedido)

      If accion = Base.AccionesSiNoExisteRegistro.Nulo Then
         Return Nothing
      ElseIf accion = Base.AccionesSiNoExisteRegistro.Vacio Then
         Return New EstadoPedido()
      Else
         Throw New Exception(String.Format("No existe Estado con Id: {0} y tipo {1}", idEstado, TipoEstadoPedido))
      End If
   End Function
#End Region

#Region "Estados Pedidos Proveedores"
   Private _estadosPedidosProveedoresCacheados As Dictionary(Of String, List(Of Eniac.Entidades.EstadoPedidoProveedor))
   Public Function BuscaEstadosPedidoProveedores(idEstado As String, TipoEstadoPedido As String) As Eniac.Entidades.EstadoPedidoProveedor
      PreparaCacheEstadoPedidosProveedores(TipoEstadoPedido)

      For Each estado As Eniac.Entidades.EstadoPedidoProveedor In _estadosPedidosProveedoresCacheados(TipoEstadoPedido)
         If estado.IdEstado = idEstado Then Return estado
      Next           'For Each estado As Eniac.Entidades.EstadoPedido In _estadosPedidosCacheados(TipoEstadoPedido)

      Return Nothing
   End Function

   Public Function BuscaEstadosPedidoProveedoresParaFacturar(TipoEstadoPedido As String) As List(Of Eniac.Entidades.EstadoPedidoProveedor)
      PreparaCacheEstadoPedidosProveedores(TipoEstadoPedido)

      Return _estadosPedidosProveedoresCacheados(TipoEstadoPedido).Where(Function(e) Not String.IsNullOrWhiteSpace(e.IdEstadoFacturado)).ToList()
   End Function
   Private Sub PreparaCacheEstadoPedidosProveedores(TipoEstadoPedido As String)
      If _estadosPedidosProveedoresCacheados Is Nothing Then
         _estadosPedidosProveedoresCacheados = New Dictionary(Of String, List(Of Entidades.EstadoPedidoProveedor))()
      End If         'If _estadosPedidosCacheados Is Nothing Then
      If Not _estadosPedidosProveedoresCacheados.ContainsKey(TipoEstadoPedido) Then
         _estadosPedidosProveedoresCacheados.Add(TipoEstadoPedido, New Eniac.Reglas.EstadosPedidosProveedores().GetTodos(TipoEstadoPedido))
      End If         'If Not _estadosPedidosCacheados.ContainsKey(TipoEstadoPedido) Then
   End Sub
#End Region

#Region "Contabilidad"
#Region "Centro de Costos"
   Private _centroCostosCacheados As List(Of Eniac.Entidades.ContabilidadCentroCosto)
   Public Function BuscaCentrosCostos(idCentroCostos As Integer) As Eniac.Entidades.ContabilidadCentroCosto
      If _centroCostosCacheados Is Nothing Then
         _centroCostosCacheados = New Eniac.Reglas.ContabilidadCentrosCostos().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.ContabilidadCentroCosto In _centroCostosCacheados
         If entidad.IdCentroCosto = idCentroCostos Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteCentrosCostos(idCentroCostos As Integer) As Boolean
      Return BuscaCentrosCostos(idCentroCostos) IsNot Nothing
   End Function
#End Region
#Region "Cuentas Contables"
   Private _idCuentasContablesCacheado As DataTable
   Public Function ExisteCuentaContablePorIdRapido(idCuenta As Long) As Boolean
      If _idCuentasContablesCacheado Is Nothing Then
         _idCuentasContablesCacheado = New Reglas.ContabilidadCuentas().GetAll_Ids()
      End If
      Return _idCuentasContablesCacheado.Select(String.Format("IdCuenta = {0}", idCuenta)).Length > 0
   End Function
#End Region
#End Region

#Region "Feriados"
#Region "Cobrador"
   Private _feriadosCacheados As List(Of Entidades.Feriado)
   Public Function BuscaFeriado(fecha As Date) As Entidades.Feriado
      InicializaCacheFeriados(fecha)

      Return _feriadosCacheados.FirstOrDefault(Function(f) f.FechaFeriado.Date = fecha.Date)
   End Function
   Public Function EsFeriado(fecha As Date) As Boolean
      Return BuscaFeriado(fecha) IsNot Nothing
   End Function
   Private Sub InicializaCacheFeriados(fecha As Date)
      If _feriadosCacheados Is Nothing Then
         'Busco desde el año pasado hacia el futuro. Para ya tener cache de fechas anteriores por las dudas que la necesite posteriormente, pero no cargo los N años hacia atrás. Es más improbable.
         _feriadosCacheados = New Feriados().GetTodos(fechaFeriadoDesde:=fecha.AddYears(-1).PrimerDiaAnio(), fechaFeriadoHasta:=Nothing)
      End If
      If _feriadosCacheados.First().FechaFeriado.Year > fecha.Year Then
         'Recacheo ya que la fecha es anterior y es posible que cuando inicialicé el cache la fecha haya tenido dos año o más de diferencia con esta fecha
         _feriadosCacheados = New Feriados().GetTodos(fechaFeriadoDesde:=fecha.AddYears(-1).PrimerDiaAnio(), fechaFeriadoHasta:=Nothing)
      End If
   End Sub
#End Region

#End Region

#Region "Tipos de Clientes"
   Private _tiposImpuestosCacheados As List(Of Eniac.Entidades.TipoImpuesto)
   Public Function BuscaTiposImpuestos(idTipoImpuesto As String) As Eniac.Entidades.TipoImpuesto
      Return BuscaTiposImpuestos(DirectCast([Enum].Parse(GetType(Entidades.TipoImpuesto.Tipos), idTipoImpuesto), Entidades.TipoImpuesto.Tipos))
   End Function
   Public Function BuscaTiposImpuestos(idTipoImpuesto As Entidades.TipoImpuesto.Tipos) As Eniac.Entidades.TipoImpuesto
      If _tiposImpuestosCacheados Is Nothing Then
         _tiposImpuestosCacheados = New Eniac.Reglas.TiposImpuestos().GetTodos()
      End If

      For Each entidad As Eniac.Entidades.TipoImpuesto In _tiposImpuestosCacheados
         If entidad.IdTipoImpuesto = idTipoImpuesto Then Return entidad
      Next

      Return Nothing
   End Function
   Public Function ExisteTiposImpuestos(idTipoCliente As String) As Boolean
      Return BuscaTiposImpuestos(idTipoCliente) IsNot Nothing
   End Function
   Public Function ExisteTiposImpuestos(idTipoCliente As Entidades.TipoImpuesto.Tipos) As Boolean
      Return BuscaTiposImpuestos(idTipoCliente) IsNot Nothing
   End Function
#End Region


#Region "Impresoras"
   Private _impresorasCacheados As Dictionary(Of String, Entidades.Impresora)

   Public Function BuscaImpresoraPorTipoComprobante(idTipoComprobante As String) As Entidades.Impresora
      If String.IsNullOrWhiteSpace(idTipoComprobante) Then Return Nothing
      If _impresorasCacheados Is Nothing Then _impresorasCacheados = New Dictionary(Of String, Entidades.Impresora)()

      If _impresorasCacheados.ContainsKey(idTipoComprobante) Then
         Return _impresorasCacheados(idTipoComprobante)
      End If

      Dim impresora As Entidades.Impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(Usuario.Actual.Sucursal.Id, My.Computer.Name, idTipoComprobante)
      If impresora IsNot Nothing Then
         _impresorasCacheados.Add(idTipoComprobante, impresora)
      End If

      Return impresora
   End Function

#End Region

End Class