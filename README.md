# Childcare
In the part of parenting, organisation of your childs day is crucial, who is caring for them, when, where and when they need collected or where theyre going next.
An application that shows a daily schedule of the childs activities, guardian present and details like location of activity, time of activity, guardians contact details etc.
With each guardian that has time with the child would have an account providing their details.

## Goals
-Simple, easy to use tool
-Manage accounts of Parents, Friends, Guardians, locations
-Provide a traceable daily Rota/timeline with ability to edit
-Ability to communicate amongst accounts with ease

## Solution
An application that provides clear information on where the child is, who theyre with and where theyre going.

## Project Outline

**MVP**

-   Create a Parent Account & Password
-   Create a Guardian
-   Create an Location
-   Create an Activity
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
          GUARDIAN ||--|| Contact Details : "creates"
          EVENT }|--|| Contact Details : "uses"
          GUARDIAN }|--|{ Contact Details : "contains"
          GUARDIAN ||--|{ Event : "runs"
```

## ERD 
``` mermaid
%%{init: {'theme': 'dark' } }%%

erDiagram
    GUARDIAN {
        int Id
        string guardian_type_id
        string first_name
        string last_name
        int contact_number
        string user_address_id
    }
    GUARDIAN_TYPE {
        int id
        string description
    }
    CHILD {
        int id
        string first_name
        string last_name
        string description
    }
    GUARDIAN_CHILD {
        int Id
        int guardian_id
        int child_id
        int guardian_type
    }
    EVENT {
        int Id
        string description
        timestamp start_time
        timestamp finish_time
        int child_id
        int event_type_id
        int event_status_id
        int created_by_id
        int event_location_id
    }
    EVENT_GUARDIAN {
        int Id
        int User_Id
        int Event_Id
    }
    GUARDIAN_ADDRESS {
        int Id
        string street_name
        string house_number
        string town
        string city
        string postcode
    }
    EVENT_TYPE {
        int Id
        string description
    }
    }
    EVENT_STATUS {
        int Id
        string description
    }
    GUARDIAN ||--|{ GUARDIAN_CHILD: "has"
    GUARDIAN ||--|{ GUARDIAN_TYPE: "has"
    GUARDIAN ||--|{ GUARDIAN_ADDRESS: "has"
    EVENT ||--|| EVENT_LOCATION: "has"
    EVENT ||--|| EVENT_GUARDIAN: "has"
    EVENT ||--|| EVENT_TYPE: "has"
    EVENT ||--|| EVENT_STATUS: "has"
    GUARDIAN_TYPE ||--|{ EVENT: "creates"
    GUARDIAN }|--|| EVENT_LOCATION: "makes"
    EVENT }|--|| CHILD : "uses"
    EVENT }|--|| GUARDIAN : "uses"
    //EVENT }|--|{ POOL : "contains"

```
