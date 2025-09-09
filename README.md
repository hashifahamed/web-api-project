# 💊 SPC Pharmaceutical Supply Chain Management System

A Service-Oriented Architecture (SOA)-based system developed for **State Pharmaceuticals Corporation (SPC)** to manage suppliers, drugs, pharmacies, and order placement.  
The solution integrates **RESTful APIs** with client web applications, enabling SPC staff, manufacturing plants, and registered pharmacies to collaborate efficiently.

---

## 🚀 Features
- **Supplier Registration** – SPC staff can register and manage suppliers.  
- **Drug Management** – Admin and manufacturing units can add or update stock.  
- **Pharmacy Management** – Register SPC-owned and external pharmacies.  
- **Drug Search & Orders** – Registered pharmacies can search drugs and place orders via APIs.  
- **Secure Access** – Only authenticated pharmacies can access drug search/order endpoints.  

---

## 🛠️ Tech Stack
- **Backend:** .NET 6 Web API, Entity Framework Core, LINQ  
- **Frontend (Clients):** ASP.NET Razor Pages (admin) + API-ready for React/Flutter/other clients  
- **Database:** SQL Server (Code-First with EF Core)  
- **API Docs & Testing:** Swagger, Postman  
- **Deployment:** IIS, Docker (future Kubernetes support)  

---

## 📌 Architecture
- **SOA (Service-Oriented Architecture)** – Modular services for Supplier, Drug, Pharmacy, and Order.  
- **Single Database** with multiple related tables.  
- **UML Diagrams** included (Class, Sequence, System Flow).  

---

## 🧪 Testing & Debugging
- APIs tested with **Swagger** & **Postman**.  
- Debugging demonstrated with **Visual Studio breakpoints** and error handling.  
- Screenshots of test cases and responses included.  

---
