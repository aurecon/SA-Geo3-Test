FROM mcr.microsoft.com/dotnet/sdk:8.0 as build-env

ARG NUGET_USERNAME
ARG NUGET_PASSWORD

RUN dotnet nuget add source "https://gitlab.aurecongroup.com/api/v4/projects/714/packages/nuget/index.json" --name "Aurecon Package Manager" --username $DEPLOY_USERNAME --password $DEPLOY_PASSWORD --store-password-in-clear-text

WORKDIR /src
COPY . .
RUN dotnet restore --use-current-runtime
RUN dotnet publish --use-current-runtime --self-contained false --no-restore -o /publish

FROM mcr.microsoft.com/dotnet/runtime:8.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .