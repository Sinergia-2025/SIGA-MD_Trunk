Option Strict On
Option Explicit On
Public Class AduanasDestinaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "AduanasDestinaciones"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "AduanasDestinaciones"
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
      Return New SqlServer.AduanasDestinaciones(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AduanasDestinaciones(Me.da).AduanasDestinaciones_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.AduanaDestinacion = DirectCast(entidad, Entidades.AduanaDestinacion)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.AduanasDestinaciones = New SqlServer.AduanasDestinaciones(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AduanasDestinaciones_I(en.IdDestinacion, en.NombreDestinacion, en.RegimenArancelario)
            Case TipoSP._U
               sqlC.AduanasDestinaciones_U(en.IdDestinacion, en.NombreDestinacion, en.RegimenArancelario)
            Case TipoSP._D
               sqlC.AduanasDestinaciones_D(en.IdDestinacion)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.AduanaDestinacion, ByVal dr As DataRow)
      With o
         .IdDestinacion = dr(Entidades.AduanaDestinacion.Columnas.IdDestinacion.ToString()).ToString()
         .NombreDestinacion = dr(Entidades.AduanaDestinacion.Columnas.NombreDestinacion.ToString()).ToString()
         .RegimenArancelario = dr(Entidades.AduanaDestinacion.Columnas.RegimenArancelario.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(IdDestinacion As String) As Entidades.AduanaDestinacion
      Dim dt As DataTable = New SqlServer.AduanasDestinaciones(Me.da).AduanasDestinaciones_G1(IdDestinacion)
      Dim o As Entidades.AduanaDestinacion = New Entidades.AduanaDestinacion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.AduanaDestinacion)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.AduanaDestinacion
      Dim oLis As List(Of Entidades.AduanaDestinacion) = New List(Of Entidades.AduanaDestinacion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.AduanaDestinacion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetFiltradoPorCodigo(codigo As String, idDestinacionParcial As Boolean) As DataTable
      Return New SqlServer.AduanasDestinaciones(Me.da).AduanasDestinaciones_G(codigo, String.Empty, idDestinacionParcial)
   End Function

   Public Function GetFiltradoPorNombre(nombre As String) As DataTable
      Return New SqlServer.AduanasDestinaciones(Me.da).AduanasDestinaciones_G(String.Empty, nombre, False)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.AduanasDestinaciones(Me.da).GetCodigoMaximo()
   End Function

#End Region
End Class
