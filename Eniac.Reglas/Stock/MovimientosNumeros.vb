Option Explicit On
Option Strict On

Imports System.Text

Public Class MovimientosNumeros
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "MovimientosNumeros"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "MovimientosNumeros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim o As Entidades.MovimientoNumero = DirectCast(entidad, Entidades.MovimientoNumero)

         Me.EjecutaSP(o, TipoSP._I)

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

         Me.EjecutaSP(DirectCast(entidad, Entidades.MovimientoNumero), TipoSP._U)

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

         Me.EjecutaSP(DirectCast(entidad, Entidades.MovimientoNumero), TipoSP._D)

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

   Private Sub EjecutaSP(ByVal o As Entidades.MovimientoNumero, ByVal tipo As TipoSP)

      Dim sql As SqlServer.MovimientosNumeros = New SqlServer.MovimientosNumeros(Me.da)
      sql.MovimientosNumeros_U(o.Sucursal.Id, o.TipoMovimiento.IdTipoMovimiento, o.Numero)

   End Sub

   Friend Sub ActualizarNumero(ByVal o As Entidades.MovimientoNumero)
      Try
         Me.EjecutaSP(o, TipoSP._U)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Friend Function GetUltimoNroMovimiento(ByVal idSucursal As Integer, ByVal idTipoMovimiento As String) As Integer
      Dim stb As StringBuilder = New StringBuilder("")
      If String.IsNullOrEmpty(idTipoMovimiento) Then
         Throw New Exception("No identifico el tipo de movimiento")
      End If
      With stb
         .Append("SELECT Numero")
         .Append("  FROM MovimientosNumeros")
         .Append("  WHERE IdSucursal =")
         .Append(idSucursal.ToString())
         .Append("AND IdTipoMovimiento = '")
         .Append(idTipoMovimiento)
         .Append("'")
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return Int32.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 0
      End If
   End Function


#End Region

End Class

