Public Class CuentasBancos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CuentasBancos"
      da = accesoDatos
   End Sub

#End Region

#Region "Enumeraciones"

   Public Enum TipoOperacion
      Nuevo
      Modificacion
   End Enum
   Public Enum TipoMovimiento
      Ingreso
      Egreso
   End Enum

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaBanco), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaBanco), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaBanco), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.CuentasBancos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CuentasBancos(da).CuentasBancos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub CargarUna(o As Entidades.CuentaBanco, dr As DataRow)
      With o
         .IdCuentaBanco = dr.Field(Of Integer)(Entidades.CuentaBanco.Columnas.IdCuentaBanco.ToString())
         .IdTipoCuenta = dr.Field(Of String)(Entidades.CuentaBanco.Columnas.IdTipoCuenta.ToString())
         .NombreCuentaBanco = dr.Field(Of String)(Entidades.CuentaBanco.Columnas.NombreCuentaBanco.ToString())
         .PideCheque = dr.Field(Of Boolean)(Entidades.CuentaBanco.Columnas.PideCheque.ToString())
         .EsPosdatado = dr.Field(Of Boolean)(Entidades.CuentaBanco.Columnas.EsPosdatado.ToString())
         .IdCuentaContable = dr.Field(Of Long?)(Entidades.CuentaBanco.Columnas.IdCuentaContable.ToString()).IfNull().ToInteger()
         .IdGrupoCuenta = dr.Field(Of String)(Entidades.CuentaBanco.Columnas.IdGrupoCuenta.ToString())
         Dim cc = dr.Field(Of Integer?)(Entidades.CuentaBanco.Columnas.IdCentroCosto.ToString())
         If cc.HasValue Then
            .CentroCosto = New Reglas.ContabilidadCentrosCostos(da)._GetUna(cc.Value)
         End If
         .IdConceptoCM05 = dr.Field(Of Integer?)(Entidades.CuentaBanco.Columnas.IdConceptoCM05.ToString())
      End With
   End Sub

   Private Sub EjecutaSP(ent As Entidades.CuentaBanco, tipo As TipoSP)
      Dim sql = New SqlServer.CuentasBancos(da)
      Select Case tipo
         Case TipoSP._I
            sql.CuentasBancos_I(ent.IdCuentaBanco, ent.NombreCuentaBanco, ent.IdTipoCuenta, ent.EsPosdatado, ent.PideCheque, ent.IdCuentaContable, ent.IdGrupoCuenta, ent.IdCentroCosto, ent.IdConceptoCM05)
         Case TipoSP._U
            sql.CuentasBancos_U(ent.IdCuentaBanco, ent.NombreCuentaBanco, ent.IdTipoCuenta, ent.EsPosdatado, ent.PideCheque, ent.IdCuentaContable, ent.IdGrupoCuenta, ent.IdCentroCosto, ent.IdConceptoCM05)
         Case TipoSP._D
            sql.CuentasBancos_D(ent.IdCuentaBanco)
      End Select
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Function GetTodas() As List(Of Entidades.CuentaBanco)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CuentaBanco())
   End Function

   Public Function GetUna(idCuentaBanco As Integer) As Entidades.CuentaBanco
      Return GetUna(idCuentaBanco, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idCuentaBanco As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CuentaBanco
      Return CargaEntidad(Get1(idCuentaBanco), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.CuentaBanco(),
                          accion, Function() String.Format("No existe la Cuenta de Banco con código {0}.", idCuentaBanco))
   End Function

   Public Function GetTodosPorCodigo(codigoCuenta As String) As DataTable
      Return New SqlServer.CuentasBancos(da).CuentasBancos_GA(codigoCuenta.ValorNumericoPorDefecto(0I))
   End Function
   Public Function GetTodosPorNombre(nombreCuenta As String) As DataTable
      Return New SqlServer.CuentasBancos(da).CuentasBancos_GA(nombreCuenta)
   End Function

   Public Function Get1(idCuentaBanco As Integer) As DataTable
      Return New SqlServer.CuentasBancos(da).CuentasBancos_G1(idCuentaBanco)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CuentasBancos(da).GetCodigoMaximo()
   End Function


   'Public Function GetCuentaBancos(IdCuentaBanco As Integer) As Entidades.CuentaBanco

   '   Dim myQuery As StringBuilder = New StringBuilder("")
   '   With myQuery
   '      .Length = 0
   '      .AppendLine("SELECT IdCuentaBanco")
   '      .AppendLine("      ,NombreCuentaBanco")
   '      .AppendLine("      ,IdTipoCuenta")
   '      .AppendLine("      ,EsPosdatado")
   '      .AppendLine("      ,PideCheque")
   '      .AppendLine("      ,IdCuentaContable")
   '      .AppendLine("      ,IdGrupoCuenta")
   '      .AppendLine("      ,IdCentroCosto")
   '      .AppendLine("  FROM CuentasBancos")
   '      .AppendLine(" WHERE IdCuentaBanco = " & IdCuentaBanco.ToString())
   '   End With

   '   Dim entCuentaBancos As Entidades.CuentaBanco
   '   entCuentaBancos = New Entidades.CuentaBanco()

   '   Dim dtCuentaBanco As DataTable = Me.DataServer().GetDataTable(myQuery.ToString())

   '   entCuentaBancos.NombreCuentaBanco = dtCuentaBanco.Rows(0)("NombreCuentaBanco").ToString()
   '   entCuentaBancos.IdTipoCuenta = dtCuentaBanco.Rows(0)("IdTipoCuenta").ToString()
   '   entCuentaBancos.EsPosdatado = Boolean.Parse(dtCuentaBanco.Rows(0)("EsPosdatado").ToString())
   '   entCuentaBancos.PideCheque = Boolean.Parse(dtCuentaBanco.Rows(0)("PideCheque").ToString())
   '   entCuentaBancos.IdCuentaContable = Integer.Parse(dtCuentaBanco.Rows(0)("IdCuentaContable").ToString())
   '   entCuentaBancos.IdGrupoCuenta = dtCuentaBanco.Rows(0)("IdGrupoCuenta").ToString()
   '   If Not String.IsNullOrWhiteSpace(dtCuentaBanco.Rows(0)("IdCentroCosto").ToString()) Then
   '      entCuentaBancos.CentroCosto = New Reglas.ContabilidadCentrosCostos().GetUna(Integer.Parse(dtCuentaBanco.Rows(0)("IdCentroCosto").ToString()))
   '   End If
   '   Return entCuentaBancos

   'End Function

   'Public Function ValidateId(idCuentaBanco As Integer) As Boolean

   '   Dim myQuery As StringBuilder = New StringBuilder("")
   '   With myQuery
   '      .Append("   Select ")
   '      .Append("       Count(*)")
   '      .Append("   From CuentasBancos")
   '      .Append("   Where idCuentaBanco = " & idCuentaBanco & " ")
   '   End With

   '   Dim dtId As DataTable = Me.DataServer().GetDataTable(myQuery.ToString())

   '   If Convert.ToInt32(dtId.Rows(0)(0)) > 0 Then
   '      Return True
   '   Else
   '      Return False
   '   End If

   'End Function
#End Region

End Class