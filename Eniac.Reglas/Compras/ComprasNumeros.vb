Option Explicit On
Option Strict On

Imports System.Text

Public Class ComprasNumeros
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ComprasNumeros"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ComprasNumeros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(DirectCast(entidad, Entidades.CompraNumero), TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(DirectCast(entidad, Entidades.CompraNumero), TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(DirectCast(entidad, Entidades.CompraNumero), TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal vn As Entidades.CompraNumero, ByVal tipo As TipoSP)

      Dim sql As SqlServer.ComprasNumeros = New SqlServer.ComprasNumeros(Me.da)
      Select Case tipo
         Case TipoSP._I
         Case TipoSP._U
            sql.ComprasNumeros_U(vn.IdSucursal, vn.IdTipoComprobante, vn.LetraFiscal, vn.CentroEmisor, vn.Numero)
         Case TipoSP._D
      End Select

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetProximoNumero(ByVal IdSucursal As Integer, _
                                    ByVal idTipoComprobante As String, _
                                    ByVal letraFiscal As String, _
                                    ByVal emisor As Integer) As Long

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Append("SELECT (Numero + 1) Numero ")
         .Append(" FROM ComprasNumeros")
         .Append(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .Append(" AND LetraFiscal = '" & letraFiscal & "'")
         .Append(" AND CentroEmisor = " & emisor.ToString())
         .Append(" AND IdSucursal = " & IdSucursal.ToString())
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return Long.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 1
      End If

   End Function

   Public Sub ActualizarNumero(ByVal vn As Entidades.CompraNumero)
      Try
         Me.EjecutaSP(vn, TipoSP._U)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Function GetLetrasFiscales() As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine(" SELECT DISTINCT LetraFiscal FROM ComprasNumeros ")
      End With

      Return Me.DataServer().GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetCentrosEmisores() As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT DISTINCT CentroEmisor FROM ComprasNumeros")
      End With

      Return Me.DataServer().GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetUltimoNumero(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Long
      Return GetUltimoNumero(idSucursal, actual.Sucursal.IdEmpresa, idTipoComprobante, letraFiscal, emisor)
   End Function

   Public Function GetUltimoNumero(idSucursal As Integer, idEmpresa As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short) As Long
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT Numero ")
         .AppendLine("  FROM ComprasNumeros")
         .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND LetraFiscal = '" & letraFiscal & "'")
         .AppendLine("   AND CentroEmisor = " & emisor.ToString())
         ' .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
         .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
      End With

      Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return Long.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 0
      End If
   End Function

   Public Function GetPagoAnterior(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letraFiscal As String,
                                   emisor As Short,
                                   numero As Long) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .AppendLine(" SELECT top 1 Fecha, NumeroComprobante ")
         .AppendLine("  FROM CuentasCorrientesProv")
         .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letraFiscal & "'")
         .AppendLine("   AND CentroEmisor = " & emisor.ToString())
         If idSucursal > 0 Then
            .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
         End If
         .AppendLine("   AND NumeroComprobante < " & numero.ToString())
         .AppendLine("   ORDER BY NumeroComprobante desc ")
      End With

      Return da.GetDataTable(stbQuery.ToString())
   End Function
#End Region

End Class

