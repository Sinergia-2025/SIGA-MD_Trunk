Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class PadronesARBA
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   'Public Sub New()
   '   Me.NombreEntidad = "PadronARBA"
   '   da = New Datos.DataAccess()
   'End Sub

   Public Sub New(ByVal base As String)
      Me.DataBase = base
      Me.NombreEntidad = "PadronARBA"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "PadronARBA"
      da = accesoDatos
   End Sub

#End Region

   Private ReadOnly Property Base As String
      Get
         Return Ayudantes.Conexiones.Base
      End Get
   End Property

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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.PadronesARBA = New SqlServer.PadronesARBA(Me.da, Me.DataBase)
         Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Try
         Me.da.OpenConection()

         Return New SqlServer.PadronesARBA(Me.da, Me.DataBase).PadronARBA_GA()
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCodigoMaximo(PeriodoInformado As Integer) As Long
      Try
         Me.da.OpenConection()
         Return New SqlServer.PadronesARBA(Me.da, Me.DataBase).GetCodigoMaximo(PeriodoInformado)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetPadronARBAxCliente(CUIT As Long, PeriodoInformado As Integer, Regimen As String) As DataTable
      Try
         Me.da.OpenConection()
         Return New SqlServer.PadronesARBA(Me.da, Me.DataBase).GetPadronARBAxCliente(CUIT, PeriodoInformado, Regimen)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.PadronARBA = DirectCast(entidad, Entidades.PadronARBA)

         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sqlC As SqlServer.PadronesARBA = New SqlServer.PadronesARBA(da, Me.DataBase)
         Select Case tipo
            Case TipoSP._I
               sqlC.PadronARBA_I(en.IdPadronARBA,
                                           en.PeriodoInformado,
                                           en.TipoRegimen,
                                           en.FechaPublicacion,
                                           en.FechaVigenciaDesde,
                                           en.FechaVigenciaHasta,
                                           en.CUIT,
                                           en.TipoContribuyente,
                                           en.AccionARBA,
                                           en.CambioAlicuota,
                                           en.Alicuota,
                                           en.Grupo)
            Case TipoSP._U
               sqlC.PadronARBA_U(en.IdPadronARBA,
                                           en.PeriodoInformado,
                                           en.TipoRegimen,
                                           en.FechaPublicacion,
                                           en.FechaVigenciaDesde,
                                           en.FechaVigenciaHasta,
                                           en.CUIT,
                                           en.TipoContribuyente,
                                           en.AccionARBA,
                                           en.CambioAlicuota,
                                           en.Alicuota,
                                           en.Grupo)
            Case TipoSP._D
               sqlC.PadronARBA_D(en.IdPadronARBA,
                                           en.PeriodoInformado)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.PadronARBA, ByVal dr As DataRow)
      With o
         o.IdPadronARBA = Long.Parse(dr(PadronARBA.Columnas.IdPadronARBA.ToString()).ToString())
         o.PeriodoInformado = Int32.Parse((dr(PadronARBA.Columnas.PeriodoInformado.ToString()).ToString()))
         o.TipoRegimen = dr(PadronARBA.Columnas.TipoRegimen.ToString()).ToString()
         o.FechaPublicacion = DateTime.Parse(dr(PadronARBA.Columnas.FechaPublicacion.ToString()).ToString())
         o.FechaVigenciaDesde = DateTime.Parse(dr(PadronARBA.Columnas.FechaVigenciaDesde.ToString()).ToString())
         o.FechaVigenciaHasta = DateTime.Parse(dr(PadronARBA.Columnas.FechaVigenciaHasta.ToString()).ToString())
         o.CUIT = Long.Parse(dr(PadronARBA.Columnas.CUIT.ToString()).ToString())
         o.TipoContribuyente = dr(PadronARBA.Columnas.TipoContribuyente.ToString()).ToString()
         o.AccionARBA = dr(PadronARBA.Columnas.AccionARBA.ToString()).ToString()
         o.CambioAlicuota = Boolean.Parse(dr(PadronARBA.Columnas.CambioAlicuota.ToString()).ToString())
         o.Alicuota = Decimal.Parse(dr(PadronARBA.Columnas.Alicuota.ToString()).ToString())
         o.Grupo = Int32.Parse(dr(PadronARBA.Columnas.Grupo.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal CUIT As Long,
                          ByVal PeriodoInformado As Integer,
                          tipoRegimen As PadronARBA.TipoRegimenEnum) As Entidades.PadronARBA
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.PadronesARBA(Me.da, Me.DataBase).PadronARBA_G1(CUIT, PeriodoInformado, tipoRegimen)
         Dim o As Entidades.PadronARBA = New Entidades.PadronARBA()
         If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            Me.CargarUno(o, dt.Rows(0))
         End If
         Return o
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetTodas() As List(Of Entidades.PadronARBA)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.PadronARBA
      Dim oLis As List(Of Entidades.PadronARBA) = New List(Of Entidades.PadronARBA)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.PadronARBA()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Sub ImportarARBA(ByVal PeriodoInformado As Integer, ByVal dt As DataTable, pb As Windows.Forms.ProgressBar)
      Dim periodoTemporal As Integer = 999999
      Dim en As PadronARBA = New PadronARBA()
      Dim sqlC As SqlServer.PadronesARBA = Nothing
      Try
         da.OpenConection()
         ''da.BeginTransaction()
         sqlC = New SqlServer.PadronesARBA(da, Me.DataBase)

         sqlC.PadronARBA_D(Nothing, periodoTemporal)
         ''da.CommitTransaction()

         Dim idPadronARBA As Long = 0

         For Each dr As DataRow In dt.Rows
            idPadronARBA += 1
            dr(PadronARBA.Columnas.PeriodoInformado.ToString()) = periodoTemporal
            dr(PadronARBA.Columnas.IdPadronARBA.ToString()) = idPadronARBA

            CargarUno(en, dr)

            ''da.BeginTransaction()
            sqlC.PadronARBA_I(en.IdPadronARBA,
                                        en.PeriodoInformado,
                                        en.TipoRegimen,
                                        en.FechaPublicacion,
                                        en.FechaVigenciaDesde,
                                        en.FechaVigenciaHasta,
                                        en.CUIT,
                                        en.TipoContribuyente,
                                        en.AccionARBA,
                                        en.CambioAlicuota,
                                        en.Alicuota,
                                        en.Grupo)
            ''da.CommitTransaction()
         Next

         da.BeginTransaction()
         sqlC.PadronARBA_D(Nothing, PeriodoInformado)
         sqlC.PadronARBA_U(periodoTemporal, PeriodoInformado)
         PeriodoInformado = CInt(New DateTime(CInt(PeriodoInformado.ToString.Substring(0, 4)), CInt(PeriodoInformado.ToString.Substring(4, 2)), 1).AddMonths(-Publicos.CantidadPadronesARBAaGuardar).ToString("yyyyMM"))
         sqlC.PadronARBA_D(Nothing, PeriodoInformado, "LE")
         da.CommitTransaction()

      Catch
         If da.Transaction IsNot Nothing Then da.RollbakTransaction()
         sqlC.PadronARBA_D(Nothing, periodoTemporal)
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub ImportarARBADirecto(base As String, archivos As IList(Of String), periodoInformado As Integer)
      'Dim periodoTemporal As Integer = 999999
      Dim en As PadronARBA = New PadronARBA()
      Dim sqlC As SqlServer.PadronesARBA = Nothing
      Try
         Me.da.OpenConection()

         sqlC = New SqlServer.PadronesARBA(da, Me.DataBase)
         'sqlC.PadronARBA_D(Nothing, periodoTemporal)

         sqlC.PadronARBA_D_temp()

         For Each ar As String In archivos
            'copio todos los registros del archivo a la tabla SQL temporal
            sqlC.PadronARBA_Bulk(ar)
         Next

         Try
            Me.da.BeginTransaction()

            'elimino los datos del periodo informado
            sqlC.PadronARBA_D(Nothing, periodoInformado)

            'proceso los datos de la tabla temporal a la tabla definitiva
            sqlC.PadronARBA_ProcesarinfoARBA(periodoInformado)

            'sqlC.PadronARBA_U(periodoTemporal, periodoInformado)

            periodoInformado = Integer.Parse(New Date(Integer.Parse(periodoInformado.ToString("000000").Substring(0, 4)),
                                                      Integer.Parse(periodoInformado.ToString("000000").Substring(4, 2)),
                                                      1).AddMonths(-Publicos.CantidadPadronesARBAaGuardar).ToString("yyyyMM"))

            sqlC.PadronARBA_D(Nothing, periodoInformado, "LE")


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
