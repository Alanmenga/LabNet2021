/************************************************************
          ALUMNO: Mengassini Alan
************************************************************/

USE PracticaSQL
GO

/************************A – Recuperación básica de datos************************/
/*1- Recuperar lista de empleados*/
SELECT LAST_NAME
FROM TEST.EMPLOYEES;

/*2- Recuperar id, apellido, fecha de contratación de los empleados*/
SELECT  ID,
		LAST_NAME,
		CONVERT(date,HIRE_DATE) FECHA_INGRESO
FROM TEST.EMPLOYEES;

/*3- Recuperar id, apellido, fecha de contratación, salario de los empleados.
Tip: notar presencia de valores nulos*/
SELECT  ID,
		LAST_NAME                 APELLIDO,
		CONVERT(date,HIRE_DATE)   FECHA_INGRESO,
		ISNULL(SALARY,0)            SALARIO
FROM TEST.EMPLOYEES;

/*4- Recuperar id, apellido, fecha de contratación, salario anual de los empleados.
Tip: Calcular el salario anual como 12 veces el salario. Usar alias para el sueldo anual.*/
SELECT  ID,
		LAST_NAME                  APELLIDO,
		CONVERT(date,HIRE_DATE)    FECHA_INGRESO,
		ISNULL(SALARY*12,0)        SALARIO_ANUAL
FROM TEST.EMPLOYEES;

/*5- Recuperar id, apellido y nombre, fecha de contratación, salario anual de los empleados.
Tip: Concatenar usando ||. Notar que los operadores a usar dependen del tipo de dato de
los campos.*/
SELECT  ID,
		FIRST_NAME+' '+LAST_NAME       NOMBRE_COMPLETO,
		CONVERT(date,HIRE_DATE)        FECHA_INGRESO,
		ISNULL(SALARY*12,0)            SALARIO_ANUAL
FROM TEST.EMPLOYEES;

/*6- Recuperar lista de departamentos que tienen empleados:*/
	/*6.a- Recuperar lista de departamentos de los empleados*/
	SELECT   d.ID,
			 d.DEPARTMENT_NAME,
			 e.ID,e.FIRST_NAME +' '+ e.LAST_NAME  NOMBRE_COMPLETO
	FROM TEST.DEPARTMENTS   as d,
		 TEST.EMPLOYEES     as e
	WHERE e.DEPARTMENT_ID=d.ID

	/*6.b- Recuperar lista no repetida de departamentos de los empleados*/
	SELECT	DISTINCT d.ID,
			d.DEPARTMENT_NAME
	FROM TEST.DEPARTMENTS   as d,
		 TEST.EMPLOYEES     as e
	WHERE e.DEPARTMENT_ID=d.ID;

/************************B – Comparaciones simples y especiales / Comparaciones nulas************************/
/*7- Recuperar lista de empleados cuyo departamento sea 10.*/
SELECT  FIRST_NAME+' '+LAST_NAME   NOMBRE_COMPLETO,
		DEPARTMENT_ID              ID_DEPARTAMETO
FROM TEST.EMPLOYEES
WHERE DEPARTMENT_ID=10;

/*8- Recuperar lista de empleados cuyo salario sea menor a 2000.*/
SELECT  FIRST_NAME+' '+LAST_NAME   NOMBRE_COMPLETO,
		ISNULL(SALARY,0)           SALARIO
FROM TEST.EMPLOYEES
WHERE SALARY<2000 OR SALARY IS NULL;

/*9- Recuperar lista de empleados cuyo salario sea entre 1800 y 3000
Tip: usar cláusula “between”. Notar diferencia con el uso de 2 condiciones.*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		SALARY SALARIO
FROM TEST.EMPLOYEES
WHERE SALARY BETWEEN 1800 AND 3000;

/*10- Recuperar lista de empleados cuyo departamento sea 10 o 30 o 31.
Tip: usar cláusula “in”.*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		DEPARTMENT_ID ID_DEPARTAMENTO
FROM TEST.EMPLOYEES
WHERE DEPARTMENT_ID IN (10,30,31);

/*11- Recuperar lista de empleados cuyo apellido empiece con F.
Tip: usar cláusula “like”. Notar que los operadores a usar dependen del tipo de dato de los
campos.*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO
FROM TEST.EMPLOYEES
WHERE LAST_NAME LIKE 'f%';

/*12- Recuperar lista de empleados cuyo job_id:*/
	/*12.a- no hay sido definido*/
	SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
			JOB_ID ID_TRABAJO
	FROM TEST.EMPLOYEES
	WHERE JOB_ID IS NULL;

	/*12.b- haya sido definido.*/
	SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
			JOB_ID ID_TRABAJO
	FROM TEST.EMPLOYEES
	WHERE JOB_ID IS NOT NULL;

