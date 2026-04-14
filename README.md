# 🔐 Secure Command Monitor (.NET Clean Architecture)

A secure command execution and monitoring system built using **.NET** and **Clean Architecture principles**, designed to simulate real-world cybersecurity monitoring and alerting mechanisms.

## 🚀 Features

- ⚙️ Execute system commands (ipconfig, netstat, whoami, tasklist)
- 🛡️ Command whitelist to prevent unauthorized execution
- 📊 Logging of all activities for auditing
- 🚨 Email alerts using SMTP
- 🔐 Secure configuration handling
- 🧱 Clean Architecture (Domain, Application, Infrastructure, Presentation)



## 🧠 Architecture

- 📁 Domain → Core models
- 📁 Application → Interfaces & business logic
- 📁 Infrastructure→ Email, Config, Logging
- 📁 Presentation → Console App (Entry Point)

## 🛠 Tech Stack

- C# / .NET
- SMTP (System.Net.Mail)
- Process API
- File Handling
- Clean Architecture

## 🔐 Security Concepts Implemented

- Command Injection Prevention (whitelisted commands)
- Secure Credential Handling (config-based)
- Logging & Monitoring
- Alerting System (Email Notifications)

## 📸 Sample Output

Command: ipconfig
Status: Success
Timestamp: 2026-04-15

## ⚙️ Configuration

Create a `config.txt` file:

```bash
From=your-email@gmail.com
To=receiver-email@gmail.com
Password=your-app-password
SmtpServer=smtp.gmail.com
Port=587
```

⚠️ Use **App Password**, not your real Gmail password.

## ▶️ How to Run

```bash
dotnet build
dotnet run
```

## 📈 Future Enhancements

- 🌐 Convert to ASP.NET Core Web API
- 📊 Add Angular Dashboard
- 🗄 Store logs in database (SQL Server / SQLite)
- 🔑 Add JWT Authentication
- 🚨 Advanced threat detection rules

## 👨‍💻 Author

~ Rajya Vardhan

If you like this project. Give it a star ⭐ and feel free to contribute!
