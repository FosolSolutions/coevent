#!/bin/bash

varDbUser=$(grep -Po 'DB_USER=\K.*$' ./db/mssql/.env)
if [ -z "$varDbUser" ]
then
    echo 'Enter a username for the database.'
    read -p 'Username: ' varDbUser
else
    echo "Your database username: $varDbUser"
fi

varPassword=$(grep -Po 'DB_PASSWORD=\K.*$' ./db/mssql/.env)
if [ -z "$varPassword" ]
then
  # Generate a random password that satisfies password requirements.
  echo 'A password is randomly being generated.'
  varPassword=$(date +%s | sha256sum | base64 | head -c 29)A8!
  echo "Your generated password is: $varPassword"
else
  echo "Your password is: $varPassword"
fi

varDbName=coevent
varAuthDbName=keycloak
