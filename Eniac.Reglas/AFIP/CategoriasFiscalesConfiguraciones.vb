Option Strict On
Option Explicit On
Public Class CategoriasFiscalesConfiguraciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CategoriaFiscalConfiguracion.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         _Insertar(DirectCast(entidad, Entidades.CategoriaFiscalConfiguracion))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         _Actualizar(DirectCast(entidad, Entidades.CategoriaFiscalConfiguracion))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         _Borrar(DirectCast(entidad, Entidades.CategoriaFiscalConfiguracion))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CategoriasFiscalesConfiguraciones = New SqlServer.CategoriasFiscalesConfiguraciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasFiscalesConfiguraciones(Me.da).CategoriasFiscalesConfiguraciones_GA(Publicos.CategoriaFiscalEmpresa)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CategoriaFiscalConfiguracion, tipo As TipoSP)
      Dim sqlC As SqlServer.CategoriasFiscalesConfiguraciones = New SqlServer.CategoriasFiscalesConfiguraciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CategoriasFiscalesConfiguraciones_I(en.IdCategoriaFiscalEmpresa, en.IdCategoriaFiscalCliente,
                                                     en.LetraFiscal, en.LetraFiscalCompra,
                                                     en.IvaDiscriminado)
         Case TipoSP._U
            sqlC.CategoriasFiscalesConfiguraciones_U(en.IdCategoriaFiscalEmpresa, en.IdCategoriaFiscalCliente,
                                                     en.LetraFiscal, en.LetraFiscalCompra,
                                                     en.IvaDiscriminado)
         Case TipoSP._M
            sqlC.CategoriasFiscalesConfiguraciones_M(en.IdCategoriaFiscalEmpresa, en.IdCategoriaFiscalCliente,
                                                     en.LetraFiscal, en.LetraFiscalCompra,
                                                     en.IvaDiscriminado)
         Case TipoSP._D
            sqlC.CategoriasFiscalesConfiguraciones_D(en.IdCategoriaFiscalEmpresa, en.IdCategoriaFiscalCliente)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.CategoriaFiscalConfiguracion, dr As DataRow)
      With o
         .IdCategoriaFiscalEmpresa = Short.Parse(dr(Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalEmpresa.ToString()).ToString())
         .IdCategoriaFiscalCliente = Short.Parse(dr(Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString()).ToString())
         .LetraFiscal = dr(Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscal.ToString()).ToString()
         .LetraFiscalCompra = dr(Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscalCompra.ToString()).ToString()
         .IvaDiscriminado = Boolean.Parse(dr(Entidades.CategoriaFiscalConfiguracion.Columnas.IvaDiscriminado.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Entidades.CategoriaFiscalConfiguracion)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.CategoriaFiscalConfiguracion)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Entidades.CategoriaFiscalConfiguracion)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Merge(entidad As Entidades.CategoriaFiscal)
      Me._Merge(New Entidades.CategoriaFiscalConfiguracion() With {.IdCategoriaFiscalEmpresa = Publicos.CategoriaFiscalEmpresa,
                                                                   .IdCategoriaFiscalCliente = entidad.IdCategoriaFiscal,
                                                                   .LetraFiscal = entidad.LetraFiscal,
                                                                   .LetraFiscalCompra = entidad.LetraFiscalCompra,
                                                                   .IvaDiscriminado = entidad.IvaDiscriminado})
   End Sub

   Public Sub _Borrar(entidad As Entidades.CategoriaFiscalConfiguracion)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idCategoriaFiscalEmpresa As Short, idCategoriaFiscalCliente As Short) As Entidades.CategoriaFiscalConfiguracion
      Dim dt As DataTable = New SqlServer.CategoriasFiscalesConfiguraciones(Me.da).CategoriasFiscalesConfiguraciones_G1(idCategoriaFiscalEmpresa, idCategoriaFiscalCliente)
      Dim o As Entidades.CategoriaFiscalConfiguracion = New Entidades.CategoriaFiscalConfiguracion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.CategoriaFiscalConfiguracion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CategoriaFiscalConfiguracion())
   End Function

#End Region
End Class