# ConsoleApp20210325

VS Code C# .net core 2.1開發mysql資料庫存取程式,linux跨平台開發..docker群暉nas服務器

參考資料:
https://blog.miniasp.com/post/2018/04/19/How-to-switch-between-DotNet-SDK-versions


程式碼:https://github.com/eric19740521/ConsoleApp20210325


1.vscode 
https://code.visualstudio.com/


2..net core v2.1.26
https://dotnet.microsoft.com/download/dotnet/2.1

C:\Program Files\dotnet\sdk\2.1.814
C:\Program Files\dotnet\sdk\2.1.522		這是因為有安裝到其他版本的軟體

3.建立專案夾ConsoleApp20210325



4.限定SDK版本開發 
dotnet new globaljson --sdk-version 2.1.814



5.
查看SDK有哪些版本
dotnet --list-sdks 

限定SDK版本開發    
dotnet new globaljson
{
  "sdk": {
    "version": "2.1.814"
  }
}

6.VS Code 第三方套件
C# 
C# Extensions


7.專案初始化
dotnet new console
dotnet build 
dotnet run


dotnet add package mysql.data


8.群輝服務器docker 容器安裝 dotnet core 2.1.814
https://docs.microsoft.com/zh-tw/dotnet/core/install/linux-ubuntu

0.上傳到 linux服務器上,測試跨平台專案



