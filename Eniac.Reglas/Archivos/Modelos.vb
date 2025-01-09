Public Class Modelos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Modelos", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Modelo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Modelo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Modelo), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Modelos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetAll(marcas:=Nothing)
   End Function
   Public Overloads Function GetAll(marcas As Entidades.Marca()) As DataTable
      Return New SqlServer.Modelos(da).Modelos_GA(marcas)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Modelo, tipo As TipoSP)
      Dim sqlModelos = New SqlServer.Modelos(da)
      Select Case tipo
         Case TipoSP._I
            sqlModelos.Modelos_I(en.IdModelo, en.NombreModelo, en.IdMarca, en.Orden)
         Case TipoSP._U
            sqlModelos.Modelos_U(en.IdModelo, en.NombreModelo, en.IdMarca, en.Orden)
         Case TipoSP._D
            sqlModelos.Modelos_D(en.IdModelo)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Modelo, dr As DataRow)
      With o
         .IdModelo = dr.Field(Of Integer)(Entidades.Modelo.Columnas.IdModelo.ToString())
         .NombreModelo = dr.Field(Of String)(Entidades.Modelo.Columnas.NombreModelo.ToString())
         .IdMarca = dr.Field(Of Integer)(Entidades.Modelo.Columnas.IdMarca.ToString())
         .NombreMarca = dr.Field(Of String)(Entidades.Marca.Columnas.NombreMarca.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.Modelo.Columnas.Orden.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.Modelo)
      Return GetTodos(marcas:=Nothing)
   End Function
   Public Function GetTodos(marcas As Entidades.Marca()) As List(Of Entidades.Modelo)
      Return CargaLista(GetAll(marcas), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Modelo())
   End Function

   Public Function GetPorCodigo(IdMarca As Integer, IdModelo As Integer) As DataTable
      Return New SqlServer.Modelos(da).Modelos_GA(IdMarca, IdModelo)
   End Function

   Public Function GetPorNombre(IdMarca As Integer, nombreModelo As String) As DataTable
      Return New SqlServer.Modelos(da).Modelos_GA(IdMarca, nombreModelo)
   End Function
   Public Function GetPorCodigo(marcas As Entidades.Marca(), IdModelo As Integer) As DataTable
      Return New SqlServer.Modelos(da).Modelos_GA(marcas, IdModelo)
   End Function
   Public Function GetPorNombre(marcas As Entidades.Marca(), nombreModelo As String) As DataTable
      Return New SqlServer.Modelos(da).Modelos_GA(marcas, nombreModelo)
   End Function

   Public Function Get1(idModelo As Integer) As DataTable
      Return New SqlServer.Modelos(da).Modelos_G1(idModelo)
   End Function
   Public Function GetUno(idModelo As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Modelo
      Return CargaEntidad(Get1(idModelo),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Modelo(),
                          accion, Function() String.Format("No existe el Modelo con IdModelo = {0}", idModelo))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Modelos(da).GetCodigoMaximo()
   End Function
   Public Function GetOrdenMaximo() As Integer
      Return New SqlServer.Modelos(da).GetOrdenMaximo()
   End Function
#End Region

End Class