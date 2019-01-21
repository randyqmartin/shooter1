Public Class Form1

    Public Const MAX_MISSILES As Integer = 20       'this many missiles at one time
    Public Const MAX_SHIPS As Integer = 10          'this many ships at one time


    Public Structure missile_struct
        Dim img As Label              'the missile object
        Dim available As Boolean    'if true, the missile can be launched
        Dim shift_x As Integer      'the amount to shift left/right
        Dim shift_y As Integer      'the amount to shift up/down
        Dim speed As Integer        'how many pixels we want to move in our direction for each tick
        Dim angle As Integer        'the angle of missile: from 0 to 180, with 90 being straight up and 0 being to the right
    End Structure

    Public Structure ship_struct
        Dim img As Label              'the ship object
        Dim available As Boolean    'if true, the ship can be sent out
        Dim shift_x As Integer      'the amount to shift left/right
        Dim shift_y As Integer      'the amount to shift up/down
        Dim speed As Integer        'how many pixels we want to move in our direction for each tick
    End Structure


    'Globals
    Public missiles() As missile_struct         'our array of missiles
    Public ships() As ship_struct               'our array of ships
    Public launcher_angle As Integer            'our current launcher angle
    
    Function random_int(ByVal lowerbound, ByVal upperbound)
        'returns random number integer inclusive between lowerbound and upperbound
        Return (CInt(Int((upperbound - lowerbound + 1) * Rnd() + lowerbound)))
    End Function

    Private Sub initialize_missiles()
        Dim i As Integer

        ReDim missiles(MAX_MISSILES)

        For i = 0 To MAX_MISSILES
            missiles(i).available = True    'all are available
        Next
    End Sub

    Private Sub initialize_ships()
        Dim i As Integer

        ReDim ships(MAX_SHIPS)

        For i = 0 To MAX_SHIPS
            ships(i).available = True    'all are available
        Next
    End Sub

    Private Sub tick_missile_move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_missile_move.Tick
        Dim i, j As Integer
        Dim img_mid_x, img_mid_y As Integer

        For i = 0 To MAX_MISSILES
            If missiles(i).available = False Then    'the missile is launched, move it
                missiles(i).img.Left += missiles(i).shift_x
                missiles(i).img.Top += missiles(i).shift_y

                'Debug.Print(String.Format("mnum={0}, sx={1}, sy={2}", _
                '                          i, missiles(i).shift_x, missiles(i).shift_y))
                'Debug.Print(String.Format("mnum={0}, L={1}, T={2}", _
                '                          i, missiles(i).img.Left, missiles(i).img.Top))

                'if we are out of range of the form, then release the missile by setting its availability back to True
                If missiles(i).img.Left > Me.Width + missiles(i).img.Image.Width Or _
                missiles(i).img.Left < (0 - missiles(i).img.Image.Width) Or _
                missiles(i).img.Top < (0 - missiles(i).img.Image.Height) Then
                    missiles(i).available = True
                    missiles(i).img = Nothing
                End If
            End If
        Next

        'now check to see if any missile has hit a ship
        For i = 0 To MAX_MISSILES
            If missiles(i).available = False Then    'the missile is launched, check it
                'check each ship to see if we have hit that ship
                For j = 0 To MAX_SHIPS
                    'only check ships that are launched and only use missiles that are fired and not already blowed up
                    If ships(j).available = False And missiles(i).available = False Then
                        img_mid_x = missiles(i).img.Left + missiles(i).img.Size.Width / 2
                        img_mid_y = missiles(i).img.Top + missiles(i).img.Size.Height / 2

                        If img_mid_y > ships(j).img.Top And _
                        img_mid_y < ships(j).img.Top + ships(j).img.Size.Height Then
                            If img_mid_x > ships(j).img.Left And _
                            img_mid_x < ships(j).img.Left + ships(j).img.Size.Width Then
                                'we have a hit
                                Debug.Print(String.Format("hit at {0}:{1}", img_mid_x, img_mid_y))
                                'blow up missile
                                missiles(i).img.Visible = False
                                missiles(i).available = True
                                'blow up ship
                                ships(j).img.Visible = False
                                ships(j).available = True
                                'now add to score?
                            End If
                        End If
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub create_missile(ByVal i As Integer)
        'pass in the missile number to calculate for in the missile array
        'make sure the angle and speed are already filled in for this array entry
        'then this routine fills in the shift_ values and creates the missile object and marks it for launch
        Dim xx, yy As Integer

        'note that xx and yy are passed in ByRef so they will be changed to the new values when this routine returns
        calculate_coordinates(missiles(i).angle, missiles(i).speed, xx, yy)

        'xx and yy have the shift values, put them in to the array
        missiles(i).shift_x = xx
        missiles(i).shift_y = -yy   'we are going up

        'create missile object label and position it for launch on our form
        missiles(i).img = New Label
        missiles(i).img.Parent = PictureBox1
        missiles(i).img.Image = My.Resources.fireball
        missiles(i).img.Width = My.Resources.fireball.Width
        missiles(i).img.Height = My.Resources.fireball.Height
        missiles(i).img.BackColor = Color.Transparent

        'launch the missile from the bottom middle of the 'PictureBox1' object
        missiles(i).img.Left = Me.PictureBox1.Left + (Me.PictureBox1.Size.Width / 2)
        missiles(i).img.Top = Me.PictureBox1.Bottom - missiles(i).img.Size.Height
        missiles(i).img.Visible = True

        'now mark the missile as launched
        missiles(i).available = False

    End Sub

    Private Sub create_ship(ByVal i As Integer)
        'pass in the ship number to create
        'make sure speed is already filled in for this array entry

        'create ship object label and position it on our form
        ships(i).img = New Label
        ships(i).img.Parent = PictureBox1
        ships(i).img.Image = My.Resources.Spaceship1
        ships(i).img.Width = My.Resources.Spaceship1.Width
        ships(i).img.Height = My.Resources.Spaceship1.Height
        ships(i).img.BackColor = Color.Transparent

        'position the ship at far left of screen
        ships(i).img.Left = Me.PictureBox1.Left - ships(i).img.Size.Width
        'create the ship in the full picturebox1 frame but less than 2 image heights from the bottom
        ships(i).img.Top = Me.Top + random_int(1, PictureBox1.Height - 2 * ships(i).img.Size.Height)
        ships(i).speed = random_int(10, 30)
        ships(i).shift_x = ships(i).speed
        ships(i).shift_y = 0
        ships(i).img.Visible = True

        'now mark the ship as launched
        ships(i).available = False

    End Sub

    Private Sub fire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        fire_missile()
    End Sub

    Private Sub fire_missile()
        'launch a new missile
        Dim i As Integer

        'find first available missile slot and use it, then return
        For i = 0 To MAX_MISSILES
            If missiles(i).available Then
                'use this slot for the missile
                'launch with current speed setting from slider and with current launcher_angle
                missiles(i).speed = Me.speed_slider.Value
                missiles(i).angle = launcher_angle
                create_missile(i)
                Return
            End If
        Next
    End Sub

    Private Sub initialize_form(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Randomize()

        launcher_angle = 0
        initialize_missiles()
        initialize_ships()

        'PictureBox1.BackColor = Color.Transparent
        'PictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0)

    End Sub

    Private Sub tick_create_ship(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_create_ship.Tick
        Dim i As Integer

        'randomly create a new ship

        '10% chance to create a new ship
        If random_int(1, 10) = 1 Then
            'find first available ship slot and use it, then return
            For i = 0 To MAX_SHIPS
                If ships(i).available Then
                    'use this slot for the ship
                    create_ship(i)
                    Return
                End If
            Next
        End If
    End Sub

    Private Sub tick_ship_move(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_ship_move.Tick
        Dim i As Integer

        For i = 0 To MAX_SHIPS
            If ships(i).available = False Then    'the ship is launched, move it
                ships(i).img.Left += ships(i).shift_x
                ships(i).img.Top += ships(i).shift_y

                'if we are out of range of the form, then release the ship by setting its availability back to True
                If ships(i).img.Left > Me.Width + ships(i).img.Image.Width Or _
                ships(i).img.Left < (0 - ships(i).img.Image.Width) Or _
                ships(i).img.Top < (0 - ships(i).img.Image.Height) Then
                    ships(i).available = True
                    ships(i).img = Nothing
                End If
            End If
        Next
    End Sub

    Private Sub show_crosshairs()
        
        Dim height As Integer = 150
        Dim new_x, new_y As Integer

        'get new coordinates from launcher_angle and height
        calculate_coordinates(launcher_angle, height, new_x, new_y)

        launcher_crosshairs.Left = (launcher_silo.Left + launcher_silo.Size.Width / 2) + new_x - launcher_crosshairs.Size.Width / 2
        launcher_crosshairs.Top = (launcher_silo.Top - launcher_silo.Size.Height / 2) - new_y - launcher_crosshairs.Size.Height / 2

    End Sub

    Private Sub calculate_coordinates(ByVal angle As Integer, ByVal hyp As Integer, ByRef x As Integer, ByRef y As Integer)

        Dim a As Double     'adjacent
        Dim o As Double     'opposite
        Dim angle_ratio As Double   'tan of angle

        'To calculate for new coordinates for movement:
        '
        'for a right angled triangle, the following methods apply:
        '
        '                       *
        '             h      *  *
        '                *      *  o = opposite
        '            *  A       *  
        '         ***************
        '               a = adjacent
        '
        '   h = hypotenuse
        '   o = opposite side
        '   a = adjacent side
        '   A = angle between adjacent and hypotenuse
        '
        '   From trigonometry, the Tan of the angle is the ratio between the opposite and the adjacent
        '      e.g.  tan A = o / a
        '
        ' We know the angle.. it ranges from
        '     0 (going directly to the right)
        '     to 90 (going straight up)
        '     to 180 (going directly to the left)
        ' We also know the value of h, the hypotenuse
        ' Knowing angle and hyp, we can calculate for o and a and then add them to the label position to
        ' get the new coordinate

        'First, get the ratio of opposite to adjacent using trig
        'convert angle to radians first (multiply by PI and divide by 180.0)
        'Always keep the ratio positive (Abs). We will determine direction later in this routine
        angle_ratio = Math.Abs(Math.Tan(angle * Math.PI / 180.0))

        'now solve for a and o using Pythagoras and substitution
        'h*h = o*o + a*a, therefore a = Math.Sqrt(h*h)/o*o). 
        'Substitute for o in equation in order to isolate a
        'o = angle_ratio * a
        '
        a = Math.Sqrt((hyp * hyp) / (1 + (angle_ratio * angle_ratio)))
        o = angle_ratio * a

        'now we have our new lengths, make sure direction is correct
        If angle > 90 Then  'we are angled to the left
            a = -a
        Else
            a = a
        End If

        'returns coordinate values as integers back to the calling routine
        'round the doubles to integers to be as accurate as possible
        x = Math.Round(a)
        y = Math.Round(o)
    End Sub

    Private Sub slider_key_down(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles launcher_trackbar.KeyDown
        If e.KeyData = Keys.Space Then
            fire_missile()
        End If
    End Sub

    Private Sub event_launcher_trackbar(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles launcher_trackbar.ValueChanged
        If launcher_trackbar.Value <> launcher_angle Then
            launcher_angle = launcher_trackbar.Value
            show_crosshairs()
        End If
    End Sub

End Class
