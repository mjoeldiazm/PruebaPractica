namespace PruebaPractica.Ejercicio1_3
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
			int[] elementosOrdenados = ConvertirArregloUnidimensional(arreglo);
			Array.Sort(elementosOrdenados);
			float mediana = ObtenerMediana(elementosOrdenados);
			ImprimirResultado(elementosOrdenados, mediana);
		}

		static int[] ConvertirArregloUnidimensional(int[,] arreglo)
		{
			int tamanoFilas = arreglo.GetLength(0);
			int tamanoColumnas = arreglo.GetLength(1);
			int[] arregloUnidimensional = new int[arreglo.Length];
			int indice = 0;
			for (int fila = 0; fila < tamanoFilas; fila++)
			{
				for (int columna = 0; columna < tamanoColumnas; columna++)
				{
					arregloUnidimensional[indice] = arreglo[fila, columna];
					indice++;
				}
			}
			return arregloUnidimensional;
		}
		static float ObtenerMediana(int[] arreglo)
		{
			bool arregloTieneTamanoPar = (arreglo.Length % 2 == 0);
			if (arregloTieneTamanoPar)
			{
				int posicionCentral = arreglo.Length / 2;
				int valorIzquierda = arreglo[posicionCentral - 1];
				int valorDerecha = arreglo[posicionCentral + 1];
				return (valorIzquierda + valorDerecha) / 2;
			}
			else
			{
				int posicionCentral = (int)Math.Floor((double)(arreglo.Length / 2));
				return arreglo[posicionCentral];
			}
		}

		static void ImprimirResultado(int[] elementosOrdenados, float mediana)
		{
            Console.WriteLine($"Elementos ordenados: {string.Join(',', elementosOrdenados)}");
			Console.WriteLine($"Mediana: {mediana}");
        }
	}
}