Option Strict On
Option Explicit On
Imports Eniac.Entidades

<Obsolete()>
Public Class BusquedasCacheadas
   Private Shared _instancia As BusquedasCacheadas = New BusquedasCacheadas()
   Public Shared ReadOnly Property Instancia As BusquedasCacheadas
      Get
         If _instancia Is Nothing Then _instancia = New BusquedasCacheadas()
         Return _instancia
      End Get
   End Property

   Public Shared Sub Reset()
      _instancia = Nothing
   End Sub

#Region "Proveedores"
   Private _proveedoresCacheados As DataTable
   Public Function BuscaProveedores(nombreProveedor As String) As DataRow
      If _proveedoresCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _proveedoresCacheados.Select(String.Format("{0} = '{1}'", Entidades.Proveedor.Columnas.NombreProveedor.ToString(), nombreProveedor))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Proveedores().GetFiltradoPorNombre(nombreProveedor)
      If _proveedoresCacheados Is Nothing Then
         _proveedoresCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _proveedoresCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function
   'Public Function BuscaProveedorPorFantasia(nombreProveedor As String) As DataRow
   '   If _proveedoresCacheados IsNot Nothing Then
   '      Dim drCol As DataRow() = _proveedoresCacheados.Select(String.Format("{0} = '{1}'", Entidades.Proveedor.Columnas.NombreDeFantasia.ToString(), nombreProveedor))
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

   Public Function BuscaProveedorPorCodigo(CodigoProveedor As Long) As DataRow
      If _proveedoresCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _proveedoresCacheados.Select(String.Format("{0} = '{1}'", Entidades.Proveedor.Columnas.CodigoProveedor.ToString(), CodigoProveedor))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Proveedores().GetFiltradoPorCodigo(CodigoProveedor, False)
      If _proveedoresCacheados Is Nothing Then
         _proveedoresCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _proveedoresCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function
#End Region


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

   Private _comprobantesCacheados As DataTable

   Public Function BuscaComprobante(TipoComprobante As String) As DataRow
      If _comprobantesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _comprobantesCacheados.Select(String.Format("{0} = '{1}'", Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString(), TipoComprobante))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.TiposComprobantes().GetPorCodigo(TipoComprobante, String.Empty, String.Empty)
      If _comprobantesCacheados Is Nothing Then
         _comprobantesCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _comprobantesCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function


   Private _VendedoresCacheados As DataTable

   Public Function BuscaVendedor(nombreVendedor As String) As DataRow
      If _VendedoresCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _VendedoresCacheados.Select(String.Format("{0} = '{1}'", Entidades.Empleado.Columnas.NombreEmpleado.ToString(), nombreVendedor))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Empleados().GetFiltradoPorNombre(nombreVendedor)
      If _VendedoresCacheados Is Nothing Then
         _VendedoresCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _VendedoresCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   Private _SucursalesCacheadas As DataTable

   Public Function BuscaSucursal(Sucursal As Integer) As DataRow
      If _SucursalesCacheadas IsNot Nothing Then
         Dim drCol As DataRow() = _SucursalesCacheadas.Select(String.Format("{0} = '{1}'", Entidades.Sucursal.Columnas.IdSucursal.ToString(), Sucursal))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Sucursales().GetPorCodigo(Integer.Parse(Sucursal.ToString()), idFuncion:=String.Empty)
      If _SucursalesCacheadas Is Nothing Then
         _SucursalesCacheadas = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _SucursalesCacheadas.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function

#End Region

#Region "Prospectos"
   Private _prospectosCacheados As DataTable
   Public Function BuscaProspecto(nombreProspecto As String) As DataRow
      If _prospectosCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _prospectosCacheados.Select(String.Format("{0} = '{1}'", "NombreProspecto", nombreProspecto))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Clientes(Cliente.ModoClienteProspecto.Prospecto).GetFiltradoPorNombre(nombreProspecto, False)
      If _prospectosCacheados Is Nothing Then
         _prospectosCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _prospectosCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function
   Public Function BuscaProspectoPorFantasia(nombreCliente As String) As DataRow
      If _prospectosCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _prospectosCacheados.Select(String.Format("{0} = '{1}'", Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), nombreCliente))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Clientes(Cliente.ModoClienteProspecto.Prospecto).GetFiltradoPorNombreFantasia(nombreCliente, False)
      If _prospectosCacheados Is Nothing Then
         _prospectosCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _prospectosCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function
