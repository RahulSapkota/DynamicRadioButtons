Imports System.Text

Public Class Form1

    '**************************Note*******************************
    'In case of requirement for Increasing variables and value retrieval follow below steps
    'step 1 add variable as given below based on row i.e
    'row[rownumber]checkbox[yes] For yes checkbox  And row[rownumber]checkbox[no] for no checkboxes

    'step 2 follow like below for yes no . in place of row number just place the actual row number i.e 1 or 2 or 3
    'If _radionamevalue(i).Name = "Yes_" & {rownumber} Then
    'row1checkboxyes = Getvalue(_radionamevalue(i).Value)
    '_selected.AppendLine(_radionamevalue(i).Name & " " + row1checkboxyes)'

    'If _radionamevalue(i).Name = "No_" & {rownumber} Then
    'row1checkboxyes = Getvalue(_radionamevalue(i).Value)
    '_selected.AppendLine(_radionamevalue(i).Name & " " + row1checkboxyes)'

    '**************************End of Note*******************************


    ''' <summary>
    ''' Controls that are required inorder to generate and group radio buttons
    ''' </summary>
    Private radiobuttonsparentcontrolpanel As Panel = Nothing

    'List will contain all the controls 
    Private _allratiobuttons As List(Of RadioButton) = New List(Of RadioButton)()

    'for holding the result for testing output produced
    Private _selected As StringBuilder = Nothing

    'single panel for each pair of radio button for grouping
    Private specificradiobuttonpanel As Panel = Nothing

    'for storing the values and easy reterival without parsing as radio button everytime
    Private _radionamevalue As List(Of RadioButtonNameValue) = Nothing


    ''' <summary>
    ''' Variables can be added here if Required More
    ''' </summary>
    Private row1checkboxyes As String = String.Empty
    Private row1checkboxno As String = String.Empty
    Private row2checkboxyes As String = String.Empty
    Private row2checkboxno As String = String.Empty
    Private row3checkboxyes As String = String.Empty
    Private row3checkboxno As String = String.Empty
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Create and Display controls
        GenerateDynamicControls()

    End Sub

    Private Sub GenerateDynamicControls(ByVal Optional numberofradiobuttonstogenerate As Integer = 3)
        Dim xaxis As Integer = 5
        Dim yaxis As Integer = 25
        Dim totalheightoccupiedbygroupbox As Integer = 0
        radiobuttonsparentcontrolpanel = New Panel()
        radiobuttonsparentcontrolpanel.AutoSize = True

        'Create Radio Button Controls vertically for yes and no as a single pair e.g
        ' yes no
        ' yes no
        For i As Integer = 0 To numberofradiobuttonstogenerate - 1

            'radio button 1
            Dim rdo As RadioButton = New RadioButton()
            rdo.Name = "Yes_" & i 'name as unique
            rdo.Text = "Yes"
            rdo.Location = New Point(xaxis, yaxis)
            rdo.Width = 50
            rdo.Height = 40
            rdo.TextAlign = ContentAlignment.MiddleCenter
            _allratiobuttons.Add(rdo)

            'radio button 2
            Dim rdo1 As RadioButton = New RadioButton()
            rdo1.Name = "No_" & i 'name as unique
            rdo1.Text = "No"
            rdo1.Location = New Point(xaxis * 15, yaxis)
            rdo1.TextAlign = ContentAlignment.MiddleCenter
            rdo1.Width = 50
            rdo1.Height = 40
            _allratiobuttons.Add(rdo1)

            'Create  new panel for each radio button pair
            specificradiobuttonpanel = New Panel()
            specificradiobuttonpanel.Height = rdo1.Height + 20

            'Calculate the height as each panel is added if not calculated new generated panel will be hidden on backside
            totalheightoccupiedbygroupbox += specificradiobuttonpanel.Height / 2
            specificradiobuttonpanel.Width = 150

            'add radio buttons
            specificradiobuttonpanel.Controls.Add(rdo)
            specificradiobuttonpanel.Controls.Add(rdo1)

            'set location of groupbox
            specificradiobuttonpanel.Location = New Point(xaxis, totalheightoccupiedbygroupbox)

            'add radiobuttons to parent panel control
            radiobuttonsparentcontrolpanel.Controls.Add(specificradiobuttonpanel)
        Next

        'add parent panel control to form
        Me.Controls.Add(radiobuttonsparentcontrolpanel)

        'create a button
        Dim btnok As Button = New Button()
        btnok.Text = "OK"

        'set event handler for button click event
        AddHandler btnok.Click, AddressOf btnok_Click

        'set location of button
        btnok.Location = New Point(0, radiobuttonsparentcontrolpanel.Height)

        'add button to form
        Me.Controls.Add(btnok)


    End Sub
    Private Sub btnok_Click(ByVal sender As Object, ByVal e As EventArgs)

        'Get the values and set it as name value in the List<RadioButtonNameValue>
        GetCheckedValuesOfRadioButton()

        'will hold result for testing puropse
        'can be commented out as per requirement
        _selected = New StringBuilder()

        'Iterate over the list to get values
        ' the name value will be added as matrix
        ' row0checkbox0 row0checkbox1 etc
        For i As Integer = 0 To _radionamevalue.Count - 1

            'Yes_0 means checkbox in row0checkbox0
            If _radionamevalue(i).Name = "Yes_" & 0 Then
                row1checkboxyes = _radionamevalue(i).Value.ToString()
                _selected.Append(_radionamevalue(i).Name & "=>" + row1checkboxyes + "   ")

                'No_0 means checkbox in row0checkbox1
            ElseIf _radionamevalue(i).Name = "No_" & 0 Then
                row1checkboxno = _radionamevalue(i).Value.ToString()
                _selected.Append(_radionamevalue(i).Name & "=>" + row1checkboxyes + Environment.NewLine)

                'Yes_1 means checkbox in row1checkbox0
            ElseIf _radionamevalue(i).Name = "Yes_" & 1 Then
                row2checkboxyes = _radionamevalue(i).Value.ToString()
                _selected.Append(_radionamevalue(i).Name & "=>" + row1checkboxyes + "   ")

                'No_1 means checkbox in row1checkbox1
            ElseIf _radionamevalue(i).Name = "No_" & 1 Then
                row2checkboxno = _radionamevalue(i).Value.ToString()
                _selected.Append(_radionamevalue(i).Name & "=>" + row1checkboxyes + Environment.NewLine)

                'Yes_2 means checkbox in row2checkbox0
            ElseIf _radionamevalue(i).Name = "Yes_" & 2 Then
                row3checkboxyes = _radionamevalue(i).Value.ToString()
                _selected.Append(_radionamevalue(i).Name & "=>" + row1checkboxyes + "   ")

                'No_2 means checkbox in row2checkbox1
            ElseIf _radionamevalue(i).Name = "No_" & 2 Then
                row3checkboxno = _radionamevalue(i).Value.ToString()
                _selected.Append(_radionamevalue(i).Name & "=>" + row1checkboxyes + "   ")
            End If
        Next

        'Just comment/uncomment messagebox as per requirement for debugging
        MessageBox.Show(_selected.ToString())
    End Sub

    ''' <summary>
    ''' Fetch name and values from Radiobutton collection
    ''' </summary>
    Private Sub GetCheckedValuesOfRadioButton()
        _radionamevalue = New List(Of RadioButtonNameValue)()
        For Each radioButton As RadioButton In _allratiobuttons
            _radionamevalue.Add(New RadioButtonNameValue() With {
                .Name = radioButton.Name,
                .Value = radioButton.Checked,
                .Text = radioButton.Text
            })
        Next
    End Sub


End Class


