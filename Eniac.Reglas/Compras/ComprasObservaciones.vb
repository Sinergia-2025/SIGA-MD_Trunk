Option Explicit On
Option Strict On

Imports System.Text

Public Class ComprasObservaciones
   Inherits Eniac.Reglas.Base


#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ComprasObservaciones"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)

      Dim oVentasObserv As Entidades.CompraObservacion = DirectCast(entidad, Entidades.CompraObservacion)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(oVentasObserv, TipoSP._I)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos"

   Friend Sub EjecutaSP(ByVal ent As Entidades.CompraObservacion, ByVal tipo As TipoSP)
      Try

         Dim sql As SqlServer.ComprasObservaciones = New SqlServer.ComprasObservaciones(Me.da)

         Select Case tipo

            Case TipoSP._I

               sql.ComprasObservaciones_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.IdProveedor, ent.Linea, ent.Observacion)

               'Case TipoSP._U


            Case TipoSP._D

               sql.ComprasObservaciones_D(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.IdProveedor, 0)

         End Select

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Function GetUna(ByVal idSucursal As Integer, _
                          ByVal idTipoComprobante As String, _
                          ByVal letra As String, _
                          ByVal centroEmisor As Integer, _
                          ByVal numeroComprobante As Long, _
                          ByVal IdProveedor As Long, _
                          ByVal linea As Integer) As Entidades.CompraObservacion

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT VO.IdSucursal")
         .Append("      ,VO.IdTipoComprobante")
         .Append("      ,VO.Letra")
         .Append("      ,VO.CentroEmisor")
         .Append("      ,VO.NumeroComprobante")
         .Append("      ,VO.IdProveedor")
         .Append("      ,VO.Linea")
         .Append("      ,VO.Observacion")
         .Append("  FROM ComprasObservaciones VO")
         .Append(" WHERE VO.IdSucursal = " & idSucursal.ToString())
         .Append("   AND VO.IdTipoComprobante = '" & idTipoComprobante & "'")
         .Append("   AND VO.Letra = '" & letra & "'")
         .Append("   AND VO.CentroEmisor = " & centroEmisor.ToString())
         .Append("   AND VO.NumeroComprobante = " & numeroComprobante.ToString())
         .Append("   AND VO.IdProveedor = " & IdProveedor.ToString())
         .Append("   AND VO.Linea = " & linea.ToString())
      End With

      Dim dtObs As DataTable = Me.DataServer.GetDataTable(stb.ToString())
      Dim oCO As Entidades.CompraObservacion

      If dtObs.Rows.Count > 0 Then

         oCO = New Entidades.CompraObservacion()
         With oCO
            .IdSucursal = Int32.Parse(dtObs.Rows(0)("IdSucursal").ToString())
            .IdTipoComprobante = dtObs.Rows(0)("IdTipoComprobante").ToString()
            .Letra = dtObs.Rows(0)("Letra").ToString()
            .CentroEmisor = Short.Parse(dtObs.Rows(0)("CentroEmisor").ToString())
            .NumeroComprobante = Long.Parse(dtObs.Rows(0)("NumeroComprobante").ToString())
            .Proveedor = New Reglas.Proveedores().GetUno(Long.Parse(dtObs.Rows(0)("IdProveedor").ToString()))
            .Linea = Integer.Parse(dtObs.Rows(0)("Linea").ToString())
            .Observacion = dtObs.Rows(0)("Observacion").ToString()
         End With

      Else
         Throw New Exception("No existe este comprobante de Observaciones de Compra.")
      End If

      Return oCO

   End Function

#End Region

End Class
