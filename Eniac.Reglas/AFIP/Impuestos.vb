Public Class Impuestos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Impuestos", accesoDatos)
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Impuesto)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Impuesto)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Impuesto)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Impuestos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Impuestos(da).Impuestos_GA(idTipoImpuesto:=String.Empty)
   End Function
   Public Overloads Function GetAll(idTipoImpuesto As String) As DataTable
      Return New SqlServer.Impuestos(da).Impuestos_GA(idTipoImpuesto)
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.Impuesto, tipo As TipoSP)
      If tipo <> TipoSP._D Then
         If Not String.IsNullOrEmpty(en.IdTipoImpuestoPIVA) AndAlso en.AlicuotaPIVA.HasValue Then
            If en.PIVAAgregarSiNoExiste AndAlso Not _Existe(en.IdTipoImpuestoPIVA, en.AlicuotaPIVA.Value) Then
               _Insertar(New Entidades.Impuesto(en.IdTipoImpuestoPIVA, en.AlicuotaPIVA.Value, activo:=True))
            End If
         End If
      End If

      Dim sql As SqlServer.Impuestos = New SqlServer.Impuestos(da)
      Select Case tipo
         Case TipoSP._I
            sql.Impuestos_I(en.IdTipoImpuesto, en.Alicuota, en.Activo, en.IdTipoImpuestoPIVA, en.AlicuotaPIVA, en.IdCuentaCompras, en.IdCuentaVentas)
         Case TipoSP._U
            sql.Impuestos_U(en.IdTipoImpuesto, en.Alicuota, en.Activo, en.IdTipoImpuestoPIVA, en.AlicuotaPIVA, en.IdCuentaCompras, en.IdCuentaVentas)
         Case TipoSP._D
            sql.Impuestos_D(en.IdTipoImpuesto, en.Alicuota)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Impuesto, dr As DataRow)
      With o
         .IdTipoImpuesto = dr.Field(Of String)("IdTipoImpuesto")
         .Alicuota = dr.Field(Of Decimal)("Alicuota")
         .Activo = dr.Field(Of Boolean)("Activo")

         .IdTipoImpuestoPIVA = dr.Field(Of String)("IdTipoImpuestoPIVA")
         .AlicuotaPIVA = dr.Field(Of Decimal?)("AlicuotaPIVA")

         Dim idCtaCble = dr.Field(Of Long?)(Entidades.Impuesto.Columnas.IdCuentaCompras.ToString())
         If idCtaCble.HasValue Then
            .CuentaCompras = New ContabilidadCuentas(da)._GetUna(idCtaCble.Value)
         End If
         idCtaCble = dr.Field(Of Long?)(Entidades.Impuesto.Columnas.IdCuentaVentas.ToString())
         If idCtaCble.HasValue Then
            .CuentaVentas = New ContabilidadCuentas(da)._GetUna(idCtaCble.Value)
         End If
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.Impuesto)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Impuesto)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Impuesto)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetTodos() As List(Of Entidades.Impuesto)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Impuesto())
   End Function
   Public Function GetTodos(idTipoImpuesto As String) As List(Of Entidades.Impuesto)
      Return CargaLista(GetAll(idTipoImpuesto), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Impuesto())
   End Function

   Public Function Get1(idTipoImpuesto As String, alicuota As Decimal) As DataTable
      Return New SqlServer.Impuestos(da).Impuestos_G1(idTipoImpuesto, alicuota)
   End Function
   Public Function GetUno(idTipoImpuesto As String, alicuota As Decimal) As Entidades.Impuesto
      Return GetUno(idTipoImpuesto, alicuota, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoImpuesto As String, alicuota As Decimal, accion As AccionesSiNoExisteRegistro) As Entidades.Impuesto
      Return CargaEntidad(Get1(idTipoImpuesto, alicuota), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Impuesto(),
                          accion, Function() String.Format("No existe el Impuesto con tipo {0} y alicuota {1}", idTipoImpuesto, alicuota))
   End Function
   Public Function GetIVAs() As List(Of Entidades.Impuesto)
      Return CargaLista(New SqlServer.Impuestos(da).GetIVAs(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Impuesto())
   End Function

   Public Function Existe(idTipoImpuesto As String, alicuota As Decimal) As Boolean
      Return EjecutaConConexion(Function() _Existe(idTipoImpuesto, alicuota))
   End Function
   Public Function _Existe(idTipoImpuesto As String, alicuota As Decimal) As Boolean
      Return New SqlServer.Impuestos(da).Impuestos_G1(idTipoImpuesto, alicuota).Rows.Count > 0
   End Function

#End Region

End Class