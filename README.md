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