/*13- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’. Tip: Notar
comportamiento de la condición con jobs nulos.*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		ISNULL(JOB_ID,NULL) ID_TRABAJO
FROM TEST.EMPLOYEES
WHERE JOB_ID <> 'AD_CTB' 
		OR JOB_ID IS NULL;

/************************C- Comparaciones con nexos lógicos / Precedencia de condiciones************************/
/*14- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’ y cuyo salario sea
mayor a 1900.*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		SALARY SALARIO,
		JOB_ID ID_TRABAJO
FROM TEST.EMPLOYEES
WHERE (JOB_ID <> 'AD_CTB' OR JOB_ID IS NULL) 
		AND SALARY >1900;

/*15- Recuperar lista de empleados cuyo job_id sea distinto de ‘AD_CTB’ o cuyo salario sea
mayor a 1900.*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		SALARY SALARIO,
		JOB_ID ID_TRABAJO
FROM TEST.EMPLOYEES
WHERE (JOB_ID <> 'AD_CTB' OR JOB_ID IS NULL) 
		OR SALARY >1900;

/*16- Recuperar lista de empleados cuyo job_id sea ‘AD_CTB’ o ‘FQ_GRT’ (sin usar IN) y cuyo
salario sea mayor a 1900.
Tip: Probar precedencia de condiciones con o sin paréntesis.*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		SALARY SALARIO,
		JOB_ID ID_TRABAJO
FROM TEST.EMPLOYEES
WHERE (JOB_ID='AD_CTB' OR JOB_ID='FQ_GRT') 
		AND SALARY>1900
--WHERE JOB_ID='AD_CTB' OR JOB_ID='FQ_GRT' 
	  --AND SALARY>1900

/************************D- Ordenamiento************************/
/*17- Recuperar empleados ordenados por fecha de ingreso (desde más viejo a más nuevo).*/
SELECT  ID,
		FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		CONVERT(date,HIRE_DATE) FECHA_INGRESO
FROM TEST.EMPLOYEES
ORDER BY HIRE_DATE ASC;

/*18- Recuperar empleados ordenados por fecha de ingreso (desde más nuevo a más viejo).*/
SELECT  ID,
		FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		CONVERT(date,HIRE_DATE) FECHA_INGRESO
FROM TEST.EMPLOYEES
ORDER BY HIRE_DATE DESC;

/*19- Recuperar empleados ordenados por fecha de ingreso descendente y apellido ascendente.*/
SELECT  ID,
		FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		CONVERT(date,HIRE_DATE) FECHA_INGRESO
FROM TEST.EMPLOYEES
ORDER BY HIRE_DATE DESC,
		 LAST_NAME ASC;

/*20- Recuperar apellido y salario anual de empleados ordenados por salario anual.
Tip: Usar alias de columna para ordenar por salario anual.*/
SELECT  LAST_NAME APELLIDO,
		ISNULL(SALARY*12,0) SALARIO_ANUAL
FROM TEST.EMPLOYEES
ORDER BY SALARIO_ANUAL DESC;

/************************E- Recuperación de datos de múltiples tablas************************/
/*21- Recuperar lista de empleados con la descripción del departamento al que cada uno
pertenece.
Tip: evitar producto cartesiano.
Completar: select * from TEST.EMPLOYEES, …*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		DEPARTMENT_ID,DEPARTMENT_NAME,
		DEPARTMENT_DESCRIPTION
FROM TEST.EMPLOYEES as e,TEST.DEPARTMENTS as d
WHERE e.DEPARTMENT_ID = d.ID;

/*22- Seleccionar apellido de empleado y nombre de departamento*/
SELECT	LAST_NAME,
		ISNULL(d.DEPARTMENT_NAME,NULL) NOMBRE_DEPARTAMENTO
