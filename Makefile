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

.PHONY: setup

##############################################################################
# Docker Development
##############################################################################

up: ## Runs the local containers (n=service name)
	$(info Running client and server...)
	@docker-compose --env-file .env --profile core up -d $(n)

down: ## Stops the local containers and removes them
	$(info Stopping client and server...)
	@docker-compose down

stop: ## Stops the local containers (n=service name)
	$(info Stopping client and server...)
	@docker-compose stop $(n)

build: ## Builds the local containers (n=service name)
	$(info Building images...)
	@docker-compose build --no-cache $(n)

restart: ## Restart local docker container (n=service name)
	$(info Restart local docker container)
	@make stop n=$(n)
	@make up n=$(n)

refresh: ## Build the local contains (n=service name) and then start them after building
	$(info Build and restart local docker container)
	@make stop n=$(n)
	@make build n=$(n)
	@make up n=$(n)

refresh-npm: ## Cleans and rebuilds the app.  This is useful when npm packages are changed.
	@make clean-npm; make refresh n=app;

clean: ## Removes all local containers, images, volumes, etc
	$(info Removing all containers, images, volumes for solution.)
	@docker-compose rm -f -v -s
	@docker volume rm -f ce-app-node-cache
	@docker volume rm -f ce-database-data
	@docker volume rm -f ce-seq-data

clean-npm: ## Removes local containers, images, volumes, for app application.
	$(info Removing app containers and volumes.)
	@docker-compose stop app
	@docker-compose rm -f -v -s app
	@docker volume rm -f ce-app-node-cache

.PHONY: local up down stop build restart refresh clean clean-npm refresh-npm

##############################################################################
# Utilities
##############################################################################

hash: ## Generate a hash (v={value})
	$(info Generate a hash (v=$(v)))
	@./scripts/gen-hash.sh $(v)

.PHONY: hash
