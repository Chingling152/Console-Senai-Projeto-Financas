using System;
using System.Text;
namespace Senai.Projeto.Financeiro.Classes
{
    /// <summary>
    /// Classe estatica usada para reaproveitamento de codigo.
    /// </summary>
    public static class Relatorio
    {
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
            Console.WriteLine($"{new string('=',mensagemSucesso.Length+4)}\n| {mensagemSucesso} |\n{new string('=',mensagemSucesso.Length+4)}");
        }

        /// <summary>
        /// Mostra que não existe funcionario com o ID inserido pelo usuario
        /// </summary>
        /// <param name="id">Posição do vetor que está com valor nulo</param>
        public static void FuncionarioNaoEncontrado(int id){
            TextDecoration($"O funcionario com o ID {id} não foi encontrado");
        }

        public static void EasterEgg(){
            Console.OutputEncoding = Encoding.ASCII;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Você Supostamente não devia estar aqui ;-;");
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