Public Class TiposImpuestos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("TiposImpuestos", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TipoImpuesto), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TipoImpuesto), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TipoImpuesto), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.TiposImpuestos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.TiposImpuestos(da).TiposImpuestos_GA()
   End Function

   Public Function GetAll2(Tipo As String) As DataTable
      Return New SqlServer.TiposImpuestos(da).TiposImpuestos_GA(Tipo)
   End Function

   Public Function GetAplicativoAfip(tipoTipoImpuesto As String) As DataTable
      Return New SqlServer.TiposImpuestos(da).GetAplicativosAfip(tipoTipoImpuesto)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ent As Eniac.Entidades.TipoImpuesto, tipo As TipoSP)
      '#### contabilidad 10/06/2013
      Dim idCuentaDebe = 0L
      Dim idCuentaHaber = 0L
      If Publicos.TieneModuloContabilidad Then
         idCuentaDebe = ent.CuentaCompras.IdCuenta
         idCuentaHaber = ent.CuentaVentas.IdCuenta
      End If
      '#### contabilidad 10/06/2013

      Dim sql = New SqlServer.TiposImpuestos(da)

      Select Case tipo
         Case TipoSP._I
            sql.TiposImpuestos_I(ent.IdTipoImpuesto, ent.NombreTipoImpuesto, ent.Tipo,
                                 idCuentaDebe, idCuentaHaber,
                                 ent.IdCuentaCaja, ent.AplicativoAfip, ent.CodigoArticuloInciso, ent.ArticuloInciso)
         Case TipoSP._U
            sql.TiposImpuestos_U(ent.IdTipoImpuesto, ent.NombreTipoImpuesto, ent.Tipo,
                                 idCuentaDebe, idCuentaHaber,
                                 ent.IdCuentaCaja, ent.AplicativoAfip, ent.CodigoArticuloInciso, ent.ArticuloInciso)
         Case TipoSP._D
            sql.TiposImpuestos_D(ent.IdTipoImpuesto)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.TipoImpuesto, dr As DataRow)
      With o
         .IdTipoImpuesto = dr.Field(Of String)(Entidades.TipoImpuesto.Columnas.IdTipoImpuesto.ToString()).StringToEnum(Entidades.TipoImpuesto.Tipos.IVA)
         .NombreTipoImpuesto = dr.Field(Of String)(Entidades.TipoImpuesto.Columnas.NombreTipoImpuesto.ToString())
         .Tipo = dr.Field(Of String)(Entidades.TipoImpuesto.Columnas.Tipo.ToString())
         .IdCuentaCaja = dr.Field(Of Integer?)("IdCuentaCaja").IfNull()

         If Publicos.TieneModuloContabilidad Then
            Dim idCtaCte = dr.Field(Of Long?)(Entidades.TipoImpuesto.Columnas.IdCuentaDebe.ToString())
            If idCtaCte.HasValue Then
               .CuentaCompras = New ContabilidadCuentas(da)._GetUna(idCtaCte.Value)
            End If
            idCtaCte = dr.Field(Of Long?)(Entidades.TipoImpuesto.Columnas.IdCuentaHaber.ToString())
            If idCtaCte.HasValue Then
               .CuentaVentas = New ContabilidadCuentas(da)._GetUna(idCtaCte.Value)
            End If
         End If

         .AplicativoAfip = dr.Field(Of String)("AplicativoAfip").IfNull()
         .CodigoArticuloInciso = dr.Field(Of String)("CodigoArticuloInciso").IfNull()
         .ArticuloInciso = dr.Field(Of String)("ArticuloInciso").IfNull()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.TipoImpuesto)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoImpuesto())
   End Function

   Public Function Get1(idTipoImpuesto As String) As DataTable
      Return New SqlServer.TiposImpuestos(da).TiposImpuestos_G1(idTipoImpuesto)
   End Function
   Public Function _GetUno(idTipoImpuesto As Entidades.TipoImpuesto.Tipos) As Entidades.TipoImpuesto
      Return _GetUno(idTipoImpuesto.ToString())
   End Function

   Public Function _GetUno(idTipoImpuesto As String) As Entidades.TipoImpuesto
      Return CargaEntidad(Get1(idTipoImpuesto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoImpuesto(),
                          accion:=AccionesSiNoExisteRegistro.Excepcion,
                          Function() String.Format("No existe el Tipo de Impuesto con Id {0}", idTipoImpuesto))
   End Function

   Public Function GetUno(idTipoImpuesto As Entidades.TipoImpuesto.Tipos) As Entidades.TipoImpuesto
      Return _GetUno(idTipoImpuesto)
   End Function

   Public Function GetxTipo(idTipoImpuesto As String) As Entidades.TipoImpuesto
      Return _GetUno(idTipoImpuesto)
      'Dim sql As SqlServer.TiposImpuestos = New SqlServer.TiposImpuestos(da)
      'Dim dt As DataTable = sql.TiposImpuestos_G1(idTipoImpuesto.ToString())

      'Dim o As Entidades.TipoImpuesto = New Entidades.TipoImpuesto()
      'If dt.Rows.Count > 0 Then
      '   Me.CargarUno(o, dt.Rows(0))
      'Else
      '   Throw New Exception("No existe el Tipo de Impuesto.")
      'End If
      'Return o
   End Function

#End Region

End Class