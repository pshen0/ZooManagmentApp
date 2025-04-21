# ZooManagmentApp
=

Реализация функциональности
=
1. Контроллеры REST API
В проекте реализованы следующие контроллеры в слое представления (Presentation):
Контроллер животных AnimalsViewController (api/animals):
GET: получить всех животных
POST: добавить животное
DELETE: удалить животное по ID

Контроллер вольеров EnclosureViewController (api/enclosures):
GET: получить все вольеры
POST: добавить вольер
DELETE: удалить вольер по ID

Контроллер расписания кормления FeedingScheduleViewController (api/feedings):
GET: получить все расписания кормления
POST: добавить новое расписание

2. Тестирование через Swagger
Через интерфейс Swagger были протестированы следующие сценарии:

Добавление сущностей:
Животное (POST /api/animals)
Вольер (POST /api/enclosures)
Расписание кормления (POST /api/feedings)

Получение информации:
О животных (GET /api/animals)
О вольерах (GET /api/enclosures)
О расписаниях кормления (GET /api/feedings)

Выполнение операций:
Кормление реализовано через FeedingOrganizationService
Перемещение реализовано через AnimalTransferService

Архитектура проекта
=
Использованная структура по Clean Architecture:
Domain Layer
-
Animal, Enclosure, FeedingSchedule, AnimalMovedEvent, FeedingEvent
Расположено в: ZooManagmentApp.Domain

Application Layer
-
Интерфейсы репозиториев: IAnimalRepository, IEnclosureRepository, IFeedingScheduleRepository
Сервисы: AnimalTransferService, FeedingOrganizationService, ZooStatisticsService
Расположено в: ZooManagmentApp.Application

Infrastructure Layer
-
Реализации репозиториев в памяти: InMemoryAnimalRepository, InMemoryEnclosureRepository, InMemoryFeedingScheduleRepository
Расположено в: ZooManagmentApp.Infrastructure

Presentation Layer
-
Контроллеры API: AnimalsViewController, EnclosureViewController, FeedingScheduleViewController
Расположено в: ZooManagmentApp.Presentation

Domain-Driven Design
=

1. Entity:	Объекты с уникальным идентификатором и жизненным циклом	(Animal, Enclosure, FeedingSchedule)
2. Value Object (Gender, HealthStatus)
3. Aggregate Root:	Контролирует инварианты агрегата и управляет доступом к вложенным сущностям	(Animal, Enclosure)
4. Domain Service (AnimalTransferService, FeedingOrganizationService, ZooStatisticsService)
5. Domain Event:	События, возникающие в домене (AnimalMovedEvent, FeedingEvent)
6. Repository:	Абстракция доступа к хранилищу	(IAnimalRepository, IEnclosureRepository, IFeedingScheduleRepository)

Хранилище данных
=
Данные хранятся в памяти (in-memory) через классы InMemoryAnimalRepository, InMemoryEnclosureRepository, InMemoryFeedingScheduleRepository, что соответствует требованию

Принципы SOLID
=
Single Responsibility - Каждый класс отвечает только за одну задачу (например, FeedingOrganizationService — только за кормление)
Open/Closed - Через интерфейсы можно внедрить новые реализации репозиториев
Liskov Substitution - Все репозитории следуют контракту и могут быть заменены
Interface Segregation - Интерфейсы не перегружены, узконаправленные
Dependency Inversion - Сервисы и контроллеры зависят от абстракций, а не от конкретных классов