#End Region

#Region "ZonaGeografica"
   Private _zonaGeograficaCacheados As DataTable
   Public Function BuscaZonaGeografica(nombreZonaGeografica As String) As DataRow
      If _zonaGeograficaCacheados Is Nothing Then
         _zonaGeograficaCacheados = New Reglas.ZonasGeograficas().GetAll()
      End If
      Dim drCol As DataRow() = _zonaGeograficaCacheados.Select(String.Format("{0} = '{1}'", Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString(), nombreZonaGeografica))
      If drCol.Length > 0 Then
         Return drCol(0)
      Else
         Return Nothing
      End If
   End Function

#End Region

#Region "Proyecto"
   Private _proyectoCacheados As DataTable
   Public Function BuscaProyecto(codigoProyecto As Integer) As DataRow
      If _proyectoCacheados Is Nothing Then
         _proyectoCacheados = New Reglas.Proyectos().GetAll()
      End If
      Dim drCol As DataRow() = _proyectoCacheados.Select(String.Format("{0} = {1}", Entidades.Proyecto.Columnas.IdProyecto.ToString(), codigoProyecto))
      If drCol.Length > 0 Then
         Return drCol(0)
      Else
         Return Nothing
      End If
   End Function
   Public Function ExisteProyecto(codigoProyecto As Integer) As Boolean
      Return BuscaProyecto(codigoProyecto) IsNot Nothing
   End Function
#End Region

#Region "CRMEstadoNovedad"
   Private _crmEstadoNovedadCacheados As DataTable
   Public Function BuscaCRMEstadoNovedad(idTipoNovedad As String, nombreEstadoNovedad As String) As DataRow
      If _crmEstadoNovedadCacheados Is Nothing Then
         _crmEstadoNovedadCacheados = New Reglas.CRMEstadosNovedades().GetAll(idTipoNovedad, False)
      End If
      Dim drCol As DataRow() = _crmEstadoNovedadCacheados.Select(String.Format("{0} = '{1}' AND {2} = '{3}'",
                                                                               Entidades.CRMEstadoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                                               Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString(), nombreEstadoNovedad))
      If drCol.Length > 0 Then
         Return drCol(0)
      Else
         Return Nothing
      End If
   End Function

#End Region

#Region "CRMPrioridadesNovedades"
   Private _crmPrioridadesNovedadesCacheados As DataTable
   Public Function BuscaCRMPrioridadesNovedades(idTipoNovedad As String, nombrePrioridadNovedad As String) As DataRow
      If _crmPrioridadesNovedadesCacheados Is Nothing Then
         _crmPrioridadesNovedadesCacheados = New Reglas.CRMPrioridadesNovedades().GetAll(idTipoNovedad, False)
      End If
      Dim drCol As DataRow() = _crmPrioridadesNovedadesCacheados.Select(String.Format("{0} = '{1}' AND {2} = '{3}'",
                                                                               Entidades.CRMPrioridadNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                                               Entidades.CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString(), nombrePrioridadNovedad.ToString()))
      If drCol.Length > 0 Then
         Return drCol(0)
      Else
         Return Nothing
      End If
   End Function

#End Region

#Region "CRMCategoriasNovedades"
   Private _crmCategoriasNovedadesCacheados As DataTable
   Public Function BuscaCRMCategoriasNovedades(idTipoNovedad As String, nombreCategoriaNovedad As String) As DataRow
      If _crmCategoriasNovedadesCacheados Is Nothing Then
         _crmCategoriasNovedadesCacheados = New Reglas.CRMCategoriasNovedades().GetAll(idTipoNovedad, False)
      End If
      Dim drCol As DataRow() = _crmCategoriasNovedadesCacheados.Select(String.Format("{0} = '{1}' AND {2} = '{3}'",
                                                                               Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                                               Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString(), nombreCategoriaNovedad))
      If drCol.Length > 0 Then
         Return drCol(0)
      Else
         Return Nothing
      End If
   End Function

