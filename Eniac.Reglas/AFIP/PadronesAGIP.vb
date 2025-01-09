Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class PadronesAGIP
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   'Public Sub New()
   '   Me.NombreEntidad = "PadronAGIP"
   '   da = New Datos.DataAccess()
   'End Sub

   Public Sub New(ByVal base As String)
      Me.DataBase = base
      Me.NombreEntidad = "PadronAGIP"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "PadronAGIP"
      da = accesoDatos
   End Sub

#End Region

   Private ReadOnly Property Base As String
      Get
         Return Ayudantes.Conexiones.Base
      End Get
   End Property

   '#Region "Overrides"

   '   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
   '      Me.EjecutaSP(entidad, TipoSP._I)
   '   End Sub

   '   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
   '      Me.EjecutaSP(entidad, TipoSP._U)
   '   End Sub

   '   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
   '      Me.EjecutaSP(entidad, TipoSP._D)
   '   End Sub

   '   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
   '      Try
   '         Me.da.OpenConection()
   '         Dim sql As SqlServer.PadronesAGIP = New SqlServer.PadronesAGIP(Me.da, Me.DataBase)
   '         Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   '      Catch ex As Exception
   '         Throw
   '      Finally
   '         Me.da.CloseConection()
   '      End Try
   '   End Function

   '   Public Overrides Function GetAll() As System.Data.DataTable
   '      Try
   '         Me.da.OpenConection()

   '         Return New SqlServer.PadronesAGIP(Me.da, Me.DataBase).PadronAGIP_GA()
   '      Catch ex As Exception
   '         Throw
   '      Finally
   '         Me.da.CloseConection()
   '      End Try
   '   End Function

   '   Public Function GetCodigoMaximo(PeriodoInformado As Integer) As Long
   '      Try
   '         Me.da.OpenConection()
   '         Return New SqlServer.PadronesAGIP(Me.da, Me.DataBase).GetCodigoMaximo(PeriodoInformado)
   '      Catch ex As Exception
   '         Throw
   '      Finally
   '         Me.da.CloseConection()
   '      End Try
   '   End Function

   '   Public Function GetPadronAGIPxCliente(CUIT As Long, PeriodoInformado As Integer, Regimen As String) As DataTable
   '      Try
   '         Me.da.OpenConection()
   '         Return New SqlServer.PadronesAGIP(Me.da, Me.DataBase).GetPadronAGIPxCliente(CUIT, PeriodoInformado, Regimen)
   '      Catch ex As Exception
   '         Throw
   '      Finally
   '         Me.da.CloseConection()
   '      End Try
   '   End Function

   '#End Region

   '#Region "Metodos Privados"

   '   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
   '      Try
   '         Dim en As Entidades.PadronAGIP = DirectCast(entidad, Entidades.PadronAGIP)

   '         Me.da.OpenConection()
   '         Me.da.BeginTransaction()

   '         Dim sqlC As SqlServer.PadronesAGIP = New SqlServer.PadronesAGIP(da, Me.DataBase)
   '         Select Case tipo
   '            Case TipoSP._I
   '               sqlC.PadronAGIP_I(en.IdPadronAGIP,
   '                                           en.PeriodoInformado,
   '                                           en.TipoRegimen,
   '                                           en.FechaPublicacion,
   '                                           en.FechaVigenciaDesde,
   '                                           en.FechaVigenciaHasta,
   '                                           en.CUIT,
   '                                           en.TipoContribuyente,
   '                                           en.AccionAGIP,
   '                                           en.CambioAlicuota,
   '                                           en.Alicuota,
   '                                           en.Grupo)
   '            Case TipoSP._U
   '               sqlC.PadronAGIP_U(en.IdPadronAGIP,
   '                                           en.PeriodoInformado,
   '                                           en.TipoRegimen,
   '                                           en.FechaPublicacion,
   '                                           en.FechaVigenciaDesde,
   '                                           en.FechaVigenciaHasta,
   '                                           en.CUIT,
   '                                           en.TipoContribuyente,
   '                                           en.AccionAGIP,
   '                                           en.CambioAlicuota,
   '                                           en.Alicuota,
   '                                           en.Grupo)
   '            Case TipoSP._D
   '               sqlC.PadronAGIP_D(en.IdPadronAGIP,
   '                                           en.PeriodoInformado)
   '         End Select

   '         da.CommitTransaction()
   '      Catch
   '         da.RollbakTransaction()
   '         Throw
   '      Finally
   '         da.CloseConection()
   '      End Try
   '   End Sub

   '   Private Sub CargarUno(ByVal o As Entidades.PadronAGIP, ByVal dr As DataRow)
   '      With o
   '         o.IdPadronAGIP = Long.Parse(dr(PadronAGIP.Columnas.IdPadronAGIP.ToString()).ToString())
   '         o.PeriodoInformado = Int32.Parse((dr(PadronAGIP.Columnas.PeriodoInformado.ToString()).ToString()))
   '         o.TipoRegimen = dr(PadronAGIP.Columnas.TipoRegimen.ToString()).ToString()
   '         o.FechaPublicacion = DateTime.Parse(dr(PadronAGIP.Columnas.FechaPublicacion.ToString()).ToString())
   '         o.FechaVigenciaDesde = DateTime.Parse(dr(PadronAGIP.Columnas.FechaVigenciaDesde.ToString()).ToString())
   '         o.FechaVigenciaHasta = DateTime.Parse(dr(PadronAGIP.Columnas.FechaVigenciaHasta.ToString()).ToString())
   '         o.CUIT = Long.Parse(dr(PadronAGIP.Columnas.CUIT.ToString()).ToString())
   '         o.TipoContribuyente = dr(PadronAGIP.Columnas.TipoContribuyente.ToString()).ToString()
   '         o.AccionAGIP = dr(PadronAGIP.Columnas.AccionAGIP.ToString()).ToString()
   '         o.CambioAlicuota = Boolean.Parse(dr(PadronAGIP.Columnas.CambioAlicuota.ToString()).ToString())
   '         o.Alicuota = Decimal.Parse(dr(PadronAGIP.Columnas.Alicuota.ToString()).ToString())
   '         o.Grupo = Int32.Parse(dr(PadronAGIP.Columnas.Grupo.ToString()).ToString())
   '      End With
   '   End Sub

   '#End Region

