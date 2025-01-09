
Option Explicit On
Option Strict On

Imports System.Text
Public Class ContabilidadPlanesCuentas

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContabilidadPlanesCuentas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ContabilidadPlanesCuentas"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ContabilidadPlanesCuentas(Me.da).PlanCuenta_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)


      Dim en As Entidades.ContabilidadPlanCuenta = DirectCast(entidad, Entidades.ContabilidadPlanCuenta)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.PlanCuenta_I(en.IdPlanCuenta _
                              , en.grillaCuentas)

            Case TipoSP._U
               sql.PlanCuenta_U(en.IdPlanCuenta _
                              , en.grillaCuentas)

            Case TipoSP._D
               sql.PlanCuenta_D(en.IdPlanCuenta)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUna(ByVal o As Entidades.ContabilidadPlanCuenta, ByVal dr As DataRow, ByVal dtDetalle As DataTable)
      With o
         .IdPlanCuenta = Integer.Parse(dr(Entidades.ContabilidadPlanCuenta.Columnas.IdPlanCuenta.ToString()).ToString())
         '.IdCuenta = Int64.Parse(dr(Entidades.PlanCuenta.Columnas.IdCuenta.ToString()).ToString())
         '.IdCentroCosto = Integer.Parse(dr(Entidades.PlanCuenta.Columnas.IdCentroCosto.ToString()).ToString())
         '.NombrePlanCuenta = dr(Entidades.PlanCuenta.Columnas.NombrePlanCuenta.ToString()).ToString()
         .grillaCuentas = dtDetalle

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ContabilidadPlanCuenta)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ContabilidadPlanCuenta
      Dim oLis As List(Of Entidades.ContabilidadPlanCuenta) = New List(Of Entidades.ContabilidadPlanCuenta)
      Dim dtDetalle As DataTable = Nothing ' no cargo los detalles del asiento cuando muestro la grilla de busqueda
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ContabilidadPlanCuenta()
         Me.CargarUna(o, dr, dtDetalle)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal idplanCuenta As Integer) As Entidades.ContabilidadPlanCuenta
      Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)
      Dim dt As DataTable = sql.PlanCuenta_G1(idplanCuenta)
      Dim o As Entidades.ContabilidadPlanCuenta = New Entidades.ContabilidadPlanCuenta()
      Dim dtDetalle As DataTable = sql.plan_GetDetalle(idplanCuenta)
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0), dtDetalle)
      Else
         'Throw New Exception("No existe el Plan de Cuenta")
      End If
      Return o
   End Function

   Public Function Get1(ByVal idplanCuenta As Integer) As DataTable
      Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)
      Return sql.PlanCuenta_G1(idplanCuenta)
   End Function

   Public Function GetPorNombre(ByVal dscplanCuenta As String) As DataTable
      Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)
      Return sql.GetPorNombre(dscplanCuenta)
   End Function

   Public Function GetIdMaximo() As Integer

      Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)
      Dim dt As DataTable = sql.PlanCuenta_GetIdMaximo()
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function GetDatosCuenta(ByVal codCuenta As Integer) As DataTable
      Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)
      Return sql.GetDatosCuenta(codCuenta)
   End Function

   Public Function seleccionarTodasLasCuentas() As DataTable
      Dim sql As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)
      Return sql.seleccionarTodasLasCuentas()
   End Function

#End Region

End Class
