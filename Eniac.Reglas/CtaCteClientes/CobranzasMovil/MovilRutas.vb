Imports Eniac.Entidades

Public Class MovilRutas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.MovilRuta.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MovilRuta), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MovilRuta), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MovilRuta), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.MovilRutas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.MovilRutas(da).MovilRutas_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.MovilRuta, tipo As TipoSP)
      Dim rRutasClientes = New MovilRutasClientes(da)
      Dim rRutasListas = New MovilRutasListasDePrecios(da)
      Dim sqlC = New SqlServer.MovilRutas(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.MovilRutas_I(en.IdRuta, en.NombreRuta, en.Activa, en.IdDispositivoPorDefecto,
                                 en.IdVendedor, en.IdTransportista.IfNull,
                                 en.PuedeModificarPrecio, en.PrecioConImpuestos, en.Usuario,
                                 en.PermiteIngresarPorcentajeDescuentos, en.PermiteCobroParcial,
                                 en.EsDeCobranza, en.EsDePedidos, en.EsDeGestion,
                                 en.ConfiguraClienteSegun, en.DescuentoMax, en.RecargaMax)
            rRutasListas.InsertaDesdeRuta(en)
         Case TipoSP._U
            sqlC.MovilRutas_U(en.IdRuta, en.NombreRuta, en.Activa, en.IdDispositivoPorDefecto,
                                 en.IdVendedor, en.IdTransportista.IfNull,
                                 en.PuedeModificarPrecio, en.PrecioConImpuestos, en.Usuario,
                                 en.PermiteIngresarPorcentajeDescuentos, en.PermiteCobroParcial,
                                 en.EsDeCobranza, en.EsDePedidos, en.EsDeGestion,
                                 en.ConfiguraClienteSegun, en.DescuentoMax, en.RecargaMax)

            rRutasListas._Borrar(New Entidades.MovilRutaListaDePrecios() With {.IdRuta = en.IdRuta})
            rRutasListas.InsertaDesdeRuta(en)

            If Publicos.Logistica.NormalizaClientesEnRutas Then
               Dim sqlRC As SqlServer.MovilRutasClientes = New SqlServer.MovilRutasClientes(da)
               sqlRC.NormalizaClienteSegunRuta()
            End If

         Case TipoSP._D
            rRutasListas._Borrar(New Entidades.MovilRutaListaDePrecios() With {.IdRuta = en.IdRuta})
            rRutasClientes._Borrar(New Entidades.MovilRutaCliente() With {.IdRuta = en.IdRuta})
            sqlC.MovilRutas_D(en.IdRuta)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MovilRuta, dr As DataRow, cargarListaPrecios As Boolean)
      With o
         .IdRuta = Integer.Parse(dr(Entidades.MovilRuta.Columnas.IdRuta.ToString()).ToString())
         .NombreRuta = dr(Entidades.MovilRuta.Columnas.NombreRuta.ToString()).ToString()
         .Activa = Boolean.Parse(dr(Entidades.MovilRuta.Columnas.Activa.ToString()).ToString())
         .IdDispositivoPorDefecto = dr(Entidades.MovilRuta.Columnas.IdDispositivoPorDefecto.ToString()).ToString()
         .IdVendedor = Integer.Parse(dr(Entidades.MovilRuta.Columnas.IdVendedor.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovilRuta.Columnas.IdTransportista.ToString()).ToString()) Then
            .IdTransportista = Integer.Parse(dr(Entidades.MovilRuta.Columnas.IdTransportista.ToString()).ToString())
         End If

         .PuedeModificarPrecio = Boolean.Parse(dr(Entidades.MovilRuta.Columnas.PuedeModificarPrecio.ToString()).ToString())
         .PrecioConImpuestos = Boolean.Parse(dr(Entidades.MovilRuta.Columnas.PrecioConImpuestos.ToString()).ToString())
         .Usuario = dr(Entidades.MovilRuta.Columnas.Usuario.ToString()).ToString()

         .PermiteIngresarPorcentajeDescuentos = Boolean.Parse(dr(Entidades.MovilRuta.Columnas.PermiteIngresarPorcentajeDescuentos.ToString()).ToString())
         .PermiteCobroParcial = Boolean.Parse(dr(Entidades.MovilRuta.Columnas.PermiteCobroParcial.ToString()).ToString())
         .EsDeCobranza = Boolean.Parse(dr(Entidades.MovilRuta.Columnas.EsDeCobranza.ToString()).ToString())
         .EsDePedidos = Boolean.Parse(dr(Entidades.MovilRuta.Columnas.EsDePedidos.ToString()).ToString())
         .EsDeGestion = Boolean.Parse(dr(Entidades.MovilRuta.Columnas.EsDeGestion.ToString()).ToString())

         .ConfiguraClienteSegun = dr.Field(Of String)(Entidades.MovilRuta.Columnas.ConfiguraClienteSegun.ToString()).StringToEnum(Entidades.OrigenConfiguraClienteSegun.RUTADIA)

         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovilRuta.Columnas.DescuentoMax.ToString()).ToString()) Then
            .DescuentoMax = Decimal.Parse(dr(Entidades.MovilRuta.Columnas.DescuentoMax.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.MovilRuta.Columnas.RecargaMax.ToString()).ToString()) Then
            .RecargaMax = Decimal.Parse(dr(Entidades.MovilRuta.Columnas.RecargaMax.ToString()).ToString())
         End If


         If cargarListaPrecios Then
            .ListasDePrecio = New Reglas.MovilRutasListasDePrecios(da).GetTodos(.IdRuta)
         End If

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function ValidaCantidadRutasUsuarios(ByRef mensaje As String) As Boolean
      Dim valida = False
      Dim cantUsr = Publicos.GetSistema().CantidadUsuariosContratados
      '-- Obtiene las rutas por usuario.- ----------------------
      Dim rutasUsr = GetUsuariosRutas()
      'If rutasUsr <> 0 AndAlso rutasUsr <= cantUsr Then
      If rutasUsr <= cantUsr Then
         valida = True
         mensaje = String.Empty
      Else
         mensaje = String.Format("No se puede Sincronizar ya que la cantidad de Usuarios con Rutas a sincronizar ({0}) es Superior a la adquirida ({1}), elimine Rutas o comuníquese con Sinergia para actualizar licencia.", rutasUsr, cantUsr)
      End If

      Return valida
   End Function

   Public Function GetPorCodigo(idMovilRuta As Integer) As DataTable
      Return New SqlServer.MovilRutas(da).MovilRutas_G1(idMovilRuta)
   End Function
   Public Function GetPorNombre(nombreMovilRuta As String) As DataTable
      Return New SqlServer.MovilRutas(da).MovilRutas_G_PorNombre(nombreMovilRuta)
   End Function
   Public Function GetUnoPorVendedor(IdVendedor As Integer) As Entidades.MovilRuta
      Dim dt As DataTable = New SqlServer.MovilRutas(da).MovilRutas_G_Vendedor(IdVendedor)
      Dim o As Entidades.MovilRuta = New Entidades.MovilRuta()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0), cargarListaPrecios:=True)
      End If
      Return o
   End Function
   Public Function GetUno(idMovilRuta As Integer) As Entidades.MovilRuta
      Return GetUno(idMovilRuta, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idMovilRuta As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MovilRuta
      Return CargaEntidad(New SqlServer.MovilRutas(da).MovilRutas_G1(idMovilRuta),
                          Sub(o, dr) CargarUno(o, dr, cargarListaPrecios:=True), Function() New Entidades.MovilRuta(),
                          accion, Function() String.Format("No se encontró ruta con IdRuta = {0}", idMovilRuta))
   End Function

   Public Function GetTodos() As List(Of Entidades.MovilRuta)
      Return CargaLista(New SqlServer.MovilRutas(da).MovilRutas_GA(), cargarListaPrecios:=False)
   End Function

   Public Function GetTodos(activa As Boolean?, cargarListaPrecios As Boolean) As List(Of Entidades.MovilRuta)
      Return CargaLista(New SqlServer.MovilRutas(da).MovilRutas_GA(activa), cargarListaPrecios)
   End Function

   Private Overloads Function CargaLista(dt As DataTable, cargarListaPrecios As Boolean) As List(Of Entidades.MovilRuta)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr, cargarListaPrecios), Function() New Entidades.MovilRuta())
   End Function

   Public Overloads Function GetAll(activa As Boolean?) As DataTable
      Return New SqlServer.MovilRutas(da).MovilRutas_GA(activa)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MovilRutas(da).GetCodigoMaximo()
   End Function

   Public Function GetClientesRutas(idRuta As Integer, idCliente As Long, idCobrador As Integer, IdVendedor As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Return GetClientesRutas(idRuta, idCliente, idCobrador, IdVendedor, dia, -1)
   End Function

   Public Function GetClientesRutas(idRuta As Integer, idCliente As Long, idCobrador As Integer, IdVendedor As Integer, dia As Entidades.Publicos.Dias?, IdLocalidad As Integer) As DataTable
      Return New SqlServer.MovilRutas(da).GetClientesRutas(idRuta, idCliente, idCobrador, IdVendedor, dia, IdLocalidad)
   End Function

   Public Function GetUsuariosRutas() As Integer
      Dim cantUsr As Integer = 0
      Dim dt = New SqlServer.MovilRutas(da).GetUsuariosRutas()
      If dt IsNot Nothing Or dt.Rows.Count <> 0 Then
         Dim dr As DataRow = dt.Rows(0)
         cantUsr = Integer.Parse(dr("Cantidad").ToString())
      Else
         cantUsr = 0
      End If

      Return cantUsr
   End Function
#End Region

End Class