#Region "Option"
Option Strict On
Option Explicit On
#End Region
Imports Eniac.Entidades

Public Class MRPProcesosProductivosCategoriasEmpleados
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = MRPProcesoProductivoCategoriaEmpleado.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoCategoriaEmpleado), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoCategoriaEmpleado), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoCategoriaEmpleado), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ---------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoCategoriaEmpleado), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoCategoriaEmpleado), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoCategoriaEmpleado), TipoSP._D)
   End Sub
   '-------------------------------------------------------------------------------------------------
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivosCategoriasEmpleados(Me.da).ProcesosProductivosCategoriaE_GA()
   End Function

   Public Function _GetAll(idProcesoProductivo As Long, idOperacion As Integer) As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivosCategoriasEmpleados(Me.da).ProcesosProductivosCategoriaE_GA(idProcesoProductivo, idOperacion)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPProcesoProductivoCategoriaEmpleado, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPProcesosProductivosCategoriasEmpleados(da)
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Procesos Productivos Categorias Empleados.- --------
            sqlC.ProcesosProductivosCategoriaE_I(en.IdOperacion, en.IdProcesoProductivo, en.IdCategoriaEmpleado, en.CantidadCategoria, en.ValorHoraCategoria)
         Case TipoSP._U
            '-- Modifica Procesos Productivos Categorias Empleados.- --------
            sqlC.ProcesosProductivosCategoriaE_U(en.IdOperacion, en.IdProcesoProductivo, en.IdCategoriaEmpleado, en.CantidadCategoria, en.ValorHoraCategoria)
         Case TipoSP._D
            '-- Elimina Procesos Productivos Categorias Empleados.- --------------------
            sqlC.ProcesosProductivosCategoriaE_D(en.IdOperacion, en.IdProcesoProductivo, en.IdCategoriaEmpleado)
      End Select
   End Sub
   Private Sub CargarUno(o As MRPProcesoProductivoCategoriaEmpleado, dr As DataRow)
      With o
         .IdOperacion = dr.Field(Of Integer)(MRPProcesoProductivoCategoriaEmpleado.Columnas.IdOperacion.ToString())
         .IdProcesoProductivo = dr.Field(Of Long)(MRPProcesoProductivoCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString())
         .IdCategoriaEmpleado = dr.Field(Of Integer)(MRPProcesoProductivoCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString())
         .CantidadCategoria = dr.Field(Of Decimal)(MRPProcesoProductivoCategoriaEmpleado.Columnas.CantidadCategoria.ToString())
         .ValorHoraCategoria = dr.Field(Of Decimal)(MRPProcesoProductivoCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString())
         .NombreCategoriaEmpleado = dr.Field(Of String)(MRPCategoriaEmpleado.Columnas.Descripcion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetTodas(IdProcesoProductivo As Long, idOperacion As Integer) As ListConBorrados(Of MRPProcesoProductivoCategoriaEmpleado)
      Dim dt = _GetAll(IdProcesoProductivo, idOperacion)
      Dim o As MRPProcesoProductivoCategoriaEmpleado
      Dim oLis = New ListConBorrados(Of MRPProcesoProductivoCategoriaEmpleado)
      For Each dr As DataRow In dt.Rows
         o = New MRPProcesoProductivoCategoriaEmpleado
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Sub ActualizaDesdeProcesosProductivosOperaciones(entidad As MRPProcesoProductivoOperacion)
      If entidad.CategoriasEmpleados IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.CategoriasEmpleados.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oCE In entidad.CategoriasEmpleados
            If oCE.IdOperacion = 0 And oCE.IdProcesoProductivo = 0 Then
               oCE.IdOperacion = entidad.IdOperacion
               oCE.IdProcesoProductivo = entidad.IdProcesoProductivo
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
