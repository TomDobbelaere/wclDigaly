﻿Imports System.Media

Public Class Form1

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs)
        'DyProgressbar1.Value = TrackBar1.Value
    End Sub

    Private Sub DySlider1_MouseMove(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        'Custom textbox paint
    End Sub


    Private Sub DyFlatButton1_Click(sender As Object, e As EventArgs)
        MessageBox.Show("doushite digaru")
    End Sub

    Private Sub DySlider1_ValueChanged()

    End Sub

    Private Sub DyFlatButton3_Click(sender As Object, e As EventArgs)
        MessageBox.Show("wow")
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub DyTextboxBorder1_Load(sender As Object, e As EventArgs) 

    End Sub

    Private Sub DyColorPicker1_SelectedColorChanged() Handles DyColorPicker1.SelectedColorChanged
        Dim c As Color = DyColorPicker1.SelectedColor

        DyFlatButton1.BackColor = c
        DyFlatButton2.ForeColor = c
        DyFlatButton2.BackColor = c

        DyTitleBar1.BackColor = c
        DyCheckbox1.ForeColor = c

    End Sub
End Class
