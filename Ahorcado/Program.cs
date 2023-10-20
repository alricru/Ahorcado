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
    Console.WriteLine(aleatoria);
    string censurada = OcultarPalabra(aleatoria);
    DibujarLineas(censurada);
    char letra = SolicitarLetra();
    ComprobarLetra(aleatoria, letra);
}


void MostrarCabecera()
{
    Console.WriteLine("+-------------------------------------+");
    Console.WriteLine("|  +---+    -----------------         |");
    Console.WriteLine("|  |   |    JUEGO:AHORCADO            |");
    Console.WriteLine("|      |    LENGUAJE:C#               |");
    Console.WriteLine("|      |    AUTOR: ALEJANDRO R.C.     |");
    Console.WriteLine("|      |    -----------------         |");
    Console.WriteLine("|      |   PROGRAMACIÓN Y MOTORES     |");
    Console.WriteLine("+-------------------------------------+");

    Console.WriteLine("--------------------");
    Console.WriteLine("JUEGO DEL AHORCADO");
    Console.WriteLine("--------------------");
    Console.WriteLine("Adivina la palabra");
    Console.WriteLine("--------------------");
    Console.WriteLine("PALABRA");


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
            Console.WriteLine("Velda");
            return true;
            
        }
        else
        {
            Console.WriteLine("Mentira");
            return false;
        }
}

void DecrementarVidas()
{
    vidas--;
}




//13
//int longitudPalabra = palabra.Length;
//for (int i = 0; i < longitudPalabra; i++)
//{
//    if (palabraOriginal[i] == letraIntroducida)
//    {
//        StringBuilder guion = new StringBuilder(palabraOculta);
//        guion[i] = letraIntroducida;
//        palabraOculta = guion.ToString();
//    }

//}
Hangman();
