using CadastroDeSeries.Interfaces;
using System.Collections.Generic;
using System;

namespace CadastroDeSeries.Classes
{
    // Controla a comunicação com o registro
    public class MidiaRepositorio : IRepositorio<Midia>
    {
        private List<Midia> listaSerie = new List<Midia>();
        // Atualiza dados do registro
        public void Atualiza(int id, Midia entidade) => listaSerie[id] = entidade;
        // Exclui dados do registro
        public void Exclui(int id) => listaSerie[id].Excluir();
        // Insere dados no registro
        public void Insere(Midia entidade) => listaSerie.Add(entidade);
        // Lista dados no registro
        public List<Midia> Lista() => listaSerie;
        // Informa o proximo ID após o ultimo da lista
        public int ProximoId() => listaSerie.Count;
        // Retorna o valor do registro pelo ID
        public Midia RetornaPorId(int id) => listaSerie[id];
    }
}