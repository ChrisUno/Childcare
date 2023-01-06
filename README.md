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
          users }|--|{ users_relationships : "contains"
          relationships }|--|{ users_relationships : "contains"
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
    users_relationships {
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

    users }|--|| users_relationships: "uses"
    relationships }|--|| users_relationships: "uses"
    users }|--|| addresses: "uses"
    users }|--|| users_events: "uses"
    events }|--|| addresses: "uses"
    events }|--|| users_events: "uses"
    

```
EVENTS - GUARDIANS - GUARDIANS_CHILDREN - ADDRESSES - CHILDREN - EVENTS_GUARDIANS_CHILDREN - RELATIONSHIP - USERS
```

API Specification

GET /events Return a list of events

Response

[
  {
    "id": 1,
    "description": "Playdate as guest"
  }
]


GET /events/{id} Returns a single event

Response
{
  "id": 1,
  "time_slot": "2020-10-05 14:01:10.000",
  "description": "Playdate as guest",
  "address": {
    "id": 2,
    "address_line_1": "8 Rathmoyle Park West",
    "address_line_2": "Carrickfergus",
    "County": "Antrim",
    "City": "Belfast",
    "postcode": "BT387NG"
  }
}


GET /events/{id}/children Returns a single event with children

Response

 {
  "id": 1,
  "events_time": "2020-10-05 14:01:10.000",
  "description": "Playdate as guest",
  "children": [
    {
      "id": 1,
      "first_name": "Luca"
    }
  ]
}


GET /events/children/{id} Returns multiple events a single child is scheduled to attend
Response
[
 {
  “id”: 1,
  "first_name":<string>,
  "description": <string>,
  “time_slot”: <atimestamp>
  }
] 

GET /children  - Returns all children
 [
  {
    "id": "1",
    "first_name": "string",
    "last_name": "string",
    "guardians": [
      {
        "id": "1",
        "first_name": "string",
        "last_name": "string",
        "guardian_relationship": {
          "id": "1",
          "description": "father"
        }
      }
    ]
  }
]

GET /children/{id}  - Returns a single child by ID
 [
  {
    "id": "1",
    "first_name": "string",
    "last_name": "string",
    "guardians": [
      {
        "id": "1",
        "first_name": "string",
        "last_name": "string",
        "guardian_relationship": {
          "id": "1",
          "description": "father"
        }
      }
    ]
  }
]


POST /events/{id} Create an event
Request
{
  "description": "Holiday",
  "time_slot": "2020-12-11 12:00:00.000",
  "address_id": "23",
  "children": [
    {
      "id": "2",
      "guardian": {
        "id": "4"
      }
    }
  ]
}
  
  
Response - 201 Created

GET /users/{id} Returns user

Response

{
  “id”:"1",
  “first_name”:Chris,
  "last_name":Crawford,
   "address": {
    "id": 2,
    "address_line_1": "8 Rathmoyle Park West",
    "address_line_2": "Carrickfergus",
    "County": "Antrim",
    "City": "Belfast",
    "postcode": "BT387NG"
  }
}

GET /users Returns all user

Response

[
{
  “id”:"1",
  “first_name”:Chris,
  "last_name":Crawford,
   "address": {
    "id": 2,
    "address_line_1": "8 Rathmoyle Park West",
    "address_line_2": "Carrickfergus",
    "County": "Antrim",
    "City": "Belfast",
    "postcode": "BT387NG"
  }
}
]


POST /users Create a user

Request

{
  "first_name": "Anne",
  "last_name": "Accident",
  "address_id": "1"
}

POST /guardian Create a guardian

{
  "child_id": "1"
  "user_id": "5"
  "relationship_id": "4"
}

Response - 201 Created

POST /addresses Create an address
{
  "address_line_1": "string",
  "address_line_2": "string",
  "county": "string",
  "city": "string",
  "postcode": "string"
}
Response - 201 Created

PUT /address/{id} Update an address by id
Request
{
  "address_line_1": "string",
  "address_line_2": "string",
  "county": "string",
  "city": "string",
  "postcode": "string"
}

PUT /users/{id} Update a user by id
Request
{
  "first_name": "Lauren",
  "last_name": "Crawford",
  "address_id": 1
}

DELETE /users/{id} Delete a user by id

Response - 204 No Content

DELETE /event/{id} Delete an event by id

Response - 204 No Content

DELETE /addresses/{id} Delete an address by id

Response - 204 No Content
