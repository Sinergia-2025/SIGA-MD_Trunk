Option Explicit On
Option Strict On
Public Class ContabilidadPlanes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ContabilidadPlanes"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ContabilidadPlan), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ContabilidadPlan), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ContabilidadPlan), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.ContabilidadPlan = New SqlServer.ContabilidadPlan(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ContabilidadPlan(Me.da).Planes_GA(False)
   End Function

   Public Overloads Function GetAll(todos As Boolean) As System.Data.DataTable
      Return New SqlServer.ContabilidadPlan(Me.da).Planes_GA(todos)
   End Function

#End Region

#Region "Metodos Privados"



   Private Sub EjecutaSP(en As Entidades.ContabilidadPlan, tipo As TipoSP)
      Dim sql As SqlServer.ContabilidadPlan = New SqlServer.ContabilidadPlan(Me.da)

      Select Case tipo

         Case TipoSP._I
            sql.Planes_I(en.IdPlanCuenta, en.NombrePlanCuenta)

         Case TipoSP._U
            sql.Planes_U(en.IdPlanCuenta, en.NombrePlanCuenta)

         Case TipoSP._D
            sql.Planes_D(en.IdPlanCuenta)

      End Select

   End Sub

   Private Sub CargarUna(o As Entidades.ContabilidadPlan, dr As DataRow)
      With o
         .IdPlanCuenta = dr.ValorNumericoPorDefecto(Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString(), 0I)
         .NombrePlanCuenta = dr(Entidades.ContabilidadPlan.Columnas.NombrePlanCuenta.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function TieneCuentasAsociadas(idPlanCuenta As Integer) As Boolean
      Dim sql As SqlServer.ContabilidadPlan = New SqlServer.ContabilidadPlan(Me.da)
      Return sql.TieneCuentasAsociadas(idPlanCuenta)
   End Function


   Public Function GetTodos() As List(Of Entidades.ContabilidadPlan)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.ContabilidadPlan())
   End Function

   Public Function GetUna(idPlanCuenta As Integer) As Entidades.ContabilidadPlan
      Return CargaEntidad(Me.Get1(idPlanCuenta), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.ContabilidadPlan(),
                          AccionesSiNoExisteRegistro.Excepcion, String.Format("No existe plan con IdPlanCuenta {0}.", idPlanCuenta))
   End Function

   Public Function Get1(idPlanCuenta As Integer) As DataTable
      Dim sql As SqlServer.ContabilidadPlan = New SqlServer.ContabilidadPlan(Me.da)
      Return sql.Planes_G1(idPlanCuenta)
   End Function

   Public Function GetPorNombre(dscplan As String) As DataTable
      Dim sql As SqlServer.ContabilidadPlan = New SqlServer.ContabilidadPlan(Me.da)
      Return sql.GetPorNombre(dscplan)
   End Function

   Public Function GetIdMaximo() As Integer
      Return New SqlServer.ContabilidadPlan(da).GetIdMaximo()
   End Function

#End Region

End Class