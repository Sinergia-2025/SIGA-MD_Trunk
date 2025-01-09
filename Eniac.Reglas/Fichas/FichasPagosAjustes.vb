Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual

#End Region

Public Class FichasPagosAjustes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "FichasPagosAjustes"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Friend"

   Friend Sub GrabaFichaPagosAjuste(ByVal ent As Eniac.Entidades.FichaPagoAjuste)

      Dim sql As SqlServer.FichasPagosAjustes = New SqlServer.FichasPagosAjustes(Me.da)

      sql.FichasPagosAjustes_I(ent.IdSucursal, ent.IdCliente, ent.NroOperacion, ent.FechaPago, ent.Importe, ent.Concepto, _
                               ent.IdCaja, ent.NumeroPlanilla, ent.NumeroMovimiento)

   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim ficha As Eniac.Entidades.FichaPagoAjuste = DirectCast(entidad, Eniac.Entidades.FichaPagoAjuste)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.GrabaFichaPagosAjuste(ficha)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos publicos"

   Friend Function GetUna(ByVal idSucursal As Int32, ByVal nroOperacion As Integer, ByVal IdCliente As Long, _
                       ByVal fechaPago As DateTime) As Eniac.Entidades.FichaPagoAjuste

      Dim stbQuery As StringBuilder = New StringBuilder("")
      Dim fp As Eniac.Entidades.FichaPagoAjuste = New Eniac.Entidades.FichaPagoAjuste(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      With stbQuery
         .Append(" select * from fichaspagosajustes ")
         .AppendFormat(" where NroOperacion = {0}", nroOperacion)
         .AppendFormat(" and IdCliente = {0}", IdCliente)
         .AppendFormat(" and FechaPago = '{0}'", fechaPago.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("and idsucursal = {0}", idSucursal)
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         fp = New Eniac.Entidades.FichaPagoAjuste(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         fp.IdSucursal = Int32.Parse(dr("IdSucursal").ToString())
         fp.NroOperacion = Int32.Parse(dr("NroOperacion").ToString())
         fp.IdCliente = Long.Parse(dr("IdCliente").ToString())
         fp.Importe = Decimal.Parse(dr("Importe").ToString())
         fp.FechaPago = DateTime.Parse(dr("FechaPago").ToString())
         If Not String.IsNullOrEmpty(dr("Concepto").ToString()) Then
            fp.Concepto = dr("Concepto").ToString()
         End If
      End If
      Return fp

   End Function

#End Region

End Class
