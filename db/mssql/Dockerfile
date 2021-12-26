FROM mcr.microsoft.com/mssql/rhel/server:2019-latest

RUN mkdir -p /usr/config
WORKDIR /usr/config
COPY . /usr/config

# Executable file permissions set in git
ENTRYPOINT ["./entrypoint.sh"]

EXPOSE 1433
VOLUME ["/var/opt/mssql"]
