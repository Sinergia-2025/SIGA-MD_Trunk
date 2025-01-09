Public Class FuncionesABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New FuncionesDetalle(DirectCast(GetEntidad(), Entidades.Funcion))
      End If
      Return New FuncionesDetalle(New Entidades.Funcion())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Funciones()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
      Sub()
         Dim frmImprime = New VisorReportes("Eniac.Win.Funciones.rdlc", "SeguridadDataSet_Funciones", dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Funciones"
         frmImprime.Show()
      End Sub)
   End Sub
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return New Reglas.Funciones().GetUna(dr.Field(Of String)(Entidades.Funcion.Columnas.Id.ToString()), cargaDocumentos:=True, cargaVinculadas:=True)
   End Function

   Protected Overrides Sub FormatearGrilla()
      dgvDatos.AgregarFiltroEnLinea({"Id", "Nombre", "Descripcion", "Pantalla", "Parametros"})

      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I
         .Columns(Entidades.Funcion.Columnas.Id.ToString()).FormatearColumna("Id", col, 150)
         .Columns(Entidades.Funcion.Columnas.Nombre.ToString()).FormatearColumna("Nombre", col, 280)
         .Columns(Entidades.Funcion.Columnas.EsMenu.ToString()).FormatearColumna("Es Menu", col, 60, HAlign.Center)
         .Columns(Entidades.Funcion.Columnas.EsBoton.ToString()).FormatearColumna("Es Boton", col, 60, HAlign.Center)
         .Columns(Entidades.Funcion.Columnas.Enabled.ToString()).FormatearColumna("Habilitado", col, 60, HAlign.Center)
         .Columns(Entidades.Funcion.Columnas.Visible.ToString()).FormatearColumna("Visible", col, 60, HAlign.Center)
         .Columns(Entidades.Funcion.Columnas.EsMDIChild.ToString()).FormatearColumna("Abre dentro de Menú Principal", col, 80, HAlign.Center)
         .Columns(Entidades.Funcion.Columnas.IdPadre.ToString()).FormatearColumna("Padre", col, 150)
         .Columns("NombrePadre").FormatearColumna("Nombre Padre", col, 280)
         .Columns(Entidades.Funcion.Columnas.Posicion.ToString()).FormatearColumna("Posición", col, 70, HAlign.Center)
         .Columns(Entidades.Funcion.Columnas.Archivo.ToString()).FormatearColumna("Archivo", col, 150)
         .Columns(Entidades.Funcion.Columnas.Pantalla.ToString()).FormatearColumna("Pantalla", col, 150)
         .Columns(Entidades.Funcion.Columnas.PermiteMultiplesInstancias.ToString()).FormatearColumna("Multiple Pantalla", col, 80, HAlign.Center)
         .Columns(Entidades.Funcion.Columnas.Icono.ToString()).FormatearColumna("Icono", col, 100)

         'Pasado al final para que entre informacion mas importante en la primer pantalla.
         .Columns(Entidades.Funcion.Columnas.Descripcion.ToString()).FormatearColumna("Descripción", col, 200)
         .Columns(Entidades.Funcion.Columnas.Parametros.ToString()).FormatearColumna("Parámetros", col, 100)

         If Reglas.Publicos.ExtrasSinergia Then
            'If Publicos.CuitEmpresa = "33711345499" Then
            .Columns(Entidades.Funcion.Columnas.Plus.ToString()).FormatearColumna("Plus", col, 50, HAlign.Center, False)
            .Columns(Entidades.Funcion.Columnas.Express.ToString()).FormatearColumna("Express", col, 50, HAlign.Center, False)
            .Columns(Entidades.Funcion.Columnas.Basica.ToString()).FormatearColumna("Básica", col, 50, HAlign.Center, False)
            .Columns(Entidades.Funcion.Columnas.PV.ToString()).FormatearColumna("PV", col, 50, HAlign.Center, False)
            .Columns(Entidades.Funcion.Columnas.IdModulo.ToString()).FormatearColumna("IdModulo", col, 50, HAlign.Center, False)
            .Columns("NombreModulo").FormatearColumna("NombreModulo", col, 50, HAlign.Center, False)

         Else
            .Columns(Entidades.Funcion.Columnas.Plus.ToString()).FormatearColumna("Plus", col, 50, HAlign.Center, True)
            .Columns(Entidades.Funcion.Columnas.Express.ToString()).FormatearColumna("Express", col, 50, HAlign.Center, True)
            .Columns(Entidades.Funcion.Columnas.Basica.ToString()).FormatearColumna("Básica", col, 50, HAlign.Center, True)
            .Columns(Entidades.Funcion.Columnas.PV.ToString()).FormatearColumna("PV", col, 50, HAlign.Center, True)
            .Columns(Entidades.Funcion.Columnas.IdModulo.ToString()).FormatearColumna("IdModulo", col, 50, HAlign.Center, True)
            .Columns("NombreModulo").FormatearColumna("Nombre Módulo", col, 50, HAlign.Center, True)
         End If


      End With
   End Sub
#End Region
End Class