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
                crear.WriteLine("ID Nombre ApellidoP ApellidoM Tipo_cuentahabiente Crédito/Débito_actual Saldo_máximo NIP Movimientos");
                crear.Close();
            }

            while (continuar)
            {
                int id = 0;
                bool validar = false;
                //Lectura del archivo de texto
                StreamReader lecturaContenido = File.OpenText(archivo);
                string contenido = lecturaContenido.ReadToEnd();
                lecturaContenido.Close();
                string[] filas = contenido.Split("\n");
                string[,] datos = new string[filas.Length, 9];

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
                    Console.WriteLine("¿Qué deseas hacer?\n 1.- Dar de alta un cuentahabiente\n 2.- Dar de baja un cuentahabiente\n 3.- Modificar el crédito máximo de un cuentahabiente \n 4.- Realizar movimientos en una cuenta\n 5.- Ver el contenido del registro\n 6.- Salir");
                    int menu = ValidarEntero(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.WriteLine("Escribe un ID para el cuantahabiente a dar de alta");
                            id = ValidarEntero(Console.ReadLine());

                            while (!validar)
                            {
                                for (int i = 1; i < datos.GetLength(0); i++)
                                {
                                    int aux = Convert.ToInt32(datos[i, 0]);
                                    if (aux == id)
                                    {
                                        Console.WriteLine("ID no válido!!! Este ID ya existe en el registro");
                                        id = ValidarEntero(Console.ReadLine());
                                        validar = !validar;
                                        break;
                                    }
                                }
                                validar = !validar;
                            }
                            validar = false;

                            //Llenado de datos
                            datos[(filas.Length - 1), 0] = Convert.ToString(id);

                            Console.WriteLine("Escribe el nombre del cuantahabiente");
                            datos[(filas.Length - 1), 1] = Console.ReadLine();
                            datos[(filas.Length - 1), 1].Replace(" ", "_");

                            Console.WriteLine("Escribe el apellido paterno");
                            datos[(filas.Length - 1), 2] = Console.ReadLine();
                            datos[(filas.Length - 1), 2].Replace(" ", "_");

                            Console.WriteLine("Escribe el apellido materno");
                            datos[(filas.Length - 1), 3] = Console.ReadLine();
                            datos[(filas.Length - 1), 3].Replace(" ", "_");

                            Console.WriteLine("Escribe el tipo de cuenta\n 'D'.- Débito\n 'C'.- Crédito");
                            while (!validar)
                            {
                                string tipo = Console.ReadLine();

                                switch (tipo.ToLower())
                                {
                                    case "d":
                                        datos[(filas.Length - 1), 4] = "débito";
                                        break;
                                    case "c":
                                        datos[(filas.Length - 1), 4] = "crédito";
                                        break;
                                    default:
                                        Console.WriteLine("Dato no válido!!! Ingresa 'c' o 'd'");
                                        validar = !validar;
                                        break;
                                }
                                validar = !validar;
                            }
                            validar = false;

                            Console.WriteLine($"Escribe el {datos[(filas.Length - 1), 4]} inicial");
                            datos[(filas.Length - 1), 5] = Convert.ToString(ValidarNumero(Console.ReadLine()));

                            Console.WriteLine($"Escribe el saldo máximo de la cuenta");
                            datos[(filas.Length - 1), 6] = Convert.ToString(ValidarNumero(Console.ReadLine()));

                            Console.WriteLine("Introduce el NIP de 4 dígitos para el cuantahabiente");
                            while (!validar)
                            {
                                int nip = ValidarEntero(Console.ReadLine());
                                string nipT = Convert.ToString(nip);
                                //Pendiente de revisión (Comprobación del NIP)
                                if (nipT.Length == 4)
                                {

                                    for (int i = 1; i < datos.GetLength(0); i++)
                                    {
                                        int aux = Convert.ToInt32(datos[i, 7]);
                                        //Comprobar contenido
                                        Console.WriteLine($"{aux} == {nip}??");
                                        if (aux == nip)
                                        {
                                            Console.WriteLine("ID no válido!!! Este NIP ya existe en el registro");
                                            validar = false;
                                            break;
                                        }
                                        else
                                        {
                                            datos[(filas.Length - 1), 7] = nipT;
                                            validar = true;
                                        }                                    
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Dato no válido!!! El número introducido debe tener 4 dígitos");
                                    validar = false;
                                }
                            }

                            datos[(filas.Length - 1), 8] = "0";

                            StreamWriter cambios = File.AppendText(archivo);
                            for (int i = 0; i < datos.GetLength(1); i++)
                            {
                                if (i == datos.GetLength(1) - 1) cambios.Write($"{datos[filas.Length - 1, i]}\n");
                                else cambios.Write($"{datos[filas.Length - 1, i]} ");
                            }

                            cambios.Close();
                            Console.WriteLine("Felicidades!!! Te has registrado con éxito");
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            while (!validar)
                            {
                                Console.WriteLine("¿Qué movimiento deseas realizar?\n 1.- Depósito\n 2.- Transferencia\n 3.- Retiro\n 4.- Compra");
                                int operacion = ValidarEntero(Console.ReadLine());
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
                            for (int i = 0; i < (datos.GetLength(0)); i++)
                            {
                                for (int j = 0; j < datos.GetLength(1); j++)
                                {
                                    if (j == (datos.GetLength(1) - 1)) Console.Write($"{datos[i, j]}\n");
                                    else Console.Write($"{datos[i, j]} ");
                                }
                            }
                            break;
                        case 6:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Dato no válido!!! No hay una operación disponible con ese número");
                            validar = true;
                            break;
                    }
                    validar = !validar;
                }
                validar = false;
            }
        }
        static public double ValidarNumero(string valor)
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
        static public int ValidarEntero(string valor)
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
