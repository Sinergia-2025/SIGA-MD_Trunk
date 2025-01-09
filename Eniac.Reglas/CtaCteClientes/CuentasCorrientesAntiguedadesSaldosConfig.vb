Public Class CuentasCorrientesAntiguedadesSaldosConfig
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.CuentaCorrienteAntiguedadSaldoConfig.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteAntiguedadSaldoConfig), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteAntiguedadSaldoConfig), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteAntiguedadSaldoConfig), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.CuentasCorrientesAntiguedadesSaldosConfig(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.CuentasCorrientesAntiguedadesSaldosConfig(da).CuentasCorrientesAntiguedadesSaldosConfig_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CuentaCorrienteAntiguedadSaldoConfig, tipo As TipoSP)
      Dim sqlC = New SqlServer.CuentasCorrientesAntiguedadesSaldosConfig(da)
      Dim rRangos = New CuentasCorrientesAntiguedadesSaldosRangos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CuentasCorrientesAntiguedadesSaldosConfig_I(en.IdAntiguedadSaldoConfig, en.NombreAntiguedadSaldoConfig, en.TipoAntiguedadSaldoConfig, en.PorDefecto)
            rRangos._Insertar(en)
         Case TipoSP._U
            sqlC.CuentasCorrientesAntiguedadesSaldosConfig_U(en.IdAntiguedadSaldoConfig, en.NombreAntiguedadSaldoConfig, en.TipoAntiguedadSaldoConfig, en.PorDefecto)
            rRangos._Actualizar(en)
         Case TipoSP._D
            rRangos._Borrar(en)
            sqlC.CuentasCorrientesAntiguedadesSaldosConfig_D(en.IdAntiguedadSaldoConfig)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CuentaCorrienteAntiguedadSaldoConfig, dr As DataRow)
      With o
         .IdAntiguedadSaldoConfig = dr.Field(Of Integer)(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.IdAntiguedadSaldoConfig.ToString())
         .NombreAntiguedadSaldoConfig = dr.Field(Of String)(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.NombreAntiguedadSaldoConfig.ToString())
         .TipoAntiguedadSaldoConfig = dr.Field(Of String)(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.TipoAntiguedadSaldoConfig.ToString()).StringToEnum(Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo.AntiguedadSaldosClientes)
         .PorDefecto = dr.Field(Of Boolean)(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.PorDefecto.ToString())
         .Rangos = New CuentasCorrientesAntiguedadesSaldosRangos(da).GetTodos(.IdAntiguedadSaldoConfig)
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(idAntiguedadSaldoConfig As Integer) As Entidades.CuentaCorrienteAntiguedadSaldoConfig
      Return GetUno(idAntiguedadSaldoConfig, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idAntiguedadSaldoConfig As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CuentaCorrienteAntiguedadSaldoConfig
      Return CargaEntidad(Get1(idAntiguedadSaldoConfig), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteAntiguedadSaldoConfig(),
                          accion, Function() String.Format("No existe configuración para Antiguedad de Saldo con código {0}", idAntiguedadSaldoConfig))
   End Function
   Public Function GetTodos() As List(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteAntiguedadSaldoConfig())
   End Function

   Public Function GetTodos(tipoAntiguedadSaldoConfig As Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo?) As List(Of Entidades.CuentaCorrienteAntiguedadSaldoConfig)
      Return CargaLista(New SqlServer.CuentasCorrientesAntiguedadesSaldosConfig(da).CuentasCorrientesAntiguedadesSaldosConfig_GA_TipoConceptoCM05(tipoAntiguedadSaldoConfig),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteAntiguedadSaldoConfig())
   End Function

   Public Function Get1(idAntiguedadSaldoConfig As Integer) As DataTable
      Return New SqlServer.CuentasCorrientesAntiguedadesSaldosConfig(da).CuentasCorrientesAntiguedadesSaldosConfig_G1(idAntiguedadSaldoConfig)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CuentasCorrientesAntiguedadesSaldosConfig(da).GetCodigoMaximo()
   End Function

#End Region

End Class