Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class FichasPagos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "FichasPagos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Friend"

   Friend Sub GrabaFichaPagos(ByVal ent As Eniac.Entidades.FichaPago)
      Dim sql As SqlServer.FichasPagos = New SqlServer.FichasPagos(Me.da)
      sql.FichasPagos_I(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, ent.NroCuota, ent.FechaVencimiento, ent.Importe, ent.Saldo)
   End Sub

   Friend Sub BorraFichaPagos(ByVal ent As Eniac.Entidades.FichaPago)
      Dim sql As SqlServer.FichasPagos = New SqlServer.FichasPagos(Me.da)
      sql.FichasPagos_D(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, ent.NroCuota)
   End Sub

   Friend Sub ActualizaSaldo(ByVal idSucursal As Integer, ByVal nroOperacion As Integer, ByVal IdCliente As Long, ByVal nrocuota As Integer, ByVal saldo As Decimal)
      Dim sql As SqlServer.FichasPagos = New SqlServer.FichasPagos(Me.da)
      sql.FichasPagos_USaldo(idSucursal, nroOperacion, IdCliente, nrocuota, saldo)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim ficha As Eniac.Entidades.FichaPago = DirectCast(entidad, Eniac.Entidades.FichaPago)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.GrabaFichaPagos(ficha)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.FichasPagos(Me.da).FichasPagos_GA()
   End Function

#End Region

#Region "Metodos Publicos"

   Public Function GetPagosPendientes(ByVal idSucursal As Integer, ByVal fechaDesde As DateTime, ByVal fechaHasta As DateTime, ByVal IdCobrador As Integer) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT FP.*, C.NombreCliente, C.Direccion, C.Telefono, C.Celular ")
         .Append(" FROM FichasPagos FP ")
         .Append(" LEFT JOIN Fichas F ON F.IdCliente = FP.IdCliente AND F.NroOperacion = FP.NroOperacion ")
         .Append(" LEFT JOIN Clientes C ON C.IdCliente = FP.IdCliente ")
         .Append(" WHERE FP.Saldo > 0 ")
         .Append(" AND F.IdSucursal = " & idSucursal)
         .Append(" AND F.IdEstado = 'ACTIVO' ")
         .Append(" AND FP.FechaVencimiento >= '")
         .Append(fechaDesde.ToString("yyyyMMdd") & " 00:00:00")
         .Append("' AND FP.FechaVencimiento <= '")
         .Append(fechaHasta.ToString("yyyyMMdd") & " 23:59:59")
         .Append("'")
         If IdCobrador > 0 Then
            .Append(" AND F.IdCobrador = ")
            .Append(IdCobrador)
         End If
         .Append(" ORDER BY C.NombreCliente, FP.NroOperacion, FP.FechaVencimiento ")
      End With
      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetPagosPendientesParaCarta(ByVal idSucursal As Integer, _
                                               ByVal fechaDesde As DateTime, _
                                               ByVal fechaHasta As DateTime, _
                                               ByVal IdCobrador As Integer, _
                                               ByVal IdCliente As Long, _
                                               ByVal nroOperacion As Integer) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Append("SELECT FP.*, C.NombreCliente, C.Direccion, C.Telefono, C.Celular, ")
         .Append(" (SELECT  MAX(P.NombreProducto) FROM FichasProductos FP ")
         .Append(" 	LEFT JOIN Productos P ON P.IdProducto = FP.IdProducto ")
         .Append(" 	WHERE FP.IdCliente = F.IdCliente ")
         .Append(" 	AND FP.IdSucursal = " & idSucursal & " ")
         .Append(" 	AND FP.NroOperacion = F.NroOperacion) Producto ")
         .Append(" FROM FichasPagos FP ")
         .Append(" LEFT JOIN Fichas F ON F.IdCliente = FP.IdCliente AND F.NroOperacion = FP.NroOperacion ")
         .Append(" LEFT JOIN Clientes C ON C.IdCliente = FP.IdCliente ")
         .Append(" WHERE FP.Saldo > 0 ")
         .Append(" AND F.IdSucursal = " & idSucursal)
         .Append(" AND F.IdEstado = 'ACTIVO' ")
         .Append(" AND FP.FechaVencimiento >= '")
         .Append(fechaDesde.ToString("yyyyMMdd") & " 00:00:00")
         .Append("' AND FP.FechaVencimiento <= '")
         .Append(fechaHasta.ToString("yyyyMMdd") & " 23:59:59")
         .Append("'")
         If IdCobrador > 0 Then
            .Append(" AND F.IdCobrador = ")
            .Append(IdCobrador)
         End If
         If IdCliente > 0 Then
            .Append(" AND FP.IdCliente = " & IdCliente.ToString())
         End If
         If nroOperacion <> 0 Then
            .Append(" AND FP.NroOperacion = ")
            .Append(nroOperacion)
            .Append("")
         End If
         .Append(" ORDER BY C.NombreCliente, FP.NroOperacion, FP.FechaVencimiento ")
      End With
      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

#End Region

End Class
