Public Class Tarjetas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Tarjetas"
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Tarjeta), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Tarjeta), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Tarjeta), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Tarjetas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetAll(activas:=False)
   End Function
   Public Overloads Function GetAll(activas As Boolean) As DataTable
      Return New SqlServer.Tarjetas(da).Tarjetas_GA(activas)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.Tarjeta, tipo As TipoSP)
      Dim sql = New SqlServer.Tarjetas(da)

      Dim idCuenta As Long = 0
      If en.CuentaContable IsNot Nothing Then idCuenta = en.CuentaContable.IdCuenta

      Select Case tipo
         Case TipoSP._I
            sql.Tarjetas_I(en.IdTarjeta, en.NombreTarjeta, en.TipoTarjeta,
                           en.Habilitada, en.Acreditacion, en.CuentaBancaria.IdCuentaBancaria,
                           en.CantDiasAcredit, en.PagoPosVenta, en.PagoPosCorte, en.DiaCorte, en.PagoDiaMes, en.DiaMes, idCuenta,
                           en.PorcIntereses, en.CantidadCuotas, en.IdProveedor)
         Case TipoSP._U
            sql.Tarjetas_U(en.IdTarjeta, en.NombreTarjeta, en.TipoTarjeta,
                           en.Habilitada, en.Acreditacion, en.CuentaBancaria.IdCuentaBancaria,
                           en.CantDiasAcredit, en.PagoPosVenta, en.PagoPosCorte, en.DiaCorte, en.PagoDiaMes, en.DiaMes, idCuenta,
                           en.PorcIntereses, en.CantidadCuotas, en.IdProveedor)
         Case TipoSP._D
            sql.Tarjetas_D(en.IdTarjeta)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Tarjeta, dr As DataRow)
      With o
         .IdTarjeta = dr.Field(Of Integer)(Entidades.Tarjeta.Columnas.IdTarjeta.ToString())
         .NombreTarjeta = dr.Field(Of String)(Entidades.Tarjeta.Columnas.NombreTarjeta.ToString())
         If dr.Field(Of String)(Entidades.Tarjeta.Columnas.TipoTarjeta.ToString()) = "D" Then
            .TipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Debito
         ElseIf dr.Field(Of String)(Entidades.Tarjeta.Columnas.TipoTarjeta.ToString()) = "C" Then
            .TipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Credito
         End If

         .Habilitada = dr.Field(Of Boolean)(Entidades.Tarjeta.Columnas.Habilitada.ToString())
         .Acreditacion = dr.Field(Of Boolean)(Entidades.Tarjeta.Columnas.Acreditacion.ToString())

         If dr.Field(Of Integer?)("IdCuentaBancaria").HasValue Then
            .CuentaBancaria = New CuentasBancarias().GetUna(dr.Field(Of Integer?)("IdCuentaBancaria").Value)
         End If

         .CantDiasAcredit = dr.Field(Of Integer?)("CantDiasAcredit").IfNull()

         .PagoPosVenta = dr.Field(Of Boolean)(Entidades.Tarjeta.Columnas.PagoPosVenta.ToString())
         .PagoPosCorte = dr.Field(Of Boolean)(Entidades.Tarjeta.Columnas.PagoPosCorte.ToString())

         .PagoDiaMes = dr.Field(Of Boolean)(Entidades.Tarjeta.Columnas.PagoDiaMes.ToString())

         .DiaCorte = dr.Field(Of Integer?)("DiaCorte").IfNull()
         .DiaMes = dr.Field(Of Integer?)("DiaMes").IfNull()


         If dr.Field(Of Long?)(Entidades.Tarjeta.Columnas.IdCuentaContable.ToString()).HasValue Then
            .CuentaContable = New ContabilidadCuentas(da)._GetUna(dr.Field(Of Long?)(Entidades.Tarjeta.Columnas.IdCuentaContable.ToString()).IfNull())
         End If

         .PorcIntereses = dr.Field(Of Decimal)("PorcIntereses")
         .CantidadCuotas = dr.Field(Of Integer)("CantidadCuotas")

         If Not String.IsNullOrEmpty(dr("IdProveedor").ToString()) Then
            .IdProveedor = Integer.Parse(dr("IdProveedor").ToString())
            .CodigoProveedor = Integer.Parse(dr("CodigoProveedor").ToString())
            .NombreProveedor = dr("NombreProveedor").ToString()
         End If

      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Function GetTodos() As List(Of Entidades.Tarjeta)
      Return EjecutaConConexion(Function() _GetTodos(activas:=False))
   End Function
   Public Function GetTodos(activas As Boolean) As List(Of Entidades.Tarjeta)
      Return EjecutaConConexion(Function() _GetTodos(activas))
   End Function

   Public Function _GetTodos(activas As Boolean) As List(Of Entidades.Tarjeta)
      Return CargaLista(GetAll(activas), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Tarjeta())
   End Function

   Public Function GetUno(idTarjeta As Integer) As Entidades.Tarjeta
      Return EjecutaConConexion(Function() _GetUno(idTarjeta))
   End Function

   Friend Function _GetUno(idTarjeta As Integer) As Entidades.Tarjeta
      Return CargaEntidad(New SqlServer.Tarjetas(da).Tarjetas_G1(idTarjeta),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Tarjeta(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe la Tarjeta con Codigo {0}", idTarjeta))
   End Function

   Public Function GetProximoId() As Integer
      Return EjecutaConConexion(Function() New SqlServer.Tarjetas(da).GetProximoId())
   End Function
   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.Tarjetas(da).GetPorNombreExacto(nombre)
   End Function

#End Region

End Class