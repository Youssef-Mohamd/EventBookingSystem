
 # 🎟️ Event Booking System

A full-featured **Event Booking System** designed to make discovering, managing, and booking events simple and efficient.  
The system supports event browsing, ticket reservations, user management, reviews, wishlists, and administrative tools for event organizers and admins.  
Built with a modular clean architecture, the project ensures scalability, maintainability, and smooth operation across all components.


---

## 👥 User Roles & Permissions

| **User Type**       | **CAN Do**                                                                 | **CANNOT Do**                                      |
|---------------------|----------------------------------------------------------------------------|----------------------------------------------------|
| **Visitor**         | - Browse events<br>- Search & filter events<br>- View event details        | - Book tickets<br>- Leave reviews<br>- Save favorites |
| **Registered User** | - All visitor capabilities<br>- Book tickets<br>- Write reviews & ratings<br>- Manage profile<br>- Save favorites to wishlist | - Edit event details<br>- Access admin features ||
| **Admin**           | - Full system access<br>- Manage all events<br>- Manage users<br>- View all reports | *None* |


## 🚀 Features

###  Authentication & Users
- Register & Login using JWT Authentication
- User roles (Admin / User)
- Manage user profile
- Secure authorization for protected endpoints

###  Event Management
- Create, update, and delete events (Admin)
- Categorize events by category and status
- Multiple ticket types
- Search & filter events

###  Booking System
- Book tickets with availability check
- View user bookings
- Update or cancel booking
- Booking status (Pending, Confirmed, Cancelled)

###  Reviews
- Add reviews to events
- Edit / remove reviews
- Event rating system

###  Wishlist
- Add events to wishlist
- Remove from wishlist
- Retrieve all wishlist items

---

## 🏗️ Project Structure

```text
EventBookingSystem/
│
├── 📁 EventBooking.API/                   
│   ├── 📁 Controllers/                    
│   │   ├── 📄 EventsController.cs         
│   │   ├── 📄 BookingsController.cs       
│   │   ├── 📄 AuthController.cs           
│   │   ├── 📄 UsersController.cs          
│   │   └── 📄 ReviewsController.cs        
│   │
│   ├── 📄 Program.cs                      
│   └── 📄 appsettings.json                
 
