#!/bin/bash

# DB Migration
if ! test -f "./api/libs/dal/connectionstrings.json"; then
echo \
"{
  \"ConnectionStrings\": {
    \"DefaultConnection\": \"Server=host.docker.internal,10000;\"
  }
}" >> ./api/libs/dal/connectionstrings.json
    echo -e "\t./api/libs/dal/connectionstrings.json created"
fi

# API
if ! test -f "./api/server/connectionstrings.json"; then
echo \
"{
  \"ConnectionStrings\": {
    \"DefaultConnection\": \"Server=host.docker.internal,10000;\"
  }
}" >> ./api/server/connectionstrings.json
    echo -e "\t./api/server/connectionstrings.json created"
fi

