# :page_facing_up:Job Application Tracker

This is a simple job application logger program that lets you log your job applications.

How to run the program:

- Clone the Github repository to your local harddrive on your computer
- Open Visual Studio and click the solid green play button

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

:computer:Program.cs:

Contains the main menu that has been coded using switch cases for different selections:
  
- Case 1: Log your job application. The program will ask for the name of the company you applied to,
position title, expected salary, what date the job application was made and if you have received a response
from the employer or not

- Case 2: Displays all of your job applications in ascending order with company name, job title, expected salary, current status (default is applied), date of application, if the application has been responded to by the employer and days passed since the application was made

- Case 3: Sorts all of your job applications by application status. Offer is number 1, Interview is number 2, Applied is number 3 and Rejected is number 4.

- Case 4: Sorts all of your job applications by application date in descending order, latest application will show first.

- Case 5: Display all of your job application statistics, you will get information about how many jobs you've applied to, how many applications have been responded to, how many job offers you received, how many rejected applications and lastly how many interviews.

- Case 6: Manage your job applications, only lets you edit application status (for now).

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

:incoming_envelope:JobApplications.cs:

- Contains attributes for a single job application with getters and setters properties for access.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

JobManager.cs:

- Contains all the logic and methods for the application. In here we have methods like Apply(), GetSummary(), SortByDate(), SortByStatus(), ShowStatistics() and ManageJobs().

