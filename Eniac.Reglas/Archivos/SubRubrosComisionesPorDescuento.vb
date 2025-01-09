Option Strict On
Option Explicit On
Public Class SubRubrosComisionesPorDescuento
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.SubRubroComisionPorDescuento.NombreTabla
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
      Me.EjecutaSP(DirectCast(entidad, Entidades.SubRubroComisionPorDescuento), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.SubRubroComisionPorDescuento), TipoSP._U)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.SubRubroComisionPorDescuento), TipoSP._D)
   End Sub
   Private Sub EjecutaSP(ByVal en As Entidades.SubRubroComisionPorDescuento, ByVal tipo As TipoSP)

      Dim sql As SqlServer.SubRubrosComisionesPorDescuento = New SqlServer.SubRubrosComisionesPorDescuento(da)
      Select Case tipo
         Case TipoSP._I
            sql.SubRubrosComisionesPorDescuento_I(en.IdSubRubro, en.DescuentoRecargoHasta, en.Comision)
         Case TipoSP._U
            sql.SubRubrosComisionesPorDescuento_U(en.IdSubRubro, en.DescuentoRecargoHasta, en.Comision)
         Case TipoSP._D
            sql.SubRubrosComisionesPorDescuento_D(en.IdSubRubro, en.DescuentoRecargoHasta)
      End Select
   End Sub
   Private Sub CargarUno(ByVal o As Entidades.SubRubroComisionPorDescuento, ByVal dr As DataRow)
      With o
         .IdSubRubro = Integer.Parse(dr(Entidades.SubRubroComisionPorDescuento.Columnas.IdSubRubro.ToString()).ToString())
         .DescuentoRecargoHasta = Decimal.Parse(dr(Entidades.SubRubroComisionPorDescuento.Columnas.DescuentoRecargoHasta.ToString()).ToString())
         .Comision = Decimal.Parse(dr(Entidades.SubRubroComisionPorDescuento.Columnas.Comision.ToString()).ToString())
      End With
   End Sub
#End Region
#Region "Metodos publicos"
   Public Function GetUno(idSubRubro As Integer, descuentoRecargoHasta As Decimal) As Entidades.SubRubroComisionPorDescuento
      Dim dt As DataTable = New SqlServer.SubRubrosComisionesPorDescuento(Me.da).SubRubrosComisionesPorDescuento_G1(idSubRubro, descuentoRecargoHasta)
      Dim o As Entidades.SubRubroComisionPorDescuento = New Entidades.SubRubroComisionPorDescuento()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function
   Public Function GetTodos(idSubRubro As Integer) As List(Of Entidades.SubRubroComisionPorDescuento)
      Return CargaLista(New SqlServer.SubRubrosComisionesPorDescuento(da).SubRubrosComisionesPorDescuento_GA(idSubRubro),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.SubRubroComisionPorDescuento())
   End Function

   Public Sub InsertaDesdeSubRubro(entidad As Eniac.Entidades.SubRubro)
      If entidad.SubRubroComisionPorDescuento IsNot Nothing Then
         For Each ent As Entidades.SubRubroComisionPorDescuento In entidad.SubRubroComisionPorDescuento
            ent.IdSubRubro = entidad.IdSubRubro
            Inserta(ent)
         Next
      End If
   End Sub
   Public Sub ActualizarDesdeSubRubro(entidad As Eniac.Entidades.SubRubro)
      If entidad.SubRubroComisionPorDescuento IsNot Nothing Then
         BorraDesdeSubRubro(entidad)
         InsertaDesdeSubRubro(entidad)
      End If
   End Sub
   Public Sub BorraDesdeSubRubro(entidad As Eniac.Entidades.SubRubro)
      Borra(New Entidades.SubRubroComisionPorDescuento() With {.IdSubRubro = entidad.IdSubRubro})
   End Sub
#End Region

End Class
