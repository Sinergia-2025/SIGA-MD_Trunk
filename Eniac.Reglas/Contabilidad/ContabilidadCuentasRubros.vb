Public Class ContabilidadCuentasRubros
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ContabilidadCuentasRubros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ContabilidadCuentaRubro)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ContabilidadCuentaRubro)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ContabilidadCuentaRubro)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ContabilidadCuentasRubros = New SqlServer.ContabilidadCuentasRubros(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ContabilidadCuentasRubros(da).CuentaRubro_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ContabilidadCuentaRubro, tipo As TipoSP)
      Dim sql = New SqlServer.ContabilidadCuentasRubros(da)
      Select Case tipo
         Case TipoSP._I
            sql.CuentaRubro_I(en.IdRubro, en.Tipo, en.IdCuenta, en.CentroEmisor)
         Case TipoSP._U
            sql.CuentaRubro_I(en.IdRubro, en.Tipo, en.IdCuenta, en.CentroEmisor)
         Case TipoSP._D
            sql.CuentaRubro_D(en.IdRubro, en.Tipo, en.IdCuenta, en.CentroEmisor)
      End Select
   End Sub

   Private Sub CargarUna(o As Entidades.ContabilidadCuentaRubro, dr As DataRow) '', dtDetalle As DataTable)
      With o
         .IdPlanCuenta = dr.Field(Of Integer)(Entidades.ContabilidadCuentaRubro.Columnas.IdPlanCuenta.ToString())
         .Tipo = dr.Field(Of String)(Entidades.ContabilidadCuentaRubro.Columnas.Tipo.ToString())
         .IdRubro = dr.Field(Of Integer)(Entidades.ContabilidadCuentaRubro.Columnas.IdRubro.ToString())
         .IdCuenta = dr.Field(Of Long)(Entidades.ContabilidadCuentaRubro.Columnas.IdCuenta.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.ContabilidadCuentaRubro.Columnas.CentroEmisor.ToString())

         'If .CentroEmisor = 0 Then
         '   .OtrosCentroEmisores = GetTodos(.IdPlanCuenta, .IdRubro, .Tipo, excluirCentroEmisor:=0)
         '   '.OtrosCentroEmisores.AddRange(New SqlServer.Impresoras(da).DistictCentroEmisor(idSucursal:=0).
         '   '                              Where(Function(x) Not .OtrosCentroEmisores.Any(Function(ce) ce.CentroEmisor = x)).ToList().
         '   '                              ConvertAll(Function(i) New Entidades.ContabilidadCuentaRubro() With {.CentroEmisor = i}))
         '   '.OtrosCentroEmisores = .OtrosCentroEmisores.OrderBy(Function(x) x.CentroEmisor).ToList()
         'End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Overloads Sub Insertar(entidad As Entidades.ContabilidadCuentaRubro, dt As DataTable)
      EjecutaConTransaccion(Sub()
                               _Insertar(entidad)
                               ActualizaCentrosEmisores(entidad, dt)
                            End Sub)
   End Sub
   Public Overloads Sub Actualizar(entidad As Entidades.ContabilidadCuentaRubro, dt As DataTable)
      EjecutaConTransaccion(Sub()
                               _Actualizar(entidad)
                               ActualizaCentrosEmisores(entidad, dt)
                            End Sub)
   End Sub

   Private Sub ActualizaCentrosEmisores(entidad As Entidades.ContabilidadCuentaRubro, dt As DataTable)
      dt.AsEnumerable().ToList().
         ForEach(Sub(dr) _Insertar(New Entidades.ContabilidadCuentaRubro() With
                                   {
                                       .IdRubro = entidad.IdRubro,
                                       .Tipo = entidad.Tipo,
                                       .CentroEmisor = dr.Field(Of Integer)("CentroEmisor"),
                                       .IdCuenta = dr.Field(Of Long)("IdCuenta")
                                   }))
   End Sub

   Public Sub _Insertar(entidad As Entidades.ContabilidadCuentaRubro)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.ContabilidadCuentaRubro)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ContabilidadCuentaRubro)
      EjecutaSP(entidad, TipoSP._D)
   End Sub


   Public Function Existe(idRubro As Integer?, idCuenta As Long?, idPlanCuenta As Integer?, tipo As String) As Boolean
      Dim sql = New SqlServer.ContabilidadCuentasRubros(da)
      Using dt = sql.CuentaRubro_G(idRubro, idCuenta, idPlanCuenta, tipo, excluirCentroEmisor:=Nothing)
         Return dt.Rows.Count > 0
      End Using
   End Function

   Public Overloads Function GetAll(idplanCuenta As Integer, idrubro As Integer, tipo As String, excluirCentroEmisor As Integer?) As DataTable
      Return New SqlServer.ContabilidadCuentasRubros(da).CuentaRubro_G(idrubro, idCuenta:=Nothing, idplanCuenta, tipo, excluirCentroEmisor)
   End Function


   Public Function GetTodos(idplanCuenta As Integer, idrubro As Integer, tipo As String, excluirCentroEmisor As Integer?) As List(Of Entidades.ContabilidadCuentaRubro)
      Return CargaLista(GetAll(idplanCuenta, idrubro, tipo, excluirCentroEmisor),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.ContabilidadCuentaRubro())
      'Dim dt As DataTable = Me.GetAll()
      'Dim o As Entidades.ContabilidadCuentaRubro
      'Dim oLis As List(Of Entidades.ContabilidadCuentaRubro) = New List(Of Entidades.ContabilidadCuentaRubro)
      '' 'Dim dtDetalle As DataTable = Nothing ' no cargo los detalles del asiento cuando muestro la grilla de busqueda
      'For Each dr As DataRow In dt.Rows
      '   o = New Entidades.ContabilidadCuentaRubro()
      '   Me.CargarUna(o, dr) '', dtDetalle)
      '   oLis.Add(o)
      'Next
      'Return oLis
   End Function

   Public Function GetUna(idplanCuenta As Integer, idrubro As Integer, tipo As String, centroEmisor As Integer) As Entidades.ContabilidadCuentaRubro
      Return CargaEntidad(New SqlServer.ContabilidadCuentasRubros(da).CuentaRubro_G1(idplanCuenta, idrubro, tipo, centroEmisor),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.ContabilidadCuentaRubro(),
                          accion:=AccionesSiNoExisteRegistro.Vacio, Function() "")
   End Function

   'Public Function Get1(idplanCuenta As Integer, idRubro As Integer, tipo As String) As DataTable
   '   Dim sql As SqlServer.ContabilidadCuentasRubros = New SqlServer.ContabilidadCuentasRubros(da)
   '   Return sql.CuentaRubro_G1(idplanCuenta, idRubro, tipo)
   'End Function

   'Public Function GetPorNombre(dscplanCuenta As String) As DataTable
   '   Dim sql As SqlServer.ContabilidadCuentasRubros = New SqlServer.ContabilidadCuentasRubros(da)
   '   Return sql.GetPorNombre(dscplanCuenta)
   'End Function

   'Public Function GetIdMaximo() As Integer

   '   Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(da)
   '   Dim dt As DataTable = sql.PlanCuenta_GetIdMaximo()
   '   Dim val As Integer = 0

   '   If dt.Rows.Count > 0 Then
   '      If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
   '         val = Integer.Parse(dt.Rows(0)("maximo").ToString())
   '      End If
   '   End If

   '   Return val

   'End Function

   Public Function GetTipoComprobante(traerTodos As Boolean) As DataTable
      Dim sql As SqlServer.ContabilidadCuentasRubros = New SqlServer.ContabilidadCuentasRubros(da)
      Return sql.GetTipoComprobante(traerTodos)
   End Function

   'Public Function seleccionarTodasLasCuentas() As DataTable
   '    Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(da)
   '    Return sql.seleccionarTodasLasCuentas()
   'End Function

   'Public Function seleccionarTodasLasCuentasNivel1() As DataTable
   '    Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(da)
   '    Return sql.seleccionarTodasLasCuentasNivel1()
   'End Function

   'Public Function GetNivel2(nivel1 As String, idPlan As Integer) As DataTable
   '    Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(da)
   '    Return sql.Cuentas_nivel2(nivel1, idPlan)
   'End Function

   'Public Function GetNivel3(nivel2 As String, idPlan As Integer) As DataTable
   '    Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(da)
   '    Return sql.Cuentas_nivel3(nivel2, idPlan)
   'End Function

   'Public Function GetNivel4(nivel3 As String, idPlan As Integer) As DataTable
   '    Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(da)
   '    Return sql.Cuentas_nivel4(nivel3, idPlan)
   'End Function

   'Public Function GetNivel3ALL() As DataTable
   '    Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(da)
   '    Return sql.CuentasNivel3ALL
   'End Function

   'Public Function TieneHijosLaCuenta(codCuenta As Integer) As Boolean
   '    Dim sql As SqlServer.Cuentas = New SqlServer.Cuentas(da)

   '    Return sql.TieneHijosLaCuenta(codCuenta)

   'End Function

#End Region

End Class