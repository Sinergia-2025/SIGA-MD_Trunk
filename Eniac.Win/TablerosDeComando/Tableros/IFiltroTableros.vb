Public Interface IFiltroTableros
   Function GetFiltros() As Entidades.TablerosDeComando.FiltroTableros
   Sub RefrescarGrilla()

End Interface
Public Class FiltroTablerosFactory
   Public Shared Function Crear(tablero As Entidades.TableroControl) As IFiltroTableros
      Try
         Dim nombreFiltro = tablero.IdControllerFiltro ' "Eniac.Win.FiltroTableros_CategoriaActualiza"
         If Not String.IsNullOrWhiteSpace(nombreFiltro) Then
            Dim assemblyName As String = String.Empty
            Dim className As String
            Dim splitController = nombreFiltro.Split(":"c)
            If splitController.Length > 1 Then
               assemblyName = splitController(0)
               className = splitController(1)
            Else
               If splitController(0).Contains(".") Then
                  Dim posicionUltimoPunto = splitController(0).LastIndexOf("."c)
                  assemblyName = splitController(0).Substring(0, posicionUltimoPunto)
               End If
               className = splitController(0)
            End If

            Dim assembly As System.Reflection.Assembly = Nothing
            If Not String.IsNullOrWhiteSpace(assemblyName) Then
               Try
                  assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(Function(a) a.GetName().Name = assemblyName)
               Catch ex As Exception
                  assembly = Nothing
               End Try
            End If
            If assembly Is Nothing Then
               assembly = System.Reflection.Assembly.GetExecutingAssembly()
            End If

            If Not className.Contains(".") Then
               className = String.Concat(assembly.GetName().Name, ".", className)
            End If

            Dim type = assembly.GetType(className)

            Dim obj = System.Activator.CreateInstance(type)

            If TypeOf (obj) Is IFiltroTableros Then
               Return DirectCast(obj, IFiltroTableros)
            End If

         End If
      Catch ex As Exception

      End Try
      Return Nothing
   End Function

End Class