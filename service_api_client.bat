sc stop "SHELTER_api_client"
sc delete "SHELTER_api_client"
sc create "SHELTER_api_client" binPath= "D:\CSharpProject\SHELTER\SHELTER_api_client\bin\Debug\net8.0\SHELTER_api_client.exe" start="auto"
sc start "SHELTER_api_client"