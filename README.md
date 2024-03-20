# EJECUTAR DOCKERFILE

```bash
docker build -t dockerizando -f Dockerfile .
docker run -d -p 8080:8080 --name SICEI dockerizando
```

# CREAR IMAGEN EN JENKINS

```bash
build_number=${BUILD_NUMBER}
GIT_BRANCH=$(echo $GIT_BRANCH | sed 's/origin\///')
branch_name=${GIT_BRANCH}

sudo docker build -t sicei-$branch_name:1.0.0-$build_number -f Dockerfile .

sudo docker image ls
```