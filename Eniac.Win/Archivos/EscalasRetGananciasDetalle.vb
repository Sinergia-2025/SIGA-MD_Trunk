﻿Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class EscalasRetGananciasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _productosComp As DataTable

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.EscalaRetGanancias)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            DirectCast(Me._entidad, Entidades.EscalaRetGanancias).Usuario = actual.Nombre
         Else

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EscalasRetGanancias()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      If Not Me.HayError Then
         Me.Close()
      End If
   End Sub

#End Region

#Region "Eventos"

   Private Sub RegimenesDetalle_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
      Try
         If Me.StateForm = Win.StateForm.Actualizar Then
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"


#End Region


End Class