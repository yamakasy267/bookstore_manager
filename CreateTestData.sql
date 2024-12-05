INSERT INTO public."Author" ("Id","Name","Birthday")
	VALUES (1,'bulgakov','1998-09-23');

INSERT INTO public."Books" ("Id","Name","AuthorId","Price","DatePublication")
	VALUES (1,'Master',1,9.99,'0024-12-03');
INSERT INTO public."Books" ("Id","Name","AuthorId","Price","DatePublication")
	VALUES (2,'Margarit',1,9.99,'0024-12-03');


INSERT INTO public."Genre" ("Id","Name")
	VALUES (1,'Drama');

INSERT INTO public."BookGenre" ("BooksId","GenreId")
	VALUES (1,1);

INSERT INTO public."Users" ("Id","Name","SecondName","Birtday","Email","HashPassword")
	VALUES (1,'Ilya','Shef','2000-09-27','test@mail.ru','dgsdasgshdgs');

INSERT INTO public."Orders" ("Id","UserId","BooksCount","Sum")
	VALUES (1,1,2,523.0);

INSERT INTO public."BookOrder" ("BooksId","OrdersId")
	VALUES (1,1);
INSERT INTO public."BookOrder" ("BooksId","OrdersId")
	VALUES (2,1);

