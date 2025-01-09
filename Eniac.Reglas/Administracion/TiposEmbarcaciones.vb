Option Strict Off
Public Class TiposEmbarcaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposEmbarcaciones"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposEmbarcaciones"
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
      Dim sql As SqlServer.TiposEmbarcaciones = New SqlServer.TiposEmbarcaciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposEmbarcaciones(Me.da).TiposEmbarcacion_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdTipoEmbarcacion) AS Maximo")
         .Append(" FROM TiposEmbarcaciones")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.TipoEmbarcacion = DirectCast(entidad, Entidades.TipoEmbarcacion)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.TiposEmbarcaciones = New SqlServer.TiposEmbarcaciones(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.TiposEmbarcacion_I(en.IdTipoEmbarcacion, en.NombreTipoEmbarcacion)
            Case TipoSP._U
               sqlC.TiposEmbarcacion_U(en.IdTipoEmbarcacion, en.NombreTipoEmbarcacion)
            Case TipoSP._D
               sqlC.TiposEmbarcacion_D(en.IdTipoEmbarcacion)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Eniac.Entidades.TipoEmbarcacion, ByVal dr As DataRow)
      With o
         .IdTipoEmbarcacion = Integer.Parse(dr(Entidades.TipoEmbarcacion.Columnas.IdTipoEmbarcacion.ToString()))
         .NombreTipoEmbarcacion = dr(Entidades.TipoEmbarcacion.Columnas.NombreTipoEmbarcacion.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idTipoEmbarcacion As Integer) As Eniac.Entidades.TipoEmbarcacion
      Dim dt As DataTable = New SqlServer.TiposEmbarcaciones(Me.da).TiposEmbarcacion_G1(idTipoEmbarcacion)
      Dim o As Eniac.Entidades.TipoEmbarcacion = New Eniac.Entidades.TipoEmbarcacion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Eniac.Entidades.TipoEmbarcacion)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Eniac.Entidades.TipoEmbarcacion
      Dim oLis As List(Of Eniac.Entidades.TipoEmbarcacion) = New List(Of Eniac.Entidades.TipoEmbarcacion)
      For Each dr As DataRow In dt.Rows
         o = New Eniac.Entidades.TipoEmbarcacion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   'Public Function GetTieneNumeros(ByVal idTipoMatricula As Integer) As Boolean
   '   Return New SqlServer.TiposMatriculas(Me.da).GetTieneNumeros(idTipoMatricula)
   'End Function

#End Region

End Class
