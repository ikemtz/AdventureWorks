FROM ikemtz/sql_dacpac:latest
ENV SA_PASSWORD=SqlDockerRocks123! \ 
    ACCEPT_EULA=Y 
ENV ASPNETCORE_ENVIRONMENT=development
ENV DbConnectionString="Server=.;Database=AdventureWorks;User ID=sa;Password=SqlDockerRocks123!;"
COPY src/IkeMtz.AdventureWorks.Db/bin/Debug/*.dacpac /dacpac/
COPY src/IkeMtz.AdventureWorks.OData.Tests/bin/Debug/net6.0/linux-x64/publish/ /odataIntegrationTests
COPY src/IkeMtz.AdventureWorks.WebApi.Tests/bin/Debug/net6.0/linux-x64/publish/ /webapiIntegrationTests
USER root

#Need ample time to allow SQL server to start (30 sec)
RUN /opt/mssql/bin/sqlservr & sleep 30 \ 
    && sqlpackage /Action:Publish /TargetServerName:localhost /TargetUser:SA /TargetPassword:$SA_PASSWORD /SourceFile:/dacpac/IkeMtz.Samples.Db.dacpac /TargetDatabaseName:SamplesDb /p:BlockOnPossibleDataLoss=false \ 
    && sleep 60 \
    && dotnet test /odataIntegrationTests/IkeMtz.AdventureWorks.OData.Tests.dll --filter TestCategory=SqlIntegration \
    && dotnet test /webapiIntegrationTests/IkeMtz.AdventureWorks.WebApi.Tests.dll --filter TestCategory=SqlIntegration \
    && pkill sqlservr