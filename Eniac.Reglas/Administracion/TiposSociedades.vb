Option Strict Off
Public Class TiposSociedades
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposSociedades"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposSociedades"
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
      Dim sql As SqlServer.TiposSociedades = New SqlServer.TiposSociedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   'Public Overrides Function Buscar(ByVal entidad As Eniac.SiSeN.Entidades.Buscar) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   With stbQuery
   '      .Append("SELECT")
   '      .Append(" IdTipoSociedad")
   '      .Append(", NombreTipoSociedad ")
   '      .Append(" FROM  ")
   '      .Append("TiposSociedades ")
   '      .Append("  WHERE ")
   '      .Append(entidad.Columna)
   '      .Append(" LIKE '%")
   '      .Append(entidad.Valor.ToString())
   '      .Append("%'")
   '   End With
   '   Return Me.da.GetDataTable(stbQuery.ToString())
   'End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposSociedades(Me.da).TiposSociedades_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdTipoSociedad) AS Maximo")
         .Append(" FROM TiposSociedades")
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
         Dim en As Eniac.Entidades.TipoSociedad = DirectCast(entidad, Eniac.Entidades.TipoSociedad)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.TiposSociedades = New SqlServer.TiposSociedades(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.TiposSociedades_I(en.IdTipoSociedad, en.NombreTipoSociedad)
            Case TipoSP._U
               sqlC.TiposSociedades_U(en.IdTipoSociedad, en.NombreTipoSociedad)
            Case TipoSP._D
               sqlC.TiposSociedades_D(en.IdTipoSociedad)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoSociedad, ByVal dr As DataRow)
      With o
         .IdTipoSociedad = Integer.Parse(dr(Entidades.TipoSociedad.Columnas.IdTipoSociedad.ToString()))
         .NombreTipoSociedad = dr(Entidades.TipoSociedad.Columnas.NombreTipoSociedad.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idTipoSociedad As Integer) As Eniac.Entidades.TipoSociedad
      Dim dt As DataTable = New SqlServer.TiposSociedades(Me.da).TiposSociedades_G1(idTipoSociedad)
      Dim o As Eniac.Entidades.TipoSociedad = New Eniac.Entidades.TipoSociedad()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Eniac.Entidades.TipoSociedad)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Eniac.Entidades.TipoSociedad
      Dim oLis As List(Of Eniac.Entidades.TipoSociedad) = New List(Of Eniac.Entidades.TipoSociedad)
      For Each dr As DataRow In dt.Rows
         o = New Eniac.Entidades.TipoSociedad()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdTipoSociedad")
         .AppendLine("      ,NombreTipoSociedad")
         .AppendLine("  FROM TiposSociedades ")
         .AppendLine(" WHERE NombreTipoSociedad = '" & nombre & "' ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

#End Region

End Class
