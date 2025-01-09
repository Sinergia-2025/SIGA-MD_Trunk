#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class AuditoriaLoginWeb
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.AuditoriaLoginWeb.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.AuditoriaLoginWeb)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.AuditoriaLoginWeb)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.AuditoriaLoginWeb)))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.AuditoriaLoginWeb = New SqlServer.AuditoriaLoginWeb(Me.da)
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
      Return New SqlServer.AuditoriaLoginWeb(Me.da).AuditoriaLoginWeb_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Eniac.Entidades.AuditoriaLoginWeb)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Eniac.Entidades.AuditoriaLoginWeb)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Eniac.Entidades.AuditoriaLoginWeb)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.AuditoriaLoginWeb)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.AuditoriaLoginWeb, ByVal tipo As TipoSP)
      Dim sqlC As SqlServer.AuditoriaLoginWeb = New SqlServer.AuditoriaLoginWeb(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.AuditoriaLoginWeb_I(en)
         Case TipoSP._U
          '  sqlC.aues_U(en)
         Case TipoSP._D
            sqlC.AuditoriaLoginWeb_D(en.Id)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.AuditoriaLoginWeb, ByVal dr As DataRow)
      With o
         .Id = Long.Parse(dr(Entidades.AuditoriaLoginWeb.Columnas.Id.ToString()).ToString())
         .nombre_usuario = dr(Entidades.AuditoriaLoginWeb.Columnas.nombre_usuario.ToString()).ToString()
         .estado_registro = dr(Entidades.AuditoriaLoginWeb.Columnas.estado_registro.ToString()).ToString()

         'If Not IsDBNull(dr(Entidades.AuditoriaLoginWeb.Columnas.IdAreaComun.ToString())) Then
         '   .AreaComun = New AreasComunes(Me.da).GetUno(dr(Entidades.Sector.Columnas.IdAreaComun.ToString()).ToString())
         'End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(ByVal id As Long) As Entidades.AuditoriaLoginWeb
      Dim dt As DataTable = New SqlServer.AuditoriaLoginWeb(Me.da).AuditoriaLoginWeb_G1(id)
      Dim o As Entidades.AuditoriaLoginWeb = New Entidades.AuditoriaLoginWeb()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function


   Public Function GetTodos() As List(Of Entidades.AuditoriaLoginWeb)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.AuditoriaLoginWeb), dr), Function() New Entidades.AuditoriaLoginWeb())
   End Function

   Public Function GetAuditoria(id As Long) As DataTable
      Dim dt As DataTable = New SqlServer.AuditoriaLoginWeb(Me.da).AuditoriaLoginWeb_G1(id)
      Return dt
   End Function

   'Public Function GetCodigoMaximo() As Short
   '   Return Convert.ToInt16(GetCodigoMaximo(Entidades.Sector.Columnas.IdSector.ToString()))
   'End Function
   'Public Function GetCodigoMaximo(ByVal campo As String) As Long
   '   Return New SqlServer.Sectores(Me.da).GetCodigoMaximo(campo)
   'End Function

   'Public Sub MigrarSectores(Sectores As DataTable, BarraProg As System.Windows.Forms.ProgressBar)
   '   Try

   '      da.OpenConection()
   '      da.BeginTransaction()

   '      Dim i As Integer = 0

   '      BarraProg.Maximum = Sectores.Rows.Count
   '      BarraProg.Minimum = 0
   '      BarraProg.Value = 0

   '      Dim Sector As Entidades.Sector
   '      For Each dr As DataRow In Sectores.Rows
   '         i += 1
   '         BarraProg.Value = i

   '         Sector = New Entidades.Sector
   '         Sector.IdSector = Short.Parse(dr("secCodigo").ToString())
   '         Sector.NombreSector = dr("SecSector").ToString()

   '         _Merge(Sector)

   '      Next

   '      da.CommitTransaction()

   '   Catch ex As Exception
   '      BarraProg.Value = 0
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try

   'End Sub

   Public Function GetTodas() As List(Of Entidades.AuditoriaLoginWeb)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.AuditoriaLoginWeb
      Dim oLis As List(Of Entidades.AuditoriaLoginWeb) = New List(Of Entidades.AuditoriaLoginWeb)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.AuditoriaLoginWeb()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetAuditorias(Login As DateTime, Logout As DateTime, usuario As String) As DataTable
      Dim dt As DataTable = New SqlServer.AuditoriaLoginWeb(Me.da).GetAuditoriasLoginWeb(Login, Logout, usuario)
      Return dt
   End Function

   Public Function GetUsuariosAuditorias() As DataTable
      Dim dt As DataTable = New SqlServer.AuditoriaLoginWeb(Me.da).GetUsuariosAuditoriasLoginWeb()
      Return dt
   End Function
#End Region

End Class