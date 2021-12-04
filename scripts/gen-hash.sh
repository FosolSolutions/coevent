#!/bin/bash

varValue=$1
if [ ! "$varValue" ]; then
  read -p "Enter value to hash: " varValue
fi

echo "seq: $(echo '$varValue' | docker run --rm -i datalust/seq:2021.3.6681-x64 config hash)"
echo "md5: $(md5sum<<<$varValue)"
echo "sha1: $(sha1sum<<<$varValue)"
echo "sha25: $(sha256sum<<<$varValue)"
