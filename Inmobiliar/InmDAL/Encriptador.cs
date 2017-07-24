using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InmDAL
{
    /// <summary>
    /// Encripta cadenas de texto
    /// </summary>
    public class Encriptador
    {
        private static string patronBusqueda = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstvuwxyz1234567890";
        private static string patronEncripta = "ACEsHfghkBlm5TñoxabNOPQ67ZSRVeD1F234yGrqtWXcwJKLMnijY0vUuzIdÑ89p";

        public Encriptador() { }

        public static string encriptarCadena(string cadena)
        {
            string resultado = "";

            for (int i = 0; i < cadena.Length - 1; i++)
            {
                resultado += encriptarCaracter(cadena.Substring(i, 1), cadena.Length, i);
            }

            return resultado;
        }

        private static string encriptarCaracter(string caracter, int variable, int aIndice)
        {
            int indice;

            if (patronBusqueda.IndexOf(caracter) != -1)
            {
                indice = ((patronBusqueda.IndexOf(caracter) + variable + aIndice) % patronBusqueda.Length);
                return patronEncripta.Substring(indice, 1);
            }

            return caracter;
        }

        public static string desencriptarCadena(string cadena)
        {
            int i;
            string resultado = "";

            for (i = 0; i < cadena.Length - 1; i++)
            {
                resultado += desencriptarCaracter(cadena.Substring(i, 1), cadena.Length, i);
            }

            return resultado;
        }

        private static string desencriptarCaracter(string caracter, int variable, int a_indice)
        {
            int indice;

            if (patronEncripta.IndexOf(caracter) != -1)
            {
                if ((patronEncripta.IndexOf(caracter) - variable - a_indice) > 0)
                {
                    indice = ((patronEncripta.IndexOf(caracter) - variable - a_indice) % patronEncripta.Length);
                }
                else
                {
                    indice = (patronBusqueda.Length) + ((patronEncripta.IndexOf(caracter) - variable - a_indice) % patronEncripta.Length);
                }

                indice = (indice % patronEncripta.Length);

                return patronBusqueda.Substring(indice, 1);
            }
            else
            {
                return caracter;
            }
        }


    }
}
