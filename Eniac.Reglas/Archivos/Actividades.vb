Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class Actividades
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Actividades"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Actividades"
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
         .AppendLine("SELECT  ")
         .AppendLine(" A.IdProvincia, ")
         .AppendLine(" P.NombreProvincia,")
         .AppendLine(" A.IdActividad, ")
         .AppendLine(" A.NombreActividad, ")
         .AppendLine(" A.Porcentaje, ")
         .AppendLine(" A.BaseImponible ")
         .AppendLine(" FROM Actividades A ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = A.IdProvincia")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Actividades(Me.da).Actividades_GA()
   End Function

   Public Function GetPorNombre(ByVal nombre As String, ByVal provincia As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT  ")
         .AppendLine(" A.IdProvincia, ")
         .AppendLine(" P.NombreProvincia,")
         .AppendLine(" A.IdActividad, ")
         .AppendLine(" A.NombreActividad, ")
         .AppendLine(" A.Porcentaje, ")
         .AppendLine(" A.BaseImponible")
         .AppendLine("FROM Actividades A ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = A.IdProvincia")
         .Append("	WHERE NombreActividad LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .AppendLine(" AND P.IdProvincia = '" & provincia & "'")
         .Append("	ORDER BY NombreActividad")
      End With

      Return Me.da.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorProvincia(ByVal idProvincia As String) As DataTable
      'Try
      '   Me.da.OpenConection()

      '   Dim sql As SqlServer.Actividades = New SqlServer.Actividades(Me.da)



      'Catch ex As Exception
      '   Throw
      'Finally
      '   Me.da.CloseConection()
      'End Try
      Return Me.GetPorNombre("", idProvincia)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim acti As Entidades.Actividad = DirectCast(entidad, Entidades.Actividad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.Actividades = New SqlServer.Actividades(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.Actividades_I(acti.IdProvincia, acti.IdActividad, acti.NombreActividad,
                                 acti.Porcentaje, acti.BaseImponible, acti.CodigoAfip)
            Case TipoSP._U
               sqlC.Actividades_U(acti.IdProvincia, acti.IdActividad, acti.NombreActividad,
                                  acti.Porcentaje, acti.BaseImponible, acti.CodigoAfip)
            Case TipoSP._D
               sqlC.Actividades_D(acti.IdProvincia, acti.IdActividad)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   'Private Function GetPorId(ByVal idProvincia As String, ByVal idActividad As Integer) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   With stbQuery
   '      .Append("SELECT IdProvincia")
   '      .Append("      ,IdActividad")
   '      .Append("      ,NombreActividad")
   '      .Append("      ,Porcentaje")
   '      .Append("      ,BaseImponible")
   '      .Append("  FROM Actividades")
   '      .AppendFormat("  WHERE IdProvincia = '{0}' ", idProvincia)
   '      .AppendFormat("  AND IdActividad = {0}", idActividad)
   '   End With
   '   Return Me.da.GetDataSet(stbQuery.ToString()).Tables(0)
   'End Function

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idProvincia As String, ByVal idActividad As Integer) As Entidades.Actividad
      Dim dt As DataTable = New SqlServer.Actividades(da).Actividades_GPorID(idProvincia, idActividad)
      Dim o As Entidades.Actividad = New Entidades.Actividad()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .IdProvincia = dr("IdProvincia").ToString()
            .IdActividad = Integer.Parse(dr("IdActividad").ToString())
            .NombreActividad = dr("NombreActividad").ToString()
            .Porcentaje = Decimal.Parse(dr("Porcentaje").ToString())
            If Not String.IsNullOrEmpty(dr("BaseImponible").ToString()) Then
               .BaseImponible = Decimal.Parse(dr("BaseImponible").ToString())
            End If
            If Not String.IsNullOrEmpty(dr("CodigoAfip").ToString()) Then
               .CodigoAfip = Integer.Parse(dr("CodigoAfip").ToString())
            End If
         End With
      End If
      Return o
   End Function

   Public Function GetIdMaximo(ByVal idProvincia As String) As Integer
      Dim sql As SqlServer.Actividades = New SqlServer.Actividades(Me.da)
      Dim dt As DataTable = sql.Actividades_GetIdMaximo(idProvincia)
      Dim val As Integer = 0
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If
      Return val
   End Function

#End Region

End Class

