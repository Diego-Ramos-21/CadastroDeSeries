using System;
using CadastroDeSeries.Enuns;

namespace CadastroDeSeries.Classes
{
    public class Midia : EntidadeBase
    {
        private Genero Genero { get; set; }
        private Categoria Categoria { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        public Midia(int id, Genero genero, Categoria categoria, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Categoria = categoria;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        // Altera a formatação da classe midia ao ser passada para string
        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += $"Gênero: {this.Genero}{Environment.NewLine}";
            retorno += $"Categoria: {this.Categoria}{Environment.NewLine}";
            retorno += $"Título: {this.Titulo}{Environment.NewLine}";
            retorno += $"Descrição: {this.Descricao}{Environment.NewLine}";
            retorno += $"Ano de Início: {this.Ano}{Environment.NewLine}";
            retorno += $"Excluído: {this.Excluido}";
            return retorno;
        }
        // Retorna o titulo da midia
        public string retornaTitulo() => this.Titulo;
        // Retorna o ID da midia
        public int retornaId() => this.Id;
        // Retorna se a midia está excluida
        public bool retornaExcluido() => this.Excluido;
        // Marca midia como excluida
        public void Excluir() => this.Excluido = true;
    }
}