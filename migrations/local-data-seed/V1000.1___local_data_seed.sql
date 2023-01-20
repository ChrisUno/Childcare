insert into family (name) values ('Crawford');
-- insert into family (name) values ('Lavery');
-- insert into family (name) values ('Childminder');
-- insert into family (name) values ('N/A');

insert into addresses (name, address_line_1, address_line_2, region, country, zipcode) values ('Crawford-Lavery Residence', '8 Rathmoyle Park West', 'Carrickfergus','Belfast', 'NI', 'BT387NG');
insert into addresses (name, address_line_1, address_line_2, region, country, zipcode) values ('Crawford Residence','5 Bluefield way', 'Carrickfergus','Belfast', 'NI', 'BT38 7UB');
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Lavery Residence','35 Chichester square', 'Carrickfergus','Belfast', 'NI', 'BT38 8JU',(select id from family where name = 'Lavery' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Airtastic','38 Mill road', 'Newtownabbey','Belfast', 'NI', 'BT367BE',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Marine Gardens','Marine Highway', 'Carrickfergus','Belfast', 'NI', 'BT38 7UP',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Exploris Aquarium',' 1 The RopeWalk', 'Portaferry', 'Ards', 'NI','BT22 1NZ',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Childminders','19 Loughview Village', 'Carrickfergus','Belfast', 'NI', 'BT387PD',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Ownies','16-18 Joymount', 'Carrickfergus','Belfast','NI','BT387DN',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Season cafe','Barn', 'B90', 'Carrickfergus','NI', 'BT38 9DQ',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Grand Opera House', '2-4', ' Great Victoria St', 'Belfast', 'NI', 'BT2 7HR',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Streamvale Open Farm','38' ,' Ballyhanwood Rd','Dundonald', 'NI','BT5 7SN',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Amphitheatre' ,' Wellness Centre','Prince William Way','Carrickfergus', 'NI', 'BT38 7HP',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Hillside Nursery Centre','328', ' Doagh Rd','Newtonabbey', 'NI',' BT36 6XL',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Ulster Folk & Transport museum', 'Reception', 'Cultra', 'Holywood', 'NI', 'BT18 0EU',(select id from family where name = 'N/A' ));
-- insert into addresses (name, address_line_1, address_line_2, region, country, zipcode, family_id) values ('Hughes Residence', '4 Windslow Drive' ,'Carrickfergus', 'Belfast', 'NI', 'BT38 9BB',(select id from family where name = 'Crawford' ));

insert into users (first_name, last_name, email, password, family_id, address_id, active) values ('Chris','Crawford','chriscrawford86@gmail.com', 'parsnips',(select id from family where name='Crawford'),(select id from addresses where address_line_1='8 Rathmoyle Park West'),'TRUE');
-- insert into users (first_name, last_name, email, password, family_id, addresses_id) values ('Lauren','Lavery','laurenlavery06@gmail.com', 'potatoes',(select id from family where name='Lavery'),(select id from addresses where address_line_1='8 Rathmoyle Park West'));
insert into users (first_name, last_name, email, password, family_id, address_id, active) values ('Marylyn','Crawford','marylyncrawford60@gmail.com', 'carrots',(select id from family where name='Crawford'),(select id from addresses where address_line_1='5 Bluefield way'),'TRUE');
-- insert into users (first_name, last_name, email, password, family_id, addresses_id) values ('Stella','Lavery','stellalavery50@gmail.com', 'mince',(select id from family where name='Lavery'),(select id from addresses where address_line_1='35 Chichester square'));
-- insert into users (first_name, last_name, email, password, family_id, addresses_id) values ('Amy','McAteer','amymcateer40@gmail.com', 'swede',(select id from family where name='Childminder'),(select id from addresses where address_line_1='19 Loughview Village'));
-- insert into users (first_name, last_name, email, password, family_id, addresses_id) values ('Laura','Hughes','lauracrawford30@gmail.com', 'onions',(select id from family where name='Crawford'),(select id from addresses where address_line_1='4 Windslow Drive'));
insert into users (first_name, last_name, email, password, family_id, address_id,active) values ('Luca','Crawford','lucacrawford20@gmail.com', 'herbs',(select id from family where name='Crawford'),(select id from addresses where address_line_1='8 Rathmoyle Park West'),'TRUE');
-- insert into users (first_name, last_name, email, password, family_id, addresses_id) values ('Unknown','Crawford','unknowncrawford30@gmail.com', 'chilli',(select id from family where name='Crawford'),(select id from addresses where address_line_1='8 Rathmoyle Park West'));


