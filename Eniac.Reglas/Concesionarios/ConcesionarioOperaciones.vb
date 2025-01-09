Public Class ConcesionarioOperaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ConcesionarioOperacion.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioOperacion), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioOperacion), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioOperacion), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ConcesionarioOperaciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ConcesionarioOperaciones(da).ConcesionarioOperaciones_GA()
   End Function
#End Region

#Region "Métodos Públicos"
   'GET UNO
   Public Function GetUno(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As Entidades.ConcesionarioOperacion
      Return GetUno(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.ConcesionarioOperacion
      Return CargaEntidad(New SqlServer.ConcesionarioOperaciones(da).ConcesionarioOperaciones_G1(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacion(),
                          accion, Function() String.Format("No existe la Operación con Marca: {0}, Año: {1}, Número: {2} y Secuancia: {3}",
                                                           idMarca, anioOperacion, numeroOperacion, secuenciaOperacion))
   End Function

   'GET TODOS
   Public Function GetTodos() As List(Of Entidades.ConcesionarioOperacion)
      Return CargaLista(New SqlServer.ConcesionarioOperaciones(da).ConcesionarioOperaciones_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacion())
   End Function

   'GET CODIGO MAXIMO
   Public Function GetNumeroMaximo(idMarca As Integer, anioOperacion As Integer) As Integer
      Return New SqlServer.ConcesionarioOperaciones(da).GetNumeroMaximo(idMarca, anioOperacion)
   End Function
   Public Function GetSecuenciaMaxima(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer) As Integer
      Return New SqlServer.ConcesionarioOperaciones(da).GetSecuenciaMaxima(idMarca, anioOperacion, numeroOperacion)
   End Function

#End Region

#Region "Métodos Privados"
   Private Sub EjecutaSP(en As Entidades.ConcesionarioOperacion, tipo As TipoSP)
      Dim sql = New SqlServer.ConcesionarioOperaciones(da)
      Dim rAdic = New ConcesionarioOperacionesAdicionales(da)
      Dim rTarj = New ConcesionarioOperacionesTarjetas(da)
      Dim rCheq = New ConcesionarioOperacionesCheques(da)
      Dim rVeh = New ConcesionarioOperacionesVehiculosPagos(da)
      Select Case tipo
         Case TipoSP._I
            If en.NumeroOperacion = 0 Then
               en.NumeroOperacion = GetNumeroMaximo(en.IdMarca, en.AnioOperacion) + 1
            End If
            If en.SecuenciaOperacion = 0 Then
               en.SecuenciaOperacion = GetSecuenciaMaxima(en.IdMarca, en.AnioOperacion, en.NumeroOperacion) + 1
            End If

            If String.IsNullOrWhiteSpace(en.CodigoOperacion) Then
               Dim m = New Marcas(da).GetUna(en.IdMarca)
               en.CodigoOperacion = String.Format("{0} - {1} - {2} - {3}",
                                               m.NombreMarca.Substring(0, 1), en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion)
            End If

            sql.ConcesionarioOperaciones_I(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.CodigoOperacion,
                                           en.FechaOperacion, en.CotizacionDolar, en.Cliente.IdCliente,
                                           en.TipoOperacion, en.IdProductoCeroKilometro, en.CantidadCeroKilometro, en.PrecioCeroKilometro, en.ImporteCeroKilometro,
                                           en.PatenteVehiculoUsado, en.PrecioListaUsado, en.ImporteUsado,
                                           en.IdTipoUnidadCeroKilometro, en.IdSubTipoUnidadCeroKilometro, en.IdEjeCeroKilometro, en.CaracteristicaAdicionalCeroKilometro,
                                           en.LargoCeroKilometro, en.AltoCargaCeroKilometro, en.AltoPuertgaLateralCeroKilometro, en.ColorCarroceriaCeroKilometro, en.ColorZocaloCeroKilometro, en.ColorBaseCeroKilometro,
                                           en.PuertaTraseraCeroKilometro, en.ParanteCeroKilometro, en.PisoCeroKilometro, en.MarcoCeroKilometro, en.HerrajeCeroKilometro,
                                           en.OtrasObservacionesCeroKilometro,
                                           en.ImporteTotalAdicionales, en.ImporteTotalCaracteristicas, en.ImporteTotal,
                                           en.ImportePesos, en.ImporteTarjetas, en.ImporteCheques, en.ImporteTransferencia, en.FechaTransferencia, en.IdCuentaBancaria)
            rAdic._Insertar(en)
            rTarj._Insertar(en)
            rCheq._Grabar(en)
            rVeh._Grabar(en)
         Case TipoSP._U
            sql.ConcesionarioOperaciones_U(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.CodigoOperacion,
                                           en.FechaOperacion, en.CotizacionDolar, en.Cliente.IdCliente,
                                           en.TipoOperacion, en.IdProductoCeroKilometro, en.CantidadCeroKilometro, en.PrecioCeroKilometro, en.ImporteCeroKilometro,
                                           en.PatenteVehiculoUsado, en.PrecioListaUsado, en.ImporteUsado,
                                           en.IdTipoUnidadCeroKilometro, en.IdSubTipoUnidadCeroKilometro, en.IdEjeCeroKilometro, en.CaracteristicaAdicionalCeroKilometro,
                                           en.LargoCeroKilometro, en.AltoCargaCeroKilometro, en.AltoPuertgaLateralCeroKilometro, en.ColorCarroceriaCeroKilometro, en.ColorZocaloCeroKilometro, en.ColorBaseCeroKilometro,
                                           en.PuertaTraseraCeroKilometro, en.ParanteCeroKilometro, en.PisoCeroKilometro, en.MarcoCeroKilometro, en.HerrajeCeroKilometro,
                                           en.OtrasObservacionesCeroKilometro,
                                           en.ImporteTotalAdicionales, en.ImporteTotalCaracteristicas, en.ImporteTotal,
                                           en.ImportePesos, en.ImporteTarjetas, en.ImporteCheques, en.ImporteTransferencia, en.FechaTransferencia, en.IdCuentaBancaria)
            rAdic._Actualizar(en)
            rTarj._Actualizar(en)
            rCheq._Grabar(en)
            rVeh._Grabar(en)
         Case TipoSP._D
            rVeh._Borrar(en)
            rCheq._Eliminar(en)
            rTarj._Borrar(en)
            rAdic._Borrar(en)
            sql.ConcesionarioOperaciones_D(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ConcesionarioOperacion, dr As DataRow)
      With o
         .IdMarca = dr.Field(Of Integer)(Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString())
         .AnioOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString())
         .NumeroOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString())
         .SecuenciaOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacion.Columnas.SecuenciaOperacion.ToString())
         .CodigoOperacion = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.CodigoOperacion.ToString())

         .FechaOperacion = dr.Field(Of Date)(Entidades.ConcesionarioOperacion.Columnas.FechaOperacion.ToString())
         .CotizacionDolar = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacion.Columnas.CotizacionDolar.ToString())

         .Cliente = New Clientes(da).GetUnoLiviando(dr.Field(Of Long)(Entidades.ConcesionarioOperacion.Columnas.IdCliente.ToString()))

         .TipoOperacion = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.TipoOperacion.ToString()).StringToEnum(Entidades.ConcesionarioTipoOperacion.CeroKilometro)

         .IdProductoCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.IdProductoCeroKilometro.ToString())
         .CantidadCeroKilometro = dr.Field(Of Decimal?)(Entidades.ConcesionarioOperacion.Columnas.CantidadCeroKilometro.ToString())
         .PrecioCeroKilometro = dr.Field(Of Decimal?)(Entidades.ConcesionarioOperacion.Columnas.PrecioCeroKilometro.ToString())
         .ImporteCeroKilometro = dr.Field(Of Decimal?)(Entidades.ConcesionarioOperacion.Columnas.ImporteCeroKilometro.ToString())

         .PatenteVehiculoUsado = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.PatenteVehiculoUsado.ToString())
         .PrecioListaUsado = dr.Field(Of Decimal?)(Entidades.ConcesionarioOperacion.Columnas.PrecioListaUsado.ToString())
         .ImporteUsado = dr.Field(Of Decimal?)(Entidades.ConcesionarioOperacion.Columnas.ImporteUsado.ToString())

         .IdTipoUnidadCeroKilometro = dr.Field(Of Integer?)(Entidades.ConcesionarioOperacion.Columnas.IdTipoUnidadCeroKilometro.ToString()).IfNull()
         .IdSubTipoUnidadCeroKilometro = dr.Field(Of Integer?)(Entidades.ConcesionarioOperacion.Columnas.IdSubTipoUnidadCeroKilometro.ToString()).IfNull()
         .IdEjeCeroKilometro = dr.Field(Of Integer?)(Entidades.ConcesionarioOperacion.Columnas.IdEjeCeroKilometro.ToString()).IfNull()
         .CaracteristicaAdicionalCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.CaracteristicaAdicionalCeroKilometro.ToString())

         .LargoCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.LargoCeroKilometro.ToString())
         .AltoCargaCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.AltoCargaCeroKilometro.ToString())
         .AltoPuertgaLateralCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.AltoPuertaLateralCeroKilometro.ToString())
         .ColorCarroceriaCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.ColorCarroceriaCeroKilometro.ToString())
         .ColorZocaloCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.ColorZocaloCeroKilometro.ToString())
         .ColorBaseCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.ColorBaseCeroKilometro.ToString())

         .PuertaTraseraCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.PuertaTraseraCeroKilometro.ToString()).StringToEnum(Entidades.ConcesionarioPuertaTrasera.Guillotina)
         .ParanteCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.ParanteCeroKilometro.ToString()).StringToEnum(Entidades.ConcesionarioParante.Entero)
         .PisoCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.PisoCeroKilometro.ToString()).StringToEnum(Entidades.ConcesionarioPiso.Liso)
         .MarcoCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.MarcoCeroKilometro.ToString()).StringToEnum(Entidades.Publicos.SiNo.SI)
         .HerrajeCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.HerrajeCeroKilometro.ToString()).StringToEnum(Entidades.ConcesionarioHerraje.Mariposa)

         .OtrasObservacionesCeroKilometro = dr.Field(Of String)(Entidades.ConcesionarioOperacion.Columnas.OtrasObservacionesCeroKilometro.ToString())

         .Adicionales = New ConcesionarioOperacionesAdicionales(da).GetTodos(.IdMarca, .AnioOperacion, .NumeroOperacion, .SecuenciaOperacion)
         .Tarjetas = New ConcesionarioOperacionesTarjetas(da).GetTodos(.IdMarca, .AnioOperacion, .NumeroOperacion, .SecuenciaOperacion)
         .Cheques = New ConcesionarioOperacionesCheques(da).GetChequesOperacion(.IdMarca, .AnioOperacion, .NumeroOperacion, .SecuenciaOperacion)
         .VehiculosPago = Entidades.ListConBorrados.From(New ConcesionarioOperacionesVehiculosPagos(da).GetVehiculosOperacion(.IdMarca, .AnioOperacion, .NumeroOperacion, .SecuenciaOperacion))

         .ImporteTotalAdicionales = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacion.Columnas.ImporteTotalAdicionales.ToString())
         .ImporteTotalCaracteristicas = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacion.Columnas.ImporteTotalCaracteristicas.ToString())
         .ImporteTotal = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacion.Columnas.ImporteTotal.ToString())


         .ImportePesos = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacion.Columnas.ImportePesos.ToString())
         .ImporteTarjetas = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacion.Columnas.ImporteTarjetas.ToString())
         .ImporteCheques = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacion.Columnas.ImporteCheques.ToString())

         .ImporteTransferencia = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacion.Columnas.ImporteTransferencia.ToString())
         .FechaTransferencia = dr.Field(Of Date?)(Entidades.ConcesionarioOperacion.Columnas.FechaTransferencia.ToString())
         .IdCuentaBancaria = dr.Field(Of Integer?)(Entidades.ConcesionarioOperacion.Columnas.IdCuentaBancaria.ToString()).IfNull()

      End With
   End Sub

#End Region
End Class