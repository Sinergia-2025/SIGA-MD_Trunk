Public Class ModelosEmbarcaciones
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("ModelosEmbarcaciones", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ModeloEmbarcacion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ModeloEmbarcacion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ModeloEmbarcacion)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ModelosEmbarcaciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ModelosEmbarcaciones(da).ModelosEmbarcaciones_GA()
   End Function

   Public Function GetAllPorMarca(IdMarcaEmbarcacion As Integer) As DataTable
      Return New SqlServer.ModelosEmbarcaciones(da).ModelosEmbarcaciones_GA(IdMarcaEmbarcacion)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ModelosEmbarcaciones(da).GetCodigoMaximo()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ModeloEmbarcacion, tipo As TipoSP)
      Dim sql = New SqlServer.ModelosEmbarcaciones(da)
      Select Case tipo
         Case TipoSP._I
            sql.ModelosEmbarcaciones_I(en.IdModeloEmbarcacion, en.NombreModeloEmbarcacion, en.MarcaEmbarcacion.IdMarcaEmbarcacion)
         Case TipoSP._U
            sql.ModelosEmbarcaciones_U(en.IdModeloEmbarcacion, en.NombreModeloEmbarcacion, en.MarcaEmbarcacion.IdMarcaEmbarcacion)
         Case TipoSP._D
            sql.ModelosEmbarcaciones_D(en.IdModeloEmbarcacion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ModeloEmbarcacion, dr As DataRow)
      With o
         .IdModeloEmbarcacion = dr.Field(Of Integer)(Entidades.ModeloEmbarcacion.Columnas.IdModeloEmbarcacion.ToString())
         .NombreModeloEmbarcacion = dr.Field(Of String)(Entidades.ModeloEmbarcacion.Columnas.NombreModeloEmbarcacion.ToString())
         .MarcaEmbarcacion = New MarcasEmbarcaciones(da).GetUno(dr.Field(Of Integer)(Entidades.ModeloEmbarcacion.Columnas.IdMarcaEmbarcacion.ToString()))
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.ModeloEmbarcacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.ModeloEmbarcacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ModeloEmbarcacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idModeloEmbarcacion As Integer) As Entidades.ModeloEmbarcacion
      Return GetUno(idModeloEmbarcacion, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idModeloEmbarcacion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ModeloEmbarcacion
      Return CargaEntidad(New SqlServer.ModelosEmbarcaciones(da).ModelosEmbarcaciones_G1(idModeloEmbarcacion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ModeloEmbarcacion(),
                          accion, String.Format("No existe Modelo de Embarcación con Id {0}", idModeloEmbarcacion))
   End Function

   Public Function GetTodas() As List(Of Entidades.ModeloEmbarcacion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ModeloEmbarcacion())
   End Function

#End Region

   Public Function GetPorNombreModelo(nombreMarcaEmbarcacion As String, nombreModeloEmbarcacion As String) As DataTable
      Dim openConnection As Boolean = False
      Try
         If da.Connection.State <> ConnectionState.Open Then
            da.OpenConection()
            openConnection = True
         End If
         Return New SqlServer.ModelosEmbarcaciones(da).GetPorNombreModelo(nombreMarcaEmbarcacion, nombreModeloEmbarcacion)
      Finally
         If openConnection Then da.CloseConection()
      End Try
   End Function

   Public Function ExistePorNombreModelo(nombreMarcaEmbarcacion As String, nombreModeloEmbarcacion As String) As Boolean
      Return GetPorNombreModelo(nombreMarcaEmbarcacion, nombreModeloEmbarcacion).Any()
   End Function

End Class