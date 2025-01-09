Option Explicit On
Option Strict On
Public Class Transportistas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Transportistas"
      da = New Datos.DataAccess()
   End Sub
   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Transportistas = New SqlServer.Transportistas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Transportistas(Me.da).Transportista_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim Transporte As Entidades.Transportista = DirectCast(entidad, Entidades.Transportista)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Transportistas = New SqlServer.Transportistas(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.Transportistas_I(Transporte.idTransportista, Transporte.NombreTransportista, _
                       Transporte.DireccionTransportista, Transporte.IdLocalidadTransportista, Transporte.CuitTransportista, Transporte.TelefonoTransportista, _
                       Transporte.CategoriaFiscal.IdCategoriaFiscal, Transporte.Observacion, Transporte.KilosMaximo, Transporte.PaletsMaximo, Transporte.Activo)

            Case TipoSP._U
               sql.Transportistas_U(Transporte.idTransportista, Transporte.NombreTransportista, _
                       Transporte.DireccionTransportista, Transporte.IdLocalidadTransportista, Transporte.CuitTransportista, Transporte.TelefonoTransportista, _
                        Transporte.CategoriaFiscal.IdCategoriaFiscal, Transporte.Observacion, Transporte.KilosMaximo, Transporte.PaletsMaximo, Transporte.Activo)

            Case TipoSP._D
               sql.Transportistas_D(Transporte.idTransportista)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Transportista, ByVal dr As DataRow)
      With o
         .idTransportista = Integer.Parse(dr("idTransportista").ToString())
         .NombreTransportista = dr("NombreTransportista").ToString()
         .DireccionTransportista = dr("DireccionTransportista").ToString()
         .IdLocalidadTransportista = Integer.Parse(dr("IdLocalidadTransportista").ToString())
         .NombreLocalidad = dr("NombreLocalidad").ToString()
         .TelefonoTransportista = dr("TelefonoTransportista").ToString()
         .CuitTransportista = dr("CuitTransportista").ToString()
         .CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Short.Parse(dr("IdCategoriaFiscalTransportista").ToString()))
         .KilosMaximo = Decimal.Parse(dr("KilosMaximo").ToString())
         .PaletsMaximo = Integer.Parse(dr("PaletsMaximo").ToString())
         .Activo = Boolean.Parse(dr("Activo").ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetUno(ByVal idTransportista As Long) As Entidades.Transportista
      Return GetUno(idTransportista, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(ByVal idTransportista As Long, accion As AccionesSiNoExisteRegistro) As Entidades.Transportista
      Return CargaEntidad(New SqlServer.Transportistas(Me.da).Transportista_G1(idTransportista, idTransportistaExacto:=True),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Transportista(),
                          accion, Function() String.Format("El Transportista {0} no existe. Por favor verifique.", idTransportista))
   End Function

   Public Function GetTodos() As List(Of Entidades.Transportista)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Transportista())
   End Function
   Public Function GetTodos(soloActivos As Boolean?) As List(Of Entidades.Transportista)
      Return CargaLista(New SqlServer.Transportistas(Me.da).Transportista_GA(soloActivos), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Transportista())
   End Function
   Public Function GetFiltradoPorCodigo(ByVal idTransportista As Long, Optional ByVal BusquedaParcial As Boolean = True) As DataTable
      Dim dt As DataTable = New SqlServer.Transportistas(Me.da).Transportista_G1(idTransportista, idTransportistaExacto:=True)
      If dt.Rows.Count = 0 And BusquedaParcial Then
         dt = New SqlServer.Transportistas(Me.da).Transportista_G1(idTransportista, idTransportistaExacto:=False)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorNombre(ByVal NombreTransportista As String) As DataTable
      Return New SqlServer.Transportistas(Me.da).GetFiltradoPorNombre(NombreTransportista)
   End Function
   Public Function GetFiltradoPorNombre(ByVal NombreTransportista As String, ByVal soloActivos As Boolean) As DataTable
      Return New SqlServer.Transportistas(Me.da).GetFiltradoPorNombre(NombreTransportista, soloActivos)
   End Function

   Public Function GetFiltradoPorDireccion(ByVal DireccionTransportista As String) As DataTable
      Return New SqlServer.Transportistas(Me.da).GetFiltradoPorDireccion(DireccionTransportista)
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Transportistas(da).GetCodigoMaximo()
   End Function
   Public Function GetCodigoMinimo() As Integer
      Return New SqlServer.Transportistas(da).GetCodigoMinimo()
   End Function

   Public Function GetExisteTransportitasEnCliente(idTransportista As Integer) As Boolean
      Dim sql As SqlServer.Transportistas = New SqlServer.Transportistas(Me.da)
      Dim dt As DataTable = sql.GetExisteTransportitasEnCliente(idTransportista)
      If dt.Rows.Count > 0 Then
         If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
            Return True
         End If
      End If

      Return False
   End Function
   Public Function GetExisteTransportitasEnRutas(idTransportista As Integer) As Boolean
      Dim sql As SqlServer.Transportistas = New SqlServer.Transportistas(Me.da)
      Dim dt As DataTable = sql.GetExisteTransportitasEnRutas(idTransportista)
      If dt.Rows.Count > 0 Then
         If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
            Return True
         End If
      End If
      Return False
   End Function
#End Region

End Class
