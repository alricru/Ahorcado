//Lista de palabras
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

List<String> palabras = new List<string>();

int vidas = 6;

void Hangman()
{
    MostrarCabecera();
    PrecargarPalabras();
    string aleatoria = SeleccionarPalabraAleatoria();
    Console.WriteLine($"VIDAS: {IntentosRestantes()}");
    string censurada = OcultarPalabra(aleatoria);
    DibujarLineas(censurada);
    while (vidas > 0 && !HasGanado(aleatoria, ref censurada))
    {
        char letra = SolicitarLetra();
        Console.Clear();
        Console.WriteLine("--------------------");
        ReemplazarLineas(aleatoria, ref censurada, letra);
        Console.WriteLine("--------------------");
        Console.WriteLine($"VIDAS: {IntentosRestantes()}");
        Console.WriteLine("--------------------");
    }
    if (vidas == 0)
    {
        Console.WriteLine("HAS PERDIDO");
    }
}


void MostrarCabecera()
{
    Console.WriteLine("+-------------------------------------+");
    Console.WriteLine("|  +---+    -----------------         |");
    Console.WriteLine("|  |   |    JUEGO:AHORCADO            |");
    Console.WriteLine("|      |    LENGUAJE:C#               |");
    Console.WriteLine("|      |    AUTOR: Alejandro Rivero   |");
    Console.WriteLine("|      |    -----------------         |");
    Console.WriteLine("|      |   PROGRAMACIÓN Y MOTORES     |");
    Console.WriteLine("+-------------------------------------+");

    Console.WriteLine("--------------------");
    Console.WriteLine("JUEGO DEL AHORCADO");
    Console.WriteLine("--------------------");
    Console.WriteLine("Adivina la palabra");
    Console.WriteLine("--------------------");


};

void PrecargarPalabras() {
    palabras.Add("Aguacate");
    palabras.Add("Alcachofa");
    palabras.Add("Cornamenta");
    palabras.Add("Ibuprofeno");
    palabras.Add("Ojera");
    palabras.Add("Global");
    palabras.Add("Esternocleidomastoideo");
    palabras.Add("Videojuego");
    palabras.Add("Butano");
    palabras.Add("Solar");
};
string[] ahorcado = {
    "  ________\n |       |\n |       O\n |      /|\\ \n |      / \\ \n |       \n |",
    "  ________\n |       |\n |       O\n |      /|\\ \n |      /  \n |       \n |",
    "  ________\n |       |\n |       O\n |      /|\\ \n |       \n |       \n |",
    "  ________\n |       |\n |       O\n |      /| \n |       \n |       \n |",
    "  ________\n |       |\n |       O\n |       | \n |       \n |       \n |",
    "  ________\n |       |\n |       O\n |       \n |       \n |       \n |",
    "  ________\n |       |\n |       \n |       \n |       \n |       \n |",
};



String SeleccionarPalabraAleatoria()
{
    Random rand = new Random();
    String aleatoria = palabras[rand.Next(10)];
    return aleatoria;
}

String OcultarPalabra(string palabra) {
    int pal = palabra.Length;
    string reemplazo = "_";

    for (int i = 0; i < pal; i++)
    {
        palabra = palabra.Substring(0,i) + reemplazo + palabra.Substring(i + 1);
    }
   return palabra;
};

void DibujarLineas(String leer)
{
    string espacio = leer.Replace("_", "_ ");
    Console.WriteLine(espacio);
}
int IntentosRestantes() 
{
    return vidas;
};

char SolicitarLetra()
{
    bool comprobar = false;
    Console.WriteLine("Escriba una Letra");
    string solicitud = null;

    while (!comprobar)
    {
        solicitud = Console.ReadLine() ?? "";
        bool isAlphaBet = Regex.IsMatch(solicitud.ToString(), "[a-z]", RegexOptions.IgnoreCase);
        if (solicitud.Length == 1 && isAlphaBet)
        {
           comprobar = true;
           char letra = char.Parse(solicitud);
           return letra;
        }
        else
        {
            Console.WriteLine("Escriba una letra válida");
        }
    }
    throw new Exception("Ha ocurrido un error inesperado");
};

bool ComprobarLetra(string palabra, char letra)
{

    if (palabra.ToLower().Contains(letra))
        {
            return true;
            
        }
        else
        {
            return false;
        }
}

void DecrementarVidas()
{
    vidas--;
}




void ReemplazarLineas(string palabraOriginal, ref string palabraOculta, char letraIntroducida)
{
    letraIntroducida = Char.ToLower(letraIntroducida);
    string diferencia = palabraOculta;

    StringBuilder nuevaPalabraOculta = new StringBuilder(palabraOculta);

    for (int i = 0; i < palabraOriginal.Length; i++)
    {
        if (Char.ToLower(palabraOriginal[i]) == letraIntroducida) 
        {
            nuevaPalabraOculta[i] = palabraOriginal[i];
        }
    }
    palabraOculta = nuevaPalabraOculta.ToString();
    if (diferencia == palabraOculta)
    {
        DecrementarVidas();
    }
    if (vidas >= 0 && vidas < ahorcado.Length)
    {
        Console.WriteLine(ahorcado[vidas]);
    }
    DibujarLineas(palabraOculta);
}

bool HasGanado(string palabraOriginal, ref string palabraOculta)
{
    if(palabraOriginal == palabraOculta)
    {
        Console.WriteLine("!HAS GANADO¡");
        return true;
    }
    else
    {
        return false;
    }
}
Hangman();
