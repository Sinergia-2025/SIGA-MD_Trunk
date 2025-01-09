Option Strict On
Option Explicit On
Namespace Ayudante
   Public Class Validadores
      Inherits Eniac.Reglas.Base
#Region "Constructores"

      Public Sub New()
         Me.NombreEntidad = "Marcas"
         da = New Datos.DataAccess()
      End Sub

      Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
         Me.NombreEntidad = "Marcas"
         da = accesoDatos
      End Sub

#End Region

      Public Function ValidaCuit(cuit As String, donde As Entidades.Ayudante.Validadores.ValidarExistenciaEn, primaryKeyActual As Object()) As Boolean
         Dim blnAbreQuery As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
         Try
            If blnAbreQuery Then da.OpenConection()
            Dim result As Boolean = True

            If donde = Entidades.Ayudante.Validadores.ValidarExistenciaEn.AduanasAgentesTransporte Or donde = Entidades.Ayudante.Validadores.ValidarExistenciaEn.Todos Then
               If Not New SqlServer.Ayudante.Validadores(da).ValidaCuit(cuit, donde, Entidades.AduanaAgenteTransporte.Columnas.Cuit.ToString(),
                                                                        String.Format(" {0} <> {1}", Entidades.AduanaAgenteTransporte.Columnas.IdAgenteTransporte.ToString(), primaryKeyActual(0))) Then
                  result = False
               End If
            End If
            If donde = Entidades.Ayudante.Validadores.ValidarExistenciaEn.AduanasDespachantes Or donde = Entidades.Ayudante.Validadores.ValidarExistenciaEn.Todos Then
               If Not New SqlServer.Ayudante.Validadores(da).ValidaCuit(cuit, donde, Entidades.AduanaDespachante.Columnas.Cuit.ToString(),
                                                                        String.Format(" {0} <> {1}", Entidades.AduanaDespachante.Columnas.IdDespachante.ToString(), primaryKeyActual(0))) Then
                  result = False
               End If
            End If
            If donde = Entidades.Ayudante.Validadores.ValidarExistenciaEn.Clientes Or donde = Entidades.Ayudante.Validadores.ValidarExistenciaEn.Todos Then
               If Not New SqlServer.Ayudante.Validadores(da).ValidaCuit(cuit, donde, Entidades.Cliente.Columnas.Cuit.ToString(),
                                                                        String.Format(" {0} <> {1}", Entidades.Cliente.Columnas.IdCliente.ToString(), primaryKeyActual(0))) Then
                  result = False
               End If
            End If
            If donde = Entidades.Ayudante.Validadores.ValidarExistenciaEn.Proveedores Or donde = Entidades.Ayudante.Validadores.ValidarExistenciaEn.Todos Then
               If Not New SqlServer.Ayudante.Validadores(da).ValidaCuit(cuit, donde, Entidades.Proveedor.Columnas.CuitProveedor.ToString(),
                                                                        String.Format(" {0} <> {1}", Entidades.Proveedor.Columnas.IdProveedor.ToString(), primaryKeyActual(0))) Then
                  result = False
               End If
            End If

            Return result
         Finally
            If blnAbreQuery Then da.CloseConection()
         End Try

      End Function

   End Class
End Namespace