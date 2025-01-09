Option Strict On
Option Explicit On
Public Class Aduanas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Aduanas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Aduanas"
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
      Return New SqlServer.Aduanas(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Aduanas(Me.da).Aduanas_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.Aduana = DirectCast(entidad, Entidades.Aduana)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.Aduanas = New SqlServer.Aduanas(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.Aduanas_I(en.IdAduana, en.NombreAduana)
            Case TipoSP._U
               sqlC.Aduanas_U(en.IdAduana, en.NombreAduana)
            Case TipoSP._D
               sqlC.Aduanas_D(en.IdAduana)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Aduana, ByVal dr As DataRow)
      With o
         .IdAduana = Integer.Parse(dr(Entidades.Aduana.Columnas.IdAduana.ToString()).ToString())
         .NombreAduana = dr(Entidades.Aduana.Columnas.NombreAduana.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idAduana As Integer) As Entidades.Aduana
      Dim dt As DataTable = New SqlServer.Aduanas(Me.da).Aduanas_G1(idAduana)
      Dim o As Entidades.Aduana = New Entidades.Aduana()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.Aduana)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Aduana
      Dim oLis As List(Of Entidades.Aduana) = New List(Of Entidades.Aduana)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Aduana()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetFiltradoPorCodigo(codigo As Integer) As DataTable
      Return New SqlServer.Aduanas(Me.da).Aduanas_G(codigo, String.Empty)
   End Function

   Public Function GetFiltradoPorNombre(nombre As String) As DataTable
      Return New SqlServer.Aduanas(Me.da).Aduanas_G(0, nombre)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Aduanas(Me.da).GetCodigoMaximo()
   End Function
#End Region
End Class
