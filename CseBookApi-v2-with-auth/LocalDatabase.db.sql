BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "User" (
	"Id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"FirstName"	TEXT,
	"LastName"	TEXT,
	"Username"	TEXT,
	"GradeLevel"	TEXT,
	"Course"	TEXT,
	"PasswordHash"	BLOB,
	"PasswordSalt"	BLOB
);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
	"MigrationId"	TEXT NOT NULL,
	"ProductVersion"	TEXT NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY("MigrationId")
);
INSERT INTO "__EFMigrationsHistory" VALUES ('20200102102942_InitialCreate','3.1.0');
COMMIT;
