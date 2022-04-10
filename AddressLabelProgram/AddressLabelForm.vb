'Jessica McArthur
'RCET0265   
'Spring 2020
'Address label program
'

Public Class AddressLabelForm

    'User input is validated
    Private Function ValidateInput() As Boolean
        Dim valid As Boolean = False
        Dim zipCode As Integer

        If FirstNameTextBox.Text = " " Then
            AccumlateMessages("First Name is required")
            FirstNameTextBox.Focus()
            valid = False
        End If

        If CityTextBox.Text = " " Then
            AccumlateMessages("Last Name is required")
            CityTextBox.Focus()
            valid = False
        End If

        If LastNameTextBox.Text = " " Then
            AccumlateMessages("Address and Street is required")
            LastNameTextBox.Focus()
            valid = False
        End If

        If StateTextBox.Text = " " Then
            AccumlateMessages("City is required")
            StateTextBox.Focus()
            valid = False
        End If

        If StreetAddressTextBox.Text = " " Then
            AccumlateMessages("State is required")
            StreetAddressTextBox.Focus()
            valid = False
        End If

        Try
            zipCode = CInt(ZipTextBox.Text)
        Catch ex As Exception
            AccumlateMessages("Zip code is required as number")
            ZipTextBox.Focus()
            valid = False
        End Try

        Return valid
    End Function

    'Shows error messages
    Private Function AccumlateMessages(Optional newMessage As String = " ", Optional clear As Boolean = False) As String
        Static _message As String

        Select Case clear
            Case False
                If newMessage <> "" Then
                    _message &= newMessage & vbCrLf
                End If
            Case Else
                _message = ""
        End Select

        Return _message
    End Function

    'Displays the input information
    Private Function Summary() As String
        Dim _summary As String
        'example of address:
        'First Name Last Name
        'Street Address
        ' City, State Zip 

        _summary &= FirstNameTextBox.Text & " " & CityTextBox.Text & vbNewLine
        _summary &= LastNameTextBox.Text & vbNewLine
        _summary &= StateTextBox.Text & " " & StreetAddressTextBox.Text & vbNewLine
        _summary &= StrDup(30, " ") & ZipTextBox.Text

        Return _summary
    End Function

    'reset all controls to default (blank)
    Private Sub Reset()
        FirstNameTextBox.Text = " "
        CityTextBox.Text = " "
        LastNameTextBox.Text = " "
        StateTextBox.Text = " "
        StreetAddressTextBox.Text = " "
        ZipTextBox.Text = " "
    End Sub

    ' buttons 

    'shows submitted address
    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click

        If ValidateInput() = False Then
            DisplayLabel.Text = " "
            DisplayLabel.Text = Summary()
        End If
    End Sub

    'exits the program
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    'resets the input and output
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Reset()
    End Sub

End Class
