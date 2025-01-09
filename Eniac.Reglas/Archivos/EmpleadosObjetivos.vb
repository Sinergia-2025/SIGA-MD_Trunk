Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
Imports Eniac.Entidades
Public Class EmpleadosObjetivos
   Inherits Eniac.Reglas.Base
#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.EmpleadoObjetivo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.EmpleadoObjetivo = DirectCast(entidad, Entidades.EmpleadoObjetivo)
      Dim sql As SqlServer.EmpleadosObjetivos = New SqlServer.EmpleadosObjetivos(da)

      Select Case tipo
         Case TipoSP._I
            sql.EmpleadosObjetivos_I(en.IdEmpleado, en.PeriodoFiscal, en.ImporteObjetivo)
         Case TipoSP._U
            sql.EmpleadosObjetivos_U(en.IdEmpleado, en.PeriodoFiscal, en.ImporteObjetivo)
         Case TipoSP._D
            sql.EmpleadosObjetivos_D(en.IdEmpleado)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.EmpleadoObjetivo, dr As DataRow)
      With o
         .IdEmpleado = Integer.Parse(dr(EmpleadoObjetivo.Columnas.IdEmpleado.ToString()).ToString())
         .PeriodoFiscal = Integer.Parse(dr(EmpleadoObjetivo.Columnas.PeriodoFiscal.ToString()).ToString())
         .ImporteObjetivo = Decimal.Parse(dr(EmpleadoObjetivo.Columnas.ImporteObjetivo.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._I))
   End Sub


   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.EmpleadosObjetivos = New SqlServer.EmpleadosObjetivos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EmpleadosObjetivos(Me.da).EmpleadosObjetivos_GA()
   End Function
#End Region

#Region "Metodos Publicos"
   Public Function GetTodos() As List(Of Entidades.EmpleadoObjetivo)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EmpleadoObjetivo())
   End Function
   Public Function GetUno(IdEmpleado As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.EmpleadoObjetivo
      Return CargaEntidad(New SqlServer.EmpleadosObjetivos(Me.da).EmpleadosObjetivos_GA(IdEmpleado),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EmpleadoObjetivo(),
                          accion, Function() String.Format("El empleado para el Id {0} no existe. Por favor verifique.", IdEmpleado))
   End Function
   Public Function GetTodos(IdEmpleado As Integer) As List(Of Entidades.EmpleadoObjetivo)
      Return CargaLista(New SqlServer.EmpleadosObjetivos(Me.da).EmpleadosObjetivos_GA(IdEmpleado), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EmpleadoObjetivo())
   End Function
   Public Function GetUno(IdEmpleado As Integer, periodoFiscal As Integer) As DataTable
      Return New SqlServer.EmpleadosObjetivos(Me.da).EmpleadosObjetivos_G1(IdEmpleado, periodoFiscal)
   End Function
#End Region

End Class
