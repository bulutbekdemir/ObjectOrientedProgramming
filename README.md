# A Basic User Registiration App

A basic windows-only user registiration application.   

# UML Diagrams

```mermaid
classDiagram
    class Record {
        <<abstract>>
        + Guid Uuid : Readonly
        + DateTime CreatedAt : Readonly
        + DateTime ModifiedAt 

        # Modified()  Changes Modified At 
    }

    class User {
        
    }

    class Student {

    }

    Record <|-- User
    User <|-- Student 
```

---
| .NET Framework 4.7.2 |
----

Copyright 2026 Bulut BEKDEMIR \
SPDX-License-Identifier: Apache-2.0