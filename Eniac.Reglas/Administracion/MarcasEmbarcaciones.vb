Public Class MarcasEmbarcaciones
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("MarcasEmbarcaciones", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.MarcaEmbarcacion)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.MarcaEmbarcacion)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.MarcaEmbarcacion)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.MarcasEmbarcaciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MarcasEmbarcaciones(da).MarcasEmbarcaciones_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MarcasEmbarcaciones(da).GetCodigoMaximo()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.MarcaEmbarcacion, tipo As TipoSP)
      Dim sql = New SqlServer.MarcasEmbarcaciones(da)
      Select Case tipo
         Case TipoSP._I
            sql.MarcasEmbarcaciones_I(en.IdMarcaEmbarcacion, en.NombreMarcaEmbarcacion)
         Case TipoSP._U
            sql.MarcasEmbarcaciones_U(en.IdMarcaEmbarcacion, en.NombreMarcaEmbarcacion)
         Case TipoSP._D
            sql.MarcasEmbarcaciones_D(en.IdMarcaEmbarcacion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MarcaEmbarcacion, dr As DataRow)
      With o
         .IdMarcaEmbarcacion = dr.Field(Of Integer)(Entidades.MarcaEmbarcacion.Columnas.IdMarcaEmbarcacion.ToString())
         .NombreMarcaEmbarcacion = dr.Field(Of String)(Entidades.MarcaEmbarcacion.Columnas.NombreMarcaEmbarcacion.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Entidades.MarcaEmbarcacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.MarcaEmbarcacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.MarcaEmbarcacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idMarcaEmbarcacion As Integer) As Entidades.MarcaEmbarcacion
      Return GetUno(idMarcaEmbarcacion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idMarcaEmbarcacion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MarcaEmbarcacion
      Return CargaEntidad(New SqlServer.MarcasEmbarcaciones(da).MarcasEmbarcaciones_G1(idMarcaEmbarcacion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MarcaEmbarcacion(),
                          accion, String.Format("No existe Marca de Embarcación con Id {0}", idMarcaEmbarcacion))
   End Function

   Public Function GetTodas() As List(Of Entidades.MarcaEmbarcacion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MarcaEmbarcacion())
   End Function

#End Region

   Public Function GetPorNombreMarca(nombreMarcaEmbarcacion As String) As DataTable
      Dim openConnection As Boolean = False
      Try
         If da.Connection.State <> ConnectionState.Open Then
            da.OpenConection()
            openConnection = True
         End If
         Return New SqlServer.MarcasEmbarcaciones(da).GetPorNombreMarca(nombreMarcaEmbarcacion)
      Finally
         If openConnection Then da.CloseConection()
      End Try
   End Function
   Public Function ExistePorNombreMarca(nombreMarcaEmbarcacion As String) As Boolean
      Return GetPorNombreMarca(nombreMarcaEmbarcacion).Any()
   End Function

End Class