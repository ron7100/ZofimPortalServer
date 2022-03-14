USE ZofimPortalDB
INSERT INTO Hanhaga
VALUES ('השחר', 11, 'Hamerkaz', 1)

INSERT INTO Shevet
VALUES ('נחשון', 1, 300, 1)

INSERT INTO [User]
VALUES ('aaa@gmail.com', 'AAA', 'AAA', '000000000', 'aaa', 1),
	   ('bbb@gmail.com', 'BBB', 'BBB', '000000001', 'bbb', 2),
	   ('ccc@gmail.com', 'CCC', 'CCC', '000000002', 'ccc', 3),
	   ('ddd@gmail.com', 'DDD', 'DDD', '000000003', 'ddd', 4)

INSERT INTO [Role]
VALUES ('אדמין', 1),
	   ('ראש הנהגה', 2),
	   ('ראש שבט', 3),
	   ('חניך ד', 4)

INSERT INTO Parent
VALUES (1, 1, 1)

INSERT INTO Worker ([RoleID], UserID, ID)
VALUES (1, 2, 1)

INSERT INTO Worker ([RoleID], HanhagaID, UserID, ID)
VALUES (2, 1, 3, 2)

INSERT INTO Worker(ShevetID, [RoleID], HanhagaID, UserID, ID)
VALUES (1, 3, 1, 4, 3)

INSERT INTO Cadet
VALUES ('aaa', 'AAA', '100000000', 1, 4, 1)

INSERT INTO Cadet_Parent
VALUES(1,1)