FROM TEST.EMPLOYEES as e
	LEFT JOIN TEST.DEPARTMENTS	 AS d
			ON e.DEPARTMENT_ID=d.ID;

/*23- Agregar id de empleado y id de departamento
Tip: desambiguar campos usando alias de tablas.*/
SELECT  e.ID,
		e.LAST_NAME,
		DEPARTMENT_ID,
		ISNULL(d.DEPARTMENT_NAME,NULL) NOMBRE_DEPARTAMENTO
FROM TEST.EMPLOYEES as e
	LEFT JOIN TEST.DEPARTMENTS	as d 
			ON e.DEPARTMENT_ID=d.ID;

/*24- Recuperar lista de empleados con descipción de departamentos y ciudades.*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		DEPARTMENT_ID,
		ISNULL(d.DEPARTMENT_NAME,NULL) NOMBRE_DEPARTAMENTO,
		DEPARTMENT_DESCRIPTION,
		CITY
FROM TEST.EMPLOYEES as e
	 LEFT JOIN TEST.DEPARTMENTS				as d 
			ON e.DEPARTMENT_ID=d.ID
		LEFT JOIN TEST.LOCATIONS				as l		 
			ON d.LOCATION_ID=l.ID;

/************************F- Uso de cláusula JOIN************************/
/*25- Recuperar lista de empleados con la descripción del departamento al que cada uno
pertenece.
Completar: select * from TEST.EMPLOYEES join …,*/
SELECT  FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		ISNULL(d.DEPARTMENT_NAME,NULL) NOMBRE_DEPARTAMENTO,
		DEPARTMENT_DESCRIPTION
FROM TEST.EMPLOYEES as e
	JOIN TEST.DEPARTMENTS as d 
		ON d.ID=e.DEPARTMENT_ID

/*26- Recuperar lista de empleados con la descripción del departamento, tengan o no
departamento asignado.*/
SELECT	FIRST_NAME+' '+LAST_NAME NOMBRE_COMPLETO,
		ISNULL(d.DEPARTMENT_DESCRIPTION,NULL) AS DESCRIPCION_DEPARTAMENTO
FROM TEST.EMPLOYEES				AS e
	LEFT JOIN TEST.DEPARTMENTS	AS d 
		ON e.DEPARTMENT_ID=d.ID;

/*27- Recuperar lista de departamentos con empleados de cada departamento, tengan o no
empleados asociados.*/
SELECT  d.DEPARTMENT_NAME,
		ISNULL(e.LAST_NAME+' '+e.FIRST_NAME,NULL)	NOMBRE_COMPLETO
FROM TEST.DEPARTMENTS			as d
	LEFT JOIN TEST.EMPLOYEES	as e
		ON d.ID=e.DEPARTMENT_ID;


/************************G- Selfjoin************************/
/*28- Recuperar lista de subordinados por cada manager*/
SELECT  e1.MANAGER_ID,
		e1.FIRST_NAME,
		e1.LAST_NAME
FROM TEST.EMPLOYEES e1,
	 TEST.EMPLOYEES e2
WHERE e1.ID<>e2.ID
	AND e1.MANAGER_ID=e2.MANAGER_ID

/************************H- Funciones de agrupamiento************************/
/*29- Recuperar máximo salario de los empleados.*/
SELECT MAX(SALARY) SALARIO_MAXIMO
FROM TEST.EMPLOYEES

/*30- Recuperar máximo, mínimo, promedio, y suma total de salarios de los empleados.*/
SELECT MAX(SALARY) SALARIO_MAXIMO,
	   MIN(SALARY) SALARIO_MINIMO,
	   AVG(SALARY) SALARIO_PROMEDIO,
	   SUM(SALARY) SUMA_SALARIOS
FROM TEST.EMPLOYEES

