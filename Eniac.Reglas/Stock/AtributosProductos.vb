Public Class AtributosProductos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.AtributoProducto.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.AtributoProducto), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.AtributoProducto), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.AtributoProducto), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.AtributosProductos(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.AtributosProductos(da).AtributosProductos_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.AtributoProducto, tipo As TipoSP)
      Dim sqlC = New SqlServer.AtributosProductos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.AtributosProductos_I(en.IdAtributoProducto, en.IdGrupoTipoAtributoProducto, en.IdTipoAtributoProducto, en.Descripcion, en.Orden)
         Case TipoSP._U
            sqlC.AtributosProductos_U(en.IdAtributoProducto, en.IdGrupoTipoAtributoProducto, en.IdTipoAtributoProducto, en.Descripcion, en.Orden)
         Case TipoSP._D
            sqlC.AtributosProductos_D(en.IdAtributoProducto, en.IdGrupoTipoAtributoProducto, en.IdTipoAtributoProducto)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.AtributoProducto, dr As DataRow)
      With o
         .IdGrupoTipoAtributoProducto = dr.Field(Of Integer)(Entidades.AtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString())
         .IdTipoAtributoProducto = dr.Field(Of Short)(Entidades.AtributoProducto.Columnas.IdTipoAtributoProducto.ToString())
         .IdAtributoProducto = dr.Field(Of Integer)(Entidades.AtributoProducto.Columnas.IdAtributoProducto.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.AtributoProducto.Columnas.Descripcion.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.AtributoProducto.Columnas.Orden.ToString())
         '--REQ-34747.- --------------------------------------------------------------------------------
         .DescripcionGrupo = dr.Field(Of String)("DescripcionGrupo")
         .DescripcionTipo = dr.Field(Of String)("DescripcionTipo")
         '----------------------------------------------------------------------------------------------
         .IdaAtributoProducto = dr.Field(Of Integer)(Entidades.AtributoProducto.Columnas.IdaAtributoProducto.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(IdAtributoProducto As Integer, IdGrupoTipoAtributoProducto As Integer, IdTipoAtributoProducto As Short) As Entidades.AtributoProducto
      Return GetUno(IdAtributoProducto, IdGrupoTipoAtributoProducto, IdTipoAtributoProducto, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(IdAtributoProducto As Integer, IdGrupoTipoAtributoProducto As Integer, IdTipoAtributoProducto As Short, accion As AccionesSiNoExisteRegistro) As Entidades.AtributoProducto
      Return CargaEntidad(New SqlServer.AtributosProductos(da).AtributosProductos_G1(IdAtributoProducto, IdGrupoTipoAtributoProducto, IdTipoAtributoProducto),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.AtributoProducto(),
                          accion, Function() String.Format("No existe Grupo de Tipo de Atributo de Producto con Id: {0}", IdAtributoProducto))
   End Function

   Public Function GetTodos() As List(Of Entidades.AtributoProducto)
      Return CargaLista(New SqlServer.AtributosProductos(da).AtributosProductos_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.AtributoProducto())
   End Function
   Public Function GetCodigoMaximo(grupoTipoAtributoProducto As Integer, tipoAtributoProducto As Short) As Integer
      Return New SqlServer.AtributosProductos(da).GetCodigoMaximo(grupoTipoAtributoProducto, tipoAtributoProducto)
   End Function

   Public Function GetOrdenMaximo(grupoTipoAtributoProducto As Integer, tipoAtributoProducto As Short) As Integer
      Return New SqlServer.AtributosProductos(da).GetOrdenMaximo(grupoTipoAtributoProducto, tipoAtributoProducto)
   End Function
   Public Function GetUnoIDA(IdaA As Integer) As Entidades.AtributoProducto
      Return CargaEntidad(New SqlServer.AtributosProductos(da).GetUnoCodigoIDA(IdaA),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.AtributoProducto(),
                          AccionesSiNoExisteRegistro.Vacio, Function() String.Format("No existe Grupo de Tipo de Atributo de Producto con Id: {0}", IdaA))
   End Function
   Public Function GetFiltradoPorCodigoIDA(IdaA As Integer, IdaG As Integer, IdaT As Short) As DataTable
      Return New SqlServer.AtributosProductos(da).GetUnoCodigoIDA(IdaA, IdaG, IdaT)
   End Function

   Public Function GetFiltradoPorNombreIDA(IdaN As String, IdaG As Integer, IdaT As Short) As DataTable
      Return New SqlServer.AtributosProductos(da).GetUnoNombreIDA(IdaN, IdaG, IdaT)
   End Function

   Public Function GetStockAtributoProductos(idProducto As String, idSucursal As Integer, idGrupoAtributo01 As Integer, idTipoAtributo01 As Integer, idGrupoAtributo02 As Integer, idTipoAtributo02 As Integer) As DataTable
      Return New SqlServer.AtributosProductos(da).GetStockAtributoProductos(idProducto, idSucursal, idGrupoAtributo01, idTipoAtributo01, idGrupoAtributo02, idTipoAtributo02)
   End Function

#End Region

End Class