#End Region

#Region "CRMMetodosResolucionesNovedades"
   Private _crmMetodosResolucionesNovedadesCacheados As DataTable
   Public Function BuscaCRMMetodosResolucionesNovedades(idTipoNovedad As String, nombreMetodoResolucionNovedad As String) As DataRow
      If _crmMetodosResolucionesNovedadesCacheados Is Nothing Then
         _crmMetodosResolucionesNovedadesCacheados = New Reglas.CRMMetodosResolucionesNovedades().GetAll(idTipoNovedad, False)
      End If
      Dim drCol As DataRow() = _crmMetodosResolucionesNovedadesCacheados.Select(String.Format("{0} = '{1}' AND {2} = '{3}'",
                                                                               Entidades.CRMMetodoResolucionNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                                               Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString(), nombreMetodoResolucionNovedad))
      If drCol.Length > 0 Then
         Return drCol(0)
      Else
         Return Nothing
      End If
   End Function

#End Region

#Region "CRMMediosComunicacionesNovedades"
   Private _crmMediosComunicacionesNovedadesCacheados As DataTable
   Public Function BuscaCRMMediosComunicacionesNovedades(idTipoNovedad As String, nombreMedio As String) As DataRow
      If _crmMediosComunicacionesNovedadesCacheados Is Nothing Then
         _crmMediosComunicacionesNovedadesCacheados = New Reglas.CRMMediosComunicacionesNovedades().GetAll(idTipoNovedad, False)
      End If
      Dim drCol As DataRow() = _crmMediosComunicacionesNovedadesCacheados.Select(String.Format("{0} = '{1}' AND {2} = '{3}'",
                                                                               Entidades.CRMMedioComunicacionNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                                               Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString(), nombreMedio))
      If drCol.Length > 0 Then
         Return drCol(0)
      Else
         Return Nothing
      End If
   End Function

#End Region

#Region "Usuarios"
   Private _usuariosCacheados As DataTable
   Private Sub InicializaUsuarios()
      If _usuariosCacheados Is Nothing Then
         _usuariosCacheados = New Reglas.Usuarios().GetAll()
      End If
   End Sub
   Public Function BuscaUsuarios(idUsuario As String) As DataRow
      InicializaUsuarios()
      Dim drCol As DataRow() = _usuariosCacheados.Select(String.Format("{0} = '{1}'", Entidades.Usuario.Columnas.Id.ToString(), idUsuario))
      If drCol.Length > 0 Then
         Return drCol(0)
      Else
         Return Nothing
      End If
   End Function

   Public Function ExisteUsuarios(idUsuario As String) As Boolean
      Return BuscaUsuarios(idUsuario) IsNot Nothing
   End Function

#End Region

#Region "Funciones"
   Private _funcionesCacheados As DataTable
   Public Function BuscaFuncion(codigoFuncion As String) As DataRow
      If _funcionesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _funcionesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Funcion.Columnas.Id.ToString(), codigoFuncion))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Funciones().Buscar(New Eniac.Entidades.Buscar(Entidades.Funcion.Columnas.Id.ToString(), codigoFuncion))
      If _funcionesCacheados Is Nothing Then
         _funcionesCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _funcionesCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   Public Function ExisteFuncion(codigoFuncion As String) As Boolean
      Return BuscaFuncion(codigoFuncion) IsNot Nothing
   End Function


   Public Function BuscaFuncionPorNombre(nombreFuncion As String) As DataRow
      If _funcionesCacheados IsNot Nothing Then
         Dim drCol As DataRow() = _funcionesCacheados.Select(String.Format("{0} = '{1}'", Entidades.Funcion.Columnas.Nombre.ToString(), nombreFuncion))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Funciones().Buscar(New Eniac.Entidades.Buscar(Entidades.Funcion.Columnas.Nombre.ToString(), nombreFuncion), True)
      If _funcionesCacheados Is Nothing Then
         _funcionesCacheados = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _funcionesCacheados.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   Public Function ExisteFuncionPorNombre(nombreFuncion As String) As Boolean
      Return BuscaFuncionPorNombre(nombreFuncion) IsNot Nothing
   End Function
