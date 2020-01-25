FROM mcr.microsoft.com/dotnet/core/sdk:3.1
RUN dotnet tool install -g dotnet-ef --version 3.1.0
COPY ./catalog /Catalog
COPY ./lib/bin/Debug/netstandard2.0/lib.dll /Catalog/lib/bin/Debug/netstandard2.0/
WORKDIR /Catalog
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh