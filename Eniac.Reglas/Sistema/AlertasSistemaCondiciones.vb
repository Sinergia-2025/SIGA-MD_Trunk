Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistemaCondiciones
      Inherits Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         NombreEntidad = AlertaSistemaCondicion.NombreTabla
         da = accesoDatos
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, AlertaSistemaCondicion)))
      End Sub
      Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, AlertaSistemaCondicion)))
      End Sub
      Public Overrides Sub Borrar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, AlertaSistemaCondicion)))
      End Sub

      Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
         Return New SqlServer.Sistema.AlertasSistemaCondiciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As DataTable
         Return New SqlServer.Sistema.AlertasSistemaCondiciones(da).AlertasSistemaCondiciones_GA()
      End Function
      Public Overloads Function GetAll(idAlertaSistema As Integer) As DataTable
         Return New SqlServer.Sistema.AlertasSistemaCondiciones(da).AlertasSistemaCondiciones_GA(idAlertaSistema)
      End Function
#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As AlertaSistemaCondicion, tipo As TipoSP)
         Dim sqlC = New SqlServer.Sistema.AlertasSistemaCondiciones(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AlertasSistemaCondiciones_I(en.IdAlertaSistema, en.OrdenCondicion,
                                                en.CondicionCount, en.ValorCondicionCount, en.MensajeCount, en.ColorCondicionCount,
                                                en.OrdenPrioridad, en.MostrarPopUp, en.ParametrosAdicionalesPantalla)
            Case TipoSP._U
               sqlC.AlertasSistemaCondiciones_U(en.IdAlertaSistema, en.OrdenCondicion,
                                                en.CondicionCount, en.ValorCondicionCount, en.MensajeCount, en.ColorCondicionCount,
                                                en.OrdenPrioridad, en.MostrarPopUp, en.ParametrosAdicionalesPantalla)
            Case TipoSP._D
               sqlC.AlertasSistemaCondiciones_D(en.IdAlertaSistema, en.OrdenCondicion)
         End Select
      End Sub

      Private Sub CargarUno(o As AlertaSistemaCondicion, dr As DataRow)
         With o
            .IdAlertaSistema = dr.Field(Of Integer)(AlertaSistemaCondicion.Columnas.IdAlertaSistema.ToString())
            .OrdenCondicion = dr.Field(Of Integer)(AlertaSistemaCondicion.Columnas.OrdenCondicion.ToString())

            .CondicionCount = dr.Field(Of String)(AlertaSistemaCondicion.Columnas.CondicionCount.ToString()).StringToEnum(CondicionesCountAlerta.Mayor)
            .ValorCondicionCount = dr.Field(Of Integer)(AlertaSistemaCondicion.Columnas.ValorCondicionCount.ToString())
            .MensajeCount = dr.Field(Of String)(AlertaSistemaCondicion.Columnas.MensajeCount.ToString())
            .ColorCondicionCount = dr.Field(Of Integer?)(AlertaSistemaCondicion.Columnas.ColorCondicionCount.ToString()).ToArgbColor()

            .OrdenPrioridad = dr.Field(Of Integer)(AlertaSistemaCondicion.Columnas.OrdenPrioridad.ToString())
            .MostrarPopUp = dr.Field(Of Boolean)(AlertaSistemaCondicion.Columnas.MostrarPopUp.ToString())
            .ParametrosAdicionalesPantalla = dr.Field(Of String)(AlertaSistemaCondicion.Columnas.ParametrosAdicionalesPantalla.ToString())

         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As AlertaSistemaCondicion)
         EjecutaSP(entidad, TipoSP._I)
      End Sub
      Public Sub _Actualizar(entidad As AlertaSistemaCondicion)
         EjecutaSP(entidad, TipoSP._U)
      End Sub
      Public Sub _Borrar(entidad As AlertaSistemaCondicion)
         EjecutaSP(entidad, TipoSP._D)
      End Sub
      Public Sub _Insertar(entidad As AlertaSistema)
         entidad.Condiciones.ForEach(
            Sub(c)
               c.IdAlertaSistema = entidad.IdAlertaSistema
               If c.OrdenCondicion = 0 Then
                  c.OrdenCondicion = GetCodigoMaximo(c.IdAlertaSistema) + 1
               End If
               _Insertar(c)
            End Sub)
      End Sub
      Public Sub _Actualizar(entidad As AlertaSistema)
         _Borrar(entidad)
         _Insertar(entidad)
      End Sub
      Public Sub _Borrar(entidad As AlertaSistema)
         _Borrar(New AlertaSistemaCondicion() With {.IdAlertaSistema = entidad.IdAlertaSistema})
      End Sub

      Public Function GetUno(idAlertaSistema As Integer, ordenCondicion As Integer) As AlertaSistemaCondicion
         Return GetUno(idAlertaSistema, ordenCondicion, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idAlertaSistema As Integer, ordenCondicion As Integer, accion As AccionesSiNoExisteRegistro) As AlertaSistemaCondicion
         Return CargaEntidad(New SqlServer.Sistema.AlertasSistemaCondiciones(da).AlertasSistemaCondiciones_G1(idAlertaSistema, ordenCondicion),
                             Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistemaCondicion(),
                             accion, Function() String.Format("No existe Alerta con Id: {0} y orden: {1}", idAlertaSistema, ordenCondicion))
      End Function
      Public Function GetTodos(idAlertaSistema As Integer) As List(Of AlertaSistemaCondicion)
         Return CargaLista(GetAll(idAlertaSistema),
                           Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistemaCondicion())
      End Function

      Public Function GetCodigoMaximo(idAlertaSistema As Integer) As Integer
         Return New SqlServer.Sistema.AlertasSistemaCondiciones(da).GetCodigoMaximo(idAlertaSistema)
      End Function

#End Region

   End Class
End Namespace