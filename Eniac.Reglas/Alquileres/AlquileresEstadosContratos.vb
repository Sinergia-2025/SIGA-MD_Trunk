
Option Explicit On
Option Strict On

Imports System.Text

Public Class AlquileresEstadosContratos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "AlquileresEstadosContratos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sql As SqlServer.AlquileresEstadosContratos = New SqlServer.AlquileresEstadosContratos(Me.da)
      Return sql.AlquilerEstados_GA
   End Function

   Public Function GetUno(ByVal IdEstado As Integer) As Entidades.AlquilerEstadoContrato
      Dim sql As SqlServer.AlquileresEstadosContratos = New SqlServer.AlquileresEstadosContratos(Me.da)
      Dim dt As DataTable = sql.AlquilerEstados_G1(IdEstado)
      Dim o As Entidades.AlquilerEstadoContrato = New Entidades.AlquilerEstadoContrato()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Estado de Contrato de Alquiler")
      End If
      Return o
   End Function

   Private Sub CargarUna(ByVal o As Entidades.AlquilerEstadoContrato, ByVal dr As DataRow)
      With o
         .IdEstado = Integer.Parse(dr(Entidades.AlquilerEstadoContrato.Columnas.IdEstado.ToString()).ToString())
         .NombreEstado = dr(Entidades.AlquilerEstadoContrato.Columnas.NombreEstado.ToString()).ToString()
      End With
   End Sub

End Class
