Option Explicit On
Option Strict On

Imports System.Text
Public Class CargosClientesObservaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CargosClientesObservaciones"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Protected Overridable Function GetSqlServer() As Eniac.SqlServer.CargosClientesObservaciones
      Return New SqlServer.CargosClientesObservaciones(da)
   End Function

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Inserta(DirectCast(entidad, Entidades.CargoClienteObservacion))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Actualiza(DirectCast(entidad, Entidades.CargoClienteObservacion))
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
         Borra(DirectCast(entidad, Entidades.CargoClienteObservacion))
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overloads Sub Borrar(idSucursal As Integer, idTipoLiquidacion As Integer)

      Try
         da.OpenConection()
         da.BeginTransaction()

         _Borrar(IdSucursal, IdTipoLiquidacion)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overloads Sub Borrar(idSucursal As Integer, idTipoLiquidacion As Integer, idCliente As Long)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.CargosClientesObservaciones = GetSqlServer()

         sql.CargosClientesObservaciones_D(idSucursal, idTipoLiquidacion, idCliente)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overloads Sub _Borrar(idSucursal As Integer, idTipoLiquidacion As Integer)
      Dim sql As SqlServer.CargosClientesObservaciones = GetSqlServer()
      sql.CargosClientesObservaciones_D(idSucursal, idTipoLiquidacion)
   End Sub
   Public Overloads Sub _Borrar(idSucursal As Integer, idTipoLiquidacion As Integer, idCliente As Long,
                                idCategoria As Integer, idZonaGeografica As String, idCobrador As Integer, filtroPcs As String, cantidadPcs As Integer)
      Dim sql As SqlServer.CargosClientesObservaciones = GetSqlServer()
      sql.CargosClientesObservaciones_D(idSucursal, idTipoLiquidacion, idCliente, idCategoria, idZonaGeografica, idCobrador, filtroPcs, cantidadPcs)
   End Sub
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(ByVal en As Entidades.CargoClienteObservacion, ByVal tipo As TipoSP)

      Dim sql As SqlServer.CargosClientesObservaciones = GetSqlServer()
      Select Case tipo
         Case TipoSP._I
            sql.CargosClientesObservaciones_I(en.IdSucursal, en.IdCliente, en.Linea, en.Observacion, en.IdTipoLiquidacion)
         Case TipoSP._U
            sql.CargosClientesObservaciones_U(en.IdSucursal, en.IdCliente, en.Linea, en.Observacion, en.IdTipoLiquidacion)
         Case TipoSP._D
            sql.CargosClientesObservaciones_D(en.IdSucursal, en.IdCliente, en.Linea, en.IdTipoLiquidacion)
      End Select

   End Sub
#End Region

#Region "Metodos"
   Public Sub Inserta(ByVal entidad As Eniac.Entidades.CargoClienteObservacion)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.CargoClienteObservacion)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.CargoClienteObservacion)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub



   Public Function GetUna(ByVal IdSucursal As Integer,
                          ByVal IdCliente As Long,
                          ByVal Linea As Integer) As Entidades.CargoClienteObservacion

      Dim sql As SqlServer.CargosClientesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.CargosClientesObservacion_G1(IdSucursal, IdCliente, Linea)

      Dim o As Entidades.CargoClienteObservacion = New Entidades.CargoClienteObservacion()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         o = Nothing
      End If

      Return o

   End Function

   Public Function GetPorSucursal(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As List(Of Entidades.CargoClienteObservacion)

      Dim sql As SqlServer.CargosClientesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.CargosClientesObservacion_GA(IdSucursal, IdTipoLiquidacion)

      Dim lista As List(Of Entidades.CargoClienteObservacion) = New List(Of Entidades.CargoClienteObservacion)()

      Dim o As Entidades.CargoClienteObservacion
      If dt.Rows.Count > 0 Then
         For Each dr As DataRow In dt.Rows
            o = New Entidades.CargoClienteObservacion()
            Me.CargarUno(o, dr)
            lista.Add(o)
         Next
      Else
         o = Nothing
      End If

      Return lista

   End Function

   Public Function GetPorSucursalEnDT(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable

      Dim sql As SqlServer.CargosClientesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.CargosClientesObservacion_GA(IdSucursal, IdTipoLiquidacion)

      Return dt

   End Function

   Public Function GetPorSucursalConDatosCliente(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable

      Dim sql As SqlServer.CargosClientesObservaciones = GetSqlServer()

      Dim dt As DataTable = sql.CargosClientesObservacionConNombres_GA(IdSucursal, IdTipoLiquidacion)
      Return dt

   End Function

   Private Sub CargarUno(ByVal o As Entidades.CargoClienteObservacion, ByVal dr As DataRow)
      With o
         .IdSucursal = CInt(dr("IdSucursal"))
         .IdCliente = CLng(dr("IdCliente"))
         .Linea = CInt(dr("Linea"))
         .Observacion = CStr(dr("Observacion"))
         .IdTipoLiquidacion = CInt(dr("IdTipoLiquidacion"))
      End With
   End Sub
#End Region
End Class