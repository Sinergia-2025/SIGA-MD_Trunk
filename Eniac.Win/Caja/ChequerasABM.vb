#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Eniac.Win
#End Region
Public Class ChequerasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ChequerasDetalle(DirectCast(Me.GetEntidad(), Entidades.Chequera))
      End If
      Return New ChequerasDetalle(New Eniac.Entidades.Chequera())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Chequeras()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.Chequeras().GetUno(CInt(.Cells(Entidades.Chequera.Columnas.IdCuentaBancaria.ToString()).Value),
                                              CInt(.Cells(Entidades.Chequera.Columnas.NumeroDesde.ToString()).Value))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      Try
         With Me.dgvDatos.DisplayLayout.Bands(0)
            Dim col As Integer = 0

            .Columns(Entidades.Chequera.Columnas.IdChequera.ToString()).FormatearColumna("IdChequera", col, 60, HAlign.Right, True)
            .Columns(Entidades.Chequera.Columnas.IdCuentaBancaria.ToString()).FormatearColumna("IdCuentaBancaria", col, 60, HAlign.Right, True)
            .Columns("NombreCuenta").FormatearColumna("Cuenta Bancaria", col, 120, HAlign.Left)
            .Columns(Entidades.Chequera.Columnas.NumeroDesde.ToString()).FormatearColumna("Desde", col, 60, HAlign.Right)
            .Columns(Entidades.Chequera.Columnas.NumeroHasta.ToString()).FormatearColumna("Hasta", col, 60, HAlign.Right)
            .Columns(Entidades.Chequera.Columnas.NombreChequera.ToString()).FormatearColumna("Chequera", col, 150, HAlign.Left)
            .Columns(Entidades.Chequera.Columnas.NumeroActual.ToString()).FormatearColumna("Actual", col, 60, HAlign.Right)
            .Columns(Entidades.Chequera.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 60, HAlign.Center)
            .Columns(Entidades.Chequera.Columnas.Descripcion.ToString()).FormatearColumna("Descripción", col, 200, HAlign.Left)

         End With

         ' Agrego el Filtro en Linea x Descripción de la clase
         AgregarFiltroEnLinea(dgvDatos, {"NombreCuenta", "NombreChequera"})
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

End Class