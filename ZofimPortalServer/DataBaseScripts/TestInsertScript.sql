USE ZofimPortalDB
INSERT INTO Hanhaga
VALUES ('Hashachar', 11, 'Hamerkaz', 1)

INSERT INTO Shevet
VALUES ('Nachson', 1, 300, 1)

INSERT INTO [User]
VALUES ('aaa@gmail.com', 'AAA', 'AAA', '000000000', 'aaa', 1)

INSERT INTO [User]
VALUES ('bbb@gmail.com', 'BBB', 'BBB', '000000002', 'bbb', 2)

INSERT INTO Parent
VALUES (1, 1, 1)

INSERT INTO Worker ([Role], UserID, ID)
VALUES (0, 2, 1)

INSERT INTO [Role]
VALUES ('cadet', 2)

INSERT INTO [Role]
VALUES ('admin', 1)

INSERT INTO Cadet
VALUES ('aaa', 'AAA', '000000001', 1, 2, 1)

INSERT INTO Cadet_Parent
VALUES(1,1)
