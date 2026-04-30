#!/bin/bash
export ASPNETCORE_ENVIRONMENT=Development
# dotnet ef migrations add <MigrationName> --project "shared/FC4.HotelReservation.Shared.Infrastructure" --startup-project "src/FC4.HotelReservation.WebApi" --context HotelDbContext
dotnet ef database update --project "shared/FC4.HotelReservation.Shared.Infrastructure" --startup-project "src/FC4.HotelReservation.WebApi" --context HotelDbContext

