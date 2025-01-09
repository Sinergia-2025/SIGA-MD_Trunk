Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class Empresas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Empresa.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Empresas = New SqlServer.Empresas(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Empresas(da).Empresas_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Try
         Dim en As Entidades.Empresa = DirectCast(entidad, Entidades.Empresa)

         da.OpenConection()
         da.BeginTransaction()

         Dim rParametros As Parametros = New Parametros(da)
         Dim rParametrosImagenes As ParametrosImagenes = New ParametrosImagenes(da)
         Dim rParametrosSucursales As ParametrosSucursales = New ParametrosSucursales(da)

         Dim sqlC As SqlServer.Empresas = New SqlServer.Empresas(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.Empresas_I(en.IdEmpresa, en.NombreEmpresa, en.CuitEmpresa)
               rParametros.CopiarEntreEmpresas(actual.Sucursal.IdEmpresa, en.IdEmpresa)
               rParametrosImagenes.CopiarEntreEmpresas(actual.Sucursal.IdEmpresa, en.IdEmpresa)
               ActualizaParametrosConDatosEmpresa(en, rParametros)
            Case TipoSP._U
               sqlC.Empresas_U(en.IdEmpresa, en.NombreEmpresa, en.CuitEmpresa)
               ActualizaParametrosConDatosEmpresa(en, rParametros)
            Case TipoSP._D
               rParametrosSucursales.Borrar(en.IdEmpresa)
               rParametrosImagenes.Borrar(en.IdEmpresa)
               rParametros.Borrar(en.IdEmpresa)
               sqlC.Empresas_D(en.IdEmpresa)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub ActualizaParametrosConDatosEmpresa(en As Entidades.Empresa, rParametros As Parametros)
      rParametros._SetValor(en.IdEmpresa, Entidades.Parametro.Parametros.NOMBREEMPRESA.ToString(), en.NombreEmpresa, String.Empty)
      rParametros._SetValor(en.IdEmpresa, Entidades.Parametro.Parametros.CUITEMPRESA.ToString(), en.CuitEmpresa, String.Empty)
      ParametrosCache.Instancia.LimpiarCache()
   End Sub

   Private Sub CargarUno(o As Entidades.Empresa, dr As DataRow)
      With o
         .IdEmpresa = Integer.Parse(dr(Entidades.Empresa.Columnas.IdEmpresa.ToString()).ToString())
         .NombreEmpresa = dr(Entidades.Empresa.Columnas.NombreEmpresa.ToString()).ToString()
         .CuitEmpresa = dr(Entidades.Empresa.Columnas.CuitEmpresa.ToString()).ToString()
         .IdCategoriaFiscal = Short.Parse(dr("IdCategoriaFiscal").ToString())
         .NombreCategoriaFiscal = dr("NombreCategoriaFiscal").ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetPorCodigo(idEmpresa As Integer, idFuncion As String) As DataTable
      Return New SqlServer.Empresas(da).Empresas_G1(idEmpresa, idFuncion)
   End Function
   Public Function GetPorNombre(nombreEmpresa As String, idFuncion As String) As DataTable
      Return New SqlServer.Empresas(da).Empresas_GA(nombreEmpresa, nombreExacto:=False, idFuncion)
   End Function

   Public Function GetUno(idEmpresa As Integer) As Entidades.Empresa
      Return CargaEntidad(New SqlServer.Empresas(da).Empresas_G1(idEmpresa, idFuncion:=String.Empty), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Empresa(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe una empresa con id {0}", idEmpresa))
   End Function

   Public Function GetTodos() As List(Of Entidades.Empresa)
      Return CargaLista(New SqlServer.Empresas(da).Empresas_GA(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Empresa())
   End Function

   Public Function GetTodos(idFuncion As String) As List(Of Entidades.Empresa)
      Return CargaLista(New SqlServer.Empresas(da).Empresas_GA(idFuncion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Empresa())
   End Function

   Public Function Count() As Integer
      Return GetAll().Rows.Count
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Empresas(da).GetCodigoMaximo()
   End Function
#End Region
End Class