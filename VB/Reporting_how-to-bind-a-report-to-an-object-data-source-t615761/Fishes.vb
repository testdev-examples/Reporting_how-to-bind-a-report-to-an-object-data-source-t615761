Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports DevExpress.DataAccess.ObjectBinding


Namespace ObjectDataSource
	<DisplayName("Fishes"), HighlightedClass>
	Public Class Fishes
		Inherits List(Of Fish)

		<HighlightedMember>
		Public Sub New(ByVal filePath As String)
			Dim path As String = TryCast(AppDomain.CurrentDomain.GetData("DataDirectory"), String)
			If Not String.IsNullOrEmpty(path) Then
				filePath = System.IO.Path.Combine(path, filePath)
			End If
			If File.Exists(filePath) Then
				Using stream As Stream = File.OpenRead(filePath)
					Me.LoadFrom(stream)
				End Using
			End If
		End Sub
		Public Sub New(ByVal stream As Stream)
			Me.LoadFrom(stream)
		End Sub
		Private Sub LoadFrom(ByVal stream As Stream)
			Dim input As TextReader = New StreamReader(stream)
			Dim line As String
			Dim id As Integer = 0
			line = input.ReadLine()
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: while ((line = input.ReadLine()) != null)
			Do While line IsNot Nothing
				Dim items() As String = line.Split("|"c)
				If items.Length = 4 Then
					id += 1
					Dim fishItem As New Fish(items(0), items(1), items(2), items(3), id)
					Me.Add(fishItem)
				End If
				line = input.ReadLine()
			Loop
			input.Close()
		End Sub
	End Class
	Public Class Fish
'INSTANT VB NOTE: The field id was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private id_Renamed As Integer
'INSTANT VB NOTE: The field category was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private category_Renamed As String = "Undefined"
'INSTANT VB NOTE: The field commonName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private commonName_Renamed As String = "Undefined"
'INSTANT VB NOTE: The field speciesName was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private speciesName_Renamed As String = "Undefined"
'INSTANT VB NOTE: The field notes was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private notes_Renamed As String = "Undefined"

		<DisplayName("Fish Category")>
		Public Property Category() As String
			Get
				Return category_Renamed
			End Get
			Set(ByVal value As String)
				category_Renamed = value
			End Set
		End Property
		<DisplayName("Fish Common Name")>
		Public Property CommonName() As String
			Get
				Return commonName_Renamed
			End Get
			Set(ByVal value As String)
				commonName_Renamed = value
			End Set
		End Property
		<DisplayName("Fish Species Name")>
		Public Property SpeciesName() As String
			Get
				Return speciesName_Renamed
			End Get
			Set(ByVal value As String)
				speciesName_Renamed = value
			End Set
		End Property
		<DisplayName("Fish Notes")>
		Public Property Notes() As String
			Get
				Return notes_Renamed
			End Get
			Set(ByVal value As String)
				notes_Renamed = value
			End Set
		End Property
		<DisplayName("Fish ID")>
		Public Property ID() As Integer
			Get
				Return id_Renamed
			End Get
			Set(ByVal value As Integer)
				id_Renamed = value
			End Set
		End Property
		Public Sub New(ByVal category As String, ByVal commonName As String, ByVal speciesName As String, ByVal notes As String, ByVal id As Integer)
			Me.category_Renamed = category
			Me.commonName_Renamed = commonName
			Me.speciesName_Renamed = speciesName
			Me.notes_Renamed = notes
			Me.id_Renamed = id
		End Sub
	End Class
End Namespace