insert into events (name, description, time_slot, address_id) values ('Playdate as guest', 'playtime with a/some child/ren not at home', '2020-10-05 06:00:00-00', (select id from addresses where name='Crawford Residence'));
insert into events (name, description, time_slot, address_id) values ('Playdate as host', 'playtime with a/some child/ren at home', '2020-10-07 08:00:00-00', (select id from addresses where name='Crawford-Lavery Residence'));
-- insert into events (name, description, time_slot, addresses_id) values ('Park visit', 'playtime at an outdoor park', '2020-10-09 10:00:00-00', (select id from addresses where address_line_1='Marine Gardens'));
-- insert into events (name, description, time_slot, addresses_id) values ('Birthday Party', 'attend a birthday party', '2020-10-11 12:00:00-00', (select id from addresses where address_line_1='Airtastic'));
-- insert into events (name, description, time_slot, addresses_id) values ('Restaurant', 'eatting a meal at a restaurant', '2020-10-13 14:00:00-00', (select id from addresses where address_line_1='Ownies'));
-- insert into events (name, description, time_slot, addresses_id) values ('Cafe', 'stopping at a cafe', '2020-10-15 16:00:00-00', (select id from addresses where address_line_1='Season cafe'));
-- insert into events (name, description, time_slot, addresses_id) values ('Softplay', 'playtime at a softplay area', '2020-10-17 18:00:00-00', (select id from addresses where address_line_1='Airtastic'));
-- insert into events (name, description, time_slot, addresses_id) values ('Babysit', 'babysitting as a favour', '2020-10-19 20:00:00-00', (select id from addresses where address_line_1='Lavery Residence'));
-- insert into events (name, description, time_slot, addresses_id) values ('Childmind', 'paid childcare', '2020-10-21 22:00:00-00', (select id from addresses where address_line_1='Childminders'));
-- insert into events (name, description, time_slot, addresses_id) values ('Theatre', 'trip to the theatre', '2020-10-23 24:00:00-00', (select id from addresses where address_line_1='Grand Opera House'));
-- insert into events (name, description, time_slot, addresses_id) values ('Open farm', 'visiting an open farm', '2020-10-01 02:00:00-00', (select id from addresses where address_line_1='Streamvale Open Farm'));
-- insert into events (name, description, time_slot, addresses_id) values ('aquarium', 'visiting an aquarium', '2020-10-03 04:00:00-00', (select id from addresses where address_line_1='Exploris Aquarium'));
-- insert into events (name, description, time_slot, addresses_id) values ('Family visit', 'visiting family', '2020-10-06 07:00:00-00', (select id from addresses where address_line_1='Crawford Residence'));
-- insert into events (name, description, time_slot, addresses_id) values ('Seasonal occasion', 'a seasonal trip or visit', '2020-10-08 09:00:00-00', (select id from addresses where address_line_1='Hillside Nursery Centre'));
-- insert into events (name, description, time_slot, addresses_id) values ('Sport practice', 'sport lessons and practice', '2020-10-10 11:00:00-00', (select id from addresses where address_line_1='Amphitheatre'));
-- insert into events (name, description, time_slot, addresses_id) values ('swimming', 'visit to the pool or sea', '2020-10-12 13:00:00-00', (select id from addresses where address_line_1='Amphitheatre'));


