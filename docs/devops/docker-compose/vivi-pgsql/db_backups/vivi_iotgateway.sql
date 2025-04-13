/*
 Navicat Premium Data Transfer

 Source Server         : vv-localhost-postgres
 Source Server Type    : PostgreSQL
 Source Server Version : 170004 (170004)
 Source Host           : localhost:9032
 Source Catalog        : vivi_iotgateway
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 170004 (170004)
 File Encoding         : 65001

 Date: 11/04/2025 18:00:02
*/


-- ----------------------------
-- Table structure for area
-- ----------------------------
DROP TABLE IF EXISTS "public"."area";
CREATE TABLE "public"."area" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "pid" uuid,
  "name" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "code" varchar(50) COLLATE "pg_catalog"."default",
  "type" varchar(50) COLLATE "pg_catalog"."default",
  "level" int4 DEFAULT 0,
  "position" jsonb,
  "block_code" varchar(20) COLLATE "pg_catalog"."default" NOT NULL,
  "created_at" timestamp(6) DEFAULT now(),
  "updated_at" timestamp(6) DEFAULT now()
)
;
COMMENT ON COLUMN "public"."area"."id" IS '主键，唯一标识区域';
COMMENT ON COLUMN "public"."area"."pid" IS '上级区域 ID，支持树结构，如省→市→区';
COMMENT ON COLUMN "public"."area"."name" IS '区域名称，例如 “A区”、“江南办公区”';
COMMENT ON COLUMN "public"."area"."code" IS '区域编码，如 REG001，用于快速索引';
COMMENT ON COLUMN "public"."area"."type" IS '区域类型，如 “楼宇、园区、楼层、功能区” 等';
COMMENT ON COLUMN "public"."area"."level" IS '区域层级，例如：0=根区域，1=省，2=市...';
COMMENT ON COLUMN "public"."area"."position" IS '区域位置，支持坐标、GeoJSON 或多边形字符串，JSONB 格式存储';
COMMENT ON COLUMN "public"."area"."block_code" IS '行政区代码，遵循 GB/T 2260 标准';
COMMENT ON COLUMN "public"."area"."created_at" IS '创建时间';
COMMENT ON COLUMN "public"."area"."updated_at" IS '更新时间';
COMMENT ON TABLE "public"."area" IS '区域信息表，用于 GIS 与物联网模块中的区域定义';

-- ----------------------------
-- Table structure for device
-- ----------------------------
DROP TABLE IF EXISTS "public"."device";
CREATE TABLE "public"."device" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "model" int2,
  "number" varchar(100) COLLATE "pg_catalog"."default",
  "area_id" uuid,
  "manufacturer" varchar(255) COLLATE "pg_catalog"."default",
  "installation_location" jsonb,
  "status" int2 DEFAULT 0,
  "created_at" timestamp(6) DEFAULT now(),
  "updated_at" timestamp(6) DEFAULT now()
)
;
COMMENT ON COLUMN "public"."device"."id" IS '设备唯一ID，UUID';
COMMENT ON COLUMN "public"."device"."name" IS '设备名称，如中央空调、风机盘管等';
COMMENT ON COLUMN "public"."device"."model" IS '设备型号';
COMMENT ON COLUMN "public"."device"."number" IS '设备编号';
COMMENT ON COLUMN "public"."device"."area_id" IS '所属区域ID';
COMMENT ON COLUMN "public"."device"."manufacturer" IS '设备生产厂家';
COMMENT ON COLUMN "public"."device"."installation_location" IS '设备安装位置';
COMMENT ON COLUMN "public"."device"."status" IS '设备状态，如 FAIL（0）通信失败、AUDIT_PENDING（1）无效设备、EXEC_PENDING（2）未启用、EXECUTING（3）运行中、FINISH（4）生命周期结束。';
COMMENT ON COLUMN "public"."device"."created_at" IS '记录创建时间';
COMMENT ON COLUMN "public"."device"."updated_at" IS '记录更新时间';
COMMENT ON TABLE "public"."device" IS '设备表，存储建筑节能设备（如空调、风机盘管等）的基本信息';

-- ----------------------------
-- Table structure for device_unit
-- ----------------------------
DROP TABLE IF EXISTS "public"."device_unit";
CREATE TABLE "public"."device_unit" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "byname" varchar(255) COLLATE "pg_catalog"."default",
  "device_id" uuid NOT NULL,
  "unit_type" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "installation_position" varchar(255) COLLATE "pg_catalog"."default",
  "created_at" timestamp(6) DEFAULT now(),
  "updated_at" timestamp(6) DEFAULT now()
)
;
COMMENT ON COLUMN "public"."device_unit"."id" IS '设备传感器唯一ID，UUID';
COMMENT ON COLUMN "public"."device_unit"."device_id" IS '所属设备ID';
COMMENT ON COLUMN "public"."device_unit"."unit_type" IS '传感器类型，如温度传感器、压力传感器';
COMMENT ON COLUMN "public"."device_unit"."installation_position" IS '传感器安装位置';
COMMENT ON COLUMN "public"."device_unit"."created_at" IS '记录创建时间';
COMMENT ON COLUMN "public"."device_unit"."updated_at" IS '记录更新时间';
COMMENT ON TABLE "public"."device_unit" IS '设备传感器表，记录安装在设备上的传感器信息';

