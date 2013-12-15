Imports NKH.MindSqualls

Namespace robotik_informatika_ITN_lego

    Public Class nxt
        Public Shared robot As NxtBrick

        ''' <summary>
        ''' fungsi ini adalah fungsi untuk menentukan port komunikasi bluetooth
        '''
        ''' </summary>
        ''' <param name="port">nomor port koneksi</param>
        ''' <remarks></remarks>
        ''' 
        Public Shared Sub koneksi_port(ByVal port As Byte)
            robot = New NxtBrick(port)


        End Sub

        ''' <summary>
        ''' fungsi untuk mengkoneksikan pc dengan nxt
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub konek()
            robot.Connect()
            robot.PlayTone(70, 100)

        End Sub

        ''' <summary>
        ''' fungsi untuk memutus koneksi antara pc dengan nxt
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub putus_koneksi()
            If robot.IsConnected = True Then
                robot.PlayTone(100, 100)
                Threading.Thread.Sleep(600)
                robot.PlayTone(100, 100)
                robot.Disconnect()

            End If


        End Sub

        ''' <summary>
        ''' fungsi untuk melihat kondisi baterai nxt, contoh nilainya adalah 8000 yang berarti kondisi baterai tinggal 80%
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function kondisi_baterai() As UShort
            Return robot.BatteryLevel
        End Function

        ''' <summary>
        ''' fungsi untuk melihat apakah nxt telah terkoneksi dengan pc, catatan nilai true berarti terkoneksi dan false berarti tidak terkoneksi
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function apakah_terkoneksi() As Boolean
            Return robot.IsConnected
        End Function

        ''' <summary>
        ''' fungsi untuk melihat nama robot 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function nama_robot() As String
            Return robot.Name
        End Function

        ''' <summary>
        ''' fungsi untuk menjalankan program yang tersimpan di dalam nxt
        ''' </summary>
        ''' <param name="nama_program">nama program dalam bentuk string contoh: "hallo"</param>
        ''' <remarks></remarks>
        Public Shared Sub jalankan_program(ByVal nama_program As String)
            robot.Program = nama_program



        End Sub

        ''' <summary>
        ''' fungsi untuk melihat daftar program yang tersimpan di nxt dan akan tersimpan di dalam array string
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function daftar_program_di_robot() As String()
            Return robot.Programs

        End Function

        ''' <summary>
        ''' fungsi untuk melihat daftar sound atau suara yang tersimpan di nxt dan akan tersimpan di dalam array string
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function daftar_sound_di_robot() As String()
            Return robot.Sounds

        End Function

        ''' <summary>
        ''' fungsi untuk menghentikan suara nxt
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub hentikan_suara()
            robot.StopSound()

        End Sub

        ''' <summary>
        ''' fungsi untuk membunyikan nada didalam nxt
        ''' </summary>
        ''' <param name="frekuensi">frekuensi nada/suara</param>
        ''' <param name="durasi">durasi nada</param>
        ''' <remarks></remarks>
        Public Shared Sub bunyikan_suara(ByVal frekuensi As UShort, ByVal durasi As UShort)
            robot.PlayTone(frekuensi, durasi)
        End Sub

        ''' <summary>
        ''' fungsi untuk memutar lagu yang tersimpan di dalam nxt
        ''' </summary>
        ''' <param name="nama_lagu">nama file lagu</param>
        ''' <remarks></remarks>
        Public Shared Sub putar_lagu(ByVal nama_lagu As String)
            robot.PlaySoundfile(nama_lagu & ".rso")

        End Sub

    End Class


    Public Class motor


#Region "motor"

#Region "enumerasi dan instansiasi motor"


        Public Enum pilihan_putaran_motor As Integer
            maju = 1
            mundur = 2

        End Enum

        Public Enum pilihan_motor As Integer
            motorA = 1
            motorB = 2
            motorC = 3

        End Enum

        ''' <summary>
        ''' fungsi untuk memasang motor a kedalam program fungsi ini adalah fungsi pertama yang harus dieksekusi sebelum menggunakan 
        ''' fungsi motor yang lain
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub pasangkan_motorA()
            nxt.robot.MotorA = New NxtMotor
        End Sub
        ''' <summary>
        ''' fungsi untuk memasang motor b kedalam program fungsi ini adalah fungsi pertama yang harus dieksekusi sebelum menggunakan 
        ''' fungsi motor yang lain
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub pasangkan_motorB()
            nxt.robot.MotorB = New NxtMotor
        End Sub
        ''' <summary>
        ''' fungsi untuk memasang motor c kedalam program fungsi ini adalah fungsi pertama yang harus dieksekusi sebelum menggunakan 
        ''' fungsi motor yang lain
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub pasangkan_motorC()
            nxt.robot.MotorC = New NxtMotor
        End Sub

