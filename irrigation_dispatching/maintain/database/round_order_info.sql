﻿USE irrigation_dispatching;
GO

INSERT INTO round_order_info(season , start_time,end_time,qouta) 
VALUES 
('春季',1458835200,1460649600,150),
('夏季',1461772800,1463241600,74),
('夏季',1463328000,1465142400,69),
('夏季',1465228800,1466870400,71),
('夏季',1466956800,1468512000,73),
('夏季',1468598400,1469894400,71),
('秋季',1469980800,1471622400,72),
('秋季',1472313600,1473868800,73),
('冬季',1473955200,1478707200,182);
GO