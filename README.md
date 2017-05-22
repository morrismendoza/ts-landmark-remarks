# ts-landmark-remarks
This is the sample project for the Landmark Remark project for TigerSpike

# Solution Overview
The solution contains 3 Folders
 - Landmark.API
 - Landmark.API.Tests
 - Landmark.UI
 
 The solution is a SPA that communicates to a Web API that communicates to MongoDb(via mlab) for data persistence.
 
 The UI consists of a map which automatically detects your location with a green marker (User Story 1). When you click on the current location marker, it will display your full address including latitude and longitude info and will show a button to add your current location. When you click this button you will be shown a pop over to enter a few details regarding your username and notes you want to add about your current location (User Story 2).
 
 When there are entries saved previously that belongs to myself (User story 3) or other users (User Story 4), red markers will be shown to denote these locations. You can click on the marker to show additional information such as complete address, latitude, longitude, username, notes/remarks and last visited date.
 
 The UI also shows a table of all the user locations with the details show for every marker. A filter input box can be used to search and filter the table and the map. The filter will look for values inside the notes/remarks or the username (User Story 5)
 
 # Effort and Man Hours
 - Landmark.API = 2 hours
 - Landmark.API.Tests = 30 minutes
 - Landmark.UI = 4 hours (Angular Folder Structure, Services, Pipes and Components, Google MAP control integration (3rd Party Library)
 
 # PROJECT FOLDER: Landmark.API
 Built using ASP.NET WebAPI, Unity for DI and contains a swagger definition http://localhost:52955/swagger
 Initially built using local db (EF, mdf) but used a NoSql database instead
 
 # Limitations
 The app requires the API to run locally via iis on port http://localhost:52955/. This is hard-coded on the Landmark.UI file inside Landmark.UI > src > environments > environments.prod.ts. You could also use a publicly available API that i have compiled in Azure http://landmark-api.azurewebsites.net/api/user (This also points to the same MongoDB mlab instance)
 
 To run the UI, you are required to run Angular CLI. Please install all the necessary node packages to run this. Read the README file inside the Landmark.UI.
 
 Quick Running Steps:
 1. Use command line to cd in the Landmark.UI folder.
 2. type 'npm install' to install dependencies
 3. type 'ng serve" to compile and run the project. The app will be available on the default port of 4200 (http://localhost:4200)
 (Check the Landmark.UI readme for more detail)
 
 # Unit Tests
 There are basic unit tests for the API.
  - The service layer is Mocked 
  - The repo layer has integration tests but tagged as ignored.
