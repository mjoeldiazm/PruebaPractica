namespace PruebaPractica.Ejercicio1_5
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string textoEntrada;
			do
			{
				Console.Write("Ingrese una cadena de texto: ");
				textoEntrada = Console.ReadLine();
			} while (string.IsNullOrEmpty(textoEntrada));
			Console.Write("Texto invertido: ");
			for (int indice = (textoEntrada.Length - 1); indice >= 0; indice--)
			{
				Console.Write(textoEntrada[indice]);
            }
		}
	}
}