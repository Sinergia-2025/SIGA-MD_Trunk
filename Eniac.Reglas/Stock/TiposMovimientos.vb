Option Explicit On
Option Strict On

Imports System.Text

Public Class TiposMovimientos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposMovimientos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposMovimientos"
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
      Return New SqlServer.TiposMovimientos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposMovimientos(Me.da).TiposMovimientos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim tipoMov As Entidades.TipoMovimiento = DirectCast(entidad, Entidades.TipoMovimiento)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.TiposMovimientos = New SqlServer.TiposMovimientos(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.TiposMovimientos_I(tipoMov.IdTipoMovimiento, tipoMov.Descripcion, tipoMov.CoeficienteStock, tipoMov.ComprobantesAsociados, tipoMov.AsociaSucursal, tipoMov.MuestraCombo, tipoMov.HabilitaDestinatario, tipoMov.HabilitaRubro, tipoMov.Imprime, tipoMov.CargaPrecio, tipoMov.IdContraTipoMovimiento, tipoMov.HabilitaEmpleado, tipoMov.ReservaMercaderia)
            Case TipoSP._U
               sql.TiposMovimientos_U(tipoMov.IdTipoMovimiento, tipoMov.Descripcion, tipoMov.CoeficienteStock, tipoMov.ComprobantesAsociados, tipoMov.AsociaSucursal, tipoMov.MuestraCombo, tipoMov.HabilitaDestinatario, tipoMov.HabilitaRubro, tipoMov.Imprime, tipoMov.CargaPrecio, tipoMov.IdContraTipoMovimiento, tipoMov.HabilitaEmpleado, tipoMov.ReservaMercaderia)
            Case TipoSP._D
               sql.TiposMovimientos_D(tipoMov.IdTipoMovimiento)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.TipoMovimiento)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.TipoMovimiento
      Dim oLis As List(Of Entidades.TipoMovimiento) = New List(Of Entidades.TipoMovimiento)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoMovimiento()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetParaCombos() As List(Of Entidades.TipoMovimiento)
      Dim dt As DataTable = Me.GetFilter(" MuestraCombo = 1").Tables(0)
      Dim o As Entidades.TipoMovimiento
      Dim oLis As List(Of Entidades.TipoMovimiento) = New List(Of Entidades.TipoMovimiento)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoMovimiento()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Private Sub CargarUno(ByVal o As Entidades.TipoMovimiento, ByVal dr As DataRow)
      With o
         .IdTipoMovimiento = dr("IdTipoMovimiento").ToString()
         If Not String.IsNullOrEmpty(dr("Descripcion").ToString()) Then
            .Descripcion = dr("Descripcion").ToString()
         End If
         If Not String.IsNullOrEmpty(dr("CoeficienteStock").ToString()) Then
            .CoeficienteStock = Int32.Parse(dr("CoeficienteStock").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("ComprobantesAsociados").ToString()) Then
            .ComprobantesAsociados = dr("ComprobantesAsociados").ToString()
         End If
         If Not String.IsNullOrEmpty(dr("AsociaSucursal").ToString()) Then
            .AsociaSucursal = Boolean.Parse(dr("AsociaSucursal").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("MuestraCombo").ToString()) Then
            .MuestraCombo = Boolean.Parse(dr("MuestraCombo").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("HabilitaDestinatario").ToString()) Then
            .HabilitaDestinatario = Boolean.Parse(dr("HabilitaDestinatario").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("HabilitaRubro").ToString()) Then
            .HabilitaRubro = Boolean.Parse(dr("HabilitaRubro").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("Imprime").ToString()) Then
            .Imprime = Boolean.Parse(dr("Imprime").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("CargaPrecio").ToString()) Then
            .CargaPrecio = dr("CargaPrecio").ToString()
         End If
         If Not String.IsNullOrEmpty(dr("IdContraTipoMovimiento").ToString()) Then
            .IdContraTipoMovimiento = dr("IdContraTipoMovimiento").ToString()
         End If

         .HabilitaEmpleado = Boolean.Parse(dr(Entidades.TipoMovimiento.Columnas.HabilitaEmpleado.ToString()).ToString())
         .ReservaMercaderia = Boolean.Parse(dr(Entidades.TipoMovimiento.Columnas.ReservaMercaderia.ToString()).ToString())

      End With
   End Sub

   Public Function GetUno(ByVal idTipoMovimiento As String) As Entidades.TipoMovimiento
      Dim dt As DataTable = Me.GetFilter("IdTipoMovimiento = '" & idTipoMovimiento & "'").Tables(0)
      Dim o As Entidades.TipoMovimiento = New Entidades.TipoMovimiento()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dr)
      End If
      Return o
   End Function

   Public Function GetUnoPorComprobanteAsociado(ByVal idTipoComprobante As String) As Entidades.TipoMovimiento

      Dim IdTipoMovimiento As String = String.Empty

      'Busco el tipo de Movimiento
      Dim stb As StringBuilder = New StringBuilder("")
      Dim com() As String = {}
      'Dim coms As List(Of String()) = New List(Of String())
      With stb
         .Length = 0
         .AppendLine("SELECT TM.IdTipoMovimiento, TM.ComprobantesAsociados ")
         .AppendLine("  FROM TiposMovimientos TM ")
         .AppendLine(" WHERE ComprobantesAsociados IS NOT NULL")
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      For Each dr As DataRow In dt.Rows
         If Not String.IsNullOrEmpty(dr("ComprobantesAsociados").ToString()) Then
            com = dr("ComprobantesAsociados").ToString().Split(","c)
            For Cont As Integer = 0 To com.Length - 1
               If com(Cont) = idTipoComprobante Then
                  IdTipoMovimiento = dr("IdTipoMovimiento").ToString()
               End If
            Next
            'coms.Add(com)
         End If
      Next
      '-------------------------------------------------------------------------------------

      Return Me.GetUno(IdTipoMovimiento)

   End Function

#End Region

End Class