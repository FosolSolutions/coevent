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
	@sh ./scripts/variables.sh
	@sh ./scripts/gen-env.sh
	@sh ./scripts/gen-conf.sh

init: ## Initialize local environment
	@setup
	@make up p=core
	@make db-update

.PHONY: setup

##############################################################################
# Docker Development
##############################################################################

up: ## Runs the local container(s) (n=service name, p=profile name)
	$(info Runs the local container(s) (n=$(n), p=$(if $(p),$(p),all)))
	@docker-compose --profile $(if $(p),$(p),all) up $(n) -d

down: ## Stops the local containers and removes them
	$(info Stops the local containers and removes them)
	@docker-compose --profile all down

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
	@docker-compose --profile all down -v

clean-npm: ## Removes local containers, images, volumes, for app application (n=service name).
	$(info Removes local containers, images, volumes, for app application (n=$(n)))
	@make stop n=$(n)
	@docker-compose --profile all rm -f -v -s $(n)
	@docker volume rm -f ce-app-node-cache

.PHONY: local up down stop build restart refresh clean clean-npm refresh-npm

##############################################################################
# Databas Utilities
##############################################################################

db-install-cli: ## Install EF CLI
	$(info Install EF CLI)
	@dotnet tool install --global dotnet-ef

db-migrations: ## Display a list of migrations.
	$(info Display a list of migrations.)
	@cd api; make db-migrations

db-add: ## Add a new database migration for the specified name (n=name of migration).
	$(info Add a new database migration for the specified name (n=$(n)).)
	@cd api; make db-add n=$(n)

db-update: ## Update the database with the latest migration.
	$(info Update the database with the latest migration.)
	@cd api; make db-update

db-rollback: ## Rollback to the specified database migration (n=name of migration).
	$(info Rollback to the specified database migration (n=$(n)).)
	@cd api; make db-rollback n=$(n)

db-remove: ## Remove the last database migration from source control
	$(info Remove the last database migration from source control)
	@cd api; make db-remove

db-refresh: ## Drop and recreate the database.
	$(info Drop and recreate the database.)
	@cd api; make db-refresh

db-drop: ## Drop the database.
	$(info Drop the database.)
	@cd api; make db-drop

db-script: ## Export an SQL script from the migration (from=0 to=Initial).
	$(info Export an SQL script from the migration (from=$(from) to=$(to)).)
	@cd api; make db-script from=$(from) to=$(to)

.PHONY: db-install-cli db-update db-migrations db-add db-rollback db-remove db-refresh db-drop db-script

##############################################################################
# Utilities
##############################################################################

hash: ## Generate a hash (v={value})
	$(info Generate a hash (v=$(v)))
	@./scripts/gen-hash.sh $(v)

.PHONY: hash