/*31- Recuperar máximo, mínimo, promedio, y suma total de fecha de contratación de los
empleados.
Tip: Notar que las funciones de agrupamiento permitidas dependen del tipo de dato.*/
SELECT MAX(HIRE_DATE) FECHA_MAXIMO,
	   MIN(HIRE_DATE) FECHA_MINIMO,
	   AVG(CAST(HIRE_DATE as INT))  FECHA_PROMEDIO,
	   SUM(CAST(HIRE_DATE as INT)) SUMA_FECHAS
FROM TEST.EMPLOYEES

/*32- Obtener la cantidad de empleados.*/
SELECT COUNT(ID) CANTIDAD_EMPLEADOS
FROM TEST.EMPLOYEES

/*33- Obtener la cantidad de empleados cuyo departamento sea 10.*/
SELECT COUNT(ID) CANTIDAD_EMPLEADOS
FROM TEST.EMPLOYEES
WHERE DEPARTMENT_ID=10

/*34- Obtener la cantidad de empleados de cada departamento.*/
SELECT	d.DEPARTMENT_NAME	  DEPARTAMENTO,
		count(e.ID)		      CANTIDAD_EMPLEADOS		
FROM TEST.DEPARTMENTS			    AS d
		LEFT JOIN TEST.EMPLOYEES	AS e
			ON d.ID=e.DEPARTMENT_ID
GROUP BY d.DEPARTMENT_NAME;

/*35- Obtener la cantidad de empleados por cada departamento y job.*/
SELECT	d.DEPARTMENT_NAME	 DEPARTAMENTO,
		j.JOB_NAME	         TRABAJO,
		count(e.ID)		     CANTIDAD_EMPLEADOS		
FROM TEST.DEPARTMENTS			    AS d
	LEFT JOIN TEST.EMPLOYEES	    AS e
		ON d.ID=e.DEPARTMENT_ID
	LEFT JOIN TEST.JOBS             AS j
		ON e.JOB_ID=j.ID    
GROUP BY d.DEPARTMENT_NAME,
		 j.JOB_NAME;

/************************I- Condiciones de grupo************************/
/*36- Recuperar los departamentos y el salario promedio de cada departamento.*/
SELECT	d.DEPARTMENT_NAME				DEPARTAMENTO,
		ISNULL(AVG(e.SALARY),0)			PROMEDIO_SALARIOS		
FROM TEST.DEPARTMENTS		AS d
	LEFT JOIN TEST.EMPLOYEES	AS e
		ON d.ID=e.DEPARTMENT_ID
GROUP BY d.DEPARTMENT_NAME;

/*37- Recuperar los departamentos y el salario promedio si es menor a 1200.*/
SELECT	d.DEPARTMENT_NAME				DEPARTAMENTO,
		ISNULL(AVG(e.SALARY),0)		PROMEDIO_SALARIOS		
FROM TEST.DEPARTMENTS		    AS d
	LEFT JOIN TEST.EMPLOYEES	AS e
		ON d.ID=e.DEPARTMENT_ID
GROUP BY d.DEPARTMENT_NAME
HAVING ISNULL(AVG(e.SALARY),0) < 1200;

/************************J- Creación de nuevos registros************************/
/*38- Crear un nuevo departamento
Caso 1: Crear insert de todos los campos en orden.
Tip: Notar restricciones de integridad por padre inexistente y por clave duplicada.
Completar: insert into TEST.DEPARTMENTS VALUES …*/
BEGIN TRANSACTION;
INSERT INTO TEST.DEPARTMENTS
     VALUES (51,'Venta',1, 'Comercializacion del producto');
COMMIT TRANSACTION;

/*Caso 2: Crear insert de todos los campos en orden usando valores nulos.
Tip: Notar restricciones de no nulidad.*/
GO
BEGIN TRANSACTION;

DECLARE @idMax int;
SET @idMax = (SELECT MAX(ID)+1 FROM TEST.EMPLOYEES);

INSERT INTO TEST.DEPARTMENTS
     VALUES (NULL,NULL,NULL,NULL);

COMMIT TRANSACTION;
GO

/*Caso 3: 38.c- Crear insert usando solamente los campos obligatorios.
Tip: Especificar lista de campos obligatorios.
Completar: insert into TEST.DEPARTMENTS (ID,...*/
GO
BEGIN TRANSACTION

DECLARE @idMax int;
SET @idMax = (SELECT MAX(ID)+1 FROM TEST.EMPLOYEES);

