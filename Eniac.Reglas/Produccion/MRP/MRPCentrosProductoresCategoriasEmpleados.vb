#Region "Option"
Option Strict On
Option Explicit On
#End Region
Imports Eniac.Entidades

Public Class MRPCentrosProductoresCategoriasEmpleados
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = MRPCentroProductorCategoriaEmpleado.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPCentroProductorCategoriaEmpleado), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPCentroProductorCategoriaEmpleado), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPCentroProductorCategoriaEmpleado), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ---------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPCentroProductorCategoriaEmpleado), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPCentroProductorCategoriaEmpleado), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPCentroProductorCategoriaEmpleado), TipoSP._D)
   End Sub
   '-------------------------------------------------------------------------------------------------
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MRPCentrosProductoresCategoriasEmpleados(Me.da).CentrosProductoresCategoriaE_GA()
   End Function

   Public Function _GetAll(idCentroProd As Integer, idCategoriaEmp As Integer) As System.Data.DataTable
      Return New SqlServer.MRPCentrosProductoresCategoriasEmpleados(Me.da).CentrosProductoresCategoriaE_GA(idCentroProd, idCategoriaEmp)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPCentroProductorCategoriaEmpleado, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPCentrosProductoresCategoriasEmpleados(da)
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Centros Productivos Categorias Empleados.- --------
            sqlC.CentrosProductoresCategoriaE_I(en.IdCentroProductor, en.IdCategoriaEmpleado, en.CantidadCategoria, en.ValorHoraCategoria)
         Case TipoSP._U
            '-- Modifica Centros Productivos Categorias Empleados.- --------
            sqlC.CentrosProductoresCategoriaE_U(en.IdCentroProductor, en.IdCategoriaEmpleado, en.CantidadCategoria, en.ValorHoraCategoria)
         Case TipoSP._M
            '-- Modifica Centros Productivos Categorias Empleados.- --------
            sqlC.CentrosProductoresCategoriaE_U(en.IdCentroProductor, en.IdCategoriaEmpleado, en.CantidadCategoria, en.ValorHoraCategoria)
         Case TipoSP._D
            '-- Elimina Centros Productivos Categorias Empleados.- --------------------
            sqlC.CentrosProductoresCategoriaE_D(en.IdCentroProductor, en.IdCategoriaEmpleado)
      End Select
   End Sub
   Private Sub CargarUno(o As MRPCentroProductorCategoriaEmpleado, dr As DataRow)
      With o
         .IdCentroProductor = dr.Field(Of Integer)(MRPCentroProductorCategoriaEmpleado.Columnas.IdCentroProductor.ToString())
         .IdCategoriaEmpleado = dr.Field(Of Integer)(MRPCentroProductorCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString())
         .CantidadCategoria = dr.Field(Of Decimal)(MRPCentroProductorCategoriaEmpleado.Columnas.CantidadCategoria.ToString())
         .ValorHoraCategoria = dr.Field(Of Decimal)(MRPCentroProductorCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString())
         .NombreCategoriaEmpleado = dr.Field(Of String)(MRPCategoriaEmpleado.Columnas.Descripcion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetTodas(idCentroProd As Integer, idCategoriaEmp As Integer) As ListConBorrados(Of MRPCentroProductorCategoriaEmpleado)
      Dim dt = _GetAll(idCentroProd, idCategoriaEmp)
      Dim o As MRPCentroProductorCategoriaEmpleado
      Dim oLis = New ListConBorrados(Of MRPCentroProductorCategoriaEmpleado)
      For Each dr As DataRow In dt.Rows
         o = New MRPCentroProductorCategoriaEmpleado
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Sub ActualizaDesdeCentrosProductores(entidad As MRPCentroProductor)
      If entidad.CategoriasEmpleados IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.CategoriasEmpleados.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oCE In entidad.CategoriasEmpleados
            Dim dt = _GetAll(oCE.IdCentroProductor, oCE.IdCategoriaEmpleado)
            If dt.Count = 0 Then
               oCE.IdCentroProductor = entidad.IdCentroProductor
               _Insertar(oCE)
            Else
               _Actualizar(oCE)
            End If
         Next
         '----------------------------------------------------------------------------
      End If
   End Sub
#End Region
End Class
