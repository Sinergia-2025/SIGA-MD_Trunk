Option Explicit On
Option Strict On
Imports System.Text

Public Class FichasFormasPago
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "FichasFormasPago"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
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
   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      entidad.Columna = "F." + entidad.Columna
      With stbQuery
         .Length = 0
         .AppendLine("SELECT F.IdFormasPago")
         .AppendLine("      ,F.DescripcionFormasPago")
         .AppendLine("      ,F.Dias")
         .AppendLine(" FROM FichasFormasPago F")
         .AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.FichasFormasPago(Me.da).FichasFormasPago_GA()
   End Function

#End Region

#Region "Metodos Publicos"

   'Public Function GetTodas() As List(Of Entidades.VentaFormaPago)
   '   Dim dt As DataTable = Me.GetAll()
   '   Dim o As Entidades.VentaFormaPago
   '   Dim oLis As List(Of Entidades.VentaFormaPago) = New List(Of Entidades.VentaFormaPago)
   '   For Each dr As DataRow In dt.Rows
   '      o = New Entidades.VentaFormaPago()
   '      Me.CargarUno(dr, o)
   '      oLis.Add(o)
   '   Next
   '   Return oLis
   'End Function

   Public Function GetUna(ByVal idFormaPago As Int32) As Entidades.FichaFormaPago
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT IdFormasPago")
         .AppendLine("      ,DescripcionFormasPago")
         .AppendLine("      ,Dias")
         .AppendLine(" FROM FichasFormasPago")
         .AppendLine("  WHERE IdFormasPago = " & idFormaPago.ToString())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim o As Entidades.FichaFormaPago = New Entidades.FichaFormaPago()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(dr, o)
      Else
         Throw New Exception("No existe la Forma de Pago")
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdFormasPago) AS maximo ")
         .Append(" FROM VentasFormasPago")
      End With

      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim forma As Eniac.Entidades.FichaFormaPago = DirectCast(entidad, Eniac.Entidades.FichaFormaPago)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.FichasFormasPago = New SqlServer.FichasFormasPago(Me.da)
         Select Case tipo
            Case TipoSP._I
               sql.FichasFormasPago_I(forma.IdFormasPago, forma.DescripcionFormasPago, forma.Dias)
            Case TipoSP._U
               sql.FichasFormasPago_U(forma.IdFormasPago, forma.DescripcionFormasPago, forma.Dias)
            Case TipoSP._D
               sql.FichasFormasPago_D(forma.IdFormasPago)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.FichaFormaPago)
      With o
         .IdFormasPago = Integer.Parse(dr("IdFormasPago").ToString())
         .DescripcionFormasPago = dr("DescripcionFormasPago").ToString()
         .Dias = Integer.Parse(dr("Dias").ToString())
      End With
   End Sub

#End Region

End Class
