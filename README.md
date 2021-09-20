# Introduction 

The solution is a simple messaging system by using a queue service. The solution consists of two console applications and queue service. The main logic is read lines from file and write lines to queue service, and read messages and write information into separate file.

# Overview

Reader and Writer services are .NET Core console applications. .NET Core chosen for development because it is a cross-platform software framework for Windows, Linux, and macOS operating systems. 
For queue service used Azure Storage Queues as powerful cloud based queues mechanism

Reader application reads lines from file located in local Windows folder "D:\TMP\FileBefore.txt" and writes lines into "text-lines" queue.

Writer application reads messages from "text-lines" queue one by one and writes messages as separate lines into new file located in local windows folder "D:\TMP\WriteLines.txt".

# How to run

- Download and install the .NET Core SDK version 3.1 or later;
- Create an Azure Storage account with queue "text-lines";
- Configure your storage connection string, write it to a new environment variable on the local machine running the application. 

1. From the command line in the "file-reader" project directory, run the following dotnet command to build the project:

- [ ] dotnet build

2. After the project builds successfully, run the following command (messages will be created in queue):

- [ ] dotnet run

3. From the command line in the "file-writer" project directory, run the following dotnet command to build the project:

- [ ] dotnet build

2. After the project builds successfully, run the following command (application will read messages from queue and write them into file):

- [ ] dotnet run

# Deployment strategy

As a solution based on a cross-platform software framework we can containerize applications and use Linux and Windows containers. Also we can make small modifications in applications, add http triggers, webbook trigger etc., and host them in cloud as managed services like azure functions, web applications etc., (also similar services in other cloud providers).
Also we can use different storages for store files as Azure Storage Account or Similar solutions. If necessary we also could modify application and use different queue services.

# Monitoring

- For solution could be added logging, with storing logs in different logs analytics services as Azure Log Analyst, ELK, Rapid7 etc.
- For solution could be added queue length monitoring, and poison queues.
- For solution could be added application performance monitoring.
- Infrastructure monitoring based on chosen system for hosting.
- For solution could be added availability monitoring.
- Could be configured dashboards and alerts.