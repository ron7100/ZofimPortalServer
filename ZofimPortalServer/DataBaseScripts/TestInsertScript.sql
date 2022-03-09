USE ZofimPortalDB
INSERT INTO Hanhaga
VALUES ('השחר', 11, 'Hamerkaz', 1)

INSERT INTO Shevet
VALUES ('נחשון', 1, 300, 1)

INSERT INTO [User]
VALUES ('aaa@gmail.com', 'AAA', 'AAA', '000000000', 'aaa', 1),
	   ('bbb@gmail.com', 'BBB', 'BBB', '000000002', 'bbb', 2)

INSERT INTO [Role]
VALUES ('admin', 1),
	   ('חניך ד', 2)

INSERT INTO Parent
VALUES (1, 1, 1)

INSERT INTO Worker ([RoleID], UserID, ID)
VALUES (1, 2, 1)

INSERT INTO Cadet
VALUES ('aaa', 'AAA', '000000001', 1, 2, 1)

INSERT INTO Cadet_Parent
VALUES(1,1)
