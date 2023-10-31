# tower-sections-catalogue
Tower Sections Catalogue App

ASP.NET Core Web API .NET 7 runs at: http://localhost:5208

ASP.NET Core Web API .NET 7 documentation: http://localhost:5208/swagger/index.html

```
dotnet build && dotnet watch
```

Create Migrations (code first approach)
```
dotnet ef migrations add InitialCreate
```

Run Migrations (create database and tables)
```
dotnet ef database update
```

Database Tables (created by the migrations)
```
-- Sections definition
CREATE TABLE "Sections" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Sections" PRIMARY KEY AUTOINCREMENT,
    "PartNumber" TEXT NOT NULL,
    "BottomDiameter" REAL NOT NULL,
    "TopDiameter" REAL NOT NULL
);

-- Shells definition
CREATE TABLE "Shells" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Shells" PRIMARY KEY AUTOINCREMENT,
    "Height" REAL NOT NULL,
    "BottomDiameter" REAL NOT NULL,
    "TopDiameter" REAL NOT NULL,
    "Thickness" REAL NOT NULL,
    "SteelDensity" REAL NOT NULL
);

-- SectionShells definition
CREATE TABLE "SectionShells" (
    "SectionId" INTEGER NOT NULL,
    "ShellId" INTEGER NOT NULL,
    "ShellPosition" INTEGER NOT NULL,
    CONSTRAINT "PK_SectionShells" PRIMARY KEY ("SectionId", "ShellId"),
    CONSTRAINT "FK_SectionShells_Sections_SectionId" FOREIGN KEY ("SectionId") REFERENCES "Sections" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_SectionShells_Shells_ShellId" FOREIGN KEY ("ShellId") REFERENCES "Shells" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_SectionShells_ShellId" ON "SectionShells" ("ShellId");
```

Create Models (database first approach just for testing purposes)
```
dotnet ef dbcontext scaffold "Data Source=./Database/sqlite.db" Microsoft.EntityFrameworkCore.Sqlite -o Models --force
```