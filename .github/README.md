## Learnify – Fullstack Learning Platform 📚

<img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/react/react-original-wordmark.svg" alt="react" width="40" height="40"/>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/dotnetcore/dotnetcore-original.svg" alt="dotnetcore" width="40" height="40"/>

</h2>

### 🚀 Features

- **Repository & Specification Patterns** for clean, maintainable data access
- **Domain-Driven Design** with layered architecture (API, Infrastructure, Entity, Client)
- **ASP.NET Identity** for secure authentication and registration
- **React Router v6** for seamless client-side navigation
- **Redux Toolkit** for centralized, scalable state management
- **AutoMapper** for efficient DTO mapping and response shaping
- **Axios** for robust API communication
- **Custom UI** built with SASS and Ant Design
- **Course rating, sorting, search, and filtering**
- **Redis** as an in-memory store for shopping cart/basket
- **Stripe** integration for secure, 3D Secure payments (EU compliant)
- **YouTube Embedded Player** for video lectures
- **Instructor role** with course and section creation
- **TypeScript** throughout for type safety and maintainability

<div align="center">
<table>
  <tr>
    <td align="center">
      <img src="./homepage.webp" height="180"/><br>
      <b>Homepage</b><br>
      <sub>Modern homepage with navigation, search, filtering, and dynamic course display.</sub>
    </td>
    <td align="center">
      <img src="./description.webp" height="180"/><br>
      <b>Course Description</b><br>
      <sub>Detailed course page with learnings, requirements, student count, level, and language.</sub>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="./cart.webp" height="180"/><br>
      <b>Shopping Cart</b><br>
      <sub>Redux-powered basket with add/remove, summary, and checkout integration.</sub>
    </td>
    <td align="center">
      <img src="./login.webp" height="180"/><br>
      <b>Login</b><br>
      <sub>Secure login and registration using ASP.NET Identity.</sub>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="./checkout.webp" height="180"/><br>
      <b>Checkout</b><br>
      <sub>Stripe-powered checkout with 3D Secure support.</sub>
    </td>
    <td align="center">
      <img src="./youtube.webp" height="180"/><br>
      <b>YouTube Player</b><br>
      <sub>Embedded YouTube player for course lectures.</sub>
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="./create.webp" height="180"/><br>
      <b>Create Course</b><br>
      <sub>Instructor dashboard for creating and publishing courses.</sub>
    </td>
    <td align="center">
      <img src="./create-section.webp" height="180"/><br>
      <b>Create Section</b><br>
      <sub>Section and lecture management for instructors.</sub>
    </td>
  </tr>
</table>

</div>
<br />

## Frontend Routes:

- **Home screen**: Navigation bar, fetching courses, search, filtering, sorting and pagination.
- **Course description screen**: Information about the course such as learnings, requirements, description and the ability to Add to Cart and Book Now.
- **Shopping cart screen**: Using redux toolkit to store course details and user's details including the courses in their cart. When a user clicks on the cart icon, they're redirected to the basket page.
- **Login screen**: Using identity framework to take care of all the requirements for user registration and login, such as verifying the email or storing user credentials in the database.
- **Checkout screen**: With Stripe integration - we just need to provide payment card details and click on 'Make Payment'. Once the payment is successful, users will be able to see purchased courses in their account.
- **Utilize YouTube's embedded Player**: Accepts course sections and lectures from the client. YouTube's embedded player for the video player.
- **Create course screen**: Allows a user to become an instructor and create a course of their own. Page for basic course details and another for creating sections and lectures. Option to publish and display the title for all customers to purchase.

## Backend Architecture:

### Entity

- **Data Models**: Defines the core data models such as `Course`, `Category`, `Learning`. These models represent the structure and relationships of the data within the application.
- **Interfaces**: Contains repository interfaces including `ICategoryRepository` and `ICourseRepository` for data access logic abstraction.

### Infrastructure

- **Data Access**: Serves as the Data Access Layer (DAL), which is responsible for interacting with the database.
- **Repository Implementations**: Implements the repository pattern for accessing and managing data.

### API

- **Endpoints/Controllers**: Handles HTTP requests and maps domain models to Data Transfer Objects (DTOs).
  - AutoMapper to map between domain models and DTOs.
  - Controllers use dependency injection to obtain instances of IRepository and IMapper. This setup allows the controllers to retrieve entities from the data source and map them to Data Transfer Objects (DTOs) efficiently.

Everything you need to build a real SaaS application.

**Learnify** is a production-ready, fullstack learning platform built with **ASP.NET Core** and **React**. This project demonstrates advanced software engineering practices, robust architecture, and modern tooling, making it an ideal showcase for your portfolio or as a foundation for your own SaaS products.

---

### 🛠️ Technical Stack

- **Backend:** ASP.NET Core 6, Entity Framework Core, AutoMapper, ASP.NET Identity, Redis, Stripe API
- **Frontend:** React 18, TypeScript, Redux Toolkit, Axios, SASS, React Router v6
- **Database:** SQL Server (or PostgreSQL for production), Redis (basket)
- **DevOps:** Heroku deployment, environment-based configuration

---

### 📦 Project Structure

```
learnify/
├── API/             # ASP.NET Core Web API (controllers, DTOs, mapping)
├── Entity/          # Domain models and repository interfaces
├── Infrastructure/  # EF Core, repository implementations, configuration
├── client/          # React frontend (TypeScript, Redux, SASS)
└── ...              # Config, migrations, deployment scripts
```

### 🚀 Get Started

1. **Clone the repo:**
   `git clone https://github.com/yourusername/learnify-fullstack.git`

2. **Backend:**

   - `cd API`
   - Configure your connection strings and environment variables
   - `dotnet ef database update`
   - `dotnet run`

3. **Frontend:**

   - `cd client`
   - `npm install`
   - `npm start`

4. **Visit:**
   - Frontend: `http://localhost:3000`
   - API: `http://localhost:5000/api`
