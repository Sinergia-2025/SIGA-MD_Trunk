Public Class Buscador
   Inherits Entidad
   Public Const NombreTabla As String = "Buscadores"
   Public Enum Columnas
      IdBuscador
      Titulo
      AnchoAyuda
      IniciaConFocoEn
      ColumaBusquedaInicial
   End Enum

   Public Sub New()
      Campos = New List(Of BuscadorCampo)()
   End Sub

   Public Property IdBuscador As Integer
   Public Property Titulo As String
   Public Property AnchoAyuda As Integer
   Public Property IniciaConFocoEn As IniciaConFocoEnList
   Public Property ColumnaBusquedaInicial As String
   Public Property Campos As List(Of BuscadorCampo)

   Public Enum IniciaConFocoEnList
      Busqueda
      Grilla
   End Enum

   Public Enum Buscadores
      Clientes = 1
      Productos = 2
      Funciones = 3
      Prospectos = 4
      Proveedores = 5
      Cargos = 6
      Plantillas = 7
      Aduanas = 8
      AduanasAgentesTransporte = 9
      AduanasDespachantes = 10
      AduanasDestinaciones = 11
      Proyectos = 12
      ContabilidadCentrosCostos = 13
      CRMNovedades = 14
      TiposUnidades = 15
      CRMCategorias = 16
      TablerosControlPanel = 17
      ReservasTurismo = 18
      Empresas = 20
      CRMEstados = 21
      CRMMediosComunicacion = 22
      CRMMetodos = 23
      Empleados = 25
      Rubros = 30
      SubRubros = 31
      SubSubRubros = 32
      Marcas = 33
      UnidadesDeMedida = 34
      Localidades = 35
      Bancos = 40
      Cajas = 41
      EstadosCheques = 42
      Transportistas = 45
      CuentasBancarias = 50
      Sucursales = 60
      FormasDePago = 70
      ListasDePrecios = 75
      TiposClientes = 80
      CategoriasCliente = 85
      TiposComprobantes = 91
      GrupoTiposComprobantes = 92
      Observaciones = 95
      ComprobantesReenvio = 100
      Repartos = 101
      OrdenesCompra = 105
      Rutas = 110
      ComprobantesVentaPendientes = 150
      Vehiculos = 200
      ZonasGeograficas = 201
      TiposAtributosProductos = 202
      GruposTiposAtributosProductos = 203
      CuentasBancos = 204
      CuentasContables = 205
      CuentasCajas = 206
      AtributosProductos = 207
      Modelos = 208
      Lotes = 300
      NrosSerie = 305
      LotesDespachos = 310
      Camas = 500
      Embarcaciones = 10001
      CategoriasEmpleados = 500
      MRPTareas = 510
      MRPNormasFabricacion = 520
      MRPSecciones = 530
      MRPCentroProductores = 540
      MRPProcesosProductivos = 550
      EstadosOrdenesCalidad = 560
      CRMCiclosPlanificacion = 700
   End Enum

End Class