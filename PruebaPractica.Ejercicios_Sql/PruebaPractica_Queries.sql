-- 2.1. Mostrar el salario mínimo, máximo y promedio por cada departamento.
SELECT D.Nombre,
	ROUND(MIN(E.Salario), 2) AS Mínimo,
	ROUND(MAX(E.Salario), 2) AS Máximo,
	ROUND(AVG(E.Salario), 2) AS Promedio
FROM Departamentos D INNER JOIN Empleados E ON D.id = E.DepartamentoId
GROUP BY D.Nombre

-- 2.2. Listar los departamentos que tienen 3 o más empleados.
SELECT D.Nombre,
	COUNT(E.Nombre) AS [No. Empleados]
FROM Departamentos D INNER JOIN Empleados E
	ON D.id = E.DepartamentoId
GROUP BY D.Nombre
HAVING COUNT (E.Nombre) >= 3

-- 2.3. Mostrar los colaboradores que tienen al menos 1 año de haber ingresado, indicando en una columna los meses que tienen de haber ingresado.
SELECT E.Nombre,
	DATEDIFF(MONTH, E.FechaIngreso, GETDATE()) AS Meses
FROM Empleados E
WHERE DATEDIFF(MONTH, E.FechaIngreso, GETDATE()) >= 12
ORDER BY DATEDIFF(MONTH, E.FechaIngreso, GETDATE())

-- 2.4. Mostrar una lista de los empleados, ordenándolos primero por los que pertenecen al departamento de Mercadeo, y luego por ordenados por el nombre del departamento y nombre del empleado.
SELECT E.Nombre AS Colaborador,
	D.Nombre AS Departamento,
	CASE 
		WHEN D.Nombre = 'Mercadeo' THEN 1
		ELSE 2
	END AS Orden
FROM Departamentos D INNER JOIN Empleados E ON D.id = E.DepartamentoId
GROUP BY D.Nombre,
	E.Nombre
ORDER BY Orden,
	D.Nombre,
	E.Nombre

-- 2.5. Listar los 2 empleados con mayor salario de cada departamento.
SELECT Empleado,
	Salario,
	Departamento
FROM (
	SELECT DENSE_RANK() OVER (PARTITION BY D.Nombre ORDER BY E.Salario DESC) AS IndiceGrupo,
		E.Nombre AS Empleado,
		E.Salario,
		D.Nombre AS Departamento
	FROM Departamentos D INNER JOIN Empleados E ON D.id = E.DepartamentoId
) GruposPorDepartamento
WHERE GruposPorDepartamento.IndiceGrupo <= 2

-- 2.6. Listar los empleados de cada departamento, agregando una columna que muestre el número de línea agrupado por cada departamento.
SELECT ROW_NUMBER() OVER (PARTITION BY D.Nombre ORDER BY E.Salario DESC) AS Numero,
	E.Nombre AS Empleado,
	E.Salario,
	D.Nombre AS Departamento
FROM Departamentos D INNER JOIN Empleados E ON D.id = E.DepartamentoId
ORDER BY D.Nombre,
	E.Nombre