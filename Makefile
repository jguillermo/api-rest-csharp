.DEFAULT_GOAL := help

## GENERAL ##
OWNER 			= getmin
SERVICE_NAME 	= democsharp

## DEPLOY ##
DATE_NOW        := $(shell date +%y%m%d_%H%M%S)
ENV 			?= dev

## RESULT_VARS ##
PROJECT_NAME	         = $(OWNER)-$(ENV)-$(SERVICE_NAME)
export CONTAINER_NAME 	 = $(PROJECT_NAME)_backend
export IMAGE_DEV		 = $(PROJECT_NAME):dev

export CONTAINER_DB_NAME = $(PROJECT_NAME)_db

export IMAGE_CLI		 = $(PROJECT_NAME):cli
export CONTAINER_CLI 	 = $(PROJECT_NAME)_cli


## Init container Commons ##
build: ## build image to dev: make build
	docker build -f container/dev/Dockerfile -t $(IMAGE_DEV) .

build-cli: ## build image to dev: make build
	docker build -f container/cli/Dockerfile -t $(IMAGE_CLI) .

generate-date: ## build image to dev: make build
	@echo ${DATE_NOW}
	
start: ## up docker containers: make up
	make build
	docker rm -f $(CONTAINER_NAME) || true
	docker-compose -f container/docker-compose.yml run -p 8080:80 --name $(CONTAINER_NAME) -d backend
	
migrate-create: ## up docker containers: make up
	make build-cli
	docker-compose -f container/docker-compose.yml run -v $(PWD)/application/Migrations:/src/application/Migrations --rm cli dotnet ef migrations add Migration_${DATE_NOW}

migrate-ejecute: ## up docker containers: make up
	make build-cli
	docker-compose -f container/docker-compose.yml run --rm cli dotnet ef database update

dump: ## Execute migrate : make migrate
	docker exec $(CONTAINER_DB_NAME) /tmp/dump.sh
	
ssh: ## Connect to container for ssh protocol : make ssh
	docker exec -it $(CONTAINER_NAME) sh

log: ## Show container logs make : make log
	#docker-compose -f container/docker-compose.yml logs -f backend
	docker logs -f $(CONTAINER_NAME)

## Tools docker##
docker-kill: ## Execute migrate : make migrate
	docker rm -f $$(docker ps -aq)

docker-rmi-dangling: ## Execute migrate : make migrate
	docker rmi $$(docker images -qf "dangling=true")

## Target Help ##
help:
	@printf "\033[31m%-16s %-59s %s\033[0m\n" "Target" "Help" "Usage"; \
	printf "\033[31m%-16s %-59s %s\033[0m\n" "------" "----" "-----"; \
	grep -hE '^\S+:.*## .*$$' $(MAKEFILE_LIST) | sed -e 's/:.*##\s*/:/' | sort | awk 'BEGIN {FS = ":"}; {printf "\033[32m%-16s\033[0m %-58s \033[34m%s\033[0m\n", $$1, $$2, $$3}'
