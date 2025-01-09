#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class CategoriasLegajos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CategoriaLegajo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CategoriaLegajo)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CategoriaLegajo)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CategoriaLegajo)))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CategoriasLegajos = New SqlServer.CategoriasLegajos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable ' se aplica la regla para traer todos los registros asociados al cliente
      Return New SqlServer.CategoriasLegajos(Me.da).CategoriasLegajos_GA()
   End Function
   'Public Function InfClientesActualizaciones(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
   '   Return New SqlServer.ClientesActualizaciones(Me.da).GetInfClientesActualizaciones(idCliente, fechaDesde, fechaHasta)
   'End Function

#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Eniac.Entidades.CategoriaLegajo)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Eniac.Entidades.CategoriaLegajo)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Eniac.Entidades.CategoriaLegajo)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.CategoriaLegajo)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.CategoriaLegajo, tipo As TipoSP)

      Dim sqlC As SqlServer.CategoriasLegajos = New SqlServer.CategoriasLegajos(da)
      Select Case tipo
         'Case TipoSP._I
         '   sqlC.ClientesActualizaciones_I(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioActualizacion, en.FechaFinActualizacion,
         '                                  en.IdUnico,
         '                                  en.Estado, en.EstadoDescargaScripts, en.EstadoDescargaInstalador,
         '                                  en.EstadoBackup, en.EstadoEjecucionScripts, en.EstadoEjecucionInstalador,
         '                                  en.Activo)
         'Case TipoSP._U
         '   sqlC.ClientesActualizaciones_U(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.FechaInicioActualizacion, en.FechaFinActualizacion,
         '                                  en.IdUnico,
         '                                  en.Estado, en.EstadoDescargaScripts, en.EstadoDescargaInstalador,
         '                                  en.EstadoBackup, en.EstadoEjecucionScripts, en.EstadoEjecucionInstalador,
         '                                  en.Activo)
         Case TipoSP._M
            sqlC.CategoriasLegajos_M(en.Idcategoria, en.NombreCategoria)
            'Case TipoSP._D
            '   sqlC.ClientesActualizaciones_D(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.CategoriaLegajo, dr As DataRow)
      With o
         .Idcategoria = Integer.Parse(dr(Entidades.CategoriaLegajo.Columnas.Idcategoria.ToString()).ToString())
         .NombreCategoria = dr(Entidades.CategoriaLegajo.Columnas.NombreCategoria.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idCategoria As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.CategoriaLegajo

      Return CargaEntidad(New SqlServer.CategoriasLegajos(da).CategoriasLegajos_G1(idCategoria),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CategoriaLegajo(),
                          accion, Function() String.Format("No se encontró la Categoría"))
   End Function

   Public Function GetTodos() As List(Of Entidades.CategoriaLegajo)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.CategoriaLegajo), dr), Function() New Entidades.CategoriaLegajo())
   End Function

   Public Sub MigrarCategorias(Categorias As DataTable, BarraProg As System.Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim i As Integer = 0

         BarraProg.Maximum = Categorias.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         Dim Categoria As Entidades.CategoriaLegajo
         For Each dr As DataRow In Categorias.Rows
            i += 1
            BarraProg.Value = i

            Categoria = New Entidades.CategoriaLegajo
            Categoria.Idcategoria = Integer.Parse(dr("tdcCodigo").ToString())
            Categoria.NombreCategoria = dr("tdcCategoria").ToString()

            _Merge(Categoria)

         Next

         da.CommitTransaction()

      Catch ex As Exception
         BarraProg.Value = 0
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

#End Region

End Class