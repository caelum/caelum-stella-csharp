using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Stella.CSharp.Format
{
    /**
     * IFormatter é responsável por transfomar cadeias sem formatação em cadeias
     * formatadas e vice-versa.
     */
    public interface IFormatter
    {
        /// <summary>
        /// Formata uma cadeia.
        /// </summary>
        /// <param name="value">cadeia sem formatação</param>
        /// <returns>cadeia formatada</returns>
        string Format(String value);

        /// <summary>
        /// Remove a formatação de uma cadeia.
        /// </summary>
        /// <param name="value">cadeia formatada</param>
        /// <returns>cadeia sem formato</returns>
        string Unformat(String value);

        /// <summary>
        /// Verifica se uma cadeia está no formato com o qual o formatador trabalha.
        /// </summary>
        /// <param name="value">cadeia a ser verificada</param>
        /// <returns>true, se estiver de acordo com o formato</returns>
        bool IsFormatted(String value);

        /// <summary>
        /// Verifica se uma cadeia pode ser formatada por esse formatador.
        /// </summary>
        /// <param name="value">cadeia a ser verificada</param>
        /// <returns>true, se este formatador pode formatar a cadeia dada.</returns>
        bool CanBeFormatted(String value);
    }
}
