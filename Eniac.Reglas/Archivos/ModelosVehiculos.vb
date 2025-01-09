Public Class ModelosVehiculos
    Inherits Base

#Region "Constructores"

    Public Sub New()
        Me.New(New Datos.DataAccess())
    End Sub

    Public Sub New(accesoDatos As Datos.DataAccess)
        Me.NombreEntidad = Entidades.ModeloVehiculo.NombreTabla
        da = accesoDatos
    End Sub

#End Region

#Region "Overrides"

    Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ModeloVehiculo), TipoSP._I))
    End Sub

    Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ModeloVehiculo), TipoSP._U))
    End Sub

    Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ModeloVehiculo), TipoSP._D))
    End Sub

    Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
        Dim sql As SqlServer.ModelosVehiculos = New SqlServer.ModelosVehiculos(Me.da)
        Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
    End Function

    Public Overrides Function GetAll() As System.Data.DataTable
        Return New SqlServer.ModelosVehiculos(Me.da).ModelosVehiculos_GA()
    End Function
#End Region

#Region "Metodos Privados"

    Private Sub EjecutaSP(en As Entidades.ModeloVehiculo, tipo As TipoSP)
        Dim sqlC As SqlServer.ModelosVehiculos = New SqlServer.ModelosVehiculos(da)
        Select Case tipo
            Case TipoSP._I
                sqlC.ModelosVehiculos_I(en.IdModeloVehiculo, en.NombreModeloVehiculo, en.IdMarcaVehiculo)
            Case TipoSP._U
                sqlC.ModelosVehiculos_U(en.IdModeloVehiculo, en.NombreModeloVehiculo, en.IdMarcaVehiculo)
            Case TipoSP._D
                sqlC.ModelosVehiculos_D(en.IdModeloVehiculo)
        End Select

    End Sub

    Private Sub CargarUno(o As Entidades.ModeloVehiculo, dr As DataRow)
        With o
            .IdModeloVehiculo = dr.Field(Of Integer)(Entidades.ModeloVehiculo.Columnas.IdModeloVehiculo.ToString())
            .NombreModeloVehiculo = dr.Field(Of String)(Entidades.ModeloVehiculo.Columnas.NombreModeloVehiculo.ToString())
            .IdMarcaVehiculo = dr.Field(Of Integer)(Entidades.ModeloVehiculo.Columnas.IdMarcaVehiculo.ToString())
        End With
    End Sub
#End Region

#Region "Metodos publicos"
    Public Function GetUno(IdModeloVehiculo As Integer) As Entidades.ModeloVehiculo
        Return GetUno(IdModeloVehiculo, AccionesSiNoExisteRegistro.Vacio)
    End Function
    Public Function GetUno(IdModeloVehiculo As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ModeloVehiculo
        Return CargaEntidad(New SqlServer.ModelosVehiculos(Me.da).ModelosVehiculos_G1(IdModeloVehiculo),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ModeloVehiculo(),
                          accion, Function() String.Format("No existe Modelo de Vehículo con Id: {0}", IdModeloVehiculo))
    End Function

    Public Function GetTodos() As List(Of Entidades.ModeloVehiculo)
        Return CargaLista(New SqlServer.ModelosVehiculos(Me.da).ModelosVehiculos_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ModeloVehiculo())
    End Function
    Public Function GetCodigoMaximo() As Integer
        Return New SqlServer.ModelosVehiculos(Me.da).GetCodigoMaximo()
    End Function

   Public Function GetAllPorMarca(ByVal IdMarcaVehiculo As Integer) As System.Data.DataTable
      Return New SqlServer.ModelosVehiculos(Me.da).ModelosVehiculos_GA(IdMarcaVehiculo)
   End Function

   Public Function GetTodosPorMarca(IdMarcaVehiculo As Integer) As List(Of Entidades.ModeloVehiculo)
      Return CargaLista(New SqlServer.ModelosVehiculos(Me.da).ModelosVehiculos_GA(IdMarcaVehiculo),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ModeloVehiculo())
   End Function

#End Region

End Class
