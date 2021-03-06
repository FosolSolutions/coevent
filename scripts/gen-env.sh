#!/bin/bash

. ./scripts/variables.sh

# Docker Compose
if ! test -f "./.env"; then
echo \
"DATABASE_PORT=10000
KEYCLOAK_PORT=10001
API_HTTP_PORT=10002
API_HTTPS_PORT=10003
APP_HTTP_PORT=10004
APP_HTTPS_PORT=10005" >> ./.env
    echo -e "\t./.env created"
fi

# Database
if ! test -f "./db/mssql/.env"; then
echo \
"ACCEPT_EULA=Y
MSSQL_PID=Developer
TZ=America/Los_Angeles
TIMEOUT_LENGTH=120

MSSQL_SA_PASSWORD=$varPassword
DB_NAME=$varDbName
DB_USER=$varDbUser
DB_PASSWORD=$varPassword

AUTH_DB_NAME=$varAuthDbName" >> ./db/mssql/.env
    echo -e "\t./db/mssql/.env created"
fi

# API
if ! test -f "./api/.env"; then
echo \
"# API
# Uncomment ASPNETCORE_URLS if you want to run outside of docker.
# ASPNETCORE_URLS=http://localhost:10002
ASPNETCORE_ENVIRONMENT=Development
BaseUrl=/api
Cors__WithOrigins=http://localhost:10004 https://localhost:10004 http://localhost:3000 https://localhost:3000

# Seq
SEQ_API_INGESTION_URL=http://host.docker.internal:10007

# Authentication
Authentication__Issuer=localhost:10002
Authentication__Audience=localhost:10002
Authentication__PrivateKey=$varPassword
Authentication__SaltLength=50

# Database
ConnectionStrings__DefaultConnection=Server=host.docker.internal,10000;
DB_NAME=$varDbName
DB_USER=$varDbUser
DB_PASSWORD=$varPassword" >> ./api/.env
    echo -e "\t./api/.env created"
fi

# APP
if ! test -f "./app/.env"; then
echo \
"# PORT=10004
NODE_ENV=development
CHOKIDAR_USEPOLLING=true
WDS_SOCKET_PORT=10004
PUBLIC_URL=/
BROWSER=none

# Container
# API_URL=http://api-editor:80

# Local
# API_URL=http://localhost:10002
" >> ./app/.env
    echo -e "\t./app/.env created"
fi

# DB Migration
if ! test -f "./api/libs/dal/.env"; then
echo \
"DB_NAME=$varDbName
DB_USER=$varDbUser
DB_PASSWORD=$varPassword

DEFAULT_PASSWORD=$varUserPassword
SALT_LENGTH=50" >> ./api/libs/dal/.env
    echo -e "\t./api/libs/dal/.env created"
fi

# Seq Logging
if ! test -f "./tools/seq/.env"; then
echo \
"ACCEPT_EULA=Y
# SEQ_FIRSTRUN_ADMINUSERNAME=$varDbUser
# SEQ_FIRSTRUN_ADMINPASSWORDHASH=
SEQ_API_INGESTIONPORT=5341" >> ./tools/seq/.env
    echo -e "\t./tools/seq/.env created"
fi
