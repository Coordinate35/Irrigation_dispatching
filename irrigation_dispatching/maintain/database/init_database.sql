USE master;
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='irrigation_dispatching')
BEGIN
    DROP DATABASE irrigation_dispatching;
END
GO

CREATE DATABASE irrigation_dispatching COLLATE Chinese_PRC_CI_AS;
GO

USE irrigation_dispatching;
GO

CREATE TABLE dbo.account(
    account_id SMALLINT NOT NULL PRIMARY KEY IDENTITY(1, 1), --账号的id
    account_name NVARCHAR(50) NOT NULL,                      --账号的真实姓名
    passwd VARCHAR(255) NOT NULL,                            --账号密码的哈希
    register_time INT NOT NULL,                              --账号注册的时间戳
    privilege INT NOT NULL DEFAULT(1),                       --账号的权限，0代表管理员，1代表用户
    available BIT NOT NULL DEFAULT(1)                        --账号是否还存在
);
GO

CREATE TABLE dbo.inflow_prediction(
    period_order TINYINT NOT NULL PRIMARY KEY,               --来水的旬次
    average_flow SMALLINT NOT NULL                           --预测的来水平均流量
);
GO

CREATE TABLE dbo.inflow_history(
    year SMALLINT NOT NULL PRIMARY KEY,                      --来水的年份
    average_flow SMALLINT NOT NULL,                          --平均的流量
    available BIT NOT NULL DEFAULT(1)                        --字段是否存在
);
GO

CREATE TABLE dbo.crop(
    crop_id SMALLINT NOT NULL PRIMARY KEY IDENTITY(1, 1),    --作物的id
    crop_name NVARCHAR(10) NOT NULL,                         --作物的名称 
    crop_type NVARCHAR(10) NOT NULL,                         --作物所属的种类
    available BIT NOT NULL DEFAULT(1)                        --作物是否存在
);
GO

CREATE TABLE dbo.admin_dept(
    dept_id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),         --行政部门的id
    dept_name NVARCHAR(30) NOT NULL,                         --行政部门的名称
    father_id INT NOT NULL,                                  --该行政部门所属的行政部门的id，如果为顶级行政部门，则为0
    available BIT NOT NULL DEFAULT(1)                        --该行政部门是否存在
);
GO

CREATE TABLE dbo.irrigation_area(
    dept_id INT NOT NULL,                                    --灌溉地区所属行政单位的id
    crop_id SMALLINT NOT NULL,                               --灌溉作物的id
    area INT NOT NULL,                                       --所需灌溉的面积
    available BIT NOT NULL DEFAULT(1),                       --该灌溉面积是否存在
    PRIMARY KEY(dept_id, crop_id),
    FOREIGN KEY (dept_id) REFERENCES admin_dept(dept_id)
        ON UPDATE CASCADE,
    FOREIGN KEY (crop_id) REFERENCES crop(crop_id)
        ON UPDATE CASCADE
);
GO

CREATE TABLE dbo.irrigation_method(
    method_id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),      --灌水方法的id
    crop_id SMALLINT NOT NULL,                              --农作物的id
    method NVARCHAR(10) NOT NULL,                           --灌水方法名
    designed_output_min SMALLINT NOT NULL,                  --计划产量最小值
    disigned_output_max SMALLINT NOT NULL,                  --计划产量最大值
    available BIT NOT NULL DEFAULT(1),                      --该方法是否存在
    FOREIGN KEY (crop_id) REFERENCES crop(crop_id)
        ON UPDATE CASCADE  
);
GO

CREATE TABLE dbo.round_order_info(
    round_order TINYINT NOT NULL PRIMARY KEY IDENTITY(1, 1), --轮次
    season NVARCHAR(10) NOT NULL,                            --季节
    start_time INT NOT NULL,                                 --开始日期的时间戳
    end_time INT NOT NULL,                                   --技术日期的时间戳
    qouta INT NOT NULL,                                      --定额
    available BIT NOT NULL DEFAULT(1)                        --方法是否存在
);
GO

CREATE TABLE dbo.dry_earth(
    round_order TINYINT NOT NULL,                            --轮次
    area INT NOT NULL,                                       --面积
    available BIT NOT NULL DEFAULT(1),                       --干第是否存在
    FOREIGN KEY (round_order) REFERENCES round_order_info(round_order)
        ON UPDATE CASCADE 
);
GO

CREATE TABLE dbo.irrigation_institution(
    institution_id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),  --制度的id
    round_order TINYINT NOT NULL,                            --轮次
    crop_id SMALLINT NOT NULL,                               --作物的id
    available BIT NOT NULL DEFAULT(1),                       --作物轮次关系是否存在
    stage NVARCHAR(50),                                      --植物生长阶段
    FOREIGN KEY (crop_id) REFERENCES crop(crop_id)
        ON UPDATE CASCADE,
    FOREIGN KEY (round_order) REFERENCES round_order_info(round_order)
        ON UPDATE CASCADE
);
GO