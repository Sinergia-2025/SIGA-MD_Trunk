Option Strict Off
Public Class TiposTimoneles
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposTimoneles"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposTimoneles"
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
      Dim sql As SqlServer.TiposTimoneles = New SqlServer.TiposTimoneles(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   'Public Overrides Function Buscar(ByVal entidad As Eniac.SiSeN.Entidades.Buscar) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   With stbQuery
   '      .Append("SELECT")
   '      .Append(" IdTipoTimonel")
   '      .Append(", NombreTipoTimonel ")
   '      .Append(" FROM  ")
   '      .Append("TiposTimoneles ")
   '      .Append("  WHERE ")
   '      .Append(entidad.Columna)
   '      .Append(" LIKE '%")
   '      .Append(entidad.Valor.ToString())
   '      .Append("%'")
   '   End With
   '   Return Me.da.GetDataTable(stbQuery.ToString())
   'End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposTimoneles(Me.da).TiposTimoneles_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdTipoTimonel) AS Maximo")
         .Append(" FROM TiposTimoneles")
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
         Dim en As Entidades.TipoTimonel = DirectCast(entidad, Entidades.TipoTimonel)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.TiposTimoneles = New SqlServer.TiposTimoneles(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.TiposTimoneles_I(en.IdTipoTimonel, en.NombreTipoTimonel, en.Prefijo)
            Case TipoSP._U
               sqlC.TiposTimoneles_U(en.IdTipoTimonel, en.NombreTipoTimonel, en.Prefijo)
            Case TipoSP._D
               sqlC.TiposTimoneles_D(en.IdTipoTimonel)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoTimonel, ByVal dr As DataRow)
      With o
         .IdTipoTimonel = Integer.Parse(dr(Entidades.TipoTimonel.Columnas.IdTipoTimonel.ToString()))
         .NombreTipoTimonel = dr(Entidades.TipoTimonel.Columnas.NombreTipoTimonel.ToString()).ToString()
         .Prefijo = dr(Entidades.TipoTimonel.Columnas.Prefijo.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idTipoTimonel As Integer) As Entidades.TipoTimonel
      Dim dt As DataTable = New SqlServer.TiposTimoneles(Me.da).TiposTimoneles_G1(idTipoTimonel)
      Dim o As Entidades.TipoTimonel = New Entidades.TipoTimonel()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Entidades.TipoTimonel)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.TipoTimonel
      Dim oLis As List(Of Entidades.TipoTimonel) = New List(Of Entidades.TipoTimonel)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoTimonel()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT T.IdTipoTimonel")
         .AppendLine("      ,T.NombreTipoTimonel")
         .AppendLine("      ,T.Prefijo")
         .AppendLine("  FROM TiposTimoneles T")
         .AppendLine(" WHERE T.NombreTipoTimonel = '" & nombre & "' ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function
#End Region

End Class
