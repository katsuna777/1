# DemoExam2026 — авторизация обувного магазина

WinForms-приложение на .NET 8 с Entity Framework Core и локальной SQLite-базой.

## Запуск

Откройте `DemoExam2026.csproj` в Visual Studio 2022 с установленной поддержкой .NET 8 Desktop Development либо выполните:

```powershell
dotnet restore
dotnet run
```

При первом запуске приложение автоматически создаёт базу и учебную учётную запись:

- Логин: `user`
- Пароль: `user`

Файл базы хранится в `%LOCALAPPDATA%\DemoExam2026\demoexam2026.db`.
