Option Strict On
Option Explicit On
Public Class RubrosComisionesPorDescuento
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RubroComisionPorDescuento.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Inserta(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Actualiza(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Borra(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region


#Region "Metodos Privados"
   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RubroComisionPorDescuento), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RubroComisionPorDescuento), TipoSP._U)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RubroComisionPorDescuento), TipoSP._D)
   End Sub
   Private Sub EjecutaSP(ByVal en As Entidades.RubroComisionPorDescuento, ByVal tipo As TipoSP)

      Dim sql As SqlServer.RubrosComisionesPorDescuento = New SqlServer.RubrosComisionesPorDescuento(da)
      Select Case tipo
         Case TipoSP._I
            sql.RubrosComisionesPorDescuento_I(en.IdRubro, en.DescuentoRecargoHasta, en.Comision)
         Case TipoSP._U
            sql.RubrosComisionesPorDescuento_U(en.IdRubro, en.DescuentoRecargoHasta, en.Comision)
         Case TipoSP._D
            sql.RubrosComisionesPorDescuento_D(en.IdRubro, en.DescuentoRecargoHasta)
      End Select
   End Sub
   Private Sub CargarUno(ByVal o As Entidades.RubroComisionPorDescuento, ByVal dr As DataRow)
      With o
         .IdRubro = Integer.Parse(dr(Entidades.RubroComisionPorDescuento.Columnas.IdRubro.ToString()).ToString())
         .DescuentoRecargoHasta = Decimal.Parse(dr(Entidades.RubroComisionPorDescuento.Columnas.DescuentoRecargoHasta.ToString()).ToString())
         .Comision = Decimal.Parse(dr(Entidades.RubroComisionPorDescuento.Columnas.Comision.ToString()).ToString())
      End With
   End Sub
#End Region
#Region "Metodos publicos"
   Public Function GetUno(idRubro As Integer, descuentoRecargoHasta As Decimal) As Entidades.RubroComisionPorDescuento
      Dim dt As DataTable = New SqlServer.RubrosComisionesPorDescuento(Me.da).RubrosComisionesPorDescuento_G1(idRubro, descuentoRecargoHasta)
      Dim o As Entidades.RubroComisionPorDescuento = New Entidades.RubroComisionPorDescuento()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function
   Public Function GetTodos(idRubro As Integer) As List(Of Entidades.RubroComisionPorDescuento)
      Return CargaLista(New SqlServer.RubrosComisionesPorDescuento(da).RubrosComisionesPorDescuento_GA(idRubro),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RubroComisionPorDescuento())
   End Function
   Public Sub InsertaDesdeRubro(entidad As Eniac.Entidades.Rubro)
      If entidad.RubroComisionPorDescuento IsNot Nothing Then
         For Each ent As Entidades.RubroComisionPorDescuento In entidad.RubroComisionPorDescuento
            ent.IdRubro = entidad.IdRubro
            Inserta(ent)
         Next
      End If
   End Sub
   Public Sub ActualizarDesdeRubro(entidad As Eniac.Entidades.Rubro)
      If entidad.RubroComisionPorDescuento IsNot Nothing Then
         BorraDesdeRubro(entidad)
         InsertaDesdeRubro(entidad)
      End If
   End Sub
   Public Sub BorraDesdeRubro(entidad As Eniac.Entidades.Rubro)
      Borra(New Entidades.RubroComisionPorDescuento() With {.IdRubro = entidad.IdRubro})
   End Sub
#End Region

End Class
