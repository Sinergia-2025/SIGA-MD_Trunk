#Region "Imports"

Imports Eniac.Entidades
Imports System.Text

#End Region

Public Class PlantillasListasControl

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
      Dim sql As SqlServer.PlantillasCalidad = New SqlServer.PlantillasCalidad(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.PlantillasCalidad(Me.da).CalidadPlantillas_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim pla As Entidades.PlantillaListaControl = DirectCast(entidad, Entidades.PlantillaListaControl)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.PlantillasCalidad = New SqlServer.PlantillasCalidad(Me.da)
         Dim sql2 As SqlServer.PlantillasListasControl = New SqlServer.PlantillasListasControl(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.CalidadPlantillas_I(pla.IdPlantillaCalidad, pla.NombrePlantillaCalidad)
               For Each dr As DataRow In pla.ListasControl.Rows
                  sql2.CalidadPlantillasListasControl_I(pla.IdPlantillaCalidad, Integer.Parse(dr("IdListaControl").ToString()))
               Next

            Case TipoSP._U
               sql.CalidadPlantillas_U(pla.IdPlantillaCalidad, pla.NombrePlantillaCalidad)
               sql2.CalidadPlantillasListasControl_D(pla.IdPlantillaCalidad.ToString())
               For Each dr As DataRow In pla.ListasControl.Rows
                  sql2.CalidadPlantillasListasControl_I(pla.IdPlantillaCalidad, Integer.Parse(dr("IdListaControl").ToString()))
               Next

            Case TipoSP._D
               sql2.CalidadPlantillasListasControl_D(pla.IdPlantillaCalidad.ToString())
               sql.CalidadPlantillas_D(pla.IdPlantillaCalidad)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub


#End Region

#Region "Metodos Publicos"

   Public Function GetUno(ByVal idPlantilla As Integer) As Entidades.PlantillaListaControl
      Dim qry As SqlServer.PlantillasCalidad = New SqlServer.PlantillasCalidad(Me.da)

      Dim dt As DataTable = qry.CalidadPlantillas_G1(idPlantilla)
      Dim o As Entidades.PlantillaListaControl = New Entidades.PlantillaListaControl()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .IdPlantillaCalidad = Integer.Parse(dr("IdPlantillaCalidad").ToString())
            .NombrePlantillaCalidad = dr("NombrePlantillaCalidad").ToString()
            .ListasControl = New Reglas.PlantillasListasControl().GetListasControlPlantilla(.IdPlantillaCalidad)
         End With
      End If
      Return o
   End Function
   Public Function GetCampos() As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT IdPlantillaCalidad,  CPLC.IdListaControl, ")
         .AppendLine(" CLC.NombreListaControl ")
         .AppendLine("  FROM CalidadPlantillasListasControl CPLC ")
         .AppendLine(" INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CPLC.IdListaControl")
         .AppendLine(" 	ORDER BY  CPLC.IdListaControl")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetListasControlPlantilla(ByVal IdPlantilla As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
          .AppendLine("SELECT IdPlantillaCalidad,  CPLC.IdListaControl, ")
         .AppendLine(" CLC.NombreListaControl ")
         .AppendLine("  FROM CalidadPlantillasListasControl CPLC ")
         .AppendLine(" INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CPLC.IdListaControl")
         .AppendLine(" WHERE CPLC.IdPlantillaCalidad = " & IdPlantilla)
         .AppendLine("	ORDER BY  CPLC.IdListaControl")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetProximoId() As Integer
      Try
         Me.da.OpenConection()

         Return New SqlServer.PlantillasCalidad(Me.da).GetProximoId()

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

   Public Function GetFiltradoPorNombre(ByVal NombrePlantilla As String) As DataTable
      Return New SqlServer.Plantillas(da).GetFiltradoPorNombre(NombrePlantilla)
   End Function
#End Region

End Class
