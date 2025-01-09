#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class RepartosGastos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RepartoGasto.NombreTabla
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
   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.RepartosGastos = New SqlServer.RepartosGastos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Throw New NotImplementedException("GetAll() no fue implementado. Usar GetAll(Integer, Integer)")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idReparto As Integer) As System.Data.DataTable
      Return New SqlServer.RepartosGastos(Me.da).RepartosGastos_GA(idSucursal, idReparto)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(ByVal en As Entidades.RepartoGasto, ByVal tipo As TipoSP)

      Dim sqlC As SqlServer.RepartosGastos = New SqlServer.RepartosGastos(da)
      Select Case tipo
         Case TipoSP._I
            If en.IdGasto = 0 Then
               en.IdGasto = GetCodigoMaximo(en.IdSucursal, en.IdReparto) + 1
            End If
            sqlC.RepartosGastos_I(en.IdSucursal,
                                  en.IdReparto,
                                  en.IdGasto,
                                  en.IdCuentaCaja,
                                  en.ImportePesos,
                                  en.Observacion,
                                  en.IdCaja,
                                  en.NumeroPlanilla,
                                  en.NumeroMovimiento)
         Case TipoSP._U
            sqlC.RepartosGastos_U(en.IdSucursal,
                                  en.IdReparto,
                                  en.IdGasto,
                                  en.IdCuentaCaja,
                                  en.ImportePesos,
                                  en.Observacion,
                                  en.IdCaja,
                                  en.NumeroPlanilla,
                                  en.NumeroMovimiento)
         Case TipoSP._D
            sqlC.RepartosGastos_D(en.IdSucursal, en.IdReparto, en.IdGasto)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.RepartoGasto, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.RepartoGasto.Columnas.IdSucursal.ToString).ToString())
         .IdReparto = Integer.Parse(dr(Entidades.RepartoGasto.Columnas.IdReparto.ToString).ToString())
         .IdGasto = Integer.Parse(dr(Entidades.RepartoGasto.Columnas.IdGasto.ToString).ToString())

         .CuentaCaja = New Reglas.CuentasDeCajas().GetUna(Integer.Parse(dr(Entidades.RepartoGasto.Columnas.IdCuentaCaja.ToString).ToString()))
         .ImportePesos = Decimal.Parse(dr(Entidades.RepartoGasto.Columnas.ImportePesos.ToString).ToString())
         .Observacion = dr(Entidades.RepartoGasto.Columnas.Observacion.ToString).ToString()
         .IdCaja = Integer.Parse(dr(Entidades.RepartoGasto.Columnas.IdCaja.ToString).ToString())
         .NumeroPlanilla = Integer.Parse(dr(Entidades.RepartoGasto.Columnas.NumeroPlanilla.ToString).ToString())
         .NumeroMovimiento = Integer.Parse(dr(Entidades.RepartoGasto.Columnas.NumeroMovimiento.ToString).ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoGasto), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoGasto), TipoSP._U)
   End Sub

   Public Sub Merge(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoGasto), TipoSP._M)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoGasto), TipoSP._D)
   End Sub

   Public Sub InsertaDesdeReparto(ByVal rc As Eniac.Entidades.Reparto)
      For Each rg As Entidades.RepartoGasto In rc.Gastos
         rg.IdSucursal = rc.IdSucursal
         rg.IdReparto = rc.IdReparto
         Inserta(rg)
      Next
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          idGasto As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.RepartoGasto
      Dim dt As DataTable = New SqlServer.RepartosGastos(da).RepartosGastos_G1(idSucursal, idReparto, idGasto)
      Dim o As Entidades.RepartoGasto = New Entidades.RepartoGasto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         ElseIf accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No se encontró el RepartoGasto con Sucursal {0}, Número {1} y Id Gasto {2}", idSucursal, idReparto, idGasto))
         End If
      End If
      Return o
   End Function

   Public Function GetTodos(idSucursal As Integer, idReparto As Integer) As List(Of Entidades.RepartoGasto)
      Return CargaLista(New SqlServer.RepartosGastos(da).RepartosGastos_GA(idSucursal, idReparto), Sub(o, dr) CargarUno(DirectCast(o, Entidades.RepartoGasto), dr), Function() New Entidades.RepartoGasto())
   End Function

   Public Function GetCodigoMaximo(idSucursal As Integer, idReparto As Integer) As Integer
      Return New SqlServer.RepartosGastos(da).GetCodigoMaximo(idSucursal, idReparto)
   End Function

#End Region

End Class