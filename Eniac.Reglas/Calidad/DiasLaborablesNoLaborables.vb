#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class DiasLaborablesNoLaborables
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "DiaLaborableNoLaborable"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "DiaLaborableNoLaborable"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.DiaLaborableNoLaborable), TipoSP._I)
   End Sub
   Public Sub _Actualiza(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.DiaLaborableNoLaborable), TipoSP._U)
   End Sub
   Public Sub _Borra(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.DiaLaborableNoLaborable), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DiaLaborableNoLaborable), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DiaLaborableNoLaborable), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DiaLaborableNoLaborable), TipoSP._D))
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sDias As SqlServer.DiasLaborablesNoLaborables = New SqlServer.DiasLaborablesNoLaborables(da)
      Return sDias.DiasLaborablesNoLaborables_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.DiaLaborableNoLaborable = DirectCast(entidad, Entidades.DiaLaborableNoLaborable)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.DiasLaborablesNoLaborables = New SqlServer.DiasLaborablesNoLaborables(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.DiasLaborablesNoLaborables_I(en.Dia, en.Laborable)
            Case TipoSP._U
               sqlC.DiasLaborablesNoLaborables_U(en.Dia, en.Laborable)
            Case TipoSP._D
               sqlC.DiasLaborablesNoLaborables_D(en.Dia)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.DiaLaborableNoLaborable, ByVal dr As DataRow)
      With o
         .Dia = Date.Parse(dr(Entidades.DiaLaborableNoLaborable.Columnas.Dia.ToString()).ToString())
         .Laborable = Boolean.Parse(dr(Entidades.DiaLaborableNoLaborable.Columnas.Laborable.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Function GetUno(Dia As Date) As Entidades.DiaLaborableNoLaborable
      Dim sDias As SqlServer.DiasLaborablesNoLaborables = New SqlServer.DiasLaborablesNoLaborables(da)
      Return CargaEntidad(sDias.DiasLaborablesNoLaborables_G1(Dia),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.DiaLaborableNoLaborable(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No se generó el Día {0}", Dia.ToString("dd/MM/yyyy")))
   End Function

   Public Function GetTodos() As List(Of Entidades.DiaLaborableNoLaborable)
      Dim dt As DataTable = New SqlServer.DiasLaborablesNoLaborables(da).DiasLaborablesNoLaborables_GA()
      Dim o As Entidades.DiaLaborableNoLaborable
      Dim oLis As List(Of Entidades.DiaLaborableNoLaborable) = New List(Of Entidades.DiaLaborableNoLaborable)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.DiaLaborableNoLaborable()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Sub GrabarDias(Dias As DateTime())
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim DiaLNL As Entidades.DiaLaborableNoLaborable
         For Each dr As Date In Dias
            DiaLNL = New Entidades.DiaLaborableNoLaborable
            DiaLNL.Dia = Date.Parse(dr.ToString("dd/MM/yyyy"))
            Select Case Date.Parse(dr.ToString("dd/MM/yyyy")).DayOfWeek
               Case DayOfWeek.Monday
                  DiaLNL.Laborable = True
               Case DayOfWeek.Tuesday
                  DiaLNL.Laborable = True
               Case DayOfWeek.Wednesday
                  DiaLNL.Laborable = True
               Case DayOfWeek.Thursday
                  DiaLNL.Laborable = True
               Case DayOfWeek.Friday
                  DiaLNL.Laborable = True
               Case DayOfWeek.Saturday
                  DiaLNL.Laborable = False
               Case DayOfWeek.Sunday
                  DiaLNL.Laborable = False
            End Select
            If Not ExisteDia(Date.Parse(dr.ToString("dd/MM/yyyy"))) Then
               _Inserta(DiaLNL)
            End If
         Next
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try





   End Sub

   Public Function ExisteDia(Dia As Date) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendFormat("SELECT COUNT(Dia) AS Existe FROM CalidadDiaslaborablesNoLaborables WHERE Dia = '{0}'", Dia.ToString("dd/MM/yyyy"))
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function GetDiasLNL(desde As Date, hasta As Date) As DataTable
      Dim dt As DataTable = New SqlServer.DiasLaborablesNoLaborables(da).DiasLaborablesNoLaborables_GxFechas(desde, hasta)
      Return dt
   End Function

#End Region

End Class