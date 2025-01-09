#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MRPCategoriasEmpleados
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.MRPCategoriaEmpleado.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPCategoriaEmpleado), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPCategoriaEmpleado), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPCategoriaEmpleado), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.MRPCategoriasEmpleados(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return _GetAll(Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Overloads Function _GetAll(activas As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.MRPCategoriasEmpleados(Me.da).CategoriasEmpleados_GA(activas)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPCategoriaEmpleado, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPCategoriasEmpleados(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CategoriasEmpleados_I(en.IdCategoriaEmpleado, en.CodigoCategoriaEmpleado, en.Descripcion, en.ValorHoraProduccion, en.Activo)
         Case TipoSP._U
            sqlC.CategoriasEmpleados_U(en.IdCategoriaEmpleado, en.CodigoCategoriaEmpleado, en.Descripcion, en.ValorHoraProduccion, en.Activo)
         Case TipoSP._D
            sqlC.CategoriasEmpleados_D(en.IdCategoriaEmpleado)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MRPCategoriaEmpleado, dr As DataRow)
      With o
         .IdCategoriaEmpleado = dr.Field(Of Integer)(Entidades.MRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString())
         .CodigoCategoriaEmpleado = dr.Field(Of String)(Entidades.MRPCategoriaEmpleado.Columnas.CodigoCategoriaEmpleado.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.MRPCategoriaEmpleado.Columnas.Descripcion.ToString())
         .ValorHoraProduccion = dr.Field(Of Decimal)(Entidades.MRPCategoriaEmpleado.Columnas.ValorHoraProduccion.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.MRPCategoriaEmpleado.Columnas.Activo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetFiltradoPorCodigo(CodigoCategoriaEmp As String,
                                        Optional BusquedaParcial As Boolean = True) As DataTable
      Dim sql = New SqlServer.MRPCategoriasEmpleados(da)
      Dim dt = sql.CategoriasEmpleados_G1_Codigo(CodigoCategoriaEmp, codigoExacto:=True)
      If dt.Rows.Count = 0 And BusquedaParcial Then
         dt = sql.CategoriasEmpleados_G1_Codigo(CodigoCategoriaEmp, codigoExacto:=False)
      End If
      Return dt
   End Function
   Public Function GetFiltradoPorNombre(nombreCategoriaEmp As String, activos As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.MRPCategoriasEmpleados(da).CategoriaEmpleados_G1_Nombre(nombreCategoriaEmp, False, activos)
   End Function

   Public Function GetUno(IdCategoria As Integer) As Entidades.MRPCategoriaEmpleado
      Return GetUno(IdCategoria, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(IdCategoria As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MRPCategoriaEmpleado
      Return CargaEntidad(New SqlServer.MRPCategoriasEmpleados(Me.da).CategoriasEmpleados_G1(IdCategoria),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPCategoriaEmpleado(),
                          accion, Function() String.Format("No existe Categoria de Empleado con Id: {0}", IdCategoria))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPCategoriaEmpleado)
      Return CargaLista(New SqlServer.MRPCategoriasEmpleados(Me.da).CategoriasEmpleados_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPCategoriaEmpleado())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MRPCategoriasEmpleados(Me.da).GetCodigoMaximo()
   End Function

   Public Function Existe(codigoCategoria As String) As Boolean
      Return New SqlServer.MRPCategoriasEmpleados(da).Existe(codigoCategoria)
   End Function

#End Region

End Class
