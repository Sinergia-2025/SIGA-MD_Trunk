Public Class SueldosObraSocial

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosObraSocial"
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
         .Append(" idObraSocial ")
         .Append(", NombreObraSocial ")
         .Append(" FROM  ")
         .Append("SueldosObraSocial ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())


   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosObraSocial(Me.da).SueldosObraSocial_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim zona As Entidades.SueldosObraSocial = DirectCast(entidad, Entidades.SueldosObraSocial)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosObraSocial = New SqlServer.SueldosObraSocial(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosObraSocial_I(zona.idObraSocial, zona.NombreObraSocial)
            Case TipoSP._U
               sql.SueldosObraSocial_U(zona.idObraSocial, zona.NombreObraSocial)
            Case TipoSP._D
               sql.SueldosObraSocial_D(zona.idObraSocial)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.SueldosObraSocial)
      With o
         .idObraSocial = dr.Field(Of Integer)("idObraSocial")
         If Not String.IsNullOrEmpty(dr("NombreObraSocial").ToString()) Then
            .NombreObraSocial = dr("NombreObraSocial").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.SueldosObraSocial)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.SueldosObraSocial
      Dim oLis As List(Of Entidades.SueldosObraSocial) = New List(Of Entidades.SueldosObraSocial)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosObraSocial()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(ByVal codigo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idObraSocial,")
         .Append("       NombreObraSocial")
         .Append("  FROM SueldosObraSocial")
         If Integer.Parse(codigo) > 0 Then
            .Append(" WHERE idObraSocial = " & codigo.ToString())
         End If
         .Append("	ORDER BY NombreObraSocial")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idObraSocial,")
         .Append("       NombreObraSocial")
         .Append("  FROM SueldosObraSocial")
         .Append("	WHERE NombreObraSocial LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreObraSocial")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetUno(ByVal idSueldosCategoria As String) As Entidades.SueldosObraSocial
      Dim qry As SqlServer.SueldosObraSocial = New SqlServer.SueldosObraSocial(Me.da)

      Dim dt As DataTable = qry.SueldosObraSocial_G1(idSueldosCategoria)
      Dim o As Entidades.SueldosObraSocial = New Entidades.SueldosObraSocial()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idObraSocial = dr.Field(Of Integer)("idObraSocial")
            .NombreObraSocial = dr("NombreObraSocial").ToString()
         End With
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.SueldosObraSocial(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class