# Customer Service Web API


###### Short Description
The service provides a in-memory list of customers which can be manipulated through defined endpoints for CRUD operations.

###### Table of contents
1. Installation and run
2. Endpoints
3. Third party products
4. Examples

#### 1. Installation and run

Application is running on Local IIS, but it can be ran on IIS Express as well (F5 in Visual Studio). If you want to run the application on Local IIS, please follow the [documentation for enabling the Local IIS](https://msdn.microsoft.com/en-us/library/ms181052%28v=vs.80%29.aspx?f=255&MSPPError=-2147217396).

Clone the repository to your local environment using `git clone https://github.com/adrnilie/CustomerService.git`

Open the repository in Visual Studio (Visual Stuido 2017 was used for developing the application) and build the application `Ctrl + Shift + B`. After the build is finished, the application should be present under the `Default Web Site` in IIS (see the picture below).

![Local IIS](https://i.imgur.com/uf1uMOZ.png)

If the application is present in the folder described earlier, then you can access the application at `http://localhost/CustomerService/api/customers`. A list of five (5) records should be shown as JSON.

#### 2. Endpoints

| Endpoint | Action | Description |
|----------|--------|-------------|
|/api/customers|GET|Returns all the customers from the list|
|/api/customers/{id}|GET|Returns a customer based on its id|
|/api/customers|POST / PUT|Adds or Updates a record|
|/api/customers/{id}|DELETE|Delets a customer by its id|

#### 3. Third party products

3.1. Dependency Injection - [Autofac](https://autofac.org/)
3.2. Test Framework - [NUnit](https://nunit.org/)
3.3. Mocking Framework - [Moq](https://github.com/moq/moq4)