#End Region

#Region "Embarcaciones"
   Private _embarcacionesCacheadas As DataTable
   ''' <summary>
   ''' Localiza por Código de Embarcación.-
   ''' </summary>
   ''' <param name="codigoEmbarcacion">Codigo de la Embarcación</param>
   ''' <returns></returns>
   Public Function BuscaEmbarcacionPorCodigo(codigoEmbarcacion As Long) As DataRow
      If _embarcacionesCacheadas IsNot Nothing Then
         Dim drCol As DataRow() = _embarcacionesCacheadas.Select(String.Format("{0} = '{1}'", EmbarcacionLiviano.Columnas.CodigoEmbarcacion.ToString(), codigoEmbarcacion))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Embarcaciones().GetPorCodigoEmbarcacion(codigoEmbarcacion)
      If _embarcacionesCacheadas Is Nothing Then
         _embarcacionesCacheadas = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _embarcacionesCacheadas.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function
   ''' <summary>
   ''' Localiza por Nombre de Embarcacion.-
   ''' </summary>
   ''' <param name="nombreEmbarcacion">Nombre de la Embarcacion</param>
   ''' <returns></returns>
   Public Function BuscaEmbarcacionPorNombre(nombreEmbarcacion As String) As DataRow
      If _embarcacionesCacheadas IsNot Nothing Then
         Dim drCol As DataRow() = _embarcacionesCacheadas.Select(String.Format("{0} = '{1}'", EmbarcacionLiviano.Columnas.NombreEmbarcacion.ToString(), nombreEmbarcacion))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Embarcaciones().GetFiltradoPorNombre(nombreEmbarcacion)
      If _embarcacionesCacheadas Is Nothing Then
         _embarcacionesCacheadas = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _embarcacionesCacheadas.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function
   ''' <summary>
   ''' Informa si Existe una Embarcacion
   ''' </summary>
   ''' <param name="codigoEmbarcacion">Código de Embarcación</param>
   ''' <returns></returns>
   Public Function ExisteEmbarcacion(codigoEmbarcacion As Long) As Boolean
      Return BuscaEmbarcacionPorCodigo(codigoEmbarcacion) IsNot Nothing
   End Function

#End Region

#Region "Camas"
   Private _camasCacheadas As DataTable
   ''' <summary>
   ''' Localiza por Código de Embarcación.-
   ''' </summary>
   ''' <param name="codigoCama">Codigo de la Embarcación</param>
   ''' <returns></returns>
   Public Function BuscaCamaPorCodigo(codigoCama As String) As DataRow
      If _camasCacheadas IsNot Nothing Then
         Dim drCol As DataRow() = _camasCacheadas.Select(String.Format("{0} = '{1}'", Cama.Columnas.CodigoCama.ToString(), codigoCama))
         If drCol.Length > 0 Then
            Return drCol(0)
         End If
      End If
      Dim dt As DataTable = New Reglas.Camas().GetCamaPorCodigo(codigoCama)
      If _camasCacheadas Is Nothing Then
         _camasCacheadas = dt
         Return dt(0)
      Else
         If dt.Rows.Count > 0 Then
            _camasCacheadas.ImportRowRange(dt.Select())
            Return dt(0)
         Else
            Return Nothing
         End If
      End If
   End Function

   ''' <summary>
   ''' Informa si Existe una Embarcacion
   ''' </summary>
   ''' <param name="codigoCama">Código de Embarcación</param>
   ''' <returns></returns>
   Public Function ExisteEmbarcacion(codigoCama As String) As Boolean
      Return BuscaCamaPorCodigo(codigoCama) IsNot Nothing
   End Function

#End Region
End Class