Public Class ConcesionarioOperacionesTarjetas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ConcesionarioOperacionTarjeta.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ConcesionarioOperacionTarjeta)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ConcesionarioOperacionTarjeta)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ConcesionarioOperacionTarjeta)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ConcesionarioOperacionesTarjetas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ConcesionarioOperacionesTarjetas(da).ConcesionarioOperacionesTarjetas_GA()
   End Function
   Public Overloads Function GetAll(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Return New SqlServer.ConcesionarioOperacionesTarjetas(da).ConcesionarioOperacionesTarjetas_GA(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.ConcesionarioOperacionTarjeta, tipo As TipoSP)
      Dim sTipoUnid As SqlServer.ConcesionarioOperacionesTarjetas = New SqlServer.ConcesionarioOperacionesTarjetas(da)
      Select Case tipo
         Case TipoSP._I
            sTipoUnid.ConcesionarioOperacionesTarjetas_I(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.Orden, en.Tarjeta.IdTarjeta, en.Banco.IdBanco, en.Monto, en.Cuotas, en.NumeroCupon, en.NumeroLote)
         Case TipoSP._U
            sTipoUnid.ConcesionarioOperacionesTarjetas_U(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.Orden, en.Tarjeta.IdTarjeta, en.Banco.IdBanco, en.Monto, en.Cuotas, en.NumeroCupon, en.NumeroLote)
         Case TipoSP._D
            sTipoUnid.ConcesionarioOperacionesTarjetas_D(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.Orden, en.Tarjeta.IdTarjeta, en.Banco.IdBanco)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ConcesionarioOperacionTarjeta, dr As DataRow)
      With o
         .IdMarca = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.IdMarca.ToString())
         .AnioOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.AnioOperacion.ToString())
         .NumeroOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroOperacion.ToString())
         .SecuenciaOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.SecuenciaOperacion.ToString())

         .Orden = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.Orden.ToString())

         .Tarjeta = New Tarjetas(da)._GetUno(dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.IdTarjeta.ToString()))
         .Banco = New Bancos(da).GetUno(dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.IdBanco.ToString()))

         .Monto = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacionTarjeta.Columnas.Monto.ToString())
         .Cuotas = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.Cuotas.ToString())
         .NumeroCupon = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroCupon.ToString())
         .NumeroLote = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroLote.ToString())

      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Overloads Sub _Insertar(entidad As Entidades.ConcesionarioOperacionTarjeta)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Overloads Sub _Actualizar(entidad As Entidades.ConcesionarioOperacionTarjeta)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Overloads Sub _Borrar(entidad As Entidades.ConcesionarioOperacionTarjeta)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Sub _Insertar(entidad As Entidades.ConcesionarioOperacion)
      entidad.Tarjetas.ForEach(
         Sub(a)
            a.IdMarca = entidad.IdMarca
            a.AnioOperacion = entidad.AnioOperacion
            a.NumeroOperacion = entidad.NumeroOperacion
            a.SecuenciaOperacion = entidad.SecuenciaOperacion
            _Insertar(a)
         End Sub)
   End Sub
   Public Overloads Sub _Actualizar(entidad As Entidades.ConcesionarioOperacion)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Overloads Sub _Borrar(entidad As Entidades.ConcesionarioOperacion)
      _Borrar(New Entidades.ConcesionarioOperacionTarjeta() With
                  {
                     .IdMarca = entidad.IdMarca,
                     .AnioOperacion = entidad.AnioOperacion,
                     .NumeroOperacion = entidad.NumeroOperacion,
                     .SecuenciaOperacion = entidad.SecuenciaOperacion
                  })
   End Sub

   'GET UNO
   Public Function Get1(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                        orden As Integer, idTarjeta As Integer, idBanco As Integer) As DataTable
      Return New SqlServer.ConcesionarioOperacionesTarjetas(da).ConcesionarioOperacionesTarjetas_G1(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, orden, idTarjeta, idBanco)
   End Function
   Public Function GetUno(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                          orden As Integer, idTarjeta As Integer, idBanco As Integer) As Entidades.ConcesionarioOperacionTarjeta
      Return GetUno(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, orden, idTarjeta, idBanco, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                          orden As Integer, idTarjeta As Integer, idBanco As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ConcesionarioOperacionTarjeta
      Return CargaEntidad(Get1(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, orden, idTarjeta, idBanco),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionTarjeta(),
                          accion, Function() String.Format("No existe el orden {0} en la Operación {1} {2} {3} {4}", orden, idMarca, anioOperacion, numeroOperacion, secuenciaOperacion))
   End Function

   'GET TODOS
   Public Function GetTodos(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As List(Of Entidades.ConcesionarioOperacionTarjeta)
      Return CargaLista(GetAll(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionTarjeta())
   End Function
   Public Function GetTodos() As List(Of Entidades.ConcesionarioOperacionTarjeta)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionTarjeta())
   End Function

#End Region
End Class