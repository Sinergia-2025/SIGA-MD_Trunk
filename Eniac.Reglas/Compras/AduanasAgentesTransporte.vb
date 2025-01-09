Option Strict On
Option Explicit On
Public Class AduanasAgentesTransporte
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "AduanasAgentesTransporte"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "AduanasAgentesTransporte"
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
      Return New SqlServer.AduanasAgentesTransporte(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AduanasAgentesTransporte(Me.da).AduanasAgentesTransporte_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.AduanaAgenteTransporte = DirectCast(entidad, Entidades.AduanaAgenteTransporte)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.AduanasAgentesTransporte = New SqlServer.AduanasAgentesTransporte(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AduanasAgentesTransporte_I(en.IdAgenteTransporte, en.NombreAgenteTransporte, en.Cuit)
            Case TipoSP._U
               sqlC.AduanasAgentesTransporte_U(en.IdAgenteTransporte, en.NombreAgenteTransporte, en.Cuit)
            Case TipoSP._D
               sqlC.AduanasAgentesTransporte_D(en.IdAgenteTransporte)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.AduanaAgenteTransporte, ByVal dr As DataRow)
      With o
         .IdAgenteTransporte = Integer.Parse(dr(Entidades.AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString()).ToString())
         .NombreAgenteTransporte = dr(Entidades.AduanaAgenteTransporte.Columnas.NombreAgenteTransporte.ToString()).ToString()
         .Cuit = dr(Entidades.AduanaAgenteTransporte.Columnas.Cuit.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(IdAgenteTransporte As Integer) As Entidades.AduanaAgenteTransporte
      Dim dt As DataTable = New SqlServer.AduanasAgentesTransporte(Me.da).AduanasAgentesTransporte_G1(IdAgenteTransporte)
      Dim o As Entidades.AduanaAgenteTransporte = New Entidades.AduanaAgenteTransporte()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.AduanaAgenteTransporte)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.AduanaAgenteTransporte
      Dim oLis As List(Of Entidades.AduanaAgenteTransporte) = New List(Of Entidades.AduanaAgenteTransporte)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.AduanaAgenteTransporte()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetFiltradoPorCodigo(codigo As Integer) As DataTable
      Return New SqlServer.AduanasAgentesTransporte(Me.da).AduanasAgentesTransporte_G(codigo, String.Empty)
   End Function

   Public Function GetFiltradoPorNombre(nombre As String) As DataTable
      Return New SqlServer.AduanasAgentesTransporte(Me.da).AduanasAgentesTransporte_G(0, nombre)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.AduanasAgentesTransporte(Me.da).GetCodigoMaximo()
   End Function
#End Region
End Class
