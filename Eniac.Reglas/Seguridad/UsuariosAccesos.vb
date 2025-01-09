Public Class UsuariosAccesos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.UsuarioAcceso.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.UsuarioAcceso), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.UsuarioAcceso), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.UsuarioAcceso), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.UsuariosAccesos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.UsuariosAccesos(da).UsuariosAccesos_GA(idSucursal:=0)
   End Function
   Public Overloads Function GetAll(idSucursal As Integer) As DataTable
      Return New SqlServer.UsuariosAccesos(da).UsuariosAccesos_GA(idSucursal)
   End Function
   '-.PE-31629.-
   Public Function GetNombresPC() As DataTable
      Return New SqlServer.UsuariosAccesos(da).UsuariosAccesos_NombresPC(idSucursal:=0)
   End Function
   Public Function GetNombresPC(idSucursal As Integer) As DataTable
      Return New SqlServer.UsuariosAccesos(da).UsuariosAccesos_NombresPC(idSucursal)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.UsuarioAcceso, tipo As TipoSP)
      Dim sql = New SqlServer.UsuariosAccesos(da)
      Select Case tipo
         Case TipoSP._I
            sql.UsuariosAccesos_I(en.IdSucursal, en.FechaAcceso, en.Usuario, en.NombrePC, en.Exitoso, en.Observacion, en.UsuarioWindows)
            'Case TipoSP._U
            '   sql.CategoriasFiscales_U(en.IdCategoriaFiscal, en.NombreCategoriaFiscal, en.NombreCategoriaFiscalAbrev, en.LetraFiscal, _
            '                            en.LetraFiscalCompra, en.IvaDiscriminado, en.UtilizaImpuestos, _
            '                            en.CondicionIvaImpresoraFiscalEpson, en.CondicionIvaImpresoraFiscalHasar, en.Activo)
            'Case TipoSP._D
            '   sql.CategoriasFiscales_D(en.IdCategoriaFiscal)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.UsuarioAcceso, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.UsuarioAcceso.Columnas.IdSucursal.ToString())
         .Usuario = dr.Field(Of String)(Entidades.UsuarioAcceso.Columnas.Usuario.ToString())
         .FechaAcceso = dr.Field(Of Date)(Entidades.UsuarioAcceso.Columnas.FechaAcceso.ToString())
         .NombrePC = dr.Field(Of String)(Entidades.UsuarioAcceso.Columnas.NombrePC.ToString())
         .Exitoso = dr.Field(Of Boolean)(Entidades.UsuarioAcceso.Columnas.Exitoso.ToString())
         .Observacion = dr.Field(Of String)(Entidades.UsuarioAcceso.Columnas.Observacion.ToString())
         .UsuarioWindows = dr.Field(Of String)(Entidades.UsuarioAcceso.Columnas.UsuarioWindows.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Function GetTodos() As List(Of Entidades.UsuarioAcceso)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.UsuarioAcceso())
   End Function
   '-.PE-31629.-
   Public Function GetTodosNombresPC() As List(Of Entidades.UsuarioAcceso)
      Return CargaLista(GetNombresPC(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.UsuarioAcceso())
   End Function
   Public Function GetPorRangoFechas(idSucursal As Integer,
                                     fechaDesde As Date, fechaHasta As Date,
                                     idUsuario As String, idPC As String) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.UsuariosAccesos(da).
                                             GetPorRangoFechas(idSucursal, fechaDesde, fechaHasta, idUsuario, idPC))
   End Function
#End Region

End Class