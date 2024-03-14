# EJECUTAR DOCKERFILE

```bash
docker build -t dockerizando -f Dockerfile .
docker run -d -p 8080:8080 --name SICEI dockerizando
```