insert into users_events (user_id, event_id) values ((select id from users where first_name='Chris'), (select id from events where name='Playdate as host'));
insert into users_events (user_id, event_id) values ((select id from users where first_name='Marylyn'), (select id from events where name='Playdate as guest'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Marylyn'), (select id from events where name='Park visit'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Stella'), (select id from events where name='Birthday Party'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Amy'), (select id from events where name='Restaurant'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Laura'), (select id from events where name='Cafe'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Chris'), (select id from events where name='Softplay'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Lauren'), (select id from events where name='Babysit'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Chris'), (select id from events where name='Childmind'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Lauren'), (select id from events where name='Theatre'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Chris'), (select id from events where name='Open farm'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Lauren'), (select id from events where name='aquarium'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Chris'), (select id from events where name='Family visit'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Lauren'), (select id from events where name='Seasonal occasion'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Chris'), (select id from events where name='Sport Practice'));
-- insert into users_events (users_id, events_id) values ((select id from users where first_name='Lauren'), (select id from events where name='Swimming'));

-- insert into users_relationship_types (users_id, relationship_types_id) values ((select id from users where first_name='Lauren'), (select id from relationship_types where name='Mother'));
insert into users_relationship_types (parent_id, child_id, relationship_type_id) values ((select id from users where first_name='Chris'),(select id from users where first_name='Luca'), (select id from relationship_types where name='Father'));
insert into users_relationship_types (parent_id, child_id, relationship_type_id) values ((select id from users where first_name='Marylyn'),(select id from users where first_name='Chris'), (select id from relationship_types where name='Mother'));
-- insert into users_relationship_types (users_id, relationship_types_id) values ((select id from users where first_name='Marylyn'), (select id from relationship_types where name='Grandmother'));
-- insert into users_relationship_types (users_id, relationship_types_id) values ((select id from users where first_name='Stella'), (select id from relationship_types where name='Grandmother'));
-- insert into users_relationship_types (users_id, relationship_types_id) values ((select id from users where first_name='Laura'), (select id from relationship_types where name='Aunt'));
-- insert into users_relationship_types (users_id, relationship_types_id) values ((select id from users where first_name='Amy'), (select id from relationship_types where name='Childminder'));
-- insert into users_relationship_types (users_id, relationship_types_id) values ((select id from users where first_name='Luca'), (select id from relationship_types where name='Child'));
-- insert into users_relationship_types (users_id, relationship_types_id) values ((select id from users where first_name='Unknown'), (select id from relationship_types where name='Child'));




------------------------------






-- insert into guardians (users_id, contact_number) values ((select id from users where first_name='Lauren'), '07707961688');
-- insert into guardians (users_id, contact_number) values ((select id from users where first_name='Marylyn'), '07703528999');
-- insert into guardians (users_id, contact_number) values ((select id from users where first_name='Stella'), '07895654035');
-- insert into guardians (users_id, contact_number) values ((select id from users where first_name='Amy'), '07891535715');
-- insert into guardians (users_id, contact_number) values ((select id from users where first_name='Laura'), '07923356548');
-- --Chris,Luca,Father

-- INSERT INTO   (users_id, events_id)
-- select u.id, e.id
-- from users u,
-- --Lauren, luca, mother

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07707961688')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Mother')) r;
-- --Marylyn, luca, grandmother

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07703528999')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Grandmother')) r;
-- --Stella, luca, grandmother

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07895654035')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Grandmother')) r;
-- --Amy, luca, childminder

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07891535715')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Childminder')) r;
-- --laura, luca, aunt

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07923356548')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Aunt')) r;
-- --Chris,Unknown,Father

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07881361286')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Father')) r;
-- --Lauren, Unknown, mother

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07707961688')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Mother')) r;
-- --Marylyn, Unknown, grandmother

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07703528999')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Grandmother')) r;
-- --Stella, Unknown, grandmother

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07895654035')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Grandmother')) r;
-- --Amy, Unknown, childminder

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07891535715')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Childminder')) r;
-- --laura, Unknown, aunt

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07923356548')) g,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Aunt')) r;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Playdate as host')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians  where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Playdate as guest')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07923356548')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Park visit')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Birthday Party')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Cafe')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Softplay')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Babysit')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07895654035')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Childmind')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07891535715')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Theatre')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Open farm')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'aquarium')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Family visit')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07703528999')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Seasonal occasion')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Sport practice')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Restaurant')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'swimming')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;
-- --Unknown

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Playdate as host')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians  where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Playdate as guest')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07923356548')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Park visit')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Birthday Party')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Cafe')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Softplay')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Babysit')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07895654035')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Childmind')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07891535715')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Theatre')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Open farm')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'aquarium')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Family visit')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07703528999')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Seasonal occasion')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Sport practice')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'Restaurant')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07707961688')) g;

