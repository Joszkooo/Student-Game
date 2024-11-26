INSERT INTO Accounts (Name, Nickname, Email, Born_date, DateCreated, IsAdmin) VALUES
('Michal Jodko', 'Joszko', 'olbrzym012@wp.pl', '2002-08-10', GETDATE(), 1),
('John Doe', 'jdoe', 'john.doe@example.com', '1990-05-15', GETDATE(), 0),
('Jane Smith', 'jsmith', 'jane.smith@example.com', '1988-11-30', GETDATE(), 0),
('Paul Allen', 'pallen', 'paul.allen@example.com', '1995-08-20', GETDATE(), 0),
('Sara Connor', 'sconnor', 'sara.connor@example.com', '1992-06-12', GETDATE(), 0),
('James Bond', 'jbond', 'james.bond@example.com', '1980-04-07', GETDATE(), 0),
('Tony Stark', 'tstark', 'tony.stark@example.com', '1975-05-29', GETDATE(), 0),
('Bruce Wayne', 'bwayne', 'bruce.wayne@example.com', '1985-03-01', GETDATE(), 0),
('Clark Kent', 'ckent', 'clark.kent@example.com', '1991-12-10', GETDATE(), 0),
('Diana Prince', 'dprince', 'diana.prince@example.com', '1993-07-20', GETDATE(), 0),
('Steve Rogers', 'srogers', 'steve.rogers@example.com', '1987-01-18', GETDATE(), 0);


INSERT INTO Foods (Name, BoostType, BoostAmount, Duration, Rarity) VALUES
('Apple', 1, 10, 5, 1),
('Bread', 2, 20, 10, 1),
('Meat', 3, 30, 15, 1),
('Fish', 2, 25, 12, 1),
('Cake', 1, 15, 8, 1),
('Cheese', 2, 20, 9, 1),
('Potion', 3, 50, 20, 2),
('Elixir', 4, 60, 25, 3),
('Fruit Salad', 1, 12, 6, 1),
('Steak', 3, 40, 18, 2);


INSERT INTO Weapons (Name, Damage, HitChance, Cost, Rarity) VALUES
('Sword', 100, 80, 300, 2),
('Axe', 120, 70, 400, 3),
('Bow', 80, 90, 250, 1),
('Dagger', 60, 95, 200, 1),
('Hammer', 140, 60, 500, 4),
('Spear', 110, 85, 350, 3),
('Crossbow', 90, 75, 300, 2),
('Staff', 70, 90, 250, 1),
('Mace', 130, 65, 450, 4),
('Greatsword', 150, 50, 600, 5);


INSERT INTO Armours (Name, Defense, Cost, Rarity) VALUES
('Iron Armor', 50, 200, 2),
('Leather Armor', 20, 50, 1),
('Chainmail Armor', 40, 150, 2),
('Dragon Scale Armor', 100, 500, 5),
('Steel Armor', 60, 250, 3),
('Wooden Armor', 10, 30, 1),
('Golden Armor', 80, 400, 4),
('Silver Armor', 70, 350, 4),
('Cloth Armor', 5, 10, 1),
('Mithril Armor', 90, 450, 5);


INSERT INTO Enemies (Name, Rank, Level, HealthPoints, AttackPoints, DefensePoints, LuckPoints, WeaponId, ArmourId , MaxHealth) VALUES
('Goblin', 1, 5, 150, 120, 50, 30, 1, 2, 150),
('Orc', 2, 8, 300, 180, 80, 40, 2, 3, 300),
('Troll', 2, 12, 450, 150, 120, 20, 3, 4, 450),
('Dragon', 5, 20, 1000, 500, 400, 10, 4, 5, 1000),
('Skeleton', 1, 3, 100, 90, 30, 15, 5, 6, 100),
('Zombie', 1, 4, 120, 80, 50, 25, 6, 7, 120),
('Vampire', 3, 10, 500, 300, 200, 50, 7, 8, 500),
('Werewolf', 4, 15, 700, 400, 300, 60, 8, 9, 700),
('Demon', 5, 18, 900, 450, 350, 70, 9, 10, 900),
('Witch', 3, 13, 600, 350, 250, 80, 10, 1, 600);


INSERT INTO Students (Money, Energy, LevelPoints, Rank, Level, Experience, HealthPoints, AttackPoints, DefensePoints, LuckPoints, IntelligencePoints, AccountId, MaxHealth) VALUES
(1000, 100, 50, 1, 10, 500, 200, 150, 100, 80, 70, 1, 200),
(500, 80, 30, 2, 5, 300, 150, 100, 50, 60, 50, 2, 150),
(2000, 120, 70, 3, 15, 700, 250, 200, 120, 90, 80, 3, 250),
(1500, 110, 60, 4, 12, 600, 220, 170, 110, 85, 75, 4, 220),
(1000, 100, 50, 2, 10, 500, 200, 150, 100, 80, 70, 5, 200),
(800, 90, 40, 3, 8, 400, 180, 140, 90, 75, 65, 6, 180),
(1200, 95, 55, 4, 11, 550, 210, 160, 105, 85, 70, 7, 210),
(1800, 105, 65, 2, 14, 650, 230, 190, 115, 90, 80, 8, 230),
(900, 85, 45, 1, 9, 450, 190, 130, 95, 70, 60, 9, 190),
(500, 75, 35, 2, 7, 350, 170, 120, 85, 65, 55, 10, 170);


INSERT INTO Stats (Fights, Victories, Defeats, StudentId) VALUES
(100, 70, 30, 1),
(50, 40, 10, 2),
(200, 150, 50, 3),
(300, 250, 50, 4),
(120, 80, 40, 5),
(400, 300, 100, 6),
(180, 150, 30, 7),
(90, 70, 20, 8),
(60, 40, 20, 9),
(30, 25, 5, 10);


INSERT INTO Student_Armors (Quantity, StudentId, ArmourId) VALUES
(1, 1, 2),
(2, 2, 3),
(1, 3, 4),	
(3, 4, 5),
(1, 2, 4),
(2, 5, 6),
(1, 6, 7),
(1, 7, 8),
(2, 8, 9),
(3, 9, 10),
(2, 10, 1);


INSERT INTO Student_Foods (Quantity, StudentId, FoodId) VALUES
(5, 1, 1),
(10, 2, 2),
(7, 3, 3),
(8, 4, 4),
(6, 5, 5),
(9, 6, 6),
(1, 1, 2),
(4, 7, 7),
(12, 8, 8),
(3, 9, 9),
(11, 10, 10);


INSERT INTO Student_Weapons (Quantity, StudentId, WeaponId) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(2, 5, 5),
(1, 1, 3),
(1, 6, 6),
(5, 7, 7),
(3, 8, 8),
(4, 9, 9),
(1, 10, 10);