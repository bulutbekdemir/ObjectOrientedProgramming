# A Basic User Registiration App

A basic windows-only user registiration application.   

## UML Diagrams

```mermaid
classDiagram
    class Record {
        <<abstract>>
        +Guid Uuid
        +DateTime CreatedAt
        +DateTime ModifiedAt
        #Modified()
    }

    class User {
        +string Id
        +string Name
        +string Surname
        +string PhoneNumber
        +string AddressOther
        +ChangeName(name: string, surname: string)
        +ChangeAddress(city: City, district: District, addressOther: string)
    }

    class Student {
        +int Class
        +string Number
        +DateTime Birthday
        +ChangeClass(newClass: int)
        +ChangeNumber(number: string)
    }

    class Gender {
        <<enumeration>>
        Male
        Woman
        NonBinary
    }

    class City {
        +int Id
        +string Name
        +List~District~ Districts
    }

    class District {
        +int Id
        +string Name
    }

    Record <|-- User
    User <|-- Student
    
    User --> Gender : Gender
    User --> City : City
    User --> District : District
    
    Student --> City : BirthCity
    Student --> District : BirthDistrict
    
    City "1" *-- "*" District : contains

```

## To-Do
There is a lot of but most importants are:
-  DB Connections 
-  More Data Controls
-  Unit Tests

---
### AI DISCLAIMER

AI tools used to generate and refactor some of code snippets in this project.

---
| .NET Framework 4.7.2 |
----

Copyright 2026 Bulut BEKDEMIR \
SPDX-License-Identifier: Apache-2.0