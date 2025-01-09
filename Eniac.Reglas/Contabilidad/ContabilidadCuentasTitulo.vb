Option Explicit On
Option Strict On

Imports System.Text

Public Class ContabilidadCuentasTitulo
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContabilidadCuentasTitulo"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ContabilidadCuentasTitulo"
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ContabilidadCuentasTitulos(Me.da).Cuentas_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.ContabilidadCuentaTitulo = DirectCast(entidad, Entidades.ContabilidadCuentaTitulo)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)

         Select Case tipo

            Case TipoSP._I ' alta cuentas 3
               'sql.Cuentas_I(sql.obtenerUltimaCuenta3(en.codCuenta.ToString) _
               '              , en.dscCuenta _
               '              , 3 _
               '              , CInt(0) _
               '              , False _
               '              , True)


            Case TipoSP._U ' cuentas 4
               sql.Cuentas_U(en.IdCuenta _
                             , en.NombreCuenta _
                             , en.IdCentroCosto _
                             , en.Activa)

            Case TipoSP._D
               sql.Cuentas_D(en.IdCuenta)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUna(ByVal o As Entidades.ContabilidadCuentaTitulo, ByVal dr As DataRow)
      With o
         .IdCuenta = Integer.Parse(dr(Entidades.ContabilidadCuentaTitulo.Columnas.IdCuenta.ToString()).ToString())
         .NombreCuenta = dr(Entidades.ContabilidadCuentaTitulo.Columnas.NombreCuenta.ToString()).ToString()
         .IdCentroCosto = Integer.Parse(dr(Entidades.ContabilidadCuentaTitulo.Columnas.IdCentroCosto.ToString()).ToString())
         .EsImputable = Boolean.Parse(dr(Entidades.ContabilidadCuentaTitulo.Columnas.EsImputable.ToString()).ToString())
         .Activa = Boolean.Parse(dr(Entidades.ContabilidadCuentaTitulo.Columnas.Activa.ToString()).ToString())
         .Nivel = Integer.Parse(dr(Entidades.ContabilidadCuentaTitulo.Columnas.Nivel.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ContabilidadCuentaTitulo)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ContabilidadCuentaTitulo
      Dim oLis As List(Of Entidades.ContabilidadCuentaTitulo) = New List(Of Entidades.ContabilidadCuentaTitulo)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ContabilidadCuentaTitulo()
         Me.CargarUna(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal codCuenta As Integer) As Entidades.ContabilidadCuentaTitulo
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Dim dt As DataTable = sql.Cuentas_G1(codCuenta)
      Dim o As Entidades.ContabilidadCuentaTitulo = New Entidades.ContabilidadCuentaTitulo()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Cuenta")
      End If
      Return o
   End Function

   Public Function Get1(ByVal codCuenta As Integer) As DataTable
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Return sql.Cuentas_G1(codCuenta)
   End Function

   Public Function GetPorNombre(ByVal dscCuenta As String) As DataTable
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Return sql.GetPorNombre(dscCuenta)
   End Function

   Public Function GetIdMaximo() As Integer
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Dim dt As DataTable = sql.Cuenta_GetIdMaximo()
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   ' para las de nivel 3
   Public Function TieneHijosLaCuenta(ByVal codCuenta As Integer) As Boolean
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)

      Return sql.TieneHijosLaCuenta(codCuenta)

   End Function

   Public Function GetNivel2(ByVal nivel1 As String) As DataTable
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Return sql.Cuentas_nivel2(nivel1)
   End Function

   Public Function GetNivel3(ByVal nivel2 As String) As DataTable
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Return sql.Cuentas_nivel3(nivel2)
   End Function

   Public Function GetNivel4(ByVal nivel3 As String) As DataTable
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Return sql.Cuentas_nivel4(nivel3)
   End Function

   Public Function GetNivel3ALL() As DataTable
      Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)
      Return sql.CuentasNivel3ALL
   End Function

   Public Sub GuardarCuentaNivel3(ByVal codCuenta As String, ByVal dscCuenta As String)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadCuentasTitulos = New SqlServer.ContabilidadCuentasTitulos(Me.da)

         sql.Cuentas_I(sql.obtenerUltimaCuenta3(codCuenta) _
                       , dscCuenta _
                       , 3 _
                       , 1 _
                       , False _
                       , True)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

End Class
