# There are two back end services and one front end client

# Angular app => npm install 
		 ng serve
		 App should run on "http://localhost:4200" 

# Same Angular app support for the both Back end services

Setup 1
# Simple BackEnd (KORE_Contacts_Service) => version .Net 6.0
	=> In Memory List have used
	=> Open the KORE_Contacts_Service.sln file using VS2022 
	=> Run the app. 
##** Front end and Back end app will work together

Step 2
# Advanced BackEnd (API) => Version .Net 8
	=> In Memory List and DB both can be used
	=> initial setup for in memory list (Tested scenario)
	=> Open Project "API\KORE_ContactManagement\KORE_ContactManagement.sln"
	=> ****IF Failed to load 
		=> Open "API\KORE_ContactManagement.DomainKORE_ContactManagement.Domain.sln"
	=> Then set "KORE_ContactManagement.Presentation" as startup project.
	=> Run the app

Local DB Setup for Advanced BackEnd ===>
	=> If local DB need to connect, Connection string need to be changed.
	=> Relevant DB and table need to be created or need to use code first migration. 
	=> Dependency Injection in KORE_ContactManagement.Infrastructure project need to be updated (Uncomment commented lines and comment existing inline injected services)
Following Table script can use to create 

CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[MiddleInitial] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL)




