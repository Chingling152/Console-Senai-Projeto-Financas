using System;
using System.Text;
using Senai.Projeto.Financeiro.Classes;

namespace Senai.Projeto.Financeiro
{
    class Program  
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            sbyte escolha = 0;

            const int tamanhoDataBase = 1001;
            FolhaDePagamento.funcionarios = new Funcionario[tamanhoDataBase];
            Relatorio.MensagemSucesso("Projeto Finanças");
                  
            do{
                Console.WriteLine("");
                Relatorio.TextDecoration("O Que deseja fazer?");
                Console.WriteLine($"\n1- Cadastrar um Funcionario\n2- Exibir Folha De Pagamento\n3- Exibir total de custos bruto da folha de pagamento\n4- Aumentar o salario de um funcionario\n5- Exibir total de custos liquido da folha de pagamento\n6- Ver maior salario\n7- Ver menor salario\n8- Alterar cadastro\n9- Remover cadastro\n0 - Sair\n10- Criar DataBase (Aleatorio)\n11- Listar funcionarios\n");
                sbyte.TryParse(Console.ReadLine().ToString(),out escolha);
                int id = 0;

                switch(escolha){
                    case 1://   Cadastrar funcionario   //
                        for(int i = 0 ; i < tamanhoDataBase-1;i++){
                            if(FolhaDePagamento.funcionarios[i] == null){
                                FolhaDePagamento.funcionarios[i] = new Funcionario();
                                FolhaDePagamento.CadastrarFuncionario(i);
                                break;
                            }
                        }
                        break;
                    case 2://   Exibir folha de pagamento   //
                        Relatorio.TextDecoration("Digite o numero de identificação do funcionario");
                        int.TryParse(Console.ReadLine(),out id);
                        if(FolhaDePagamento.funcionarios[id] != null){
                            FolhaDePagamento.MostrarFolhaDePagamento(id);
                        }else{
                            Relatorio.FuncionarioNaoEncontrado(id);
                        }
                        break;
                    case 3://   Exibir total de custos bruto    //
                        FolhaDePagamento.TotalCustosBruto();
                        break;
                    case 4://   Aumentar Salario de um funcionario  //
                        Relatorio.TextDecoration("Informe o numero de identificação do funcionario no qual você quer aumentar o salario");
                        int.TryParse(Console.ReadLine(),out id);
                        if(id < 1001 && id >= 0){
                            if(FolhaDePagamento.funcionarios[id] != null){
                                FolhaDePagamento.AumentarSalario(id);
                            }else{
                                Relatorio.FuncionarioNaoEncontrado(id);                                
                            }
                        }else{
                            Relatorio.TextDecoration($"O valor inserido ({id}) não está dentro dos limites do banco de dados");
                        }
                        break;
                    case 5://   Exibir total de custos liquido da folha de pagamento    //
                        FolhaDePagamento.TotalCustosLiquido();
                        break;
                    case 6://   Ver maior salario   //
                        FolhaDePagamento.MaiorSalario();
                        break;
                    case 7://   Ver menor salario   //
                        FolhaDePagamento.MenorSalario();
                        break;
                    case 8://   Alterar cadastro    //
                        Console.WriteLine("Digite o ID do funcionario que você quer alterar");
                        int.TryParse(Console.ReadLine(),out id);
                        if(id < tamanhoDataBase && id >= 0){
                            if(FolhaDePagamento.funcionarios[id] != null){
                                FolhaDePagamento.AlterarCadastro(id);
                            }else{
                                Relatorio.TextDecoration($"Não existe nenhum funcionario cadastrado no ID {id}.");
                                Console.WriteLine("\nDeseja cadastar um funcionario nesse ID?\n1- Sim\n2- Não");
                                sbyte.TryParse(Console.ReadLine(),out sbyte esc);
                                switch (esc){
                                    case 1:
                                        FolhaDePagamento.CadastrarFuncionario(id);
                                        break;
                                    default:
                                        //porra nenhuma acontece ;-;
                                        break;
                                }
                            }
                        }else{
                            Relatorio.TextDecoration($"O valor inserido ({id}) não está dentro dos limites do banco de dados");
                        }
                        break;
                    case 9://   Remover cadastro    //
                        Console.WriteLine("Digite o ID do funcionario que você quer remover");
                        int.TryParse(Console.ReadLine(),out id);
                        if(id < tamanhoDataBase && id >= 0){
                            if(FolhaDePagamento.funcionarios[id] != null){
                                Console.WriteLine($"\nDeseja mesmo excluir o Funcionario {FolhaDePagamento.funcionarios[id].nome} no indice {id}?\n1- Sim\n2- Não");
                                sbyte.TryParse(Console.ReadLine(),out sbyte esc);
                                switch (esc){
                                    case 1:                                       
                                        Relatorio.MensagemSucesso($"Funcionario {FolhaDePagamento.funcionarios[id].nome} removido com sucesso");
                                        FolhaDePagamento.funcionarios[id] = null;
                                        break;
                                    default:
                                        //porra nenhuma acontece ;-;
                                        break;
                                }
                            }else{
                                Relatorio.TextDecoration($"Não há funcionario no indice {id}.");
                            }
                        }else{
                            Relatorio.TextDecoration($"O valor inserido ({id}) não está dentro dos limites do banco de dados");
                        }
                        break;
                    case 10:// Gerar funcionarios aleatorio //
                        Relatorio.TextDecoration($"Insira a quantidade de funcionarios");
                        Console.WriteLine($"um numero entre 1 e {tamanhoDataBase}");
                        int.TryParse(Console.ReadLine(),out int valor);    

                        FolhaDePagamento.funcionarios = new Funcionario[tamanhoDataBase];   
                        
                        if(valor < tamanhoDataBase && valor > 0){
                            for(int i = 0 ; i < valor;i++){
                                FolhaDePagamento.GerarDataBase(i);
                            }
                        }else{
                            Relatorio.TextDecoration("O numero inserido não é valido.");
                        }
                        break;
                    case 11://  Listar Funcionario  //
                        foreach(Funcionario item in FolhaDePagamento.funcionarios){
                            if(item!= null){
                                Console.WriteLine($"ID : {item.id} , Nome : {item.nome} , Salario R${item.salarioBruto}");
                            }
                        }
                        break;
                    case 12:
                        Relatorio.EasterEgg();
                        break;
                    case 0://   Sair     //
                        Console.WriteLine("Aperte qualquer tecla para sair");
                        break;
                    default://  Exceção //
                        escolha = 1;
                        Relatorio.TextDecoration("Você deve escolhe qualquer uma dessas escolhas numeradas");
                        continue;
                }
                if(escolha != 0){
                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                }
            }while(escolha != 0);
            Console.ReadKey();
        }       

        
    }
}
