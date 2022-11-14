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
          GUARDIAN ||--|{ EVENT : "creates"
          GUARDIAN ||--|{ CHILD : "creates"
          GUARDIAN }|--|{ GUARDIAN_TYPES : "contains"
          GUARDIAN ||--|{ GUARDIAN_ADDRESS : "creates"
          GUARDIAN ||--|{ EVENT_GUARDIAN : "creates"
          GUARDIAN ||--|{ EVENT_LOCATION : "creates"
          EVENT }|--|{ EVENT_TYPES : "contains"
          EVENT }|--|{ EVENT_STATUS : "contains"
          EVENT }|--|| EVENT_GUARDIAN : "uses"
          EVENT }|--|{ EVENT_LOCATION : "contains"
          EVENT }|--|| EVENT_TYPES : "uses"
          EVENT }|--|| EVENT_STATUS : "uses"
          EVENT }|--|| GUARDIAN_ADDRESS : "uses"
          EVENT }|--|| GUARDIAN_TYPE : "uses"
          EVENT_LOCATION }|--|| GUARDIAN_ADDRESS : "uses"
          GUARDIAN_CHILD }|--|| GUARDIAN : "uses"
          GUARDIAN_CHILD }|--|| GUARDIAN_TYPES : "uses"
          GUARDIAN_CHILD }|--|| CHILD : "uses"
          EVENT_GUARDIAN }|--|{ EVENT : "contains"
          EVENT_GUARDIAN }|--|{ GUARDIAN : "contains"
          GUARDIAN ||--|{ EVENT : "runs"
```

## ERD 
``` mermaid
%%{init: {'theme': 'dark' } }%%

erDiagram

    guardians {
        int Id
        string user_id
        int contact_number
    }
    relationship {
        int id
        string description
    }
    child {
        int id
        int user_id
    }
    guardian_child {
        int Id
        int guardian_id
        int child_id
        int relationship_id
    }
    event {
        int id
        int address_id
        string description
    }
    event_guardian_child {
        int event_id
        int child_id
        int address_id
    }
    address {
        int Id
        string street_name
        string house_number
        string town
        string city
        string postcode
    }
    user {
        int Id
        string first_name
        string last_name
        int address_id
    }

    GUARDIANS ||--|{ GUARDIAN_CHILD: "has"
    GUARDIAN ||--|{ GUARDIAN_TYPES: "has"
    GUARDIAN ||--|{ GUARDIAN_ADDRESS: "has"
    GUARDIAN ||--|{ CHILD: "creates"
    EVENT ||--|| EVENT_LOCATION: "has"
    EVENT ||--|| EVENT_GUARDIAN: "has"
    EVENT ||--|| EVENT_TYPES: "has"
    EVENT ||--|| EVENT_STATUS: "has"
    GUARDIAN ||--|{ EVENT: "creates"
    GUARDIAN }|--|| EVENT_LOCATION: "makes"
    EVENT }|--|| CHILD : "uses"
    GUARDIAN_ADDRESS }|--|| GUARDIAN : "uses"
    EVENT }|--|| GUARDIAN_CHILD : "uses"
    EVENT }|--|| GUARDIAN_ADDRESS : "uses"

```
