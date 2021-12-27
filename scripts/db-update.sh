#!/bin/bash

cd api/libs
docker build -t ce:db-migration -f Dockerfile.dal .
docker run --env-file=dal/.env --name ce-db-migration ce:db-migration
# docker exec -it ce-db-migration bash -c "dotnet ef database update -v"
# docker stop ce-db-migration
docker rm ce-db-migration -f
