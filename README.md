# Intellias Hackaton

## Summary

To solve hackaton task I decided to store data as Graph: vertices for main entities like User, Group, Flow and Videos and edges for associations with not required Priority property set.
I had an issue and stucked at populating data via Gremlin Query Language as I didn't have experience with it before , but still good practice with new technologies ;)

Service is implemented using principles of Onion architecture, Query Handlers are implemented directly in Infrastructure layer to simplify models mapping.

## Run

To run solution following instructions can be used:

```bash
# Go into the folder with solution and run:
$ docker-compose up
```

## Notes

RabbitMq has been integrated later and shouldn't be taken to the account.