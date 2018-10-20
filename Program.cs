﻿using System;
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
            FolhaDePagamento folha = new FolhaDePagamento();

            const int tamanhoDataBase = 1001;
            folha.funcionarios = new Funcionario[tamanhoDataBase];
            MensagemSucesso("Projeto Finanças");
                  
            do{
                Console.WriteLine("");
                TextDecoration("O Que deseja fazer?");
                Console.WriteLine($"\n1- Cadastrar um Funcionario\n2- Exibir Folha De Pagamento\n3- Exibir total de custos bruto da folha de pagamento\n4- Alterar o salario de um funcionario\n5- Exibir total de custos liquido da folha de pagamento\n6- Ver maior salario\n7- Ver menor salario\n8- Alterar cadastro\n9- Remover cadastro\n0 - Sair\n10- Criar DataBase (Aleatorio)\n");
                sbyte.TryParse(Console.ReadLine().ToString(),out escolha);
                int id = 0;

                switch(escolha){
                    case 1://   Cadastrar funcionario   //
                        for(int i = 0 ; i < tamanhoDataBase-1;i++){
                            if(folha.funcionarios[i] == null){
                                folha.funcionarios[i] = new Funcionario();
                                folha.CadastrarFuncionario(i);
                                break;
                            }
                        }
                        break;
                    case 2://   Exibir folha de pagamento   //
                        TextDecoration("Digite o numero de identificação do funcionario");
                        int.TryParse(Console.ReadLine(),out id);
                        if(folha.funcionarios[id] != null){
                            folha.MostrarFolhaDePagamento(id);
                        }else{
                            folha.FuncionarioNaoEncontrado(id);
                        }
                        break;
                    case 3://   Exibir total de custos bruto    //
                        folha.TotalCustosBruto();
                        break;
                    case 4://   Aumentar Salario de um funcionario  //
                        TextDecoration("Informe o numero de identificação do funcionario no qual você quer alterar o salario");
                        int.TryParse(Console.ReadLine(),out id);
                        if(id < 1001 && id >= 0){
                            if(folha.funcionarios[id] != null){
                                folha.AlterarSalario(id);
                            }else{
                                folha.FuncionarioNaoEncontrado(id);                                
                            }
                        }else{
                            TextDecoration($"O valor inserido ({id}) não está dentro dos limites do banco de dados");
                        }
                        break;
                    case 5://   Exibir total de custos liquido da folha de pagamento    //
                        folha.TotalCustosLiquido();
                        break;
                    case 6://   Ver maior salario   //
                        folha.MaiorSalario();
                        break;
                    case 7://   Ver menor salario   //
                        folha.MenorSalario();
                        break;
                    case 8://   Alterar cadastro    //
                        Console.WriteLine("Digite o ID do funcionario que você quer alterar");
                        int.TryParse(Console.ReadLine(),out id);
                        if(id < tamanhoDataBase && id >= 0){
                            if(folha.funcionarios[id] != null){
                                folha.AlterarCadastro(id);
                            }else{
                                TextDecoration($"Não existe nenhum funcionario cadastrado no ID {id}.");
                                Console.WriteLine("\nDeseja cadastar um funcionario nesse ID?\n1- Sim\n2- Não");
                                sbyte.TryParse(Console.ReadLine(),out sbyte esc);

                                switch (esc){
                                    case 1:
                                        folha.CadastrarFuncionario(id);
                                        break;
                                    default:
                                        //porra nenhuma acontece ;-;
                                        break;
                                }
                            }
                        }else{
                            TextDecoration($"O valor inserido ({id}) não está dentro dos limites do banco de dados");
                        }
                        break;
                    case 9://   Remover cadastro    //
                        Console.WriteLine("Digite o ID do funcionario que você quer remover");
                        int.TryParse(Console.ReadLine(),out id);
                        if(id < tamanhoDataBase && id >= 0){
                            if(folha.funcionarios[id] != null){
                                Console.WriteLine($"\nDeseja mesmo excluir o Funcionario {folha.funcionarios[id].nome} no indice {id}?\n1- Sim\n2- Não");
                                sbyte.TryParse(Console.ReadLine(),out sbyte esc);

                                switch (esc){
                                    case 1:                                       
                                        MensagemSucesso($"Funcionario {folha.funcionarios[id].nome} removido com sucesso");
                                        folha.funcionarios[id] = null;
                                        break;
                                    default:
                                        //porra nenhuma acontece ;-;
                                        break;
                                }
                            }else{
                                TextDecoration($"Não há funcionario no indice {id}.");
                            }
                        }else{
                            TextDecoration($"O valor inserido ({id}) não está dentro dos limites do banco de dados");
                        }
                        break;
                    case 10:// Gerar funcionarios aleatorio //
                        TextDecoration($"Insira a quantidade de funcionarios");
                        Console.WriteLine($"um numero entre 1 e {tamanhoDataBase}");
                        int.TryParse(Console.ReadLine(),out int valor);    

                        folha.funcionarios = new Funcionario[tamanhoDataBase];   
                        
                        if(valor < tamanhoDataBase && valor > 0){
                            for(int i = 0 ; i < valor;i++){
                                folha.GerarDataBase(i);
                            }
                        }else{
                            TextDecoration("O numero inserido não é valido.");
                        }
                        break;
                    case 12:
                        Console.BackgroundColor = ConsoleColor.Red;
                        EasterEgg();
                        Console.WriteLine("Você Supostamente não devia estar aqui ;-;");
                        break;
                    case 0://   Sair     //
                        Console.WriteLine("Aperte qualquer tecla para sair");
                        break;
                    default://  Exceção //
                        escolha = 1;
                        TextDecoration("Você deve escolhe qualquer uma dessas escolhas numeradas");
                        continue;
                }
                if(escolha != 0){
                    Console.WriteLine("Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                }
            }while(escolha != 0);
            Console.ReadKey();
        }
        
        /// <summary>
        /// Apenas decora o texto com =  
        /// Exemplo : ======| Texto |======.
        /// </summary>
        /// <param name="t">Texto no qual ficará entra os "|"</param>
        public static void TextDecoration(string t){
            Console.WriteLine($"======| {t} |======");      
        }
        /// <summary>
        /// Cria linhas com = em cima e abaixo do texto selecionado , Alem de deixar | antes e depois da mensagem.  
        /// </summary>
        /// <param name="mensagemSucesso">Texto no qual ficará entra os "|"</param>
        public static void MensagemSucesso(string mensagemSucesso){
            Console.WriteLine($"{new string('=',mensagemSucesso.Length+2)}\n|{mensagemSucesso}|\n{new string('=',mensagemSucesso.Length+2)}");
        }

        static void EasterEgg(){
            Console.OutputEncoding = Encoding.ASCII;
            Console.WriteLine(@"
                ;,,,,,,;+'''''+;'+++#+++++++++++++++++++++++++++++++++'++++:,..........:+'''''';',,,++'''+''+;+++;+''+++''+
                '',:,,.,+''+''+;'+++'++++''+++++++++++++++++++++++++++++++''+++':,....;''+,.,..,,,.,'+''''''+'+;++'+++'''++
                ''',,,:,++''''+''+++'+'++''+++++++++++''+++++++++++++++++'''''+'''++''+'+++,:.,:;;,:'+''''''+';++'++'''++++
                '''',,::+,:'''+++'+'+''+++'++++++++++++++++++++++++++++++++++++'+'''++++#;',..`.;;:,++';'+''''+'++++'++++++
                +'''',:,'';;''++++++'++++'+++++++++++++++++++++++++++++++++++++++++''++++'+.,```.;:,'+';;'';#''++''++++++++
                +++++'::+';'''+'++''++'+++'++++++++++++++++++++++++++++++++'++++++++++'+''+'+.`;`;:,+++''''+'++'';#++++++++
                ++++++:,++'''+'++'++''++++'+++'++''+'++++++++++'''+''+++++++++++++++++++++++''.,.;;;+''';'+'+++'+++++++++'+
                ++++++;:+;''''''+++'++++++'+++++''++'++++++++''''++''++++++++++++++++++++++'++';,;:,''''';++'''+#++++'''+++
                ++++',::;'''+'++++'++++++++++'+'++++'''++++'''''+++''++'+++'++'+++++++++++''++'++;,,';+''++''#+++++'''+++++
                ++++';;:+'''++'+++++++++++++++'''+'''''+++''''''+'+++'''++++++++++++++++++++++++''::'+'++''+++++++''+++++++
                +++'+;:'''##+++'++++'++++++++''''+'''''+''''''''+'++''''++++''++++++++++++'++++''+;'+'+''++++++++'+++++++++
                ++++';;;';+++++++++++++++++++''''''''''''''''''+++++'''''+''''++''+'''+++++++++++++'#+';+++++++'+++++++++++
                +'+'';:;;#'+''++++++++++++++'''''''''''''''''''+++++'''''''''''+''+'''++++++++++'++++'#+++++'''++++++++++++
                +'''';;;+'+++++++++++++++++''''''''''''''+'''''++'++''''''''''''''+''+++'''+++++'++++#+++''''++++++++++++++
                +''''';''++++'+++++++++++++''''''''''''+++++'''''+'''''''''''''''+''++++++++++++'+++'#+''''++++++++++++++++
                '''''';'++'++++++++++++++++'''''''''''++'+++'''''+'''''''''''''''+''++++'''++++++++++'#''++++++++++++++++++
                '';++''+++++++++++++++++'+''''''''+''++++++++''''+''+''''''''''''+'''+++++++++++++++++'#+++++++++++++++++++
                '';+++'+'++++++++++++++++++'++'''++++++++++++''''++'+++''''''''''+''+++++++++++++++++++#+++++'+++++++++++++
                '';++'++++#++++++++++++++++++++'+++'+++++++++++'++++'++''''++''''+++'++++++++++++++++++'#+'++++++++++++++++
                '';++++++++++'+++++++++++++++++++++++++++++'+'++++++++++''+'+++++++++++++++++'+++++++++++#++++++++++++++++'
                '';'''+++#+++'++++++++++++++++++++++++++++++'+++++++++++++'++'+++++++++++++++++++++++++++++++++++++++++++++
                '';'+'++#+++++++++++++++'++++++++++++++++++++++++++++++++'++++++++++++++'++++++'++++++++++#++++++++++++++++
                '';'++++#++++'+++++++++'''''+''''+++++++'++++++++++++++++++++++++++++++++++++++++++++'+++++++++++++';++++++
                '';'''+++++++++++++++++++''++'''++++++''++++++'+++++++++++++++++++++++++++++++++++'++'++'++#++'+;;;;;#+++++
                '''++++#++++'++++++'++''+++++'++++++++++++++++++++++++++++++++++'++++'++'+++++++++++++'+'+++++++;;;;+++++++
                ;;''++++++++'+++++++++++++++++'++++++++++++#++++++++++++++++++++'++++++++++++++++++++''++'''#+++;;;;+++++++
                ;;'+++#+++++'+++++'+++++++++++'++++#+'++++++++++'+++++++++++++++++++++++++++++++++++++++'+++#+#+:::;+++++++
                ';++++#++++++++++++++#++++++++++++++'+++++++'++'++++++++++++++++++++++++++++++++++++++++'++++#++;;;;+++++++
                ''+++++++++++++++++++#++++++'+++++++++++++#+'+++++'++++++++'++++++++++++'++++++++++++++++'+''#+#:;;;+++++++
                ''+++#++++++++++++++++++++#+''++++++++++++++++++++++++++++''++++++++++++'++++++++++++++++'+++#+#:;:;#++++++
                ''''+#++++++++++++++++++++#++++++++++++++#++''++++'+++++++++++++++++++++'++++++++++++++++++++#++:;:;#++++++
                '';++#++++++++#+++++#+++++#++++++++++++++++++++++'+++#++++++++++++++++++'+++++++++++++++++'++#+#:;;;#++++++
                '';'++++++++++#+++++#+++++#+++++#+++++++#+++'++++++++':+++++++'++++++++++++++++++++++++++++++#+;;;:;+++++++
                '';+++++++++++#+++++#+++++++++++#+++++++#++++++#+++++':+++++++'++++++++++++++++++++++++++++++#+;;;:;+++++++
                ;';+++++++++++#+++++#++++++#++++#+++++++#++++++#+++++;,#+++++++++++++++++++++++++++++++++++++#+::;:;+++++++
                '';;#+++++++++#+++++#++++++#+####++++++++++++++#+++++..'+++####++++++++'+++++++++++++++++++++#+:;::;+++++++
                '';:;+++++++++#+++++#+++++++#+++###++++#+++++++#+++++.`,+#++++##+++++++++++++++++++++++++++++#+::;:;+#+++++
                '';;;+++++++++#+++++++++++++#+++#+#++++#+++++++#+++++..,#++++++#+++++++++++++++++++++++++++++#++''+++++++++
                ;';;;+++++++++#++++++#++++++''++#++++++#+++++++#+++++``,+++++++#+++#+++++++++++++++++++++++++#+;:++++++++++
                ;';:;+++++#+++#++++++#++++++;,#+#++++++#+++++++#+++++..,.'+++++#+++#++++++++++++++++++++++++#++;;++++++++++
                ;';:;+++++#+++#+++++++#+++++..`+#++++++#++++++++;++++...`.#++++#+++#++++++++++++++++++++++++#++::++++++++++
                ;';::+++++#+++++++++++++++++...``:+++++#+++++++'.+#+#:.,,`.++++#+++#++++++++++++++++++++++++#++:;#+++++++++
                ;';:;;++++#++++#++++++#+++++..,..,+++++#++++++#'.+++#'...,.,#+++#++#+++++++++++++++++++++++#+++';'+++++++++
                ;';:;:++++#++++#+++++++#++++,.``.`:+++++++++++++..#++'`., ,..#'##++++++++++++++++++++++++++#'++'+++++++++++
                ;';:;:'+++#+++++#++++++#+++#;```..`++++++++++++'.`,#+'.```,.``:##++++++++++++++++++++++++++++++++++++++++++
                '';::;:+++#+++++#++++++#'++++`..`.,.#+++#+++++++..`.++'.`.`.`...`+++#++++++++++++++++++++++++++++++++++++++
                '';:;::'++#++++++#+++++#+.++'..`..`. '++#+++++++.`..`##```````.`.,++##++++++++++++++++++++#++++++++++++++++
                '';:::::#++#++++++#+++++'..+#,.,````,`.+#+++++++`..,..`````````.`.;+##++++++++++++++++++++#'+++++#+++++++#+
                ';;::::::#+#+++++++++++++,`.````.````..``:++++++;......`````````...+++++++#++++++++++++++#+''++++#+++'#+'#+
                ';;;:::::+###++++++++#++#'`..`````````,.`.;+++++'...`,``````.`````.`#+''++#++++++++++++++#''+++++#++++#+#'+
                ';;:::::;+;';+++++++++####;..`````````.....+++++'.``.`.`.`` `````..`.#'#++#+++++++++++++#+''++++++++++++##+
                ';;::::::+';;++++++++++++,``````` ```````..`''+++'....  ``````````..`...#+++++++++++++++#+;'+++++++++++++++
                ';;::::::+'';:+++++++++++'``````````````..```,#++#:.``` ``````````..`.`.+#+#+++++++++++#'+;;++++++'++++++++
                ;;;::::::+;;;';+++++++++'+````````````````````` ```````.```.```````..`..:#++#+++#++++++;:+:'+++++;'++++++++
                ';;::::::+;';:;;++++++++++;```+@'`````.,. `````````````````````  ,+,..`,.'+##+#+``+++++':+''''+++++++++++++
                ';;::::::+;;':::'+++++++++'.` `@@@@@@@@#``````````````'@@@@@@@@@@@@+... ,.#+##'`..,#+++##+'':'++++++++++;;+
                ';;::::::'';:;::'++++++++++. ``.#@@@@@#,.```..````````.#@@@@@@@@@#;.`..`.+++#;....`#++###+;';+++++++++#+;':
                ';;::::::+'';::;;''++++++++'```.`;@@#:``.`,,`..`.````` `'@@@@@@@#,`...`.:+++'..,+..:+++';'++''+++++;#+#+:;+
                ';;::::::';;;;:;;'';#'++++#+````.`````.`..``.`.`...``.``.`.#@@+...`,``.,#+++'.;....,++++;+'':+++'++;'++,+'+
                ;;;:;::::+;;;:;::;';+,''''#'````````````.``````````````````.````.```...,+++''+.,'...+++;;'++;+++`.+''+++#:+
                ';;:;::::+;''::;,;':+:;'''#'```````````,'```````````````````.``` `.`....+++++`..+...+++#++'+'++`+++':'':,++
                ;;;:;::::'++;';,:;',+,';'+#'````.``````,'.````````````````````````..,...+++#'`.,..,:+#';;+++:';+;''';+.+,++
                ;;;:;::::'+';;;`:;':+,';'##' `````````````````````````````````````.:`. ,++++,`,'..,+++;';+++;';;':+:;':+'+'
                ;;;:;::::'+';';.::',+,;''+++````````````````````````````````````.`..,.,`'++',:',.,+##::;'+'+'+;''':'+';+++'
                ;;;:;::::+''';;:::;,+,+++++:``````````````````````````````````````.,`.`.:++'````.:+++'''+'+'''++';;''+:++'+
                ;;;:;::;;''+;;:;::;,+,+++##:`````````````````````````````````````..`,,...++;...,,++#''''''''''+:'#++'+;'+'+
                ;;;:;::;;''';;:;::;:+,+'+##'`````````````````````````````````````..`.,..,++:....+++':'''''''''+''++++++'''+
                ;;;:;:::;'+''':'::':+,;;:;#+````````````````````````````````````````....:##+,.++++;:'':;;;'''''''+#+#+#'++'
                ;;;:;:::;''+;;::,:'',,,,::##:`````````````,`..`````````.````````.`,,.`.,####++'++;;;:;;'::'';''+'++#++++'++
                ;;;:::::;''+'';;::::::,,,,##'.``````````````````.````````````````....,.:+#+++++#;;;;;;:::',;;;'+';#++++#'''
                ;;;:::::;''''';:,:::,,,,,,++##.`````````````````````````````````.`,``.:++++++++;;::;;;;;;::'::';++#+++++'''
                ;;;:::::;''';';:,::,,,,,,,;:';#.`````````````````````````````````,`..:++++++++:``;;;;;;;;;:::'::#++++++++''
                ';':::::;'';''';,,,:,,,:.,:::::+'```````````````` ``.```````````....#+++++++;::::.,:`:::;;;;:::;++++++++#+'
                ;;':::::;''+;''',,:,:,:,,,:::::;:: ````````````````.``````````.`.`'+++++#+:::::::,.`;..;::;;;;'#++++++++++'
                ;;':;:::;''+'+';::::.',,,,;::::,::@:```````````````````````````:+,;++++##':::::::;;'``;`.;;;++++++++++++++#
                ;;;:;::;;+;+'''';;:,,::,,,:::::::::,'```````````````````````,+....,++++++++:::::::::;,.,:,:++++++++++++++++
                ;;;:;:::;+''';':'::,,:,,,,::::::::::,#+ ``````````````.` ,+:...,.,,+++++++#':::::::::::``;++++++##+++++++#'
                ;;;:;:::;++'+''';;,,,,,,,,;:::::::::,`,'#.```````````.;#,`.,.......+++++++++::::::::::;''+++++++#;#++++#';;
                ';;:;;:::'+++++';'+.,..::,;::::::::;..::`.++.   .'#;,...........,..#+++++++#++###:::;++++++++++'#;;;;;;;:;;
                ';;:;;;'''+++'';';',,,,.:,::::::::::``,:.`::::::+,.,...........,.,.;++++++++++++++;;+++++++++++#;;;;;;;;;;:
                ';;:;''''++'++'+;+':,,.:,,;:::::;:;:;:::`.,,::::;,.,.....`..,.`....,+++++++++++++++#+++++++###+`;`.;;;;;;;;
                '';:;'''+'''+'+++#',;`,:,,::::::;;;:::::``::::::;.,....,.,.....,....#+++++++++++++##++++++++#+'.`::.`;;;;;;
                ';;:;'''+'+';+'+'';,;:.,,,:;:;#;`   .''':,:,;++++.,.`..,......,.....,++++++++++#@@#+.`.:#+++#:::,.`;,..';;;
                ';;;;'''+'++'+';;;;:,.:,::;;+`````.`.'##++#.````,,..``...............:####+##@@@@@#.....,.:#;:::;;.,,:..;;;
                ';;:;''''++++'';;;;;;,::.'#:````````;#+''#:```.`.'`...``..........,..,......#@@@@@',,,.....,,+:::;::``::..;
                ';':;'''''+'++'';;:;`.,,,'`````````,##+'#'`.`````'``````,.....`....,..,....'@@@@@+`,..........;;;;:;;`.`;,.
                ';';;;''+';;++:;';,,:,,,; `````````+#+++'.```````:`````.,.....`.......`,..;@@@@@#;...,.........,;;;;;;:`.:;
                ';';;;'''++';;'';;,.,:;+`..````.``,#++'#+...`````,`.```.,.....,..,..'`,`.,@@@#@@+.....,,..,......:;:;;;;,.`
                ';';;;''''';;:;;:;,`,:+`````````..+#''#'`::.````.`.````....,...,.,#..`.,.#@@@@@#'....,...........:;;;;;;;;.
                ''';;;'++'';:::;;;.,`:`.`````````,##+'#:`..+`````.`....,.....`;#: ..,`.,:@@@@@@#,....,...........:+;;:;;;:;
                ''';;;'''''':::;;;,,.``.```.```.`'+++''`...`,``````........'',`.``.`...,#@@@@@@+..,........,....,,,:;;;;;;;
                ''':';'+;;';::;'';,+ .``````````.@#++#'`````````.```..`.':````````.....;###@@@@;,,....,.......`,.,.+;;;;;;;
                ''';';+++++;::;'''+:.``..``.``.`,##+'#;.```````.``...,,.`````.``````..,#@++@@@#,`..,..,,,,....,.,..:;:;;;;;
                ''''';'++'';:;'';:`.``````````..'+'''..'```.``.`.``.`....`.``.`````...;++++@@@+......,....,....,..,,;;;;;;;
                '';;''++''+;;:;':' ```...``.```.##'+##:`;..``.`.`.`..`.````.```````.,:##+'+@@@',.........,.,.,.,...,#;;;;;;
                '';;'''+''+':'',:,````````....,,+#'#@'`+`.'`````.``...`.``..``...`...:#+'++@@#:,...........,.,.,,...,;;;;;;
                ''''';;;''+++;;'`.```````...`,.;+';``'``,:`:.``````.````.`.``````.`.,@#''++@@#.,.....,.,.....,.,.,..,;;;;;;
                '''';';'''';;:'+``.`````...,.'.##+'+`..+``'..' ```.```.`..```````..`;#+''+#@@'....,..,.,,,,...,.....,;;;;;;
                ';;:::;;;;';:;''` ``````.....,+@@#'+#'.`:'`.'`,:`...,,``..``.``````,##++++#@@'.........,....,.....,.,+;;;;;
                '':;,':'';';:;```````.`......,#++''++++#`.:;`::.',',.,.``.```..``..:#++'++#@#:,.,...,,.......,..,....';;;;;
                ;;;;';':;;;;;+,`.````...,...:#+++'+++#+`.+`.;:.',,+.,..``...``..``:##++++#@@+..,..,.......,,...,.,,,.;;;;;;
                ''::;;;;::;,;`` .````.`..`.:#+''''''+++'.`.'``'.:+.:,..``````.````'#++'+###@+.`.,,.........,....,...,,;:;;;
                ';::;:::;:::;`..``````....,#+''''+'++'#+#```.';.,`,,:'''' ```.```;#+'''+#@@@'...........,............,;;;;;
                ::::;:::::,''`..``````...,#+'+++'+'++'++##:,'`.`.``````.`:``````++#+''+#@@@@'......................,.,;;;;;
                :::;:;::;,:,```````````.:#+'''''++''+''++#'`..`````.``````,  ..#+#''+'++@@@#'.....,.,................::;;;;
                :::;:;;:;:;,.`..`````...#+''++++'++'+'##;.`.``...``.`````..'.+#+#++'+'+#@@@#'.....,..,.,,.,,...,.....,;;;;;
                ::;:::;:..`..``````````''''''''''+'++` .`````.`,````:#;'`...;#+#++'+'+++@@@#'...,.,:......,....,.....,';;;;
                ");
        }
    }
}
