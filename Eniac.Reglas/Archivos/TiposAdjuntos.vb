Option Strict On
Option Explicit On
Public Class TiposAdjuntos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposAdjuntos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposAdjuntos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TiposAdjuntos = New SqlServer.TiposAdjuntos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposAdjuntos(Me.da).TiposAdjuntos_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.TipoAdjunto = DirectCast(entidad, Entidades.TipoAdjunto)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.TiposAdjuntos = New SqlServer.TiposAdjuntos(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.TiposAdjuntos_I(en.IdTipoAdjunto, en.NombreTipoAdjunto)
            Case TipoSP._U
               sqlC.TiposAdjuntos_U(en.IdTipoAdjunto, en.NombreTipoAdjunto)
            Case TipoSP._D
               sqlC.TiposAdjuntos_D(en.IdTipoAdjunto)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoAdjunto, ByVal dr As DataRow)
      With o
         .IdTipoAdjunto = Integer.Parse(dr(Entidades.TipoAdjunto.Columnas.IdTipoAdjunto.ToString()).ToString())
         .NombreTipoAdjunto = dr(Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTipoAdjunto As Integer) As Entidades.TipoAdjunto
      Dim dt As DataTable = New SqlServer.TiposAdjuntos(Me.da).TiposAdjuntos_G1(idTipoAdjunto)
      Dim o As Entidades.TipoAdjunto = New Entidades.TipoAdjunto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.TipoAdjunto)
      Dim dt As DataTable = New SqlServer.TiposAdjuntos(Me.da).TiposAdjuntos_GA()
      Dim o As Entidades.TipoAdjunto
      Dim oLis As List(Of Entidades.TipoAdjunto) = New List(Of Entidades.TipoAdjunto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoAdjunto()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return New SqlServer.TiposAdjuntos(da).GetCodigoMaximo()
   End Function

#End Region
End Class