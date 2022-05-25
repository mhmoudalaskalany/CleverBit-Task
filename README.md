# Cleverbit Employee Region Task

# Features
- Generic crud operations
- Auto Mapper
- Generic Repository And Unit Of Work Pattern
- Audit Trails
- Logging Using Serilog To Sql Server Database
- Swagger Documentation
- JWT Authentication


# Installation

- clone the repository
- change the connection string in the appsettings.json in backend solution
- run the backend project on https://localhost:5001  (migrations will be applied automatically)
- use login endpoint to get a JWT and authorize swagger 
- use Files/Upload endpoint to upload the 2 CSV files 
- use Employees/Add , Region/Add  endoints to add employee and region (regionId is required no to be duplicated from CSV)
- open CMD in frontend root directory
- run (npm i)
- if npm success run (npm run start) to serve the fronend application
- navigate to http://localhost:4200
- try login using Username: Admin ; Password:123456
- go to employees page and search using region to get related employees


# Notes
 - CSV files has some wrong data according to region which casue reference forigen key exception when seeding the database so i had to remove the constraint of the self reference relation to save the time 
 
