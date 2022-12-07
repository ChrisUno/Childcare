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
          guardians ||--|{ events : "creates"
          guardians ||--|{ children : "creates"
          guardians ||--|{ addresses : "creates"
          guardians ||--|{ relationship : "creates"
          guardians ||--|{ users : "creates"
          events }|--|{ addresses : "contains"
          children }|--|{ user_id : "contains"
          users }|--|{ addresses : "contains"
          
```

## ERD 
``` mermaid
%%{init: {'theme': 'dark' } }%%

erDiagram

    guardians {
        int Id
        int user_id
        int contact_number
    }
    relationship {
        int id
        string description
    }
    children {
        int id
        int users_id
    }
    guardians_children {
        int Id
        int guardians_id
        int children_id
        int relationship_id
    }
    events {
        int id
        int addresses_id
        string description
    }
    events_guardians_children {
        int events_id
        int children_id
        int addresses_id
    }
    addresses {
        int Id
        string street_name
        string house_number
        string town
        string city
        string postcode
    }
    users {
        int Id
        string first_name
        string last_name
        int addresses_id
    }

    guardians ||--|{ children: "creates"
    children }|--|| users: "uses"
    events }|--|| addresses: "uses"
    guardians }|--|| users: "uses"
    guardians_children }|--|| guardians: "uses"
    guardians_children }|--|| children: "uses"
    guardians_children }|--|| addresses: "uses"
    guardians_children }|--|| relationship: "uses"
    users }|--|| addresses: "uses"
    events_guardians_children }|--|| guardians: "uses"
    events_guardians_children }|--|| events: "uses"
    events_guardians_children }|--|| children: "uses"

```

API Specification

Events
GET /events Return a list of all events

Response

[
  {
    "id": 1,
    "description": "Playdate as guest",
  },
  {
    "id": 2,
    "description": "Playdate as host",
  },
  {
    "id": 3,
    "description": "Park Visit",
  },
  {
    "id": 4,
    "description": "Birthday Party",
  },
  {
    "id": 5,
    "description": "Restaurant",
  },
  {
    "id": 6,
    "description": "Cafe",
  },
  {
    "id": 7,
    "description": "Softplay",
  },
  {
    "id": 8,
    "description": "Babysit",
  },
  {
    "id": 9,
    "description": "Childmind",
  },
  {
    "id": 10,
    "description": "Theatre",
  },
  {
    "id": 11,
    "description": "Open farm",
  },
  {
    "id": 12,
    "description": "Aquarium",
  },
  {
    "id": 13,
    "description": "Family visit",
  },
  {
    "id": 14,
    "description": "Seasonal occasion",
  },
  {
    "id": 15,
    "description": "Sport practice",
  },
  {
    "id": 16,
    "description": "swimming",
  }
]
Relationship
GET /relationship Return a list of all relationships

Response

[
  {
    "id": 1,
    "description": "Father"
  },
  {
    "id": 2,
    "description": "Mother"
  },
  {
    "id": 2,
    "description": "Grandmother"
  },
  {
    "id": 2,
    "description": "Grandfather"
  },
  {
    "id": 2,
    "description": "Sister"
  },
  {
    "id": 2,
    "description": "Brother"
  },
  {
    "id": 2,
    "description": "Childminder"
  },
  {
    "id": 2,
    "description": "Aunt"
  },
  {
    "id": 2,
    "description": "Uncle"
  },
  {
    "id": 2,
    "description": "Friend"
  }
]
GET /games/users/{userId} Return a list of a user's games

Response

[
  {
    "id": 1,
    "title": "A Game Title",
    "genre": "The Genre",
    "platform": "The Platform",
    "status": "The Status"
  },
  {
    "id": 2,
    "title": "Another Game Title",
    "genre": "The Genre",
    "platform": "The Platform",
    "status": "The Status"
  }
]
GET /games/{id} Return a game by id

Response

{
  "id": 1,
  "title": "A Game Title",
  "genre": "Racing",
  "platform": "PS4"
}
POST /games/users/{userId} Create a game

Request

{
  "title": "A New Game",
  "genreId": 1,
  "platformId": 1,
  "statusId": 1
}
Response - 201 Created

USERS
GET /users/{id} Return a user by id

Response

{
  "id": 1,
  "username": "a_user",
  "enabled": true
}
POST /users Create a user

Request

{
  "username": "a_user",
  "password": "a_password"
}
Response - 201 Created

PUT /users/{id} Update a user by id

Request

{
  "username": "updated_user",
  "password": "updated_password",
  "enabled": true
}
DELETE /users/{id} Delete a user by id

Response - 204 No Content

Status
GET /status

POST /status

DELETE /status/{statusId}

Platforms
GET /platforms

POST /platforms

DELETE /platforms/{platformId}

Genres
GET /genres

POST /genres

DELETE /genres/{genreId}
