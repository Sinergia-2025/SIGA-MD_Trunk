Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ArchivosAImprimirDetalle

#Region "Campos"

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ArchivoAImprimir)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         DirectCast(Me._entidad, Entidades.ArchivoAImprimir).IdSucursal = actual.Sucursal.IdSucursal
      End If


   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ArchivosAImprimir()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      If Not Me.HayError Then Me.Close()
   End Sub

#End Region

#Region "Eventos"

#End Region

#Region "Metodos"


#End Region

End Class