INSERT INTO TEST.DEPARTMENTS
           (ID,
		   DEPARTMENT_NAME,
		   LOCATION_ID)
     VALUES(@idMax, 'RRHH',1);
COMMIT TRANSACTION;
GO

/************************K- Creación de nuevos registros en base a registros existentes************************/
/*39- Crear un nuevo empleado basado en los datos de Gustavo Boulette:
		cambiando su nombre
		aumentando su sueldo en $200.
		blanqueando su manager*/
GO
BEGIN TRANSACTION

DECLARE @idMax int;
SET @idMax = (SELECT MAX(ID)+1 FROM TEST.EMPLOYEES);

INSERT INTO TEST.EMPLOYEES
SELECT @idMax , 'Alan', 'Mengassini',emp.SALARY+200,emp.DEPARTMENT_ID,emp.JOB_ID,emp.HIRE_DATE,NULL
FROM TEST.EMPLOYEES emp
WHERE emp.FIRST_NAME='Gustavo' and emp.LAST_NAME='Boulette';

COMMIT TRANSACTION;
GO

/************************L- Actualización de registros************************/
/*40- Actualizar salario del empleado 10 a $1100.*/
BEGIN TRANSACTION
UPDATE TEST.EMPLOYEES 
SET SALARY=1100
 WHERE  ID=10;
COMMIT TRANSACTION;

/*41- Duplicar salario del empleado 11.*/
BEGIN TRANSACTION
UPDATE TEST.EMPLOYEES 
SET SALARY=SALARY*2
 WHERE  ID=11;
COMMIT TRANSACTION;

/*42- Aumentar salario en un 10% a todos los empleados del departamento 40.*/
BEGIN TRANSACTION
UPDATE TEST.EMPLOYEES 
SET SALARY=SALARY*1.1
WHERE  DEPARTMENT_ID=40;
COMMIT TRANSACTION;


/************************M- Eliminación de registros************************/
/*43- Eliminar departamentos cuyo id sea mayor a 50.
Tip: hacer un select antes y después para verificar usando la misma condición que para el
delete.*/
BEGIN TRANSACTION

SELECT ID
FROM TEST.DEPARTMENTS;

DELETE TEST.DEPARTMENTS 
WHERE  ID>50;

SELECT ID
FROM TEST.DEPARTMENTS;

COMMIT TRANSACTION;

/*44- Eliminar departamento 40.
Tip: notar resultado de las restricciones de integridad.*/
Select * from TEST.DEPARTMENTS;

BEGIN TRANSACTION
UPDATE TEST.EMPLOYEES 
SET DEPARTMENT_ID=NULL
WHERE  DEPARTMENT_ID=40

DELETE TEST.DEPARTMENTS 
WHERE  ID=40;
COMMIT TRANSACTION

/************************N-Crear una Función************************/
/*45- Crear la función &quot;fn_AntiguedadEmpleado&quot; que retorne la antiguedad en años de cada
empleado donde el parametro de ingreso es el id del empleado*/
GO
CREATE FUNCTION fn_AntiguedadEmpleado(@id INT)
RETURNS INT
AS
BEGIN
DECLARE @Antiguiedad int

SELECT @Antiguiedad = DATEDIFF (YEAR, emp.HIRE_DATE , GETDATE())
FROM TEST.EMPLOYEES AS emp
	WHERE emp.ID=@id

RETURN @Antiguiedad
END
GO

SELECT dbo.fn_AntiguedadEmpleado(1);


/*46 - Crear el Procedimiento almacenado &quot;sp_GetNombreAntiguedad&quot; que retorne el primer
nombre y el apellido separados por una coma y en la segunda columna la antiguedad en año. Usar
la función creada en el punto anterior.
Ordenar por antiguedad descendiente (mas antiguo primero)*/
GO
CREATE PROCEDURE sp_GetNombreAntiguedad
AS
SELECT First_name +','+Last_Name, dbo.fn_AntiguedadEmpleado(emp.ID) AS 'Antiguedad'
FROM TEST.EMPLOYEES AS emp
ORDER BY  'Antiguedad'
GO

sp_GetNombreAntiguedad;