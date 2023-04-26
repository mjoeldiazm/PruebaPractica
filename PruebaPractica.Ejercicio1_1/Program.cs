namespace PruebaPractica.Ejercicio1_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[,] arreglo1 = { 
				{ 17, 9, 36 }, 
				{ 8, 7, 3 }, 
				{ 15, 28, 87 } 
			};
			int[,] arreglo2 = { 
				{ 9, 21, 36 }, 
				{ 16, 65, 4 }, 
				{ 12, 28, 31 } 
			};
			int cantidadElementosMayoresArreglo1 = 0;
			int cantidadElementosMayoresArreglo2 = 0;
			int cantidadElementosIguales = 0;
			int tamanoFilas = arreglo1.GetLength(0);
			int tamanoColumnas = arreglo1.GetLength(1);
			for (int fila = 0; fila < tamanoFilas; fila++)
			{
				for (int columna = 0; columna < tamanoColumnas; columna++)
				{
					int valorActualArreglo1 = arreglo1[fila, columna];
					int valorActualArreglo2 = arreglo2[fila, columna];
					if (valorActualArreglo1 > valorActualArreglo2)
					{
						cantidadElementosMayoresArreglo1++;
						continue;
					}
					if (valorActualArreglo2 > valorActualArreglo1)
					{
						cantidadElementosMayoresArreglo2++;
						continue;
					}
					cantidadElementosIguales++;
				}
			}
			ImprimirResultado(cantidadElementosMayoresArreglo1,
				cantidadElementosMayoresArreglo2,
				cantidadElementosIguales);
		}

		static void ImprimirResultado(int cantidadElementosMayoresArreglo1,
			int cantidadElementosMayoresArreglo2,
			int cantidadElementosIguales)
		{
			Console.WriteLine($"El arreglo 1 contiene {cantidadElementosMayoresArreglo1} elementos mayores");
			Console.WriteLine($"El arreglo 2 contiene {cantidadElementosMayoresArreglo2} elementos mayores");
			Console.WriteLine($"Existen {cantidadElementosIguales} elementos iguales en ambos arreglos");
		}
	}
}