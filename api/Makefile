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

db-migrations: ## Display a list of migrations.
	$(info Display a list of migrations.)
	@cd libs/dal; dotnet ef migrations list

db-add: ## Add a new database migration for the specified name (n=name of migration).
	$(info Add a new database migration for the specified name (n=$(n)).)
	@cd libs/dal; dotnet ef migrations add $(n); code -r ./Migrations/*_$(n).cs
	@./scripts/db-migration.sh $(n);

db-update: ## Update the database with the latest migration.
	$(info Update the database with the latest migration.)
	@cd libs/dal; dotnet ef database update

db-rollback: ## Rollback to the specified database migration (n=name of migration).
	$(info Rollback to the specified database migration (n=$(n)).)
	@cd libs/dal; dotnet ef database update $(n);

db-remove: ## Remove the last database migration from source control
	$(info Remove the last database migration from source control)
	@cd libs/dal; dotnet ef migrations remove --force;

db-refresh: ## Drop and recreate the database.
	$(info Drop and recreate the database.)
	@cd libs/dal; dotnet ef database drop --force; dotnet ef database update

db-drop: ## Drop the database.
	$(info Drop the database.)
	@cd libs/dal; dotnet ef database drop --force;

db-script: ## Export an SQL script from the migration (from=0 to=Initial).
	$(info Export an SQL script from the migration (from=$(from) to=$(to)).)
	@cd libs/dal; dotnet ef migrations script ${from} ${to} --output ../../db-migration.sql

.PHONY: db-migrations db-add db-update db-rollback db-remove db-clean db-refresh db-seed db-script

##############################################################################
# Helpful commands
##############################################################################

clean: ## Clean the whole solution.
	$(info Clean the whole solution)
	@dotnet clean
	@find . -type d -name bin -prune -exec rm -rf {} \;
	@find . -type d -name obj -prune -exec rm -rf {} \;

build: ## Build the whole solution.
	$(info Build the whole solution)
	@dotnet build

.PHONY: clean build
