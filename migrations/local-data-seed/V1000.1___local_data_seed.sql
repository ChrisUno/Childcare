insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('8 Rathmoyle Park West', 'Carrickfergus','Antrim', 'Belfast', 'BT387NG');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('5 Bluefield way', 'Carrickfergus','Antrim', 'Belfast', 'BT387UB');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('35 Chichester square', 'Carrickfergus','Antrim', 'Belfast', 'BT388JU');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Airtastic','38 Mill road Newtownabbey','Antrim', 'Belfast', 'BT367BE');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Marine Gardens', 'Carrickfergus','Antrim', 'Belfast', 'BT387UP');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Exploris Aquarium',' 1 The RopeWalk', 'Portaferry', 'Newtownards','BT22 1NZ');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('19 Loughview Village', 'Carrickfergus','Antrim', 'Belfast', 'BT387PD');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Ownies','16-18 Joymount Carrickfergus','Antrim','Belfast','BT387DN');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Season','B90', 'Carrickfergus','Belfast', 'BT38 9DQ');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Grand Opera House', '2-4', ' Great Victoria St', 'Belfast', 'BT27HR');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Streamvale Open Farm','38' ,' Ballyhanwood Rd', 'Belfast','BT57SN');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Amphitheatre' ,' Wellness Centre','Prince William Way', 'Carrickfergus', 'BT387HP');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Hillside Nursery Centre','328', ' Doagh Rd', 'Newtownabbey',' BT36 6XL');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('Ulster Folk & Transport' ,' museum', 'Cultra', 'Holywood', 'BT18 0EU');
insert into addresses (address_line_1, address_line_2, county, city, postcode) values ('4 Windslow Drive' ,'Carrickfergus', 'Antrim', 'Belfast', 'BT389BB');

insert into users (first_name, last_name, address_id) values ('Chris','Crawford',(select id from addresses where address_line_1='8 Rathmoyle Park West'));
insert into users (first_name, last_name, address_id) values ('Lauren','Lavery',(select id from addresses where address_line_1='8 Rathmoyle Park West'));
insert into users (first_name, last_name, address_id) values ('Marylyn','Crawford',(select id from addresses where address_line_1='5 Bluefield way'));
insert into users (first_name, last_name, address_id) values ('Stella','Lavery',(select id from addresses where address_line_1='35 Chichester square'));
insert into users (first_name, last_name, address_id) values ('Amy','McAteer',(select id from addresses where address_line_1='19 Loughview Village'));
insert into users (first_name, last_name, address_id) values ('Laura','Hughes',(select id from addresses where address_line_1='4 Windslow Drive'));
insert into users (first_name, last_name, address_id) values ('Luca','Crawford',(select id from addresses where address_line_1='8 Rathmoyle Park West'));
insert into users (first_name, last_name, address_id) values ('Unknown','Crawford',(select id from addresses where address_line_1='8 Rathmoyle Park West'));

insert into guardian (user_id, contact_number) values ((select id from users where first_name='Chris'), '07881361286');
insert into guardian (user_id, contact_number) values ((select id from users where first_name='Lauren'), '07707961688');
insert into guardian (user_id, contact_number) values ((select id from users where first_name='Marylyn'), '07703528999');
insert into guardian (user_id, contact_number) values ((select id from users where first_name='Stella'), '07895654035');
insert into guardian (user_id, contact_number) values ((select id from users where first_name='Amy'), '07891535715');
insert into guardian (user_id, contact_number) values ((select id from users where first_name='Laura'), '07923356548');

insert into children (users_id) values ((select id from users where first_name='Luca'));
insert into children (users_id) values ((select id from users where first_name='Unknown'));

