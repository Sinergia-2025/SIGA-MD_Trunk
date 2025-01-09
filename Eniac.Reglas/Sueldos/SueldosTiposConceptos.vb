'Option Strict Off
'#Region "Imports"

'Imports Eniac.Entidades
'Imports System.Text

'#End Region

Public Class SueldosTiposConceptos

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosTipoConcepto"
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
         .Length = 0
         .AppendLine("SELECT *")
         .AppendLine("  FROM SueldosTiposConceptos ")
         .AppendLine(" WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosTiposConceptos(Me.da).SueldosTiposConceptos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim zona As Entidades.SueldosTipoConcepto = DirectCast(entidad, Entidades.SueldosTipoConcepto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosTiposConceptos = New SqlServer.SueldosTiposConceptos(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosTiposConceptos_I(zona.idTipoConcepto, zona.NombreTipoConcepto, zona.Orden)
            Case TipoSP._U
               sql.SueldosTiposConceptos_U(zona.idTipoConcepto, zona.NombreTipoConcepto, zona.Orden)
            Case TipoSP._D
               sql.SueldosTiposConceptos_D(zona.idTipoConcepto)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.SueldosTipoConcepto)
      With o
         .idTipoConcepto = dr.Field(Of Integer)("idTipoConcepto")
         If Not String.IsNullOrEmpty(dr("NombreTipoConcepto").ToString()) Then
            .NombreTipoConcepto = dr("NombreTipoConcepto").ToString()
         End If
         .Orden = Integer.Parse(dr("Orden").ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.SueldosTipoConcepto)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.SueldosTipoConcepto
      Dim oLis As List(Of Entidades.SueldosTipoConcepto) = New List(Of Entidades.SueldosTipoConcepto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosTipoConcepto()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(ByVal codigo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idTipoConcepto,")
         .Append("       NombreTipoConcepto")
         .Append("     , Orden")
         .Append("  FROM SueldosTiposConceptos")
         If Integer.Parse(codigo) > 0 Then
            .Append(" WHERE idTipoConcepto = " & codigo.ToString())
         End If
         .Append("	ORDER BY NombreTipoConcepto")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idTipoConcepto,")
         .Append("       NombreTipoConcepto")
         .Append("     , Orden")
         .Append("  FROM SueldosTiposConceptos")
         .Append("	WHERE NombreTipoConcepto LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreTipoConcepto")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetUno(ByVal idSueldosCategoria As String) As Entidades.SueldosTipoConcepto
      Dim qry As SqlServer.SueldosTiposConceptos = New SqlServer.SueldosTiposConceptos(Me.da)

      Dim dt As DataTable = qry.SueldosTiposConceptos_G1(idSueldosCategoria)
      Dim o As Entidades.SueldosTipoConcepto = New Entidades.SueldosTipoConcepto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idTipoConcepto = dr.Field(Of Integer)("idTipoConcepto")
            .NombreTipoConcepto = dr("NombreTipoConcepto").ToString()
            .Orden = Integer.Parse(dr("Orden").ToString())
         End With
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.SueldosTiposConceptos(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class
