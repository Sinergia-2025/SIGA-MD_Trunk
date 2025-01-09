Public Class CalendariosSucursales
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CalendarioSucursal.NombreTabla
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

   'Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
   '   Dim sql As SqlServer.CalendariosSucursales = New SqlServer.CalendariosSucursales(Me.da)
   '   Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   'End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CalendariosSucursales(Me.da).CalendariosSucursales_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.CalendarioSucursal = DirectCast(entidad, Entidades.CalendarioSucursal)
      Dim sqlC As SqlServer.CalendariosSucursales = New SqlServer.CalendariosSucursales(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CalendariosSucursales_I(en.IdSucursal, en.IdCalendario, en.IdCaja)
         Case TipoSP._U
            sqlC.CalendariosSucursales_U(en.IdSucursal, en.IdCalendario, en.IdCaja)
         Case TipoSP._D
            sqlC.CalendariosSucursales_D(en.IdSucursal, en.IdCalendario)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CalendarioSucursal, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.CalendarioSucursal.Columnas.IdSucursal.ToString()).ToString())
         .IdCalendario = Integer.Parse(dr(Entidades.CalendarioSucursal.Columnas.IdCalendario.ToString()).ToString())
         If IsNumeric(dr(Entidades.CalendarioSucursal.Columnas.IdCaja.ToString())) Then
            .IdCaja = Integer.Parse(dr(Entidades.CalendarioSucursal.Columnas.IdCaja.ToString()).ToString())
         End If
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

   Public Overloads Sub Borrar(idCalendario As Integer)
      Dim sqlC As SqlServer.CalendariosSucursales = New SqlServer.CalendariosSucursales(da)
      sqlC.CalendariosSucursales_D(actual.Sucursal.IdSucursal, idCalendario)
   End Sub

   Public Function GetUno(idSucursal As Integer, idCalendario As Integer) As Entidades.CalendarioSucursal
      Dim dt As DataTable = New SqlServer.CalendariosSucursales(Me.da).CalendariosSucursales_G1(idSucursal, idCalendario)
      Dim o As Entidades.CalendarioSucursal = New Entidades.CalendarioSucursal()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.CalendarioSucursal)
      Return CargaLista(New SqlServer.CalendariosSucursales(Me.da).CalendariosSucursales_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalendarioSucursal())
   End Function

   Public Function GetTodos(idSucursal As Integer) As List(Of Entidades.CalendarioSucursal)
      Return CargaLista(New SqlServer.CalendariosSucursales(Me.da).CalendariosSucursales_GA(idSucursal),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalendarioSucursal())
   End Function

#End Region

End Class