#End Region

        ''' <summary>
        ''' fugnsi untuk menggerakkan motor 
        ''' </summary>
        ''' <param name="jenis_putaran">jenis putaran motor dapat maju atau mundur</param>
        ''' <param name="port">port dari motor nxt</param>
        ''' <param name="kecepatan">kecepatan motor, batasan kecepatan minimum 1 dan maximum adalah 100</param>
        ''' <remarks></remarks>
        Public Shared Sub gerakkan_motor(ByVal jenis_putaran As pilihan_putaran_motor, ByVal port As pilihan_motor, ByVal kecepatan As SByte)
            Select Case port
                Case pilihan_motor.motorA

                    If jenis_putaran = pilihan_putaran_motor.maju Then
                        nxt.robot.MotorA.Run(kecepatan, 0)
                    ElseIf jenis_putaran = pilihan_putaran_motor.mundur Then
                        nxt.robot.MotorA.Run(-kecepatan, 0)
                    End If

                Case pilihan_motor.motorB

                    If jenis_putaran = pilihan_putaran_motor.maju Then
                        nxt.robot.MotorB.Run(kecepatan, 0)
                    ElseIf jenis_putaran = pilihan_putaran_motor.mundur Then
                        nxt.robot.MotorB.Run(-kecepatan, 0)
                    End If

                Case pilihan_motor.motorC

                    If jenis_putaran = pilihan_putaran_motor.maju Then
                        nxt.robot.MotorC.Run(kecepatan, 0)
                    ElseIf jenis_putaran = pilihan_putaran_motor.mundur Then
                        nxt.robot.MotorC.Run(-kecepatan, 0)
                    End If


            End Select

        End Sub

        ''' <summary>
        ''' fungsi untuk menghentikan motor 
        ''' </summary>
        ''' <param name="port"></param>
        ''' <remarks></remarks>
        Public Shared Sub berhenti(ByVal port As pilihan_motor)
            If port = pilihan_motor.motorA Then
                nxt.robot.MotorA.Brake()
            ElseIf port = pilihan_motor.motorB Then
                nxt.robot.MotorB.Brake()
            ElseIf port = pilihan_motor.motorC Then
                nxt.robot.MotorC.Brake()
            End If
        End Sub

        ''' <summary>
        ''' fungsi untuk mensingkronkan gerakan motor jadi motor 1 dan 2 kecepatannya akan sama
        ''' </summary>
        ''' <param name="motor1">motor pertama </param>
        ''' <param name="motor2">motor kedua</param>
        ''' <param name="kecepatan">kecepatan kedua motor</param>
        ''' <remarks></remarks>
        Public Shared Sub singkronkan_gerakan_motor(ByVal motor1 As pilihan_motor, ByVal motor2 As pilihan_motor, ByVal kecepatan As SByte)
            Dim tmp As NxtMotorSync

            If motor1 = pilihan_motor.motorA And motor2 = pilihan_motor.motorB Or motor1 = pilihan_motor.motorB And motor2 = pilihan_motor.motorA Then
                motor.pasangkan_motorA()
                motor.pasangkan_motorB()
                tmp = New NxtMotorSync(nxt.robot.MotorA, nxt.robot.MotorB)
                tmp.Run(kecepatan, 0, 0)

            ElseIf motor1 = pilihan_motor.motorA And motor2 = pilihan_motor.motorC Or motor1 = pilihan_motor.motorC And motor2 = pilihan_motor.motorA Then
                motor.pasangkan_motorA()
                motor.pasangkan_motorC()
                tmp = New NxtMotorSync(nxt.robot.MotorA, nxt.robot.MotorC)
                tmp.Run(kecepatan, 0, 0)

            ElseIf motor1 = pilihan_motor.motorB And motor2 = pilihan_motor.motorC Or motor1 = pilihan_motor.motorC And motor2 = pilihan_motor.motorB Then
                motor.pasangkan_motorB()
                motor.pasangkan_motorC()
                tmp = New NxtMotorSync(nxt.robot.MotorB, nxt.robot.MotorC)
                tmp.Run(kecepatan, 0, 0)





            End If
        End Sub


#End Region

    End Class


End Namespace