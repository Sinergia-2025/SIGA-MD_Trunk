Public Class ParametrosSucursales
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ParametroSucursal.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.ParametroSucursal)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.ParametroSucursal)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.ParametroSucursal)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.ParametrosSucursales(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ParametrosSucursales(da).ParametrosSucursales_GA(actual.Sucursal.IdEmpresa, actual.Sucursal.Id)
   End Function
#End Region

#Region "Metodos Privados"

   Public Sub Inserta(entidad As Entidades.ParametroSucursal)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(entidad As Entidades.ParametroSucursal)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Merge(entidad As Entidades.ParametroSucursal)
      EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub Borra(entidad As Entidades.ParametroSucursal)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.ParametroSucursal, tipo As TipoSP)

      Dim sqlC As SqlServer.ParametrosSucursales = New SqlServer.ParametrosSucursales(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ParametrosSucursales_I(en.IdEmpresa, en.IdSucursal, en.IdParametro, en.ValorParametro)
         Case TipoSP._U
            sqlC.ParametrosSucursales_U(en.IdEmpresa, en.IdSucursal, en.IdParametro, en.ValorParametro)
         Case TipoSP._M
            sqlC.ParametrosSucursales_M(en.IdEmpresa, en.IdSucursal, en.IdParametro, en.ValorParametro)
         Case TipoSP._D
            sqlC.ParametrosSucursales_D(en.IdEmpresa, en.IdSucursal, en.IdParametro)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.ParametroSucursal, dr As DataRow)
      With o
         .IdEmpresa = Integer.Parse(dr(Entidades.ParametroSucursal.Columnas.IdEmpresa.ToString()).ToString())
         .IdSucursal = Integer.Parse(dr(Entidades.ParametroSucursal.Columnas.IdSucursal.ToString()).ToString())
         .IdParametro = dr(Entidades.ParametroSucursal.Columnas.IdParametro.ToString()).ToString()
         .ValorParametro = dr(Entidades.ParametroSucursal.Columnas.ValorParametro.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetPorCodigo(idParametro As String) As DataTable
      Return New SqlServer.ParametrosSucursales(da).ParametrosSucursales_GA(actual.Sucursal.IdEmpresa, actual.Sucursal.Id, idParametro, False)
   End Function

   Public Function Get1(idParametro As String) As DataTable
      Return Get1(actual.Sucursal.IdEmpresa, actual.Sucursal.Id, idParametro)
   End Function
   Public Function Get1(idEmpresa As Integer, idSucursal As Integer, idParametro As String) As DataTable
      Return New SqlServer.ParametrosSucursales(da).ParametrosSucursales_G1(idEmpresa, idSucursal, idParametro)
   End Function

   Public Function GetUno(idParametro As String) As Entidades.ParametroSucursal
      Return GetUno(actual.Sucursal.IdEmpresa, actual.Sucursal.Id, idParametro, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEmpresa As Integer, idSucursal As Integer, idParametro As String, accion As AccionesSiNoExisteRegistro) As Entidades.ParametroSucursal
      Return CargaEntidad(Get1(idEmpresa, idSucursal, idParametro),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ParametroSucursal(),
                          accion, Function() String.Format("No se encontró el parámetro {1} en la sucursal {0}", idSucursal, idParametro))
   End Function

   Public Function GetTodos() As List(Of Entidades.ParametroSucursal)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ParametroSucursal())
   End Function

   Public Overloads Sub Borrar(idEmpresa As Integer)
      Dim sql = New SqlServer.ParametrosSucursales(da)
      sql.ParametrosSucursales_D(idEmpresa, idSucursal:=0, idParametro:=String.Empty)
   End Sub

#End Region

End Class