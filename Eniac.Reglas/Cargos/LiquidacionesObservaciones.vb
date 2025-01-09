Option Explicit On
Option Strict On

Imports System.Text
Public Class LiquidacionesObservaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "LiquidacionesObservaciones"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Protected Overridable Function GetSqlServer() As Eniac.SqlServer.LiquidacionesObservaciones
      Return New SqlServer.LiquidacionesObservaciones(da)
   End Function

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim observacion As Entidades.LiquidacionObservacion = DirectCast(entidad, Entidades.LiquidacionObservacion)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.LiquidacionesObservaciones = GetSqlServer()

         sql.LiquidacionesObservaciones_I(observacion)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim observacion As Entidades.LiquidacionObservacion = DirectCast(entidad, Entidades.LiquidacionObservacion)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.LiquidacionesObservaciones = GetSqlServer()

         sql.LiquidacionesObservaciones_D(observacion)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overloads Sub Borrar(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.LiquidacionesObservaciones = GetSqlServer()

         sql.LiquidacionesObservaciones_D(IdSucursal, IdTipoLiquidacion)

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
   Public Function GetUna(ByVal IdSucursal As Integer,
                          ByVal PeriodoLiquidacion As Integer,
                          ByVal IdLiquidacionCargo As Integer,
                          ByVal Linea As Integer,
                          ByVal IdTipoLiquidacion As Integer) As Entidades.LiquidacionObservacion

      Dim sql As SqlServer.LiquidacionesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.LiquidacionesObservaciones_G1(IdSucursal, PeriodoLiquidacion, IdLiquidacionCargo, Linea, IdTipoLiquidacion)

      Dim o As Entidades.LiquidacionObservacion = New Entidades.LiquidacionObservacion()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         o = Nothing
      End If

      Return o

   End Function

   Public Function GetPorSucursal(ByVal IdSucursal As Integer) As List(Of Entidades.LiquidacionObservacion)

      Dim sql As SqlServer.LiquidacionesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.LiquidacionesObservaciones_GA(IdSucursal)

      Dim lista As List(Of Entidades.LiquidacionObservacion) = New List(Of Entidades.LiquidacionObservacion)()

      Dim o As Entidades.LiquidacionObservacion
      If dt.Rows.Count > 0 Then
         For Each dr As DataRow In dt.Rows
            o = New Entidades.LiquidacionObservacion()
            Me.CargarUno(o, dr)
            lista.Add(o)
         Next
      Else
         o = Nothing
      End If

      Return lista

   End Function

   Public Function GetPorSucursal(ByVal IdSucursal As Integer, ByVal Periodo As Integer, ByVal IdTipoLiquidacion As Integer) As List(Of Entidades.LiquidacionObservacion)

      Dim sql As SqlServer.LiquidacionesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.LiquidacionesObservaciones_GA(IdSucursal, Periodo, IdTipoLiquidacion)

      Dim lista As List(Of Entidades.LiquidacionObservacion) = New List(Of Entidades.LiquidacionObservacion)()

      Dim o As Entidades.LiquidacionObservacion
      If dt.Rows.Count > 0 Then
         For Each dr As DataRow In dt.Rows
            o = New Entidades.LiquidacionObservacion()
            Me.CargarUno(o, dr)
            lista.Add(o)
         Next
      Else
         o = Nothing
      End If

      Return lista

   End Function

   Public Function GetPorSucursalEnDT(ByVal IdSucursal As Integer) As DataTable

      Dim sql As SqlServer.LiquidacionesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.LiquidacionesObservaciones_GA(IdSucursal)

      Return dt

   End Function

   Public Function GetPorSucursalConDatosCliente(ByVal IdSucursal As Integer, ByVal periodo As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable

      Dim sql As SqlServer.LiquidacionesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.LiquidacionesObservacionesConNombres_GA(IdSucursal, periodo, IdTipoLiquidacion)

      Return dt

   End Function

  

   'Public Function GetPorNombre(ByVal detalleObservacion As String, ByVal Tipo As String) As DataTable

   '   Try
   '      Me.da.OpenConection()

   '      Dim sql As SqlServer.LiquidacionesObservaciones = New SqlServer.LiquidacionesObservaciones(Me.da)

   '      Return sql.CargosClientesObservacion_GPorNombre(detalleObservacion, "CARGO")
   '   Catch ex As Exception
   '      Throw
   '   Finally
   '      Me.da.CloseConection()
   '   End Try

   'End Function
   Private Sub CargarUno(ByVal o As Entidades.LiquidacionObservacion, ByVal dr As DataRow)
      With o
         .IdSucursal = CInt(dr("IdSucursal"))
         .PeriodoLiquidacion = CInt(dr("PeriodoLiquidacion"))
         .IdCliente = CLng(dr("IdCliente"))
         '.IdLiquidacionCargo = CInt(dr("IdLiquidacionCargo"))
         .Linea = CInt(dr("Linea"))
         .Observacion = CStr(dr("Observacion"))
      End With
   End Sub
#End Region
End Class
