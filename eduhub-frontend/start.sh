#!/bin/bash

# EduHub Frontend Startup Script

echo "🎓 Starting EduHub Frontend..."
echo "=================================="

# Check if Node.js is installed
if ! command -v node &> /dev/null; then
    echo "❌ Node.js is not installed. Please install Node.js 18 or higher."
    exit 1
fi

# Check if npm is installed
if ! command -v npm &> /dev/null; then
    echo "❌ npm is not installed. Please install npm."
    exit 1
fi

echo "✅ Node.js version: $(node --version)"
echo "✅ npm version: $(npm --version)"

# Check if dependencies are installed
if [ ! -d "node_modules" ]; then
    echo "📦 Installing dependencies..."
    npm install --legacy-peer-deps
    if [ $? -ne 0 ]; then
        echo "❌ Failed to install dependencies."
        exit 1
    fi
else
    echo "✅ Dependencies already installed."
fi

# Check if Angular CLI is available
if ! command -v ng &> /dev/null; then
    echo "📦 Installing Angular CLI..."
    npm install -g @angular/cli@17
    if [ $? -ne 0 ]; then
        echo "❌ Failed to install Angular CLI."
        exit 1
    fi
else
    echo "✅ Angular CLI version: $(ng version --quiet)"
fi

echo ""
echo "🚀 Starting development server..."
echo "📱 The app will be available at: http://localhost:4200"
echo "🔗 Backend API should be running at: http://localhost:5000/api"
echo ""
echo "Press Ctrl+C to stop the server"
echo "=================================="

# Start the development server
ng serve --host 0.0.0.0 --port 4200