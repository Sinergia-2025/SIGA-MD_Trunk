#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MRPSecciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.MRPSeccion.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPSeccion), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPSeccion), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPSeccion), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.MRPSecciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return _GetAll(Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Overloads Function _GetAll(activas As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.MRPSecciones(Me.da).Secciones_GA(activas)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPSeccion, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPSecciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Secciones_I(en.IdSeccion, en.CodigoSeccion, en.Descripcion, en.ClaseSeccion.ToString(), en.Activo)
         Case TipoSP._U
            sqlC.Secciones_U(en.IdSeccion, en.CodigoSeccion, en.Descripcion, en.ClaseSeccion.ToString(), en.Activo)
         Case TipoSP._D
            sqlC.Secciones_D(en.IdSeccion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MRPSeccion, dr As DataRow)
      With o
         .IdSeccion = dr.Field(Of Integer)(Entidades.MRPSeccion.Columnas.IdSeccion.ToString())
         .CodigoSeccion = dr.Field(Of String)(Entidades.MRPSeccion.Columnas.CodigoSeccion.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.MRPSeccion.Columnas.Descripcion.ToString())
         .ClaseSeccion = DirectCast([Enum].Parse(GetType(Entidades.MRPSeccion.ClaseSecciones), dr(Entidades.MRPSeccion.Columnas.ClaseSeccion.ToString()).ToString()), Entidades.MRPSeccion.ClaseSecciones)
         .Activo = dr.Field(Of Boolean)(Entidades.MRPSeccion.Columnas.Activo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idSeccion As Integer) As Entidades.MRPSeccion
      Return GetUno(idSeccion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSeccion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MRPSeccion
      Return CargaEntidad(New SqlServer.MRPSecciones(Me.da).Secciones_G1(idSeccion),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPSeccion(),
                          accion, Function() String.Format("No existe Seccion con Id: {0}", idSeccion))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPSeccion)
      Return CargaLista(New SqlServer.MRPSecciones(Me.da).Secciones_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPSeccion())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MRPSecciones(Me.da).GetCodigoMaximo()
   End Function
   Public Function Existe(codigoSeccion As String) As Boolean
      Return New SqlServer.MRPSecciones(da).Existe(codigoSeccion)
   End Function

#End Region

End Class
