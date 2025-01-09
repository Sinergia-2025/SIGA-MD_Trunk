#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class TiposAtributosProductos
	Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TipoAtributoProducto.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoAtributoProducto), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoAtributoProducto), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoAtributoProducto), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.TiposAtributosProductos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposAtributosProductos(Me.da).TiposAtributosProductos_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.TipoAtributoProducto, tipo As TipoSP)
      Dim sqlC = New SqlServer.TiposAtributosProductos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TiposAtributosProductos_I(en.IdTipoAtributoProducto, en.Descripcion)
         Case TipoSP._U
            sqlC.TiposAtributosProductos_U(en.IdTipoAtributoProducto, en.Descripcion)
         Case TipoSP._D
            sqlC.TiposAtributosProductos_D(en.IdTipoAtributoProducto)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.TipoAtributoProducto, dr As DataRow)
      With o
         .IdTipoAtributoProducto = dr.Field(Of Short)(Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.TipoAtributoProducto.Columnas.Descripcion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idTipoAtributoProducto As Short) As Entidades.TipoAtributoProducto
      Return GetUno(idTipoAtributoProducto, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTipoAtributoProducto As Short, accion As AccionesSiNoExisteRegistro) As Entidades.TipoAtributoProducto
      Return CargaEntidad(New SqlServer.TiposAtributosProductos(da).TiposAtributosProductos_G1(idTipoAtributoProducto),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TipoAtributoProducto(),
                          accion, Function() String.Format("No existe Tipo de Atributo de Producto con Id: {0}", idTipoAtributoProducto))
   End Function
   Public Function GetTodos() As List(Of Entidades.TipoAtributoProducto)
      Return CargaLista(New SqlServer.TiposAtributosProductos(Me.da).TiposAtributosProductos_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TipoAtributoProducto())
   End Function
   Public Function GetCodigoMaximo() As Short
      Return New SqlServer.TiposAtributosProductos(Me.da).GetCodigoMaximo()
   End Function
   Public Function GetFiltradoPorCodigo(codigo As Short) As DataTable
      Return New SqlServer.TiposAtributosProductos(da).GetFiltradoPorCodigo(codigo)
   End Function
   Public Function GetFiltradoPorDescripcion(descripcion As String) As DataTable
      Return New SqlServer.TiposAtributosProductos(da).GetFiltradoPorDescripcion(descripcion)
   End Function
#End Region

End Class
