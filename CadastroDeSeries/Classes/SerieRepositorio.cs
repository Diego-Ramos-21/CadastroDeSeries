using CadastroDeSeries.Interfaces;
using System.Collections.Generic;
using System;

namespace CadastroDeSeries.Classes
{
    // Controla a comunicação com o registro
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        // Atualiza dados do registro
        public void Atualiza(int id, Serie entidade) => listaSerie[id] = entidade;
        // Exclui dados do registro
        public void Exclui(int id) => listaSerie[id].Excluir();
        // Insere dados no registro
        public void Insere(Serie entidade) => listaSerie.Add(entidade);
        // Lista dados no registro
        public List<Serie> Lista() => listaSerie;
        // Informa o proximo ID após o ultimo da lista
        public int ProximoId() => listaSerie.Count;
        // Retorna o valor do registro pelo ID
        public Serie RetornaPorId(int id) => listaSerie[id];
    }
}