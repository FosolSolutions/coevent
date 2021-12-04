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

up: ## Runs the local container(s) (n=service name)
	$(info Runs the local container(s) (n=$(n)))
	@docker-compose --env-file .env --profile core up -d $(n)

down: ## Stops the local containers and removes them
	$(info Stops the local containers and removes them)
	@docker-compose --profile core --profile utility down

stop: ## Stops the local container(s) (n=service name)
	$(info Stops the local container(s) (n=$(n)))
	@docker-compose --profile core --profile utility stop $(n)

build: ## Builds the local container(s) (n=service name)
	$(info Builds the local container(s) (n=$(n)))
	@docker-compose --profile core --profile utility build --no-cache $(n)

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
