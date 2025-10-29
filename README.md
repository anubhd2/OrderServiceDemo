OrderServiceDemo (.NET 8 + Steeltoe)

A demo microservice built with **ASP.NET Core** that integrates with **Spring Cloud Config Server** using **Steeltoe**.  
The service is also instrumented with **Prometheus** and visualized in **Grafana** for real-time metrics.

Architecture

        ┌──────────────────────────┐
        │   Spring Config Server   │
        │      (Java 21 / Maven)   │
        └──────────┬───────────────┘
                   │ REST (port 8888)
                   ▼
          ┌──────────────────────┐
          │ .NET Order Service   │
          │  Steeltoe Config +   │
          │  Prometheus Metrics  │
          └──────────┬───────────┘
                     │
         ┌───────────▼────────────┐
         │ Prometheus + Grafana   │
         │  Metrics + Dashboard   │
         └────────────────────────┘

   ********* Tech Stack***********

| Component | Description |
|------------|-------------|
| **Spring Boot 3.5.7** | Base framework for the Config Server |
| **Spring Cloud Config** | Serves configuration over REST endpoints |
| **Java 21 (Eclipse Adoptium)** | Runtime |
| **Maven 3.9.11** | Build automation |
| **Git (Local Repo)** | Configuration source backend |
| **Steeltoe (.NET)** | .NET client consuming configuration |
| **Prometheus + Grafana** | Monitoring ecosystem |

**************How to Run********************

1.Start Config Server (Java) : mvn spring-boot:run and Visit http://localhost:8888/orderservice/default
2. run OrderServiceDemo
3.Start Prometheus + Grafana (via Docker) docker-compose up -d and 
4. open Grafana http://localhost:3000
5.Once running, visit:
 *Prometheus: http://localhost:9090
 *Metrics endpoint: http://localhost:5145/metrics
 *Grafana dashboards: visualize CPU, request latency, and uptime

*********** what I achieved*********
Integrated Steeltoe Config Server support
Health, Refresh, and Metrics Actuators
Prometheus scraping + Grafana visualization
Demonstrates cloud-native configuration & observability setup

************My next target to add********** 
Service discovery (via Eureka or Consul)
Circuit breaker (Resilience4J or Polly)
Logging aggregation (ELK / Seq)

