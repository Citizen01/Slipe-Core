# Installation

## What is Slipe?

Slipe is an open source framework that enables anyone to write scripts for [MTA:San Andreas](https://multitheftauto.com) in C# instead of Lua, wrapping all MTA elements and classes and including some .NET Core namespaces. It is based on [CSharp.lua](https://github.com/yanghuan/CSharp.lua) by [Yang Huan](https://github.com/yanghuan).

## Prerequisites

* [.NET Core 3.0 (preview)](https://dotnet.microsoft.com/download/dotnet-core/3.0)
* [Visual studio 2019](https://visualstudio.microsoft.com/downloads/)

Since .NET Core 3.0 is still in preview you need to manually activate it in Visual Studio. You need to go to `Tools > Options > Environment > Preview features` and check the "Use previews of the .NET Core SDK" checkbox.

## Installing Slipe

### Windows
* Download the [Slipe installer](/downloads/SlipeInstaller.exe)
* Run the installer .exe file
* Run the `slipe` command anywhere on your system in a command prompt to verify installation worked.

### Linux
* Download the latest version of [Slipe-CLI](/downloads/slipe-linux.zip)
* Unzip the downloaded file
* run `sudo ./install.sh`
* Run the `slipe` command anywhere on your system in a command prompt to verify installation worked.

## Having trouble?

If you are having trouble getting set up you can ask your question on our [discord server](https://discord.gg/NwEK894)