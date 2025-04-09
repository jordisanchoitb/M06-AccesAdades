DROP TABLE IF EXISTS department;
DROP TABLE IF EXISTS employee;

CREATE TABLE department (
 _id  INTEGER NOT NULL PRIMARY KEY,
 name  VARCHAR(15), 
 loc   VARCHAR(15)
);

INSERT INTO department VALUES (10,'CONTABILIDAD','SEVILLA');
INSERT INTO department VALUES (20,'INVESTIGACIÓN','MADRID');
INSERT INTO department VALUES (30,'VENTAS','BARCELONA');
INSERT INTO department VALUES (40,'PRODUCCIÓN','BILBAO');
COMMIT;

CREATE TABLE employee (
 _id    INTEGER  NOT NULL PRIMARY KEY,
 surname  VARCHAR(10),
 job    VARCHAR(10),
 managerid INTEGER,
 startdate DATE      ,
 salary   DECIMAL(6,2),
 commission  DECIMAL(6,2),
 depid   INTEGER NOT NULL,
 CONSTRAINT FK_DEP FOREIGN KEY (depid) REFERENCES department(_id)

);

INSERT INTO employee VALUES (7369,'SÁNCHEZ','EMPLEADO',7902,'1990/12/17',
                        1040,NULL,20);				
INSERT INTO employee VALUES (7499,'ARROYO','VENDEDOR',7698,'1990/02/20',
                        1500,390,30);
INSERT INTO employee VALUES (7521,'SALA','VENDEDOR',7698,'1991/02/22',
                        1625,650,30);
INSERT INTO employee VALUES (7566,'JIMÉNEZ','DIRECTOR',7839,'1991/04/02',
                        2900,NULL,20);
INSERT INTO employee VALUES (7654,'MARTÍN','VENDEDOR',7698,'1991/09/29',
                        1600,1020,30);
INSERT INTO employee VALUES (7698,'NEGRO','DIRECTOR',7839,'1991/05/01',
                        3005,NULL,30);
INSERT INTO employee VALUES (7782,'CEREZO','DIRECTOR',7839,'1991/06/09',
                        2885,NULL,10);
INSERT INTO employee VALUES (7788,'GIL','ANALISTA',7566,'1991/11/09',
                        3000,NULL,20);
INSERT INTO employee VALUES (7839,'REY','PRESIDENTE',NULL,'1991/11/17',
                        4100,NULL,10);
INSERT INTO employee VALUES (7844,'TOVAR','VENDEDOR',7698,'1991/09/08',
                        1350,0,30);
INSERT INTO employee VALUES (7876,'ALONSO','EMPLEADO',7788,'1991/09/23',
                        1430,NULL,20);
INSERT INTO employee VALUES (7900,'JIMENO','EMPLEADO',7698,'1991/12/03',
                        1335,NULL,30);
INSERT INTO employee VALUES (7902,'FERNÁNDEZ','ANALISTA',7566,'1991/12/03',
                        3000,NULL,20);
INSERT INTO employee VALUES (7934,'MUÑOZ','EMPLEADO',7782,'1992/01/23',
                        1690,NULL,10);
COMMIT;
