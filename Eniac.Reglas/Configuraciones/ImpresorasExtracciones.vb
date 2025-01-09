Public Class ImpresorasExtracciones
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ImpresoraExtraccion.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ImpresoraExtraccion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ImpresoraExtraccion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ImpresoraExtraccion)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ImpresorasExtracciones(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ImpresorasExtracciones(Me.da).ImpresorasExtracciones_GA(actual.Sucursal.Id)
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idImpresora As String) As DataTable
      Return New SqlServer.ImpresorasExtracciones(Me.da).ImpresorasExtracciones_GA(idSucursal, idImpresora)
   End Function

#End Region

#Region "Metodos Privados"
   Public Sub _Insertar(entidad As Entidades.ImpresoraExtraccion)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.ImpresoraExtraccion)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ImpresoraExtraccion)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub CargarUno(o As Entidades.ImpresoraExtraccion, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.ImpresoraExtraccion.Columnas.IdSucursal.ToString())
         .IdImpresora = dr.Field(Of String)(Entidades.ImpresoraExtraccion.Columnas.IdImpresora.ToString())
         .Secuencia = dr.Field(Of Integer)(Entidades.ImpresoraExtraccion.Columnas.Secuencia.ToString())

         .ZetaDesde = dr.Field(Of Integer)(Entidades.ImpresoraExtraccion.Columnas.ZetaDesde.ToString())
         .ZetaHasta = dr.Field(Of Integer)(Entidades.ImpresoraExtraccion.Columnas.ZetaHasta.ToString())
         .FechaExtraccionDesde = dr.Field(Of Date)(Entidades.ImpresoraExtraccion.Columnas.FechaExtraccionDesde.ToString())
         .FechaExtraccionHasta = dr.Field(Of Date)(Entidades.ImpresoraExtraccion.Columnas.FechaExtraccionHasta.ToString())

         .FechaExtraccion = dr.Field(Of Date)(Entidades.ImpresoraExtraccion.Columnas.FechaExtraccion.ToString())
         .IdUsuarioExtraccion = dr.Field(Of String)(Entidades.ImpresoraExtraccion.Columnas.IdUsuarioExtraccion.ToString())

         .NombreArchivo = dr.Field(Of String)(Entidades.ImpresoraExtraccion.Columnas.NombreArchivo.ToString())
         .MD5Archivo = dr.Field(Of String)(Entidades.ImpresoraExtraccion.Columnas.MD5Archivo.ToString())

      End With

   End Sub

   Private Sub EjecutaSP(en As Entidades.ImpresoraExtraccion, tipo As TipoSP)
      Dim sql = New SqlServer.ImpresorasExtracciones(Me.da)
      Select Case tipo
         Case TipoSP._I
            If en.Secuencia = 0 Then
               en.Secuencia = GetCodigoMaximo(en.IdSucursal, en.IdImpresora) + 1
            End If

            sql.ImpresorasExtracciones_I(en.IdSucursal, en.IdImpresora, en.Secuencia,
                                         en.ZetaDesde, en.ZetaHasta, en.FechaExtraccionDesde, en.FechaExtraccionHasta,
                                         en.FechaExtraccion, en.IdUsuarioExtraccion, en.NombreArchivo, en.MD5Archivo)

         Case TipoSP._U
            sql.ImpresorasExtracciones_U(en.IdSucursal, en.IdImpresora, en.Secuencia,
                                         en.ZetaDesde, en.ZetaHasta, en.FechaExtraccionDesde, en.FechaExtraccionHasta,
                                         en.FechaExtraccion, en.IdUsuarioExtraccion, en.NombreArchivo, en.MD5Archivo)

         Case TipoSP._D
            sql.ImpresorasExtracciones_D(en.IdSucursal, en.IdImpresora, en.Secuencia)

      End Select
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetTodos(impresora As Entidades.Impresora) As List(Of Entidades.ImpresoraExtraccion)
      Return GetTodos(impresora.IdSucursal, impresora.IdImpresora)
   End Function
   Public Function GetTodos(idSucursal As Integer, idImpresora As String) As List(Of Entidades.ImpresoraExtraccion)
      Return CargaLista(New SqlServer.ImpresorasExtracciones(da).ImpresorasExtracciones_GA(idSucursal, idImpresora),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ImpresoraExtraccion())
   End Function

   Public Function GetUna(idSucursal As Integer, idImpresora As String, secuencia As Integer) As Entidades.ImpresoraExtraccion
      Return _GetUna(idSucursal, idImpresora, secuencia, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Friend Function _GetUna(idSucursal As Integer, idImpresora As String, secuencia As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ImpresoraExtraccion
      Return CargaEntidad(New SqlServer.ImpresorasExtracciones(da).ImpresorasExtracciones_G1(idSucursal, idImpresora, secuencia),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ImpresoraExtraccion(),
                          AccionesSiNoExisteRegistro.Excepcion, String.Format("No existe la Extracción de Impresora con sucursal {0}, impresora {1} y secuencia {2}", idSucursal, idImpresora, secuencia))
   End Function

   Public Function GetCodigoMaximo(idSucursal As Integer, idImpresora As String) As Integer
      Return New SqlServer.ImpresorasExtracciones(da).GetCodigoMaximo(idSucursal, idImpresora)
   End Function

#End Region

End Class