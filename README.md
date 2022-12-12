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
EVENTS - GUARDIANS - GUARDIANS_CHILDREN - ADDRESSES - CHILDREN - EVENTS_ADDRESSES_CHILDREN - RELATIONSHIP - USERS
```

API Specification

GET /events Return a list of all events

Response

[
  {
    "id": 1,
    "events_time":2020-10-05 14:01:10.000,
    "description": "Playdate as guest",
    "children": [
    {"id": 1,
    "first_name": @Luca
    }
  },
  {
    "id": 2,
    
    "description": "Playdate as host",
    "children": [
    {"id": 1,
    "first_name": @Luca
    }
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


GET /events/{id} Returns a single event

Response
[
{
    "id": 1,
    "events_time":2020-10-05 14:01:10.000,
    "description": "Playdate as guest",
  },
]

GET /events/{id}/children Returns a single event with both children
Response
[
 {
  “id”: 1,
  “events_time”:2020-10-05 14:01:10.000,
  “description”: “Playdate as guest”,
  “children”: [
  {“id”: 1,
  “first_name”: @Luca
  },
  {“id”:2,
  “first_name”: @Unknown
  }]
 },
]

GET /children/events/{id} Returns multiple events a single child is scheduled to attend
Response
[
 {
  “id”: 1,
  “users_id”:7,
  "description": "Playdate as guest",
  “events_time”:2020-10-05 06:00:00.000
  },
  {
  “id”: 2,
  “users_id”:7,
  "description": "Playdate as host",
  “events_time”:2020-10-07 08:00:00.000
  },
 {
  “id”: 3,
  “users_id”:7,
  "description": "Park visit",
  “events_time”:2020-10-09 10:00:00.000
  },
 {
  “id”: 4,
  “users_id”:7,
  "description": "Birthday Party",
  “events_time”:2020-10-11 12:00:00.000
  },
  {
  “id”: 5,
  “users_id”:7,
  "description": "Restaurant",
  “events_time”:2020-10-15 16:00:00-00
  },
 {
  “id”: 6,
  “users_id”:7,
  "description": "Cafe",
  “events_time”:2020-10-15 16:00:00.000
  },
 {
  “id”: 7,
  “users_id”:7,
  "description": "Softplay",
  “events_time”:2020-10-17 18:00:00.000
  },
  {
  “id”: 8,
  “users_id”:7,
  "description": "Babysit",
  “events_time”:2020-10-19 20:00:00.000
  },
  {
  “id”: 9,
  “users_id”:7,
  "description": "Childmind",
  “events_time”:2020-10-21 22:00:00.000
  },
  {
  “id”: 10,
  “users_id”:7,
  "description": "Theatre",
  “events_time”:2020-10-24 00:00:00.000
  },
  {
  “id”: 11,
  “users_id”:7,
  "description": "Open farm",
  “events_time”:2020-10-01 02:00:00.000
  },
 {
  “id”: 12,
  “users_id”:7,
  "description": "aquarium",
  “events_time”:2020-10-03 04:00:00.000
  },
  {
  “id”: 13,
  “users_id”:7,
  "description": "Family visit",
  “events_time”:2020-10-06 07:00:00.000
  },
  {
  “id”: 14,
  “users_id”:7,
  "description": "Seasonal occasion",
  “events_time”:2020-10-17 19:00:00.000
  },
 {
  “id”: 15,
  “users_id”:7,
  "description": "Sport practice",
  “events_time”:2020-10-10 11:00:00.000
  },
  {
  “id”: 16,
  “users_id”:7,
  "description": "swimming",
  “events_time”:2020-10-12 13:00:00.000
  }
  {
  “id”: 1,
  “users_id”:8,
  "description": "Playdate as guest",
  “events_time”:2020-10-05 06:00:00.000
  },
  {
  “id”: 2,
  “users_id”:8,
  "description": "Playdate as host",
  “events_time”:2020-10-07 08:00:00.000
  },
 {
  “id”: 3,
  “users_id”:8,
  "description": "Park visit",
  “events_time”:2020-10-09 10:00:00.000
  },
 {
  “id”: 4,
  “users_id”:8,
  "description": "Birthday Party",
  “events_time”:2020-10-11 12:00:00.000
  },
  {
  “id”: 5,
  “users_id”:8,
  "description": "Restaurant",
  “events_time”:2020-10-15 16:00:00-00
  },
 {
  “id”: 6,
  “users_id”:8,
  "description": "Cafe",
  “events_time”:2020-10-15 16:00:00.000
  },
 {
  “id”: 7,
  “users_id”:8,
  "description": "Softplay",
  “events_time”:2020-10-17 18:00:00.000
  },
  {
  “id”: 8,
  “users_id”:8,
  "description": "Babysit",
  “events_time”:2020-10-19 20:00:00.000
  },
  {
  “id”: 9,
  “users_id”:8,
  "description": "Childmind",
  “events_time”:2020-10-21 22:00:00.000
  },
  {
  “id”: 10,
  “users_id”:8,
  "description": "Theatre",
  “events_time”:2020-10-24 00:00:00.000
  },
  {
  “id”: 11,
  “users_id”:8,
  "description": "Open farm",
  “events_time”:2020-10-01 02:00:00.000
  },
 {
  “id”: 12,
  “users_id”:8,
  "description": "aquarium",
  “events_time”:2020-10-03 04:00:00.000
  },
  {
  “id”: 13,
  “users_id”:8,
  "description": "Family visit",
  “events_time”:2020-10-06 07:00:00.000
  },
  {
  “id”: 14,
  “users_id”:8,
  "description": "Seasonal occasion",
  “events_time”:2020-10-17 19:00:00.000
  },
 {
  “id”: 15,
  “users_id”:8,
  "description": "Sport practice",
  “events_time”:2020-10-10 11:00:00.000
  },
  {
  “id”: 16,
  “users_id”:8,
  "description": "swimming",
  “events_time”:2020-10-12 13:00:00.000
  }
]

GET /events/{id}/addresses Returns event address

Response
[
{
  “id”: 2,
  “description”:"Playdate as host",
  “events_time”:2020-10-07 08:00:00.000,
  "addresses": [
  {"id": 2,
  "address_line_1": 8 Rathmoyle Park West,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387NG
  }]
},

{
  “id”: 1,
  “description”:"Playdate as guest",
  “events_time”:2020-10-05 06:00:00.000,
  "addresses": [
  {"id": 15,
  "address_line_1": 4 Windslow Drive,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT389BB
  }]
},

{
  “id”: 3,
  “description”:"Park visit",
  “events_time”:2020-10-09 10:00:00.000,
  "addresses": [
  {"id": 5,
  "address_line_1": Marine Gardens,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387UP
  }]
},
{
  “id”: 4,
  “description”:"Birthday Party",
  “events_time”:2020-10-11 12:00:00.000,
  "addresses": [
  {"id": 4,
  "address_line_1": Airtastic,
  "address_line_2": 38 Mill road Newtownabbey,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT367BE
  }]
},
{
  “id”: 5,
  “description”:"Restaurant",
  “events_time”:2020-10-13 14:00:00.000,
  "addresses": [
  {"id": 8,
  "address_line_1": Ownies,
  "address_line_2": 16-18 Joymount Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387DN
  },
  {
  “id”: 6,
  “description”:"Cafe",
  “events_time”:2020-10-13 14:00:00.000,
  "addresses": [
  {"id": 9,
  "address_line_1": Season,
  "address_line_2": B90,
  "County": Carrickfergus,
  "City": Belfast,
  "postcode": BT389DQ
  },
  {
  “id”: 7,
  “description”:"Softplay",
  “events_time”:2020-10-13 14:00:00.000,
  "addresses": [
  {"id": 4,
  "address_line_1": Airtastic,
  "address_line_2": 38 Mill road Newtownabbey,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT367BE
  },
  {
  “id”: 8,
  “description”:"Babysit",
  “events_time”:2020-10-19 20:00:00.000,
  "addresses": [
  {"id": 3,
  "address_line_1": 35 Chichester square,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT388JU
  },
  {
  “id”: 9,
  “description”:"Childmind",
  “events_time”:2020-10-21 22:00:00.000,
  "addresses": [
  {"id": 7,
  "address_line_1": 19 Loughview Village,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387PD
  },
  {
  “id”: 10,
  “description”:"Theatre",
  “events_time”:2020-10-24 00:00:00.000,
  "addresses": [
  {"id": 10,
  "address_line_1": Grand Opera House,
  "address_line_2": 2-4,
  "County":  Great Victoria St,
  "City": Belfast,
  "postcode": BT27HR
  },
  {
  “id”: 11,
  “description”:"Open farm",
  “events_time”:2020-10-01 02:00:00.000,
  "addresses": [
  {"id": 11,
  "address_line_1": Streamvale Open Farm,
  "address_line_2": 38,
  "County":  Ballyhanwood Rd,
  "City": Belfast,
  "postcode": BT57SN
  },
  {
  “id”: 12,
  “description”:"aquarium",
  “events_time”:2020-10-03 04:00:00.000,
  "addresses": [
  {"id": 6,
  "address_line_1": Exploris Aquarium,
  "address_line_2":  1 The RopeWalk,
  "County": Portaferry,
  "City": Newtownards,
  "postcode": BT221NZ
  },
  {
  “id”: 13,
  “description”:"Family visit",
  “events_time”:2020-10-06 07:00:00.000,
  "addresses": [
  {"id": 2,
  "address_line_1": 5 Bluefield way,
  "address_line_2":  Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387UB
  },
  {
  “id”: 14,
  “description”:"Seasonal occasion",
  “events_time”:2020-10-08 09:00:00.000,
  "addresses": [
  {"id": 14,
  "address_line_1": Ulster Folk & Transport,
  "address_line_2":   museum,
  "County": Cultra,
  "City": Holywood,
  "postcode": BT18 0EU
  },
  {
  “id”: 15,
  “description”:"Sport practice",
  “events_time”:2020-10-10 11:00:00.000,
  "addresses": [
  {"id": 12,
  "address_line_1": Amphitheatre,
  "address_line_2":   Wellness Centre,
  "County": Prince William Way,
  "City": Carrickfergus,
  "postcode": BT387HP
  },
  {
  “id”: 16,
  “description”:"swimming",
  “events_time”:2020-10-12 13:00:00.000,
  "addresses": [
  {"id": 12,
  "address_line_1": Amphitheatre,
  "address_line_2":   Wellness Centre,
  "County": Prince William Way,
  "City": Carrickfergus,
  "postcode": BT387HP
  },
  ]
},

GET /events/addresses Returns all events addresses
Response

{
  “description”:"Playdate as guest",
  “events_time”:2020-10-05 06:00:00.000,
  "addresses": [{
  "address_line_1": 4 Windslow Drive,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT389BB
  }]
},

{
  “description”:"Park visit",
  “events_time”:2020-10-09 10:00:00.000,
  "addresses": [{
  "address_line_1": Marine Gardens,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387UP
  }]
},
{
  “description”:"Birthday Party",
  “events_time”:2020-10-11 12:00:00.000,
  "addresses": [{
  "address_line_1": Airtastic,
  "address_line_2": 38 Mill road Newtownabbey,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT367BE
  }]
},
{
  “description”:"Restaurant",
  “events_time”:2020-10-13 14:00:00.000,
  "addresses": [{
  "address_line_1": Ownies,
  "address_line_2": 16-18 Joymount Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387DN
  },
  {
  “description”:"Cafe",
  “events_time”:2020-10-13 14:00:00.000,
  "addresses": [{
  "address_line_1": Season,
  "address_line_2": B90,
  "County": Carrickfergus,
  "City": Belfast,
  "postcode": BT389DQ
  },
  {
  “description”:"Softplay",
  “events_time”:2020-10-13 14:00:00.000,
  "addresses": [{
  "address_line_1": Airtastic,
  "address_line_2": 38 Mill road Newtownabbey,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT367BE
  },
  {
  “description”:"Babysit",
  “events_time”:2020-10-19 20:00:00.000,
  "addresses": [{
  "address_line_1": 35 Chichester square,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT388JU
  },
  {
  “description”:"Childmind",
  “events_time”:2020-10-21 22:00:00.000,
  "addresses": [{
  "address_line_1": 19 Loughview Village,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387PD
  },
  {
  “description”:"Theatre",
  “events_time”:2020-10-24 00:00:00.000,
  "addresses": [{
  "address_line_1": Grand Opera House,
  "address_line_2": 2-4,
  "County":  Great Victoria St,
  "City": Belfast,
  "postcode": BT27HR
  },
  {
  “description”:"Open farm",
  “events_time”:2020-10-01 02:00:00.000,
  "addresses": [{
  "address_line_1": Streamvale Open Farm,
  "address_line_2": 38,
  "County":  Ballyhanwood Rd,
  "City": Belfast,
  "postcode": BT57SN
  },
  {
  “description”:"aquarium",
  “events_time”:2020-10-03 04:00:00.000,
  "addresses": [{
  "address_line_1": Exploris Aquarium,
  "address_line_2":  1 The RopeWalk,
  "County": Portaferry,
  "City": Newtownards,
  "postcode": BT221NZ
  },
  {
  “description”:"Family visit",
  “events_time”:2020-10-06 07:00:00.000,
  "addresses": [{
  "address_line_1": 5 Bluefield way,
  "address_line_2":  Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387UB
  },
  {
  “description”:"Seasonal occasion",
  “events_time”:2020-10-08 09:00:00.000,
  "addresses": [{
  "address_line_1": Ulster Folk & Transport,
  "address_line_2":   museum,
  "County": Cultra,
  "City": Holywood,
  "postcode": BT18 0EU
  },
  {
  “description”:"Sport practice",
  “events_time”:2020-10-10 11:00:00.000,
  "addresses": [{
  "address_line_1": Amphitheatre,
  "address_line_2":   Wellness Centre,
  "County": Prince William Way,
  "City": Carrickfergus,
  "postcode": BT387HP
  },
  {
  “description”:"swimming",
  “events_time”:2020-10-12 13:00:00.000,
  "addresses": [{
  "address_line_1": Amphitheatre,
  "address_line_2":   Wellness Centre,
  "County": Prince William Way,
  "City": Carrickfergus,
  "postcode": BT387HP
  },
  ]
},


GET /users/{id}/addresses Returns Single users address

Response

[
{
  “id”:"1",
  “first_name”:Chris,
  "last_name":Crawford,
  "addresses": [{
  "address_id": 1,
  "address_line_1": 8 Rathmoyle Park West,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387NG
  }]
},
]

GET /users/addresses Returns all users addresses

Response

[
{
“id”:"1",
  “first_name”:Chris,
  "last_name":Crawford,
  "addresses": [{
  "address_id": 1,
  "address_line_1": 8 Rathmoyle Park West,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387NG
  }]
},
{
“id”:"2",
  “first_name”:Lauren,
  "last_name":Lavery,
  "addresses": [{
  "address_id": 1
  "address_line_1": 8 Rathmoyle Park West,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387NG
  }]
},
{
“id”:"3",
  “first_name”:Marylyn,
  "last_name":Crawford,
  "addresses": [{
  "address_id": 2,
  "address_line_1": 5 Bluefield way,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387UB
  }]
},
{
“id”:"4",
  “first_name”:Stella,
  "last_name":Lavery,
  "addresses": [{
  "address_id": 3,
  "address_line_1": 35 Chichester square,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT388JU
  }]
},
{
“id”:"5",
  “first_name”:Amy,
  "last_name":McAteer,
  "addresses": [{
  "address_id": 7,
  "address_line_1": 19 Loughview Village,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387PD
  }]
},
{
“id”:"6",
  “first_name”:Laura,
  "last_name":Hughes,
  "addresses": [{
  "address_id": 15
  "address_line_1": 4 Windslow Drive,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT389BB
  }]
},
{
“id”:"7",
  “first_name”:Luca,
  "last_name":Crawford
  "addresses": [{
  "address_id": 1
  "address_line_1": 8 Rathmoyle Park West,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387NG
  }]
},
{
“id”:"8",
  “first_name”:Unknown,
  "last_name":Crawford
  "addresses": [{
  "address_id": 1
  "address_line_1": 8 Rathmoyle Park West,
  "address_line_2": Carrickfergus,
  "County": Antrim,
  "City": Belfast,
  "postcode": BT387NG
  }]
},
]

GET /Guardians/{id}/children/{id}/relationship/ Returns the guardians relationship to child

Response

{
“id”:"1",
  “first_name”:Chris,
  "last_name":Crawford,
  "children": [{
  "children_id": 1,
  "first_name": Luca,
  "last_name": Crawford
  }]
  "relationship" [{
  "description": Father
  }]
},

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




POST /events/users/{id} Create an event

Request

{
  "description": "Holiday",
  "id": 17,
  "events_time":2020-12-11 12:00:00.000,
  "users:[{
  "id":2
  }]
}
Response - 201 Created

POST /users Create a user

Request

{
  "id": "9"
  "first_name": "Anne",
  "last_name": "Accident",
  "address_id": "1",
  "relationship": [{
  "id":"5",
  "description": "sister"
  }]
}
Response - 201 Created

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
