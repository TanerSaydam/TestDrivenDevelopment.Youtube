# eTicaret Projesi with TDD

- [ ] Bir ürün tablom olsun
- [ ] Bu ürün kaydolurken bazý þartlardan geçsin. Mesela ismi 3 karaterdan az olamasýn, ismi unique olsun, fiyatý 0 dan büyük olsun
- [ ] Bu ürün sepete eklenirken stokta varsa eklenebilsin, eðer stokta ürün yoksa eklenemesin

## Youtube videosu
```
https://youtube.com/live/tIukiVKch3Q
```

## Postgres docker kodu
```
docker run -d --name postgredb -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=1 -e POSTGRES_DB=mydb -p 5432:5432 postgres:latest
```
