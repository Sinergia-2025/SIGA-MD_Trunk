Public Class UnidadesDeMedidas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.UnidadDeMedida.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.UnidadDeMedida)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.UnidadDeMedida)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.UnidadDeMedida)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().UnidadDeMedida_GA()
   End Function

#End Region

#Region "Metodos Privados"
   Public Function GetSql() As SqlServer.UnidadesDeMedidas
      Return New SqlServer.UnidadesDeMedidas(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.UnidadDeMedida, tipo As TipoSP)
      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            sql.UnidadDeMedida_I(en.IdUnidadDeMedida, en.NombreUnidadDeMedida, en.ConversionAKilos, en.IdAFIP)
         Case TipoSP._U
            sql.UnidadDeMedida_U(en.IdUnidadDeMedida, en.NombreUnidadDeMedida, en.ConversionAKilos, en.IdAFIP)
         Case TipoSP._D
            sql.UnidadDeMedida_D(en.IdUnidadDeMedida)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.UnidadDeMedida, dr As DataRow)
      With o
         .IdUnidadDeMedida = dr.Field(Of String)(Entidades.UnidadDeMedida.Columnas.IdUnidadDeMedida.ToString())
         .NombreUnidadDeMedida = dr.Field(Of String)(Entidades.UnidadDeMedida.Columnas.NombreUnidadDeMedida.ToString())
         .ConversionAKilos = dr.Field(Of Decimal)(Entidades.UnidadDeMedida.Columnas.ConversionAKilos.ToString())
         .IdAFIP = dr.Field(Of Integer?)(Entidades.UnidadDeMedida.Columnas.IdAFIP.ToString()).IfNull()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.UnidadDeMedida)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.UnidadDeMedida)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.UnidadDeMedida)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetTodos() As List(Of Entidades.UnidadDeMedida)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.UnidadDeMedida())
   End Function

   Public Function Get1(idUnidadDeMedida As String) As DataTable
      Return GetSql().UnidadDeMedida_G1(idUnidadDeMedida)
   End Function
   Public Function GetUno(idUnidadDeMedida As String) As Entidades.UnidadDeMedida
      Return GetUno(idUnidadDeMedida, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUno(idUnidadDeMedida As String, accion As AccionesSiNoExisteRegistro) As Entidades.UnidadDeMedida
      Return CargaEntidad(Get1(idUnidadDeMedida), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.UnidadDeMedida(),
                          accion, Function() String.Format("No existe UM con Id: {0}", idUnidadDeMedida))
   End Function

   Public Function GetBuscaPorCodigo(idUnidadDeMedida As String) As DataTable
      Return GetSql().UnidadDeMedida_GA_BuscaPorCodigo(idUnidadDeMedida)
   End Function
   Public Function GetBuscaPorNombre(nombreUnidadDeMedida As String) As DataTable
      Return GetSql().UnidadDeMedida_GA_BuscaPorNombre(nombreUnidadDeMedida)
   End Function

   Public Function GetUnidadDeMedidaPorDefecto() As String
      Dim sql = GetSql()
      Using dt = sql.GetUnidadDeMedidaPorDefecto()
         If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Field(Of String)("IdUnidadDeMedida")
         Else
            Throw New Exception("No existen Unidades de Medida configuradas")
         End If
      End Using
   End Function
#End Region

End Class