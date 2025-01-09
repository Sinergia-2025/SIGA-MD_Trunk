Option Explicit On
Option Strict On

Imports System.Text

Public Class VentasObservaciones
   Inherits Eniac.Reglas.Base


#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "VentasObservaciones"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)

      Dim oVentasObserv As Entidades.VentaObservacion = DirectCast(entidad, Entidades.VentaObservacion)

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

   Friend Sub EjecutaSP(ByVal ent As Entidades.VentaObservacion, ByVal tipo As TipoSP)
      Try

         Dim sql As SqlServer.VentasObservaciones = New SqlServer.VentasObservaciones(Me.da)

         Select Case tipo

            Case TipoSP._I

               sql.VentasObservaciones_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Linea, ent.Observacion, ent.IdTipoObservacion)

               'Case TipoSP._U


            Case TipoSP._D

               sql.VentasObservaciones_D(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, 0)

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
                          ByVal linea As Integer) As Entidades.VentaObservacion

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT VO.IdSucursal")
         .Append("      ,VO.IdTipoComprobante")
         .Append("      ,VO.Letra")
         .Append("      ,VO.CentroEmisor")
         .Append("      ,VO.NumeroComprobante")
         .Append("      ,VO.Linea")
         .Append("      ,VO.Observacion")
         .Append("      ,VO.IdTipoObservacion")
         .Append("      ,TOB.Descripcion")
         .Append("  FROM VentasObservaciones VO")
         .Append("  INNER JOIN TiposObservaciones TOB ON VO.IDTipoObservacion = TOB.IdObservaciones ")
         .Append(" WHERE VO.IdSucursal = " & idSucursal.ToString())
         .Append("   AND VO.IdTipoComprobante = '" & idTipoComprobante & "'")
         .Append("   AND VO.Letra = '" & letra & "'")
         .Append("   AND VO.CentroEmisor = " & centroEmisor.ToString())
         .Append("   AND VO.NumeroComprobante = " & numeroComprobante.ToString())
         .Append("   AND VO.Linea = " & linea.ToString())
      End With

      Dim dtObs As DataTable = Me.DataServer.GetDataTable(stb.ToString())
      Dim oVO As Entidades.VentaObservacion

      If dtObs.Rows.Count > 0 Then

         oVO = New Entidades.VentaObservacion()
         With oVO
            .IdSucursal = Int32.Parse(dtObs.Rows(0)("IdSucursal").ToString())
            .IdTipoComprobante = dtObs.Rows(0)("IdTipoComprobante").ToString()
            .Letra = dtObs.Rows(0)("Letra").ToString()
            .CentroEmisor = Short.Parse(dtObs.Rows(0)("CentroEmisor").ToString())
            .NumeroComprobante = Long.Parse(dtObs.Rows(0)("NumeroComprobante").ToString())
            .Linea = Integer.Parse(dtObs.Rows(0)("Linea").ToString())
            .Observacion = dtObs.Rows(0)("Observacion").ToString()
            .IdTipoObservacion = Short.Parse(dtObs.Rows(0)("IdTipoObservacion").ToString())
            .DescripcionTipoObservacion = dtObs.Rows(0)("Descripcion").ToString()
         End With

      Else
         Throw New Exception("No existe este comprobante de Observaciones de Venta.")
      End If

      Return oVO

   End Function

#End Region

End Class
