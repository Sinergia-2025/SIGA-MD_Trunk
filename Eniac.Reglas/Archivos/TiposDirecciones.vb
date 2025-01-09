Public Class TiposDirecciones
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "TiposDirecciones"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.TipoDireccion)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.TipoDireccion)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.TipoDireccion)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.TiposDirecciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposDirecciones(da).TiposDirecciones_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TipoDireccion, tipo As TipoSP)
      Dim sql = New SqlServer.TiposDirecciones(da)
      Select Case tipo
         Case TipoSP._I
            sql.TiposDirecciones_I(en.IdTipoDireccion, en.NombreTipoDireccion, en.NombreAbrevTipoDireccion)
         Case TipoSP._U
            sql.TiposDirecciones_U(en.IdTipoDireccion, en.NombreTipoDireccion, en.NombreAbrevTipoDireccion)
         Case TipoSP._D
            sql.TiposDirecciones_D(en.IdTipoDireccion)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.TipoDireccion, dr As DataRow)
      With o
         .IdTipoDireccion = dr.Field(Of Integer)(Entidades.TipoDireccion.Columnas.IdTipoDireccion)
         .NombreTipoDireccion = dr.Field(Of String)(Entidades.TipoDireccion.Columnas.NombreTipoDireccion).IfNull()
         .NombreAbrevTipoDireccion = dr.Field(Of String)(Entidades.TipoDireccion.Columnas.NombreAbrevTipoDireccion).IfNull()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Insertar(entidad As Entidades.TipoDireccion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.TipoDireccion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.TipoDireccion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Function GetTodas() As List(Of Entidades.TipoDireccion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoDireccion())
   End Function

   Public Function GetUna(idTipoDireccion As Integer) As Entidades.TipoDireccion
      Return GetUna(idTipoDireccion, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetUna(idTipoDireccion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TipoDireccion
      Return CargaEntidad(New SqlServer.TiposDirecciones(da).TiposDirecciones_G1(idTipoDireccion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoDireccion(),
                          accion, Function() String.Format("No existe el Tipo de Direccion con Id {0}.", idTipoDireccion))
   End Function

   Public Function GetPorCodigo(codigo As Integer) As DataTable
      Return New SqlServer.TiposDirecciones(da).TiposDirecciones_G1(codigo)
   End Function

   Public Function GetPorNombre(nombre As String) As DataTable
      Return New SqlServer.TiposDirecciones(da).TiposDirecciones_GA_PorNombre(nombre, nombreTipoDireccionExacto:=False)
   End Function

   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.TiposDirecciones(da).TiposDirecciones_GA_PorNombre(nombre, nombreTipoDireccionExacto:=True)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TiposDirecciones(da).GetCodigoMaximo()
   End Function

#End Region

End Class