#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
Imports System.Web.Script.Serialization
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class SolicitarSoporte

   Private Property IdEmpresa As Integer
   Private Property BaseUri As Uri
   Private Property NombreEmpresa As String
   Private Property CuitEmpresa As String
   Private Property IdUsuario As String
   Private Property NombreUsuario As String


   Public Sub New()
      'IdEmpresa = 235
      Dim codigoClienteSinergia As String = Publicos.CodigoClienteSinergia
      If Not IsNumeric(codigoClienteSinergia) Then
         Throw New Exception("No está configurado el Codigo de Empresa.")
      End If
      IdEmpresa = Integer.Parse(codigoClienteSinergia)
      Dim simovilSoporteURLBase As String = Publicos.SimovilSoporteURLBase
      If String.IsNullOrWhiteSpace(simovilSoporteURLBase) Then
         Throw New Exception("No está configurado la URL Base para Simovil Soporte.")
      End If
      BaseUri = New Uri(simovilSoporteURLBase)
      NombreEmpresa = Publicos.NombreEmpresa
      CuitEmpresa = Publicos.CuitEmpresa
      IdUsuario = actual.Nombre
      NombreUsuario = New Reglas.Usuarios().GetUno(actual.Nombre).Nombre
   End Sub

   Public Function GetInfoParaVinculacion() As String
      Return GetInfoParaVinculacion(IdEmpresa, NombreEmpresa, CuitEmpresa, NombreUsuario)
   End Function
   Public Function GetInfoParaVinculacion(codigoCliente As Long, nombreCliente As String, cuitCliente As String, nombreUsuario As String) As String
      Dim info = New With {.BaseURL = BaseUri,
                           .CodigoEmpresa = codigoCliente,
                           .NombreEmpresa = nombreCliente,
                           .Cuit = cuitCliente,
                           .NombreUsuario = nombreUsuario,
                           .IdUsuario = IdUsuario}
      Return New JavaScriptSerializer().Serialize(info)
   End Function

End Class