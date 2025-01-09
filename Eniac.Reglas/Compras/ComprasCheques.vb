Option Explicit On
Option Strict On

#Region "Imports"

Imports Eniac.Entidades
Imports Eniac.Reglas
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual

#End Region

Public Class ComprasCheques
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ComprasCheques"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.GrabarCompra(DirectCast(entidad, Entidades.CompraCheque))

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub Graba(ByVal ent As Entidades.CompraCheque)
      Try

         Dim sql As SqlServer.ComprasCheques = New SqlServer.ComprasCheques(da)

         'sql.ComprasCheques_I(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, _
         '                     ent.Proveedor.IdProveedor)

      Catch ex As Exception
         If ex.Message.IndexOf("Cannot insert duplicate key in object") > -1 Then
            Throw New Exception("El Comprobante ya existe y no lo puede volver a cargar.")
         Else
            Throw ex
         End If
      End Try
   End Sub

#End Region

#Region "Metodos Publicos"


   Public Sub EliminarCompraCheque(ByVal compra As Entidades.Compra)

      Dim oCompra As Entidades.Compra = DirectCast(compra, Entidades.Compra)

      Try

         Dim sql As SqlServer.ComprasCheques = New SqlServer.ComprasCheques(da)
         sql.ComprasCheques_D(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor, oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor)

      Catch ex As Exception

      End Try
   End Sub

   Friend Sub GrabarCompra(ByVal comp As Entidades.CompraCheque)

      Me.Graba(comp)

   End Sub


#End Region



End Class
