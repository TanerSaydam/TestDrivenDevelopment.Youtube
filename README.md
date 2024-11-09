# eTicaret Projesi with TDD

- [ ] Bir �r�n tablom olsun
- [ ] Bu �r�n kaydolurken baz� �artlardan ge�sin. Mesela ismi 3 karaterdan az olamas�n, ismi unique olsun, fiyat� 0 dan b�y�k olsun
- [ ] Bu �r�n sepete eklenirken stokta varsa eklenebilsin, e�er stokta �r�n yoksa eklenemesin



## Postgres docker kodu
```
docker run -d --name postgredb -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=1 -e POSTGRES_DB=mydb -p 5432:5432 postgres:latest
```