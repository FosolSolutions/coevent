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

.PHONY: setup

##############################################################################
# Docker Development
##############################################################################

restart: | stop build up ## Restart local docker environment

refresh: | down build up ## Recreates local docker environment

up: ## Runs the local containers (n=service name)
	$(info Running client and server...)
	@docker-compose --env-file .env up -d $(n)

down: ## Stops the local containers and removes them
	$(info Stopping client and server...)
	@docker-compose down

stop: ## Stops the local containers (n=service name)
	$(info Stopping client and server...)
	@docker-compose stop $(n)

build: ## Builds the local containers (n=service name)
	$(info Building images...)
	@docker-compose build --no-cache $(n)

rebuild: ## Build the local contains (n=service name) and then start them after building
	@make build n=$(n)
	@make up n=$(n)

clean: ## Removes all local containers, images, volumes, etc
	$(info Removing all containers, images, volumes for solution.)
	@docker-compose rm -f -v -s
	@docker volume rm -f pims-app-node-cache
	@docker volume rm -f pims-database-data

npm-clean: ## Removes local containers, images, volumes, for frontend application.
	$(info Removing frontend containers and volumes.)
	@docker-compose stop frontend
	@docker-compose rm -f -v -s frontend
	@docker volume rm -f pims-app-node-cache

npm-refresh: ## Cleans and rebuilds the frontend.  This is useful when npm packages are changed.
	@make npm-clean; make build n=frontend; make up;

.PHONY: local restart refresh up down stop build rebuild clean setup npm-clean npm-refresh
