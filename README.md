# Childcare
In the part of parenting, organisation of your childs day is crucial, who is caring for them, when, where and when they need collected or where theyre going next.
An application that shows a daily schedule of the childs activities, guardian present and details like location of activity, time of activity, guardians contact details etc.
With each guardian that has time with the child would have an account providing their details.

## Goals
-  Simple, easy to use tool
-  Manage accounts of Parents, Friends, Guardians, locations
-  Provide a traceable daily Rota/timeline with ability to edit
-  Ability to communicate amongst accounts with ease

## Solution
An application that provides clear information on where the child is, who theyre with and where theyre going.

## Project Outline

**MVP**

-   Create a Parent Account & Password
-   Create a Guardian
-   Create a Location
-   Create an Event
-   Daily calendar to track appointments, Activities.
-   Ability to update, edit and remove appointments and activities.

**V1 Goals**

-   Push Notifications
-   Automatically send email updates to parents
-   Flag late appearances or issues

## Domain Model
``` mermaid
erDiagram

          events }|--|{ addresses : "contains"
          events }|--|{ users_events : "contains"
          users }|--|{ users_events : "contains"
          users }|--|{ addresses : "contains"
          users }|--|{ users_relationship : "contains"
          users_relationship }|--|{ relationship_types : "contains"
          users }|--|{ family : "contains"
```

## ERD 
``` mermaid
%%{init: {'theme': 'dark' } }%%

erDiagram


    family {
        int id
        string name
    }
    relationship_types {
        int id
        string name
    }
    users_relationship {
        int id
        int parent_id
        int child_id
        int relationship_type_id
    }
    events {
        int id
        string name
        string description
        TIMESTAMP Time_slot
        int addresses_id
    }
    users_events {
        int id
        int users_id
        int events_id
        
    }
    addresses {
        int Id
        string name
        string Address_Line_1
        string Address_Line_2
        string Region
        string Zipcode
        string Country
        int Family_id
    }
    users {
        int Id
        string first_name
        string last_name
        string email
        string password
        int family_id
        int addresses_id
    }

    users }|--|| users_relationship: "uses"
    users }|--|| addresses: "uses"
    users }|--|| users_events: "uses"
    events }|--|| addresses: "uses"
    events }|--|| users_events: "uses"
    users_relationship }|--|| relationship_types: "uses"
    users }|--|| family: "uses"
    

```

```

API Specification

**USERS**

GET /users/{id} Returns user by id and all relationships - first name last name and relationship

Response

{
  “id”:"1",
  “first_name”:"Chris",
  "last_name":"Crawford",
  "email":"chriscrawford86@gmail.com",
  "family": {
    "id": "1",
    "name": "Crawford"
  },
   "address": {
    "id": 2,
    "address_line_1": "8 Rathmoyle Park West",
    "address_line_2": "Carrickfergus",
    "region": "Belfast",
    "Country": "NI",
    "zipcode": "BT387NG"
  },
}

GET /users Returns all users with first name, last name and email
Optional filter on family id

Response

[
{
  “id”:"1",
  “first_name”:"Chris",
  "last_name":"Crawford",
  "email":"chriscrawford86@gmail.com"
}
]


POST /users Creates user, optional relationships at this point.

Request

{
  "first_name": "Anne",
  "last_name": "Accident",
  "email": "anneaccident10@gmail.com",
  "password":"crispbag",
  "family_id": "1",
  "address_id": "1"  
}

PUT /users/{id} Update a user and relationships
Request
{
  "first_name": "Lauren",
  "last_name": "Crawford",
  "email":"laurencrawford35@gmail.com",
  "family_id": "1",
  "address_id": "1"  
}

DELETE /users/{id} soft deletion a user by id

Response - 204 No Content


**EVENTS**

GET /events Return all events names and descriptions

Response

[
  {
    "id": 1,
    "name":Playdate as host,
    "description": "playtime with a/some child/ren at home"
  }
]


GET /events/{id} Returns an event with name and description, times lot and address

Response
{
  "id": 1,
  "name":Playdate as host
  "description": "playtime with a/some child/ren at home",
  "time_slot": "2020-10-05 14:01:10.000",
  "address": {
    "id": 1,
    "address_line_1": "8 Rathmoyle Park West",
    "address_line_2": "Carrickfergus",
    "region": "Belfast",
    "Country": "NI",
    "zipcode": "BT387NG"
  }
}

POST /events Creates event.

Request

{
  "name": "Playdate as host",
  "description": "playtime with a/some child/ren at home",
  "time_slot": "2020-10-05 14:01:10.000",
  "address_id":"1" 
}

PUT /events/{id} Update event, description, address and its time slot
Request
{
  "id": "1",
  "name": "Playdate as host",
  "description":"playtime with a/some child/ren at home",
  "time_slot": "2020-10-05 14:01:10.000",
  "address_id": "1"  
}

DELETE /events/{id} soft deletion an event by id

Response - 204 No Content


**Family**


GET /family  - Returns all families
 [
  {
    "id": "1",
    "name": "Crawford"
  }
]

GET /family/{id}  - Returns a family with all family members
 [
  {
    "id": "1",
    "name": "Crawford",
    "users_relationship_types":{
        "id": "1",
        "child_id": "string",
        "parent_id": "string"
        }
        "relationship_type_id": {
          "id": "1",
          "name": "father"
        }
     }
   ]


POST /family Create a family
Request
{
  "id": "2",
  "name": "Lavery",
}
    
Response - 201 Created


PUT /family/{id} Update a family name

{
  "id": "1",
  "name": "5"
}
Response - 201 Created


DELETE /family/{id} Soft Delete a family by id

Response - 204 No Content


**ADDRESSES**
We won’t directly create addresses, instead addresses will be created with users and events.

GET /Addresses/{AddressID} Return address by id
Request
{
   "id": 1,
   "address_line_1": "8 Rathmoyle Park West",
   "address_line_2": "Carrickfergus",
   "region": "Belfast",
   "Country": "NI",
   "zipcode": "BT387NG"
}

GET /Addresses?FamilyID={FamilyID} return address by family id
Request
{
   "family":{
          "id":"1"
          "name":"Crawford"
          }
   "address_line_1": "8 Rathmoyle Park West",
   "address_line_2": "Carrickfergus",
   "region": "Belfast",
   "Country": "NI",
   "zipcode": "BT387NG"
}


**Relationship_types**

GET /Relationship_types/ - Return all relationship types
{
     "id":"1"
     "name":"Father"
}


