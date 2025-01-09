Public Class ModelosMotores
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("ModelosMotores", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ModeloMotor)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ModeloMotor)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ModeloMotor)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ModelosMotores(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ModelosMotores(da).ModelosMotores_GA()
   End Function

   Public Overloads Function GetAll(IdMarcaMotor As Integer) As DataTable
      Return New SqlServer.ModelosMotores(da).ModelosMotores_GA(IdMarcaMotor)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ModeloMotor, tipo As TipoSP)
      Dim sql = New SqlServer.ModelosMotores(da)
      Select Case tipo
         Case TipoSP._I
            sql.ModelosMotores_I(en.IdModeloMotor, en.NombreModeloMotor, en.IdMarcaMotor)
         Case TipoSP._U
            sql.ModelosMotores_U(en.IdModeloMotor, en.NombreModeloMotor, en.IdMarcaMotor)
         Case TipoSP._D
            sql.ModelosMotores_D(en.IdModeloMotor)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ModeloMotor, dr As DataRow)
      With o
         .IdModeloMotor = dr.Field(Of Integer)(Entidades.ModeloMotor.Columnas.IdModeloMotor.ToString())
         .NombreModeloMotor = dr.Field(Of String)(Entidades.ModeloMotor.Columnas.NombreModeloMotor.ToString())
         .IdMarcaMotor = dr.Field(Of Integer)(Entidades.MarcaMotor.Columnas.IdMarcaMotor.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.ModeloMotor)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.ModeloMotor)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ModeloMotor)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idModeloMotor As Integer) As Entidades.ModeloMotor
      Return GetUno(idModeloMotor, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idModeloMotor As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ModeloMotor
      Return CargaEntidad(New SqlServer.ModelosMotores(da).ModelosMotores_G1(idModeloMotor),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ModeloMotor(),
                          accion, Function() String.Format("No existe Modelo de Motor con Id {0}", idModeloMotor))
   End Function

   Public Function GetTodas() As List(Of Entidades.ModeloMotor)
      Return CargaLista(GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ModeloMotor())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ModelosMotores(da).GetCodigoMaximo()
   End Function

   '-.PE-31591.-
   Public Function GetPorModeloMotor(nombreModeloMotor As String) As DataTable
      Dim openConnection As Boolean = False
      Try
         If da.Connection.State <> ConnectionState.Open Then
            da.OpenConection()
            openConnection = True
         End If
         Return New SqlServer.ModelosMotores(da).GetPorModeloMotor(nombreModeloMotor)
      Finally
         If openConnection Then da.CloseConection()
      End Try
   End Function

#End Region

End Class