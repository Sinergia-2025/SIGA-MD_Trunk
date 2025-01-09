Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports Eniac.Datos

#End Region

Public Class RecepcionNotasEstadosF
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "RecepcionNotasEstadosF"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         Dim nota As Entidades.RecepcionNotaEstadoF

         da.OpenConection()
         da.BeginTransaction()

         nota = DirectCast(entidad, Entidades.RecepcionNotaEstadoF)
         Me.EjecutaSP(nota, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT ")
         .Append(" IdSector ")
         .Append(", NombreSector ")
         .Append(", LetraSector ")
         .Append("FROM  ")
         .Append("Sectores ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

#End Region

#Region "Metodos Privados"

   Friend Sub EjecutaSP(ByVal nota As Entidades.RecepcionNotaEstadoF, ByVal tipo As TipoSP)

      Dim sql As SqlServer.RecepcionNotasEstadosF = New SqlServer.RecepcionNotasEstadosF(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.RecepcionNotasEstadosF_I(nota.IdSucursal, nota.Nota.NroNota, nota.Estado.IdEstado, nota.FechaEstado, nota.Observacion, nota.Usuario)
         Case TipoSP._U
         Case TipoSP._D

      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.RecepcionNotaEstadoF, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())

         'No se si vale la pena en una coleecion de su misma nota.. asignarlo...
         '.Nota = New Eniac.Service.Reglas.RecepcionNotasV().GetUno(Integer.Parse(dr("NroNota").ToString()))

         .Nota.NroNota = Integer.Parse(dr("NroNota").ToString())

         .FechaEstado = Date.Parse(dr("FechaEstado").ToString())
         .Observacion = dr("Observacion").ToString()

         .Estado = New Eniac.Reglas.RecepcionEstadosF().GetUno(Integer.Parse(dr("IdEstado").ToString()))
         'Hay que agregar el campo
         '.Usuario 
      End With

   End Sub

   Private Function GetUltimoNroNotaRecepcion() As Integer
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT max(NroNota) as Nro")
         .Append(" FROM RecepcionNotasF")
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Nro").ToString()) Then
            Return Integer.Parse(dt.Rows(0)("Nro").ToString())
         End If
      End If
      Return 0
   End Function

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.RecepcionNotaEstadoF)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.RecepcionNotaEstadoF
      Dim oLis As List(Of Entidades.RecepcionNotaEstadoF) = New List(Of Entidades.RecepcionNotaEstadoF)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.RecepcionNotaEstadoF()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   'Public Function GetUno(ByVal IdSucursal As Integer, _
   '                       ByVal NroNota As Integer) As Entidades.RecepcionNotaEstado

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT RNE.IdSucursal")
   '      .AppendLine("  ,RNE.NroNota")
   '      .AppendLine("  ,RNE.FechaEstado")
   '      .AppendLine("  ,RNE.IdEstado")
   '      .AppendLine("  ,RNE.Observacion")
   '      .AppendLine("  FROM RecepcionNotasEstadosF RNE")
   '      .AppendLine("  WHERE RNE.IdSucursal = " & IdSucursal.ToString())
   '      .AppendLine("    AND RNE.NroNota = " & NroNota.ToString())
   '      .AppendLine("  ORDER BY RNE.FechaEstado DESC")
   '   End With

   '   Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())

   '   Dim o As Entidades.RecepcionNotaEstado = New Entidades.RecepcionNotaEstado()
   '   If dt.Rows.Count > 0 Then
   '      Me.CargarUno(o, dt.Rows(0))
   '   Else
   '      Throw New Exception("No existe la Nota Estado.")
   '   End If
   '   Return o
   'End Function

   Public Function GetUna(ByVal IdSucursal As Integer, ByVal NroNota As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT RNE.NroNota")
         .AppendLine("      ,RNE.FechaEstado")
         .AppendLine("      ,RNE.IdEstado")
         .AppendLine("      ,RE.NombreEstado")
         .AppendLine("      ,RNE.Observacion")
         .AppendLine("      ,RNE.Usuario")
         .AppendLine("  FROM RecepcionNotasEstadosF RNE, RecepcionEstadosF RE")
         .AppendLine("  WHERE RNE.IdEstado = RE.IdEstado")
         .AppendLine("    AND RNE.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("    AND RNE.NroNota = " & NroNota.ToString())
         .AppendLine("  ORDER BY RNE.FechaEstado DESC")
      End With

      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())

      If dt.Rows.Count = 0 Then
         Throw New Exception("No existe la Nota Estado.")
      End If
      Return dt

   End Function

#End Region

End Class
