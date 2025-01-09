Public Class ClientesParametros
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.ClienteParametro.NombreTabla, accesoDatos)
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ClienteParametro)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ClienteParametro)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ClienteParametro)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ClientesParametros = New SqlServer.ClientesParametros(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ClientesParametros(da).ClientesParametros_GA()
   End Function
   Public Function GetInfClienteParametros(idCliente As Long, idParametro As String) As DataTable
      Return New SqlServer.ClientesParametros(da).GetInfClienteParametros(idCliente, idParametro)
   End Function
#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Entidades.ClienteParametro)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.ClienteParametro)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Merge(entidad As Entidades.ClienteParametro)
      EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub Merge(parametros As IEnumerable(Of Entidades.ClienteParametro))
      Dim sqlC = New SqlServer.ClientesParametros(da)
      sqlC.ClientesParametros_M(parametros)
   End Sub

   Public Sub _Borrar(entidad As Entidades.ClienteParametro)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.ClienteParametro, tipo As TipoSP)
      Dim sqlC = New SqlServer.ClientesParametros(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ClientesParametros_I(en.IdCliente, en.NombreServidor, en.BaseDatos, en.IdEmpresa, en.IdParametro, en.ValorParametro)
         Case TipoSP._U
            sqlC.ClientesParametros_U(en.IdCliente, en.NombreServidor, en.BaseDatos, en.IdEmpresa, en.IdParametro, en.ValorParametro)
         Case TipoSP._M
            sqlC.ClientesParametros_M(en.IdCliente, en.NombreServidor, en.BaseDatos, en.IdEmpresa, en.IdParametro, en.ValorParametro)
         Case TipoSP._D
            sqlC.ClientesParametros_D(en.IdCliente, en.NombreServidor, en.BaseDatos, en.IdEmpresa, en.IdParametro)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ClienteParametro, dr As DataRow)
      With o
         .IdCliente = dr.Field(Of Long)(Entidades.ClienteParametro.Columnas.IdCliente.ToString())
         .NombreServidor = dr.Field(Of String)(Entidades.ClienteParametro.Columnas.NombreServidor.ToString())
         .BaseDatos = dr.Field(Of String)(Entidades.ClienteParametro.Columnas.BaseDatos.ToString())
         .IdEmpresa = dr.Field(Of Integer)(Entidades.ClienteParametro.Columnas.IdEmpresa.ToString())
         .IdParametro = dr.Field(Of String)(Entidades.ClienteParametro.Columnas.IdParametro.ToString())
         .ValorParametro = dr.Field(Of String)(Entidades.ClienteParametro.Columnas.ValorParametro.ToString()).IfNull()
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idCliente As Long, nombreServidor As String, baseDatos As String, idEmpresa As Integer, idParametro As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.ClienteParametro
      Return CargaEntidad(New SqlServer.ClientesParametros(da).ClientesParametros_G1(idCliente, nombreServidor, baseDatos, idEmpresa, idParametro),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ClienteParametro(),
                          accion, String.Format("No se encontró el Parametro del Cliente"))
   End Function

   Public Function GetTodos() As List(Of Entidades.ClienteParametro)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ClienteParametro())
   End Function
   Public Function GetTodos(idCliente As Long, codigoCliente As Long, idParametros As String()) As List(Of Entidades.ClienteParametro)
      Return CargaLista(New SqlServer.ClientesParametros(da).ClientesParametros_GA(idCliente, codigoCliente, idParametros), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ClienteParametro())
   End Function

   Public Sub ImportarDesdeJson(codigoCliente As Long, nombreServidor As String, baseDatos As String, dcRemoto As Entidades.JSonEntidades.SSSServicioWeb.Parametro())
      EjecutaConTransaccion(
         Sub()
            Dim rCliente = New Clientes()
            Dim idCliente As Long
            Using dtClientes = rCliente.GetFiltradoPorCodigo(codigoCliente, False, False)
               If Not dtClientes.Any() Then
                  Throw New Exception(String.Format("No existe cliente con el código {0}", codigoCliente))
               End If
               idCliente = dtClientes.AsEnumerable().First().Field(Of Long)("IdCliente")
            End Using

            _Borrar(New Entidades.ClienteParametro() With {.IdCliente = idCliente})

            Try
               Merge(dcRemoto.ToList().ConvertAll(Function(dc) New Entidades.ClienteParametro() With
                                                               {
                                                                  .IdCliente = idCliente,
                                                                  .NombreServidor = nombreServidor,
                                                                  .BaseDatos = baseDatos,
                                                                  .IdEmpresa = dc.IdEmpresa,
                                                                  .IdParametro = dc.IdParametro,
                                                                  .ValorParametro = dc.ValorParametro
                                                               }))
            Catch ex As Exception
               'Si da error el Merge BULK lo intento uno por uno
               'Puede dar error con bases multi-empresa hasta solucionar el problema de fondo se debe arreglar de esta manera
               For Each dc As Entidades.JSonEntidades.SSSServicioWeb.Parametro In dcRemoto
                  Merge(New Entidades.ClienteParametro() With
                              {
                                 .IdCliente = idCliente,
                                 .NombreServidor = nombreServidor,
                                 .BaseDatos = baseDatos,
                                 .IdEmpresa = dc.IdEmpresa,
                                 .IdParametro = dc.IdParametro,
                                 .ValorParametro = dc.ValorParametro
                              })
               Next
            End Try
         End Sub)
   End Sub

   Public Sub ImportarDesdeJson(codigoCliente As Long, nombreServidor As String, baseDatos As String, idParametro As String, valorParametro As String)
      EjecutaConTransaccion(
         Sub()
            Dim rCliente = New Clientes()
            Dim idCliente As Long
            Using dtClientes = rCliente.GetFiltradoPorCodigo(codigoCliente, False, False)
               If Not dtClientes.Any() Then
                  Throw New Exception(String.Format("No existe cliente con el código {0}", codigoCliente))
               End If
               idCliente = dtClientes.AsEnumerable().First().Field(Of Long)("IdCliente")
            End Using

            Merge(New Entidades.ClienteParametro() With
                           {
                              .IdCliente = idCliente,
                              .NombreServidor = nombreServidor,
                              .BaseDatos = baseDatos,
                              .IdParametro = idParametro,
                              .ValorParametro = valorParametro
                           })

         End Sub)
   End Sub

   Public Sub ActualizarCliente(codigoCliente As Long)
      EjecutaConTransaccion(
         Sub()
            Dim version As String = String.Empty
            Dim fechaVersion As Date? = Nothing
            Dim vencimientoSistema As Date? = Nothing

            Dim parametros = GetTodos(idCliente:=0, codigoCliente:=codigoCliente, idParametros:={Entidades.Parametro.Parametros.VERSIONDB.ToString(), "FECHAVERSIONDB", "VENCIMIENTOSISTEMA"})
            For Each param In parametros
               Select Case param.IdParametro
                  Case Entidades.Parametro.Parametros.VERSIONDB.ToString()
                     Dim split As String() = param.ValorParametro.Split("."c)
                     If split.Length = 4 Then
                        Dim verNueva = String.Format("{0:00}.{1:00}.{2:00}.{3:00}", split)
                        If version < verNueva Then
                           version = verNueva
                        End If
                     End If
                  Case "FECHAVERSIONDB"
                     If IsDate(param.ValorParametro) Then
                        Dim fechaNueva = Date.Parse(param.ValorParametro)
                        If Not fechaVersion.HasValue OrElse fechaVersion.Value < fechaNueva Then
                           fechaVersion = fechaNueva
                        End If
                     End If
                  Case "VENCIMIENTOSISTEMA"
                     Try
                        Dim vencimiento As String = New Ayudantes.Criptografia().DecryptString128Bit(param.ValorParametro, "clave")
                        Dim fechaSplit() As String = vencimiento.Split(";"c)(0).Split("/"c)
                        Dim anio As Integer = Integer.Parse(fechaSplit(2))
                        If anio > 2100 Then anio = 4000
                        Dim vencNuevo = (New DateTime(anio, Integer.Parse(fechaSplit(1)), Integer.Parse(fechaSplit(0)))).AddDays(-1)
                        If Not vencimientoSistema.HasValue OrElse vencimientoSistema.Value < vencNuevo Then
                           vencimientoSistema = vencNuevo
                        End If
                     Catch ex As Exception
                        vencimientoSistema = Nothing
                     End Try
               End Select
            Next

            Dim sql = New SqlServer.ClientesParametros(da)
            sql.ActualizarCliente(codigoCliente, version, fechaVersion, vencimientoSistema)
         End Sub)
   End Sub

#End Region

End Class