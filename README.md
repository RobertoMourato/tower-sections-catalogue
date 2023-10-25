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
CREATE TABLE sections (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	part_number TEXT,
	bottom_diameter REAL,
	top_diameter REAL
);

CREATE TABLE shells (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	height REAL,
	bottom_diameter REAL,
	top_diameter REAL,
	thickness REAL,
	steel_density REAL
);

-- ASSOCIATIVE TABLE
CREATE TABLE section_shell (
	id INTEGER PRIMARY KEY AUTOINCREMENT,
	section_id INTEGER,
	shell_id INTEGER,
	shell_position INTEGER,
	CONSTRAINT section_FK FOREIGN KEY (section_id) REFERENCES sections(id) ON DELETE CASCADE,
	CONSTRAINT shell_FK FOREIGN KEY (shell_id) REFERENCES shells(id) ON DELETE CASCADE
);
```