-- INSERT INTO events_guardians_children   (events_id, guardians_id, children_id)
-- select e.id, g.id, c.id
-- from ((select id  from events e where description = 'swimming')) e,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from guardians g where contact_number  ='07881361286')) g;

-- UPDATE events
-- SET time_slot  = '2020-10-05 06:00:00-00'
-- WHERE   id  = '1';
-- UPDATE events
-- SET time_slot  = '2020-10-07 08:00:00-00'
-- WHERE   id  = '2';
-- UPDATE events
-- SET time_slot  = '2020-10-09 10:00:00-00'
-- WHERE   id  = '3';
-- UPDATE events
-- SET time_slot  = '2020-10-11 12:00:00-00'
-- WHERE   id  = '4';
-- UPDATE events
-- SET time_slot  = '2020-10-13 14:00:00-00'
-- WHERE   id  = '5';
-- UPDATE events
-- SET time_slot  = '2020-10-15 16:00:00-00'
-- WHERE   id  = '6';
-- UPDATE events
-- SET time_slot  = '2020-10-17 18:00:00-00'
-- WHERE   id  = '7';
-- UPDATE events
-- SET time_slot  = '2020-10-19 20:00:00-00'
-- WHERE   id  = '8';
-- UPDATE events
-- SET time_slot  = '2020-10-21 22:00:00-00'
-- WHERE   id  = '9';
-- UPDATE events
-- SET time_slot  = '2020-10-23 24:00:00-00'
-- WHERE   id  = '10';
-- UPDATE events
-- SET time_slot  = '2020-10-01 02:00:00-00'
-- WHERE   id  = '11';
-- UPDATE events
-- SET time_slot  = '2020-10-03 04:00:00-00'
-- WHERE   id  = '12';
-- UPDATE events
-- SET time_slot  = '2020-10-06 07:00:00-00'
-- WHERE   id  = '13';
-- UPDATE events
-- SET time_slot  = '2020-10-08 09:00:00-00'
-- WHERE   id  = '14';
-- UPDATE events
-- SET time_slot  = '2020-10-10 11:00:00-00'
-- WHERE   id  = '15';
-- UPDATE events
-- SET time_slot  = '2020-10-12 13:00:00-00'
-- WHERE   id  = '16';

-- select *  from events_guardians_children  egc
-- inner join events e  on e.id =egc.events_id
-- inner join guardians a on a.id =egc.guardians_id
-- inner join children c on c.id=egc.children_id;





-- insert into children (users_id) values ((select id from users where first_name='Luca'));
-- insert into children (users_id) values ((select id from users where first_name='Unknown'));

-- --Chris,Luca,Father

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07881361286')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Father')) r;
-- --Lauren, luca, mother

-- INSERT INTO guardians_children_relationship  (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07707961688')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Mother')) r;
-- --Marylyn, luca, grandmother

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07703528999')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Grandmother')) r;
-- --Stella, luca, grandmother

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07895654035')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Grandmother')) r;
-- --Amy, luca, childminder

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07891535715')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Childminder')) r;
-- --laura, luca, aunt

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07923356548')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Luca')) c,
-- ((select id  from relationship  where description ='Aunt')) r;
-- --Chris,Unknown,Father

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07881361286')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Father')) r;
-- --Lauren, Unknown, mother

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07707961688')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Mother')) r;
-- --Marylyn, Unknown, grandmother

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07703528999')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Grandmother')) r;
-- --Stella, Unknown, grandmother

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07895654035')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Grandmother')) r;
-- --Amy, Unknown, childminder

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07891535715')) g,
-- ((select ch.id  from children ch
-- inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Childminder')) r;
-- --laura, Unknown, aunt

-- INSERT INTO guardians_children_relationship (guardians_id, children_id, relationship_id)
-- select g.id, c.id, r.id
-- from ((select id  from guardians where contact_number = '07923356548')) g,
-- ((select ch.id  from children ch inner join users u on ch.users_id = u.id where u.first_name ='Unknown')) c,
-- ((select id  from relationship  where description ='Aunt')) r;