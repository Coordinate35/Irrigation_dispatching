USE irrigation_dispatching;
GO

INSERT INTO irrigation_method(crop_id,method ,designed_output_min,disigned_output_max ) 
VALUES 
(1,	'块灌',	300,450),
(3,	'块灌',	350,500),
(5,	'块灌',	90,145),
(13,	'块灌',	100,200),
(14,	'块灌',	100,200);
GO