#Region "Metodos publicos"

   'Public Function GetUno(ByVal CUIT As Long,
   '                       ByVal PeriodoInformado As Integer,
   '                       tipoRegimen As PadronAGIP.TipoRegimenEnum) As Entidades.PadronAGIP
   '   Try
   '      Me.da.OpenConection()
   '      Dim dt As DataTable = New SqlServer.PadronesAGIP(Me.da, Me.DataBase).PadronAGIP_G1(CUIT, PeriodoInformado, tipoRegimen)
   '      Dim o As Entidades.PadronAGIP = New Entidades.PadronAGIP()
   '      If dt.Rows.Count > 0 Then
   '         Dim dr As DataRow = dt.Rows(0)
   '         Me.CargarUno(o, dt.Rows(0))
   '      End If
   '      Return o
   '   Catch ex As Exception
   '      Throw
   '   Finally
   '      Me.da.CloseConection()
   '   End Try
   'End Function

   'Public Function GetTodas() As List(Of Entidades.PadronAGIP)
   '   Dim dt As DataTable = Me.GetAll()
   '   Dim o As Entidades.PadronAGIP
   '   Dim oLis As List(Of Entidades.PadronAGIP) = New List(Of Entidades.PadronAGIP)
   '   For Each dr As DataRow In dt.Rows
   '      o = New Entidades.PadronAGIP()
   '      Me.CargarUno(o, dr)
   '      oLis.Add(o)
   '   Next
   '   Return oLis
   'End Function

   'Public Sub ImportarAGIP(ByVal PeriodoInformado As Integer, ByVal dt As DataTable, pb As Windows.Forms.ProgressBar)
   '   Dim periodoTemporal As Integer = 999999
   '   Dim en As PadronAGIP = New PadronAGIP()
   '   Dim sqlC As SqlServer.PadronesAGIP = Nothing
   '   Try
   '      da.OpenConection()
   '      ''da.BeginTransaction()
   '      sqlC = New SqlServer.PadronesAGIP(da, Me.DataBase)

   '      sqlC.PadronAGIP_D(Nothing, periodoTemporal)
   '      ''da.CommitTransaction()

   '      Dim idPadronAGIP As Long = 0

   '      For Each dr As DataRow In dt.Rows
   '         idPadronAGIP += 1
   '         dr(PadronAGIP.Columnas.PeriodoInformado.ToString()) = periodoTemporal
   '         dr(PadronAGIP.Columnas.IdPadronAGIP.ToString()) = idPadronAGIP

   '         CargarUno(en, dr)

   '         ''da.BeginTransaction()
   '         sqlC.PadronAGIP_I(en.IdPadronAGIP,
   '                                     en.PeriodoInformado,
   '                                     en.TipoRegimen,
   '                                     en.FechaPublicacion,
   '                                     en.FechaVigenciaDesde,
   '                                     en.FechaVigenciaHasta,
   '                                     en.CUIT,
   '                                     en.TipoContribuyente,
   '                                     en.AccionAGIP,
   '                                     en.CambioAlicuota,
   '                                     en.Alicuota,
   '                                     en.Grupo)
   '         ''da.CommitTransaction()
   '      Next

   '      da.BeginTransaction()
   '      sqlC.PadronAGIP_D(Nothing, PeriodoInformado)
   '      sqlC.PadronAGIP_U(periodoTemporal, PeriodoInformado)
   '      PeriodoInformado = CInt(New DateTime(CInt(PeriodoInformado.ToString.Substring(0, 4)), CInt(PeriodoInformado.ToString.Substring(4, 2)), 1).AddMonths(-2).ToString("yyyyMM"))
   '      sqlC.PadronAGIP_D(Nothing, PeriodoInformado, "LE")
   '      da.CommitTransaction()

   '   Catch
   '      If da.Transaction IsNot Nothing Then da.RollbakTransaction()
   '      sqlC.PadronAGIP_D(Nothing, periodoTemporal)
   '      Throw
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Sub

   Public Sub ImportarAGIPDirecto(base As String, archivos As IList(Of String), periodoInformado As Integer)
      'Dim periodoTemporal As Integer = 999999
      Dim en As PadronAGIP = New PadronAGIP()
      Dim sqlC As SqlServer.PadronesAGIP = Nothing
      Try
         Me.da.OpenConection()

         sqlC = New SqlServer.PadronesAGIP(da, Me.DataBase)
         'sqlC.PadronAGIP_D(Nothing, periodoTemporal)

         sqlC.PadronAGIP_D_temp()

         For Each ar As String In archivos
            'copio todos los registros del archivo a la tabla SQL temporal
            sqlC.PadronAGIP_Bulk(ar)
         Next

         Try
            Me.da.BeginTransaction()

            'elimino los datos del periodo informado
            sqlC.PadronAGIP_D(Nothing, periodoInformado)

            'proceso los datos de la tabla temporal a la tabla definitiva
            sqlC.PadronAGIP_ProcesarinfoAGIP(periodoInformado)

            'sqlC.PadronAGIP_U(periodoTemporal, periodoInformado)

            periodoInformado = Integer.Parse(New Date(Integer.Parse(periodoInformado.ToString("000000").Substring(0, 4)),
                                                      Integer.Parse(periodoInformado.ToString("000000").Substring(4, 2)),
                                                      1).AddMonths(-2).ToString("yyyyMM"))

            sqlC.PadronAGIP_D(Nothing, periodoInformado, "LE")
            Me.da.CommitTransaction()
         Catch
            Me.da.RollbakTransaction()
            Throw
         End Try

      Catch ex As Exception
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

End Class
