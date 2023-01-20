--CREATE TABLE guardians
--(
--    id SERIAL PRIMARY KEY,
--    user_id INT,
--    contact_number VARCHAR
--);
--CREATE TABLE relationship
--(
--    id SERIAL PRIMARY KEY,
--    description VARCHAR
--);
--CREATE TABLE addresses
--(
--    id SERIAL PRIMARY KEY,
--    address_line_1 VARCHAR,
--    address_line_2 VARCHAR,
--    county VARCHAR,
--    city VARCHAR,
--    postcode VARCHAR
--);
--CREATE TABLE users
--(
--    id SERIAL PRIMARY KEY,
--    first_name VARCHAR(255),
--    last_name VARCHAR(255),
--    address_id INT constraint users_addresses_user_address_id_fk references public.addresses
--);
--
--CREATE TABLE events
--(
--    id SERIAL PRIMARY KEY,
--    description VARCHAR(255),
--    event_time TIMESTAMP,
--);
--CREATE TABLE children
--(
--    id SERIAL PRIMARY KEY,
--    users_id INT Constraint children_users_children_users_id_fk references public.users
--);
--CREATE TABLE events_addresses_children
--(
--  events_id INT constraint events_addresses_children_events_events_addresses_children_events_id_fk references public.events,
--  children_id INT constraint events_addresses_children_children_events_addresses_children_children_id_fk references public.children,
--  addresses_id INT constraint events_addresses_children_addresses_events_addresses_children_addresses_id_fk references public.addresses
-- );
--CREATE TABLE guardians_children
--(
--    id SERIAL PRIMARY KEY,
--    guardians_id INT constraint guardians_children_guardians_guardians_children_guardians_id_fk REFERENCES public.guardians,
--    children_id INT constraint guardians_children_children_guardians_children_children_id_fk REFERENCES public.children,
--    relationship_id INT constraint guardians_children_guardians_children_relationship_id_fk REFERENCES public.relationship
--);
--sql
CREATE TABLE public.family (
	id serial4 NOT NULL,
	name varchar(255) NOT NULL,
	CONSTRAINT family_pkey PRIMARY KEY (id)
);
CREATE TABLE public.relationship_types (
	id serial4 NOT NULL,
	name varchar(255) NOT NULL,
	CONSTRAINT relationship_types_pkey PRIMARY KEY (id)
);
CREATE TABLE public.addresses (
	id serial4 NOT NULL,
	name varchar NOT NULL,
	address_line_1 varchar NOT NULL,
	address_line_2 varchar NULL,
	region varchar NOT NULL,
	country varchar NOT NULL,
	zipcode varchar NOT NULL,
	CONSTRAINT addresses_pkey PRIMARY KEY (id)
);
CREATE TABLE public.events (
	id serial4 NOT NULL,
	name varchar(255) NOT NULL,
	description varchar(255) NOT NULL,
	time_slot TIMESTAMP NOT NULL,
	address_id INT NOT NULL constraint events_addresses_address_id_fk REFERENCES public.addresses,
	CONSTRAINT events_pkey PRIMARY KEY (id)
);
CREATE TABLE public.users (
	id serial4 NOT NULL,
	first_name varchar(255) NOT NULL,
	last_name varchar(255) NOT NULL,
	email varchar(255) NOT NULL,
	password varchar(255) NOT NULL,
	active boolean NOT NULL,
	family_id INT NOT NULL constraint users_family_family_id_fk REFERENCES public.family,
	address_id INT NOT NULL constraint users_addresses_address_id_fk REFERENCES public.addresses,
	CONSTRAINT users_pkey PRIMARY KEY (id)
);
CREATE TABLE public.users_events (
	id serial4 NOT NULL,
	user_id INT NOT NULL constraint users_events_user_id_fk REFERENCES public.users,
	event_id INT NOT NULL constraint users_events_event_id_fk REFERENCES public.events
);
CREATE TABLE public.users_relationship_types (
	id serial4 NOT NULL,
	child_id INT NOT NULL constraint users_relationship_types_users_child_id_fk REFERENCES public.users,
	parent_id INT NOT NULL constraint users_relationship_types_users_parent_id_fk REFERENCES public.users,
	relationship_type_id INT NOT NULL constraint users_relationship_types_relationship_types_relationship_type_id_fk REFERENCES public.relationship_types,
	CONSTRAINT users_relationship_types_pkey PRIMARY KEY (id)
);



