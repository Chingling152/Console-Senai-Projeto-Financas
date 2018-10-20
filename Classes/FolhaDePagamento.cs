using System;
namespace Senai.Projeto.Financeiro.Classes
{
    
    public class FolhaDePagamento
    {
        #region Variaveis
        private const double descontoINSS = 0.11;
        private const double descontoIRFF = 0.075;
        private const double valeTransporte = 0.06;
        /// <summary>
        /// Salario minimo do funcionario : 835.50
        /// </summary>
        private const double salarioMinimo = 834.50;
        #endregion

        #region DataBase
        /// <summary>
        /// DataBase onde contem todos os funcionarios.
        /// </summary>
        public Funcionario[] funcionarios;

        private string[] nomes = {
            "Carlos","Fred","Diego","Antonio","Lucas","Davi","David","Laura","Claudia","Fernanda","Fabio","Julia","Franklin","João","Sabrina",
            "Gustavo","Gabriela","Mauricio","Aline","Allan","Fernando","Felipe","Karina","Wesley","Paulo","Michael","Pedro","Maria","Luana"
        };
        #endregion

        #region Metodos Publicos
        /// <summary>
        /// Cadastra um funcionario onde há um slot vazio no vetor.  
        /// Usa o AlterarSalario() para adcionar o salario
        /// </summary>
        /// <param name="id">O numero do funcionario à ser criado no banco de dados.</param>
        public void CadastrarFuncionario(int id){
            Console.WriteLine("Digite o nome o funcionario");
            funcionarios[id].nome = Console.ReadLine();           
            AlterarSalario(id);
            Program.MensagemSucesso($"Muito bem! O Funcionario {funcionarios[id].nome} foi criado com o id {id}");
        }
        /// <summary>
        /// Modifica um funcionario que existe no vetor
        /// Usa o AlterarSalario() para alterar o salario
        /// </summary>
        /// <param name="id">O numero do funcionario à ser alterado no banco de dado.</param>
        public void AlterarCadastro(int id){
            Console.WriteLine("Digite o nome o funcionario");
            funcionarios[id].nome = Console.ReadLine();           
            AlterarSalario(id);
            Program.MensagemSucesso($"Muito bem! O Funcionario foi criado com o id {id}");
        }        
        /// <summary>
        /// Altera o salario bruto do funcionario selecionado pela ID.  
        /// </summary>
        /// <param name="id">O numero do funcionario que será alterado o valor do salario.</param>
        public void AlterarSalario(int id){
            Console.WriteLine($"Digite o valor do salario (bruto) do funcionario {funcionarios[id].nome}");
            double.TryParse(Console.ReadLine(),out funcionarios[id].salarioBruto);

            while(funcionarios[id].salarioBruto < salarioMinimo){       
                Console.WriteLine($"O Salario bruto ({funcionarios[id].salarioBruto.ToString("N2")}) não pode ser menor do que o salario minimo ({salarioMinimo.ToString("N2")})");
                Console.WriteLine("Digite denovo o salario bruto");
                double.TryParse(Console.ReadLine(),out funcionarios[id].salarioBruto);
            }
        }
        /// <summary>
        /// Mostra todos os dados de um funcionario dentro do vetor.
        /// </summary>
        /// <param name="id">O numero do funcionario a ser exibido</param>
        public void MostrarFolhaDePagamento(int id){
            if(funcionarios[id] != null){
                Console.WriteLine($"\nFuncionario Nº {id}");
                Console.WriteLine($"Nome : {funcionarios[id].nome}");
                Console.WriteLine($"Salario Bruto : R${funcionarios[id].salarioBruto.ToString("N2")}");               
                Console.WriteLine($"Total de Descontos : R${(funcionarios[id].salarioBruto - funcionarios[id].salarioLiquido).ToString("N2")}");
                Console.WriteLine($"Salario Liquido : R${(funcionarios[id].salarioLiquido).ToString("N2")}\n");
            }else{
                Program.TextDecoration("Funcionario não encontrado. Verifique se você digitou o numero corretamente");
            }
        }

        /// <summary>
        /// Mostra o total de custos com base no salario bruto de todos os funcionarios.
        /// </summary>
        public void TotalCustosBruto(){
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
        public void TotalCustosLiquido(){
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
        public void MaiorSalario(){           
            int id = maiorSalario();  
            Program.TextDecoration("Funcionario com o maior salario");
            MostrarFolhaDePagamento(id);
        }
        /// <summary>
        /// Procura o id do funcionario que tem o maior salario.  
        /// </summary>
        /// <returns>Um numero inteiro com o ID do funcionario</returns>
        public int maiorSalario(){
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
        /// Procura o funcionario com o menor salario (bruto), baseando-se no funcionario com o maior salario.
        /// </summary>
        public void MenorSalario(){
            double salario = funcionarios[maiorSalario()].salarioBruto;
            int id = 0;
            foreach(Funcionario item in funcionarios){
                if(item != null){
                    if(item.salarioBruto < salario){
                        salario = item.salarioBruto;
                        id = item.id;
                    }
                }
            }
            Program.TextDecoration("Funcionario com o menor salario");
            MostrarFolhaDePagamento(id);          
        }
        /// <summary>
        /// (Metodo apenas usado pela propriedade "salarioLiquido" na classe "Funcionario").    
        /// Calcula o salario liquido com base no salario bruto do funcionario e retorna para a propriedade "salarioLiquido".  
        /// </summary>
        /// <param name="func">Funcionario que terá o salario liquido a  ser calculado</param>
        /// <returns>Retorna o salario liquido com influencia do INSS , IRFF e vale transporte</returns>
        public double SalarioLiquido(Funcionario func){ 
            return func.salarioBruto - ((func.salarioBruto * descontoINSS) + (func.salarioBruto * descontoIRFF) + (func.salarioBruto * valeTransporte));
        }
        /// <summary>
        /// Mostra que não existe funcionario com o ID inserido pelo usuario
        /// </summary>
        /// <param name="id">Posição do vetor que está com valor nulo</param>
        public void FuncionarioNaoEncontrado(int id){
            Program.TextDecoration($"O funcionario com o ID {id} não foi encontrado");
        }

        /// <summary>
        /// Gera um funcionario com nome aleatorio no indice selecionado.
        /// </summary>
        /// <param name="id">ID do funcionario gerado</param>
        public void GerarDataBase(int id){
            Random rdm = new Random();
            funcionarios[id] = new Funcionario();
            funcionarios[id].id = id;
            funcionarios[id].nome = nomes[rdm.Next(0,nomes.Length)];
            funcionarios[id].salarioBruto = (double)rdm.Next((int)salarioMinimo,10000);
            Console.WriteLine($"Criado o funcionario {funcionarios[id].nome} com o ID {id} e salario bruto de R${funcionarios[id].salarioBruto.ToString("N2")}");
        }

        #endregion

    }
}