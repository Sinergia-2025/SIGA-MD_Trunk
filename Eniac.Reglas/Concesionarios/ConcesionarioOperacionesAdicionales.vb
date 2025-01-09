Public Class ConcesionarioOperacionesAdicionales
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ConcesionarioOperacionAdicional.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ConcesionarioOperacionAdicional)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ConcesionarioOperacionAdicional)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ConcesionarioOperacionAdicional)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ConcesionarioOperacionesAdicionales(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ConcesionarioOperacionesAdicionales(da).ConcesionarioOperacionesAdicionales_GA()
   End Function
   Public Overloads Function GetAll(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Return New SqlServer.ConcesionarioOperacionesAdicionales(da).ConcesionarioOperacionesAdicionales_GA(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.ConcesionarioOperacionAdicional, tipo As TipoSP)
      Dim sTipoUnid As SqlServer.ConcesionarioOperacionesAdicionales = New SqlServer.ConcesionarioOperacionesAdicionales(da)
      Select Case tipo
         Case TipoSP._I
            sTipoUnid.ConcesionarioOperacionesAdicionales_I(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.IdAdicional, en.DetalleAdicional, en.PrecioAdicional.ToDecimal())
         Case TipoSP._U
            sTipoUnid.ConcesionarioOperacionesAdicionales_U(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.IdAdicional, en.DetalleAdicional, en.PrecioAdicional.ToDecimal())
         Case TipoSP._D
            sTipoUnid.ConcesionarioOperacionesAdicionales_D(en.IdMarca, en.AnioOperacion, en.NumeroOperacion, en.SecuenciaOperacion, en.IdAdicional)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ConcesionarioOperacionAdicional, dr As DataRow)
      With o
         .IdMarca = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionAdicional.Columnas.IdMarca.ToString())
         .AnioOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionAdicional.Columnas.AnioOperacion.ToString())
         .NumeroOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionAdicional.Columnas.NumeroOperacion.ToString())
         .SecuenciaOperacion = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionAdicional.Columnas.SecuenciaOperacion.ToString())

         .IdAdicional = dr.Field(Of Integer)(Entidades.ConcesionarioOperacionAdicional.Columnas.IdAdicional.ToString())

         .PrecioAdicional = dr.Field(Of Decimal)(Entidades.ConcesionarioOperacionAdicional.Columnas.PrecioAdicional.ToString())

         .NombreAdicional = dr.Field(Of String)(Entidades.ConcesionariosAdicionales.Columnas.NombreAdicional.ToString())
         .SolicitaDetalleAdicional = dr.Field(Of Boolean)(Entidades.ConcesionariosAdicionales.Columnas.SolicitaDetalle.ToString())

      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Overloads Sub _Insertar(entidad As Entidades.ConcesionarioOperacionAdicional)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Overloads Sub _Actualizar(entidad As Entidades.ConcesionarioOperacionAdicional)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Overloads Sub _Borrar(entidad As Entidades.ConcesionarioOperacionAdicional)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Sub _Insertar(entidad As Entidades.ConcesionarioOperacion)
      entidad.Adicionales.ForEach(
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
      _Borrar(New Entidades.ConcesionarioOperacionAdicional() With
                  {
                     .IdMarca = entidad.IdMarca,
                     .AnioOperacion = entidad.AnioOperacion,
                     .NumeroOperacion = entidad.NumeroOperacion,
                     .SecuenciaOperacion = entidad.SecuenciaOperacion
                  })
   End Sub

   'GET UNO
   Public Function Get1(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer, idAdicional As Integer) As DataTable
      Return New SqlServer.ConcesionarioOperacionesAdicionales(da).ConcesionarioOperacionesAdicionales_G1(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, idAdicional)
   End Function
   Public Function GetUno(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer, idAdicional As Integer) As Entidades.ConcesionarioOperacionAdicional
      Return GetUno(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, idAdicional, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer, idAdicional As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ConcesionarioOperacionAdicional
      Return CargaEntidad(Get1(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, idAdicional),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionAdicional(),
                          accion, Function() String.Format("No existe el adicional {0} en la Operación {1} {2} {3} {4}", idAdicional, idMarca, anioOperacion, numeroOperacion, secuenciaOperacion))
   End Function

   'GET TODOS
   Public Function GetTodos(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As List(Of Entidades.ConcesionarioOperacionAdicional)
      Return CargaLista(GetAll(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionAdicional())
   End Function
   Public Function GetTodos() As List(Of Entidades.ConcesionarioOperacionAdicional)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioOperacionAdicional())
   End Function

#End Region
End Class