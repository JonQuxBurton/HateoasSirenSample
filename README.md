# HATEOAS Siren Sample

In this sample a Customer can have a PhoneLine added. Once they have a PhoneLine they can then have Broadband added. Once they have Broadband they can have a Static IP added.
This workflow is controlled by the server and clients can follow it using the HATEOAS links provided.

Based on https://github.com/migrap/Migrap.AspNetCore.Hateoas.

## Walkthrough
(Note the Ids are generated afresh on each run)

---

Get the site root:
```
curl http://localhost:55877 -H "Accept: application/vnd.siren+json"
```
---

Follow the link to the Customers (action [getCustomers])
```
curl http://localhost:55877/customers -H "Accept: application/vnd.siren+json"
```
---

Follow the link to the Customer Bob's Books
```
curl http://localhost:55877/customers/60c70bda-d40b-4ca5-9a60-d4ed7c95e7a0 -H "Accept: application/vnd.siren+json"
```
The actions available are:

[add phoneline]

---

Add a PhoneLine (action [add phoneline])
```
curl -X POST http://localhost:55877/customers/60c70bda-d40b-4ca5-9a60-d4ed7c95e7a0/phonelines -H "Accept: application/vnd.siren+json" -d {}
```
---

Reload Customer Bob's Books
```
curl http://localhost:55877/customers/60c70bda-d40b-4ca5-9a60-d4ed7c95e7a0 -H "Accept: application/vnd.siren+json"
```
Now the actions available are: 

[delete phoneline]

[add broadband]

---

Add Broadband (action [add broadband])
```
curl -X POST http://localhost:55877/customers/60c70bda-d40b-4ca5-9a60-d4ed7c95e7a0/broadbands?phoneLineId=d7f83dfb-001d-4b62-a556-571a4beacc31 -H "Accept: application/vnd.siren+json" -d {}
```
---

Reload Customer Bob's Books
```
curl http://localhost:55877/customers/60c70bda-d40b-4ca5-9a60-d4ed7c95e7a0 -H "Accept: application/vnd.siren+json"
```
Now the actions available are: 

[delete phoneline]

[delete broadband]

[add static ip]

---

Add a Static IP (action [add static ip])
```
curl -X POST http://localhost:55877/customers/60c70bda-d40b-4ca5-9a60-d4ed7c95e7a0/staticips -H "Accept: application/vnd.siren+json" -d {}
```
---

Reload Customer Bob's Books

Now the actions available are: 

[delete phoneline]

[delete broadband]

[add delete static ip]
