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

# Keycloak
if ! test -f "./auth/keycloak/.env"; then
echo \
"PROXY_ADDRESS_FORWARDING=true
KEYCLOAK_USER=$varDbUser
KEYCLOAK_PASSWORD=$varPassword
KEYCLOAK_IMPORT="/tmp/realm-export.json -Dkeycloak.profile.feature.scripts=enabled -Dkeycloak.profile.feature.upload_scripts=enabled"
KEYCLOAK_LOGLEVEL=WARN
ROOT_LOGLEVEL=WARN

DB_VENDOR=mssql
DB_ADDR=database
DB_PORT=1433
DB_DATABASE=$varAuthDbName
DB_USER=$varDbUser
DB_PASSWORD=$varPassword" >> ./auth/keycloak/.env
    echo -e "\t./auth/keycloak/.env created"
fi

# API
if ! test -f "./api/.env"; then
echo \
"DB_NAME=$varDbName
DB_USER=$varDbUser
DB_PASSWORD=$varPassword" >> ./api/.env
    echo -e "\t./api/.env created"
fi

# APP
if ! test -f "./app/.env"; then
echo \
"NODE_ENV=development
CHOKIDAR_USEPOLLING=true" >> ./app/.env
    echo -e "\t./app/.env created"
fi

# DB Migration
if ! test -f "./api/libs/dal/.env"; then
echo \
"DB_NAME=$varDbName
DB_USER=$varDbUser
DB_PASSWORD=$varPassword" >> ./api/libs/dal/.env
    echo -e "\t./api/libs/dal/.env created"
fi