-- ----------------------------
-- Table structure for unit_capab
-- ----------------------------
DROP TABLE IF EXISTS "public"."unit_capab";
CREATE TABLE "public"."unit_capab" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "unit" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "description" text COLLATE "pg_catalog"."default",
  "created_at" timestamp(6) DEFAULT now(),
  "updated_at" timestamp(6) DEFAULT now()
)
;
COMMENT ON COLUMN "public"."unit_capab"."id" IS '传感器能力唯一ID，UUID';
COMMENT ON COLUMN "public"."unit_capab"."name" IS '传感器能力名称，如温度、湿度、风速等';
COMMENT ON COLUMN "public"."unit_capab"."unit" IS '传感器能力单位，如℃、%RH、m/s';
COMMENT ON COLUMN "public"."unit_capab"."description" IS '传感器能力描述';
COMMENT ON COLUMN "public"."unit_capab"."created_at" IS '记录创建时间';
COMMENT ON COLUMN "public"."unit_capab"."updated_at" IS '记录更新时间';
COMMENT ON TABLE "public"."unit_capab" IS '传感器能力表，定义传感器的测量能力，如温度、湿度等';

-- ----------------------------
-- Table structure for unit_capab_map
-- ----------------------------
DROP TABLE IF EXISTS "public"."unit_capab_map";
CREATE TABLE "public"."unit_capab_map" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "unit_id" uuid NOT NULL,
  "capab_id" uuid NOT NULL
)
;
COMMENT ON COLUMN "public"."unit_capab_map"."id" IS '传感器能力映射唯一ID，UUID';
COMMENT ON COLUMN "public"."unit_capab_map"."unit_id" IS '设备传感器ID';
COMMENT ON COLUMN "public"."unit_capab_map"."capab_id" IS '传感器能力ID';
COMMENT ON TABLE "public"."unit_capab_map" IS '传感器能力映射表，用于关联传感器和它具备的测量能力';

-- ----------------------------
-- Table structure for unit_records
-- ----------------------------
DROP TABLE IF EXISTS "public"."unit_records";
CREATE TABLE "public"."unit_records" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "unit_id" uuid NOT NULL,
  "capab_id" uuid NOT NULL,
  "value" numeric(10,2) NOT NULL,
  "timestamp" timestamp(6) DEFAULT now()
)
;
COMMENT ON COLUMN "public"."unit_records"."id" IS '传感器数据唯一ID，UUID';
COMMENT ON COLUMN "public"."unit_records"."unit_id" IS '设备传感器ID';
COMMENT ON COLUMN "public"."unit_records"."capab_id" IS '传感器能力ID';
COMMENT ON COLUMN "public"."unit_records"."value" IS '传感器采集数据值';
COMMENT ON COLUMN "public"."unit_records"."timestamp" IS '数据采集时间';
COMMENT ON TABLE "public"."unit_records" IS '传感器数据表，存储传感器的实时数据';

-- ----------------------------
-- Primary Key structure for table area
-- ----------------------------
ALTER TABLE "public"."area" ADD CONSTRAINT "area_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table device
-- ----------------------------
ALTER TABLE "public"."device" ADD CONSTRAINT "device_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table device_unit
-- ----------------------------
ALTER TABLE "public"."device_unit" ADD CONSTRAINT "device_unit_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table unit_capab
-- ----------------------------
ALTER TABLE "public"."unit_capab" ADD CONSTRAINT "unit_capab_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table unit_capab_map
-- ----------------------------
ALTER TABLE "public"."unit_capab_map" ADD CONSTRAINT "unit_capab_map_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table unit_records
-- ----------------------------
ALTER TABLE "public"."unit_records" ADD CONSTRAINT "unit_records_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Foreign Keys structure for table device
-- ----------------------------
ALTER TABLE "public"."device" ADD CONSTRAINT "device_area_id_fkey" FOREIGN KEY ("area_id") REFERENCES "public"."area" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table device_unit
-- ----------------------------
ALTER TABLE "public"."device_unit" ADD CONSTRAINT "device_unit_device_id_fkey" FOREIGN KEY ("device_id") REFERENCES "public"."device" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table unit_capab_map
-- ----------------------------
ALTER TABLE "public"."unit_capab_map" ADD CONSTRAINT "unit_capab_map_capab_id_fkey" FOREIGN KEY ("capab_id") REFERENCES "public"."unit_capab" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."unit_capab_map" ADD CONSTRAINT "unit_capab_map_unit_id_fkey" FOREIGN KEY ("unit_id") REFERENCES "public"."device_unit" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table unit_records
-- ----------------------------
ALTER TABLE "public"."unit_records" ADD CONSTRAINT "unit_records_capab_id_fkey" FOREIGN KEY ("capab_id") REFERENCES "public"."unit_capab" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."unit_records" ADD CONSTRAINT "unit_records_unit_id_fkey" FOREIGN KEY ("unit_id") REFERENCES "public"."device_unit" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
