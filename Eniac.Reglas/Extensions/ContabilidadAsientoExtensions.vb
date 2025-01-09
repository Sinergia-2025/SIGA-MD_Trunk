Imports System.Runtime.CompilerServices

Namespace Extensions
   Public Module ContabilidadAsientoExtensions
      <Extension>
      Public Function InicializaManual(a As Entidades.ContabilidadAsiento) As Entidades.ContabilidadAsiento
         Return InicializaManual(a, New ContabilidadEstadosAsientos())
      End Function
      <Extension>
      Public Function InicializaAutomatico(a As Entidades.ContabilidadAsiento) As Entidades.ContabilidadAsiento
         Return InicializaAutomatico(a, New ContabilidadEstadosAsientos())
      End Function

      <Extension>
      Public Function InicializaManual(a As Entidades.ContabilidadAsiento, da As Datos.DataAccess) As Entidades.ContabilidadAsiento
         Return InicializaManual(a, New ContabilidadEstadosAsientos(da))
      End Function
      <Extension>
      Public Function InicializaAutomatico(a As Entidades.ContabilidadAsiento, da As Datos.DataAccess) As Entidades.ContabilidadAsiento
         Return InicializaAutomatico(a, New ContabilidadEstadosAsientos(da))
      End Function

      Private Function InicializaManual(a As Entidades.ContabilidadAsiento, r As ContabilidadEstadosAsientos) As Entidades.ContabilidadAsiento
         Return Inicializa(a, r.GetUnoPorDefectoManual())
      End Function
      Private Function InicializaAutomatico(a As Entidades.ContabilidadAsiento, r As ContabilidadEstadosAsientos) As Entidades.ContabilidadAsiento
         Return Inicializa(a, r.GetUnoPorDefectoAutomatico())
      End Function


      Private Function Inicializa(a As Entidades.ContabilidadAsiento, e As Entidades.ContabilidadEstadoAsiento) As Entidades.ContabilidadAsiento
         a.IdEstadoAsiento = e.IdEstadoAsiento
         Return a
      End Function
   End Module
End Namespace