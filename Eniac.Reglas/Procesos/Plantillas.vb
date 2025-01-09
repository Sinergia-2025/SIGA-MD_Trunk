#Region "Imports"

Imports Eniac.Entidades
Imports System.Text

#End Region

Public Class Plantillas

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Plantillas"
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
      Dim sql As SqlServer.Plantillas = New SqlServer.Plantillas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Plantillas(Me.da).Plantillas_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim pla As Entidades.Plantilla = DirectCast(entidad, Entidades.Plantilla)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Plantillas = New SqlServer.Plantillas(Me.da)
         Dim sql2 As SqlServer.PlantillasCampos = New SqlServer.PlantillasCampos(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.Plantillas_I(pla.IdPlantilla, pla.NombrePlantilla, pla.Proveedor.IdProveedor, pla.FilaInicial, pla.Sistema)
               For Each dr As DataRow In pla.Campos.Rows
                  If String.IsNullOrEmpty(dr("OrdenColumna").ToString()) Then
                     sql2.PlantillasCampos_I(pla.IdPlantilla, Integer.Parse(dr("IdCampo").ToString()), 0)
                  Else
                     sql2.PlantillasCampos_I(pla.IdPlantilla, Integer.Parse(dr("IdCampo").ToString()), Integer.Parse(dr("OrdenColumna").ToString()))
                  End If

               Next

            Case TipoSP._U
               sql.Plantillas_U(pla.IdPlantilla, pla.NombrePlantilla, pla.Proveedor.IdProveedor, pla.FilaInicial, pla.Sistema)
               sql2.PlantillasCampos_D(pla.IdPlantilla.ToString())
               For Each dr As DataRow In pla.Campos.Rows
                  If String.IsNullOrEmpty(dr("OrdenColumna").ToString()) Then
                     sql2.PlantillasCampos_I(pla.IdPlantilla, Integer.Parse(dr("IdCampo").ToString()), 0)
                  Else
                     sql2.PlantillasCampos_I(pla.IdPlantilla, Integer.Parse(dr("IdCampo").ToString()), Integer.Parse(dr("OrdenColumna").ToString()))
                  End If
               Next

            Case TipoSP._D
               sql2.PlantillasCampos_D(pla.IdPlantilla.ToString())
               sql.Plantillas_D(pla.IdPlantilla)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   'Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
   '   Dim zona As Entidades.ZonaGeografica = DirectCast(entidad, Entidades.ZonaGeografica)
   '   Dim sql As SqlServer.ZonaGeografica = New SqlServer.ZonaGeografica(Me.da)
   '   sql.ZonaGeografica_I(zona.IdZonaGeografica, zona.NombreZonaGeografica)
   'End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.ZonaGeografica)
      With o
         .IdZonaGeografica = dr("IdZonaGeografica").ToString()
         If Not String.IsNullOrEmpty(dr("NombreZonaGeografica").ToString()) Then
            .NombreZonaGeografica = dr("NombreZonaGeografica").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.ZonaGeografica)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ZonaGeografica
      Dim oLis As List(Of Entidades.ZonaGeografica) = New List(Of Entidades.ZonaGeografica)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ZonaGeografica()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   'Public Function GetPorCodigo(ByVal codigo As Integer) As DataTable

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Append("SELECT IdZonaGeografica,")
   '      .Append("       NombreZonaGeografica")
   '      .Append("  FROM ZonasGeograficas")
   '      If codigo > 0 Then
   '         .Append(" WHERE IdZonaGeografica = " & codigo.ToString())
   '      End If
   '      .Append("	ORDER BY NombreZonaGeografica")
   '   End With

   '   Return Me.DataServer.GetDataTable(stb.ToString())

   'End Function

   'Public Function GetPorNombre(ByVal nombre As String) As DataTable

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Append("SELECT IdZonaGeografica,")
   '      .Append("       NombreZonaGeografica")
   '      .Append("  FROM ZonasGeograficas")
   '      .Append("	WHERE NombreZonaGeografica LIKE '%")
   '      .Append(nombre)
   '      .Append("%' ")
   '      .Append("	ORDER BY NombreZonaGeografica")
   '   End With

   '   Return Me.DataServer.GetDataTable(stb.ToString())

   'End Function

   Public Function GetUno(ByVal idPlantilla As Integer) As Entidades.Plantilla
      Dim qry As SqlServer.Plantillas = New SqlServer.Plantillas(Me.da)

      Dim dt As DataTable = qry.Plantillas_G1(idPlantilla)
      Dim o As Entidades.Plantilla = New Entidades.Plantilla()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .IdPlantilla = Integer.Parse(dr("IdPlantilla").ToString())
            .NombrePlantilla = dr("NombrePlantilla").ToString()
            If Not String.IsNullOrEmpty(dr("IdProveedor").ToString()) Then
               .Proveedor = New Reglas.Proveedores().GetUno(Long.Parse(dr("IdProveedor").ToString()))
            End If
            .FilaInicial = Integer.Parse(dr("FilaInicial").ToString())
            .Sistema = Boolean.Parse(dr("Sistema").ToString())
            .Campos = New Reglas.Plantillas().GetCamposPlantilla(.IdPlantilla)
         End With
      End If
      Return o
   End Function
   'Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT IdZonaGeografica,")
   '      .AppendLine("       NombreZonaGeografica")
   '      .AppendLine("  FROM ZonasGeograficas")
   '      .AppendLine(" WHERE NombreZonaGeografica = '" & nombre & "' ")
   '   End With

   '   Return Me.da.GetDataTable(stb.ToString())

   'End Function

   Public Function GetCampos() As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT IdCampo,")
         .AppendLine("       NombreCampo,")
         .AppendLine("       Orden, ")
         .AppendLine("       '' AS OrdenColumna")
         .AppendLine("  FROM Campos")
         .AppendLine("	ORDER BY  Orden")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetCamposPlantilla(ByVal IdPlantilla As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT PC.IdCampo,")
         .AppendLine("       C.NombreCampo,")
         .AppendLine("       C.Orden, ")
         .AppendLine("       PC.OrdenColumna")
         .AppendLine("  FROM PlantillasCampos PC")
         .AppendLine("INNER JOIN Campos C ON C.IdCampo = PC.IdCampo")
         .AppendLine(" WHERE PC.IdPlantilla = " & IdPlantilla)
         .AppendLine("	ORDER BY  C.Orden")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetProximoId() As Integer
      Try
         Me.da.OpenConection()

         Return New SqlServer.Plantillas(Me.da).GetProximoId()

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetFiltradoPorCodigo(codigoPlantilla As Long) As DataTable
      Dim sql As SqlServer.Plantillas = New SqlServer.Plantillas(da)
      Dim dt As DataTable = sql.GetFiltradoPorCodigo(codigoPlantilla)
      Return dt
   End Function

   Public Function GetFiltradoPorProveedor(IdProveedor As Long) As DataTable
      Dim sql As SqlServer.Plantillas = New SqlServer.Plantillas(da)
      Dim dt As DataTable = sql.GetFiltradoPorProveedor(IdProveedor)
      Return dt
   End Function

   Public Function GetFiltradoPorNombre(ByVal NombrePlantilla As String) As DataTable
      Return New SqlServer.Plantillas(da).GetFiltradoPorNombre(NombrePlantilla)
   End Function
#End Region

End Class
