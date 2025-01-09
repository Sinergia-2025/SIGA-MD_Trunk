Public Class SueldosEstadoCivil
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosEstadoCivil"
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
         .Append(" idEstadoCivil ")
         .Append(", NombreEstadoCivil ")
         .Append(" FROM  ")
         .Append("SueldosEstadoCivil ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())


   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosEstadoCivil(Me.da).SueldosEstadoCivil_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim zona As Entidades.SueldosEstadoCivil = DirectCast(entidad, Entidades.SueldosEstadoCivil)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosEstadoCivil = New SqlServer.SueldosEstadoCivil(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosEstadoCivil_I(zona.idEstadoCivil, zona.NombreEstadoCivil)
            Case TipoSP._U
               sql.SueldosEstadoCivil_U(zona.idEstadoCivil, zona.NombreEstadoCivil)
            Case TipoSP._D
               sql.SueldosEstadoCivil_D(zona.idEstadoCivil)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.SueldosEstadoCivil)
      With o
         .idEstadoCivil = Int32.Parse(dr("idEstadoCivil").ToString())
         If Not String.IsNullOrEmpty(dr("NombreEstadoCivil").ToString()) Then
            .NombreEstadoCivil = dr("NombreEstadoCivil").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.SueldosEstadoCivil)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.SueldosEstadoCivil
      Dim oLis As List(Of Entidades.SueldosEstadoCivil) = New List(Of Entidades.SueldosEstadoCivil)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosEstadoCivil()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(ByVal codigo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idEstadoCivil,")
         .Append("       NombreEstadoCivil")
         .Append("  FROM SueldosEstadoCivil")
         If Integer.Parse(codigo) > 0 Then
            .Append(" WHERE idEstadoCivil = " & codigo.ToString())
         End If
         .Append("	ORDER BY NombreEstadoCivil")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idEstadoCivil,")
         .Append("       NombreEstadoCivil")
         .Append("  FROM SueldosEstadoCivil")
         .Append("	WHERE NombreEstadoCivil LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreEstadoCivil")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetUno(ByVal idSueldosCategoria As String) As Entidades.SueldosEstadoCivil
      Dim qry As SqlServer.SueldosEstadoCivil = New SqlServer.SueldosEstadoCivil(Me.da)

      Dim dt As DataTable = qry.SueldosEstadoCivil_G1(idSueldosCategoria)
      Dim o As Entidades.SueldosEstadoCivil = New Entidades.SueldosEstadoCivil()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idEstadoCivil = dr.Field(Of Integer?)("idEstadoCivil").IfNull()
            .NombreEstadoCivil = dr("NombreEstadoCivil").ToString()
         End With
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.SueldosEstadoCivil(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class