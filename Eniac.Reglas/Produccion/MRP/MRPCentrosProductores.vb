#Region "Option"
Option Strict On
Option Explicit On
#End Region
Imports Eniac.Entidades

Public Class MRPCentrosProductores
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.MRPCentroProductor.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPCentroProductor), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPCentroProductor), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPCentroProductor), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.MRPCentrosProductores(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MRPCentrosProductores(Me.da).CentrosProductores_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPCentroProductor, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPCentrosProductores(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CentrosProductores_I(en.IdCentroProductor, en.CodigoCentroProductor, en.Descripcion, en.IdSeccion, en.ClaseCentroProductor.ToString(), en.Dotacion,
                                      en.HorasLunes, en.HorasMartes, en.HorasMiercoles, en.HorasJueves, en.HorasViernes, en.HorasSabado, en.HorasDomingo,
                                      en.TiempoPAP, en.TiempoProductivo, en.TiempoNoProductivo, en.HorasHombrePAP, en.HorasHombreProductivo, en.HorasHombreNoProductivo,
                                      en.Activo, en.IdProveedor, en.IdNormaFabricacion, en.MantenimientoAutonomo, en.CantidadControles)
            '-- Actualiza Categorias Empleados.- ---------------------------------
            Dim rCategoriasCP = New MRPCentrosProductoresCategoriasEmpleados(da)
            rCategoriasCP.ActualizaDesdeCentrosProductores(en)

         Case TipoSP._U
            sqlC.CentrosProductores_U(en.IdCentroProductor, en.CodigoCentroProductor, en.Descripcion, en.IdSeccion, en.ClaseCentroProductor.ToString(), en.Dotacion,
                                      en.HorasLunes, en.HorasMartes, en.HorasMiercoles, en.HorasJueves, en.HorasViernes, en.HorasSabado, en.HorasDomingo,
                                      en.TiempoPAP, en.TiempoProductivo, en.TiempoNoProductivo, en.HorasHombrePAP, en.HorasHombreProductivo, en.HorasHombreNoProductivo,
                                      en.Activo, en.IdProveedor, en.IdNormaFabricacion, en.MantenimientoAutonomo, en.CantidadControles)
            '-- Actualiza Categorias Empleados.- ---------------------------------
            Dim rCategoriasCP = New MRPCentrosProductoresCategoriasEmpleados(da)
            rCategoriasCP.ActualizaDesdeCentrosProductores(en)

         Case TipoSP._D
            '-- Borra Categoria Empleados.- ---------------------------------------------
            Dim rCategoriaEmp = New Reglas.MRPCentrosProductoresCategoriasEmpleados(da)
            For Each eCatEmp In en.CategoriasEmpleados
               rCategoriaEmp._Borrar(eCatEmp)
            Next
            sqlC.CentrosProductores_D(en.IdCentroProductor)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MRPCentroProductor, dr As DataRow)
      With o
         .IdCentroProductor = dr.Field(Of Integer)(Entidades.MRPCentroProductor.Columnas.IdCentroProductor.ToString())
         .CodigoCentroProductor = dr.Field(Of String)(Entidades.MRPCentroProductor.Columnas.CodigoCentroProductor.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.MRPCentroProductor.Columnas.Descripcion.ToString())
         .IdSeccion = dr.Field(Of Integer?)(Entidades.MRPCentroProductor.Columnas.IdSeccion.ToString()).IfNull()
         .ClaseCentroProductor = DirectCast([Enum].Parse(GetType(Entidades.MRPCentroProductor.ClaseCentrosProd), dr(Entidades.MRPCentroProductor.Columnas.ClaseCentroProductor.ToString()).ToString()), Entidades.MRPCentroProductor.ClaseCentrosProd)
         .IdProveedor = dr.Field(Of Long?)(Entidades.MRPCentroProductor.Columnas.IdProveedor.ToString()).IfNull()
         .IdNormaFabricacion = dr.Field(Of Integer?)(Entidades.MRPCentroProductor.Columnas.IdNormaFabricacion.ToString()).IfNull()

         .Dotacion = dr.Field(Of Integer)(Entidades.MRPCentroProductor.Columnas.Dotacion.ToString())
         .CantidadControles = dr.Field(Of Integer)(Entidades.MRPCentroProductor.Columnas.CantidadControles.ToString())

         .HorasLunes = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasLunes.ToString())
         .HorasMartes = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasMartes.ToString())
         .HorasMiercoles = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasMiercoles.ToString())
         .HorasJueves = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasJueves.ToString())
         .HorasViernes = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasViernes.ToString())
         .HorasSabado = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasSabado.ToString())
         .HorasDomingo = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasDomingo.ToString())

         .TiempoPAP = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.TiempoPAP.ToString())
         .HorasHombrePAP = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasHombrePAP.ToString())

         .TiempoProductivo = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.TiempoProductivo.ToString())
         .HorasHombreProductivo = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasHombreProductivo.ToString())

         .TiempoNoProductivo = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.TiempoNoProductivo.ToString())
         .HorasHombreNoProductivo = dr.Field(Of Decimal)(Entidades.MRPCentroProductor.Columnas.HorasHombreNoProductivo.ToString())

         .Activo = dr.Field(Of Boolean)(Entidades.MRPCentroProductor.Columnas.Activo.ToString())

         .MantenimientoAutonomo = dr.Field(Of Boolean)(Entidades.MRPCentroProductor.Columnas.MantenimientoAutonomo.ToString())

         .CategoriasEmpleados = New Reglas.MRPCentrosProductoresCategoriasEmpleados().GetTodas(dr.Field(Of Integer)(MRPCentroProductor.Columnas.IdCentroProductor.ToString()), 0)

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetFiltradoPorCodigo(codigoCentroProd As String,
                                        internos As Entidades.Publicos.SiNoTodos,
                                        Optional BusquedaParcial As Boolean = True) As DataTable
      Dim sql = New SqlServer.MRPCentrosProductores(da)
      Dim dt = sql.CentrosProductores_G1_Codigo(codigoCentroProd, codigoExacto:=True, internos)
      If dt.Rows.Count = 0 And BusquedaParcial Then
         dt = sql.CentrosProductores_G1_Codigo(codigoCentroProd, codigoExacto:=False, internos)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorNombre(nombreCentroProd As String, activos As Entidades.Publicos.SiNoTodos, internos As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.MRPCentrosProductores(da).CentrosProductores_G1_Nombre(nombreCentroProd, False, activos, internos)
   End Function
   Public Function GetUno(idCentroProductor As Integer) As Entidades.MRPCentroProductor
      Return GetUno(idCentroProductor, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idCentroProductor As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MRPCentroProductor
      Return CargaEntidad(New SqlServer.MRPCentrosProductores(Me.da).CentrosProductores_G1(idCentroProductor),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPCentroProductor(),
                          accion, Function() String.Format("No existe Categoria de Empleado con Id: {0}", idCentroProductor))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPCentroProductor)
      Return CargaLista(New SqlServer.MRPCentrosProductores(Me.da).CentrosProductores_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPCentroProductor())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MRPCentrosProductores(Me.da).GetCodigoMaximo()
   End Function

   Public Function Existe(codigoCentroProd As String) As Boolean
      Return New SqlServer.MRPCentrosProductores(da).Existe(codigoCentroProd)
   End Function
#End Region
End Class
