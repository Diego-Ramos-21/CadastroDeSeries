using System;
using CadastroDeSeries.Classes;
using CadastroDeSeries.Enuns;

namespace CadastroDeSeries
{
    class Program
    {
        static MidiaRepositorio repositorio = new MidiaRepositorio();
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
                        ListarMidia();
                        break;
                    case "2":
                        InserirMidia();
                        break;
                    case "3":
                        AtualizarMidia();
                        break;
                    case "4":
                        ExcluirMidia();
                        break;
                    case "5":
                        VisualizarMidia();
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
        // Marca o registro da mídia como excluido
        private static void ExcluirMidia()
        {
            Console.Write("Digite o ID da mídia: ");
            int.TryParse(Console.ReadLine(), out int indiceMidia);
            repositorio.Exclui(indiceMidia);
        }
        // Visualiza o registro geral da mídia
        private static void VisualizarMidia()
        {
            Console.Write("Digite o ID da mídia: ");
            int.TryParse(Console.ReadLine(), out int indiceMidia);
            Midia midia = repositorio.RetornaPorId(indiceMidia);
            Console.WriteLine(midia);
        }
        // Atualiza o registro da mídia escolhida
        private static void AtualizarMidia()
        {
            Console.Write("Digite o ID da mídia: ");
            int.TryParse(Console.ReadLine(), out int indiceMidia);
            foreach (int index in Enum.GetValues(typeof(Genero))) Console.WriteLine($"{index} - {Enum.GetName(typeof(Genero), index)}"); // Captura valores no Enum genero
            Console.Write("Digite o gênero entre as opções acima: ");
            int.TryParse(Console.ReadLine(), out int entradaGenero);
            foreach (int index in Enum.GetValues(typeof(Categoria))) Console.WriteLine($"{index} - {Enum.GetName(typeof(Categoria), index)}"); // Captura valores no Enum de categoria
            Console.Write("Digite a categoria entre as opções acima: ");
            int.TryParse(Console.ReadLine(), out int entradaCategoria);
            Console.Write("Digite o Título da mídia: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano de início da mídia: ");
            int.TryParse(Console.ReadLine(), out int entradaAno);
            Console.Write("Digite a descrição da mídia: ");
            string entradaDescricao = Console.ReadLine();
            Midia atualizaMidia = new Midia(id: indiceMidia,
                                            genero: (Genero)entradaGenero,
                                            categoria: (Categoria)entradaCategoria,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceMidia, atualizaMidia);
        }
        // Lista todas as mídia no registro
        private static void ListarMidia()
        {
            Console.WriteLine("Listar mídia");
            List<Midia> lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma mídia cadastrada");
                return;
            }
            foreach (Midia midia in lista)
            {
                bool excluido = midia.retornaExcluido();
                Console.WriteLine($"#ID {midia.retornaId()}: - {midia.retornaTitulo()} {(excluido ? "*Excluído*" : "")}");
            }
        }
        // Insere novas mídia no registro
        private static void InserirMidia()
        {
            Console.WriteLine("Inserir nova mídia ");
            foreach (int index in Enum.GetValues(typeof(Genero))) Console.WriteLine($"{index} - {Enum.GetName(typeof(Genero), index)}"); // Captura valores no Enum de genero
            Console.Write("Digite o gênero entre as opções acima: ");
            int.TryParse(Console.ReadLine(), out int entradaGenero);
            foreach (int index in Enum.GetValues(typeof(Categoria))) Console.WriteLine($"{index} - {Enum.GetName(typeof(Categoria), index)}"); // Captura valores no Enum de categoria
            Console.Write("Digite a categoria entre as opções acima: ");
            int.TryParse(Console.ReadLine(), out int entradaCategoria);
            Console.Write("Digite o Título da mídia: ");
            string entradaTitulo = Console.ReadLine();
            Console.Write("Digite o Ano de início da mídia: ");
            int.TryParse(Console.ReadLine(), out int entradaAno);
            Console.Write("Digite a descrição da mídia: ");
            string entradaDescricao = Console.ReadLine();
            Midia novaMidia = new Midia(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        categoria: (Categoria)entradaCategoria,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaMidia);
        }
        // Mostra o menu de opções para o usuario e retorna o valor selecionado pelo mesmo
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO série a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar mídias");
            Console.WriteLine("2- Inserir nova mídia");
            Console.WriteLine("3- Atualizar mídia");
            Console.WriteLine("4- Excluir mídia");
            Console.WriteLine("5- Visualizar mídia");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}