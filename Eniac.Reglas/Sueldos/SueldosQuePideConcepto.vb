Public Class SueldosQuePideConcepto

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosQuePideConcepto"
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
         .Append(" idQuePide ")
         .Append(", NombreQuePide ")
         .Append(" FROM  ")
         .Append("SueldosQuePideConcepto ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosQuePideConcepto(Me.da).SueldosQuePideConcepto_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim zona As Entidades.SueldosQuePideConcepto = DirectCast(entidad, Entidades.SueldosQuePideConcepto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosQuePideConcepto = New SqlServer.SueldosQuePideConcepto(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosQuePideConcepto_I(zona.idQuePide, zona.NombreQuePide)
            Case TipoSP._U
               sql.SueldosQuePideConcepto_U(zona.idQuePide, zona.NombreQuePide)
            Case TipoSP._D
               sql.SueldosQuePideConcepto_D(zona.idQuePide)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.SueldosQuePideConcepto)
      With o
         .idQuePide = Integer.Parse(dr("idQuePide").ToString())
         .NombreQuePide = dr("NombreQuePide").ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.SueldosQuePideConcepto)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.SueldosQuePideConcepto
      Dim oLis As List(Of Entidades.SueldosQuePideConcepto) = New List(Of Entidades.SueldosQuePideConcepto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosQuePideConcepto()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(ByVal codigo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idQuePide,")
         .Append("       NombreQuePide")
         .Append("  FROM SueldosQuePideConcepto")
         If Integer.Parse(codigo) > 0 Then
            .Append(" WHERE idQuePide = " & codigo.ToString())
         End If
         .Append("	ORDER BY NombreQuePide")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idQuePide,")
         .Append("       NombreQuePide")
         .Append("  FROM SueldosQuePideConcepto")
         .Append("	WHERE NombreQuePide LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreQuePide")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetUno(ByVal idSueldosCategoria As String) As Entidades.SueldosQuePideConcepto
      Dim qry As SqlServer.SueldosQuePideConcepto = New SqlServer.SueldosQuePideConcepto(Me.da)
      Dim dt As DataTable = qry.SueldosQuePideConcepto_G1(idSueldosCategoria)
      Dim o As Entidades.SueldosQuePideConcepto = New Entidades.SueldosQuePideConcepto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idQuePide = Integer.Parse(dr("idQuePide").ToString())
            .NombreQuePide = dr("NombreQuePide").ToString()
         End With
      End If
      Return o
   End Function

#End Region

End Class