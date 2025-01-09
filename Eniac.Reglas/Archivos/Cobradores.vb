Option Strict On
Option Explicit On
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class Cobradores
   Inherits Eniac.Reglas.Base


#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Cobradores"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Cobradores"
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Cobradores = New SqlServer.Cobradores(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Cobradores(Me.da).Cobradores_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Eniac.Entidades.Cobrador = DirectCast(entidad, Eniac.Entidades.Cobrador)

      Try
         da.OpenConection()
         da.BeginTransaction()


         Dim sql As SqlServer.Cobradores = New SqlServer.Cobradores(Me.da)
         Dim rCobradoresSucursales As CobradoresSucursales = New CobradoresSucursales(da)

         Select Case tipo

            Case TipoSP._I
               sql.Cobradores_I(en.IdCobrador, en.NombreCobrador, en.DebitoDirecto, en.IdBanco, en.IdDispositivo)
               en.CobradorSucursal.IdSucursal = actual.Sucursal.IdSucursal
               en.CobradorSucursal.IdCobrador = en.IdCobrador
               rCobradoresSucursales.InsertaOActualiza(en.CobradorSucursal)

            Case TipoSP._U
               sql.Cobradores_U(en.IdCobrador, en.NombreCobrador, en.DebitoDirecto, en.IdBanco, en.IdDispositivo)
               en.CobradorSucursal.IdSucursal = actual.Sucursal.IdSucursal
               en.CobradorSucursal.IdCobrador = en.IdCobrador
               rCobradoresSucursales.InsertaOActualiza(en.CobradorSucursal)

            Case TipoSP._D
               rCobradoresSucursales.Borrar(en.IdCobrador)
               sql.Cobradores_D(en.IdCobrador)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(ByVal o As Eniac.Entidades.Cobrador, ByVal dr As DataRow)
      With o
         .IdCobrador = Integer.Parse(dr(Eniac.Entidades.Cobrador.Columnas.IdCobrador.ToString()).ToString())
         .NombreCobrador = dr(Eniac.Entidades.Cobrador.Columnas.NombreCobrador.ToString()).ToString()
         .DebitoDirecto = Boolean.Parse(dr(Eniac.Entidades.Cobrador.Columnas.DebitoDirecto.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Eniac.Entidades.Cobrador.Columnas.IdBanco.ToString()).ToString()) Then
            .IdBanco = Integer.Parse(dr(Eniac.Entidades.Cobrador.Columnas.IdBanco.ToString()).ToString())
         End If
         .NombreBanco = dr(Eniac.Entidades.Cobrador.Columnas.NombreBanco.ToString()).ToString()
         .IdDispositivo = dr(Eniac.Entidades.Cobrador.Columnas.IdDispositivo.ToString()).ToString()

         .CobradorSucursal = New CobradoresSucursales(da).GetUno(actual.Sucursal.IdSucursal, .IdCobrador)

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Eniac.Entidades.Cobrador)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Eniac.Entidades.Cobrador
      Dim oLis As List(Of Eniac.Entidades.Cobrador) = New List(Of Eniac.Entidades.Cobrador)
      For Each dr As DataRow In dt.Rows
         o = New Eniac.Entidades.Cobrador()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal IdCobrador As Integer) As Eniac.Entidades.Cobrador
      Try
         Me.da.OpenConection()
         Return Me._GetUno(IdCobrador)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function _GetUno(ByVal IdCobrador As Integer) As Eniac.Entidades.Cobrador
      Dim sql As SqlServer.Cobradores = New SqlServer.Cobradores(Me.da)
      Dim dt As DataTable = sql.Cobradores_G1(IdCobrador)
      Dim o As Eniac.Entidades.Cobrador = New Eniac.Entidades.Cobrador()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Cobrador.")
      End If
      Return o
   End Function

   Public Function GetPorNombre(ByVal nombreCobrador As String) As DataTable
      Dim sql As SqlServer.Cobradores = New SqlServer.Cobradores(Me.da)
      Return sql.GetPorNombre(nombreCobrador)
   End Function

   Public Function GetDebitosDirectos() As System.Data.DataTable
      Return New SqlServer.Cobradores(Me.da).Cobradores_DebitosDirectos()
   End Function

   Public Function Get1(ByVal idCobrador As Integer) As DataTable
      Dim sql As SqlServer.Cobradores = New SqlServer.Cobradores(Me.da)
      Return sql.Cobradores_G1(idCobrador)
   End Function

   Public Function GetIdMaximo() As Integer

      Dim sql As SqlServer.Cobradores = New SqlServer.Cobradores(Me.da)
      Dim dt As DataTable = sql.Cobradores_GetIdMaximo()
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region

End Class