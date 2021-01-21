Imports System.Windows.Forms

Public Class frmReplicateObjects
    Dim Blue As Byte
    Dim Red As Byte
    Dim Yellow As Byte
    Dim Green As Byte

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Blue = 0 Then rdbBB.Checked = True Else rdbBB.Checked = False
        If Blue = 1 Then rdbBR.Checked = True Else rdbBR.Checked = False
        If Blue = 2 Then rdbBY.Checked = True Else rdbBY.Checked = False
        If Blue = 3 Then rdbBG.Checked = True Else rdbBG.Checked = False

        If Red = 0 Then rdbRB.Checked = True Else rdbRB.Checked = False
        If Red = 1 Then rdbRR.Checked = True Else rdbRR.Checked = False
        If Red = 2 Then rdbRY.Checked = True Else rdbRY.Checked = False
        If Red = 3 Then rdbRG.Checked = True Else rdbRG.Checked = False

        If Yellow = 0 Then rdbYB.Checked = True Else rdbYB.Checked = False
        If Yellow = 1 Then rdbYR.Checked = True Else rdbYR.Checked = False
        If Yellow = 2 Then rdbYY.Checked = True Else rdbYY.Checked = False
        If Yellow = 3 Then rdbYG.Checked = True Else rdbYG.Checked = False

        If Green = 0 Then rdbGB.Checked = True Else rdbGB.Checked = False
        If Green = 1 Then rdbGR.Checked = True Else rdbGR.Checked = False
        If Green = 2 Then rdbGY.Checked = True Else rdbGY.Checked = False
        If Green = 3 Then rdbGG.Checked = True Else rdbGG.Checked = False
        Me.Close()
    End Sub

    Private Sub frmReplicateObjects_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If rdbBB.Checked Then Blue = 0
        If rdbBR.Checked Then Blue = 1
        If rdbBY.Checked Then Blue = 2
        If rdbBG.Checked Then Blue = 3
        If rdbRB.Checked Then Red = 0
        If rdbRR.Checked Then Red = 1
        If rdbRY.Checked Then Red = 2
        If rdbRG.Checked Then Red = 3
        If rdbYB.Checked Then Yellow = 0
        If rdbYR.Checked Then Yellow = 1
        If rdbYY.Checked Then Yellow = 2
        If rdbYG.Checked Then Yellow = 3
        If rdbGB.Checked Then Green = 0
        If rdbGR.Checked Then Green = 1
        If rdbGY.Checked Then Green = 2
        If rdbGG.Checked Then Green = 3
    End Sub
End Class
