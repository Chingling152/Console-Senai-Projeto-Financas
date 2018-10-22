using System;
namespace Senai.Projeto.Financeiro.Classes
{
    
    public static class FolhaDePagamento
    {
        #region Variaveis
        private const double descontoINSS = 0.11;
        private const double descontoIRRF = 0.075;
        private const double valeTransporte = 0.06;
        /// <summary>
        /// Salario minimo do funcionario : 835.50
        /// </summary>
        private const double salarioMinimo = 835.50;
        #endregion

        #region DataBase
        /// <summary>
        /// DataBase onde contem todos os funcionarios.
        /// </summary>
        public static Funcionario[] funcionarios;
        private static string[] nomes = {
            "Carlos","Fred","Diego","Antonio","Lucas","Davi","David","Laura","Claudia","Fernanda","Fabio","Julia","Franklin","João","Sabrina",
            "Gustavo","Gabriela","Mauricio","Aline","Allan","Fernando","Felipe","Karina","Wesley","Paulo","Michael","Pedro","Maria","Luana"
        };
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Cadastra um funcionario onde há um slot vazio no vetor.  
        /// Usa o AlterarSalario() para adicionar o salario
        /// </summary>
        /// <param name="id">O numero do funcionario a ser criado no banco de dados.</param>
        public static void CadastrarFuncionario(int id){
            Console.WriteLine("Digite o nome o funcionario");
            funcionarios[id].id = id;
            funcionarios[id].nome = Console.ReadLine();           
            AlterarSalario(id);
            Relatorio.MensagemSucesso($"Muito bem! O Funcionario {funcionarios[id].nome} foi criado com o id {id}");
        }
        /// <summary>
        /// Modifica um funcionario que existe no vetor
        /// Usa o AlterarSalario() para alterar o salario
        /// </summary>
        /// <param name="id">O numero do funcionario a ser alterado no banco de dado.</param>
        public static void AlterarCadastro(int id){
            Console.WriteLine("Digite o nome o funcionario");
            funcionarios[id].nome = Console.ReadLine();           
            AlterarSalario(id);
            Relatorio.MensagemSucesso($"Muito bem! O Funcionario foi criado com o id {id}");
        }        
        /// <summary>
        /// Altera o salario bruto do funcionario selecionado pela ID.  
        /// </summary>
        /// <param name="id">O numero do funcionario que será alterado o valor do salario.</param>
        public static void AlterarSalario(int id){
            Console.WriteLine($"Digite o valor do salario (bruto) do funcionario {funcionarios[id].nome}");
            double.TryParse(Console.ReadLine(),out funcionarios[id].salarioBruto);

            while(funcionarios[id].salarioBruto < salarioMinimo){       
                Console.WriteLine($"O Salario bruto (R${funcionarios[id].salarioBruto.ToString("N2")}) não pode ser menor do que o salario minimo (R${salarioMinimo.ToString("N2")})");
                Console.WriteLine("Digite denovo o salario bruto");
                double.TryParse(Console.ReadLine(),out funcionarios[id].salarioBruto);
            }
        }
        /// <summary>
        /// Aumenta o salario do funcionario baseado nas seguintes condições:  
        /// Se for menor ou igual a 2 salarios minimos , o aumento será de 15%  
        /// Se for menor ou igual a 4 salarios minimos , o aumento será de 10%  
        /// Se for menor ou igual a 8 salarios minimos , o aumento será de 8%  
        /// Se o salario do funcionario não se encaixa em nenhum das condições acima , o aumento será de 5%  
        /// </summary>
        public static void AumentarSalario(int id){
            float porcentagem = 0.00f;
            if(funcionarios[id].salarioBruto <= salarioMinimo*2){
                porcentagem = 0.15f;
            }else if(funcionarios[id].salarioBruto <= salarioMinimo*4){
                porcentagem = 0.10f;
            }else if(funcionarios[id].salarioBruto <= salarioMinimo*8){
                porcentagem = 0.08f;
            }else{
                porcentagem = 0.05f;
            }
            Relatorio.MensagemSucesso($"O Salario bruto do funcionario {funcionarios[id].nome} foi alterado de {funcionarios[id].salarioBruto} para {funcionarios[id].salarioBruto += funcionarios[id].salarioBruto * porcentagem} (Aumento de {porcentagem*100}%)");
            
        }
        /// <summary>
        /// Mostra todos os dados de um funcionario dentro do vetor.
        /// </summary>
        /// <param name="id">O numero do funcionario a ser exibido</param>
        public static void MostrarFolhaDePagamento(int id){
            if(funcionarios[id] != null){
                Console.WriteLine($"\nFuncionario Nº {id}");
                Console.WriteLine($"Nome : {funcionarios[id].nome}");
                Console.WriteLine($"Salario Bruto : R${funcionarios[id].salarioBruto.ToString("N2")}");   
                Console.WriteLine($"\tDesconto INSS : R${(funcionarios[id].salarioBruto * descontoINSS).ToString("N2")}");       
                Console.WriteLine($"\tDesconto IRRF : R${(funcionarios[id].salarioBruto * descontoIRRF).ToString("N2")}");
                Console.WriteLine($"\tDesconto Vale Transporte : R${(funcionarios[id].salarioBruto * valeTransporte).ToString("N2")}");           
                Console.WriteLine($"\tTotal de Descontos : R${(funcionarios[id].salarioBruto - funcionarios[id].salarioLiquido).ToString("N2")}");
                Console.WriteLine($"Salario Liquido : R${(funcionarios[id].salarioLiquido).ToString("N2")}\n");
            }else{
                Relatorio.TextDecoration("Funcionario não encontrado. Verifique se você digitou o numero corretamente");
            }
        }

