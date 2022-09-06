
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            bool entradaValida = false;
            bool sairDoMetodo = false;

            Console.WriteLine("Digite a placa do veículo para estacionar:");

            while (!entradaValida || !sairDoMetodo)
            {
                string placa = Console.ReadLine();
                string padraoDePlaca = @"([A-Z]{3})-(\d{4})";
                entradaValida = Regex.IsMatch(placa, padraoDePlaca, RegexOptions.IgnoreCase);
                sairDoMetodo = Regex.IsMatch(placa, @"q");

                if(sairDoMetodo) break;

                if (entradaValida)
                {
                    Console.WriteLine("Veículo cadastrado com sucesso!");
                    veiculos.Add(placa.ToUpper());
                    break;
                }

                Console.Clear();
                Console.WriteLine("Formato inválido. \n Use o formato XXX-0000 para inserir a placa ou pressione \"q\" para voltar.");

            }
        }

        public void RemoverVeiculo()
        {
            if(!veiculos.Any()) {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }
            
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = horas * this.precoPorHora + this.precoInicial;

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
