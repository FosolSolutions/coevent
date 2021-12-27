#!/bin/bash

varDbUser=$(grep -Po 'DB_USER=\K.*$' ./db/mssql/.env)
if [ -z "$varDbUser" ]
then
    echo 'Enter a username for the database.'
    read -p 'Username: ' varDbUser
else
    echo "Database username: $varDbUser"
fi

varPassword=$(grep -Po 'DB_PASSWORD=\K.*$' ./db/mssql/.env)
if [ -z "$varPassword" ]
then
  # Generate a random password that satisfies password requirements.
  echo 'A password is randomly being generated.'
  varPassword=$(date +%s | sha256sum | base64 | head -c 29)A8!
  echo "Database generated password is: $varPassword"
else
  echo "Database password is: $varPassword"
fi

varUserPassword=$(grep -Po 'DEFAULT_PASSWORD=\K.*$' ./api/libs/dal/.env)
if [ -z "$varUserPassword" ]
then
  echo 'Enter a password for the default admin user account.'
  read -p 'Password: ' varUserPassword
else
  echo "Application admin password is: $varUserPassword"
fi

varDbName=coevent
varAuthDbName=keycloak
