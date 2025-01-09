Imports Eniac.Reglas.Publicos.Simovil

Public Class SucursalesUbicaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.SucursalUbicacion.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.SucursalUbicacion), TipoSP._I, controlaCantidadUbicacionesAlBorrar:=True, actualizandoAsociado:=False))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.SucursalUbicacion), TipoSP._U, controlaCantidadUbicacionesAlBorrar:=True, actualizandoAsociado:=False))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.SucursalUbicacion), TipoSP._D, controlaCantidadUbicacionesAlBorrar:=True, actualizandoAsociado:=False))
   End Sub

   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad, actualizandoAsociado As Boolean)
      EjecutaSP(DirectCast(entidad, Entidades.SucursalUbicacion), TipoSP._I, controlaCantidadUbicacionesAlBorrar:=True, actualizandoAsociado)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad, controlaCantidadUbicacionesAlBorrar As Boolean)
      EjecutaSP(DirectCast(entidad, Entidades.SucursalUbicacion), TipoSP._D, controlaCantidadUbicacionesAlBorrar, actualizandoAsociado:=False)
   End Sub

   Public Sub _InsertarDesdeDeposito(en As Entidades.SucursalDeposito, actualizandoAsociado As Boolean)
      Dim eUbica = New Entidades.SucursalUbicacion
      With eUbica
         .IdDeposito = en.IdDeposito
         .IdSucursal = en.IdSucursal
         .IdUbicacion = GetCodigoMaximo(en.IdDeposito, en.IdSucursal) + 1
         .NombreUbicacion = en.NombreDeposito
         .CodigoUbicacion = en.CodigoDeposito
         .SucursalAsociada = en.SucursalAsociada
         .DepositoAsociado = en.DepositoAsociado
         .UbicacionAsociada = Nothing
         .EstadoUbicacion = New SucursalesUbicacionesEstados().GetOrdenMinimo()
         .Activo = en.Activo
      End With
      _Insertar(eUbica, actualizandoAsociado)
   End Sub

   Public Sub _InsertarDesdeExportacion(IdSucursal As Integer, nombreDeposito As String, nombreUbicacion As String)
      Dim eUbica = New Entidades.SucursalUbicacion
      Dim rDeposito = New Reglas.SucursalesDepositos()

      Dim en = rDeposito.GetDepositoNombre(actual.Sucursal.IdSucursal, nombreDeposito)
      With eUbica
         .IdDeposito = en.IdDeposito
         .IdSucursal = en.IdSucursal
         .IdUbicacion = GetCodigoMaximo(en.IdDeposito, en.IdSucursal) + 1
         .NombreUbicacion = nombreUbicacion
         .CodigoUbicacion = en.IdSucursal.ToString("000") + "." + en.IdDeposito.ToString("000") + "." + .IdUbicacion.ToString("000")
         .SucursalAsociada = 0
         .DepositoAsociado = 0
         .UbicacionAsociada = 0
         .EstadoUbicacion = New Reglas.SucursalesUbicacionesEstados(da).GetOrdenMinimo()
         .Activo = en.Activo
      End With
      Insertar(eUbica)
   End Sub

   Public Sub _BorrarDesdeDeposito(en As Entidades.SucursalDeposito)
      Dim eUbica = New Entidades.SucursalUbicacion
      With eUbica
         .IdDeposito = en.IdDeposito
         .IdSucursal = en.IdSucursal
         '.IdUbicacion = New Reglas.SucursalesUbicaciones().GetUno(en.IdDeposito, en.IdSucursal, 0).IdUbicacion
      End With
      _Borrar(eUbica, controlaCantidadUbicacionesAlBorrar:=False)
   End Sub


   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.SucursalesUbicaciones(da).SucursalesUbicaciones_GA()
   End Function

   Public Overrides Function Buscar(args As Entidades.Buscar) As DataTable
      Return MyBase.Buscar(args)
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.SucursalUbicacion, tipo As TipoSP, controlaCantidadUbicacionesAlBorrar As Boolean, actualizandoAsociado As Boolean)
      Dim sqlC = New SqlServer.SucursalesUbicaciones(da)
      Select Case tipo
         Case TipoSP._I
            If en.IdUbicacion = 0 Then
               en.IdUbicacion = GetCodigoMaximo(en.IdDeposito, en.IdSucursal) + 1
            End If
            sqlC.SucursalesUbicaciones_I(en.IdDeposito, en.IdSucursal, en.IdUbicacion, en.NombreUbicacion, en.CodigoUbicacion,
                                         en.SucursalAsociada, en.DepositoAsociado, en.UbicacionAsociada, en.EstadoUbicacion, en.Activo)
            ''-- Inserta Productos Sucursales Depositos.- ----------------------------------------------
            'Dim rProDepo = New ProductosUbicaciones(da)
            'rProDepo.ProductosSucursalesUbicaciones_I(en.IdDeposito, en.IdSucursal, en.IdUbicacion)
            ''------------------------------------------------------------------------------------------
         Case TipoSP._U
            sqlC.SucursalesUbicaciones_U(en.IdDeposito, en.IdSucursal, en.IdUbicacion,
                                         en.NombreUbicacion, en.CodigoUbicacion, en.EstadoUbicacion, en.Activo)
         Case TipoSP._D
            '-- Procedimiento de Eliminacion de ubicaciones.- ---
            If controlaCantidadUbicacionesAlBorrar Then
               Dim rUbica = New SucursalesUbicaciones(da)
               Using dt = rUbica.GetSucursalDeposito(idDeposito:=en.IdDeposito, idSucursal:=en.IdSucursal)
                  If dt.Rows.Count = 1 Then
                     Throw New Exception("No se Puede Borrar la Ubicacion. El Depósito posee 1 (una) sola Ubicación.")
                  End If
               End Using
            End If
            Dim dtU = New Reglas.ProductosUbicaciones(da).GetSucursalDepositoProducto(en.IdSucursal, en.IdDeposito, en.IdUbicacion, "", True)
            If dtU.Rows.Count = 0 Then
               '-- Borra Productos Sucursales Depositos.- ----------------------------------------------
               Dim rProDepo = New ProductosUbicaciones(da)
               rProDepo.ProductosSucursalesUbicaciones_D(en.IdDeposito, en.IdSucursal, en.IdUbicacion)
               '------------------------------------------------------------------------------------------
               sqlC.SucursalesUbicaciones_D(en.IdDeposito, en.IdSucursal, en.IdUbicacion)
            Else
               Throw New Exception("No se Puede Borrar la Ubicacion. La misma posee Productos con Stock")
            End If


      End Select

      If Not actualizandoAsociado Then
         Dim dep = New SucursalesDepositos(da).GetUno(en.IdDeposito, en.IdSucursal)
         If dep.DepositoAsociado <> 0 Then
            If tipo = TipoSP._I Then
               en.SucursalAsociada = en.IdSucursal
               en.DepositoAsociado = en.IdDeposito
               en.UbicacionAsociada = en.IdUbicacion
            End If
            en.IdSucursal = dep.SucursalAsociada
            en.IdDeposito = dep.DepositoAsociado

            EjecutaSP(en, tipo, controlaCantidadUbicacionesAlBorrar, actualizandoAsociado:=True)

            If tipo = TipoSP._I Then
               Dim temp = en.IdSucursal
               en.IdSucursal = en.SucursalAsociada
               en.SucursalAsociada = temp
               temp = en.IdDeposito
               en.IdDeposito = en.DepositoAsociado
               en.DepositoAsociado = temp

               temp = en.IdUbicacion
               en.IdUbicacion = en.UbicacionAsociada
               en.UbicacionAsociada = temp

               _ActualizaUbicacionAsociada(en.IdDeposito, en.IdSucursal, en.IdUbicacion, en.DepositoAsociado, en.SucursalAsociada, en.UbicacionAsociada)
            End If

         End If
      End If

   End Sub
   Private Sub CargarUno(o As Entidades.SucursalUbicacion, dr As DataRow)
      With o
         .IdDeposito = dr.Field(Of Integer)(Entidades.SucursalUbicacion.Columnas.IdDeposito.ToString())
         .NombreDeposito = dr.Field(Of String)(Entidades.SucursalUbicacion.Columnas.NombreDeposito.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.SucursalUbicacion.Columnas.IdSucursal.ToString())
         .NombreSucursal = dr.Field(Of String)(Entidades.SucursalUbicacion.Columnas.NombreSucursal.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.SucursalUbicacion.Columnas.IdUbicacion.ToString())
         .NombreUbicacion = dr.Field(Of String)(Entidades.SucursalUbicacion.Columnas.NombreUbicacion.ToString())
         .CodigoUbicacion = dr.Field(Of String)(Entidades.SucursalUbicacion.Columnas.CodigoUbicacion.ToString())
         .EstadoUbicacion = dr.Field(Of Integer)(Entidades.SucursalUbicacion.Columnas.EstadoUbicacion.ToString())
         .NombreEstado = dr.Field(Of String)(Entidades.SucursalUbicacion.Columnas.NombreEstado.ToString())
         .SucursalAsociada = dr.Field(Of Integer?)(Entidades.SucursalUbicacion.Columnas.SucursalAsociada.ToString()).IfNull()
         .DepositoAsociado = dr.Field(Of Integer?)(Entidades.SucursalUbicacion.Columnas.DepositoAsociado.ToString()).IfNull()
         .UbicacionAsociada = dr.Field(Of Integer?)(Entidades.SucursalUbicacion.Columnas.UbicacionAsociada.ToString()).IfNull()
         .Activo = dr.Field(Of Boolean)(Entidades.SucursalUbicacion.Columnas.Activo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idDeposito As Integer, idSucursal As Integer, idUbicacion As Integer) As Entidades.SucursalUbicacion
      Return GetUno(idDeposito, idSucursal, idUbicacion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idDeposito As Integer, idSucursal As Integer, idUbicacion As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.SucursalUbicacion
      Return CargaEntidad(New SqlServer.SucursalesUbicaciones(da).SucursalesUbicaciones_G1(idDeposito, idSucursal, idUbicacion),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SucursalUbicacion(),
                          accion, Function() String.Format("No existe Sucursal({0}) - Deposito ({1})", idSucursal, idDeposito))
   End Function
   Public Function GetTodos() As List(Of Entidades.SucursalUbicacion)
      Return CargaLista(New SqlServer.SucursalesUbicaciones(da).SucursalesUbicaciones_GA(),
                      Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SucursalUbicacion())
   End Function
   Public Function GetCodigoMaximo(idDeposito As Integer, idSucursal As Integer) As Integer
      Return New SqlServer.SucursalesUbicaciones(da).GetCodigoMaximo(idDeposito, idSucursal)
   End Function

   Public Function GetSucursalDeposito(idDeposito As Integer, idSucursal As Integer) As DataTable
      Return New SqlServer.SucursalesUbicaciones(da).GetSucursalDeposito(idDeposito, idSucursal)
   End Function
   Public Function GetSucursalDepositoMultiples(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito()) As DataTable
      Dim dt = New SqlServer.SucursalesUbicaciones(da).GetSucursalDepositoMultiples(sucursales, depositos)
      If depositos.Count > 1 Then
         dt.AsEnumerable().ToList().
            ForEach(Sub(dr)
                       Dim nombre = String.Format("{1} ({0})",
                                                  dr.Field(Of String)(Entidades.SucursalUbicacion.Columnas.NombreDeposito.ToString()),
                                                  dr.Field(Of String)(Entidades.SucursalUbicacion.Columnas.NombreUbicacion.ToString()))
                       dr(Entidades.SucursalUbicacion.Columnas.NombreUbicacion.ToString()) = nombre
                    End Sub)
      End If
      Return dt
   End Function
   Public Function GetTodosSucursalDeposito(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito()) As List(Of Entidades.SucursalUbicacion)
      Return CargaLista(GetSucursalDepositoMultiples(sucursales, depositos),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.SucursalUbicacion())
   End Function

   Public Sub ActualizaUbicacionAsociada(idDeposito As Integer, idSucursal As Integer, idUbicacion As Integer,
                                         depositoAsociado As Integer, sucursalAsociada As Integer, ubicacionAsociada As Integer)
      EjecutaConTransaccion(Sub() _ActualizaUbicacionAsociada(idDeposito, idSucursal, idUbicacion, depositoAsociado, sucursalAsociada, ubicacionAsociada))
   End Sub

   Public Sub _ActualizaUbicacionAsociada(idDeposito As Integer, idSucursal As Integer, idUbicacion As Integer,
                                         depositoAsociado As Integer, sucursalAsociada As Integer, ubicacionAsociada As Integer)
      Dim sql = New SqlServer.SucursalesUbicaciones(da)
      sql.SucursalesUbicaciones_U_SucAsoc(idDeposito, idSucursal, idUbicacion, depositoAsociado, sucursalAsociada, ubicacionAsociada)
   End Sub

   Public Function GetUbicacionPredeterminadaParaSucursal(idSucursal As Integer) As DataTable
      Return New SqlServer.SucursalesUbicaciones(da).GetUbicacionPredeterminadaParaSucursal(idSucursal, sinVinculadas:=True)
   End Function

   Public Function GetUbicacionNombres(idSucursal As Integer, nombreDeposito As String, nombreUbicacion As String) As Entidades.SucursalUbicacion
      Return GetUbicacionNombres(idSucursal, nombreDeposito, nombreUbicacion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUbicacionNombres(idSucursal As Integer, nombreDeposito As String, nombreUbicacion As String, accion As AccionesSiNoExisteRegistro) As Entidades.SucursalUbicacion
      Return CargaEntidad(New SqlServer.SucursalesUbicaciones(da).GetUbicacionNombres(idSucursal, nombreDeposito, nombreUbicacion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.SucursalUbicacion(),
                          accion, Function() String.Format("No existe Deposito"))
   End Function
   Public Function ExistePorNombre(idSucursal As Integer, nombreDeposito As String, nombreUbicacion As String) As Boolean
      Return GetUbicacionNombres(idSucursal, nombreDeposito, nombreUbicacion, AccionesSiNoExisteRegistro.Nulo) IsNot Nothing
   End Function

#End Region

End Class