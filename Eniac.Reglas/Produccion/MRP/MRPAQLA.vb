Public Class MRPAQLA
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.MRPAQLA.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MRPAQLA), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MRPAQLA), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MRPAQLA), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.MRPAQLA(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.MRPAQLA(da).MRPAQLA_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPAQLA, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPAQLA(da)
      Select Case tipo
         Case TipoSP._I
            If ValidarRango(en.TamanoLoteDesde, en.TamanoLoteHasta, en.IdMRPAQLA).Any() Then
               Throw New Exception(String.Format("El rango que se desea agregar se solapa otro rango."))
            End If
            en.IdMRPAQLA = GetCodigoMaximo() + 1
            sqlC.MRPAQLA_I(en.IdMRPAQLA, en.TamanoLoteDesde, en.TamanoLoteHasta,
                           en.NivelGeneral1, en.NivelGeneral2, en.NivelGeneral3,
                           en.NivelEspecialS1, en.NivelEspecialS2, en.NivelEspecialS3, en.NivelEspecialS4)
         Case TipoSP._U
            If ValidarRango(en.TamanoLoteDesde, en.TamanoLoteHasta, en.IdMRPAQLA).Any() Then
               Throw New Exception(String.Format("El rango que se desea actualizar se solapa otro rango."))
            End If
            sqlC.MRPAQLA_U(en.IdMRPAQLA, en.TamanoLoteDesde, en.TamanoLoteHasta,
                           en.NivelGeneral1, en.NivelGeneral2, en.NivelGeneral3,
                           en.NivelEspecialS1, en.NivelEspecialS2, en.NivelEspecialS3, en.NivelEspecialS4)
         Case TipoSP._D
            sqlC.MRPAQLA_D(en.IdMRPAQLA)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MRPAQLA, dr As DataRow)
      With o
         .IdMRPAQLA = dr.Field(Of Integer)(Entidades.MRPAQLA.Columnas.IdMRPAQLA.ToString())
         .TamanoLoteDesde = dr.Field(Of Integer)(Entidades.MRPAQLA.Columnas.TamanoLoteDesde.ToString())
         .TamanoLoteHasta = dr.Field(Of Integer)(Entidades.MRPAQLA.Columnas.TamanoLoteHasta.ToString())
         .NivelGeneral1 = dr.Field(Of String)(Entidades.MRPAQLA.Columnas.NivelGeneral1.ToString())
         .NivelGeneral2 = dr.Field(Of String)(Entidades.MRPAQLA.Columnas.NivelGeneral2.ToString())
         .NivelGeneral3 = dr.Field(Of String)(Entidades.MRPAQLA.Columnas.NivelGeneral3.ToString())
         .NivelEspecialS1 = dr.Field(Of String)(Entidades.MRPAQLA.Columnas.NivelEspecialS1.ToString())
         .NivelEspecialS2 = dr.Field(Of String)(Entidades.MRPAQLA.Columnas.NivelEspecialS2.ToString())
         .NivelEspecialS3 = dr.Field(Of String)(Entidades.MRPAQLA.Columnas.NivelEspecialS3.ToString())
         .NivelEspecialS4 = dr.Field(Of String)(Entidades.MRPAQLA.Columnas.NivelEspecialS4.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function Get1(idMRPAQLA As Integer) As DataTable
      Return New SqlServer.MRPAQLA(da).MRPAQLA_G1(idMRPAQLA)
   End Function
   Public Function GetUno(idMRPAQLA As Integer) As Entidades.MRPAQLA
      Return GetUno(idMRPAQLA, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idMRPAQLA As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MRPAQLA
      Return CargaEntidad(Get1(idMRPAQLA), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MRPAQLA(),
                          accion, Function() String.Format("No existe AQL A con Id: {0}", idMRPAQLA))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPAQLA)
      Return CargaLista(GetAll(), Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPAQLA())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MRPAQLA(da).GetCodigoMaximo()
   End Function
   Private Function ValidarRango(desde As Integer, hasta As Integer, idActual As Integer) As DataTable
      Return New SqlServer.MRPAQLA(da).ValidarRango(desde, hasta, idActual)
   End Function

   Public Function GetCalidadOrdenCantidad(cantidad As Decimal) As Entidades.MRPAQLA
      Return GetCalidadOrdenCantidad(cantidad, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetCalidadOrdenCantidad(cantidad As Decimal, accion As AccionesSiNoExisteRegistro) As Entidades.MRPAQLA
      Return CargaEntidad(New SqlServer.MRPAQLA(da).GetCalidadOrdenCantidad(cantidad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MRPAQLA(),
                          accion, Function() String.Format("No existe AQL A para una muestra de: {0}", cantidad))
   End Function

#End Region

End Class