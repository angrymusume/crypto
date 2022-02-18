Private Sub cryptoSingleFile(path, toExtension, key, iv)
        Dim encryptor As DESCryptoServiceProvider = New DESCryptoServiceProvider()
        encryptor.Key = key
        encryptor.IV = iv
        Dim encryption As ICryptoTransform = encryptor.CreateEncryptor(encryptor.Key, encryptor.IV)

        Dim input As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read)
        Dim output As FileStream = New FileStream(path & toExtension, FileMode.Create, FileAccess.Write)
        Dim encEngine As CryptoStream = New CryptoStream(output, encryption, CryptoStreamMode.Write)
        Dim buffer(input.Length - 1) As Byte
        input.Read(buffer, 0, buffer.Length)
        encEngine.Write(buffer, 0, buffer.Length)
        encEngine.Close()
        input.Close()
        output.Close()

    End Sub
