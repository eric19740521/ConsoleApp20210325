# ConsoleApp20210325

VS Code C# .net core 2.1開發資料庫存取程式,docker群暉nas服務器

參考資料:

https://blog.miniasp.com/post/2018/04/19/How-to-switch-between-DotNet-SDK-versions


1.vscode 
https://code.visualstudio.com/


2..net core v2.1.26
https://dotnet.microsoft.com/download/dotnet/2.1

C:\Program Files\dotnet\sdk\2.1.814

3.
dotnet new globaljson --sdk-version 2.1.814



4.建立專案夾test05




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

6.專案初始化

dotnet add package mysql.data
dotnet build 
dotnet run



0.上傳到 linux服務器上,測試跨平台專案



