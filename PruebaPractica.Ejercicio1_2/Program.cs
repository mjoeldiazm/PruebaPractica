using System.Linq;

namespace PruebaPractica.Ejercicio1_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[,] arreglo = { 
				{ 17, 9, 36 }, 
				{ 8, 7, 3 }, 
				{ 15, 28, 57 } 
			};
			int sumaTotal = ObtenerSumaTotalArreglo(arreglo);
			float promedio = sumaTotal / arreglo.Length;
			float diferenciaPorcentualAdmitida = 0.6F;
			List<int> elementosValidos = new();
			List<int> elementosInvalidos = new();
			int tamanoFilas = arreglo.GetLength(0);
			int tamanoColumnas = arreglo.GetLength(1);
			int sumaValoresValidos = 0;
			for (int fila = 0; fila < tamanoFilas; fila++)
			{
				for (int columna = 0; columna < tamanoColumnas; columna++)
				{
					int valorActual = arreglo[fila, columna];
					float diferenciaValorActualConPromedio = Math.Abs(valorActual - promedio);
					if ((diferenciaValorActualConPromedio / promedio) <= diferenciaPorcentualAdmitida)
					{
						elementosValidos.Add(valorActual);
						sumaValoresValidos += valorActual;
						continue;
					}
					elementosInvalidos.Add(valorActual);
				}
			}
			ImprimirResultado(sumaValoresValidos, promedio, elementosValidos, elementosInvalidos);
		}

		static int ObtenerSumaTotalArreglo(int[,] arreglo)
		{
			int tamanoFilas = arreglo.GetLength(0);
			int tamanoColumnas = arreglo.GetLength(1);
			int sumaTotal = 0;
			for (int fila = 0; fila < tamanoFilas; fila++)
			{
				for (int columna = 0; columna < tamanoColumnas; columna++)
				{
					sumaTotal += arreglo[fila, columna];
				}
			}
			return sumaTotal;
		}

		static void ImprimirResultado(int sumaValoresValidos, 
			float promedio, 
			List<int> valoresValidos, 
			List<int> valoresInvalidos)
		{
            Console.WriteLine($"La suma es: {sumaValoresValidos}");
            Console.WriteLine($"Promedio: {promedio}");
            Console.WriteLine($"No aplican para sumar: {string.Join(',', valoresInvalidos)}");
            Console.WriteLine($"Sí aplican para sumar: {string.Join(',', valoresValidos)}");
        }
	}
}