Public Class SueldosTiposVinculoFamiliar
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosTiposVinculoFamiliar"
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
         .Append(" IdTipoVinculoFamiliar ")
         .Append(", NombreVinculoFamiliar ")
         .Append(" FROM  ")
         .Append("SueldosTiposVinculoFamiliar ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosTiposVinculoFamiliar(Me.da).SueldosTiposVinculoFamiliar_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim tipovinculo As Entidades.SueldosTiposVinculoFamiliar = DirectCast(entidad, Entidades.SueldosTiposVinculoFamiliar)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosTiposVinculoFamiliar = New SqlServer.SueldosTiposVinculoFamiliar(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosTiposVinculoFamiliar_I(tipovinculo.idTipoVinculoFamiliar, tipovinculo.NombreVinculoFamiliar)
            Case TipoSP._U
               sql.SueldosTiposVinculoFamiliar_U(tipovinculo.idTipoVinculoFamiliar, tipovinculo.NombreVinculoFamiliar)
            Case TipoSP._D
               sql.SueldosTiposVinculoFamiliar_D(tipovinculo.idTipoVinculoFamiliar)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.SueldosTiposVinculoFamiliar)
      With o
         .idTipoVinculoFamiliar = dr("IdTipoVinculoFamiliar").ToString()
         If Not String.IsNullOrEmpty(dr("NombreVinculoFamiliar").ToString()) Then
            .NombreVinculoFamiliar = dr("NombreVinculoFamiliar").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.SueldosTiposVinculoFamiliar)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.SueldosTiposVinculoFamiliar
      Dim oLis As List(Of Entidades.SueldosTiposVinculoFamiliar) = New List(Of Entidades.SueldosTiposVinculoFamiliar)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosTiposVinculoFamiliar()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(ByVal codigo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdTipoVinculoFamiliar,")
         .Append("       NombreVinculoFamiliar")
         .Append("  FROM SueldosTiposVinculoFamiliar")
         If Not String.IsNullOrWhiteSpace(codigo) Then
            .Append(" WHERE IdTipoVinculoFamiliar = " & codigo.ToString())
         End If
         .Append("	ORDER BY NombreVinculoFamiliar")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdTipoVinculoFamiliar,")
         .Append("       NombreVinculoFamiliar")
         .Append("  FROM SueldosTiposVinculoFamiliar")
         .Append("	WHERE NombreVinculoFamiliar LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreVinculoFamiliar")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetUno(ByVal idTipoVinculoFamiliar As String) As Entidades.SueldosTiposVinculoFamiliar
      Dim qry As SqlServer.SueldosTiposVinculoFamiliar = New SqlServer.SueldosTiposVinculoFamiliar(Me.da)

      Dim dt As DataTable = qry.SueldosTiposVinculoFamiliar_G1(idTipoVinculoFamiliar)
      Dim o As Entidades.SueldosTiposVinculoFamiliar = New Entidades.SueldosTiposVinculoFamiliar()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idTipoVinculoFamiliar = dr("IdTipoVinculoFamiliar").ToString()
            .NombreVinculoFamiliar = dr("NombreVinculoFamiliar").ToString()
         End With
      End If
      Return o
   End Function

#End Region

End Class