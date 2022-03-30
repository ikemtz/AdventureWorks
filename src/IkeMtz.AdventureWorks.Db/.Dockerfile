FROM ikemtz/sql_dacpac:latest
ENV SA_PASSWORD=SqlDockerRocks123! \
    ACCEPT_EULA=Y \
    NEW_DB_NAME=AdventureWorks

COPY ./bin/Debug/IkeMtz.AdventureWorks.Db.dacpac /dacpac/db.dacpac
RUN sqlservr & sleep 20 \
    && sqlpackage /Action:Publish /TargetServerName:localhost /TargetUser:SA /TargetPassword:$SA_PASSWORD /SourceFile:/dacpac/db.dacpac /TargetDatabaseName:$NEW_DB_NAME /p:BlockOnPossibleDataLoss=false \
    && sleep 20 \
    && pkill sqlservr && sleep 10