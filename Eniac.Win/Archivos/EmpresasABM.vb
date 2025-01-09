Option Strict On
Option Explicit On
Public Class EmpresasABM

#Region "Overrides"


   Protected Overrides Sub Nuevo()
      Dim sistema As Entidades.Sistema = Publicos.GetSistema()
      Dim cantidadEmpresas As Integer = New Reglas.Empresas().Count()
      If sistema.CantidadEmpresasContratadas > cantidadEmpresas Then
         MyBase.Nuevo()
      Else
         ShowMessage(String.Format("Ha llegado a la cantidad máxima de empresas contratadas ({0}). Por favor comuniquese con Sinergia Software para contratar más empresas", sistema.CantidadEmpresasContratadas))
      End If
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EmpresasDetalle(DirectCast(Me.GetEntidad(), Entidades.Empresa))
      End If
      Return New EmpresasDetalle(New Entidades.Empresa)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Empresas()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr As DataRow = dgvDatos.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Return New Reglas.Empresas().GetUno(Integer.Parse(dr(Entidades.Empresa.Columnas.IdEmpresa.ToString()).ToString()))
      End If
      Return Nothing
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.Empresa.Columnas.IdEmpresa.ToString()).FormatearColumna("Código", pos, 70, HAlign.Right)
         .Columns(Entidades.Empresa.Columnas.NombreEmpresa.ToString()).FormatearColumna("Nombre", pos, 300)
         .Columns(Entidades.Empresa.Columnas.CuitEmpresa.ToString()).FormatearColumna("Cuit", pos, 80)
         .Columns("IdCategoriaFiscal").OcultoPosicion(True, pos)
         .Columns("NombreCategoriaFiscal").FormatearColumna("Categoría Fiscal", pos, 150)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.Empresa.Columnas.NombreEmpresa.ToString(), Entidades.Empresa.Columnas.CuitEmpresa.ToString()})
   End Sub

#End Region

End Class