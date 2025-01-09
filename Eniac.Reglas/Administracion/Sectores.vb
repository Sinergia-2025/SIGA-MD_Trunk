#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class Sectores
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Sector.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Sector)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Sector)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Sector)))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Sectores = New SqlServer.Sectores(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   'Public Overrides Function GetAll() As System.Data.DataTable ' se aplica la regla para traer todos los registros asociados al cliente
   '   Return New SqlServer.Sectores(Me.da).Sectores_GA()
   'End Function
   'Public Function InfClientesActualizaciones(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
   '   Return New SqlServer.ClientesActualizaciones(Me.da).GetInfClientesActualizaciones(idCliente, fechaDesde, fechaHasta)
   'End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(False)
   End Function

   Public Overloads Function GetAll(activas As Boolean) As System.Data.DataTable
      Return New SqlServer.Sectores(Me.da).Sectores_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Eniac.Entidades.Sector)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Eniac.Entidades.Sector)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Eniac.Entidades.Sector)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.Sector)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.Sector, ByVal tipo As TipoSP)
      Dim sqlC As SqlServer.Sectores = New SqlServer.Sectores(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Sectores_I(en)
         Case TipoSP._U
            sqlC.Sectores_U(en)
         Case TipoSP._D
            sqlC.Sectores_D(en.IdSector)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Sector, ByVal dr As DataRow)
      With o
         .IdSector = Short.Parse(dr(Entidades.Sector.Columnas.IdSector.ToString()).ToString())
         .NombreSector = dr(Entidades.Sector.Columnas.NombreSector.ToString()).ToString()
         .Observaciones = dr(Entidades.Sector.Columnas.Observaciones.ToString()).ToString()
         If Not IsDBNull(dr(Entidades.Sector.Columnas.IdAreaComun.ToString())) Then
            .AreaComun = New AreasComunes(Me.da).GetUno(dr(Entidades.Sector.Columnas.IdAreaComun.ToString()).ToString())
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(ByVal idMotor As Integer) As Entidades.Sector
      Dim dt As DataTable = New SqlServer.Sectores(Me.da).Sectores_G1(idMotor)
      Dim o As Entidades.Sector = New Entidades.Sector()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function


   Public Function GetTodos() As List(Of Entidades.Sector)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.Sector), dr), Function() New Entidades.Sector())
   End Function
   Public Function GetCodigoMaximo() As Short
      Return Convert.ToInt16(GetCodigoMaximo(Entidades.Sector.Columnas.IdSector.ToString()))
   End Function
   Public Function GetCodigoMaximo(ByVal campo As String) As Long
      Return New SqlServer.Sectores(Me.da).GetCodigoMaximo(campo)
   End Function

   Public Sub MigrarSectores(Sectores As DataTable, BarraProg As System.Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim i As Integer = 0

         BarraProg.Maximum = Sectores.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         Dim Sector As Entidades.Sector
         For Each dr As DataRow In Sectores.Rows
            i += 1
            BarraProg.Value = i

            Sector = New Entidades.Sector
            Sector.IdSector = Short.Parse(dr("secCodigo").ToString())
            Sector.NombreSector = dr("SecSector").ToString()

            _Merge(Sector)

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

   Public Function GetTodas() As List(Of Entidades.Sector)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Sector
      Dim oLis As List(Of Entidades.Sector) = New List(Of Entidades.Sector)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Sector()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region

End Class