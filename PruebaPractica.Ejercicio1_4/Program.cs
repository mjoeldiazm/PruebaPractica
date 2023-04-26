namespace PruebaPractica.Ejercicio1_4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[,] arreglo = {
				{ 17, 9, 36, 21 },
				{ 8, 28, 3, 1 },
				{ 15, 7, 5, 30 },
				{ 10, 17, 4, 12 }
			};
			int tamanoArreglo = arreglo.GetLength(0);
			int sumaTotal = 0;
			for (int indice = 0; indice < tamanoArreglo; indice++)
			{
				sumaTotal += arreglo[indice, indice];
			}
			ImprimirResultado(sumaTotal);
		}
		static void ImprimirResultado(int sumaTotal)
		{
			Console.WriteLine($"La suma es: {sumaTotal}");
		}
	}
}