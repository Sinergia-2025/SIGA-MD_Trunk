#Region "Option"
Option Strict On
Option Explicit On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion

#End Region
Public Class CRMMediosComunicacionesNovedades
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMMedioComunicacionNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMMedioComunicacionNovedadJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMMedioComunicacionNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMMedioComunicacionNovedadJSon)

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMMediosComunicacionesNovedades"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMMedioComunicacionNovedad), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMMedioComunicacionNovedad), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMMedioComunicacionNovedad), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CRMMediosComunicacionesNovedades = New SqlServer.CRMMediosComunicacionesNovedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMMediosComunicacionesNovedades(Me.da).CRMMediosComunicacionesNovedades_GA()
   End Function

   Public Overloads Function GetAll(TipoNovedad As Entidades.CRMTipoNovedad) As System.Data.DataTable
      If TipoNovedad Is Nothing Then
         Return GetAll()
      Else
         Return GetAll(TipoNovedad.IdTipoNovedad, False)
      End If
   End Function
   Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.CRMMediosComunicacionesNovedades(Me.da).CRMMediosComunicacionesNovedades_GA(idTipoNovedad, ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMMedioComunicacionNovedad, tipo As TipoSP)
      Dim sqlC As SqlServer.CRMMediosComunicacionesNovedades = New SqlServer.CRMMediosComunicacionesNovedades(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CRMMediosComunicacionesNovedades_I(en.IdMedioComunicacionNovedad, en.NombreMedioComunicacionNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto, en.Color)
         Case TipoSP._U
            sqlC.CRMMediosComunicacionesNovedades_U(en.IdMedioComunicacionNovedad, en.NombreMedioComunicacionNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto, en.Color)
         Case TipoSP._D
            sqlC.CRMMediosComunicacionesNovedades_D(en.IdMedioComunicacionNovedad)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CRMMedioComunicacionNovedad, dr As DataRow)
      With o
         .IdMedioComunicacionNovedad = Integer.Parse(dr(Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString()).ToString())
         .NombreMedioComunicacionNovedad = dr(Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()).ToString()
         .Posicion = Integer.Parse(dr(Entidades.CRMMedioComunicacionNovedad.Columnas.Posicion.ToString()).ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMMedioComunicacionNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
         .PorDefecto = CBool(dr(Entidades.CRMMedioComunicacionNovedad.Columnas.PorDefecto.ToString()).ToString())

         If IsNumeric(dr(Entidades.CRMMedioComunicacionNovedad.Columnas.Color.ToString())) Then
            .Color = Integer.Parse(dr(Entidades.CRMMedioComunicacionNovedad.Columnas.Color.ToString()).ToString())
         Else
            .Color = Nothing
         End If

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idMedioComunicacionNovedad As Integer) As Entidades.CRMMedioComunicacionNovedad
      Return GetUno(idMedioComunicacionNovedad, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idMedioComunicacionNovedad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CRMMedioComunicacionNovedad
      Return CargaEntidad(New SqlServer.CRMMediosComunicacionesNovedades(Me.da).CRMMediosComunicacionesNovedades_G1(idMedioComunicacionNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMMedioComunicacionNovedad(),
                          accion, Function() String.Format("No existe un Medio de Comunicación con Código {0}", idMedioComunicacionNovedad))
   End Function

   Public Function GetTodos(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMMedioComunicacionNovedad)
      Return CargaLista(Me.GetAll(idTipoNovedad, ordenarPosicion),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMMedioComunicacionNovedad())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CRMMediosComunicacionesNovedades(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.CRMMediosComunicacionesNovedades(Me.da).
                                       GetCodigoMaximo(Entidades.CRMMedioComunicacionNovedad.Columnas.Posicion.ToString(),
                                                       "CRMMediosComunicacionesNovedades",
                                                       String.Format("{0} = '{1}'", Entidades.CRMMedioComunicacionNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   End Function
   Public Function GetPorCodigo(codigo As Integer, idTipoNovedad As String) As DataTable
      Return New SqlServer.CRMMediosComunicacionesNovedades(da).CRMMediosComunicacionNovedades_GxCodigo(codigo, idTipoNovedad)
   End Function

   Public Function GetPorNombre(nombre As String, idTipoNovedad As String) As DataTable
      Return New SqlServer.CRMMediosComunicacionesNovedades(da).CRMMediosComunicacionNovedades_PorNombre(nombre, nombreExacto:=False, idTipoNovedad)
   End Function
#End Region
End Class
