namespace Senai.Projeto.Financeiro.Classes
{
    public class Funcionario
    {
        public int id;
        public string nome;
        public double salarioBruto;
        public double salarioLiquido{
            get {
                return FolhaDePagamento.SalarioLiquido(this);
            }
        }
    }
}
