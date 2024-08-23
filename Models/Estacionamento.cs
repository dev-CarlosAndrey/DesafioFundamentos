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
        Console.WriteLine("Digite a placa do veículo para estacionar: ");
        string placa = Console.ReadLine();

        if(placa.Length != 7 || !placa.All(char.IsLetterOrDigit))
        {
            Console.WriteLine("Por favor digite a placa corretamente.");
            AdicionarVeiculo();
            return;
        }

        if (veiculos.Contains(placa))
        {
            Console.WriteLine("Esta placa já está registrada no estacionamento. Tente novamente com uma placa diferente.");
            AdicionarVeiculo();
            return;
        }

        veiculos.Add(placa);
        Console.WriteLine($"Veiculo com a placa {placa} adicionado.");
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Digite a placa do veiculo para remover: ");
        string placa = Console.ReadLine();

        if(veiculos.Any(x=> x.ToUpper() == placa.ToUpper()))
        {
            Console.WriteLine("Digite a quantidade de horas que o veiculo permaneceu estacionado: ");

            int horas = int.Parse(Console.ReadLine());
            decimal valorTotal = precoInicial + precoPorHora * horas;

            veiculos.Remove(placa);
            Console.WriteLine($"O veiculo com {placa} foi removido e o preço total foi de: R$ {valorTotal}");
        }
        else
        {
            Console.WriteLine("Desculpe, esse veiculo não está estacioado aqui. Confira se digitou a placa corretamente.");
        }
    }

    public void ListarVeiculos()
    {
        if(veiculos.Any())
        {
            Console.WriteLine("Os veiculos estacionados são: ");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo);
            }
        }
            else
            {
            Console.WriteLine("Não há veiculos estacionados.");
            }
        }
    }
}