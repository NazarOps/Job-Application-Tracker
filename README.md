# 📄 Job Application Tracker

This is a simple job application logger program that lets you log your job applications.

---

## 🚀 How to Run the Program

1. Clone the GitHub repository to your local hard drive.  
2. Open **Visual Studio** and click the **solid green play button** to run the program.

---

## 💻 Program.cs

Contains the **main menu**, coded using **switch cases** for different selections:

- **Case 1:** Log your job application.  
  The program will ask for:
  - Company name  
  - Position title  
  - Expected salary  
  - Date of application  
  - Whether you’ve received a response from the employer  

- **Case 2:** Display all of your job applications in ascending order, showing:  
  - Company name  
  - Job title  
  - Expected salary  
  - Current status (default: *Applied*)  
  - Date of application  
  - Response status  
  - Days passed since application  

- **Case 3:** Sort all job applications by **application status**:  
  1. Offer  
  2. Interview  
  3. Applied  
  4. Rejected  

- **Case 4:** Sort all job applications by **application date (descending order)** — latest applications appear first.

- **Case 5:** Display job application **statistics**, including:  
  - Total jobs applied  
  - Total responses received  
  - Total offers  
  - Total rejections  
  - Total interviews  

- **Case 6:** Manage job applications.  
  *(Currently allows editing only of application status.)*

---

## ✉️ JobApplications.cs

Contains attributes for a single job application, with **getter** and **setter** properties for access.

---

## 💻 JobManager.cs

Contains all the **logic and methods** for the application, including:  
- `Apply()`  
- `GetSummary()`  
- `SortByDate()`  
- `SortByStatus()`  
- `ShowStatistics()`  
- `ManageJobs()`
