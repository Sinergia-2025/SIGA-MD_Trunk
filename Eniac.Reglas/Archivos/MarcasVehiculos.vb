Public Class MarcasVehiculos
    Inherits Base

#Region "Constructores"

    Public Sub New()
        Me.New(New Datos.DataAccess())
    End Sub

    Public Sub New(accesoDatos As Datos.DataAccess)
        Me.NombreEntidad = Entidades.MarcaVehiculo.NombreTabla
        da = accesoDatos
    End Sub

#End Region

#Region "Overrides"

    Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MarcaVehiculo), TipoSP._I))
    End Sub

    Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MarcaVehiculo), TipoSP._U))
    End Sub

    Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
        EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MarcaVehiculo), TipoSP._D))
    End Sub

    Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
        Dim sql As SqlServer.MarcasVehiculos = New SqlServer.MarcasVehiculos(Me.da)
        Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
    End Function

    Public Overrides Function GetAll() As System.Data.DataTable
        Return New SqlServer.MarcasVehiculos(Me.da).MarcasVehiculos_GA()
    End Function
#End Region

#Region "Metodos Privados"

    Private Sub EjecutaSP(en As Entidades.MarcaVehiculo, tipo As TipoSP)
        Dim sqlC As SqlServer.MarcasVehiculos = New SqlServer.MarcasVehiculos(da)
        Select Case tipo
            Case TipoSP._I
            sqlC.MarcasVehiculos_I(en.IdMarcaVehiculo, en.NombreMarcaVehiculo)
         Case TipoSP._U
            sqlC.MarcasVehiculos_U(en.IdMarcaVehiculo, en.NombreMarcaVehiculo)
         Case TipoSP._D
            sqlC.MarcasVehiculos_D(en.IdMarcaVehiculo)
      End Select

    End Sub

    Private Sub CargarUno(o As Entidades.MarcaVehiculo, dr As DataRow)
        With o
         .IdMarcaVehiculo = dr.Field(Of Integer)(Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString())
         .NombreMarcaVehiculo = dr.Field(Of String)(Entidades.MarcaVehiculo.Columnas.NombreMarcaVehiculo.ToString())
      End With
    End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(IdMarcaVehiculo As Integer) As Entidades.MarcaVehiculo
      Return GetUno(IdMarcaVehiculo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(IdMarcaVehiculo As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MarcaVehiculo
      Return CargaEntidad(New SqlServer.MarcasVehiculos(Me.da).MarcasVehiculos_G1(IdMarcaVehiculo),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MarcaVehiculo(),
                          accion, Function() String.Format("No existe Marca de Vehículo con Id: {0}", IdMarcaVehiculo))
   End Function

   Public Function GetTodos() As List(Of Entidades.MarcaVehiculo)
        Return CargaLista(New SqlServer.MarcasVehiculos(Me.da).MarcasVehiculos_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MarcaVehiculo())
    End Function
    Public Function GetCodigoMaximo() As Integer
        Return New SqlServer.MarcasVehiculos(Me.da).GetCodigoMaximo()
    End Function

#End Region


End Class
