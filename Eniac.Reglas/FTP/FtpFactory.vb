Option Strict On
Option Explicit On
Public Class FtpFactory
   Public Shared Function Crear() As IFtp
      Dim servidorFTP As String = Reglas.Publicos.FTPServidor
      Dim usuarioFTP As String = Reglas.Publicos.FTPUsuario
      Dim claveFTP As String = Reglas.Publicos.FTPPassword
      Dim conexionPasivaFTP As Boolean = Reglas.Publicos.FTPConexionPasiva
      Dim carpetaRemotaFTP As String = Reglas.Publicos.FTPCarpetaRemota

      Dim ftp As IFtp = New Reglas.SimpleFtp(servidorFTP, usuarioFTP, claveFTP)
      ftp.UsePassive = conexionPasivaFTP

      Return ftp
   End Function
End Class