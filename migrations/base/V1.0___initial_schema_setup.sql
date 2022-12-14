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
CREATE TABLE public.addresses (
	id serial4 NOT NULL,
	address_line_1 varchar NULL,
	address_line_2 varchar NULL,
	county varchar NULL,
	city varchar NULL,
	postcode varchar NULL,
	CONSTRAINT addresses_pkey PRIMARY KEY (id)
);
CREATE TABLE public.children (
	id serial4 NOT NULL,
	users_id int4 NULL,
	CONSTRAINT children_pkey PRIMARY KEY (id)
);
CREATE TABLE public.events (
	id serial4 NOT NULL,
	description varchar(255) NULL,
	time_slot TIMESTAMP,
	CONSTRAINT events_pkey PRIMARY KEY (id)
);
CREATE TABLE public.events_guardian_children (
	events_id int4 NULL,
	children_id int4 NULL,
	guardian_id int4 NULL
);
CREATE TABLE public.guardian (
	id serial4 NOT NULL,
	user_id int4 NULL,
	contact_number varchar NULL,
	CONSTRAINT guardian_pkey PRIMARY KEY (id)
);
CREATE TABLE public.guardian_children_relationship (
	id serial4 NOT NULL,
	guardian_id int4 NOT NULL,
	children_id int4 NOT NULL,
	relationship_id int4 NOT NULL,
	CONSTRAINT guardian_children_relationship_pkey PRIMARY KEY (id)
);
CREATE TABLE public.relationship (
	id serial4 NOT NULL,
	description varchar NULL,
	CONSTRAINT relationship_pkey PRIMARY KEY (id)
);
CREATE TABLE public.users (
	id serial4 NOT NULL,
	first_name varchar(255) NULL,
	last_name varchar(255) NULL,
	address_id int4 NULL,
	CONSTRAINT users_pkey PRIMARY KEY (id)
);

