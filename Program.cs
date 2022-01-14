using System;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace Archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            archivos();
        }
        static void archivos ()
        {
            var dir = Combine(CurrentDirectory, "Archivos");//Se crea la ruta de un directorio
            CreateDirectory(dir);//Se crea el directorio

            string archivoTexto = Combine(dir, "Archivo.txt");//Se crea la ruta del archivo a crear.  | camino fuente
            string respaldoTexto = Combine(dir, "Archivo.bak");//Se crea la ruta del respaldo.        | camino destino

            WriteLine($"Trabajando con archivo fuente: {archivoTexto}");
            WriteLine($"\nTrabajando con archivo destino: {respaldoTexto}");
            WriteLine($"\nExiste {archivoTexto}: {File.Exists(archivoTexto)}");//Revisa si el archivo existe

            if(File.Exists(archivoTexto))//En caso de que haya un archivo con el mismo nombre, se interrumpe el programa
            {
                WriteLine("\nEl archivo que intenta crear o sobreescribiria ya existe, por lo que no se puede continuar con ese nombre.");
            }
            else
            {
                //Escribimos el archivo
                StreamWriter escritorTexto = File.CreateText(archivoTexto);
                escritorTexto.WriteLine("Esto es una prueba");
                escritorTexto.Close();

                WriteLine($"\nExiste {respaldoTexto}: {File.Exists(respaldoTexto)}");//Revisa si el archivo respaldo existe
                WriteLine($"\nCreando copia de: {archivoTexto} a {respaldoTexto}");
                File.Copy(archivoTexto, respaldoTexto, true);//Se copia el archivo al respaldo .bak

                if(File.Exists(respaldoTexto))//Verifica si existe el archivo de respaldo
                {
                    WriteLine($"\nEl archivo: {archivoTexto} se eliminara...");
                        File.Delete(archivoTexto);
                }
                else
                    WriteLine($"\nEl archivo: {archivoTexto} no puede ser borrado porque no tiene un respaldo");
                
                WriteLine($"\nEl contenido del resplado es\n");
                WriteLine(File.ReadAllText(respaldoTexto));//Leemos el .bak
            }
        }
    }
}