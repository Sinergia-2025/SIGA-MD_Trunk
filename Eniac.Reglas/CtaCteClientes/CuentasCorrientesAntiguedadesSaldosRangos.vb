Public Class CuentasCorrientesAntiguedadesSaldosRangos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.CuentaCorrienteAntiguedadSaldoRangos.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CuentaCorrienteAntiguedadSaldoRangos)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CuentaCorrienteAntiguedadSaldoRangos)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CuentaCorrienteAntiguedadSaldoRangos)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.CuentasCorrientesAntiguedadesSaldosRangos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.CuentasCorrientesAntiguedadesSaldosRangos(da).CuentasCorrientesAntiguedadesSaldosRangos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CuentaCorrienteAntiguedadSaldoRangos, tipo As TipoSP)
      Dim sqlC = New SqlServer.CuentasCorrientesAntiguedadesSaldosRangos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CuentasCorrientesAntiguedadesSaldosRangos_I(en.IdAntiguedadSaldoConfig, en.DiasDesde, en.DiasHasta, en.EtiquetaColumna, en.Orden)
         Case TipoSP._U
            sqlC.CuentasCorrientesAntiguedadesSaldosRangos_U(en.IdAntiguedadSaldoConfig, en.DiasDesde, en.DiasHasta, en.EtiquetaColumna, en.Orden)
         Case TipoSP._D
            sqlC.CuentasCorrientesAntiguedadesSaldosRangos_D(en.IdAntiguedadSaldoConfig, en.DiasDesde)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CuentaCorrienteAntiguedadSaldoRangos, dr As DataRow)
      With o
         .IdAntiguedadSaldoConfig = dr.Field(Of Integer)(Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.IdAntiguedadSaldoConfig.ToString())
         .DiasDesde = dr.Field(Of Integer)(Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.DiasDesde.ToString())
         .DiasHasta = dr.Field(Of Integer)(Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.DiasHasta.ToString())
         .EtiquetaColumna = dr.Field(Of String)(Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.EtiquetaColumna.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.Orden.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Entidades.CuentaCorrienteAntiguedadSaldoRangos)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CuentaCorrienteAntiguedadSaldoRangos)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CuentaCorrienteAntiguedadSaldoRangos)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Insertar(en As Entidades.CuentaCorrienteAntiguedadSaldoConfig)
      en.Rangos.ForEach(
         Sub(r)
            r.IdAntiguedadSaldoConfig = en.IdAntiguedadSaldoConfig
            _Insertar(r)
         End Sub)
   End Sub
   Public Sub _Actualizar(en As Entidades.CuentaCorrienteAntiguedadSaldoConfig)
      _Borrar(en)
      _Insertar(en)
   End Sub
   Public Sub _Borrar(en As Entidades.CuentaCorrienteAntiguedadSaldoConfig)
      Dim sqlC = New SqlServer.CuentasCorrientesAntiguedadesSaldosRangos(da)
      sqlC.CuentasCorrientesAntiguedadesSaldosRangos_D(en.IdAntiguedadSaldoConfig, diasDesde:=Nothing)
   End Sub

   'Public Function GetUno(idAntiguedadSaldoConfig As Integer, diasDesde As Integer) As Entidades.CuentaCorrienteAntiguedadSaldoRangos
   '   Return GetUno(idAntiguedadSaldoConfig, diasDesde, AccionesSiNoExisteRegistro.Vacio)
   'End Function
   'Public Function GetUno(idAntiguedadSaldoConfig As Integer, diasDesde As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CuentaCorrienteAntiguedadSaldoRangos
   '   Return CargaEntidad(Get1(idAntiguedadSaldoConfig, diasDesde), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteAntiguedadSaldoRangos(),
   '                       accion, Function() String.Format("No existe Concepto CM05 con código {0}", idConceptoCM05))
   'End Function
   Public Function GetTodos() As List(Of Entidades.CuentaCorrienteAntiguedadSaldoRangos)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteAntiguedadSaldoRangos())
   End Function

   Public Function GetTodos(idAntiguedadSaldoConfig As Integer) As List(Of Entidades.CuentaCorrienteAntiguedadSaldoRangos)
      Return CargaLista(New SqlServer.CuentasCorrientesAntiguedadesSaldosRangos(da).CuentasCorrientesAntiguedadesSaldosRangos_GA(idAntiguedadSaldoConfig),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteAntiguedadSaldoRangos())
   End Function

   'Public Function Get1(idAntiguedadSaldoConfig As Integer, diasDesde As Integer) As DataTable
   '   Return New SqlServer.CuentasCorrientesAntiguedadesSaldosRangos(da).CuentasCorrientesAntiguedadesSaldosRangos_G1(idAntiguedadSaldoConfig, diasDesde)
   'End Function

   Public Function GetOrdenMaximo(idAntiguedadSaldoConfig As Integer) As Integer
      Return New SqlServer.CuentasCorrientesAntiguedadesSaldosRangos(da).GetOrdenMaximo(idAntiguedadSaldoConfig)
   End Function

#End Region

End Class