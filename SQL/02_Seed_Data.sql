USE [PickUpAndPlay]
GO

set identity_insert [Area] on;
INSERT INTO "Area" ("Id", "Name")
VALUES
(1, 'North Nashville'),
(2, 'East Nashville'),
(3, 'South Nashville'),
(4, 'West Nashville'),
(5, 'Brentwood'),
(6, 'Clarksville'),
(7, 'Hendersonville'),
(8, 'Smyrna')
set identity_insert [Area] off;

set identity_insert [SkillLevel] on;
INSERT INTO "SkillLevel" ("Id", "Name")
VALUES
(1, 'Beginner'),
(2, 'Intermediate'),
(3, 'Advanced')
set identity_insert [SkillLevel] off;

set identity_insert [UserProfile] on;
INSERT INTO "UserProfile" ("Id", "FireBaseUserId", "FirstName", "LastName", "Email", "IsAdmin", "IsActive")
VALUES
(1, '4MEM0lUG4OgHPm0dQ3WN5S4VpnN2', 'Lee', 'Jennings', 'leerjennings@outlook.com', 1, 1),
(2, 'qq12xt0YCrMVSyaY2nIrb9pwnV23', 'Kareem', 'Abdul-Jabbar', 'kaj@gmail.com', 0, 1),
(3, 'bW6RcEbB9USBfaiVpPBwzsTMqMj2', 'Guy', 'Dude', 'guy@gmail.com', 0, 0)
set identity_insert [UserProfile] off;

set identity_insert [Game] on;
INSERT INTO "Game" ("Id", "UserProfileId", "Title", "ParkName", "Address", "Date", "Time", "AreaId", "SkillLevelId", "CreatedDateTime", "CleatsRequired", "WhiteAndDarkShirt", "BarefootFriendly", "DogsAllowed", "PlaygroundNearby", "BathroomsNearby", "DrinkingWaterNearby", "AllAges", "EighteenPlus")
VALUES
(1, 1, 'UltimateEast Wednesday Night', 'East Park', '700 Woodland Street', '2022-08-10', '17:30', 2, 1, '2022-08-03', 1, 1, 0, 0, 1, 1, 0, 1, 0),
(2, 2, 'Men''s Club Practice', 'Ted Rhodes Fields', '720 Mainstream Dr', '2022-09-01', '17:30', 1, 3, '2022-08-12', 1, 1, 0, 1, 0, 0, 0, 0, 1)
set identity_insert [Game] off;

set identity_insert [Comment] on;
INSERT INTO "Comment" ("Id", "GameId", "UserProfileId", "Content", "CreatedDateTime")
VALUES
(1, 1, 1, 'I''m running late! Anyone able to make sure the fields are open?', '2022-08-10'),
(2, 1, 2, 'All good, looks like the fields are free to use! See you soon!', '2022-08-10')
set identity_insert [Comment] off;

set identity_insert [Stat] on;
INSERT INTO "Stat" ("Id", "UserProfileId", "GameId", "Goals", "Assists", "Blocks", "Turnovers")
VALUES
(1, 1, 1, 2, 3, 0, 2)
set identity_insert [Stat] off;

INSERT INTO "Like" ("UserProfileId", "GameId")
VALUES
(1, 1),
(2, 1),
(2, 2)