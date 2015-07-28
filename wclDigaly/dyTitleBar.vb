﻿Imports System.ComponentModel

Public Class dyTitleBar
    Private previousClick As Integer = SystemInformation.DoubleClickTime
    Public Shadows Event DoubleClick As EventHandler
    Private useLightTheme As Boolean = True

    Dim minbutton As New dyTitlebarButton()
    Dim maxbutton As New dyTitlebarButton()
    Dim xbutton As New dyTitlebarButton()

    <Browsable(False)>
    Public Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(value As String)
            MyBase.Text = value
            Invalidate()
        End Set
    End Property

    <Browsable(True)>
    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value
            Invalidate()
        End Set
    End Property

    Public Property LightTheme As Boolean
        Get
            Return useLightTheme
        End Get
        Set(value As Boolean)
            useLightTheme = value
            UpdateButtons()
            Invalidate()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()

        Dock = DockStyle.Top
        Me.Height = 30

        minbutton.ButtonType = dyTitlebarButton.ButtonMode.Minimize
        minbutton.Dock = DockStyle.Right
        Me.Controls.Add(minbutton)

        maxbutton.ButtonType = dyTitlebarButton.ButtonMode.Maximize
        maxbutton.Dock = DockStyle.Right

        Me.Controls.Add(maxbutton)

        xbutton.Dock = DockStyle.Right

        Me.Controls.Add(xbutton)
    End Sub

    Sub UpdateButtons()
        If Not useLightTheme Then
            minbutton.LightTheme = False
            minbutton.BackColor = BackColor
            maxbutton.LightTheme = False
            maxbutton.BackColor = BackColor
            xbutton.LightTheme = False
            xbutton.BackColor = BackColor
        Else
            minbutton.LightTheme = True
            maxbutton.LightTheme = True
            xbutton.LightTheme = True
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim sf As StringFormat = New StringFormat()
        sf.Alignment = StringAlignment.Near
        sf.LineAlignment = StringAlignment.Center

        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        If useLightTheme Then
            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle)
            e.Graphics.DrawString(Me.FindForm().Text, Font, Brushes.Black, New RectangleF(e.ClipRectangle.X + 5, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height), sf)
        Else
            e.Graphics.FillRectangle(New SolidBrush(BackColor), e.ClipRectangle)
            e.Graphics.DrawString(Me.FindForm().Text, Font, Brushes.White, New RectangleF(e.ClipRectangle.X + 5, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height), sf)
        End If

        'Add your custom paint code here
    End Sub

    Protected Overrides Sub OnResize(eventargs As EventArgs)
        MyBase.OnResize(eventargs)

        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        If e.Button = MouseButtons.Left Then
            Me.Capture = False
            Const WM_NCLBUTTONDOWN As Integer = &HA1S
            Const HTCAPTION As Integer = 2
            Dim msg As Message =
                Message.Create(Me.FindForm().Handle, WM_NCLBUTTONDOWN,
                    New IntPtr(HTCAPTION), IntPtr.Zero)
            Me.DefWndProc(msg)
        End If

        Invalidate()
    End Sub
End Class
