# Blog Backend API - Project Overview

## Project Goal
Create a backend for Blog Application:

- support full crud operations
- All users to create account and login
- deploy to azure
- uses SCRUM workflow concepts
- Introduces Azure DevOps practices

## Stack
- back end will be in .Net 9, ASP.NET Core, EF Core, SQL Server
- front end - next JS with typescript (to be done by Jacob), flowbite and tailwind. Deploy with either Vercel or Azure

## Application features

### User Capabilities

- create an account
- log in 
- delete account

## Blog features

- view all published blog posts
- filter blog posts
- create new posts
- edit existing posts
- delete blog posts
- publish/unpublish posts


### Pages (front end connected to api)
- create account page
- Blog view post page of published items
- Dashboard page (this is the profile page where we will edit delete publish and unpublish posts)

- **Blog Page**
    - Display all published blog items

- **Dashboard**
    - user profile page
    - create blog posts
    - edit blog posts
    - delete blog posts

## Project Folder Structure

### Controllers
### UserController
Handles all users interactions
Endpoints:
 - Login
 - Add user
 - update Users
 - Delete User

### BlogsController

Handles all blog operations.

Endpoints:
- create blog item (C)
- get all blog items (R)
- Get blog items by  category (R)
- get blog items by tags (R)
- get blog items by date (R)
- get blogs by user ids (R)
- get published blog items (R)
- update blog items (U)
- remove blog items (D)

> Delete will be use for soft delete

---

## Models

### User Model

```csharp 

int Id
string Username
string Salt
string Hash

### Blog Model

int Id
int UserId
string PublisherName
string Title
string Image
string Description
string Date
string Category
string Tags
bool isPublished
bool isDeleted

## Items saved to our DB
## We need a way to sign in with our user name

```csharp

###LoginModel

    string Username
    string Password

### CreateAccountModel
    int Id  = 0
    string Username
    string Password

### PasswordModel

    string Salt
    string Hash

```

### Services
    Context/Folder
    - DataContext
    - UserService/file
        - GetUserByUsername
        - Login
        - AddUser
        - UpdateUser
        - DeleteUser
### BlogItemService
    - AddBlogItems
    - GetAllBlogItems
    - GetBlogItemsByCategory
    - GetBlogItemsByTag
    - GetBlogItemsByDate
    - GetPublishedBlogItems
    - UpdateBlogItems
    - DeleteBlogItems
    - GetUserById
### PasswordService
    - Hash Password
    - Verify Hash Password
