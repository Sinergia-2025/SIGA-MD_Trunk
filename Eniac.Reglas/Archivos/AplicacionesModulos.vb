Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class AplicacionesModulos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.AplicacionModulo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.AplicacionesModulos = New SqlServer.AplicacionesModulos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AplicacionesModulos(Me.da).Modulos_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Try
         Dim en As Entidades.AplicacionModulo = DirectCast(entidad, Entidades.AplicacionModulo)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.AplicacionesModulos = New SqlServer.AplicacionesModulos(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.Modulos_I(en.IdModulo, en.NombreModulo)

            Case TipoSP._U
               sqlC.Modulos_U(en.IdModulo, en.NombreModulo)
            Case TipoSP._D
               sqlC.Modulos_D(en.IdModulo)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(o As Entidades.AplicacionModulo, dr As DataRow)
      With o
         .IdModulo = Integer.Parse(dr(Entidades.AplicacionModulo.Columnas.IdModulo.ToString()).ToString())
         .NombreModulo = dr(Entidades.AplicacionModulo.Columnas.NombreModulo.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetPorCodigo(idModulo As Integer) As DataTable
      Return New SqlServer.AplicacionesModulos(Me.da).Modulos_G1(idModulo)
   End Function
   Public Function GetPorNombre(nombreModulo As String) As DataTable
      Return New SqlServer.AplicacionesModulos(Me.da).Modulos_GA(nombreModulo, False)
   End Function

   Public Function GetUno(idModulo As Integer) As Entidades.AplicacionModulo
      Return CargaEntidad(New SqlServer.AplicacionesModulos(Me.da).Modulos_G1(idModulo), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.AplicacionModulo(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe una Modulo con id {0}", idModulo))
   End Function

   Public Function GetTodos() As List(Of Entidades.AplicacionModulo)
      Return CargaLista(New SqlServer.AplicacionesModulos(Me.da).Modulos_GA(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.AplicacionModulo())
   End Function

   Public Function Count() As Integer
      Return GetAll().Rows.Count
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.AplicacionesModulos(Me.da).GetCodigoMaximo()
   End Function
#End Region
End Class