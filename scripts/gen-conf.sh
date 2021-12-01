# DB Migration
if ! test -f "./api/libs/dal/connectionstrings.json"; then
echo \
"{
  \"ConnectionStrings\": {
    \"DefaultConnection\": \"Server=localhost,10000;\"
  }
}" >> ./api/libs/dal/connectionstrings.json
    echo -e "\t./api/libs/dal/connectionstrings.json created"
fi

# API
if ! test -f "./api/connectionstrings.json"; then
echo \
"{
  \"ConnectionStrings\": {
    \"DefaultConnection\": \"Server=localhost,10000;\"
  }
}" >> ./api/connectionstrings.json
    echo -e "\t./api/connectionstrings.json created"
fi

