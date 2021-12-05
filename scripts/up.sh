#!/bin/bash

if [ "$1" ]; then
  docker-compose --env-file .env --profile all up -d $1
else
  docker-compose --env-file .env --profile core up -d
fi
