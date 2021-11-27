# Docker Compose
if ! test -f "./.env"; then
echo \
"" >> ./.env
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
DB_PASSWORD=$varPassword" >> ./db/mssql/.env
    echo -e "\t./db/mssql/.env created"
fi
