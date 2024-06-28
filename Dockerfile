# Use the official .NET SDK 8.0 image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution file and project files
COPY Quizz/Quizz.sln ./Quizz/
COPY Quizz/Quizz.csproj ./Quizz/
COPY /Quizz.Common/Quizz.Common.csproj ./Quizz.Common/
COPY Quizz.Core.UnitTests/Quizz.Core.UnitTests.csproj ./Quizz.Core.UnitTests/
COPY Quizz.Domain.Core/Quizz.Domain.Core.csproj ./Quizz.Domain.Core/
COPY Quizz.Domain.Infrastructure/Quizz.Domain.Infrastructure.csproj ./Quizz.Domain.Infrastructure/

# Restore dependencies
RUN dotnet restore  Quizz/Quizz.sln

# Copy the remaining files and build the project
COPY . ./
RUN dotnet publish Quizz/Quizz.csproj -c Release -o out

# Use the official ASP.NET Core runtime 8.0 image as the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 80
EXPOSE 8080
EXPOSE 80

RUN pwd 
RUN ls

# Set the entry point to the built application
ENTRYPOINT ["dotnet", "Quizz.dll"]
