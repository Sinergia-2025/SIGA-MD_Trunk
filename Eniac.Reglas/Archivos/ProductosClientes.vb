Public Class ProductosClientes
   Inherits Eniac.Reglas.Base
#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProductosClientes.NombreTabla
      da = accesoDatos
   End Sub
#End Region
#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me._Insertar(DirectCast(entidad, Entidades.ProductosClientes))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      MyBase.Actualizar(entidad)
      'Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me._Borrar(DirectCast(entidad, Entidades.ProductosClientes))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub


#End Region
#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProductosClientes, ByVal tipo As TipoSP)
      Dim sqlC As SqlServer.ProductosClientes = New SqlServer.ProductosClientes(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ProductosPorCliente_I(en.IdProducto, en.IdCliente)
         Case TipoSP._D
            sqlC.ProductosPorCliente_D(en.IdCliente)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ProductosClientes, ByVal dr As DataRow)
      With o
         .IdProducto = dr(Entidades.ProductosClientes.Columnas.IdProducto.ToString()).ToString()

         .IdCliente = Integer.Parse(dr(Entidades.ProductosClientes.Columnas.IdCliente.ToString()).ToString())
      End With
   End Sub
#End Region
#Region "Metodos publicos"
   Public Sub _Insertar(ByVal entidad As Entidades.ProductosClientes)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Function GetUno(idProducto As String, IdCliente As Long, accion As AccionesSiNoExisteRegistro) As Entidades.ProductosClientes
      Return CargaEntidad(New SqlServer.ProductosClientes(da).ProductosClientes_G1(idProducto, IdCliente),
                      Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductosClientes(),
                      accion, String.Format("No existe el IdProducto = {0} para el Cliente = {1}", idProducto, IdCliente))
   End Function
   Public Sub _Borrar(ByVal entidad As Entidades.ProductosClientes)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Function GetProductosCliente(idCliente As Long,
                                    marcas As Entidades.Marca(),
                                    rubros As Entidades.Rubro(),
                                    subRubros As Entidades.SubRubro()) As DataTable

      Return New SqlServer.ProductosClientes(da).GetProductosCliente(idCliente,
                                                             marcas,
                                                             rubros,
                                                             subRubros)
   End Function

   Public Function GetParaSincronizacionMovil(idSucursal As Integer,
                                              incluirClientes As String,
                                              incluidoEnRuta As Boolean,
                                              idCategoria As Integer,
                                              modulo As String,
                                              publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros,
                                              soloProductosConStock As Boolean) As DataTable
      Dim sProductosClientes As SqlServer.ProductosClientes = New SqlServer.ProductosClientes(da)
      Return sProductosClientes.GetParaSincronizacionMovil(idSucursal,
                                                           incluirClientes,
                                                           incluidoEnRuta,
                                                           idCategoria,
                                                           modulo,
                                                           publicarEn,
                                                           soloProductosConStock)
   End Function

   Public Sub BorraClienteProductoCalidad(idProducto As String)

      Dim sql As SqlServer.ProductosClientes = New SqlServer.ProductosClientes(da)
      sql.ProductosPorCliente_DxProducto(idProducto)

   End Sub

   Public Function GetClientexProducto(idProducto As String) As DataTable

      Return New SqlServer.ProductosClientes(da).GetClientexProducto(idProducto)
   End Function

   Public Sub Guardar(idCliente As Long, dtProductosPorCliente As DataTable)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.ProductosClientes = New SqlServer.ProductosClientes(da)
         sql.ProductosPorCliente_D(idCliente)

         For Each dr As DataRow In dtProductosPorCliente.Rows
            sql.ProductosPorCliente_I(dr("IdProducto").ToString(), idCliente)
         Next


         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   'Public Sub ImportarProductosClientes(ByVal IdSucursal As Integer,
   '                           ByVal datos As DataTable,
   '                           ByVal usuario As String,
   '                           ByRef BarraProg As System.Windows.Forms.ProgressBar,
   '                           ByVal IdFuncion As String)
   '   Try

   '      da.OpenConection()
   '      da.BeginTransaction()

   '      Dim dt As DataTable = datos

   '      Dim oCategorias As Eniac.Reglas.Categorias = New Eniac.Reglas.Categorias(da)

   '      Dim oCategoriasFiscales As Eniac.Reglas.CategoriasFiscales = New Eniac.Reglas.CategoriasFiscales(da)

   '      Dim oZonasGeograficas As Eniac.Reglas.ZonasGeograficas = New Eniac.Reglas.ZonasGeograficas(da)

   '      Dim oListasDePrecios As Eniac.Reglas.ListasDePrecios = New Eniac.Reglas.ListasDePrecios(da)

   '      Dim oVendedores As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados(da)

   '      Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes(da)

   '      Dim ExisteCliente As Boolean

   '      Dim Cliente As Entidades.Cliente

   '      Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)

   '      Dim AnchoNombreCliente As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "NombreCliente")

   '      Dim Produ As Entidades.Producto

   '      Dim oProd As Reglas.Productos = New Reglas.Productos(da)

   '      Dim sql As SqlServer.ProductosClientes = New SqlServer.ProductosClientes(da)

   '      Dim Marca As Entidades.Marca = New Reglas.Marcas().GetUna(New Reglas.Marcas().GetPrimeraMarca())
   '      Dim Rubro As Entidades.Rubro = New Reglas.Rubros().GetUno(New Reglas.Rubros().GetPrimerRubro())
   '      Dim Moneda As Entidades.Moneda = New Reglas.Monedas().GetUna(1)
   '      Dim Categoria As Integer = oCategorias.GetPrimerIdCategoria()
   '      Dim ZonaGeografica As String = oZonasGeograficas.GetPrimerIdZonaGeografica()
   '      Dim ListaDePrecios As Integer = Publicos.ListaPreciosPredeterminada ' oListasDePrecios.GetPrimerIdListaDePrecios()
   '      Dim Vendedor As Integer = oVendedores.GetPrimerIdEmpleado()

   '      Dim Cli As Entidades.Cliente = New Entidades.Cliente
   '      Dim i As Integer = 0

   '      BarraProg.Maximum = dt.Rows.Count
   '      BarraProg.Minimum = 0
   '      BarraProg.Value = 0

   '      For Each dr As DataRow In dt.Rows

   '         i += 1
   '         BarraProg.Value = i
   '         If String.IsNullOrEmpty(dr("NroCarroceria").ToString()) Then
   '            Exit For
   '         End If
   '         If Boolean.Parse(dr("Importa").ToString()) Then

   '            ExisteCliente = oClientes.ExisteCodigoLetras(dr("CodigoCliente").ToString())

   '            'Grabo cliente si no existe
   '            If Not ExisteCliente Then

   '               Cliente = New Entidades.Cliente

   '               Cliente.IdCliente = 0

   '               Cliente.CodigoClienteLetras = dr("CodigoCliente").ToString.Trim()

   '               Cliente.IdCategoria = Categoria

   '               Cliente.CategoriaFiscal.IdCategoriaFiscal = 1

   '               Cliente.ZonaGeografica.IdZonaGeografica = ZonaGeografica

   '               Cliente.IdListaPrecios = ListaDePrecios

   '               Cliente.Vendedor.IdEmpleado = Vendedor

   '               If Strings.Trim(dr("NombreCliente").ToString.Trim()).Length > AnchoNombreCliente Then
   '                  Cliente.NombreCliente = Strings.Trim(dr("NombreCliente").ToString.Trim()).Remove(AnchoNombreCliente)
   '               Else
   '                  Cliente.NombreCliente = Strings.Trim(dr("NombreCliente").ToString.Trim())
   '               End If

   '               Cliente.Direccion = "."

   '               Cliente.Localidad.IdLocalidad = 2000

   '               Cliente.Usuario = usuario

   '               Cliente.FechaAlta = Date.Now

   '               Cliente.UtilizaAppSoporte = False
   '               Cliente.Sexo = Entidades.Cliente.SexoOpciones.Indefinido
   '               Cliente.IdSucursal = IdSucursal
   '               Cliente.Activo = True
   '               Cliente.FechaNacimiento = Date.Now
   '               Cliente.NroOperacion = 0
   '               Cliente.NombreTrabajo = ""
   '               Cliente.DireccionTrabajo = ""
   '               Cliente.IdLocalidadTrabajo = 0
   '               Cliente.TelefonoTrabajo = ""
   '               Cliente.CorreoTrabajo = ""
   '               Cliente.FechaIngresoTrabajo = Date.Now

   '               Cliente.SaldoPendiente = 0
   '               Cliente.TipoDocumentoGarante = ""
   '               Cliente.IdClienteGarante = 0
   '               Cliente.LimiteDeCredito = 0
   '               Cliente.IdSucursalAsociada = 0

   '               Cliente.DescuentoRecargoPorc = 0
   '               Cliente.IdTipoComprobante = ""
   '               Cliente.IdFormasPago = 0
   '               ' Cliente.Foto = Nothing
   '               Cliente.IdTransportista = 0
   '               Cliente.IngresosBrutos = ""
   '               Cliente.InscriptoIBStaFe = False
   '               Cliente.LocalIB = False
   '               Cliente.ConvMultilateralIB = False
   '               Cliente.NumeroLote = 0
   '               Cliente.PaginaWeb = ""
   '               'van fijo por ahora-----------
   '               Cliente.EstadoCliente.IdEstadoCliente = 1
   '               Cliente.Cobrador.IdEmpleado = 1
   '               '   Cliente.Cobrador.NroDocEmpleado = "1"

   '               Cliente.TipoCliente.IdTipoCliente = 1
   '               '-----------------------------
   '               Cliente.EsClienteGenerico = False
   '               Cliente.UsaArchivoAImprimir2 = False
   '               Cliente.CantidadVisitas = 0

   '               Cliente.NivelAutorizacion = 0
   '               Cliente.DadoAltaPor = Cliente.Vendedor

   '               Cliente.ValorizacionFacturacionMensual = 0
   '               Cliente.ValorizacionCoeficienteFacturacion = 0
   '               Cliente.ValorizacionFacturacion = 0
   '               Cliente.ValorizacionImporteAdeudado = 0
   '               Cliente.ValorizacionCoeficienteDeuda = 0
   '               Cliente.ValorizacionDeuda = 0
   '               Cliente.ValorizacionProyecto = 0
   '               Cliente.ValorizacionCliente = 0
   '               Cliente.ValorizacionEstrellas = 0
   '               Cliente.PublicarEnWeb = True

   '               oClientes.Inserta(Cliente)
   '            End If

   '            If IsNumeric(dr("NroCarroceria").ToString()) Then
   '               'Grabo producto si no existe 
   '               If Not oProd.Existe(dr("NroCarroceria").ToString()) Then
   '                  oProd.InsertarProducto(actual.Sucursal.Id, dr("NroCarroceria").ToString(),
   '                                         ".", Marca.NombreMarca, Rubro.NombreRubro, Moneda.NombreMoneda,
   '                                          21, actual.Nombre, IdFuncion)
   '               End If

   '               'Grabar ProductosClientes
   '               Cli = New Entidades.Cliente
   '               Cli = oClientes.GetUnoPorCodigoLetras(dr("CodigoCliente").ToString())
   '               Produ = oProd.GetUno(dr("NroCarroceria").ToString())
   '               sql.ProductosPorCliente_DxProducto(Produ.IdProducto)
   '               sql.ProductosPorCliente_I(Produ.IdProducto, Cli.IdCliente)

   '               'Actualizo datos Chasis y Carroceria

   '               Produ.CalidadNumeroChasis = dr("NumeroChasis").ToString
   '               Produ.CalidadNroCarroceria = Integer.Parse(dr("NroCarroceria").ToString())
   '               oProd.ActualizaProductoCalidad(Produ)
   '            End If

   '         End If

   '      Next

   '      da.CommitTransaction()

   '   Catch ex As Exception
   '      BarraProg.Value = 0
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try

   'End Sub
#End Region
End Class