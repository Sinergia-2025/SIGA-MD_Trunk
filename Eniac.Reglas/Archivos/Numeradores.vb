Option Strict On
Option Explicit On
Public Class Numeradores
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Numerador.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(entidad))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(entidad))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(entidad))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Numeradores = New SqlServer.Numeradores(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Numeradores(Me.da).Numeradores_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Eniac.Entidades.Numerador, tipo As TipoSP)
      Dim sqlC As SqlServer.Numeradores = New SqlServer.Numeradores(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Numeradores_I(en.IdNumerador, en.Numero, en.Descripcion)
         Case TipoSP._U
            sqlC.Numeradores_U(en.IdNumerador, en.Numero, en.Descripcion)
         Case TipoSP._M
            sqlC.Numeradores_M(en.IdNumerador, en.Numero, en.Descripcion)
         Case TipoSP._D
            sqlC.Numeradores_D(en.IdNumerador)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Numerador, dr As DataRow)
      With o
         .IdNumerador = dr(Entidades.Numerador.Columnas.IdNumerador.ToString()).ToString()
         .Numero = Long.Parse(dr(Entidades.Numerador.Columnas.Numero.ToString()).ToString())
         .Descripcion = dr(Entidades.Numerador.Columnas.Descripcion.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.Numerador), TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.Numerador), TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.Numerador), TipoSP._D)
   End Sub

   Public Function GetUno(idNumerador As String) As Entidades.Numerador
      Return GetUno(idNumerador, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUno(idNumerador As String, accion As AccionesSiNoExisteRegistro) As Entidades.Numerador
      Return CargaEntidad(New SqlServer.Numeradores(Me.da).Numeradores_G1(idNumerador), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Numerador(),
                          accion, Function() String.Format("No existe Numerador con Id = '{0}'", idNumerador))
   End Function

   Public Function GetTodos() As List(Of Entidades.Numerador)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Numerador())
   End Function

   Public Sub ActualizarNumerador(idNumerador As String, proximoNumero As Long)
      Dim sql As SqlServer.Numeradores = New SqlServer.Numeradores(da)
      sql.Numeradores_M_Numero(idNumerador, proximoNumero)
   End Sub

   Public Function _getUno(idNumerador As String) As DataTable
      Return New SqlServer.Numeradores(Me.da).Numeradores_G1(idNumerador)
   End Function

#End Region

End Class