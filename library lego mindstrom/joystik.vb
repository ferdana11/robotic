Imports Microsoft.DirectX.DirectInput
Namespace robotik_informatika_controller


    Public Class joystik
        Shared stik As Device
        Shared state As JoystickState

        ''' <summary>
        ''' fungsi untuk mengenalkan fungsi-fungsi joystik pada program fungsi ini adalah fungsi pertama yang harus dijalankan ketika
        ''' ingin menjalankan fungsi joystik yang lain
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub pasang_joystick()
            Dim gameControllerList As DeviceList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly)

            ' seleksi apakah gamepadnya tidak 0/kosong
            If (gameControllerList.Count > 0) Then

                ' pilih joystick pertama
                gameControllerList.MoveNext()
                ' buat object instansiasi gameconrollerlist
                Dim deviceInstance As DeviceInstance = gameControllerList.Current

                stik = New Device(deviceInstance.InstanceGuid)


            End If

            stik.SetDataFormat(DeviceDataFormat.Joystick)
            stik.Acquire()



        End Sub

        Public Enum tombol As Integer
            segitiga = 1
            kotak = 2
            bulat = 3
            silang = 4
            selec = 5
            start = 6
            arah_kanan = 7
            arah_kiri = 8
            arah_bawah = 9
            arah_atas = 10
            R1 = 11
            R2 = 12
            R3 = 13
            L1 = 14
            L2 = 15
            L3 = 16
        End Enum
        Public Enum jenis_analog As Integer
            kiri = 1
            kanan = 2

        End Enum
        Public Enum koordinat As Integer
            x = 1
            y = 2
            z = 3

        End Enum

        ''' <summary>
        ''' fungsi untuk mendapatkan nilai koordinat analog joystik 
        ''' </summary>
        ''' <param name="analog">jenis analog analog kiri atau kanan</param>
        ''' <param name="koordinat">jenis koordinat yang ingin didapatkan dari joystik. 
        ''' catatan: joystik kiri hanya dapat menampilkan koordinat x dan y dan joystik kanan hanya menampilkan koordinat z</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function koordinat_analog(ByVal analog As jenis_analog, ByVal koordinat As koordinat) As Integer
            stik.Poll()
            state = stik.CurrentJoystickState
            Select Case analog
                Case jenis_analog.kiri
                    If koordinat = joystik.koordinat.x Then
                        Return state.X
                    ElseIf koordinat = joystik.koordinat.y Then
                        Return state.Y
                    End If
                Case jenis_analog.kanan

                    If koordinat = joystik.koordinat.z Then
                        Return state.Z

                    End If


            End Select
        End Function

        ''' <summary>
        ''' fungsi ini adalah fungsi untuk mendapatkan arah dari analog joystik, arah disini adalah atas, bawah, kiri, kanan
        ''' catatan: joystik kanan hanya arah atas, bawah
        ''' </summary>
        ''' <param name="analog">jenis analog joystik kiri atau kanan</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function arah_analog(ByVal analog As jenis_analog) As String
            stik.Poll()
            state = stik.CurrentJoystickState
            Select Case analog
                Case jenis_analog.kiri
                    If state.Y = 0 Then
                        Return "atas"
                    ElseIf state.Y = 65535 Then
                        Return "bawah"
                    ElseIf state.X = 0 Then
                        Return "kiri"
                    ElseIf state.X = 65535 Then
                        Return "kanan"

                    End If
                Case jenis_analog.kanan
                    If state.Z = 0 Then
                        Return "atas"
                    ElseIf state.Z = 65535 Then
                        Return "bawah"

                    End If
            End Select
        End Function

        ''' <summary>
        ''' fungsi untuk mendapatkan nilai apakah tombol dari joystik di tekan atau tidak, 
        ''' catatan nilai true berarti tombol ditekan nilai false berarti tombol tidak ditekan
        ''' </summary>
        ''' <param name="tombol">jenis tombol dari joystik</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function tekan_tombol(ByVal tombol As tombol) As Boolean

            stik.Poll()
            state = stik.CurrentJoystickState
            Select Case tombol

                Case joystik.tombol.arah_atas
                    If state.GetPointOfView(0) = 0 Then
                        Return True
                    ElseIf state.GetPointOfView(0) = -1 Then
                        Return False

                    End If

                Case joystik.tombol.arah_bawah
                    If state.GetPointOfView(0) = 18000 Then
                        Return True
                    ElseIf state.GetPointOfView(0) = -1 Then
                        Return False

                    End If

                Case joystik.tombol.arah_kanan
                    If state.GetPointOfView(0) = 9000 Then
                        Return True
                    ElseIf state.GetPointOfView(0) = -1 Then
                        Return False

                    End If

                Case joystik.tombol.arah_kiri
                    If state.GetPointOfView(0) = 27000 Then
                        Return True
                    ElseIf state.GetPointOfView(0) = -1 Then
                        Return False

                    End If


                Case joystik.tombol.segitiga

                    If state.GetButtons(0) = 128 Then
                        Return True
                    ElseIf state.GetButtons(0) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.bulat
                    If state.GetButtons(1) = 128 Then
                        Return True
                    ElseIf state.GetButtons(1) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.silang
                    If state.GetButtons(2) = 128 Then
                        Return True
                    ElseIf state.GetButtons(2) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.kotak
                    If state.GetButtons(3) = 128 Then
                        Return True
                    ElseIf state.GetButtons(3) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.L2
                    If state.GetButtons(4) = 128 Then
                        Return True
                    ElseIf state.GetButtons(4) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.R2
                    If state.GetButtons(5) = 128 Then
                        Return True
                    ElseIf state.GetButtons(5) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.L1
                    If state.GetButtons(6) = 128 Then
                        Return True
                    ElseIf state.GetButtons(6) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.R1
                    If state.GetButtons(7) = 128 Then
                        Return True
                    ElseIf state.GetButtons(7) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.start
                    If state.GetButtons(9) = 128 Then
                        Return True
                    ElseIf state.GetButtons(9) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.selec
                    If state.GetButtons(8) = 128 Then
                        Return True
                    ElseIf state.GetButtons(8) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.L3
                    If state.GetButtons(10) = 128 Then
                        Return True
                    ElseIf state.GetButtons(10) = 0 Then

                        Return False

                    End If

                Case joystik.tombol.R3
                    If state.GetButtons(11) = 128 Then
                        Return True
                    ElseIf state.GetButtons(11) = 0 Then

                        Return False

                    End If

            End Select


        End Function

    End Class
End Namespace