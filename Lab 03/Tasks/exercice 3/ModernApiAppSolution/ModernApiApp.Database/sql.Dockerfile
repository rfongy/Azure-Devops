# use MSSQL 2017 image on Ubuntu 16.04
FROM microsoft/mssql-server-linux:2017-latest

# set environment variables
ENV MSSQL_SA_PASSWORD=Microsoft!1
ENV ACCEPT_EULA=Y
EXPOSE 1433
EXPOSE 5434

COPY deploy/ ./scripts/

RUN chmod +x ./scripts/SqlCmdStartup.sh
RUN sed -i 's/\r$//' ./scripts/entrypoint.sh
RUN sed -i 's/\r$//' ./scripts/SqlCmdStartup.sh
CMD /bin/bash ./scripts/entrypoint.sh



