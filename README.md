# DemoExam2026 — авторизация обувного магазина

WinForms-приложение на .NET 8 с EF Core и MySQL. SQLite не используется.

## Подготовка базы

Целевая база — `db_u75_p18` на MySQL-сервере `5.129.243.76:3302`. Скрипт [database/setup.sql](database/setup.sql) создаёт таблицу `Users` и учебную учётную запись `user` / `user` с ролью `AuthorizedClient`.

Текущая учётная запись MySQL не имеет права `CREATE TABLE`; список её разрешений — `SELECT`, `INSERT`, `UPDATE`, `DELETE`. Поэтому владелец базы или администратор должен один раз выполнить `database/setup.sql`. После этого приложение сможет проверять логин и пароль.

## Строка подключения

Приложение читает строку подключения из переменной окружения `DEMOEXAM2026_MYSQL_CONNECTION_STRING`. Установите её локально в Visual Studio или в терминале перед запуском. Не сохраняйте пароль в исходниках и не отправляйте его в Git.

Формат строки: `Server=<host>;Port=<port>;Database=<database>;User=<user>;Password=<password>;`.

## Запуск в Windows

Откройте `DemoExam2026.csproj` в Visual Studio 2022 с установленной поддержкой .NET 8 Desktop Development либо выполните:

```powershell
dotnet restore
dotnet run
```

MySQL-провайдер EF Core — `Pomelo.EntityFrameworkCore.MySql` версии 8.0.3.
