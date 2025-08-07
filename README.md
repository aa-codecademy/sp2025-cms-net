# SP2025 CMS Fullstack Boilerplate

This project is a fullstack web application boilerplate featuring:

- **Strapi CMS** (for content and user management)
- **.NET 8 Web API** (for API, authentication, and business logic)
- **Frontend Client** (plain JavaScript/HTML/CSS)

It is designed for students to learn how to integrate a modern CMS, a robust backend, and a simple frontend, and to extend the system with new features, while delivering a production ready application for our clients.

## 🎯 Learning Objectives

By working with this project, you will learn:

- **Modern Architecture Patterns**: Understanding microservices, API gateways, and layered architecture
- **CMS Integration**: How to use Strapi as a headless CMS with custom content types
- **Backend Development**: Building REST APIs with .NET 8, including authentication and data transformation
- **Frontend Development**: Creating responsive UIs with vanilla JavaScript
- **Database Design**: Working with SQLite and understanding content type schemas
- **API Design**: Creating clean, documented APIs with proper error handling
- **Authentication**: Implementing JWT-based authentication across multiple services
- **Data Flow**: Understanding how data moves between client, server, CMS, and database

## 📁 Project Structure

```
sp2025-cms-net/
├── client/                    # Plain JS frontend
│   ├── index.html            # Main HTML file
│   ├── script.js             # JavaScript logic
│   └── style.css             # Styling
├── cms/                      # Strapi CMS (Node.js)
│   ├── src/
│   │   ├── api/              # Content types and API endpoints
│   │   │   ├── article/      # Article content type
│   │   │   └── user/         # User content type
│   │   └── extensions/       # Custom extensions
│   ├── config/               # Strapi configuration
│   └── public/               # Static files and uploads
├── server/                   # .NET 8 Web API
│   ├── src/
│   │   └── Strapi.Backend.Demo/
│   │       ├── Strapi.Backend.Demo.Api/     # Main API project
│   │       │   ├── Program.cs               # Application entry point
│   │       │   ├── ApiConfig.cs             # Route configuration
│   │       │   └── appsettings.json         # Configuration
│   │       └── Strapi.Backend.Demo.Services/ # Business logic layer
│   │           ├── Dtos/                    # Data Transfer Objects
│   │           ├── Interfaces/              # Service contracts
│   │           └── Services/                # Service implementations
└── README.md                 # This file
```

## 🔄 How the Parts Communicate

- **Client** communicates with the .NET Web API via HTTP (REST API)
- **.NET Web API** communicates with Strapi CMS via HTTP (REST API), acting as a secure proxy and business logic layer
- **Strapi CMS** manages content (articles) and users, and exposes its own REST API

## 🏗️ System Architecture

```
┌─────────────┐    HTTP/REST    ┌─────────────┐    HTTP/REST    ┌─────────────┐
│   Client    │ ──────────────► │ .NET 8 API  │ ──────────────► │ Strapi CMS  │
│ (Plain JS)  │                 │             │                 │             │
└─────────────┘                 └─────────────┘                 └─────────────┘
                                        │                              │
                                        │                              │
                                        ▼                              ▼
                               ┌─────────────┐                 ┌─────────────┐
                               │   Swagger   │                 │   SQLite    │
                               │  UI (Dev)   │                 │  Database   │
                               └─────────────┘                 └─────────────┘
```

## 🚀 Quick Start

### Prerequisites

- **Node.js** (v18 or higher)
- **.NET 8 SDK**
- **Git**

### 1. Clone the Repository

```bash
git clone <repository-url>
cd sp2025-cms-net
```

### 2. Start Strapi CMS

Navigate to the CMS directory and start the development server:

```bash
cd cms
npm install
npm run develop
```

**Important**: The first time you run this command, Strapi will prompt you to create an admin account. Follow the setup wizard in your browser.

**Access Points**:
- **Admin Dashboard**: http://localhost:1337/admin
- **API Endpoint**: http://localhost:1337/api

### 3. Start .NET Web API

Open a new terminal and navigate to the server directory:

```bash
cd server/src/Strapi.Backend.Demo/Strapi.Backend.Demo.Api
dotnet restore
dotnet run
```

**Access Points**:
- **API Endpoint**: https://localhost:7001/api
- **Swagger UI**: https://localhost:7001/swagger

### 4. Configure Frontend API Connection

Before opening the frontend, you need to update the API base URL in the client code to match your .NET API:

1. Open `client/script.js` in your code editor

