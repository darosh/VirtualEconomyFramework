# Virtual Economy Framework

This framework will help you to create applications related to blockchain and cryptocurrencies.
Application uses PostgreSQL to store local data, publish data to MQTT and lots of other useful features.

Main framework is .NET Core 5.0 (ASP.NET). Code is written in C#, HTML, CSS and JavaScript.
Solution is for Visual Studio 2019.

IMPORTANT! This repository is now under huge development so please wait until it will be tagged as Beta before you will post any issues or any contribution. Expected beta is planned to end of the March 2021.


# Projects in the solution

-	NeblioRestApi - .NET Core 5.0 wrapper for Neblio API.
-	TestNeblio – testing utility for integration tests.
-	VEconomy – ASP.NET application to be shaped to your app or used as it is.
-	VEDrivers – digital twins and other drivers for economy-based applications.
-	VEGameDrivers - drivers for connecting games and blockchain
-	VENodeExecutor – runs node-red as a service.
-	VEQTWalletExecutor – runs QT Wallet as a service.
-	VEUsersUtility – utility to create first admin user in Db


# Other Projects

This repository contains also project examples for Arduino IDE. It is developed on M5StickC HW. It is based on ESP32 MCU (official page: [M5Stack](https://m5stack.com/)). These projects you can find in folder [Examples-ArduinoIDE-M5StickC](https://github.com/fyziktom/VirtualEconomyFramework/tree/main/Examples/ArduinoIDE/M5StickC).

For compilation you need to install Arduino IDE and M5Stack libraries and ESP32 libraries into IDE ([Guidlines](https://docs.m5stack.com/#/en/arduino/arduino_development)).
 


# Features

-	ASP.NET Core base application, VEconomy, which can be shaped for your app needs.
-	Digital Twins of objects related to blockchain such as Wallet, Account, Transaction, Token, etc. and publishing these data to MQTT.
-	Set of drivers/helpers for economy-based applications.
-	Set of drivers/helpers for using blockchain in games
-	Simple Chess Game which store game data to blockchain as example
-	REST API with OpenAPI description in Swagger.
-	QT Wallet RPC client and controller for communication with desktop wallet or core of blockchain based on Bitcoin QT Wallet.
-	QT Wallet is optional.
-	Neblio API .NET Core wrapper (ReddCoin and Bitcoin to be soon).
-	Wrapper for NBitcoin library to simple create Neblio addresses, sign and send transactions of Nebl and Tokens without QTWallet or Nebliod (other currencies soon).
-	Integrated MQTT Broker with TCP/IP and WebSocket support
-	Connection to Binance Exchange data.
-	Testing application for integration tests.
-	Basic UI in HTML/CSS/JavaScript dependent just on Bootstrap and JQuery (and few small libs)!
-	Project for Bootstrap Studio which simplify building web-based UI of applications.
-	Functional “Nodes” which can perform some action such as HTTP API Request or MQTT Publish based on trigger from blockchain transaction (incoming and outgoing).
-	Nodes can run custom JavaScript with payload data from transaction and provide the tx result as payload for main function of Node.
-	Web UI has integrated JavaScript editor.
-	JS Script can be tested with simulated tx data or last tx real data. No need to send tx during debbuging of JS Scripts.
-	Web UI contains hash library for creating hash of any file on the client side and use it as metadata in NFT token transactions
-	Connection to Database where local data about digital twins and settings are stored.
-	Stored Last Processed Transaction and Last Confirmed Transaction for recovery after crash for each Account (works without Db too)
-	Db is connected via Entity Framework Core so it can be connected to another Db.
-	Db connection is optional and app can run without it
-	You can setup different Db providers. SQLite is default (it create default file if not exists), optional PostgreSQL and MSSQL
-	Security controller for creating users, rights, roles which limit access to API
-	Node-Red executor application – can run node.js and node-red as a service.
-	QT Wallet executor application – can run QT Wallet as a service.
-	Logging errors, infos and warrings with log4net library


# Main Planned Features

- Async loading of Tx - almost done, testing, cancel
-	DocFx documentation of project
-	Raspberry PI pre-installed image - in progress, almost done
-	ReddCoin and Bitcoin drivers (maybe Polkadot and Chainlink)
-	Lock and unlock desktop wallet and other RPC commands for wallets
-	Transactions details in UI - almost done (need to add token meta details)
-	HTTPS support
-	Analytics drivers
-	Nuget Package of VEDrivers
-	Connection to AI ML.NET Neural Network library
-	Examples of customized applications based on VEFramework - chess game example ready.
-	Examples with Arduino IDE + Client for VEconomy API
-	Connector to MS SQL - integrated, needs tests. Also integrated and tested SQLite ;)
-	Unit tests
-	Docker support


# Supported Platforms

Project is based on .NET Core 5.0 so it can run on:
-	Windows
-	Windows 10 IoT
-	Linux
-	MacOS
-	iOS
-	Android
-	x86, x64, AnyCPU, ARM
And other platforms which .NET Core 5.0 supports.


# Installation and setting

This application needs few steps of installation to run with all features.

If you do not want to use Database or QT wallet just skip these steps. In appsetings.json you can disable working with Db and QT.
You can run app without Db but with QT support and oposite too. Without QT app cannot sign transactions now!

Default setting of the app uses SQLite Db. This is automatically created after start if not exists in user AppData folder (on Win 10 C:\Users\UserName\AppData\Roaming\VEFramework). To install another database please follow instructions below.

1.	Database - Optional
-	Download build of PostgreSQL for your platform: https://www.postgresql.org/download/
-	Install it based on instructions.
-	After installation open pgAdmin and create new database named “veframework” (you can change the name, but it must be changed in “appsettings.json” in the ConnectionStrings).
-	Create new user “veadmin” with password “veadmin” (you can change the user and pass, but it must be changed in “appsettings.json” in the ConnectionStrings).
-	Open query tool and run script “CreateTableScript.sql” (VEDrivers/DDL/CreateTableScript - PostgreSQL.sql). This will create tables and fill some sample data (in section “Accounts” please fill some your account addresses instead of default example accounts address)!!!
-	Grant privileges to “veadmin” – uncomment and run just last lines of “CreateTableScript.sql” file.
-	That should be all about preparing the Database.

2.	ASP.NET Core 5.0
-	If you do not have installed ASP.NET Core 5.0 runtime and .NET Core 5.0 runtime libraries you have to install it before you run VEFramework.
-	Go to the https://dotnet.microsoft.com/download/dotnet/5.0 and download latest release and follow common installation instruction for your platform.

3.	Creating first admin user - Optional - Just with Db
-	Run “VEUserUtility.exe” Follow the instructions in console. 
-	Type “1” for add new user. At first fill login - “admin” and then full username “John Doe” (just example). All confirm with “enter” after input.
-	Type “2” to create password. At first fill login and then password. All confirm with “enter” after input.
-	That is all. Now you can use this account to login in VEconomy UI and create other users in UI.

4.	Download and synchronize Neblio desktop wallet - Optional
-	Go to the https://nebl.io/wallets/ and download wallet for your platform. 
-	Move “neblio-qt.exe” to some folder and set the path in “appsettings.json” of “VEQTWalletExecutor.exe”
-	If you do not want to use VEQTWalletExecutor you do not need to setup this.
-	Run QT Wallet and lets it synchronize with the network.
-	In QT Wallet click to "Help" -> "Debug Window" -> "Show Data Directory". In the data directory folder create new file "neblio.conf" with this content (username and pass you can change, but remeber to change it in appsetting.json of the apps):

```
server=1
rpcuser=user
rpcpassword=password
rpcport=6326
```

This step is now optional. VEFramework now contains own MQTT Broker. If you need Node-RED for another use please install it but it is not necessary for VEFramework now. 
Please remember. If you will install MQTT Broker in Node-RED you have to set different port than in VEconomy. It cannot run on same ports!

5.	Install MQTT Broker – Optional
-	If you want to use another MQTT Broker it is no problem, just VEconomy needs WS sockets too!
-	Go to the https://nodejs.org/en/ and download and install version of “node.js”.
-	Go to the https://nodered.org/ and download and install version of node-red for your platform. [Here for Linux](https://nodered.org/docs/getting-started/local), [Here for Windows](https://nodered.org/docs/getting-started/windows)
-	If you want to run node-RED as service, you can use “VENodeExecutor.exe”. Just setup in “appsettings.json” path to node.exe (node.js main app) and node-red path (common path for windows is in file, just change the username”.
-	If you do not want to use “VENodeExecutor.exe” please run node-red with type “node-red” into command line.
-	Open node-red interface http://localhost:1880/ 
-	Open “Manage Pallet” in node-red (right top menu next to “Deploy” button). Switch to tab “Install” and install package “node-red-contrib-aedes” (node-red-contrib-aedes (node) - Node-RED).
-	After installation, close „Manage Pallet“ panel and add the node „aedes broker“ to the flow. 
-	With double-click open detail of MQTT broker. Fill MQTT Port to „1883“ and WS Port to „8083“ and on tab „Security“ fill Username „user“ and Password „userpass“ (if you want to use different ports, user and password you have to change it in all appsettings.json of applications which uses MQTT, mainly in „VEconomy“).
-	Close Broker details and click to Deploy. MQTT should run now correctly.


# Using VEconomy API

You can use VE Economy as background service which communicates just with API. The description of API is in OpenAPI form, swagger: 

[VEconomy Open API Description](https://github.com/fyziktom/VirtualEconomyFramework/blob/main/VEconomy-swagger.json)

- When you run VEconomy, you can access swagger UI on http://localhost:8080/swagger/index.html 
- Data about digital twins are available on MQTT under topics:
- VEF/Wallets – full list of wallets and their accounts
- VEF/Accounts – full list of accounts
- VEF/Nodes – full list of functional nodes
- VEF/Cryptocurrencies – full list of available cryptocurrencies (just drivers in VEF)
- Refreshing rate is now 1s (it is in MainDataContext.cs, will be connected to appsetting.json)

# Using VEconomy UI

Host and port you can setup in VEconomy “appsettings.json”. Default setting listen an all local hosts and port 8080 (http://*:8080/).

Step by step tutorial for web UI will be published soon.


# VEconomy Structure

You can use VEconomy application as base for your own project. This application uses ASP.NET and creates webserver with secured API. It also runs several internal services:
-	Starupt – runs web server
-	VEconomyCore – runs MQTT client
-	WalletHandlerCore – handling wallets, accounts and nodes and publish data to MQTT in the intervals.
-	ExchangeService - runs Exchange connector


You can add another service which handle your tasks. Please follow structure as VEEconomyCore.cs and you must add setup/start of the service in Program.cs

Main HTTP controller are placed in folder “Controllers”. You can add your own commands. In the controller there is examples for GET and PUT commands.

If you want to secure some command please add the rights before the function ([example](https://github.com/fyziktom/VirtualEconomyFramework/blob/main/VirtualEconomyFramework/VEconomy/Controllers/MainController.cs#L62)).

UI files are in folder “wwwroot”. Project of web UI is in Bootstrap Studio “VEView.bsdesign”.

MQTT Controller. Is controller structure prepared for your own commands which can be provided via MQTT to the core. All commands must be registered in function “RegistredTopics” and it must have function which meets specification described by Dictionary “ApiFunctions”. Example is “Started” function. Same structure you can find in “QTWalletRPC.cs” which is controller for RPC commands for QT Wallets.

Main shared objects are stored in MainDataContext.cs static class. Most important is dictionaries:
-	Wallets
-	Accounts
-	Nodes
-	Cryptocurrencies
-	Owners (not used yet)


You can also find there ExchangeDataProvider to get info about prices from Binance exchange or MQTT and QTRPC clients.

More detailed explanation of structure of code will be added soon (especially for VEDrivers).

# Pre-Beta Pre-Build :)

There you can download first pre-beta pre-build. It is preset to work with SQLite Db (created automatically after start if not exists) and QT wallet. 
It can run without db too, to just display data or set anything to RAM (will be lost after reset of app). 
In that case you can edit addresses in appsetting.json in section "Accounts". Accounts in this list will be loaded after start of the app and all tx data will be downloaded and prepared from blockchain.  You can browse tokens, check moves in chess, or test nodes. 

If you have QT wallet you can send Tx too via RPC. Just set to Accounts List in the appsetting.json (if you run without Db] some of the address from QT. Then you can run it without Db but with sending tx support.

Actual version now supports sending transactions without QT Wallet. You can also create addresses without QT wallet. It works as independent Wallet for Neblio now.

If you need to acces UI via your network you have to change IP in "MQTT" section in the appsetting.json.

Here you can download the app:

[VEFramework Release Folder](https://technicinsider-my.sharepoint.com/:f:/p/tomas_svoboda/EgLTmYjsqDRHvQyGvkKkO6EBl44-fFopmkSZUQH_gF__Xg?e=HKcLCg)

In the folder you can find .NET Core 5.0 and ASP.NET 5.0 installers too.

# Thanks

Main Thanks goes to Mr. Jan Kuznik. He taught me lots of great knowledge about programming.

“TestNeblio.exe” utility is Mr.Kuznik design and he agreed to publish it with this project. Many thanks for this great tool.

This project uses some other opensource libraries or other tools. Many thanks to all authors of these projects and other opensource projects.

-	Neblio – Blockchain solution for Enterprises – https://github.com/NeblioTeam/neblio 
-	Microsoft - .NET Core, C#, Entity Framework Core - https://docs.microsoft.com/en-us/dotnet/core/introduction 
-	Newtonsoft.Json – JSON parsing library - https://github.com/JamesNK/Newtonsoft.Json 
-	NBitcoin - .NET C# Library for Bitcoin based cryptocurrencies - https://github.com/MetacoSA/NBitcoin
-	DocFx – API documentation generator - https://github.com/dotnet/docfx 
-	Swagger – OpenAPI description of REST API - https://swagger.io/ 
-	MQTTNet – library for MQTT connection - https://github.com/chkr1011/MQTTnet
-	Log4net – library for logging - https://github.com/apache/logging-log4net
-	Binance.Net – library for connecting to Binance Exchange - https://github.com/JKorf/Binance.Net
-	Jint – library for run JavaScript in C# - https://github.com/sebastienros/jint
-	Npgsql – EFC provider for PostgreSQL - https://github.com/npgsql/efcore.pg
-	Node.js – JavaScript runtime - https://nodejs.org/en/  
-	Node-RED – IoT tool for event driven connections - 
-	Aedes Node-Red node – MQTT Broker - https://github.com/moscajs/aedes 
-	Paho MQTT – JavaScript library for MQTT client - https://github.com/eclipse/paho.mqtt.javascript 
-	Chart JS - JavaScript library for charts - https://github.com/chartjs 
-	CodeJar - Simple JavaScript editor - https://github.com/antonmedv/codejar
-	Prism - Code Syntax Highlight library - https://prismjs.com/
-	Crypto JS - JS library of crypto standards - https://github.com/brix/crypto-js
-	Chessboard JS - JS library for chess game - https://chessboardjs.com/
-	Bootstrap Studio – tool for simplify web-based UI - https://bootstrapstudio.io/ 

# License 

This framework can be used for any use even for commercial use. License is BSD 2 with additional conditions. 

Please read it here: 

https://github.com/fyziktom/VirtualEconomyFramework/blob/main/License/license.txt


# Donation

If you like this project, please donate the team with some Nebl,  Bitcoin or ReddCoin. 

Thanks to donations we can focus our energy to this opensource project.

Project Neblio Address - NUhbMPqKYaGe8irb4kXECb8KN79YbD6ZyX

Project BTC Address - 34cuGjGbdVBHvwS3dha8pMv63jbxsF96MP

Project ReddCoin Address - RiPAe5nGNvtyPfxCC3nQoXes6EjgduQct2

