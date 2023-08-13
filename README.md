# DemoApp
**This project is a Asp.Net Core Web API with MySQL as Database with Entity Framework code first approach**

## Project Setup
Please clone the project and install the necessary nuget dependencies 

## Project Description
The Web API contains 2 main features Products and Categories which can be manipulated with CRUD operations using API end points.

## Endpoint usage
- Products end points can be used to make CRUD operations on Products and ProductsDetails table
- Products end point also exposes an api to get all the Archived Products
- Category end points can be used to make CRUd operations on Category table
- Categories api has an end point for uploading an excel file to Category table(Sample excel tamplete is avilable under resources folder)
- Quartz job scheduler is scheduled to run every hour to copy the Inactive Products into Archived Products table

