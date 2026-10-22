# petBlog

Навчальний пет-проєкт: простий блог на **Angular** (frontend) та **ASP.NET Core Web API** (backend). Метою є вивчення зв'язки Angular + ASP.NET Core на прикладі CRUD-операцій над постами.

## Стек

- Backend: ASP.NET Core 8 Web API, EF Core, SQLite, Swagger
- Frontend: Angular (standalone-компоненти), HttpClient

## Структура

```
petBlog/
├── backend/    # ASP.NET Core Web API (Blog.sln)
└── frontend/   # Angular-застосунок
```

## Запуск

**Backend** (з папки `backend/Blog.Api`):

```bash
dotnet ef database update
dotnet run
```

Swagger відкривається за адресою з консолі, зазвичай `https://localhost:<порт>/swagger`.

**Frontend** (з папки `frontend`):

```bash
npm install
ng serve
```

Застосунок буде доступний на `http://localhost:4200`.

## План

- [x] Створити структуру проєкту
- [ ] Backend: CRUD для Post
- [ ] Frontend: список постів
- [ ] Перегляд, створення, редагування, видалення
- [ ] Пошук і пагінація, теги, коментарі, авторизація