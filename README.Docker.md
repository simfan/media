# MediaCopy on UnRaid

This deployment runs the Blazor client and API controllers in one ASP.NET Core process. The browser uses one public origin; the server-side Blazor app calls the API over the container's loopback address.

## UnRaid container settings

- Container port: `8080` (TCP)
- Host port: choose an unused port, for example `8080`
- Appdata mapping: `/mnt/user/appdata/mediacopy` to `/config` (read/write)
- Optional TMDb token: set `TMDb__BearerToken` as a container variable if online movie search is used

Build the image from this directory, or publish it to a registry and use that image in the UnRaid Docker template. The database is `/config/media.db`; EF Core migrations are applied at startup. Back up the appdata directory while the container is stopped.

The container listens on HTTP. For remote access, terminate TLS at the UnRaid reverse proxy and forward to the published host port. The app does not issue an HTTPS redirect in the container.

For local Compose use, `docker compose up --build -d` starts it on `http://localhost:8080` and persists SQLite under `./appdata`.
