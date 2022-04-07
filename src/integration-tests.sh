#!/bin/bash
dotnet publish IkeMtz.AdventureWorks.OData.Tests/ -r linux-x64 --no-self-contained
dotnet publish IkeMtz.AdventureWorks.WebApi.Tests/ -r linux-x64 --no-self-contained
docker build --pull --rm -f "integration-tests-ci.Dockerfile" -t adventureworks:integration . 