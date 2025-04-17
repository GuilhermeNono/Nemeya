
# 🌐 Sphinx: Identity Provider

Project Sphinx is an ASP.NET Core application designed to serve as an identity provider. Built with **.NET 8**, **Docker**, and **SQL Server**, it provides a robust and scalable solution for managing authentication and identity in modern applications. 🚀

## ✨ Features

- 🔒 **Identity Management**: User authentication, authorization, and identity management.
- 🛠️ **.NET 8**: Leverages the latest features and performance improvements of .NET 8.
- 🐳 **Docker Support**: Containerized application for easy deployment and scalability.
- 🗄️ **SQL Server Integration**: Secure and reliable data storage.

## 🖥️ Requirements

To run the project, ensure you have the following installed:

- 📦 [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- 🐳 [Docker](https://www.docker.com/)
- 🗄️ [SQL Server](https://www.microsoft.com/en-us/sql-server)

## 🚀 Getting Started

Follow these steps to get the application running locally:

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/GuilhermeNono/Sphinx.git
cd Nemeia
```

### 2️⃣ Build and Run with Docker
Ensure Docker is installed and running on your machine. Use the provided Docker configuration to build and run the project:
```bash
docker-compose up --build
```

### 3️⃣ Configure SQL Server
Set up the SQL Server database using the provided scripts in the project. Make sure the connection string in the `appsettings.json` file is correctly configured.

## 📂 Project Structure

- **📁 /src**: Contains the main application source code.
- **📁 /docker**: Docker-related configurations and files.
- **📁 /scripts**: SQL scripts for database setup.

## 🤝 Contributing

Contributions are welcome! If you'd like to contribute to the project, please fork the repository and submit a pull request. 🛠️

## 📜 License

This project is licensed under the [MIT License](LICENSE). 📝
