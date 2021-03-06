#!/usr/bin/make

SHELL := /usr/bin/env bash
.DEFAULT_GOAL := help

ifneq ($(OS),Windows_NT)
POSIXSHELL := 1
else
POSIXSHELL :=
endif

# to see all colors, run
# bash -c 'for c in {0..255}; do tput setaf $c; tput setaf $c | cat -v; echo =$c; done'
# the first 15 entries are the 8-bit colors

# define standard colors
BLACK        := $(shell tput -Txterm setaf 0)
RED          := $(shell tput -Txterm setaf 1)
GREEN        := $(shell tput -Txterm setaf 2)
YELLOW       := $(shell tput -Txterm setaf 3)
LIGHTPURPLE  := $(shell tput -Txterm setaf 4)
PURPLE       := $(shell tput -Txterm setaf 5)
BLUE         := $(shell tput -Txterm setaf 6)
WHITE        := $(shell tput -Txterm setaf 7)

RESET := $(shell tput -Txterm sgr0)

# default "prompt"
P = ${GREEN}[+]${RESET}

help:
	@grep -E '^[a-zA-Z_-]+:.*?## .*$$' Makefile | sort | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'

.PHONY: help

##############################################################################
# Docker Development
##############################################################################

setup: ## Setup and configure local environment
	$(info Setup and configure local environment)
	@sh ./scripts/gen-env.sh
	@sh ./scripts/gen-conf.sh

init: ## Initialize local environment
	$(info Initialize local environment)
	@make setup
	@make up p=core
	@make db-update

nuke: ## Destroy local environment so that you can restart from scratch.
	$(info Destroy local environment so that you can restart from scratch.)
	@make down clean
	@./scripts/nuke.sh

.PHONY: setup

##############################################################################
# Docker Development
##############################################################################

up: ## Runs the local container(s) (n=service name, p=profile name)
	$(info Runs the local container(s) (n=$(n), p=$(if $(p),$(p),all)))
	@docker-compose --profile $(if $(p),$(p),all) up $(n) -d

down: ## Stops the local containers and removes them
	$(info Stops the local containers and removes them)
	@docker-compose --profile all down -v

stop: ## Stops the local container(s) (n=service name)
	$(info Stops the local container(s) (n=$(n)))
	@docker-compose --profile all stop $(n)

build: ## Builds the local container(s) (n=service name)
	$(info Builds the local container(s) (n=$(n)))
	@docker-compose --profile all build --no-cache $(n)

restart: ## Restart local docker container(s) (n=service name)
	$(info Restart local docker container(s) (n=$(n)))
	@make stop up n=$(n)

refresh: ## Stop, build the local container(s) and then start them after building (n=service name)
	$(info Stop, build the local container(s) and then start them after building (n=$(n)))
	@make stop build up n=$(n)

refresh-npm: ## Cleans and rebuilds the app.  This is useful when npm packages are changed.
	@make clean-npm refresh n=app;

clean: ## Removes all local containers, images, volumes, etc
	$(info Removing all containers, images, volumes for solution.)
	@docker-compose --profile all down -v --rmi all

clean-npm: ## Removes local containers, images, volumes, for app application (n=service name).
	$(info Removes local containers, images, volumes, for app application (n=$(if $(n),$(n),app)))
	@make stop n=$(if $(n),$(n),app)
	@docker-compose --profile all rm -f -v -s $(if $(n),$(n),app)
	@docker volume rm -f ce-app-node-cache

.PHONY: local up down stop build restart refresh clean clean-npm refresh-npm

##############################################################################
# Databas Utilities
##############################################################################

db-update: ## Update the database with the latest migration.
	$(info Update the database with the latest migration.)
	@./scripts/db-update.sh

.PHONY: db-update

##############################################################################
# Utilities
##############################################################################

hash: ## Generate a hash (v={value})
	$(info Generate a hash (v=$(v)))
	@./scripts/gen-hash.sh $(v)

app-shell: ## Open shell in the app container
	@docker-compose -f docker-compose.yml exec app bash

db-shell: ## Open shell in the app container
	@docker-compose -f docker-compose.yml exec database bash

.PHONY: hash
