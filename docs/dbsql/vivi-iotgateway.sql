/*
 Navicat Premium Data Transfer

 Source Server         : sangu-localhost-postgres
 Source Server Type    : PostgreSQL
 Source Server Version : 170004 (170004)
 Source Host           : localhost:9032
 Source Catalog        : sangu-vivi-iotgateway
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 170004 (170004)
 File Encoding         : 65001

 Date: 27/03/2025 11:11:59
*/


-- ----------------------------
-- Table structure for sensor_capability
-- ----------------------------
DROP TABLE IF EXISTS "public"."sensor_capability";
CREATE TABLE "public"."sensor_capability" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "unit" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "description" text COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."sensor_capability"."id" IS '传感器能力唯一ID，UUID';
COMMENT ON COLUMN "public"."sensor_capability"."name" IS '传感器能力名称，如温度、湿度、风速等';
COMMENT ON COLUMN "public"."sensor_capability"."unit" IS '传感器能力单位，如℃、%RH、m/s';
COMMENT ON COLUMN "public"."sensor_capability"."description" IS '传感器能力描述';
COMMENT ON TABLE "public"."sensor_capability" IS '传感器能力表，定义传感器的测量能力，如温度、湿度等';

-- ----------------------------
-- Records of sensor_capability
-- ----------------------------

-- ----------------------------
-- Table structure for sensor_capability_map
-- ----------------------------
DROP TABLE IF EXISTS "public"."sensor_capability_map";
CREATE TABLE "public"."sensor_capability_map" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "sensor_id" uuid NOT NULL,
  "capability_id" uuid NOT NULL
)
;
COMMENT ON COLUMN "public"."sensor_capability_map"."id" IS '传感器能力映射唯一ID，UUID';
COMMENT ON COLUMN "public"."sensor_capability_map"."sensor_id" IS '设备传感器ID';
COMMENT ON COLUMN "public"."sensor_capability_map"."capability_id" IS '传感器能力ID';
COMMENT ON TABLE "public"."sensor_capability_map" IS '传感器能力映射表，用于关联传感器和它具备的测量能力';

-- ----------------------------
-- Records of sensor_capability_map
-- ----------------------------

-- ----------------------------
-- Table structure for sensor_data
-- ----------------------------
DROP TABLE IF EXISTS "public"."sensor_data";
CREATE TABLE "public"."sensor_data" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "sensor_id" uuid NOT NULL,
  "capability_id" uuid NOT NULL,
  "value" numeric(10,2) NOT NULL,
  "timestamp" timestamp(6) DEFAULT now()
)
;
COMMENT ON COLUMN "public"."sensor_data"."id" IS '传感器数据唯一ID，UUID';
COMMENT ON COLUMN "public"."sensor_data"."sensor_id" IS '设备传感器ID';
COMMENT ON COLUMN "public"."sensor_data"."capability_id" IS '传感器能力ID';
COMMENT ON COLUMN "public"."sensor_data"."value" IS '传感器采集数据值';
COMMENT ON COLUMN "public"."sensor_data"."timestamp" IS '数据采集时间';
COMMENT ON TABLE "public"."sensor_data" IS '传感器数据表，存储传感器的实时数据';

-- ----------------------------
-- Records of sensor_data
-- ----------------------------

