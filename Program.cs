using System;
using System.IO;

namespace proyecto_final
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            //Creación del archivo de texto
            string archivo = "registro.txt";
            if (!File.Exists(archivo))
            {
                StreamWriter crear = File.CreateText(archivo);
                crear.WriteLine("ID Nombre Tipo_cuentahabiente Crédito/Débito_actual Saldo_máximo Movimientos");
                crear.Close();
            }

            while (continuar)
            {
                bool validar = false;
                //Lectura del archivo
                StreamReader lecturaContenido = File.OpenText(archivo);
                string contenido = lecturaContenido.ReadToEnd();
                lecturaContenido.Close();

                //creación de matriz
                string[] filas = contenido.Split("\n");
                string[,] datos = new string[filas.Length, 6];

                //Llenado de matriz
                for (int i = 0; i < (datos.GetLength(0) - 1); i++)
                {
                    string[] filaActual = filas[i].Split(" ");
                    for (int j = 0; j < datos.GetLength(1); j++)
                    {
                        datos[i, j] = filaActual[j];
                    }
                }

                while (!validar)
                {
                    Console.WriteLine("¿Qué deseas hacer?\n 1.- Dar de alta un cuentahabiente\n 2.- Dar de baja un cuentahabiente\n 3.- Modificar el crédito máximo de un cuentahabiente \n 4.- Realizar movimientos en una cuenta\n 5.- Salir");
                    int menu = ValidarNumero(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:
                            while (!validar)
                            {
                                Console.WriteLine("¿Qué movimiento deseas realizar?\n 1.- Depósito\n 2.- Transferencia\n 3.- Retiro\n 4.- Compra");
                                int operacion = ValidarNumero(Console.ReadLine());

                                switch (operacion)
                                {
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                    case 3:

                                        break;
                                    case 4:

                                        break;
                                    default:
                                        Console.WriteLine("Dato no válido!!! No hay una operación con ese número");
                                        validar = true;
                                        break;
                                }
                                validar = !validar;
                            }
                            validar = false;
                            break;
                        case 5:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Dato no válido!!! No hay una operación con ese número");
                            validar = true;
                            break;
                    }
                    validar = !validar;
                }
                validar = false;
            }
        }
        static public int ValidarNumero(string valor)
        {
            int numero = 0;
            bool validar = false;
            while (!validar)
            {
                try
                {
                    numero = Convert.ToInt32(valor);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Dato no válido!!! Ingresa un número entero:");
                    valor = Console.ReadLine();
                    validar = true;
                }
                validar = !validar;
            }
            validar = false;
            return numero;
        }
    }
}
