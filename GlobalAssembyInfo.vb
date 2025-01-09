Imports System.Reflection

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

#If DEBUG Then
<Assembly: AssemblyConfiguration("DEBUG")> 
#Else
<Assembly: AssemblyConfiguration("RELEASE")>
#End If

<Assembly: AssemblyCompany("Sinergia Software")>
#If DEBUG Then
<Assembly: AssemblyProduct("SIGA - DEBUG")>
#Else
<Assembly: AssemblyProduct("SIGA")>
#End If
<Assembly: AssemblyCopyright("Copyright © Sinergia Software 2010")>
<Assembly: AssemblyTrademark("")>

' You can specify all the values or you can default the Build and Revision Numbers by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("25.13.03.1")>
<Assembly: AssemblyFileVersion("25.13.03.1")>