3. Update it to match your .NET API URL:  
   ```javascript
   const BACKEND_URL = 'https://localhost:7001/api'; // Your .NET backend URL
   ```

**Important**: Make sure the port number matches the one shown when you start your .NET API (usually `7001` or `7103`).

### 5. Open the Frontend

Open the `client/index.html` file in your browser or serve it using a local server:


## 🏛️ Architecture & Data Flow

### .NET Web API Architecture

The .NET backend is implementation of Minimal API project and follows a simplified N-tier architecture for demo purpose with the following layers:

#### 1. **API Layer** (`Strapi.Backend.Demo.Api`)
- **Entry Point**: `Program.cs` - Configures services, middleware, and dependency injection
- **Route Configuration**: `ApiConfig.cs` - Defines all API endpoints using minimal APIs

#### 2. **Service Layer** (`Strapi.Backend.Demo.Services`)
- **Interfaces**: Define contracts for business logic
- **Services**: Implement business logic and external API communication
- **DTOs**: Data Transfer Objects for API requests/responses

### API Endpoints

#### Articles Management

```csharp
// Get all articles
GET /api/articles

// Get article by ID
GET /api/articles/{articleId}

// Create new article
POST /api/articles
{
  "data": {
    "articleId": 1,
    "title": "Sample Article",
    "datePosted": "2024-01-01T00:00:00Z"
  }
}

// Update article
PUT /api/articles/{articleId}
{
  "title": "Updated Article Title"
}

// Delete article
DELETE /api/articles/{articleId}
```

#### Authentication

```csharp
// User login
POST /api/auth/login
{
  "identifier": "user@example.com",
  "password": "password123"
}

// User registration
POST /api/auth/register
{
  "username": "newuser",
  "email": "user@example.com",
  "password": "password123"
}
```

### Data Flow Example

1. **Client Request**: Frontend makes request to `/api/articles`
2. **API Gateway**: .NET API receives request and routes to `ArticleService`
3. **Service Layer**: `ArticleService` transforms request and calls Strapi API
4. **CMS Response**: Strapi returns article data
5. **Data Transformation**: .NET API transforms Strapi response to client-friendly format
6. **Client Response**: Transformed data sent back to frontend

### Code Snippets

#### Service Implementation Example

```csharp
public class ArticleService : IArticleService
{
    private readonly HttpClient _httpClient;

    public ArticleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseDto<List<ArticleDto>>> GetArticlesAsync()
    {
        var request = await _httpClient.GetAsync("articles");
        var resp = await request.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ResponseDto<List<ArticleDto>>>(resp);
        return result;
    }
}
```

#### Route Configuration Example

```csharp
app.MapGet("/api/articles", (IArticleService _articleService) =>
{
    return _articleService.GetArticlesAsync();
})
.Produces<ResponseDto<List<ArticleDto>>>(StatusCodes.Status200OK)
.WithDescription("Get all articles")
.WithDisplayName("GetAllArticles");
```

## 📖 Strapi as Headless CMS and how to use it

### Strapi CMS Guide

[Strapi & How to install](STRAPI_GUIDE.md)

The guide covers:
- Creating new Strapi projects
- Running and configuring Strapi
- Admin panel features and workflows
- API endpoints and customization
- Troubleshooting and best practices
- Links to official documentation

## 🛠️ Technology Stack

### Backend (.NET 8)
- **Framework**: ASP.NET Core 8.0
- **Architecture**: Minimal APIs with simplified N-tier Architecture
- **HTTP Client**: Built-in HttpClient for external API calls
- **Documentation**: Swagger/OpenAPI
- **CORS**: Cross-Origin Resource Sharing enabled
- **Configuration**: appsettings.json with environment variables

### CMS (Strapi)
- **Version**: 5.18.1
- **Database**: SQLite (development)
- **Content Types**: Custom article schema with internationalization
- **Authentication**: JWT-based with Users & Permissions plugin
- **API**: RESTful API with automatic documentation

### Frontend
- **Language**: Vanilla JavaScript (ES6+)
- **Styling**: CSS3 with modern layout techniques
- **HTTP Client**: Fetch API for API communication
- **UI Components**: Modal dialogs, responsive design

### Development Tools
- **Package Manager**: npm (Node.js), NuGet (.NET)
- **Build Tools**: Strapi CLI, .NET CLI
- **Development Server**: Strapi dev server, .NET Kestrel
- **Documentation**: Swagger UI, Strapi Admin Panel


