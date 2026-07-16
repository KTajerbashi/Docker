# 🐳 Docker - Complete Guide (Zero to Hero)

> A complete Docker tutorial for Developers, DevOps Engineers, and Software Architects.

---

# 📚 Table of Contents

- What is Docker?
- Why Docker?
- Problems Before Docker
- Virtual Machine vs Docker
- Docker Architecture
- Docker Components
- Docker Installation
- Docker Images
- Docker Containers
- Docker Registry
- Docker Hub
- Docker CLI
- Docker Networking
- Docker Volumes
- Docker Bind Mount
- Docker Compose
- Dockerfile
- Multi Stage Build
- Docker Logs
- Docker Environment Variables
- Docker Secrets
- Docker Health Check
- Docker Resource Limitation
- Docker Security
- Docker Swarm
- Docker Best Practices
- Useful Docker Commands
- Troubleshooting
- References

---

# 🐳 What is Docker?

Docker is an open-source platform that allows developers to package applications and all their dependencies into lightweight, portable containers.

A Docker container includes:

- Application Source Code
- Runtime
- Libraries
- System Tools
- Configuration Files

Because everything is packaged together, the application behaves the same in Development, Testing and Production.

---

# ❓ Why Docker?

Docker solves one of the biggest software development problems:

> "It works on my machine."

Without Docker:

- Different Operating Systems
- Different Library Versions
- Different Runtime Versions
- Different Configurations

can all cause application failures.

Docker guarantees consistency.

---

# 😓 Problems Before Docker

Before Docker developers usually had problems like:

- Dependency conflicts
- Environment mismatch
- Manual deployment
- Long setup times
- Difficult scaling
- Version inconsistency

Example:

Developer Machine

.NET 10

↓

Test Server

.NET 9

↓

Production

.NET 8

Application crashes because of different environments.

---

# 🖥 Virtual Machine vs Docker

| Virtual Machine | Docker |
|----------------|---------|
| Includes Full OS | Shares Host OS |
| Heavy | Lightweight |
| Slow Startup | Fast Startup |
| GB Size | MB Size |
| Hypervisor Required | Docker Engine |
| More RAM | Less RAM |

Docker starts containers in seconds.

Virtual Machines may take several minutes.

---

# 🏗 Docker Architecture

Docker consists of three major parts.

```
Docker Client
      │
      ▼
Docker Engine
      │
      ▼
Containers
```

Docker Engine includes:

- Docker Daemon
- REST API
- Docker CLI

---

# 📦 Docker Components

- Docker Engine
- Docker CLI
- Docker Daemon
- Docker Image
- Docker Container
- Docker Registry
- Docker Hub
- Docker Network
- Docker Volume

---

# 💻 Docker Installation

Windows

- Docker Desktop
- WSL2
- Hyper-V

Linux

- Docker Engine
- Docker CLI

MacOS

- Docker Desktop

Verify Installation

```bash
docker --version

docker info

docker ps
```

---

# 🖼 Docker Image

Image is a read-only template used to create containers.

Examples

- nginx
- redis
- postgres
- mysql
- ubuntu

Useful Commands

```bash
docker images

docker pull nginx

docker rmi nginx
```

---

# 📦 Docker Container

Container is a running instance of an Image.

Useful Commands

```bash
docker run nginx

docker ps

docker ps -a

docker stop

docker start

docker restart

docker rm
```

---

# 🌍 Docker Registry

A Registry stores Docker Images.

Popular Registries

- Docker Hub
- Azure Container Registry
- AWS ECR
- GitHub Container Registry
- Google Artifact Registry

---

# ☁ Docker Hub

Docker Hub is the largest public Docker Registry.

Examples

```bash
docker pull nginx

docker pull redis

docker push myimage
```

---

# 🛠 Docker CLI

Common Commands

```bash
docker version

docker info

docker images

docker ps

docker run

docker exec

docker logs

docker inspect

docker rm

docker rmi
```

---

# 🌐 Docker Networking

Docker provides multiple network drivers.

- Bridge
- Host
- None
- Overlay
- Macvlan

Commands

```bash
docker network ls

docker network create

docker network inspect

docker network rm
```

---

# 💾 Docker Volumes

Volumes are used for persistent storage.

Commands

```bash
docker volume ls

docker volume create

docker volume inspect

docker volume rm
```

---

# 📁 Bind Mount

Bind Mount maps a host directory directly into a container.

Example

```bash
docker run -v C:\Data:/app/data
```

---

# 📄 Dockerfile

Dockerfile defines how an image is built.

Example

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release

ENTRYPOINT ["dotnet","MyApp.dll"]
```

---

# 🚀 Multi Stage Build

Used to reduce image size.

Advantages

- Smaller Images
- Faster Deployment
- Better Security

---

# 📦 Docker Compose

Docker Compose manages multiple containers.

Example

```yaml
services:

  sqlserver:

  redis:

  webapi:

  angular:
```

Commands

```bash
docker compose up

docker compose down

docker compose build
```

---

# 📜 Docker Logs

```bash
docker logs

docker logs -f

docker logs --tail 100
```

---

# ⚙ Environment Variables

```bash
docker run -e ConnectionStrings__Default=...
```

---

# 🔐 Docker Secrets

Used for storing:

- Passwords
- API Keys
- Certificates
- Tokens

without hardcoding them.

---

# ❤️ Health Check

Docker can automatically verify application health.

Example

```dockerfile
HEALTHCHECK CMD curl http://localhost
```

---

# ⚡ Resource Limitation

Limit CPU

```bash
--cpus="2"
```

Limit Memory

```bash
--memory="512m"
```

---

# 🔒 Docker Security

Best Practices

- Don't run as Root
- Use Official Images
- Keep Images Updated
- Scan Vulnerabilities
- Minimize Layers
- Use Multi Stage Builds

---

# 🚢 Docker Swarm

Docker Swarm provides container orchestration.

Features

- Scaling
- Load Balancing
- High Availability
- Rolling Updates

---

# ✅ Docker Best Practices

- Use Official Images
- Keep Images Small
- Use Multi Stage Build
- Use .dockerignore
- Avoid Running as Root
- Pin Image Versions
- Remove Unnecessary Packages
- Store Secrets Securely
- Monitor Containers
- Use Health Checks

---

# 📖 Useful Docker Commands

```bash
docker version

docker info

docker images

docker image ls

docker pull

docker push

docker build

docker run

docker stop

docker start

docker restart

docker rm

docker rmi

docker exec

docker logs

docker inspect

docker network ls

docker volume ls

docker compose up

docker compose down

docker system prune
```

---

# 🛠 Troubleshooting

## Port Already Allocated

```bash
docker ps
```

---

## Container Exited Immediately

```bash
docker logs <container>
```

---

## Remove Unused Resources

```bash
docker system prune -a
```

---

## Remove Dangling Images

```bash
docker image prune
```

---

# 📚 Learning Roadmap

1. Docker Basics
2. Docker Images
3. Docker Containers
4. Docker Networking
5. Docker Volumes
6. Docker Compose
7. Dockerfile
8. Multi Stage Build
9. Docker Security
10. Docker Swarm
11. Docker Best Practices

---

# 📖 References

- Docker Official Documentation
- Docker Hub
- Docker CLI Reference
- Docker Compose Documentation

---

# ⭐ Support

If you find this repository helpful, please give it a ⭐ on GitHub.

Happy Coding! 🚀
