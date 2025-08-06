# EduHub Frontend

A modern, responsive Angular web application for the EduHub online learning platform.

## 🚀 Features

### ✅ Completed Features

- **Top Navbar** with About Us, Contact Us (Telegram link), and Login button
- **Homepage** with featured courses, search bar, and category previews
- **Authentication System** with login/signup forms and JWT token management
- **Responsive Design** with modern UI/UX using Bootstrap 5 and custom SCSS
- **About Us Page** with team information and platform details

### 🔄 Planned Features

- **User Dashboard** with profile section and channel creation
- **Video Components** with video cards, detail pages, and category filtering
- **Search Functionality** with global and category-specific search
- **Instructor Channel** pages with video listings
- **Admin Panel** for category and user management

## 🛠️ Technology Stack

- **Angular 17** - Frontend framework
- **TypeScript** - Programming language
- **Bootstrap 5** - CSS framework
- **SCSS** - CSS preprocessor
- **FontAwesome** - Icons
- **RxJS** - Reactive programming

## 📋 Prerequisites

- Node.js (v18 or higher)
- npm (v9 or higher)
- Angular CLI (v17 or higher)

## 🔧 Installation

1. **Navigate to the frontend directory:**
   ```bash
   cd eduhub-frontend
   ```

2. **Install dependencies:**
   ```bash
   npm install
   ```

3. **Install Angular CLI globally (if not already installed):**
   ```bash
   npm install -g @angular/cli@17
   ```

## 🚀 Running the Application

### Development Server

```bash
ng serve
```

The application will be available at `http://localhost:4200`

### Production Build

```bash
ng build --prod
```

The build artifacts will be stored in the `dist/` directory.

## 🌐 Environment Configuration

The application is configured to connect to the backend API:

- **Development**: `http://localhost:5000/api`
- **Production**: Configure in `src/environments/environment.prod.ts`

## 📁 Project Structure

```
src/
├── app/
│   ├── components/
│   │   ├── navbar/           # Top navigation component
│   │   ├── homepage/         # Main homepage
│   │   ├── auth/            # Login/Signup components
│   │   ├── about/           # About Us page
│   │   ├── profile/         # User profile (planned)
│   │   ├── video/           # Video components (planned)
│   │   ├── channel/         # Channel pages (planned)
│   │   └── admin/           # Admin panel (planned)
│   ├── services/
│   │   ├── auth.service.ts      # Authentication service
│   │   ├── video.service.ts     # Video management
│   │   ├── category.service.ts  # Category management
│   │   ├── channel.service.ts   # Channel management
│   │   ├── comment.service.ts   # Comment system
│   │   └── like.service.ts      # Like system
│   ├── models/              # TypeScript interfaces
│   ├── guards/              # Route guards
│   └── ...
├── environments/            # Environment configurations
├── assets/                  # Static assets
└── styles.scss             # Global styles
```

## 🔐 Authentication Flow

1. **User Registration/Login** - Users can create accounts or sign in
2. **JWT Token Management** - Secure token-based authentication
3. **Auto-refresh** - Automatic token refresh on expiration
4. **Route Protection** - Guards protect authenticated routes
5. **Role-based Access** - Admin routes require admin privileges

## 🎨 UI/UX Features

- **Responsive Design** - Works on desktop, tablet, and mobile
- **Modern Gradient Design** - Beautiful color schemes and animations
- **Hover Effects** - Interactive elements with smooth transitions
- **Loading States** - User-friendly loading indicators
- **Form Validation** - Comprehensive client-side validation
- **Error Handling** - Graceful error messages and recovery

## 📱 Responsive Breakpoints

- **Mobile**: < 768px
- **Tablet**: 768px - 991px
- **Desktop**: > 991px

## 🔗 API Integration

The frontend integrates with the EduHub .NET backend API:

### Authentication Endpoints
- `POST /api/auth/login` - User login
- `POST /api/auth/signup` - User registration
- `POST /api/auth/refresh` - Token refresh

### Video Endpoints
- `GET /api/videos` - Get all videos
- `GET /api/videos/featured` - Get featured videos
- `GET /api/videos/category/{id}` - Get videos by category
- `GET /api/videos/search` - Search videos

### Category Endpoints
- `GET /api/categories` - Get all categories
- `POST /api/categories` - Create category (admin)

## 🎯 User Experience

### For Visitors (Not Logged In)
- View featured courses and category previews
- Learn about the platform on About Us page
- Access to signup/login forms
- Contact information via Telegram

### For Logged-In Users
- Full access to video library
- Category-based filtering
- Search functionality
- Profile management
- Channel creation capabilities

### For Administrators
- User management
- Category management
- Content moderation
- System administration

## 🚀 Deployment

### Development
```bash
ng serve --host 0.0.0.0 --port 4200
```

### Production
```bash
ng build --configuration production
```

Deploy the `dist/` folder to your web server.

## 📞 Contact

For questions or support, reach out to us on Telegram: [@sayfalseee](https://t.me/sayfalseee)

## 📄 License

This project is part of the EduHub learning platform.

---

**EduHub** - Learn, Create, Grow 🎓