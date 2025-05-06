using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AseguraYa
{
    public class _686DP_ExpresionesRegulares
    {
        public bool _686DPEsNumero(string texto)
        {
            try
            {
                if (string.IsNullOrEmpty(texto)) return false;

                return Regex.IsMatch(texto, @"^\d+$");
            }
            catch (Exception)
            {
                throw new Exception("Ingresar campos numéricos unicamente");
            }
        }
        public bool _686DPEsEmail(string texto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(texto)) return false;
                return Regex.IsMatch(texto, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }
            catch (Exception)
            {
                throw new Exception("Ingresar un email válido.");
            }
        }

        public bool _686DPEsSoloLetras(string texto)
        {
            try
            {
                if (string.IsNullOrEmpty(texto)) return false;
                return Regex.IsMatch(texto, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
            }
            catch (Exception)
            {
                throw new Exception("Ingresar solo letras.");
            }
        }

    }
}
