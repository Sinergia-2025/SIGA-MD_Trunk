#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class GruposTiposAtributosProductos
	Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.GrupoTipoAtributoProducto.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.GrupoTipoAtributoProducto), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.GrupoTipoAtributoProducto), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.GrupoTipoAtributoProducto), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.GruposTiposAtributosProductos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.GruposTiposAtributosProductos(da).GruposTiposAtributosProductos_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.GrupoTipoAtributoProducto, tipo As TipoSP)
      Dim sqlC = New SqlServer.GruposTiposAtributosProductos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.GruposTiposAtributosProductos_I(en.IdGrupoTipoAtributoProducto, en.IdTipoAtributoProducto, en.Descripcion)
         Case TipoSP._U
            sqlC.GruposTiposAtributosProductos_U(en.IdGrupoTipoAtributoProducto, en.IdTipoAtributoProducto, en.Descripcion)
         Case TipoSP._D
            sqlC.GruposTiposAtributosProductos_D(en.IdGrupoTipoAtributoProducto, en.IdTipoAtributoProducto)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.GrupoTipoAtributoProducto, dr As DataRow)
      With o
         .IdGrupoTipoAtributoProducto = dr.Field(Of Integer)(Entidades.GrupoTipoAtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString())
         .IdTipoAtributoProducto = dr.Field(Of Short)(Entidades.GrupoTipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.GrupoTipoAtributoProducto.Columnas.Descripcion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(IdGrupoTipoAtributoProducto As Integer, IdTipoAtributoProducto As Short) As Entidades.GrupoTipoAtributoProducto
      Return GetUno(IdGrupoTipoAtributoProducto, IdTipoAtributoProducto, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(IdGrupoTipoAtributoProducto As Integer, IdTipoAtributoProducto As Short, accion As AccionesSiNoExisteRegistro) As Entidades.GrupoTipoAtributoProducto
      Return CargaEntidad(New SqlServer.GruposTiposAtributosProductos(da).GruposTiposAtributosProductos_G1(IdGrupoTipoAtributoProducto, IdTipoAtributoProducto),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.GrupoTipoAtributoProducto(),
                          accion, Function() String.Format("No existe Grupo de Tipo de Atributo de Producto con Id: {0}", IdGrupoTipoAtributoProducto))
   End Function

   Public Function GetTodos() As List(Of Entidades.GrupoTipoAtributoProducto)
      Return CargaLista(New SqlServer.GruposTiposAtributosProductos(da).GruposTiposAtributosProductos_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.GrupoTipoAtributoProducto())
   End Function
   Public Function GetCodigoMaximo(tipoAtributoProducto As Short) As Integer
      Return New SqlServer.GruposTiposAtributosProductos(da).GetCodigoMaximo(tipoAtributoProducto)
   End Function
   Public Function GetFiltradoPorCodigo(codigoGrupo As Integer, codigoTipo As Short) As DataTable
      Return New SqlServer.GruposTiposAtributosProductos(da).GetFiltradoPorCodigo(codigoGrupo, codigoTipo)
   End Function
   Public Function GetFiltradoPorDescripcion(descripcion As String, codigoTipo As Short) As DataTable
      Return New SqlServer.GruposTiposAtributosProductos(da).GetFiltradoPorDescripcion(descripcion, codigoTipo)
   End Function
#End Region

End Class
