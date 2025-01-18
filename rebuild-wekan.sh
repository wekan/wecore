#!/bin/bash

# Use relative path from script location
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# Load environment variables from config file
if [ -f "$SCRIPT_DIR/config.env" ]; then
    export $(cat "$SCRIPT_DIR/config.env" | xargs)
else
    echo "Error: config.env file not found"
    exit 1
fi

check_directory() {
    cd "$SCRIPT_DIR"
    
    # Check if solution file exists
    if [ ! -f "WeCore.sln" ]; then
        echo "Creating new solution..."
        dotnet new sln -n WeCore
        
        # Check if API project exists
        if [ ! -d "WeCore.Api" ]; then
            echo "Creating API project..."
            dotnet new webapi -n WeCore.Api
            dotnet sln add WeCore.Api/WeCore.Api.csproj
            
            # Add packages to API project
            cd WeCore.Api
            dotnet add package Microsoft.EntityFrameworkCore
            dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            dotnet add package AutoMapper
            dotnet add package FluentValidation
            cd ..
        fi

        # Check if UI project exists
        if [ ! -d "WeCore.UI" ]; then
            echo "Creating Blazor WebAssembly project..."
            dotnet new blazorwasm -n WeCore.UI
            dotnet sln add WeCore.UI/WeCore.UI.csproj
            
            # Add packages to UI project
            cd WeCore.UI
            dotnet add package Microsoft.AspNetCore.Components.WebAssembly
            dotnet add package Microsoft.AspNetCore.Components.WebAssembly.DevServer
            cd ..
        fi
    fi
}

show_menu() {
    clear
    echo "==============================================="
    echo "           Wekan Management Script            "
    echo "==============================================="
    echo "1) Install Dependencies"
    echo "2) Build Application"
    echo "3) Run Application"
    echo "4) Build Docker Image"
    echo "5) Run with Docker Compose"
    echo "0) Exit"
    echo "==============================================="
}

install_dependencies() {
    echo "Installing dependencies..."
    check_directory
    
    # Verify dotnet installation and version
    if ! command -v dotnet &> /dev/null; then
        echo "Error: .NET SDK is not installed"
        echo "Please install .NET SDK and try again"
        exit 1
    fi
    
    DOTNET_VERSION=$(dotnet --version)
    if [[ "${DOTNET_VERSION}" < "8.0" ]]; then
        echo "Error: .NET SDK 8.0 or higher is required"
        echo "Current version: ${DOTNET_VERSION}"
        exit 1
    fi
    
    cd "$SCRIPT_DIR/WeCore.Api"
    echo "Restoring project dependencies..."
    dotnet restore
    if [ $? -ne 0 ]; then
        echo "Error: Failed to restore dependencies"
        exit 1
    fi
    
    cd "$SCRIPT_DIR"
    echo "Restoring solution dependencies..."
    dotnet restore
}

build_app() {
    echo "Building application..."
    check_directory
    cd "$SCRIPT_DIR"
    dotnet build --configuration Release
}

run_app() {
    echo "Running application..."
    check_directory
    cd "$SCRIPT_DIR"
    dotnet run --configuration Release
}

build_docker() {
    echo "Building Docker image..."
    docker build -t wekan-core:latest .
}

run_docker_compose() {
    echo "Running with Docker Compose..."
    docker compose up -d
}

# Main loop
while true; do
    show_menu
    read -p "Enter your choice [0-5]: " choice

    case $choice in
        1)
            install_dependencies
            read -p "Press Enter to continue..."
            ;;
        2)
            build_app
            read -p "Press Enter to continue..."
            ;;
        3)
            run_app
            ;;
        4)
            build_docker
            read -p "Press Enter to continue..."
            ;;
        5)
            run_docker_compose
            read -p "Press Enter to continue..."
            ;;
        0)
            echo "Exiting..."
            exit 0
            ;;
        *)
            echo "Invalid option. Press Enter to continue..."
            read
            ;;
    esac
done