-- ----------------------------
-- Table structure for smart_device
-- ----------------------------
DROP TABLE IF EXISTS "public"."smart_device";
CREATE TABLE "public"."smart_device" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "name" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "model" varchar(100) COLLATE "pg_catalog"."default",
  "manufacturer" varchar(255) COLLATE "pg_catalog"."default",
  "installation_location" text COLLATE "pg_catalog"."default",
  "status" varchar(50) COLLATE "pg_catalog"."default" DEFAULT 'active'::character varying,
  "created_at" timestamp(6) DEFAULT now(),
  "updated_at" timestamp(6) DEFAULT now()
)
;
COMMENT ON COLUMN "public"."smart_device"."id" IS '设备唯一ID，UUID';
COMMENT ON COLUMN "public"."smart_device"."name" IS '设备名称，如中央空调、风机盘管等';
COMMENT ON COLUMN "public"."smart_device"."model" IS '设备型号';
COMMENT ON COLUMN "public"."smart_device"."manufacturer" IS '设备生产厂家';
COMMENT ON COLUMN "public"."smart_device"."installation_location" IS '设备安装位置';
COMMENT ON COLUMN "public"."smart_device"."status" IS '设备状态，如 active（启用）、inactive（停用）、maintenance（维护）';
COMMENT ON COLUMN "public"."smart_device"."created_at" IS '记录创建时间';
COMMENT ON COLUMN "public"."smart_device"."updated_at" IS '记录更新时间';
COMMENT ON TABLE "public"."smart_device" IS '设备表，存储建筑节能设备（如空调、风机盘管等）的基本信息';

-- ----------------------------
-- Records of smart_device
-- ----------------------------

-- ----------------------------
-- Table structure for smart_device_sensor
-- ----------------------------
DROP TABLE IF EXISTS "public"."smart_device_sensor";
CREATE TABLE "public"."smart_device_sensor" (
  "id" uuid NOT NULL DEFAULT gen_random_uuid(),
  "device_id" uuid NOT NULL,
  "sensor_type" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "installation_position" varchar(255) COLLATE "pg_catalog"."default"
)
;
COMMENT ON COLUMN "public"."smart_device_sensor"."id" IS '设备传感器唯一ID，UUID';
COMMENT ON COLUMN "public"."smart_device_sensor"."device_id" IS '所属设备ID';
COMMENT ON COLUMN "public"."smart_device_sensor"."sensor_type" IS '传感器类型，如温度传感器、压力传感器';
COMMENT ON COLUMN "public"."smart_device_sensor"."installation_position" IS '传感器安装位置';
COMMENT ON TABLE "public"."smart_device_sensor" IS '设备传感器表，记录安装在设备上的传感器信息';

-- ----------------------------
-- Records of smart_device_sensor
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table sensor_capability
-- ----------------------------
ALTER TABLE "public"."sensor_capability" ADD CONSTRAINT "sensor_capability_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sensor_capability_map
-- ----------------------------
ALTER TABLE "public"."sensor_capability_map" ADD CONSTRAINT "sensor_capability_map_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table sensor_data
-- ----------------------------
ALTER TABLE "public"."sensor_data" ADD CONSTRAINT "sensor_data_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table smart_device
-- ----------------------------
ALTER TABLE "public"."smart_device" ADD CONSTRAINT "smart_device_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table smart_device_sensor
-- ----------------------------
ALTER TABLE "public"."smart_device_sensor" ADD CONSTRAINT "smart_device_sensor_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Foreign Keys structure for table sensor_capability_map
-- ----------------------------
ALTER TABLE "public"."sensor_capability_map" ADD CONSTRAINT "sensor_capability_map_capability_id_fkey" FOREIGN KEY ("capability_id") REFERENCES "public"."sensor_capability" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."sensor_capability_map" ADD CONSTRAINT "sensor_capability_map_sensor_id_fkey" FOREIGN KEY ("sensor_id") REFERENCES "public"."smart_device_sensor" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table sensor_data
-- ----------------------------
ALTER TABLE "public"."sensor_data" ADD CONSTRAINT "sensor_data_capability_id_fkey" FOREIGN KEY ("capability_id") REFERENCES "public"."sensor_capability" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
ALTER TABLE "public"."sensor_data" ADD CONSTRAINT "sensor_data_sensor_id_fkey" FOREIGN KEY ("sensor_id") REFERENCES "public"."smart_device_sensor" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table smart_device_sensor
-- ----------------------------
ALTER TABLE "public"."smart_device_sensor" ADD CONSTRAINT "smart_device_sensor_device_id_fkey" FOREIGN KEY ("device_id") REFERENCES "public"."smart_device" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
