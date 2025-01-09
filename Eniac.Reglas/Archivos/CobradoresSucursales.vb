Option Strict On
Option Explicit On
Public Class CobradoresSucursales
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CobradorSucursal.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Inserta(entidad)
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
         Actualiza(entidad)
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
         Borra(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CobradoresSucursales = New SqlServer.CobradoresSucursales(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CobradoresSucursales(Me.da).CobradoresSucursales_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.CobradorSucursal = DirectCast(entidad, Entidades.CobradorSucursal)
      Dim sqlC As SqlServer.CobradoresSucursales = New SqlServer.CobradoresSucursales(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CobradoresSucursales_I(en.IdSucursal, en.IdCobrador, en.IdCaja, en.Observacion)
         Case TipoSP._U
            sqlC.CobradoresSucursales_U(en.IdSucursal, en.IdCobrador, en.IdCaja, en.Observacion)
         Case TipoSP._D
            sqlC.CobradoresSucursales_D(en.IdSucursal, en.IdCobrador)
         Case TipoSP._M
            sqlC.CobradoresSucursales_M(en.IdSucursal, en.IdCobrador, en.IdCaja, en.Observacion)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CobradorSucursal, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.CobradorSucursal.Columnas.IdSucursal.ToString()).ToString())
         .IdCobrador = Integer.Parse(dr(Entidades.CobradorSucursal.Columnas.IdCobrador.ToString()).ToString())

         If IsNumeric(dr(Entidades.CobradorSucursal.Columnas.IdCaja.ToString())) Then
            .IdCaja = Integer.Parse(dr(Entidades.CobradorSucursal.Columnas.IdCaja.ToString()).ToString())
         End If
         .Observacion = dr(Entidades.CobradorSucursal.Columnas.Observacion.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Overloads Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overloads Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overloads Sub InsertaOActualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub


   Public Overloads Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Sub Borrar(idCobrador As Integer)
      Dim sqlC As SqlServer.CobradoresSucursales = New SqlServer.CobradoresSucursales(da)
      sqlC.CobradoresSucursales_D(0, idCobrador)
   End Sub

   Public Function GetUno(idSucursal As Integer, idCobrador As Integer) As Entidades.CobradorSucursal
      Dim dt As DataTable = New SqlServer.CobradoresSucursales(Me.da).CobradoresSucursales_G1(idSucursal, idCobrador)
      Dim o As Entidades.CobradorSucursal = New Entidades.CobradorSucursal()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.CobradorSucursal)
      Return CargaLista(New SqlServer.CobradoresSucursales(Me.da).CobradoresSucursales_GA())
   End Function

   Public Function GetTodos(idSucursal As Integer) As List(Of Entidades.CobradorSucursal)
      Return CargaLista(New SqlServer.CobradoresSucursales(Me.da).CobradoresSucursales_GA(idSucursal))
   End Function

   Private Function CargaLista(dt As DataTable) As List(Of Entidades.CobradorSucursal)
      Dim o As Entidades.CobradorSucursal
      Dim oLis As List(Of Entidades.CobradorSucursal) = New List(Of Entidades.CobradorSucursal)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CobradorSucursal()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class