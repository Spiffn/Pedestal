#!/bin/bash
cat ascii-art.txt
printf "\n"

msbuild lib

docker-compose build
docker-compose up
