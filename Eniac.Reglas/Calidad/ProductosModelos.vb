Option Explicit On
Option Strict On
Public Class ProductosModelos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.ProductoModelo.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProductoModelo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModelo), TipoSP._I)
   End Sub
   Public Sub _Actualiza(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModelo), TipoSP._U)
   End Sub
   Public Sub _Borra(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModelo), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModelo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModelo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModelo), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.ProductosModelos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ProductosModelos(da).GetCodigoMaximo() + 1
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sListasControlTipos As SqlServer.ProductosModelos = New SqlServer.ProductosModelos(da)
      Return sListasControlTipos.ProductosModelos_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(idProductoModelo As Integer) As Entidades.ProductoModelo
      Dim sProductosModelos As SqlServer.ProductosModelos = New SqlServer.ProductosModelos(da)
      Return CargaEntidad(sProductosModelos.ProductosModelos_G1(idProductoModelo),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoModelo(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Tipo de Lista de Control {0}", idProductoModelo))
   End Function

   Public Function GetUnoxCodigo(CodigoProductoModelo As String) As Entidades.ProductoModelo
      Dim sProductosModelos As SqlServer.ProductosModelos = New SqlServer.ProductosModelos(da)
      Return CargaEntidad(sProductosModelos.ProductosModelos_G1xCodigo(CodigoProductoModelo),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoModelo(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Tipo de Lista de Control {0}", CodigoProductoModelo))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProductoModelo)
      Dim dt As DataTable = Me.GetAll()
      Dim eProductoModelo As Entidades.ProductoModelo
      Dim lista As List(Of Entidades.ProductoModelo) = New List(Of Entidades.ProductoModelo)
      For Each dr As DataRow In dt.Rows
         eProductoModelo = New Entidades.ProductoModelo()
         Me.CargarUno(eProductoModelo, dr)
         lista.Add(eProductoModelo)
      Next
      Return lista
   End Function

   Public Function ListasDeControlFueraDeRango(rangoDesde As Integer,
                                               rangoHasta As Integer,
                                               idTipoListaControl As Integer) As DataTable
      Return New SqlServer.ListasControlTipos(da).ListasDeControlFueraDeRango(rangoDesde, rangoHasta, idTipoListaControl)
   End Function

   Public Function ConsultarSolapamientoListasDeControl(rangoDesde As Integer,
                                                     rangoHasta As Integer,
                                                     idTipoListaControl As Integer) As DataTable
      Return New SqlServer.ListasControlTipos(da).ConsultarSolapamientoListasDeControl(rangoDesde, rangoHasta, idTipoListaControl)
   End Function

   Public Function GetPorNombre(ProductoModelo As String) As DataTable
      Dim sProductosModelos As SqlServer.ProductosModelos = New SqlServer.ProductosModelos(da)
      Return sProductosModelos.ProductosModelos_GetPorNombre(ProductoModelo)
   End Function
#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProductoModelo, tipo As TipoSP)
      Dim sProductosModelos As SqlServer.ProductosModelos = New SqlServer.ProductosModelos(da)
      Select Case tipo
         Case TipoSP._I
            If en.IdProductoModelo = 0 Then
               en.IdProductoModelo = Me.GetCodigoMaximo()
            End If
            sProductosModelos.ProductosModelos_I(en.IdProductoModelo,
                                                               en.NombreProductoModelo,
                                                               en.CodigoProductoModelo,
                                                               en.IdProductoModeloTipo,
                                                               en.IdProductoModeloSubTipo)
         Case TipoSP._U
            sProductosModelos.ProductosModelos_U(en.IdProductoModelo,
                                                               en.NombreProductoModelo,
                                                               en.CodigoProductoModelo,
                                                               en.IdProductoModeloTipo,
                                                               en.IdProductoModeloSubTipo)
         Case TipoSP._D
            sProductosModelos.ProductosModelos_D(en.IdProductoModelo)
      End Select
   End Sub

   Private Sub CargarUno(eProductoModelo As Entidades.ProductoModelo, dr As DataRow)
      With eProductoModelo
         .IdProductoModelo = dr.Field(Of Integer)(Entidades.ProductoModelo.Columnas.IdProductoModelo.ToString())
         .NombreProductoModelo = dr.Field(Of String)(Entidades.ProductoModelo.Columnas.NombreProductoModelo.ToString())
         .CodigoProductoModelo = dr.Field(Of String)(Entidades.ProductoModelo.Columnas.CodigoProductoModelo.ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.ProductoModelo.Columnas.IdProductoModeloTipo.ToString()).ToString()) Then
            .IdProductoModeloTipo = dr.Field(Of Integer)(Entidades.ProductoModelo.Columnas.IdProductoModeloTipo.ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.ProductoModelo.Columnas.IdProductoModeloSubTipo.ToString()).ToString()) Then
            .IdProductoModeloSubTipo = dr.Field(Of Integer)(Entidades.ProductoModelo.Columnas.IdProductoModeloSubTipo.ToString())
         End If

      End With
   End Sub
   Public Function GetModelosBejerman(ByVal Base As String) As DataTable
      Dim sql As SqlServer.ProductosModelos
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.ProductosModelos(da)

         dt = sql.GetModelosBejerman(Base)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function ExisteCodigoModelo(ByVal codigoModelo As String) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendFormat("SELECT COUNT(CodigoProductoModelo) AS Existe FROM CalidadProductosModelos WHERE CodigoProductoModelo = '{0}'", codigoModelo.Trim())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Sub ImportarModelosBejerman(ByVal IdSucursal As Integer,
                             ByVal datos As DataTable,
                             ByVal usuario As String,
                             ByRef BarraProg As System.Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = datos

         Dim oProductosModelos As Eniac.Reglas.ProductosModelos = New Eniac.Reglas.ProductosModelos(da)
         Dim ExisteModelo As Boolean
         Dim Modelo As Entidades.ProductoModelo = New Entidades.ProductoModelo

         Dim i As Integer = 0

         BarraProg.Maximum = dt.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         For Each dr As DataRow In dt.Rows

            i += 1
            BarraProg.Value = i

            If Boolean.Parse(dr("Importa").ToString()) Then

               ExisteModelo = oProductosModelos.ExisteCodigoModelo(dr("CodigoProductoModelo").ToString())

               If Not ExisteModelo Then
                  Modelo = New Entidades.ProductoModelo

                  Modelo.IdProductoModelo = 0

                  Modelo.NombreProductoModelo = Strings.Trim(dr("NombreProductoModelo").ToString.Trim())

                  Modelo.CodigoProductoModelo = dr("CodigoProductoModelo").ToString().Trim()
                  oProductosModelos._Inserta(Modelo)
               Else
                  Modelo = oProductosModelos.GetUnoxCodigo(dr("CodigoProductoModelo").ToString().Trim())
                  Modelo.NombreProductoModelo = Strings.Trim(dr("NombreProductoModelo").ToString.Trim())
                  oProductosModelos._Actualiza(Modelo)

               End If

            End If
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
