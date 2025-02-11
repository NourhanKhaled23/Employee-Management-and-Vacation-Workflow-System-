#👨‍💻 Employee Management and Vacation Workflow System
## **📄 Project Documentation**

### **1. 🏁 Project Overview**
#### **1.1 🎯 Purpose**
The **Employee Management and Vacation Workflow System** is designed to manage employee information and handle vacation requests within a company. It allows employees to submit vacation requests, managers to approve or decline requests, and HR to track employee vacation balances.

#### **1.2 🌟 Features**
- **👤 Employee Management**: View, add, update, and delete employee information.
- **🏖️ Vacation Requests**: Submit, approve, or decline vacation requests.
- **📊 Reporting**: Generate reports on employee vacation balances and pending requests.
- **🔄 Workflow**: Automate the approval process for vacation requests.

#### **1.3 🛠️ Technologies Used**
- **Backend**: .NET 8, Entity Framework Core, ASP.NET Core Web API.
- **Database**: SQL Server.
- **Tools**: Swagger for API documentation, Visual Studio for development.


---

### **2. 🗄️ Database Design**
#### **2.1 📂 Tables**
| **Table**            | **Description**                          |
|-----------------------|------------------------------------------|
| **Employee**          | Stores employee details.                 |
| **Department**        | Stores department details.               |
| **Position**          | Stores position details.                 |
| **VacationRequest**   | Stores vacation requests.                |
| **VacationType**      | Stores types of vacations (e.g., Sick, Annual). |
| **RequestState**      | Stores request states (e.g., Submitted, Approved, Declined). |

#### **2.2 🔗 Relationships**
| **Relationship**                     | **Description**                          |
|--------------------------------------|------------------------------------------|
| **Employee ↔ Department**            | Many-to-One.                             |
| **Employee ↔ Position**              | Many-to-One.                             |
| **Employee ↔ Employee**              | Self-referencing (Manager ↔ Subordinate).|
| **VacationRequest ↔ Employee**       | Many-to-One.                             |
| **VacationRequest ↔ VacationType**   | Many-to-One.                             |
| **VacationRequest ↔ RequestState**   | Many-to-One.                             |

---

### **3. 📡 API Documentation**
Use **Swagger** to document your API endpoints. Below is a summary of the endpoints.

#### **3.1 👤 EmployeeController**
| **Endpoint**                          | **Method** | **Description**                          |
|---------------------------------------|------------|------------------------------------------|
| `/api/Employee`                       | GET        | Get all employees.                       |
| `/api/Employee/{employeeNumber}`      | GET        | Get employee by ID.                      |
| `/api/Employee`                       | POST       | Add a new employee.                      |
| `/api/Employee/{employeeNumber}`      | PUT        | Update employee details.                 |
| `/api/Employee/{employeeNumber}`      | DELETE     | Delete an employee.                      |
| `/api/Employee/PendingVacations`      | GET        | Get employees with pending vacation requests. |
| `/api/Employee/{employeeNumber}/VacationHistory` | GET | Get vacation history for an employee. |
| `/api/Employee/{employeeNumber}/PendingRequests` | GET | Get pending vacation requests for an approver. |

#### **3.2 🏖️ VacationRequestController**
| **Endpoint**                          | **Method** | **Description**                          |
|---------------------------------------|------------|------------------------------------------|
| `/api/VacationRequest`                | POST       | Submit a vacation request.               |
| `/api/VacationRequest/Pending`        | GET        | Get all pending vacation requests.       |
| `/api/VacationRequest/Approve/{id}`   | PUT        | Approve a vacation request.              |
| `/api/VacationRequest/Decline/{id}`   | PUT        | Decline a vacation request.              |

---

### **4. 🏗️ Code Structure**
#### **4.1 📂 Project Structure**
```
BackendFirstProject/
├── Core/
│   ├── Entities/              # Domain models
│   ├── Interfaces/            # Repository interfaces
│   ├── DTOs/                  # Data Transfer Objects
│   └── Exceptions/            # Custom exceptions
│
├── Infrastructure/
│   ├── Data/                  # DbContext and configurations
│   ├── Repositories/          # Repository implementations
│   └── Services/              # Business logic services
│
├── API/
│   ├── Controllers/           # API controllers
│   ├── Middleware/            # Custom middleware
│   └── appsettings.json       # Configuration
│
│
└── BackendFirstProject.sln    # Solution file
```

#### **4.2 🔑 Key Files**
| **File**                  | **Description**                          |
|---------------------------|------------------------------------------|
| **Entities**              | `Employee.cs`, `Department.cs`, `VacationRequest.cs`, etc. |
| **Repositories**          | `EmployeeRepository.cs`, `VacationRequestRepository.cs`. |
| **Controllers**           | `EmployeeController.cs`, `VacationRequestController.cs`. |
| **Services**              | `EmployeeService.cs`, `VacationRequestService.cs`. |

---

### **5. 🚀 How to Run the Project**
#### **5.1 📋 Prerequisites**
- .NET 8 SDK.
- SQL Server (or LocalDB).
- Visual Studio 2022 or Visual Studio Code.

#### **5.2 🛠️ Steps**
1. **Clone the Repository**:
2. **Set Up the Database**:
   - Update the connection string in `appsettings.json`.
   - Run migrations:
     ```bash
     dotnet ef database update --project BackendFirstProject.Infrastructure --startup-project BackendFirstProject.API
     ```

3. **Run the Application**:
   ```bash
   dotnet run --project BackendFirstProject.API
   ```

4. **Access Swagger**:
   Open `http://localhost:<port>/swagger` in your browser.

---

### **6. 🧪 Testing**
#### **6.1 🖐️ Manual Testing**
- Use Swagger to manually test API endpoints.

---

### **7. 🚀 Deployment**
#### **7.1 🏠 Local Deployment**
- Use `dotnet run` to run the application locally.
---
### **11. 📜 License**
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

### **12. 📚 References**
- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [Swagger Documentation](https://swagger.io/docs/)
