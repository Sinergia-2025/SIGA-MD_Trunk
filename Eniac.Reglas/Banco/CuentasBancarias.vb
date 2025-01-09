Public Class CuentasBancarias
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CuentasBancarias"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaBancaria), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaBancaria), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaBancaria), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad).CuentasBancarias_GA()
   End Function

#End Region

#Region "Metodos Publicos"
   Public Function GetAllActivos() As DataTable
      Return New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad).CuentasBancarias_GA_Activos()
   End Function

   Public Function GetFiltradoPorNombre(nombre As String, Optional idMoneda As Integer = 0, Optional ignorarEspeciales As Boolean = True) As DataTable
      Return New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad).
                           CuentasBancarias_GA_PorNombre(nombre, nombreCuentaExacto:=False, idMoneda, ignorarEspeciales)
   End Function

   Public Function GetFiltradoPorCodigo(id As Integer, Optional ignorarEspeciales As Boolean = True) As DataTable
      Return New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad).
                           CuentasBancarias_GA_PorCodigo(id.NullIf(0), activos:=True, ignorarEspeciales)
   End Function


   Public Function GetTodas() As List(Of Entidades.CuentaBancaria)
      Return CargaLista(GetAll(),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CuentaBancaria())
   End Function

   Public Function GetProximoId() As Integer
      Dim proximo = New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad).GetCodigoMaximo() + 1
      If proximo = 999 Then proximo += 1
      Return proximo
   End Function

   Public Function GetUna(idCuentaBancaria As Integer) As Entidades.CuentaBancaria
      Return GetUna(idCuentaBancaria, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idCuentaBancaria As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CuentaBancaria
      Return CargaEntidad(New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad).CuentasBancarias_GA_PorCodigo(idCuentaBancaria),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CuentaBancaria(),
                          accion, Function() String.Format("No existe la Cuenta de Bancaria con id: {0}", idCuentaBancaria))
   End Function

   Public Function GetParaInformarEnFEC() As List(Of Entidades.CuentaBancaria)
      Return CargaLista(New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad).CuentasBancarias_GA_ParaInformarEnFEC(),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CuentaBancaria())
   End Function

#End Region

#Region "Enumeraciones"

   Public Enum TipoOperacion
      Nuevo
      Modificacion
   End Enum

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ent As Entidades.CuentaBancaria, tipo As TipoSP)
      Dim sql = New SqlServer.CuentasBancarias(da, Publicos.TieneModuloContabilidad)
      Select Case tipo
         Case TipoSP._I
            sql.CuentasBancarias_I(ent.IdCuentaBancaria, ent.CodigoBancario, ent.CuentaBancariaClase.IdCuentaBancariaClase, ent.TieneChequera,
                                    ent.Moneda.IdMoneda, ent.Banco.IdBanco, ent.IdBancoSucursal, ent.Localidad.IdLocalidad, ent.NombreCuenta,
                                    ent.Activo, ent.idPlanCuenta, ent.idCuentaContable, ent.Cbu, ent.CbuAlias, ent.ParaInformarEnFEC, ent.IdEmpresa)
         Case TipoSP._U
            sql.CuentasBancarias_U(ent.IdCuentaBancaria, ent.CodigoBancario, ent.CuentaBancariaClase.IdCuentaBancariaClase, ent.TieneChequera,
                                    ent.Moneda.IdMoneda, ent.Banco.IdBanco, ent.IdBancoSucursal, ent.Localidad.IdLocalidad, ent.NombreCuenta,
                                    ent.Activo, ent.idPlanCuenta, ent.idCuentaContable, ent.Cbu, ent.CbuAlias, ent.ParaInformarEnFEC, ent.IdEmpresa)
         Case TipoSP._D
            sql.CuentasBancarias_D(ent.IdCuentaBancaria)
      End Select
   End Sub

   Private Sub CargarUna(o As Entidades.CuentaBancaria, dr As DataRow)
      With o
         .IdCuentaBancaria = dr.Field(Of Integer)(Entidades.CuentaBancaria.Columnas.IdCuentaBancaria.ToString())
         .Banco = New Bancos(da).GetUno(dr.Field(Of Integer)(Entidades.CuentaBancaria.Columnas.IdBanco.ToString()))
         .CodigoBancario = dr.Field(Of String)(Entidades.CuentaBancaria.Columnas.CodigoBancario.ToString())
         .IdBancoSucursal = dr.Field(Of Integer)(Entidades.CuentaBancaria.Columnas.IdBancoSucursal.ToString())
         .CuentaBancariaClase = New CuentasBancariasClase(da).GetUna(dr.Field(Of Integer)(Entidades.CuentaBancaria.Columnas.IdCuentaBancariaClase.ToString()))
         .Localidad = New Localidades(da).GetUna(dr.Field(Of Integer)(Entidades.CuentaBancaria.Columnas.IdLocalidad.ToString()))
         .Moneda = New Monedas(da).GetUna(dr.Field(Of Integer)(Entidades.CuentaBancaria.Columnas.IdMoneda.ToString()))
         .Saldo = dr.Field(Of Decimal?)(Entidades.CuentaBancaria.Columnas.Saldo.ToString()).IfNull()
         .SaldoConfirmado = dr.Field(Of Decimal?)(Entidades.CuentaBancaria.Columnas.SaldoConfirmado.ToString()).IfNull()
         .TieneChequera = dr.Field(Of Boolean)(Entidades.CuentaBancaria.Columnas.TieneChequera.ToString())
         .NombreCuenta = dr.Field(Of String)(Entidades.CuentaBancaria.Columnas.NombreCuenta.ToString())
         .Activo = dr.Field(Of Boolean)("Activo")
         .idPlanCuenta = dr.Field(Of Integer?)(Entidades.CuentaBancaria.Columnas.IdPlanCuenta.ToString()).IfNull()
         .idCuentaContable = dr.Field(Of Long?)(Entidades.CuentaBancaria.Columnas.IdCuentaContable.ToString()).IfNull().ToInteger()
         .Cbu = dr.Field(Of String)(Entidades.CuentaBancaria.Columnas.Cbu.ToString()).IfNull()
         .CbuAlias = dr.Field(Of String)(Entidades.CuentaBancaria.Columnas.CbuAlias.ToString()).IfNull()
         .ParaInformarEnFEC = dr.Field(Of Boolean)(Entidades.CuentaBancaria.Columnas.ParaInformarEnFEC.ToString())

         '-.PE-32476.-
         .IdEmpresa = dr.Field(Of Integer?)(Entidades.CuentaBancaria.Columnas.IdEmpresa.ToString()).IfNull()
      End With
   End Sub

#End Region

End Class