--Chris,Luca,Father

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07881361286')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from relationship  where description ='Father')) r;
--Lauren, luca, mother

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07707961688')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from relationship  where description ='Mother')) r;
--Marylyn, luca, grandmother

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07703528999')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from relationship  where description ='Grandmother')) r;
--Stella, luca, grandmother

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07895654035')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from relationship  where description ='Grandmother')) r;
--Amy, luca, childminder

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07891535715')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from relationship  where description ='Childminder')) r;
--laura, luca, aunt

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07923356548')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from relationship  where description ='Aunt')) r;
--Chris,Unknown,Father

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07881361286')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from relationship  where description ='Father')) r;
--Lauren, Unknown, mother

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07707961688')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from relationship  where description ='Mother')) r;
--Marylyn, Unknown, grandmother

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07703528999')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from relationship  where description ='Grandmother')) r;
--Stella, Unknown, grandmother

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07895654035')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from relationship  where description ='Grandmother')) r;
--Amy, Unknown, childminder

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07891535715')) g,
((select ch.id  from children ch
inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from relationship  where description ='Childminder')) r;
--laura, Unknown, aunt

INSERT INTO guardian_children_relationship  (guardian_id, children_id, relationship_id)
select g.id, c.id, r.id
from ((select id  from guardian where contact_number = '07923356548')) g,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from relationship  where description ='Aunt')) r;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Playdate as host')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian  where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Playdate as guest')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07923356548')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Park visit')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Birthday Party')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Cafe')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Softplay')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Babysit')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07895654035')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Childmind')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07891535715')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Theatre')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Open farm')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'aquarium')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Family visit')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07703528999')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Seasonal occasion')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Sport practice')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Restaurant')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'swimming')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;
--Unknown

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Playdate as host')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian  where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Playdate as guest')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07923356548')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Park visit')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Birthday Party')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Cafe')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Softplay')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Babysit')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07895654035')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Childmind')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07891535715')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Theatre')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Open farm')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'aquarium')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Family visit')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07703528999')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Seasonal occasion')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Sport practice')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'Restaurant')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07707961688')) g;

INSERT INTO events_guardian_children  (events_id, guardian_id, children_id)
select e.id, g.id, c.id
from ((select id  from events e where description = 'swimming')) e,
((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
((select id  from guardian g where contact_number  ='07881361286')) g;

UPDATE events
SET time_slot  = '2020-10-05 06:00:00-00'
WHERE   id  = '1';
UPDATE events
SET time_slot  = '2020-10-07 08:00:00-00'
WHERE   id  = '2';
UPDATE events
SET time_slot  = '2020-10-09 10:00:00-00'
WHERE   id  = '3';
UPDATE events
SET time_slot  = '2020-10-11 12:00:00-00'
WHERE   id  = '4';
UPDATE events
SET time_slot  = '2020-10-13 14:00:00-00'
WHERE   id  = '5';
UPDATE events
SET time_slot  = '2020-10-15 16:00:00-00'
WHERE   id  = '6';
UPDATE events
SET time_slot  = '2020-10-17 18:00:00-00'
WHERE   id  = '7';
UPDATE events
SET time_slot  = '2020-10-19 20:00:00-00'
WHERE   id  = '8';
UPDATE events
SET time_slot  = '2020-10-21 22:00:00-00'
WHERE   id  = '9';
UPDATE events
SET time_slot  = '2020-10-23 24:00:00-00'
WHERE   id  = '10';
UPDATE events
SET time_slot  = '2020-10-01 02:00:00-00'
WHERE   id  = '11';
UPDATE events
SET time_slot  = '2020-10-03 04:00:00-00'
WHERE   id  = '12';
UPDATE events
SET time_slot  = '2020-10-06 07:00:00-00'
WHERE   id  = '13';
UPDATE events
SET time_slot  = '2020-10-08 09:00:00-00'
WHERE   id  = '14';
UPDATE events
SET time_slot  = '2020-10-10 11:00:00-00'
WHERE   id  = '15';
UPDATE events
SET time_slot  = '2020-10-12 13:00:00-00'
WHERE   id  = '16';

select *  from events_guardian_children egc
inner join events e  on e.id =egc.events_id
inner join guardian a on a.id =egc.guardian_id
inner join children c on c.id=egc.children_id;



