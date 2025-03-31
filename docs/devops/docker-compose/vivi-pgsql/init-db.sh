#!/bin/bash
set -e

# 使用默认连接（一般为 postgres 数据库）创建新数据库
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" <<-EOSQL
    CREATE DATABASE vivi_iotgateway;
EOSQL

# 连接到 vivi_iotgateway 数据库，创建表
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname vivi_iotgateway -f /db_backups/vivi_iotgateway.sql

echo "Database and table created successfully."