        /// <summary>
        /// Mostra o total de custos com base no salario bruto de todos os funcionarios.
        /// </summary>
        public static void TotalCustosBruto(){
            double total = 0;
            foreach(Funcionario item in funcionarios){
                if(item!=null){
                    total += item.salarioBruto;
                }else{
                    continue;
                }
            }
            Console.WriteLine($"O custo bruto total é de R${total.ToString("N2")}");
        }
        /// <summary>
        /// Mostra o total de custos com base no salario liquido de todos os funcionarios.
        /// </summary>
        public static void TotalCustosLiquido(){
            double total = 0;
            foreach(Funcionario item in funcionarios){
                if (item!=null){
                    total += item.salarioLiquido;
                }else{
                    continue;
                }
            }
            Console.WriteLine($"O custo liquido total é de R${total.ToString("N2")}");
        }
        /// <summary>
        /// Procura o funcionario com o maior salario (bruto) e mostra todas as informações dele
        /// </summary>
        public static void MaiorSalario(){           
            int id = VerSalario();  
            Relatorio.TextDecoration("Funcionario com o maior salario");
            MostrarFolhaDePagamento(id);
        }
        /// <summary>
        /// Procura o funcionario com o menor salario (bruto), baseando-se no funcionario com o maior salario.
        /// </summary>
        public static void MenorSalario(){
            double salario = funcionarios[VerSalario()].salarioBruto;
            int id = VerSalario();
            foreach(Funcionario item in funcionarios){
                if(item != null){
                    if(item.salarioBruto < salario){                        
                        salario = item.salarioBruto;
                        id = item.id;
                    }
                }
            }
            Relatorio.TextDecoration("Funcionario com o menor salario");
            MostrarFolhaDePagamento(id);          
        }
        /// <summary>
        /// Procura o id do funcionario que tem o maior salario.  
        /// </summary>
        /// <returns>Um numero inteiro com o ID do funcionario</returns>
        private static int VerSalario(){
            double salario = salarioMinimo;
            int id = 0;
            foreach(Funcionario item in funcionarios){
                if(item != null){
                    if(item.salarioBruto > salario){
                        salario = item.salarioBruto;
                        id = item.id;
                    }
                }
            }
            return id;
        }
        /// <summary>
        /// (Metodo apenas usado pela propriedade "salarioLiquido" na classe "Funcionario").    
        /// Calcula o salario liquido com base no salario bruto do funcionario e retorna para a propriedade "salarioLiquido".  
        /// </summary>
        /// <param name="func">Funcionario que terá o salario liquido a  ser calculado</param>
        /// <returns>Retorna o salario liquido com influencia do INSS , IRFF e vale transporte</returns>
        public static double SalarioLiquido(Funcionario func){ 
            return func.salarioBruto - ((func.salarioBruto * descontoINSS) + (func.salarioBruto * descontoIRRF) + (func.salarioBruto * valeTransporte));
        }

        /// <summary>
        /// Gera um funcionario com nome aleatorio no indice selecionado.
        /// </summary>
        /// <param name="id">ID do funcionario gerado</param>
        public static void GerarDataBase(int ID){
            Random rdm = new Random();
            funcionarios[ID] = new Funcionario(){
                id = ID,
                nome = nomes[rdm.Next(0,nomes.Length)],
                salarioBruto = (double)rdm.Next((int)salarioMinimo,10000)
            };
            Console.WriteLine($"Criado o funcionario {funcionarios[ID].nome} com o ID {ID} e salario bruto de R${funcionarios[ID].salarioBruto.ToString("N2")}");
        }

        #endregion

    }
}