Public Class ConcesionarioOperacionesVehiculosPagos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ConcesionarioOperacionVehiculoPago.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ConcesionarioOperacionVehiculoPago)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ConcesionarioOperacionVehiculoPago)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ConcesionarioOperacionVehiculoPago)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ConcesionarioOperacionesVehiculosPagos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ConcesionarioOperacionesVehiculosPagos(da).ConcesionarioOperacionesVehiculosPagos_GA()
   End Function
   Public Overloads Function GetAll(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Return New SqlServer.ConcesionarioOperacionesVehiculosPagos(da).ConcesionarioOperacionesVehiculosPagos_GA(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.ConcesionarioOperacionVehiculoPago, tipo As TipoSP)
      Dim sTipoUnid As SqlServer.ConcesionarioOperacionesVehiculosPagos = New SqlServer.ConcesionarioOperacionesVehiculosPagos(da)
      Select Case tipo
         Case TipoSP._I
            sTipoUnid.ConcesionarioOperacionesVehiculosPagos_I(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.PatenteVehiculo)
         Case TipoSP._U
            sTipoUnid.ConcesionarioOperacionesVehiculosPagos_U(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.PatenteVehiculo)
         Case TipoSP._M
            sTipoUnid.ConcesionarioOperacionesVehiculosPagos_M(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.PatenteVehiculo)
         Case TipoSP._D
            sTipoUnid.ConcesionarioOperacionesVehiculosPagos_D(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.PatenteVehiculo)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ConcesionarioOperacionVehiculoPago, dr As DataRow)
      With o
         .IdMarca = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionVehiculoPago.Columnas.IdMarca.ToString())
         .AnioOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionVehiculoPago.Columnas.AnioOperacion.ToString())
         .NumeroOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionVehiculoPago.Columnas.NumeroOperacion.ToString())
         .SecuenciaOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionVehiculoPago.Columnas.SecuenciaOperacion.ToString())

         .PatenteVehiculo = dr.Field(Of String)(Entidades.ConcesionarioOperacionVehiculoPago.Columnas.PatenteVehiculo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Overloads Sub _Insertar(entidad As Entidades.ConcesionarioOperacionVehiculoPago)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Overloads Sub _Actualizar(entidad As Entidades.ConcesionarioOperacionVehiculoPago)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Merge(entidad As Entidades.ConcesionarioOperacionVehiculoPago)
      EjecutaSP(entidad, TipoSP._M)
   End Sub
   Public Overloads Sub _Borrar(entidad As Entidades.ConcesionarioOperacionVehiculoPago)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Sub _Grabar(entidad As Entidades.ConcesionarioOperacion)
      Dim rVeh = New Vehiculos(da)
      entidad.VehiculosPago.Borrados.
         ForEach(Sub(v)
                    rVeh.ActualizaOperacionIngreso(v.PatenteVehiculo, Nothing, Nothing, Nothing, Nothing)
                    _Borrar(New Entidades.ConcesionarioOperacionVehiculoPago(entidad.IdMarca, entidad.AnioOperacion, entidad.NumeroOperacion, entidad.SecuenciaOperacion, v.PatenteVehiculo))
                 End Sub)
      entidad.VehiculosPago.ForEach(
         Sub(v)
            rVeh._Merge(v)
            If Not Get1(entidad.IdMarca, entidad.AnioOperacion, entidad.NumeroOperacion, entidad.SecuenciaOperacion, v.PatenteVehiculo).Any() Then
               rVeh.ActualizaOperacionIngreso(v.PatenteVehiculo, entidad.IdMarca, entidad.AnioOperacion, entidad.NumeroOperacion, entidad.SecuenciaOperacion)
            End If
            _Merge(New Entidades.ConcesionarioOperacionVehiculoPago(entidad.IdMarca, entidad.AnioOperacion, entidad.NumeroOperacion, entidad.SecuenciaOperacion, v.PatenteVehiculo))
         End Sub)
   End Sub

   '''''Grabar debe:
   '''''1- Borrar COC
   '''''2- Hacer el manejo de Nuevo/Actualizar/Borrar Cheques
   '''''3- Insertar COC
   ''''Public Overloads Sub _Grabar(entidad As Entidades.ConcesionarioOperacion)
   ''''   Dim lstChequesActual = GetChequesOperacion(entidad.IdMarca, entidad.AnioOperacion, entidad.NumeroOperacion, entidad.SecuenciaOperacion)

   ''''   _Borrar(entidad)

   ''''   Dim rCheque = New Cheques(da)
   ''''   entidad.Cheques.ForEach(
   ''''      Sub(chqOperacion)
   ''''         Dim chqDB = lstChequesActual.FirstOrDefault(Function(x) x.IdCheque = chqOperacion.IdCheque)
   ''''         If chqDB Is Nothing Then
   ''''            chqOperacion.IdSucursal = actual.Sucursal.Id
   ''''            chqOperacion.Usuario = actual.Nombre
   ''''            rCheque._Inserta(chqOperacion)
   ''''         Else
   ''''            If chqDB.IdEstadoCheque <> Entidades.Cheque.Estados.ALTA Then
   ''''               Throw New Exception(String.Format("El cheque {0} tiene estado {1} no es posible modificarlo.", chqDB.NumeroCheque, chqDB.IdEstadoCheque))
   ''''            End If
   ''''            rCheque._Modifica(chqOperacion)
   ''''         End If
   ''''         lstChequesActual.Remove(chqDB)
   ''''      End Sub)

   ''''   lstChequesActual.ForEach(
   ''''      Sub(chqDB)
   ''''         If chqDB.IdEstadoCheque <> Entidades.Cheque.Estados.ALTA Then
   ''''            Throw New Exception(String.Format("El cheque {0} tiene estado {1} no es posible modificarlo.", chqDB.NumeroCheque, chqDB.IdEstadoCheque))
   ''''         End If
   ''''         rCheque._Elimina(chqDB)
   ''''      End Sub)

   ''''   _Insertar(entidad)
   ''''End Sub
   '''''
   '''''Eliminar es el Borrar con los cheques
   ''''Public Overloads Sub _Eliminar(entidad As Entidades.ConcesionarioOperacion)
   ''''   Dim rCheque = New Cheques(da)

   ''''   Dim chqNoAlta = entidad.Cheques.FirstOrDefault(Function(c) rCheque.GetUno(c.IdCheque).IdEstadoCheque <> Entidades.Cheque.Estados.ALTA)
   ''''   If chqNoAlta IsNot Nothing Then
   ''''      Throw New Exception(String.Format("El cheque {0} tiene estado {1} no es posible anularlo.", chqNoAlta.NumeroCheque, chqNoAlta.IdEstadoCheque))
   ''''   End If

   ''''   entidad.Cheques.ForEach(Sub(c) rCheque._Elimina(c))

   ''''   _Borrar(entidad)
   ''''End Sub

   ''''Private Overloads Sub _Insertar(entidad As Entidades.ConcesionarioOperacion)
   ''''   entidad.Cheques.ForEach(
   ''''      Sub(c)
   ''''         Dim a = New Entidades.ConcesionarioOperacionVehiculoPago()
   ''''         a.IdMarca = entidad.IdMarca
   ''''         a.AnioOperacion = entidad.AnioOperacion
   ''''         a.NumeroOperacion = entidad.NumeroOperacion
   ''''         a.SecuenciaOperacion = entidad.SecuenciaOperacion
   ''''         a.IdCheque = c.IdCheque
   ''''         _Insertar(a)
   ''''      End Sub)
   ''''End Sub
   ''''Private Overloads Sub _Actualizar(entidad As Entidades.ConcesionarioOperacion)
   ''''   _Borrar(entidad)
   ''''   _Insertar(entidad)
   ''''End Sub
   Public Overloads Sub _Borrar(entidad As Entidades.ConcesionarioOperacion)
      _Borrar(New Entidades.ConcesionarioOperacionVehiculoPago() With
                  {
                     .IdMarca = entidad.IdMarca,
                     .AnioOperacion = entidad.AnioOperacion,
                     .NumeroOperacion = entidad.NumeroOperacion,
                     .SecuenciaOperacion = entidad.SecuenciaOperacion
                  })
   End Sub

   'GET UNO
   Public Function Get1(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                        patenteVehiculo As String) As DataTable
      Return New SqlServer.ConcesionarioOperacionesVehiculosPagos(da).ConcesionarioOperacionesVehiculosPagos_G1(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, patenteVehiculo)
   End Function
   Public Function GetUno(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                          patenteVehiculo As String) As Entidades.ConcesionarioOperacionVehiculoPago
      Return GetUno(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, patenteVehiculo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                          patenteVehiculo As String, accion As AccionesSiNoExisteRegistro) As Entidades.ConcesionarioOperacionVehiculoPago
      Return CargaEntidad(Get1(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, patenteVehiculo),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionVehiculoPago(),
                          accion, Function() String.Format("No existe la Patente {0} en la Operación {1} {2} {3} {4}", patenteVehiculo, idMarca, anioOperacion, numeroOperacion, secuenciaOperacion))
   End Function

   'GET TODOS
   Public Function GetTodos(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As List(Of Entidades.ConcesionarioOperacionVehiculoPago)
      Return CargaLista(GetAll(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionVehiculoPago())
   End Function
   Public Function GetTodos() As List(Of Entidades.ConcesionarioOperacionVehiculoPago)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionVehiculoPago())
   End Function

   Public Function GetVehiculosOperacion(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As List(Of Entidades.Vehiculo)
      Dim lstCheques = GetAll(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion)
      Dim vVeh = New Vehiculos(da)
      Return lstCheques.AsEnumerable().ToList().ConvertAll(Function(dr) vVeh.CargarUno(dr))
   End Function

#End Region
End Class