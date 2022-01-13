using System;
using CadastroDeSeries.Classes;
using CadastroDeSeries.Enuns;

namespace CadastroDeSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            // Demonstra e obtem o valor inserido pelo usuario
            string opcaoUsuario = ObterOpcaoUsuario();
            // Filtra e aplica a função escolhida pelo usuario
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        // Marca o registro da serie como excluido
        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da série: ");
            int.TryParse(Console.ReadLine(), out int indiceSerie);
            repositorio.Exclui(indiceSerie);
        }
        // Visualiza o registro geral da serie
        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int.TryParse(Console.ReadLine(), out int indiceserie);
            Serie serie = repositorio.RetornaPorId(indiceserie);
            Console.WriteLine(serie);
        }
        // Atualiza o registro da serie escolhida
        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int.TryParse(Console.ReadLine(), out int indiceSerie);
            foreach (int index in Enum.GetValues(typeof(Genero))) Console.WriteLine($"{index} - {Enum.GetName(typeof(Genero), index)}"); // Captura valores no Enum
            Console.Write("Digite o gênero entre as opções acima: ");
            int.TryParse(Console.ReadLine(), out int entradaGenero);
            Console.Write("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano de início da série: ");
            int.TryParse(Console.ReadLine(), out int entradaAno);
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        // Lista todas as series no registro
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            List<Serie> lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (Serie serie in lista)
            {
                bool excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()} {(excluido ? "*Excluído*" : "")}");
            }
        }
        // Insere novas series no registro
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach (int index in Enum.GetValues(typeof(Genero))) Console.WriteLine($"{index} - {Enum.GetName(typeof(Genero), index)}"); // Captura valores no Enum
            Console.Write("Digite o gênero entre as opções acima: ");
            int.TryParse(Console.ReadLine(), out int entradaGenero);
            Console.Write("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano de início da série: ");
            int.TryParse(Console.ReadLine(), out int entradaAno);
            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }
        // Mostra o menu de opções para o usuario e retorna o valor selecionado pelo mesmo
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO série a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}