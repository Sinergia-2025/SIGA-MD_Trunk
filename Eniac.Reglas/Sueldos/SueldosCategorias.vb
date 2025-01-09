Public Class SueldosCategorias

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosCategoria"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
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

      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT")
         .Append(" IdCategoria ")
         .Append(", NombreCategoria ")
         .Append(" FROM  ")
         .Append("SueldosCategorias ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosCategorias(Me.da).SueldosCategorias_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim zona As Entidades.SueldosCategoria = DirectCast(entidad, Entidades.SueldosCategoria)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosCategorias = New SqlServer.SueldosCategorias(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosCategorias_I(zona.idCategoria, zona.NombreCategoria)
            Case TipoSP._U
               sql.SueldosCategorias_U(zona.idCategoria, zona.NombreCategoria)
            Case TipoSP._D
               sql.SueldosCategorias_D(zona.idCategoria)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.SueldosCategoria)
      With o
         .idCategoria = Int32.Parse(dr("IdCategoria").ToString())
         If Not String.IsNullOrEmpty(dr("NombreCategoria").ToString()) Then
            .NombreCategoria = dr("NombreCategoria").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.SueldosCategoria)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.SueldosCategoria
      Dim oLis As List(Of Entidades.SueldosCategoria) = New List(Of Entidades.SueldosCategoria)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosCategoria()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(ByVal codigo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdCategoria,")
         .Append("       NombreCategoria")
         .Append("  FROM SueldosCategorias")
         If Integer.Parse(codigo) > 0 Then
            .Append(" WHERE IdCategoria = " & codigo.ToString())
         End If
         .Append("	ORDER BY NombreCategoria")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdCategoria,")
         .Append("       NombreCategoria")
         .Append("  FROM SueldosCategorias")
         .Append("	WHERE NombreCategoria LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreCategoria")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetUno(ByVal idSueldosCategoria As Integer) As Entidades.SueldosCategoria
      Try
         Me.da.OpenConection()
         Return Me._GetUno(idSueldosCategoria)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Friend Function _GetUno(ByVal idSueldosCategoria As Integer) As Entidades.SueldosCategoria
      Dim qry As SqlServer.SueldosCategorias = New SqlServer.SueldosCategorias(Me.da)

      Dim dt As DataTable = qry.SueldosCategorias_G1(idSueldosCategoria)
      Dim o As Entidades.SueldosCategoria = New Entidades.SueldosCategoria()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idCategoria = dr.Field(Of Integer?)("IdCategoria").IfNull()
            .NombreCategoria = dr("NombreCategoria").ToString()
         End With
      End If
      Return o
   End Function



#End Region

End Class
