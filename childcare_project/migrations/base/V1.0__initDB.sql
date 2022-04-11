CREATE TABLE user_address
(
    id INT,
    street_name VARCHAR(255),
    house_number VARCHAR(255),
    town VARCHAR(255),
    city VARCHAR(255),
    postcode VARCHAR(255),
    country VARCHAR(255), 
    PRIMARY KEY (id)
);
CREATE TABLE user_type
(
    id INT,
    u_type VARCHAR(255),
    PRIMARY KEY (id)
);
CREATE TABLE child
(
    id INT,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    PRIMARY KEY (id)
);
CREATE TABLE event_type
(
    id INT,
    e_type VARCHAR(255),
    PRIMARY KEY (id)
);
CREATE TABLE event_status
(
    id INT,
    e_status VARCHAR(255),
    PRIMARY KEY (id)
);
CREATE TABLE relation
(
    id INT,
    relation_to_child VARCHAR(255),
    PRIMARY KEY (id)
);
CREATE TABLE event_location
(
    id INT,
    location_name VARCHAR(255),
    user_address_id VARCHAR(255),
    PRIMARY KEY (id)
    FOREIGN KEY (user_address_id) REFERENCES table(user_address),
);
CREATE TABLE user
(
    id INT,
    user_type VARCHAR(255),
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    contact_number VARCHAR(255),
    user_address_id VARCHAR(255), 
    PRIMARY KEY (id)
    FOREIGN KEY (user_type_id) REFERENCES table(user_type),
    FOREIGN KEY (user_address_id) REFERENCES table(user_address),
);
CREATE TABLE select_event
(
    id INT,
    event_description VARCHAR(255),
    start_time VARCHAR(255),
    finish_time VARCHAR(255),
    child_id VARCHAR(255),
    event_type_id VARCHAR(255), 
    event_status_id VARCHAR(255), 
    user_id_event_owner VARCHAR(255), 
    event_location_id VARCHAR(255), 
    PRIMARY KEY (id)
    FOREIGN KEY (child_id) REFERENCES table(child_id),
    FOREIGN KEY (event_type_id) REFERENCES table(event_type),
    FOREIGN KEY (event_status_id) REFERENCES table(event_status),
    FOREIGN KEY (event_user_id) REFERENCES table(event_user),
    FOREIGN KEY (event_location_id) REFERENCES table(event_location),
);
CREATE TABLE event_user
(
    id INT,
    user_id VARCHAR(255),
    select_event_id INT,
    PRIMARY KEY (id)
    FOREIGN KEY (user_id) REFERENCES table(user),
    FOREIGN KEY (select_event_id) REFERENCES table(select_event),
);
CREATE TABLE user_child
(
    id INT,
    user_id INT,
    child_id INT,
    relation_id INT,
    FOREIGN KEY (user_id) REFERENCES table(user),
    FOREIGN KEY (child_id) REFERENCES table(child),
    FOREIGN KEY (relation_id) REFERENCES table(relation),
);
