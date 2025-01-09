Public Class CuentasDeCajas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CuentasDeCajas"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas(idCuentaCaja As String) As DataTable
      Return New SqlServer.CuentasDeCajas(da).CuentasDeCajas_G1(If(IsNumeric(idCuentaCaja), Integer.Parse(idCuentaCaja), 0))
   End Function

   Public Function Existe(idCuentaCaja As Integer) As Boolean
      Return New SqlServer.CuentasDeCajas(da).CuentasDeCajas_G1(idCuentaCaja).Rows.Count > 0
   End Function

   Public Function GetPorNombre(nombreCuenta As String) As DataTable
      Return New SqlServer.CuentasDeCajas(da).CuentasDeCajas_GA(nombreCuenta, nombreExacto:=False)
   End Function
   Public Function GetPorNombreExacto(nombreCuenta As String) As DataTable
      Return New SqlServer.CuentasDeCajas(da).CuentasDeCajas_GA(nombreCuenta, nombreExacto:=True)
   End Function

   Public Function GetUna(idCuentaCaja As Integer) As Entidades.CuentaDeCaja
      Return GetUna(idCuentaCaja, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idCuentaCaja As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CuentaDeCaja

      Dim dt As DataTable = New SqlServer.CuentasDeCajas(da).CuentasDeCajas_G1(idCuentaCaja)
      Dim ct As Entidades.CuentaDeCaja = New Entidades.CuentaDeCaja()

      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With ct
            .IdCuentaCaja = Integer.Parse(dr("IdCuentaCaja").ToString())
            .NombreCuentaCaja = dr("NombreCuentaCaja").ToString()
            .IdTipoCuenta = dr("IdTipoCuenta").ToString()
            .EsPosdatado = Boolean.Parse(dr("EsPosdatado").ToString())
            .PideCheque = Boolean.Parse(dr("PideCheque").ToString())
            .IdGrupoCuenta = dr("IdGrupoCuenta").ToString()
            If Not String.IsNullOrEmpty(dr("IdCuentaContable").ToString()) Then
               .IdCuentaContable = Long.Parse(dr("IdCuentaContable").ToString())
            End If
            If Not String.IsNullOrWhiteSpace(dr(Entidades.CuentaDeCaja.Columnas.IdCentroCosto.ToString()).ToString()) Then
               .CentroCosto = New Reglas.ContabilidadCentrosCostos(da)._GetUna(Integer.Parse(dr(Entidades.CuentaDeCaja.Columnas.IdCentroCosto.ToString()).ToString()))
            End If

            .GeneraContabilidad = Boolean.Parse(dr("GeneraContabilidad").ToString())
            .IdConceptoCM05 = dr.Field(Of Integer?)("IdConceptoCM05")

         End With
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No Existe la Cuenta de Caja con IdCuentaCaja = {0}.", idCuentaCaja))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If

      Return ct
   End Function

   Public Function GetCodigoMaximo() As Long
      Return New SqlServer.CuentasDeCajas(da).GetCodigoMaximo()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Entidades.Entidad, tipo As TipoSP)
      Dim cuentaDeCaja As Entidades.CuentaDeCaja = DirectCast(entidad, Entidades.CuentaDeCaja)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.CuentasDeCajas = New SqlServer.CuentasDeCajas(Me.da)
         Select Case tipo
            Case TipoSP._I
               sql.CuentasDeCajas_I(cuentaDeCaja.IdCuentaCaja, cuentaDeCaja.NombreCuentaCaja,
                                    cuentaDeCaja.IdTipoCuenta, cuentaDeCaja.EsPosdatado, cuentaDeCaja.PideCheque,
                                    cuentaDeCaja.IdGrupoCuenta, cuentaDeCaja.IdCuentaContable, cuentaDeCaja.IdCentroCosto,
                                    cuentaDeCaja.GeneraContabilidad, cuentaDeCaja.IdConceptoCM05)
            Case TipoSP._U
               sql.CuentasDeCajas_U(cuentaDeCaja.IdCuentaCaja, cuentaDeCaja.NombreCuentaCaja,
                                    cuentaDeCaja.IdTipoCuenta, cuentaDeCaja.EsPosdatado, cuentaDeCaja.PideCheque,
                                    cuentaDeCaja.IdGrupoCuenta, cuentaDeCaja.IdCuentaContable, cuentaDeCaja.IdCentroCosto,
                                    cuentaDeCaja.GeneraContabilidad, cuentaDeCaja.IdConceptoCM05)
            Case TipoSP._D
               sql.CuentasDeCajas_D(cuentaDeCaja.IdCuentaCaja)
         End Select

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.CuentasDeCajas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.CuentasDeCajas(Me.da).CuentasDeCajas_GA()
   End Function

   Public Function GetGruposDeCuentas() As DataTable
      Return New SqlServer.CuentasDeCajas(Me.da).CuentasDeCajas_GetGruposDeCuentas()
   End Function

#End Region

End Class
