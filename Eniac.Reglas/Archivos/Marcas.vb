Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Public Class Marcas
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte, Entidades.JSonEntidades.Archivos.MarcaJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte, Entidades.JSonEntidades.Archivos.MarcaJSon)

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.Marca.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.Marca)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.Marca)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Marca), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Marcas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Marcas(da).Marcas_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(marca As Entidades.Marca, tipo As TipoSP)
      Dim sql = New SqlServer.Marcas(da)
      Select Case tipo
         Case TipoSP._I
            sql.Marcas_I(marca.IdMarca, marca.NombreMarca, marca.ComisionPorVenta, marca.DescuentoRecargoPorc1, marca.DescuentoRecargoPorc2)
         Case TipoSP._U
            sql.Marcas_U(marca.IdMarca, marca.NombreMarca, marca.ComisionPorVenta, marca.DescuentoRecargoPorc1, marca.DescuentoRecargoPorc2)
         Case TipoSP._D
            sql.Marcas_D(marca.IdMarca)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Marca, dr As DataRow)
      With o
         .IdMarca = dr.Field(Of Integer)(Entidades.Marca.Columnas.IdMarca.ToString())
         .NombreMarca = dr.Field(Of String)(Entidades.Marca.Columnas.NombreMarca.ToString())
         .ComisionPorVenta = dr.Field(Of Decimal)(Entidades.Marca.Columnas.ComisionPorVenta.ToString())
         .DescuentoRecargoPorc1 = dr.Field(Of Decimal)(Entidades.Marca.Columnas.DescuentoRecargoPorc1.ToString())
         .DescuentoRecargoPorc2 = dr.Field(Of Decimal)(Entidades.Marca.Columnas.DescuentoRecargoPorc2.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub Inserta(entidad As Entidades.Marca)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub Actualiza(entidad As Entidades.Marca)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Function GetTodas() As List(Of Entidades.Marca)
      Return EjecutaConConexion(Function() _GetTodas())
   End Function
   Public Function _GetTodas() As List(Of Entidades.Marca)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Marca())
   End Function

   Public Function GetUna(idMarca As Integer) As Entidades.Marca
      Return GetUna(idMarca, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idMarca As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Marca
      Return CargaEntidad(New SqlServer.Marcas(da).Marcas_G1(idMarca),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Marca(),
                          accion, Function() String.Format("No existe Marca con Id: {0}", idMarca))
   End Function

   Public Function GetPorCodigo(codigo As Integer) As DataTable
      Return New SqlServer.Marcas(da).Marcas_G1(If(codigo = 0, -1, codigo))
   End Function

   Public Function GetPorNombre(nombre As String) As DataTable
      Return New SqlServer.Marcas(da).Marcas_GA_PorNombre(nombre, nombreExacto:=False)
   End Function

   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.Marcas(da).Marcas_GA_PorNombre(nombre, nombreExacto:=True)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Marcas(da).GetCodigoMaximo()
   End Function
   Public Function GetPrimeraMarca() As Integer
      Return CargaEntidad(New SqlServer.Marcas(da).Marcas_GetPrimeraMarca(),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Marca(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() "No existe registros de Marca").IdMarca
   End Function

#End Region

End Class