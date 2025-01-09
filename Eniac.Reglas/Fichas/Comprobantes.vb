#Region "Imports"

Imports System.Text

#End Region

Public Class Comprobantes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()

      Me.NombreEntidad = "Comprobantes"
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

   'Esto se usa??
   Public Function BuscarPendientes(ByVal Cliente As Eniac.Entidades.Cliente) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery

         '   Sucursal", "Tipo", "Letra", "Emisor", "Numero", "Cuota", "FechaVencimiento", "Importe", "Saldo"}

         .Append("SELECT cc.[IdSucursal] as Sucursal")
         .Append(",cc.[IdTipoComprobante] as Tipo ")
         .Append(",cc.[Letra]")
         .Append(",cc.[CentroEmisor] as Emisor")
         .Append(",cc.[NumeroComprobante] as Numero ")
         .Append(",cc.[CuotaNumero] as Cuota")
         .Append(",cc.[TipoDocCliente]")
         .Append(",cc.[NroDocCliente]")
         .Append(",cc.[Fecha]")
         .Append(",cc.[FechaVencimiento]")
         .Append(",cc.[ImporteCuota] as Importe")
         .Append(",cc.[SaldoCuota] as Saldo")
         .Append(",cc.[IdFormasPago]")
         .Append(",cc.[Observacion]")
         .Append(" FROM CuentasCorrientesPagos cc,  CuentasCorrientes aa")
         .Append(" where aa.tipodoccliente='" & Cliente.TipoDocCliente & "'")
         .Append(" and aa.nrodoccliente=" & Cliente.NroDocCliente)
         .Append(" and cc.idsucursal=aa.idsucursal")
         .Append(" and cc.idtipocomprobante = aa.idtipocomprobante")
         .Append(" and cc.letra = aa.letra")
         .Append(" and cc.centroemisor = aa.centroemisor")
         .Append(" and cc.numerocomprobante = aa.numerocomprobante")

      End With

      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim comprobante As Entidades.Comprobantes = DirectCast(entidad, Entidades.Comprobantes)
      Try
         da.OpenConection()
         da.BeginTransaction()

         da.Command.Connection = da.Connection
         da.Command.Transaction = da.Transaction
         da.Command.CommandText = Me.NombreEntidad & tipo.ToString()
         da.Command.CommandType = CommandType.StoredProcedure
         da.Command.Parameters.Clear()

         da.LoadParameter("@idSucursal", ParameterDirection.Input, DbType.Int32, comprobante.IdSucursalComprobante)
         da.LoadParameter("@idComprobante", ParameterDirection.Input, DbType.Int32, comprobante.IdComprobante)
         If tipo <> TipoSP._D Then
            da.LoadParameter("@nombreComprobante", ParameterDirection.Input, DbType.String, comprobante.NombreComprobante)
            da.LoadParameter("@afectaStock", ParameterDirection.Input, DbType.String, comprobante.AfectaStock)
            da.LoadParameter("@esFacturable", ParameterDirection.Input, DbType.String, comprobante.EsFacturable)
            da.LoadParameter("@grabaLibroIVA", ParameterDirection.Input, DbType.String, comprobante.GrabaLibroIVA)
         End If
         da.Command.ExecuteNonQuery()

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




#End Region

End Class