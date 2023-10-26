# tower-sections-catalogue
Tower Sections Catalogue App

http://localhost:5208/swagger/index.html

```
dotnet build && dotnet watch
```

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

```
dotnet ef dbcontext scaffold "Data Source=./Database/sqlite.db" Microsoft.EntityFrameworkCore.Sqlite -o Models --force
```

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
    "Id" INTEGER NOT NULL CONSTRAINT "PK_SectionShells" PRIMARY KEY AUTOINCREMENT,
    "SectionId" INTEGER NOT NULL,
    "ShellId" INTEGER NOT NULL,
    "ShellPosition" INTEGER NOT NULL,
    CONSTRAINT "FK_SectionShells_Sections_SectionId" FOREIGN KEY ("SectionId") REFERENCES "Sections" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_SectionShells_Shells_ShellId" FOREIGN KEY ("ShellId") REFERENCES "Shells" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_SectionShells_SectionId" ON "SectionShells" ("SectionId");
CREATE INDEX "IX_SectionShells_ShellId" ON "SectionShells" ("ShellId");
```