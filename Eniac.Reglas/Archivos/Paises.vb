Option Strict On
Option Explicit On
Public Class Paises
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.Pais.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Pais.NombreTabla
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
      Dim sql As SqlServer.Paises = New SqlServer.Paises(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Paises(Me.da).Paises_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.Pais = DirectCast(entidad, Entidades.Pais)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.Paises = New SqlServer.Paises(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.Paises_I(en.IdPais, en.NombrePais, en.IdAfipPais)
            Case TipoSP._U
               sqlC.Paises_U(en.IdPais, en.NombrePais, en.IdAfipPais)
            Case TipoSP._D
               sqlC.Paises_D(en.IdPais)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Pais, ByVal dr As DataRow)
      With o
         .IdPais = dr(Entidades.Pais.Columnas.IdPais.ToString()).ToString()
         .NombrePais = dr(Entidades.Pais.Columnas.NombrePais.ToString()).ToString()
         .IdAfipPais = dr.Field(Of Integer)(Entidades.Pais.Columnas.IdAfipPais.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idPais As String) As Entidades.Pais
      Dim dt As DataTable = New SqlServer.Paises(Me.da).Paises_G1(idPais)
      Dim o As Entidades.Pais = New Entidades.Pais()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.Pais)
      Dim dt As DataTable = New SqlServer.Paises(Me.da).Paises_GA()
      Dim o As Entidades.Pais
      Dim oLis As List(Of Entidades.Pais) = New List(Of Entidades.Pais)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Pais()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class