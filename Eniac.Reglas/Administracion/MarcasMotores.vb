Public Class MarcasMotores
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("MarcasMotores", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.MarcaMotor)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.MarcaMotor)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.MarcaMotor)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.MarcasMotores(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.MarcasMotores(da).MarcasMotores_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MarcasMotores(da).GetCodigoMaximo()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.MarcaMotor, tipo As TipoSP)
      Dim sqlC = New SqlServer.MarcasMotores(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.MarcasMotores_I(en.IdMarcaMotor, en.NombreMarcaMotor)
         Case TipoSP._U
            sqlC.MarcasMotores_U(en.IdMarcaMotor, en.NombreMarcaMotor)
         Case TipoSP._D
            sqlC.MarcasMotores_D(en.IdMarcaMotor)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MarcaMotor, dr As DataRow)
      With o
         .IdMarcaMotor = dr.Field(Of Integer)(Entidades.MarcaMotor.Columnas.IdMarcaMotor.ToString())
         .NombreMarcaMotor = dr.Field(Of String)(Entidades.MarcaMotor.Columnas.NombreMarcaMotor.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.MarcaMotor)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.MarcaMotor)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.MarcaMotor)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idMarcaMotor As Integer) As DataTable
      Return New SqlServer.MarcasMotores(da).MarcasMotores_G1(idMarcaMotor)
   End Function
   Public Function GetUno(idMarcaMotor As Integer) As Entidades.MarcaMotor
      Return GetUno(idMarcaMotor, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idMarcaMotor As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MarcaMotor
      Return CargaEntidad(Get1(idMarcaMotor),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MarcaMotor(),
                          accion, String.Format("No existe Marca de Motor con Id {0}", idMarcaMotor))
   End Function
   Public Function GetTodas() As List(Of Entidades.MarcaMotor)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MarcaMotor())
   End Function

#End Region

   Public Function GetPorNombreMarca(nombreMarcaMotor As String) As DataTable
      Dim openConnection As Boolean = False
      Try
         If da.Connection.State <> ConnectionState.Open Then
            da.OpenConection()
            openConnection = True
         End If
         Return New SqlServer.MarcasMotores(da).GetPorNombreMarca(nombreMarcaMotor)
      Finally
         If openConnection Then da.CloseConection()
      End Try
   End Function
   Public Function ExistePorNombreMarca(nombreMarcaMotor As String) As Boolean
      Return GetPorNombreMarca(nombreMarcaMotor).Any()
   End Function

End Class