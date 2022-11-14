CREATE TABLE guardians
(
    id INT,
    user_id INT
    contact_number VARCHAR(255),
    PRIMARY KEY (id)
);
CREATE TABLE relationship
(
    id INT,
    description STRING,
    PRIMARY KEY (id)
);
CREATE TABLE children
(
    id INT,
    PRIMARY KEY (id),
    FOREIGN KEY (users_id) REFERENCES table(users_id),
);
CREATE TABLE guardians_children
(
    id INT,
    PRIMARY KEY (id),
    FOREIGN KEY (guardians_id) REFERENCES table(guardians),
    FOREIGN KEY (children_id) REFERENCES table(children),
    FOREIGN KEY (relationship_id) REFERENCES table(relationship),
);
CREATE TABLE events
(
    id INT,
    description STRING,
    PRIMARY KEY (id),
    FOREIGN KEY (addresses_id) REFERENCES table(addresses),
);
CREATE TABLE events_addresses_children
(
  FOREIGN KEY (events_id) REFERENCES table(events),
  FOREIGN KEY (children_id) REFERENCES table(children),
  FOREIGN KEY (addresses_id) REFERENCES table(address),
);
CREATE TABLE addresses
(
    id INT,
    street_name STRING,
    house_number INT,
    town STRING,
    city STRING,
    postcode VARCHAR(255),
    PRIMARY KEY (id)
);
CREATE TABLE users
(
    id INT,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    user_address_id VARCHAR(255),
    PRIMARY KEY (id),
    FOREIGN KEY (addresses) REFERENCES table(addresses),
);
