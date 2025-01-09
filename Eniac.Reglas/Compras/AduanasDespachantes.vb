Option Strict On
Option Explicit On
Public Class AduanasDespachantes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "AduanasDespachantes"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "AduanasDespachantes"
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
      Return New SqlServer.AduanasDespachantes(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AduanasDespachantes(Me.da).AduanasDespachantes_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.AduanaDespachante = DirectCast(entidad, Entidades.AduanaDespachante)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.AduanasDespachantes = New SqlServer.AduanasDespachantes(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AduanasDespachantes_I(en.IdDespachante, en.NombreDespachante, en.Cuit)
            Case TipoSP._U
               sqlC.AduanasDespachantes_U(en.IdDespachante, en.NombreDespachante, en.Cuit)
            Case TipoSP._D
               sqlC.AduanasDespachantes_D(en.IdDespachante)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.AduanaDespachante, ByVal dr As DataRow)
      With o
         .IdDespachante = Integer.Parse(dr(Entidades.AduanaDespachante.Columnas.IdDespachante.ToString()).ToString())
         .NombreDespachante = dr(Entidades.AduanaDespachante.Columnas.NombreDespachante.ToString()).ToString()
         .Cuit = dr(Entidades.AduanaDespachante.Columnas.Cuit.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(IdDespachante As Integer) As Entidades.AduanaDespachante
      Dim dt As DataTable = New SqlServer.AduanasDespachantes(Me.da).AduanasDespachantes_G1(IdDespachante)
      Dim o As Entidades.AduanaDespachante = New Entidades.AduanaDespachante()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.AduanaDespachante)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.AduanaDespachante
      Dim oLis As List(Of Entidades.AduanaDespachante) = New List(Of Entidades.AduanaDespachante)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.AduanaDespachante()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetFiltradoPorCodigo(codigo As Integer) As DataTable
      Return New SqlServer.AduanasDespachantes(Me.da).AduanasDespachantes_G(codigo, String.Empty)
   End Function

   Public Function GetFiltradoPorNombre(nombre As String) As DataTable
      Return New SqlServer.AduanasDespachantes(Me.da).AduanasDespachantes_G(0, nombre)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.AduanasDespachantes(Me.da).GetCodigoMaximo()
   End Function
#End Region
End Class
