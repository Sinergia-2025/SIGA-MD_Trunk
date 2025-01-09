Imports System.Runtime.CompilerServices

Public Class ControlSistema
   Inherits Base

   Private Const FormatoMensajeControlLicencia As String = "Se detectó que existen más depositos {0} en el sistema ({1}) de los habilitados en la Licencia ({2}). NO podrá continuar."
#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess(CadenaSegura))
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(String.Empty, accesoDatos)
   End Sub
#End Region

   Public Sub ControlaValidezDeFecha(sistema As Entidades.Sistema, fecha As Date, idSucursal As Integer)
      If DateDiff(DateInterval.Day, fecha, sistema.FechaVencimiento) < 0 Then
         Throw New Exception(String.Format("La fecha es mayor a la validez del sistema, el {0:dd/MM/yyyy}", sistema.FechaVencimiento))
      End If
      ControlaCantidadDeposito(sistema, idSucursal)
   End Sub

   Public Sub ControlaCantidadDeposito(sistema As Entidades.Sistema, idSucursal As Integer)
      ControlaCantidadDeposito(sistema, idSucursal, FormatoMensajeControlLicencia)
   End Sub
   Public Sub ControlaCantidadDeposito(sistema As Entidades.Sistema, idSucursal As Integer, formatoMensaje As String)
      Dim errorBld = ControlaCantidadDeposito(sistema, idSucursal, New Entidades.ErrorBuilder(), formatoMensaje)
      If errorBld.AnyError Then
         Throw New Exception(errorBld.ErrorToString())
      End If
   End Sub
   Public Function ControlaCantidadDeposito(sistema As Entidades.Sistema, idSucursal As Integer, errorBld As Entidades.ErrorBuilder) As Entidades.ErrorBuilder
      Return ControlaCantidadDeposito(sistema, idSucursal, errorBld, FormatoMensajeControlLicencia)
   End Function
   Public Function ControlaCantidadDeposito(sistema As Entidades.Sistema, idSucursal As Integer, errorBld As Entidades.ErrorBuilder, formatoMensaje As String) As Entidades.ErrorBuilder
      Dim rDepositos = New SucursalesDepositos(da)
      For Each kv In rDepositos.GetCantidadPorTipo(idSucursal)
         sistema.ControlaCantidadDeposito(kv.Key, kv.Value, errorBld, formatoMensaje)
      Next
      Return errorBld
   End Function

End Class

Namespace Extensions
   Public Module SistemaExtensions
      <Extension()>
      Public Sub ControlaValidezDeFecha(sistema As Entidades.Sistema, fecha As Date)
         Dim r = New ControlSistema()
         r.ControlaValidezDeFecha(sistema, fecha, actual.Sucursal.Id)
      End Sub

      <Extension()>
      Public Sub ControlaCantidadDeposito(sistema As Entidades.Sistema, tipo As Entidades.SucursalDeposito.TiposDepositos, cantidadBD As Integer, formatoMensaje As String)
         Dim errorBld = ControlaCantidadDeposito(sistema, tipo, cantidadBD, New Entidades.ErrorBuilder(), formatoMensaje)
         If errorBld.AnyError Then
            Throw New Exception(errorBld.ErrorToString())
         End If
      End Sub
      <Extension()>
      Public Function ControlaCantidadDeposito(sistema As Entidades.Sistema, tipo As Entidades.SucursalDeposito.TiposDepositos,
                                               cantidadBD As Integer, errorBld As Entidades.ErrorBuilder, formatoMensaje As String) As Entidades.ErrorBuilder
         Dim cantidadLicencia = 0I
         Select Case tipo
            Case Entidades.SucursalDeposito.TiposDepositos.OPERATIVO
               cantidadLicencia = sistema.CantidadDepositosTipoOperativo
            Case Entidades.SucursalDeposito.TiposDepositos.RESERVADO
               cantidadLicencia = sistema.CantidadDepositosTipoReserva
            Case Entidades.SucursalDeposito.TiposDepositos.ENTRANSITO
               cantidadLicencia = sistema.CantidadDepositosTipoEnTransito
            Case Entidades.SucursalDeposito.TiposDepositos.DEFECTUOSO
               cantidadLicencia = sistema.CantidadDepositosTipoDefectuoso
         End Select

         If cantidadBD > cantidadLicencia Then
            errorBld.AddError(String.Format(formatoMensaje,
                                            tipo.GetDescription(), cantidadBD, cantidadLicencia))
         End If
         Return errorBld
      End Function
   End Module
End Namespace